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
            string summonerByNameUrl = @"https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/Toni?api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            string summonerMatchesById = @"https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/40738833?api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            string summonerRankingById = @"https://eune.api.pvp.net/api/lol/eune/v1.3/stats/by-summoner/27786422/ranked?season=SEASON2016&api_key=RGAPI-83bc4cd9-c0d4-4fa3-a0a9-775ea5edc1e1";
            LoLClient client = new LoLClient();
            string response =  client.DownloadString(summonerByNameUrl);


            Dictionary<string, Player> matches = SerializerManager.PlayerDataSerializer(response);    

        }
    }
}
