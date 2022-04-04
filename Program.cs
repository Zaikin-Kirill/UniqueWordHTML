using System;
using UniqueWordHTML.Logger;
using UniqueWordHTML.Controller;

namespace UniqueWordHTML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            ConsoleKeyInfo key;

            do
            {
                Console.Write("\nУкажите ссылку на исследуемый сайт: ");
                string url = Console.ReadLine();

                LoggerErrors.createLog();

                Counter html = new Counter { Url = url };
                html.main();

                Console.Write("\nДля выхода нажмите клавишу 'Escape'. Для продолжения нажмите любую клавишу...");
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Escape);

        }
    }
}
