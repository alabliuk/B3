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
                    new LineColorAlert().Error(outputMsg);
                    break;

                case "S":
                    new LineColorAlert().Success(outputMsg);
                    break;

                case "W":
                    new LineColorAlert().Warning(outputMsg);
                    break;

                case "R":
                    new LineColorAlert().Running(outputMsg);
                    break;

                case null:
                default:
                    Console.WriteLine("\n" + outputMsg);
                    break;
            }

        }

        public void Error(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ResetColor();
        }

        public void Success(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ResetColor();
        }

        public void Warning(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ResetColor();
        }

        public void Running(string outputMsg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\t" + outputMsg);
            Console.ResetColor();
        }
    }
}



