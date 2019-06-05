using AssetData.Business;
using AssetData.Repository;
using System;
using System.Collections.Generic;

namespace AssetData.UI
{
    class StockQuote
    {
        public void Render(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
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
                    IntradayScreen();
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

        private void IntradayScreen(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 RUN                                         ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LIST OF PROCESSING ASSETS                   ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 9 GO BACK TO MENU                             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    RunningIntradayScreen();
                    while (true)
                    {
                        new IntradayController().IntradayManager();
                    }

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListRegisteredAssets();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    new Program().StartApp();
                    break;

                default:
                    new StockQuote().IntradayScreen("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void ListRegisteredAssets(string outputMsg = null, string status = null)
        {
            if (outputMsg is null)
                RenderAssetList();
            else
                RenderAssetList(outputMsg, status);

            Console.WriteLine("\n");
            Console.WriteLine("║ 1 ADD                                         ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 REMOVE                                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 9 GO BACK                                     ║");
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

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    IntradayScreen();
                    break;

                default:
                    new StockQuote().ListRegisteredAssets("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void RenderAssetList(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading Assets...");
            List<string> assetList = new IntradayRepository().IntradayAssetList();
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║                                               ║");

            foreach (string asset in assetList)
            {
                new LineColorLine().White("\t" + asset + "\n");
            }
        }

        public void RunningIntradayScreen(string outputMsg = null, string status = null, string asset = null)
        {
            RenderAssetList(outputMsg, status);

            if (!string.IsNullOrEmpty(outputMsg))
            {
                Console.Write("\t");
                new LineColorLine().Bold($"\n\t{asset}\t\n");
            }

            Console.WriteLine("╚═══════════════════════════════════════════════╝");
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
                inputAssetCode = inputAssetCode.ToUpper();
                switch (operation)
                {
                    case "ADD":
                        var rA = new IntradayController().AddAssetOnProcessingList(inputAssetCode);
                        ListRegisteredAssets(rA.Item1, rA.Item2);
                        break;

                    case "REMOVE":
                        var rR = new IntradayController().RemoveAssetOnProcessingList(inputAssetCode);
                        ListRegisteredAssets(rR.Item1, rR.Item2);
                        break;
                }
            }
            else
            {
                string outputMsg = $"Asset Code {inputAssetCode} Invalid!";
                ListRegisteredAssets(outputMsg, "E");
            }
        }

        private void RunIntraday()
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading Assets...");
        }
    }
}
