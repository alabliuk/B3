using System;

namespace AssetData.UI
{
    class MainMenu
    {
        public int Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ Asset Service v0.3 ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.ResetColor();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 1 LOAD ASSETS                                 ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 2 LOAD STOCK QUOTES                           ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 3 EXCHANGE RATES                              ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 0 EXIT                                        ║");
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

        public void GoBackMainMenu(string outputMsg = null, string status = null)
        {
            new LineColorAlert().Render(outputMsg, status);
            Console.WriteLine("\n");
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ 9 GO BACK TO MENU                             ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║ 0 EXIT                                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            Console.Write("Insert key value : ");

            //>Valida entrada do usuario
            ConsoleKey UserInput = Console.ReadKey(true).Key;
            switch (UserInput)
            {
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    new Program().StartApp();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;

                default:
                    new MainMenu().GoBackMainMenu("Invalid input value... Try Again!", "E");
                    break;
            }
        }
    }
}
