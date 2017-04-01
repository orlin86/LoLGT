using System;

namespace Server.Models
{
    using System.Collections.Generic;
    public class StatsRanking
    {
        public int SummonerId { get; set; }
        public long ModifyDate { get; set; }
        public List<Champion> Champions { get; set; }
    }
}
