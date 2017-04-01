﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Server.Models
{
  
    public class Match
    {
    //    [JsonProperty("region")]
        public string Region { get; set; }

  //      [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        [JsonProperty("champion")]
          public int? Champion { get; set; }

        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("timestamp")] 
        public long? Timestamp { get; set; }

       [JsonProperty("lane")]   
        public string Lane { get; set; }

       [JsonProperty("role")]        
       public string Role { get; set; }
    }
}
