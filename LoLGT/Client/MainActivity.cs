using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace App1
{
    [Activity(Label = "LoL Game Tracker", MainLauncher = true, Icon = "@drawable/home_pic")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            /*
         // WebSocketClient:
        WebSocket ws = new WebSocket("ws://SERVER IP ADDRESS:4649/SendKills");
        ws.EmitOnPing = true;
        ws.WaitTime = TimeSpan.FromSeconds(10);
         ThreadPool.QueueUserWorkItem(o => ws.OnOpen += (sender, e) =>
         {
         }
          RunOnUiThread(() => ws.OnMessage += (sender, e) =>
         {
         }
          ThreadPool.QueueUserWorkItem(o => ws.OnError += (sender, e) =>
         {
         }
         ThreadPool.QueueUserWorkItem(o => ws.OnClose += (sender, e) =>
         {
         }
         On Connect Button add this method:
             private static void WSConnect(WebSocket ws)
                 {
                     ws.ConnectAsync();
                 }

         To send data:
         ws.Send();
     */






            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button searchSummonerButton = FindViewById<Button>(Resource.Id.SummonerSubmitButton);

            searchSummonerButton.Click += (sender, e) =>
            {
                var summonerName = FindViewById<EditText>(Resource.Id.InputSummonerName).Text;
                var intent = new Intent(this, typeof(MatchHistoryActivity));
                intent.PutExtra("summoner_name", summonerName);
                StartActivity(intent);
            };

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "LoL Game Tracker";
        }
    }
}

