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
         //RecyclerView instance that displays the match history:
                RecyclerView mRecyclerView;

                // Layout manager that lays out each row in the RecyclerView:
                RecyclerView.LayoutManager mLayoutManager;

                // Adapter that accesses the data set (match history):
                MatchHistoryAdapter mAdapter;

                // Match history that is managed by the adapter:
                MatchHistory matchHistory;

            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Menu);
                var summonerName = Intent.Extras.GetString("summoner_name") ?? "";
                var summonerTextField = (TextView)FindViewById<TextView>(Resource.Id.SummonerName);
                summonerTextField.Text = summonerTextField.Text +  summonerName;
                // Instantiate match history:
                matchHistory = new MatchHistory();


                // Set our view from the "menu" layout resource:


                // Get our RecyclerView layout:
                mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

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
                mAdapter = new MatchHistoryAdapter(this, matchHistory);

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
                case Resource.Id.champion_stats_menu_item:
                    var championstatsintent = new Intent(this, typeof(ChampionStatisticsActivity));
                    StartActivity(championstatsintent);
                    return true;

                case Resource.Id.match_history_menu_item:
                    var mainActivityIntent = new Intent(this, typeof(MainActivity));
                    StartActivity(mainActivityIntent);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }


    //----------------------------------------------------------------------
    // VIEW HOLDER

    // Implement the ViewHolder pattern: each ViewHolder holds references
    // to the UI components (ImageView and TextView) within the CardView 
    // that is displayed in a row of the RecyclerView:


    //----------------------------------------------------------------------
    // ADAPTER

    // Adapter to connect the data set (match history) to the RecyclerView: 
    public class MatchHistoryAdapter : RecyclerView.Adapter
        {

               public  class MatchHistoryViewHolder : RecyclerView.ViewHolder
               {
                   public TextView ChampionName;
                   public TextView Kills;
                   public TextView Deaths;
                   public TextView Assists;
                   public TextView Mobs;
                   public ImageView Image;

            // Get references to the views defined in the CardView layout.
            public MatchHistoryViewHolder(View itemView)
                       : base(itemView)
                   {
                // Locate and cache view references:
                       ChampionName = itemView.FindViewById<TextView>(Resource.Id.champion_name);
                       Kills = itemView.FindViewById<TextView>(Resource.Id.champion_kills);
                       Deaths = itemView.FindViewById<TextView>(Resource.Id.champion_deaths);
                       Assists = itemView.FindViewById<TextView>(Resource.Id.champion_assists);
                       Mobs = itemView.FindViewById<TextView>(Resource.Id.champion_mobs);
                       Image = itemView.FindViewById<ImageView>(Resource.Id.champiom_image);
            }
               }
        // Underlying data set (match history):
        private MatchHistory matchHistory;
            private Context context;

            // Load the adapter with the data set (match history) at construction time:
            public MatchHistoryAdapter(Context context, MatchHistory matchHistory)
            {
                this.matchHistory = matchHistory;
                this.context = context;
            }


        // Create a match history view : 
        public override RecyclerView.ViewHolder
                OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                Context context = parent.Context;
                // Inflate the view for the data:
                View itemView = LayoutInflater.From(context).
                            Inflate(Resource.Layout.match_history_row, parent, false);

                MatchHistoryViewHolder vh = new MatchHistoryViewHolder(itemView);
                return vh;
            }

            // Fill in the contents of the view holder (invoked by the layout manager):
            public override void
                OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                 MatchHistoryViewHolder vh = holder as MatchHistoryViewHolder;

                // Set the data in the ViewHolder's
                vh.ChampionName.Text = matchHistory[position].ChampionName;
                vh.Kills.Text = matchHistory[position].Kills.ToString();
                vh.Deaths.Text = matchHistory[position].Deaths.ToString();
                vh.Assists.Text = matchHistory[position].Assists.ToString();
                vh.Mobs.Text = matchHistory[position].MinionKills.ToString();
        }

            // Return the number of rows available in match history:
            public override int ItemCount
            {
                get { return matchHistory.RowsLength; }
            }
    }
}
