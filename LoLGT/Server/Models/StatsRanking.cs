using System;

namespace Server.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class StatsRanking
    {
        public int SummonerId { get; set; }
        [JsonIgnore]
        public string SummonerName { get; set; }
        public long ModifyDate { get; set; }
        public List<Champion> Champions { get; set; }
    }
}
