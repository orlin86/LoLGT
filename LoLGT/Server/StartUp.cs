using Server.Service;
using Server.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Newtonsoft.Json;

namespace Server
{
    class StartUp
    {
        static void Main(string[] args)
        {

            LoLClient client = new LoLClient();

            Console.WriteLine("Please enter summoner name");
            string name = Console.ReadLine();

            string summonerId = client.DownloadString(URLManager.SummonerByName(name)).ExtractID();
            try
            {
                string summonerRanksResponse = client.DownloadString(URLManager.SummonerRankingById(summonerId));
                var obj = SerializerManager.StatsRankingSerializer(summonerRanksResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Ranks for such player Id! " + ex.Message);
            }

            Console.WriteLine();

        }
    }
}
