

namespace Server.Models
{
    using Newtonsoft.Json;
    public class Games
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ChampionId { get; set; }
        [JsonIgnore]
        public string ChampionName { get; set; }

        public int StatsId { get; set; }
        [JsonProperty("stats")]
        public GameStatistics Gamestatistics { get; set; }
    }
}
