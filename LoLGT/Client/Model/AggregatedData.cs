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
    public class AggregatedData
    {
        private AggregatedDataRow[] _aggregatedData;

        static AggregatedDataRow[] aggregatedData =
        {
            new AggregatedDataRow
            {
                Id = 1,
                ChampionName = "Ahri",
                WinRatePercentage = "55%",
                Wins = 55,
                Loses = 45,
                KDA = 11,
                AverageGameDuration = "31.32",
                MinionKills = 210
            },

            new AggregatedDataRow
            {
                Id = 2,
                ChampionName = "Pantheon",
                WinRatePercentage = "33%",
                Wins = 33,
                Loses = 67,
                KDA = 3,
                AverageGameDuration = "38.33",
                MinionKills = 111
            },

            new AggregatedDataRow
            {
                Id = 3,
                ChampionName = "Elise",
                WinRatePercentage = "20%",
                Wins = 20,
                Loses = 80,
                KDA = 4,
                AverageGameDuration = "31.32",
                MinionKills = 55
            }

        };

        public AggregatedData()
        {
            _aggregatedData = aggregatedData;
        }

        public int RowsLength
        {
            get { return _aggregatedData.Length; }
        }

        public AggregatedDataRow this[int i]
        {
            get { return _aggregatedData[i]; }
        }
    }
}