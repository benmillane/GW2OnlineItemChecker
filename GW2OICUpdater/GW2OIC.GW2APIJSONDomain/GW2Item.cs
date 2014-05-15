using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;

namespace GW2OIC.GW2APIJSONDomain
{

    public class GW2Item
    {
        //Holds the JSON response from the API call whe GetItem is called. Can be deserialized multiple times without additional API calls.
        private string GW2APIJSON ;

        //Used to hold an internally accessible object with the same properties as GW2Item but with full read/write access within this class.
        private GW2ItemPrivate item;

        //Item properties can ONLY have values set through CreateItem to prevent creation of objects not from the API.
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

        /// <summary>
        /// Obtains JSON from the GW2 API and deserializes it into a GW2ItemPrivate Object for CreateItem to use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async private Task GetItem(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                //Obtain JSON response from GW2 API.
                GW2APIJSON = await client.GetStringAsync("https://api.guildwars2.com/v1/item_details.json?item_id=" + id);

                //Serialize the JSON response into a GW2Item object
                JavaScriptSerializer jss = new JavaScriptSerializer();
                this.item = jss.Deserialize<GW2ItemPrivate>(GW2APIJSON);
            }

        }

        //Calls GetItem to access API and then replicates the values into this object's properties.
        async public Task CreateItem(int id)
        {
            await this.GetItem(id);
            this.item_id = item.item_id;
            this.name = item.name;
            this.description = item.description;
            this.type = item.type;
            this.level = item.level;
            this.rarity = item.rarity;
            this.vendor_value = item.vendor_value;
            this.icon_file_id = item.icon_file_id;
            this.default_skin = item.default_skin;
            this.game_types = item.game_types;
            this.flags = item.flags;
            this.restrictions = item.restrictions;
        }

        public void PopulateItemTypeObject(string type)
        {
            //TODO
            //Switch for item types
            //e.g. if switch case == weapon then this.item.WeaponInfo = jss.Deserialize<WeaponInfo>(GW2APIJSON) or possibly a substring of it.
        }

        /// <summary>
        /// Used internally to hold values to be placed into the GW2Item properties.
        /// </summary>
        private class GW2ItemPrivate
        {
            public int item_id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public int level { get; set; }
            public string rarity { get; set; }
            public int vendor_value { get; set; }
            public int icon_file_id { get; set; }
            public string icon_file_signature { get; set; }
            public int default_skin { get; set; }
            public string[] game_types { get; set; }
            public string[] flags { get; set; }
            public string[] restrictions { get; set; }
        }

        private class WeaponInfo
        {
            string type { get; set; }
            string damage_type { get; set; }
            int min_power { get; set; }
            int max_power { get; set; }

        }

        //Need to create a subset of private classes for each type of "Item_type" property in the API.
        //Add a set of properties to the main GW2Item class for each of these private classes.
        //In the CreateItem function have a switch on item type and populate the new item from the
        //Class level GW2APIJSON string variable (should work).

    }

}
