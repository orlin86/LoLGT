namespace Server.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class LoLGTContext : DbContext
    {
        public LoLGTContext()
            : base("name=LoLGTContext")
        {
     //       Database.SetInitializer(new DropCreateDatabaseAlways<LoLGTContext>());
        }

        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<StatsRanking> StatsRanking { get; set; }
        public virtual DbSet<SummonerGames> SummonerGames { get; set; }
    }
}