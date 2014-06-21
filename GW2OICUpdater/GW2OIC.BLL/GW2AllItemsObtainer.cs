using GW2OIC.GW2APIJSONDomain.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Data.Entity;

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

        async public static void PopulateDatabase()
        {
            List<string> allItems = new List<string>();
            allItems = GetAllGW2Items();

            for(int i = 0; i < 100; i++)
            {
                GW2Item item = new GW2Item();
                int itemID;
                if (!Int32.TryParse(allItems.ElementAt(i), out itemID))
                {
                    continue;
                }
                await item.CreateItem(itemID);
                ConvertAPIItemToEFItem(item);
            }

        }

        public EFGW2Item ConvertAPIItemToEFItem(GW2Item apiItem)
        {
            EFGW2Item efItem = new EFGW2Item();

            if (!PopulateStandardProperties(apiItem, efItem))
            {
                throw new InvalidOperationException("Unable to convert apiItem to database item");
            }
            

        }

        /// <summary>
        /// Create base item for database
        /// </summary>
        /// <param name="apiItem"></param>
        /// <param name="efItem"></param>
        /// <returns></returns>
        private bool PopulateStandardProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    //Standard properties
                    efItem.item_id = apiItem.item_id;
                    efItem.name = apiItem.name;
                    efItem.description = apiItem.description;
                    efItem.type = apiItem.type;
                    efItem.level = apiItem.level;
                    efItem.rarity = apiItem.rarity;
                    efItem.vendor_value = apiItem.vendor_value;
                    efItem.icon_file_id = apiItem.icon_file_id;
                    efItem.icon_file_signature = apiItem.icon_file_signature;
                    efItem.default_skin = apiItem.default_skin;

                    context.GW2Items.Add(efItem);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        private bool PopulateArrayProperties(GW2Item apiItem, EFGW2Item efItem)
        {

        }

    }
}

