using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Startup
    {
        static void Main(string[] args)
        {
            LolContext ctx = new LolContext();
            ctx.Database.Initialize(true);
        }
    }
}
