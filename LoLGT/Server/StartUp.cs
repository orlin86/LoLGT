using Server.Service;
using Server.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using ServerConsoleApp;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.DataLayer;
using Server.Service;
namespace Server
{
    class StartUp
    {


        static void Main(string[] args)
        {
            // INit DB
            //    Utility.LaunchDB();
        //    Console.WriteLine(n);
             LoLClient lol = new LoLClient();
            lol.GetSummonerIdByName("Sirias");
            lol.GetSummonerMatchesById();
            lol.GetSummonerRankingById();
            lol.GetSummonerGamesById();

            LoLGTContext context = new LoLGTContext();
         //   context.
            context.Matches.Add(lol.Matches);
            context.StatsRanking.Add(lol.Ranking);
            context.SummonerGames.Add(lol.SummonerGames);
            context.SaveChanges();
            DateTime timeAtSendToClients = new DateTime();
            DateTime timeNow = new DateTime();
            // ↓ Connect to ipaddress:4649/SendData
            WebSocketServer wssv = new WebSocketServer(System.Net.IPAddress.Any, 4649);
#if DEBUG
            wssv.Log.Level = LogLevel.Trace;
#endif
            wssv.KeepClean = true;
            wssv.WaitTime = TimeSpan.FromSeconds(120);
            wssv.ReuseAddress = false;
            // ↓ Implement Server activies in SendData.cs
            wssv.AddWebSocketService<SendData>("/SendData");

       //     LoLClient lol = new LoLClient();

            Console.WriteLine();

            wssv.Start();
            timeAtSendToClients = DateTime.Now;

            string input = "";
            while (input!="stop")
            {
                timeNow = DateTime.Now;
                if (timeNow == timeAtSendToClients+TimeSpan.FromMinutes(5))
                {
                    // ↓ Tony add the data to send to the clients in SendData
                    string dataToBroadcast = "";
                    wssv.WebSocketServices["/SendData"].Sessions.Broadcast(dataToBroadcast);
                }
                if (input.Take(5).ToString().ToLower() == "send ")
                { 
                    string dataToBroadcast = input.Skip(5).ToString();
                    wssv.WebSocketServices["/SendData"].Sessions.Broadcast(dataToBroadcast);
                }

                input = "";
                try
                {
                    input = ReaderForLoops.ReadLine(150000);
                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Next loop init");
                }

            }
            wssv.Stop();
        }
    }
}
