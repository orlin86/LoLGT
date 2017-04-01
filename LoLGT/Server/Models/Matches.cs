using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
   public class Matches
    {

        public Matches()
        {
            this.MatchesList = new List<Match>();
        }
        [JsonProperty("matches")]
        public List<Match> MatchesList { get; set; } 
    }
}
