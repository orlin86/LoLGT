

namespace Server.ServiceConsumer
{
    using Models;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    public class LoLClient
    {
        private const string jsonFilePath = "../../AditionalFiles/IdToName.json"; // do not change

        public WebClient client;
        private Dictionary<int, string> idName;
        private Matches matches;
        private StatsRanking ranking;
        private SummonerGames summonerGames;
        private string responseCode = "";
        private string summonerRanksResponse = "";
        private string summonerMatchesResponse = "";
        private string summonerGamesResponse = "";
        private string summonerName = "";
        private int summonerId;
        public LoLClient()
        {
            this.client = new WebClient();
            this.idName = new Dictionary<int, string>();
        }

        public Matches Matches
        {
            get
            {
                return this.matches;
            }
            private set
            {
                this.matches = value;
            }
        }
        public StatsRanking Ranking
        {
            get
            {
                return this.ranking;
            }
            private set
            {
                this.ranking = value;
            }
        }
        public SummonerGames SummonerGames
        {
            get
            {
                return this.summonerGames;
            }
            private set
            {
                this.summonerGames = value;
            }
        }
        public string SummonerName
        {
            get
            {
                return this.summonerName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid Summer name " + value);
                }
                this.summonerName = value;
            }
        }

        public int SummonerId
        {
            get
            {
                return this.summonerId;
            }
            private set
            {
                this.summonerId = value;
            }
        }

        #region Get Summoner data methods

        public string GetSummonerIdByName(string sumName)
        {
            try
            {
                
                string summonerId = client.DownloadString(URLManager.SummonerByName(sumName)).ExtractID();
                this.SummonerId = int.Parse(summonerId);
                this.SummonerName = sumName;
                return responseCode = "#02";
            }
            catch (Exception ex)
            {
                return "#03";
            }
        }

        public string GetSummonerRankingById()
        {
            idName = ReaderManager.FileReader(jsonFilePath);
            try
            {
                summonerRanksResponse = client.DownloadString(URLManager.SummonerRankingById(summonerId));
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                return "#03";
            }
            try
            {
                var rankingModel = SerializerManager.StatsRankingSerializer(summonerRanksResponse);
                this.Ranking = NameManager.RankingNameFiller(rankingModel, this.SummonerName, idName);
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            return responseCode;

        }

        public string GetSummonerMatchesById()
        {
            try
            {
                summonerMatchesResponse = client.DownloadString(URLManager.SummonerMatchesById(summonerId));
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                return "#03";
            }
            try
            {
                idName = ReaderManager.FileReader(jsonFilePath);
                var matchesModel = SerializerManager.MatchesDeserializer(summonerMatchesResponse);
                matchesModel.Id = this.SummonerId;
                this.Matches = NameManager.MachesNameFiller(matchesModel, this.summonerName, idName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            return responseCode;
        }

        public string GetSummonerGamesById()
        {
            try
            {
                summonerGamesResponse = client.DownloadString(URLManager.SummonerGamesById(summonerId));
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            try
            {
                idName = ReaderManager.FileReader(jsonFilePath);
                SummonerGames summonerGamesModel = SerializerManager.SummonerGamesSerializer(summonerGamesResponse);
                this.SummonerGames = NameManager.GamesNameFiller(summonerGamesModel, this.summonerName, idName);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            return responseCode;
        }

        #endregion
    }
}
