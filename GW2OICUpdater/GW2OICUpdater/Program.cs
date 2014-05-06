using GW2OIC.GW2APIJSONDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GW2OICUpdater
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program.ShowItemInConsole();
            Console.ReadLine();
        }

        async static public void ShowItemInConsole()
        {
            GW2Item item = new GW2Item();
            GW2Item asyncItem = await item.Create(28445);
            Console.WriteLine(item.game_types);
            Console.WriteLine(item.name);
            Console.ReadLine();
        }


    }

}
