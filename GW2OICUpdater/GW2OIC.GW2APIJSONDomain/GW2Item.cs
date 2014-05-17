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

    /// <summary>
    /// Represents a GW2 Item as obtained via the official online JSON API.
    /// An item cannot be populated with fake details due to private setters.
    /// A GW2Item is constructed only through the CreateItem(int id) function.
    /// IItemTypeInfo objects can currently be populated with fake details but cannot
    /// be set to a property on an instance of a real object.
    /// </summary>
    public class GW2Item
    {
        //Holds the JSON response from the API call whe GetItem is called. Can be deserialized multiple times without additional API calls.
        private string GW2APIJSON ;

        //JSON serialization object.
        JavaScriptSerializer jss = new JavaScriptSerializer();

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
        public WeaponTypeInfo weapon { get; private set; }

        /// <summary>
        /// Obtains JSON from the GW2 API and deserializes it into a GW2ItemPrivate Object for CreateItem to use
        /// </summary>
        /// <param name="id">The id of the item as per the official GW2 api</param>
        /// <returns></returns>
        async private Task GetItem(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                //Obtain JSON response from GW2 API.
                GW2APIJSON = await client.GetStringAsync("https://api.guildwars2.com/v1/item_details.json?item_id=" + id);

                //Serialize the JSON response into a GW2Item object
                this.item = jss.Deserialize<GW2ItemPrivate>(GW2APIJSON);
            }

        }

        /// <summary>
        /// Calls GetItem to access API and then replicates the values into this object's properties.
        /// </summary>
        /// <param name="id">The id of the item as per the official GW2 api</param>
        /// <returns></returns>
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
            this.icon_file_signature = item.icon_file_signature;
            this.default_skin = item.default_skin;
            this.game_types = item.game_types;
            this.flags = item.flags;
            this.restrictions = item.restrictions;
            this.weapon = item.weapon;
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
            public WeaponTypeInfo weapon { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of weapon will have a object property called weapon.
        /// This object has a unique set of properties which giove additional information about the weapon.
        /// </summary>
        public class WeaponTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
            public string damage_type { get; set; }
            public int min_power { get; set; }
            public int max_power { get; set; }
            public int defence { get; set; }
            public flagArray[] infusion_slots { get; set; }
            public int? suffix_item_id { get; set; }

            public class flagArray
            {
                public string[] flags { get; set; }
            }
        }

        /// <summary>
        /// All items from the API have a specific ItemType object as their final property.
        /// Each ItemType object has a property called type which is a string.
        /// </summary>
        public interface IItemTypeInfo
        {
            string type { get; set; }
        }
    }

}
