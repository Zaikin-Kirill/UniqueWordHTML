

namespace UniqueWordHTML.Model
{
    class WordStat
    {
        public int Id { get; set; }
        public string Word { get; set; }

        public int Occurrences { get; set; }

        public int SiteId { get; set; }
        public Site Site { get; set; }

    }
}
