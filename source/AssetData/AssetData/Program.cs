﻿using AssetData.Business;
using AssetData.UI;
using System;

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
                        new StockQuote().Render();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        throw new Exception("Function empty...");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" --> " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
