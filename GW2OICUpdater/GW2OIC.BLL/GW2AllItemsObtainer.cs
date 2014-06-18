using GW2OIC.GW2APIJSONDomain.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GW2OIC.GW2APIJSONDomain
{
    public class GW2AllItemsObtainer
    {
        public static List<string> GetAllGW2Items()
        {
            List<string> allItems = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                string AllItemsAPIList = client.GetStringAsync("https://api.guildwars2.com/v1/items.json").Result;
                string filteredAllItems = AllItemsAPIList.Remove(1, 9)
                                                            .Replace("\n", "")
                                                            .Replace("[", "")
                                                            .Replace("]", "")
                                                            .Replace("{", "")
                                                            .Replace("}", "")
                                                            .Replace("\"", "");               

                foreach (string i in filteredAllItems.Split(','))
                {
                    allItems.Add(i);
                }
            }

            return allItems;
        }

        public static void PopulateDatabase()
        {
            List<string> allItems = new List<string>();
            allItems = GetAllGW2Items();

            for(int i = 0; i < 100; i++)
            {
                //TODO
            }

        }

        public static EFGW2Item ConvertAPIItemToEFItem(GW2Item apiItem)
        {
            //TODO
            throw new NotImplementedException();
        }

    }
}

