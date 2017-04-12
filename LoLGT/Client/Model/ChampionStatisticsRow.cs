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
   public class ChampionStatisticsRow
    {
        public int Id { get; set; }

        public string ChampionName { get; set; }

        public string WinRatePercentage { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int KDA { get; set; }

        public int MinionKills { get; set; }

        public string AverageGameDuration { get; set; }
    }
}