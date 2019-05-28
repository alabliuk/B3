
using AssetData.Business;
using System;

namespace AssetData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("Get All Assets - " + DateTime.Now);
            new AssetController().AssetManager();
            Console.WriteLine("=================================================");

            Console.Read();
        }
    }
}
