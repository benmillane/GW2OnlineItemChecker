using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace GW2OIC.GW2APIJSONDomain
{
    public class GW2Item
    {

        private GW2Item item;

        //Item properties are read only
        public int item_id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public string type { get; private set; }
        public int level { get; private set; }
        public string rarity { get; private set; }
        public int vendor_value { get; private set; }
        public int icon_file_id { get; private set; }
        public string icon_file_signature { get; private set; }
        public int default_skin { get; private set; }
        public string[] game_types { get; private set; }
        public string[] flags { get; private set; }
        public string[] restrictions { get; private set; }

        async public Task<GW2Item> Create(int id)
        {
                using (HttpClient client = new HttpClient())
                {
                    //Creates an asyncronous task which will eventually return a string
                    Task<String> task = client.GetStringAsync("https://api.guildwars2.com/v1/item_details.json?item_id=" + id);

                    //Call the task and continue program execution, when the task is completed the code will run from this point.
                    string GW2APIJSON = "";
                    try { GW2APIJSON = await task; }
                    catch (Exception e) { var mess = e.Message; }

                    //Serialize the JSON response into a GW2Item object
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    this.item = jss.Deserialize<GW2Item>(GW2APIJSON);
                    UpdateItem();
                    return this;
                }
        }

        private void UpdateItem()
        {
            this.default_skin = item.default_skin;
            this.description = item.description;
            this.flags = item.flags;
            this.game_types = item.game_types;
            this.icon_file_id = item.icon_file_id;
            this.icon_file_signature = item.icon_file_signature;
            this.item_id = item.item_id;
            this.level = item.level;
            this.name = item.name;
            this.rarity = item.rarity;
            this.restrictions = item.restrictions;
            this.type = item.type;
            this.vendor_value = item.vendor_value;
        }

    }
}
