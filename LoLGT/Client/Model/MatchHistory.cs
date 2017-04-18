namespace App1.Model
{
    public class MatchHistory
    {
        private MatchHistoryRow[] _matchHistoryData;

        static MatchHistoryRow[] MatchHistoryData =
        {
            new MatchHistoryRow
            {
                Id = 1,
                ChampionId = Resource.Drawable.ahri,
                ChampionName = "Ahri",
                Outcome = "Win",
                Kills = 5,
                Deaths = 3,
                Assists = 4,
                MinionKills = 120
            },

            new MatchHistoryRow
            {
                Id = 2,
                ChampionId = Resource.Drawable.pantheon,
                ChampionName = "Pantheon",
                Outcome = "Loss",
                Kills = 2,
                Deaths = 5,
                Assists = 4,
                MinionKills = 80
            },

            new MatchHistoryRow
            {
                Id = 3,
                ChampionId = Resource.Drawable.elise,
                ChampionName = "Elise",
                Outcome = "Win",
                Kills = 7,
                Deaths = 4,
                Assists = 1,
                MinionKills = 220
            }

        };

        public MatchHistory()
        {
            _matchHistoryData = MatchHistoryData;
        }

        public int RowsLength
        {
            get { return MatchHistoryData.Length; }
        }

        public MatchHistoryRow this[int i]
        {
            get { return _matchHistoryData[i]; }
        }
    }
}