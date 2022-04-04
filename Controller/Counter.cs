
using System;
using System.Collections.Generic;
using System.Linq;

using UniqueWordHTML.Logger;
using UniqueWordHTML.Model;
using UniqueWordHTML.DB;

namespace UniqueWordHTML.Controller
{
    class Counter
    {
        
        public string Url { get; set; }

        public void getCountUniqueWords(string fullText)
        {
            Site site = new Site { SiteName = Url, checkDate = DateTime.Now };

            char[] separators = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

            string[] words = fullText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = words.Select(q => q.ToLower().Trim()).Distinct();
            List<WordStat> result = new List<WordStat>();
            foreach (var word in uniqueWords)
            {
                result.Add(new WordStat { Word = word, Occurrences = words.Count(q => q.ToLower().Equals(word)), Site = site });
            }

            Console.WriteLine($"Результат для сайта: {site.SiteName}");
            foreach (var word in result)
            {
                Console.WriteLine($"Слово: '{word.Word}' Вхождения: {word.Occurrences}");
            }

            try
            {
                DBWorker.SaveDB(site, result);
            }
            catch (Exception ex)
            {
                LoggerErrors.writeLog($"Ошибка сохранение статистики в БД: {ex.Message}");
            }
        }

        public void main()
        {
            bool loadIsOK = Parser.loadSource(Url);
            if (loadIsOK)
            {
                string fulltext = Parser.getTextHLML();
                if (fulltext != "")
                    getCountUniqueWords(fulltext);
            }

        }
    }
}
