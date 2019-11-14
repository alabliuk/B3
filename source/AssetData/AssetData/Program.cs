using AssetData.Business;
using AssetData.Repository;
using AssetData.UI;
using AssetData.Util;
using System;
using System.Threading;

namespace AssetData
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().StartApp();
        }

        public void StartApp()
        {
            try
            {
                new QuickEditConsole().DisableQuickEdit();

                int UserInputNumber = new MainMenu().Render();
                Console.Clear();
                switch (UserInputNumber)
                {
                    case 1:
                        Console.WriteLine("=================================================");
                        Console.WriteLine("\tLOAD ASSETS - " + DateTime.Now);
                        new AssetController().AssetManager();
                        Console.WriteLine("=================================================");
                        break;

                    case 2:
                        new StockQuoteMenu().Render();
                        break;

                    case 3:
                        new ExchangeMenu().Render();
                        break;

                    case 0:
                        new LineColorLine().Red("\n\n\tShutting down...");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;

                    default:
                        throw new Exception("Function empty...");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" ||> {DateTime.Now} --> {ex.Message}");

                try
                {
                    switch (ex.Message)
                    {
                        case ("Invalid input value..."):
                            break;

                        default:
                            new ExceptionRepository().Save(ex.Message);
                            break;
                    }
                }
                catch (Exception exLog)
                {
                    new LineColorLine().Yellow($"\n\n ||> {DateTime.Now} --> Error log error: ");
                    Console.Write(exLog.Message);
                }

                Console.ReadKey();
            }
        }
    }
}
