using System;
using System.Collections.Generic;
using System.Text;

namespace AssetData.UI
{
    class LineColorAlert
    {
        public void Render(string outputMsg = null, string status = null)
        {
            switch (status)
            {
                case "E":
                    new LineColorAlert().Red(outputMsg);
                    break;

                case "S":
                    new LineColorAlert().Green(outputMsg);
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
            Console.ResetColor();
        }

        public void Green(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ResetColor();
        }
    }
}
