using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Model
{
    public class ChampionStatistics
    {
        private ChampionStatisticsRow[] _championStatisticsData;

        static ChampionStatisticsRow[] championStatisticsData =
        {
            new ChampionStatisticsRow
            {
                Id = 1,
                ChampionName = "Ahri",
                WinRatePercentage = "55%",
                Wins = 55,
                Loses = 45,
                KDA = 11,
                MinionKills = 210
            },

            new ChampionStatisticsRow
            {
                Id = 2,
                ChampionName = "Pantheon",
                WinRatePercentage = "33%",
                Wins = 33,
                Loses = 67,
                KDA = 3,
                MinionKills = 111
            },

            new ChampionStatisticsRow
            {
                Id = 3,
                ChampionName = "Elise",
                WinRatePercentage = "20%",
                Wins = 20,
                Loses = 80,
                KDA = 4,
                MinionKills = 55
            }

        };

        public ChampionStatistics()
        {
            _championStatisticsData = championStatisticsData;
        }

        public int RowsLength
        {
            get { return championStatisticsData.Length; }
        }

        public ChampionStatisticsRow this[int i]
        {
            get { return _championStatisticsData[i]; }
        }
    }
}