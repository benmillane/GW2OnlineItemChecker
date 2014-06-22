using GW2OIC.GW2APIJSONDomain.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Data.Entity;
using GW2OIC.BLL.Mapping;

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

        async public void PopulateDatabase()
        {
            List<string> allItems = new List<string>();
            allItems = GetAllGW2Items();
            APIToEFMapper mapper = new APIToEFMapper();

            for(int i = 0; i < 100; i++)
            {
                GW2Item item = new GW2Item();
                int itemID;
                if (!Int32.TryParse(allItems.ElementAt(i), out itemID))
                {
                    continue;
                }
                await item.CreateItem(itemID);
                mapper.ConvertAPIItemToEFItem(item);
            }

        }

        

    }
}

