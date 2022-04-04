using System;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Linq;
using UniqueWordHTML.Logger;

namespace UniqueWordHTML.Controller
{
    static class Parser
    {
        static HtmlDocument htmlDoc;

        internal static bool loadSource(string url)
        {
            HtmlWeb web = new HtmlWeb();
            try
            {
                htmlDoc = web.Load(url);
            }
            catch (WebException)
            {
                LoggerErrors.writeLog($"Ошибка загрузки исходного кода по ссылке: { url }");
                return false;
            }
            catch (UriFormatException)
            {
                LoggerErrors.writeLog($"Текст: '{ url }' не является ссылкой");
                return false;
            }
            return true;

        }

        internal static string getTextHLML()
        {
            string fullText = "";
            htmlDoc.DocumentNode.Descendants().Where(n => n.Name == "script" || n.Name == "style").ToList().ForEach(n => n.Remove());
            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//body"))
            {
                string text = node.InnerText;
                if (!string.IsNullOrEmpty(text))
                {
                    fullText += text;
                }
            }

            if (fullText == "")
            {
                LoggerErrors.writeLog($"Страница не содержит слов");
                return fullText;
            }

            fullText = Regex.Replace(fullText, @"&#\d*;", "");
            fullText = Regex.Replace(fullText, "[0-9]", "", RegexOptions.IgnoreCase);

            return fullText;
        }

    }
}
