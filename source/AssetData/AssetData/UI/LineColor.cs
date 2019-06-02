using System;
using System.Collections.Generic;
using System.Text;

namespace AssetData.UI
{
    class LineColor
    {
        public void Render(string outputMsg = null, string status = null)
        {
            switch (status)
            {
                case "E":
                    new LineColor().Red(outputMsg);
                    break;

                case "S":
                    new LineColor().Green(outputMsg);
                    break;

                case null:
                default:
                    Console.WriteLine("\n" + outputMsg);
                    break;
            }

        }

        public void Red(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Green(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
