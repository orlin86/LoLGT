
namespace Server.Service
{
    using Models;
    using System;
    using System.Collections.Generic;
    public static class NameManager
    {
        public static Matches MachesNameFiller(Matches matches, string summonerName, Dictionary<int, string> idAndName)
        {
            matches.SummonerName = summonerName;
            foreach (var match in matches.MatchesList)
            {
                try
                {
                    match.ChampionName = idAndName[match.ChampionId];
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error ocuured " + ex.Message);                    
                }               
            }
            return matches;
        }

        public static StatsRanking RankingNameFiller(StatsRanking ranking, string summonerName, Dictionary<int, string> idAndName)
        {
            ranking.SummonerName = summonerName;
            foreach (var champion in ranking.Champions)
            {              
                try
                {
                    champion.ChampionName = idAndName[champion.Id];
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error occured " + ex.Message);                    
                }              
            }
            return ranking;
        }
    }
}
