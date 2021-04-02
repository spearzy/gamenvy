using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.APIContexts
{
    public static class ValorantAPI
    {
        private static string Domain = "https://eu.api.riotgames.com";
        private static string ContentsUrl = "/val/content/v1/contents?locale=en-GB";
        private static string MatchByIdUrl = "/val/match/v1/matches/{0}"; //param = matchId
        private static string MatchListByPuuIdUrl = "/val/match/v1/matchlists/by-puuid/{0}"; // param = puuid
        private static string RecentMatchesByQueue = "/val/match/v1/recent-matches/by-queue/{0}"; //param = queue e.g competitive
        private static string RankedUrl = "/val/ranked/v1/leaderboards/by-act/{actId}"; // 
        private static string StatusUrl = "/val/status/v1/platform-data";
        private static string ImageUrl = "/val/static-data/v3/items?itemListData=image";
        public static string GetContents()
        {
            return Domain + ContentsUrl;
        }
        public static string GetMatchById(string matchId)
        {
            return string.Format(Domain + MatchByIdUrl, matchId);
        }
        public static string GetMatchesByPuuid(string puuId)
        {
            return string.Format(Domain + MatchListByPuuIdUrl, puuId);
        }
        public static string GetRecentMatches(string queue)
        {
            return string.Format(Domain + RecentMatchesByQueue, queue);
        }
        public static string GetRanked(int actId)
        {
            return string.Format(Domain + RankedUrl, actId);
        }
        public static string GetHealthStatus()
        {
            return Domain + StatusUrl;
        }
    }
}
