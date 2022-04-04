using System.Collections.Generic;
using UniqueWordHTML.Model;

namespace UniqueWordHTML.DB
{
    static class DBWorker
    {
        public static void SaveDB(Site site, List<WordStat> result)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Sites.Add(site);
                db.WordStats.AddRange(result);
                db.SaveChanges();
            }
        }
    }
}
