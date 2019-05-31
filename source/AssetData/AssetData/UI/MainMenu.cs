using System;

namespace AssetData.UI
{
    class MainMenu
    {
        public int Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ Asset Service v0.1 ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

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
    }
}
