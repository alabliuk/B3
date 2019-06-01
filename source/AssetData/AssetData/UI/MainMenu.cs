using System;

namespace AssetData.UI
{
    class MainMenu
    {
        public int Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ Asset Service v0.1 ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 LOAD ASSETS                                 ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LOAD STOCK QUOTES                           ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 XXXXXXXXXXXXXXXX                            ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 4 YYYYYYYYYY                                  ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 5 ZZZZZZZZZZZZZZ                              ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 6 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            //>Valida entrada do usuario
            int UserInputNumber;
            ConsoleKeyInfo UserInput = Console.ReadKey();
            if (char.IsDigit(UserInput.KeyChar))
            {
                UserInputNumber = int.Parse(UserInput.KeyChar.ToString());
            }
            else
            {
                throw new Exception("Invalid input value...");
            }

            return UserInputNumber;
        }

        public void GoBackMainMenu(string outputMsg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(outputMsg);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 GO BACK TO MENU                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");

            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            //>Valida entrada do usuario
            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    new Program().StartApp();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Environment.Exit(0);
                    break;

                default:
                    new MainMenu().GoBackMainMenu("\nInvalid input value... Try Again!");
                    break;
            }
        }
    }
}
