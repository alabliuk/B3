using System;

namespace AssetData.UI
{
    class StockQuote
    {
        public void Render()
        {
            Console.Clear();
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
            Console.WriteLine("║ 8 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            Console.ReadKey();

        }
    }
}
