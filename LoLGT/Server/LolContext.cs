namespace Server
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LolContext : DbContext
    {
        public LolContext()
            : base("name=LolContext")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }

    }
}
