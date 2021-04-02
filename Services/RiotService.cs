using Newtonsoft.Json.Linq;
using Interfaces.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using SharedObjects.DTOs;
using SharedObjects.APIContexts;
using Microsoft.AspNetCore.Components;

namespace Services
{
    public class RiotService : IRiotService
    {

        HttpClient client;
        string apiKey = "";
        string requestUrl = "https://euw1.api.riotgames.com/tft/summoner/v1/summoners/by-name/";
        string secondRequestUrl = "https://europe.api.riotgames.com/tft/match/v1/matches/by-puuid/";
        string thirdRequestUrl = "https://europe.api.riotgames.com/tft/match/v1/matches/";
        public async Task<string> getTFTStats(string input)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            HttpResponseMessage response = await client.GetAsync(requestUrl + input);

            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                
                string id = JObject.Parse(response.Content.ReadAsStringAsync().Result).Value<string>("puuid");

                HttpResponseMessage secondResponse = await client.GetAsync(secondRequestUrl + id + "/ids?count=10");

                if (secondResponse.IsSuccessStatusCode)
                {
                    JArray matches = JArray.Parse(secondResponse.Content.ReadAsStringAsync().Result);


                    HttpResponseMessage thirdResponse = await client.GetAsync(thirdRequestUrl + matches[0].ToString());
                   // HttpResponseMessage thirdResponse = await client.GetAsync("https://europe.api.riotgames.com/tft/match/v1/matches/EUW1_5079281684");

                    if (thirdResponse.IsSuccessStatusCode)
                    {
                        JArray participants = JObject.Parse(thirdResponse.Content.ReadAsStringAsync().Result).Value<JObject>("info").Value<JArray>("participants");
                        JToken x = participants.Single(x => x.Value<string>("puuid") == id);

                        return x.Value<string>("placement");
                    }

                    return "Third call didn't work";
                }

                return "Second call didn't work";
            }

            return "First call didn't work";
        }

        public async Task<List<ValorantCharacterDto>> GetValorantCharacters()
        {
            string url = ValorantAPI.GetContents();
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            HttpResponseMessage response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                JArray participants = JObject.Parse(response.Content.ReadAsStringAsync().Result).Value<JArray>("characters");

                List<ValorantCharacterDto> Characters = participants.Select(x => new ValorantCharacterDto
                {
                    Id = (string)x["id"],
                    Name = (string)x["name"]
                }).ToList();
                return Characters.Where(x => x.Name != "Null UI Data!").ToList();
            }
            return new List<ValorantCharacterDto>();
        }
    }
}
