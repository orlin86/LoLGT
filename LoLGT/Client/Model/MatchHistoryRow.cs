namespace App1.Model
{
    public class MatchHistoryRow
    {

        public int Id { get; set; }

        public int ChampionId { get; set; }

        public string ChampionName { get; set; }

        public string Outcome { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int MinionKills { get; set; }

        public string GameDuration { get; set; }


    }
}