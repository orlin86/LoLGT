using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
   public class Champion
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string ChampionName { get; set; }
        public Stats Stats { get; set; }
    }
}
