using Android.App;
using Android.Widget;
using Android.OS;

namespace Client
{
    [Activity(Label = "Client", MainLauncher = true, Icon = "@drawable/icon")]
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
        }
    }
}

