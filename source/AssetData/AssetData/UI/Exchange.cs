using System;

namespace AssetData.UI
{
    class Exchange
    {
        public void Render(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ ! [ R$ BRL ] - [ ????? ]                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LIST CURRENCIES                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3                                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 4                                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 5                                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 6                                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 9 GO BACK TO MENU                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 0 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    //IntradayScreen();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    new Program().StartApp();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;

                default:
                    new StockQuote().Render("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void RenderCurrencieList(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading currencies...");
            //List<string> assetList = new IntradayRepository().IntradayAssetList();
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║                                               ║");

            //foreach (string asset in assetList)
            //{
            //    new LineColorLine().White("\t" + asset + "\n");
            //}
        }
    }
}
