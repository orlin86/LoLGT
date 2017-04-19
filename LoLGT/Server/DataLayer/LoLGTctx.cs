using Server.DataLayer;
using Server.Models;

namespace Server
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LoLGTctx : DbContext
    {

        public LoLGTctx()
            : base("name=LoLGTctx")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LoLGTctx>());

        }

        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<StatsRanking> StatsRanking { get; set; }
        public virtual DbSet<SummonerGames> SummonerGames { get; set; }
    }

 
}