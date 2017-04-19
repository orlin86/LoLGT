using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using System.Threading;
using App1.Model;
namespace App1
{
    [Activity(Label = "Match History")]
    public class MatchHistoryActivity : Activity
    {
        MatchHistory matchHistory = new MatchHistory();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.match_history_layout);

            MainActivity.WsClient.ws.Send("#06");

            // ↓ Stanislav, add here method to parse the json
            ThreadPool.QueueUserWorkItem(o => MainActivity.WsClient.ws.OnMessage += (senderer, er) =>
            {
                // ↓ Incoming data from the server
                if (er.Data.Contains("#07"))
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


            var killsHeader = new TextView(this);
            killsHeader.Text = "Kills";

            var deathsHeader = new TextView(this);
            deathsHeader.Text = "Deaths";

            var assistsHeader = new TextView(this);
            assistsHeader.Text = "Assists";

            var minionHeader = new TextView(this);
            minionHeader.Text = "Minions";

            headerRow.AddView(imageHeader);
            headerRow.AddView(champNameHeader);
            headerRow.AddView(killsHeader);
            headerRow.AddView(deathsHeader);
            headerRow.AddView(assistsHeader);
            headerRow.AddView(minionHeader);

            //-----------------------------------
            //-----------------------------------


            //rest of the table (within a scroll view)
            TableLayout table = (TableLayout)FindViewById(Resource.Id.maintable);
            table.AddView(headerRow);

            var random = new Random();

            for (int i = 1; i < 100; i++)
            {
                //Get Data Row
                var matchHistoryRow = matchHistory[random.Next(0, 3)];

                //Create a new table row
                TableRow row = new TableRow(this);
                row.SetPadding(0, 20, 0, 0);
                if (i % 2 == 0)
                    row.SetBackgroundColor(Android.Graphics.Color.LightGray);

                //Create Table children(these will be the columns)
                var ChampImageView = new ImageView(this);
                var ChampionNameTexView = new TextView(this);
                var KillsTextView = new TextView(this);
                var DeathsTextView = new TextView(this);
                var AssistsTextView = new TextView(this);
                var MinionKillsView = new TextView(this);

                //Fill columns with data from the db
                ChampImageView.SetImageResource(Resource.Drawable.ahri);
                ChampionNameTexView.Text = matchHistoryRow.ChampionName;
                KillsTextView.Text = matchHistoryRow.Kills.ToString();
                DeathsTextView.Text = matchHistoryRow.Deaths.ToString();
                AssistsTextView.Text = matchHistoryRow.Assists.ToString();
                MinionKillsView.Text = matchHistoryRow.MinionKills.ToString();
            
                //append(view to the row)
                row.AddView(ChampImageView);
                row.AddView(ChampionNameTexView);
                row.AddView(KillsTextView);
                row.AddView(DeathsTextView);
                row.AddView(AssistsTextView);
                row.AddView(MinionKillsView);

                //append row to the table layout
                table.AddView(row, i);
            }

            var toolbar = FindViewById<Toolbar>(Resource.Id.match_history_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Match History";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            //Current Summoner's name which is passed from the ChampionStatisticsActivity
            var summonerName = "";
            if (this.Intent.Extras != null)
            {
                summonerName = this.Intent.Extras.GetString("summoner_name");
            }

            switch (item.ItemId)
            {
                case Resource.Id.champion_stats_menu_item:
                    var champStatsDataIntent = new Intent(this, typeof(ChampionStatisticsActivity));
                    champStatsDataIntent.PutExtra("summoner_name", summonerName);
                    StartActivity(champStatsDataIntent);
                    return true;
                default:
                    Toast.MakeText(this, "Already selected: " + item.TitleFormatted,
                        ToastLength.Short).Show();
                    return true;
            }
        }
    }
}
