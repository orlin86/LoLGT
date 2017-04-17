


namespace Server
{
    using DataLayer;
    using System;
    public static class Utility
    {

        public static void LaunchDB()
        {
            var context = new LoLGTContext();

            context.Database.Initialize(true);
        }
    }
}
