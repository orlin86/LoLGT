
namespace Server.Service
{
    using DataLayer;
    using System;
    using App1.Model;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Newtonsoft.Json;

    public class DataFetcher
    {
        public int SummonerId { get; set; }
        public string ChampionStatsData(string summonerName)
        {
            List<ChampionStatisticsRow> champStats = new List<ChampionStatisticsRow>();
            using (LoLGTContext context = new LoLGTContext())
            {
                var statsRanking = context.StatsRanking.Where(x => x.SummonerName == summonerName).FirstOrDefault();
                if (statsRanking == null)
                {
                    return "#08";
                }
                foreach (var champion in statsRanking.Champions)
                {
                    ChampionStatisticsRow newChampionDTO = new ChampionStatisticsRow();
                    var kills = champion.Stats.TotalChampionKills;
                    var deaths = champion.Stats.TotalDeathsPerSession;
                    var assists = champion.Stats.TotalAssists;
                    newChampionDTO.ChampionName = champion.ChampionName;
                    newChampionDTO.Wins = champion.Stats.TotalSessionsWon;
                    newChampionDTO.Loses = champion.Stats.TotalSessionsLost;
                    newChampionDTO.KDA = deaths == 0 ? kills + assists : (kills + assists) / deaths;
                    double totalGamePlayed = champion.Stats.TotalSessionsWon + champion.Stats.TotalSessionsLost;
                    newChampionDTO.WinRatePercentage = (((double)champion.Stats.TotalSessionsWon / totalGamePlayed) * 100).ToString();
                    newChampionDTO.MinionKills = champion.Stats.TotalMinionKills;
                    champStats.Add(newChampionDTO);
                }
            };
            return "#05" + JsonConvert.SerializeObject(champStats);
        }

        public string MatchHistoryData(string summonerName)
        {
            List<MatchHistoryRow> matchHistoryList = new List<MatchHistoryRow>();

            using (LoLGTContext context = new LoLGTContext())
            {
                var summonerGames = context.SummonerGames.Where(x => x.SummonerName == summonerName).FirstOrDefault();
                if (summonerGames == null)
                {
                    return "#09";
                }
                foreach (var game in summonerGames.Games)
                {
                    MatchHistoryRow matchHistoryDTO = new MatchHistoryRow();
                    matchHistoryDTO.ChampionName = game.ChampionName;
                    matchHistoryDTO.Outcome = game.Gamestatistics.Win == true ? "Win" : "Loss";
                    matchHistoryDTO.Kills = game.Gamestatistics.ChampionsKilled;
                    matchHistoryDTO.Deaths = game.Gamestatistics.numDeaths;
                    matchHistoryDTO.Assists = game.Gamestatistics.Assists;
                    matchHistoryList.Add(matchHistoryDTO);
                }
            }
            return "#07" + JsonConvert.SerializeObject(matchHistoryList);
        }


    }
}
