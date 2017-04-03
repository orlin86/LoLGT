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
using Android.Support.V7.Widget;
using App1.Model;

namespace App1
{
    [Activity(Label = "ChampionStatisticsActivity")]
    public class ChampionStatisticsActivity : Activity
    {
        RecyclerView mRecyclerView;

        // Layout manager that lays out each row in the RecyclerView:
        RecyclerView.LayoutManager mLayoutManager;

        // Adapter that accesses the data set (match history):
        ChampionStatisticsAdapter mAdapter;

        // Match history that is managed by the adapter:
        ChampionStatistics championStatistics;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //RecyclerView instance that displays the match history:

            SetContentView(Resource.Layout.Champion_statistics_layout);

            //TODO
            //var summonerName = Intent.Extras.GetString("summoner_name") ?? "";
            //var summonerTextField = (TextView)FindViewById<TextView>(Resource.Id.SummonerName);
            //summonerTextField.Text = summonerTextField.Text + summonerName;


            // Instantiate match history:
            championStatistics = new ChampionStatistics();


            // Set our view from the "menu" layout resource:


            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.champion_statistics_recyclerView);

            //............................................................
            // Layout Manager Setup:

            // Use the built-in linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);

            // Or use the built-in grid layout manager (two horizontal rows):
            // mLayoutManager = new GridLayoutManager
            //        (this, 2, GridLayoutManager.Horizontal, false);

            // Plug the layout manager into the RecyclerView:
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //............................................................
            // Adapter Setup:

            // Create an adapter for the RecyclerView, and pass it the
            // data set (the photo album) to manage:
            mAdapter = new ChampionStatisticsAdapter(this, championStatistics);

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);

            var toolbar = FindViewById<Toolbar>(Resource.Id.menus_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "LoL Game Tracker";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            //    ToastLength.Short).Show();

            switch (item.ItemId)
            {
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }





    //----------------------------------------------------------------------
    // ADAPTER

    // Adapter to connect the data set (match history) to the RecyclerView: 
    public class ChampionStatisticsAdapter : RecyclerView.Adapter
    {

        //----------------------------------------------------------------------
        // VIEW HOLDER

        // Implement the ViewHolder pattern: each ViewHolder holds references
        // to the UI components 
        public class ChampionStatisticsViewHolder : RecyclerView.ViewHolder
        {
            public TextView ChampionName;
            public TextView Winrate;
            public TextView Wins;
            public TextView Loses;
            public TextView KDA;
            public TextView MinionKills;
            public TextView AverageGameDuration;
            public ImageView Image;

            // Get references to the views defined in the CardView layout.
            public ChampionStatisticsViewHolder(View itemView)
                       : base(itemView)
            {
                // Locate and cache view references:
                ChampionName = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_summoner_name);
                Winrate = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_winrate);
                Wins = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_wins);
                Loses = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_loses);
                KDA = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_kda);
                MinionKills = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_minionkills);
                AverageGameDuration = itemView.FindViewById<TextView>(Resource.Id.champion_statistics_champion_avgGameDuration);
                Image = itemView.FindViewById<ImageView>(Resource.Id.champiom_image);
            }
        }
        // Underlying data set (match history):
        private ChampionStatistics championStatistics;
        private Context context;

        // Load the adapter with the data set (match history) at construction time:
        public ChampionStatisticsAdapter(Context context, ChampionStatistics championStatistics)
        {
            this.championStatistics = championStatistics;
            this.context = context;
        }


        // Create a match history view : 
        public override RecyclerView.ViewHolder
                OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            // Inflate the view for the data:
            View itemView = LayoutInflater.From(context).
                        Inflate(Resource.Layout.champion_statistics_row, parent, false);

            ChampionStatisticsViewHolder vh = new ChampionStatisticsViewHolder(itemView);
            return vh;
        }

        // Fill in the contents of the view holder (invoked by the layout manager):
        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ChampionStatisticsViewHolder vh = holder as ChampionStatisticsViewHolder;

            // Set the data in the ViewHolder's
            vh.ChampionName.Text = championStatistics[position].ChampionName;
            vh.Winrate.Text = championStatistics[position].WinRatePercentage.ToString();
            vh.Wins.Text = championStatistics[position].Wins.ToString();
            vh.Loses.Text = championStatistics[position].Loses.ToString();
            vh.KDA.Text = championStatistics[position].KDA.ToString();
            vh.MinionKills.Text = championStatistics[position].MinionKills.ToString();
            vh.AverageGameDuration.Text = championStatistics[position].AverageGameDuration.ToString();
        }

        // Return the number of rows available in match history:
        public override int ItemCount
        {
            get { return championStatistics.RowsLength; }
        }
    }
}
    
