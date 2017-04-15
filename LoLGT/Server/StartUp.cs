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

namespace Server
{
    class StartUp
    {


        static void Main(string[] args)
        {
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

            LoLClient client = new LoLClient();

        //    Console.WriteLine("Please enter summoner name");
       //     string name = Console.ReadLine();

       //     string summonerId = client.DownloadString(URLManager.SummonerByName(name)).ExtractID();
            try
            {
                string summonerRanksResponse = client.DownloadString(URLManager.SummonerRankingById(27786422.ToString()));
                var obj = SerializerManager.StatsRankingSerializer(summonerRanksResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Ranks for such player Id! " + ex.Message);
            }

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
