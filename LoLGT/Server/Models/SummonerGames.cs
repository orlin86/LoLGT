
namespace Server.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public class SummonerGames
    {
        public SummonerGames()
        {
           this.Games = new HashSet<Games>();
        }
        [JsonIgnore]
        public int Id { get; set; }
        public int SummonerId { get; set; }
        public string SummonerName { get; set; }
        public ICollection<Games> Games { get; set; }
    }
}
