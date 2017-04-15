using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace App1
{
    [Activity(Label = "LoL Game Tracker", MainLauncher = true, Icon = "@drawable/home_pic")]
    public class MainActivity : Activity
    {
        public readonly WebSocketClient WsClient = new WebSocketClient("ws://SERVER IP ADDRESS:4649/SendData");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            try
            {
                WsClient.Connect();
            }
            catch (Exception e)
            {
                // ↓ Navigate to Main Page, params CONNECTION UNAVAILABLE
            }

            ThreadPool.QueueUserWorkItem(o => WsClient.ws.OnError += (sender, e) =>
            {
                // ↓ Navigate to Main Page, params CONNECTION ERROR
            });
            ThreadPool.QueueUserWorkItem(o => WsClient.ws.OnClose += (sender, e) =>
            {
                // ↓ Navigate to Main Page, params CONNECTION CLOSED

            });

            Button searchSummonerButton = FindViewById<Button>(Resource.Id.SummonerSubmitButton);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "League of Legends Game Tracker";

            searchSummonerButton.Click += (sender, e) =>
            {
                var summonerName = FindViewById<EditText>(Resource.Id.InputSummonerName).Text;
                try
                {
                    WsClient.Send($"01{summonerName}");

                    // ↓ if WsClient.send does not succeed will close the connection and redirect to mainpage

                }
                catch (Exception exception)
                {
                    WsClient.ws.Close();
                    // redirect to mainscreen with params websocket.send error?
                }

                ThreadPool.QueueUserWorkItem(o => WsClient.ws.OnMessage += (senderer, er) =>
                {
                    // ↓ Code for Summoner exists
                    if (er.Data.Take(2).ToString() == "02")
                    {
                        var intent = new Intent(this, typeof(ChampionStatisticsActivity));
                        intent.PutExtra("summoner_name", summonerName);
                        StartActivity(intent);
                    }
                    else if (er.Data.Take(2).ToString() == "03")
                    {
                        // redirect to mainscreen with params Summoner does not exist
                    }
                });
            };
        }
    }
}

