using AssetData.Business;
using System;

namespace AssetData.UI
{
    class StockQuote
    {
        public void Render(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColor().Render(outputMsg, status);
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
                    IntradayScreen();
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
                    new StockQuote().Render("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void IntradayScreen(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColor().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 RUN                                         ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LIST OF PROCESSING ASSETS                   ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 GO BACK TO MENU                             ║");
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

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListRegisteredAssets();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    new Program().StartApp();
                    break;

                default:
                    new StockQuote().IntradayScreen("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void ListRegisteredAssets(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColor().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("\t1 CEMIG4");
            Console.WriteLine("\t2 VALE3");
            Console.WriteLine("\t3 PETR4");

            Console.WriteLine("\n");
            Console.WriteLine("║ 1 ADD                                         ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 REMOVE                                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 GO BACK TO MENU                             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddOrRemoveAsset("ADD");
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    AddOrRemoveAsset("REMOVE");
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    new Program().StartApp();
                    break;

                default:
                    new StockQuote().IntradayScreen("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void AddOrRemoveAsset(string operation)
        {
            Console.WriteLine("\n\n");
            Console.Write($"{operation} Asset Code : ");
            string inputAssetCode = Console.ReadLine();

            //Verifica se há o ativo cadastrado na tabela Asset
            bool isValid = new IntradayController().IsValidAssetCode(inputAssetCode);

            if (isValid)
            {
                switch (operation)
                {
                    case "ADD":
                        new IntradayController().AddAssetOnProcessingList();
                        ListRegisteredAssets($"Ativo {inputAssetCode} cadastrado com sucesso!", "S");
                        break;

                    case "REMOVE":
                        new IntradayController().RemoveAssetOnProcessingList();
                        break;
                }
            }
            else
            {
                string outputMsg = $"Asset Code {inputAssetCode} Invalid!";
                ListRegisteredAssets(outputMsg, "E");
            }
        }
    }
}
