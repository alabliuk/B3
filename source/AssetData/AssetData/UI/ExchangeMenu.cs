using AssetData.Business;
using AssetData.Repository;
using System;
using System.Collections.Generic;

namespace AssetData.UI
{
    class ExchangeMenu
    {
        public void Render(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 RUN                                         ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LIST OF CURRENCIES                          ║");
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
                    RenderParametersExchange();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad3:
                    RenderCurrencieList();
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
                    new ExchangeMenu().Render("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void RenderParametersExchange(string outputMsg = null, string status = null)
        {
            DateTime begintDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date;

            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 MARKET CURRENCIES (LAST 30 DAYS)            ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 MARKET CURRENCIES (LAST 1 YEAR)             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 MARKET CURRENCIES (LAST 5 YEARS)            ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 4 MARKET CURRENCIES (LAST 10 YEARS)           ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 5 MARKET CURRENCIES (ALL)                     ║");
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
                    begintDate = begintDate.AddDays(-30);
                    new ExchangeController().ExchangeManager(begintDate, endDate);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    begintDate = begintDate.AddDays(-365);
                    //new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    begintDate = begintDate.AddDays(-1825);
                    //new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    begintDate = begintDate.AddDays(-3650);
                    //new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    begintDate = Convert.ToDateTime("2000-01-01");
                    //new InterdayController().InterdayManager(begintDate, endDate, loadListAsset);
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Render();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;

                default:
                    new ExchangeMenu().RenderParametersExchange("Invalid input value... Try Again!", "E");
                    break;
            }
        }

        private void RenderCurrencieList(string outputMsg = null, string status = null)
        {
            Console.Clear();
            new LineColorLine().Bold("\n\nLoading market currencies...");
            List<string> exList = new ExchangeRepository().GetAllCurrencies();
            Console.Clear();
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║                                               ║");

            foreach (string ex in exList)
            {
                new LineColorLine().White("\t" + ex + "\n");
            }

            Console.WriteLine("\n");
            Console.Write("║ 1 RELOAD LIST  "); new LineColorLine().Cyan("(Check for Updates)");
            Console.WriteLine("            ║");
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
                    new ExchangeController().UpdateCurrenciesList();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Render();
                    break;

                default:
                    new ExchangeMenu().RenderCurrencieList("Invalid input value... Try Again!", "E");
                    break;
            }
        }
    }
}
