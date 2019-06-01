using AssetData.Business;
using System;

namespace AssetData.UI
{
    class StockQuote
    {
        public void Render(string outputMsg = null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(outputMsg);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 INTRADAY                                    ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 INTERDAY (LAST 1 WEEK)                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 INTERDAY (LAST 30 DAYS)                     ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 4 INTERDAY (LAST 1 YEAR)                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 5 INTERDAY (LAST 5 YEARS)                     ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 6 INTERDAY (LAST 10 YEARS)                    ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 7 INTERDAY (ALL)                              ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 8 GO BACK TO MENU                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 9 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    new IntradayController().IntradayManager();
                    break;

                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    new Program().StartApp();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Environment.Exit(0);
                    break;

                default:
                    new StockQuote().Render("\n\tInvalid input value... Try Again!");
                    break;
            }
        }
    }
}
