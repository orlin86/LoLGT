using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using App1.Model;
namespace App1
{
    [Activity(Label = "MatchHistoryActivity")]
    public class MatchHistoryActivity : Activity
    {
        MatchHistory matchHistory = new MatchHistory();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.match_history_layout);

            //Create and append header row
            TableRow headerRow = new TableRow(this);
            headerRow.SetMinimumHeight(100);



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
        }
    }
}
