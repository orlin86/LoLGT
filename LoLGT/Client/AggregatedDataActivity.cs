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
using App1.Model;
namespace App1
{
    [Activity(Label = "AggregatedDataActivity")]
    public class AggregatedDataActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            var aggregatedData = new AggregatedData();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.aggregated_statistics_layout);

            //Create and append header row
            TableRow headerRow = new TableRow(this);
            headerRow.SetMinimumHeight(100);


            var imageHeader = new TextView(this);
            imageHeader.Text = "Portrait";

            var champNameHeader = new TextView(this);
            champNameHeader.Text = "Champion";


            var winsHeader = new TextView(this);
            winsHeader.Text = "Monthly Wins";

            var losesHeader = new TextView(this);
            losesHeader.Text = "Monthly Loses";

            var kdaHeader = new TextView(this);
            kdaHeader.Text = "Monthly KDA";

            var minionHeader = new TextView(this);
            minionHeader.Text = "Monthly Minions";

            headerRow.AddView(imageHeader);
            headerRow.AddView(champNameHeader);
            headerRow.AddView(winsHeader);
            headerRow.AddView(losesHeader);
            headerRow.AddView(kdaHeader);
            headerRow.AddView(minionHeader);

            //-----------------------------------
            //-----------------------------------


            //rest of the table (within a scroll view)
            TableLayout table = (TableLayout)FindViewById(Resource.Id.maintable_aggregated_data);
            table.AddView(headerRow);

            var random = new Random();

            for (int i = 1; i < 100; i++)
            {
                //Get Data Row
                var aggregatedDataRow = aggregatedData[random.Next(0, 3)];

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
                ChampionNameTexView.Text = aggregatedDataRow.ChampionName;
                WinsTextView.Text = aggregatedDataRow.Wins.ToString();
                LosesTextView.Text = aggregatedDataRow.Loses.ToString();
                KDATextView.Text = aggregatedDataRow.KDA.ToString();
                MinionKillsView.Text = aggregatedDataRow.MinionKills.ToString();

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

        }
    }
}