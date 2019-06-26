using AssetData.Util;
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

        public void White(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(outputMsg);
            Console.ResetColor();
        }

        public void Cyan(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
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

        public void PrintResult(string asset, StatusScreen status)
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
    }
}
