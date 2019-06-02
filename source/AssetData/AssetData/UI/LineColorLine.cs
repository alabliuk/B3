using System;

namespace AssetData.UI
{
    class LineColorLine
    {
        public void Red(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(outputMsg);
            Console.ResetColor();
        }

        public void Green(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(outputMsg);
            Console.ResetColor();
        }

        public void Yellow(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(outputMsg);
            Console.ResetColor();
        }

        public void Bold(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(outputMsg);
            Console.ResetColor();
        }
    }
}
