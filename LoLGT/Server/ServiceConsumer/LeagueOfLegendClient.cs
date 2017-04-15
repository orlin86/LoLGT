

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
    public class LoLClient : WebClient
    {
        private const string jsonFilePath = "../../AditionalFiles/IdToName.json"; // do not change
        public WebClient client;
        private Dictionary<int, string> idName;
        private int summonerId;
        private Matches matches;
        private StatsRanking ranking;
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
        public string GetDataBySummonerName(string sumName)
        {
            string responseCode = "";
            string summonerRanksResponse = "";
            string summonerMatchesResponse = "";
            try
            {
                string summonerId = client.DownloadString(URLManager.SummonerByName(sumName)).ExtractID();
                this.summonerId = int.Parse(summonerId);
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                return "#03";
            }

            idName = ReaderManager.FileReader(jsonFilePath);
            try
            {
                summonerRanksResponse = client.DownloadString(URLManager.SummonerRankingById(27786422));
                responseCode = "#02";
            }
            catch (Exception ex)
            {
                return "#03";
            }
            try
            {
                var rankingModel = SerializerManager.StatsRankingSerializer(summonerRanksResponse);
                this.Ranking = NameManager.RankingNameFiller(rankingModel, sumName, idName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            try
            {
                summonerMatchesResponse = client.DownloadString(URLManager.SummonerMatchesById(27786422));
                responseCode = "#03";
            }
            catch (Exception ex)
            {
                return "#02";
            }
            try
            {
                var matchesModel = SerializerManager.MatchesDeserializer(summonerMatchesResponse);
                this.Matches = NameManager.MachesNameFiller(matchesModel, sumName, idName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Either response serializing or finding name went wrong " + ex.Message);
            }
            return responseCode;

        }
    }
}
