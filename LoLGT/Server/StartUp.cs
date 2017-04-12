using Server.Service;
using Server.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    class StartUp
    {


        static void Main(string[] args)
        {
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
            while (true)
            {
                
            }
            wssv.Stop();
        }
    }
}
