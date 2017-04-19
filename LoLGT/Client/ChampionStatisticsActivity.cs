using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using App1.Model;

namespace App1
{
    [Activity(Label = "Champion Stats")]
    public class ChampionStatisticsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            List<ChampionStatisticsRow> championStatsRowList = new List<ChampionStatisticsRow>();

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.champion_statistics_layout);

            MainActivity.WsClient.ws.Send("#04");

            // ↓ Stanislav, add here method to parse the json
            ThreadPool.QueueUserWorkItem(o => MainActivity.WsClient.ws.OnMessage += (senderer, er) =>
            {
                // ↓ Incoming data from the server
                if (er.Data.Contains("#05"))
                {
                    var json = er.Data.Substring(3);
                    // ↓ ADD THE METHOD HERE WITH json AS PARAM
                    
                }
            });

            //Create and append header row
            TableRow headerRow = new TableRow(this);
            headerRow.SetMinimumHeight(100);
            headerRow.SetPadding(0, 120, 0, 120);

            var imageHeader = new TextView(this);
            imageHeader.Text = "Portrait";

            var champNameHeader = new TextView(this);
            champNameHeader.Text = "Champion";


            var winsHeader = new TextView(this);
            winsHeader.Text = "Wins";

            var losesHeader = new TextView(this);
            losesHeader.Text = "Loses";

            var kdaHeader = new TextView(this);
            kdaHeader.Text = "KDA";

            var minionHeader = new TextView(this);
            minionHeader.Text = "Minions";

            headerRow.AddView(imageHeader);
            headerRow.AddView(champNameHeader);
            headerRow.AddView(winsHeader);
            headerRow.AddView(losesHeader);
            headerRow.AddView(kdaHeader);
            headerRow.AddView(minionHeader);

            //-----------------------------------
            //-----------------------------------


            //rest of the table (within a scroll view)
            TableLayout table = (TableLayout)FindViewById(Resource.Id.maintable_champ_stats);
            table.AddView(headerRow);

            var random = new Random();

            for (int i = 0; i < championStatsRowList.Count; i++)
            {
                //Get Data Row
                

                //Create a new table row
                TableRow row = new TableRow(this);
                row.SetPadding(0, 20, 0, 0);
                if (i % 2 == 0)
                    row.SetBackgroundColor(Android.Graphics.Color.LightGray);

                //Create Table children(these will be the columns)
                var ChampImageView = new ImageView(this);
                var ChampionNameTexView = new TextView(this);
                var WinsTextView = new TextView(this);
                var LosesTextView = new TextView(this);
                var KDATextView = new TextView(this);
                var MinionKillsView = new TextView(this);

                //Fill columns with data from the db
                ChampImageView.SetImageResource(Resource.Drawable.ahri);
                ChampionNameTexView.Text = championStatsRowList[i].ChampionName;
                WinsTextView.Text = championStatsRowList[i].Wins.ToString();
                LosesTextView.Text = championStatsRowList[i].Loses.ToString();
                KDATextView.Text = championStatsRowList[i].KDA.ToString();
                MinionKillsView.Text = championStatsRowList[i].MinionKills.ToString();

                //append(view to the row)
                row.AddView(ChampImageView);
                row.AddView(ChampionNameTexView);
                row.AddView(WinsTextView);
                row.AddView(LosesTextView);
                row.AddView(KDATextView);
                row.AddView(MinionKillsView);

                //append row to the table layout
                table.AddView(row, i);
            }

            var toolbar = FindViewById<Toolbar>(Resource.Id.champ_stats_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Champion Stats";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //Current Summoner's name which is passed from the MainActivity
            var summonerName = "";
            if (this.Intent.Extras != null)
            {
                summonerName = this.Intent.Extras.GetString("summoner_name");
            }
            switch (item.ItemId)
            {
                case Resource.Id.match_history_menu_item:
                    var MatchHistoryIntent = new Intent(this, typeof(MatchHistoryActivity));
                    MatchHistoryIntent.PutExtra("summoner_name", summonerName);
                    StartActivity(MatchHistoryIntent);
                    return true;
                default:
                    Toast.MakeText(this, "Already selected: " + item.TitleFormatted,
                        ToastLength.Short).Show();
                    return true;
            }
        }

    }
}
    
