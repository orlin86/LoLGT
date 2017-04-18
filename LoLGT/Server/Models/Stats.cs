

namespace Server.Models
{
    using Newtonsoft.Json;

    public class Stats
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string TotalSessionsPlayed { get; set; }
        public int TotalSessionsLost { get; set; }
        public int TotalSessionsWon { get; set; }
        public int TotalChampionKills { get; set; }
        public string TotalDamageDealt { get; set; }
        public string TotalDamageTaken { get; set; }
        public string MostChampionKillsPerSession { get; set; }
        public int TotalMinionKills { get; set; }
        public string TotalDoubleKills { get; set; }
        public string TotalTripleKills { get; set; }
        public string TotalQuadraKills { get; set; }
        public string TotalPentaKills { get; set; }
        public string TotalUnrealKills { get; set; }
        public int TotalDeathsPerSession { get; set; }
        public string TotalGoldEarned { get; set; }
        public string TostSpellsCast { get; set; }
        public string TotalTurretsKilled { get; set; }
        public string TotalPhysicalDamageDealt { get; set; }
        public string TotalMagicDamageDealt { get; set; }
        public string TotalFirstBlood { get; set; }
        public int TotalAssists { get; set; }
        public string TaxChampionsKilled { get; set; }
        public string MaxNumDeaths { get; set; }

    }
}
