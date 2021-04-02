using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.DTOs
{
   public class ValorantMatchDto
    {
        public string MatchId { get; set; }
        public string MapId { get; set; }
        public int GameLengthMilliseconds { get; set; }
        public long GameStartMilliseconds { get; set; }
        public string ProvisioningFLowId { get; set; }
        public bool Completed { get; set; }
        public string CustomGameName { get; set; }
        public string QueueId { get; set; }
        public string Gamemode { get; set; }
        public bool IsRanked { get; set; }
        public string SeasonId { get; set; }
    }
}
