using Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class BattleNetService : IGameService
    {
        public async Task<string> getAll(int id)
        {
            return "Hello";
        }

        public async Task<string> GetSeasonIndex()
        {
            OAuthToken oauth = RequestAuthorizationToken();
            string url = "https://eu.api.blizzard.com/data/d3/season/?access_token=" + oauth.access_token;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);


                var objects = JObject.Parse(json);
                var battleTag = GetBattleTag();
                var data = GetDiabloData("");
                return "Current Season: " + objects.Value<int>("current_season").ToString() + " BattleTag: " + battleTag + " Clan Name: " + data.guildName;

            }
        }

        private OAuthToken RequestAuthorizationToken()
        {
            var client = new RestClient("https://eu.battle.net/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id=&client_secret=", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            var token = JsonConvert.DeserializeObject<OAuthToken>(response.Content);
            return token;
        }

        private string GetBattleTag()
        {
            var client = new RestClient("https://eu.battle.net/oauth/userinfo");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter(":region", "eu");
            request.AddParameter("access_token", "");

            IRestResponse response = client.Execute(request);

            var token = JsonConvert.DeserializeObject<BattleTagResponse>(response.Content);
            return token.battletag;
        }

        private DiabloDTO GetDiabloData(string battleTag)
        {
            battleTag = battleTag.Replace("#", "%23");
            var client = new RestClient("https://eu.api.blizzard.com/d3/profile/" + battleTag + "/");
            var request = new RestRequest(Method.GET);
            request.AddParameter("access_token", "");

            IRestResponse response = client.Execute(request);

            var token = JsonConvert.DeserializeObject<DiabloDTO>(response.Content);
            return token;
        }

    }
    public class BattleTagResponse
    {
        public string sub { get; set; }
        public int id { get; set; }
        public string battletag { get; set; }
    }

    public class OAuthToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }

    public class DiabloDTO
    {
        public string battleTag { get; set; }
        public int paragonLevel { get; set; }
        public int paragonLevelHardcore { get; set; }
        public int paragonLevelSeason { get; set; }
        public int paragonLevelSeasonHardcore { get; set; }
        public string guildName { get; set; }
    }

}