namespace Server.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class LoLGTContext : DbContext
    {
        // Your context has been configured to use a 'LoLGTContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Server.DataLayer.LoLGTContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LoLGTContext' 
        // connection string in the application configuration file.
        public LoLGTContext()
            : base("name=LoLGTContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Champion> Champions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}