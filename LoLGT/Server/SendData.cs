using Server.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    public class SendData : WebSocketBehavior
    {
        public SendData()
        {
        }

        protected override void OnOpen()
        {
            Console.WriteLine("Conn opened");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            // ↓ Toni Add here the method to parse data from the LoL APi
            Console.WriteLine(e.Data);

            //If summoner exists
            LoLClient lol = new LoLClient();
            // Toni is just example of a name
            // method returns found -> #02 or not found #03 as requested 
            if (e.Data.Contains("#01"))
            {
                Send(lol.GetSummonerIdByName(e.Data.Skip(3).ToString()));
            }
            else if (e.Data.Contains("#04"))
            {
                Console.WriteLine("Send data to champ stats!");
            }
            //else
            //Send("03");
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
        }

        // To send data to a client from wssv:
        // Send()

        // To send to all clients:
        // wssv.WebSocketServices["/SendData"].Sessions.Broadcast();
    }
}
