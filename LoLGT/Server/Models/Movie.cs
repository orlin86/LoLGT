using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public double Rating { get; set; }
        public int DirectorId { get; set; }
        public int Duration { get; set; }

    }
}
