


namespace Server.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public class Matches
    {

        public Matches()
        {
            this.MatchesList = new HashSet<Match>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int SummonerId { get; set; }
        [JsonIgnore]
        public string SummonerName { get; set; }

        [JsonProperty("matches")]
        public ICollection<Match> MatchesList { get; set; } 
    }
}
