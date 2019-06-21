using AssetData.Business;
using AssetData.Repository;
using System;
using System.Collections.Generic;
using AssetData.Util;

namespace AssetData.UI
{
    class StockQuote
    {
        #region Share Screens
        public void Render(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 INTRADAY                                    ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 INTERDAY                                    ║");
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

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    InterdayScreen();
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
                    Render();
                    break;

                default:
                    new StockQuote().ListRegisteredAssets("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void AddOrRemoveAsset(string operation)
        {
            Console.WriteLine("\n\n");
            Console.Write($"{operation} Asset Code : ");
            string inputAssetCode = Console.ReadLine();

            //Verifica se há o ativo cadastrado na tabela Asset
            bool isValid = new ProcessingAssetController().IsValidAssetCode(inputAssetCode);

            if (isValid)
            {
                inputAssetCode = inputAssetCode.ToUpper();
                switch (operation)
                {
                    case "ADD":
                        var rA = new ProcessingAssetController().AddAssetOnProcessingList(inputAssetCode);
                        ListRegisteredAssets(rA.Item1, rA.Item2);
                        break;

                    case "REMOVE":
                        var rR = new ProcessingAssetController().RemoveAssetOnProcessingList(inputAssetCode);
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
        #endregion

        #region Intraday
        private void RunIntraday()
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading Assets...");
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

        private void RenderAssetList(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading Assets...");
            List<string> assetList = new ProcessingAssetRepository().AssetList();
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
        #endregion

        #region Interday
        public void RunInterday(string dateRange)
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading Interday...\n");
            new LineColorLine().Cyan(dateRange);
        }

        private void InterdayScreen(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 RUN (List)                                  ║");
            Console.WriteLine("║                                               ║");
            Console.Write("║ 2 RUN (All)  "); new LineColorLine().Red("[!] Slow Function Execution [!]");
            Console.WriteLine("  ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 LIST OF PROCESSING ASSETS                   ║");
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
                    RenderParametersInterday(null, null, true);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    RenderParametersInterday();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
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

        public void RenderParametersInterday(string outputMsg = null, string status = null, bool loadListAsset = default(bool))
        {
            DateTime begintDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date;

            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            new LineColorLine().Yellow("\t[!] Slow Function Execution [!]\n\n");
            Console.WriteLine("║ 1 INTERDAY (LAST 1 WEEK)                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 INTERDAY (LAST 30 DAYS)                     ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 INTERDAY (LAST 1 YEAR)                      ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 4 INTERDAY (LAST 5 YEARS)                     ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 5 INTERDAY (LAST 10 YEARS)                    ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 6 INTERDAY (ALL)                              ║");
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
                    begintDate = begintDate.AddDays(-5);
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    begintDate = begintDate.AddDays(-30);
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    begintDate = begintDate.AddDays(-365);
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    begintDate = begintDate.AddDays(-1825);
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    begintDate = begintDate.AddDays(-3650);
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    begintDate = Convert.ToDateTime("2000-01-01");
                    new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    InterdayScreen();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;

                default:
                    new StockQuote().RenderParametersInterday("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        public void RunningInterdayScreen(string asset, StatusScreen status)
        {
            switch (status)
            {
                case StatusScreen.Success:
                    new LineColorLine().Green("[Processed] - ");
                    new LineColorLine().White(asset + "\n");
                    break;

                case StatusScreen.Warning:
                    new LineColorLine().Yellow("[Warning] - ");
                    new LineColorLine().White(asset + "\n");
                    break;

                case StatusScreen.Error:
                    new LineColorLine().Red("[Error] - ");
                    new LineColorLine().White(asset + "\n");
                    break;
            }

        }

        #endregion
    }
}
