using System;
using System.Collections.Generic;

namespace UniqueWordHTML.Model
{
    class Site
    {
        public int Id { get; set; }
        public string SiteName { get; set; }

        public DateTime checkDate { get; set; }
        public List<WordStat> WordStats { get; set; } 

    }
}
