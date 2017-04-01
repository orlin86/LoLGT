using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Server.Service
{
    public static class SerializerManager
    {

        public static Matches MatchesDeserializer(string response)
        {
            Matches matches;

            try
            {
                matches = JsonConvert.DeserializeObject<Matches>(response);
                return matches;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static StatsRanking StatsRankingSerializer(string response)
        {
            StatsRanking statRanking;
            try
            {
                statRanking = JsonConvert.DeserializeObject<StatsRanking>(response);

                return statRanking;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Dictionary<string, Player> PlayerDataSerializer(string response)
        {
            Dictionary<string, Player> plData;
            try
            {
                plData = JsonConvert.DeserializeObject<Dictionary<string, Player>>(response);
                return plData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
