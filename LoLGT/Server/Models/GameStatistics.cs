


namespace Server.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public  class GameStatistics
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool Win { get; set; }
        public int ChampionsKilled { get; set; }
        public int numDeaths { get; set; }
        public int Assists { get; set; }
        public int MinionsKilled { get; set; }
        public int TimePlayed { get; set; }
    }
}
