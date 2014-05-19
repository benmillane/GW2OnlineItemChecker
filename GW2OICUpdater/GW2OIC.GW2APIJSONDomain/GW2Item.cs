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
        public ArmourTypeInfo armour { get; private set; }
        public BackTypeInfo back { get; private set; }
        public BagTypeInfo bag { get; private set; }
        public ConsumableTypeInfo consumable { get; private set; }
        public ContainerTypeInfo container { get; private set; }
        public GatheringTypeInfo  gathering { get; private set; }
        public GizmoTypeInfo gizmo { get; private set; }
        public ToolTypeInfo tool { get; private set; }
        public TrinketTypeInfo trinket { get; private set; }
        public UpgradeComponentTypeInfo upgradecomponent { get; private set; }
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
            this.armour = item.armour;
            this.back = item.back;
            this.bag = item.bag;
            this.consumable = item.consumable;
            this.container = item.container;
            this.gathering = item.gathering;
            this.gizmo = item.gizmo;
            this.tool = item.tool;
            this.trinket = item.trinket;
            this.upgradecomponent = item.upgradecomponent;
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
            public ArmourTypeInfo armour { get; private set; }
            public BackTypeInfo back { get; private set; }
            public BagTypeInfo bag { get; private set; }
            public ConsumableTypeInfo consumable { get; private set; }
            public ContainerTypeInfo container { get; private set; }
            public GatheringTypeInfo gathering { get; private set; }
            public GizmoTypeInfo gizmo { get; private set; }
            public ToolTypeInfo tool { get; private set; }
            public TrinketTypeInfo trinket { get; private set; }
            public UpgradeComponentTypeInfo upgradecomponent { get; private set; }
            public WeaponTypeInfo weapon { get; private set; }
        }

        /// <summary>
        /// Any GW2Item with a type of armour will have a object property called armour.
        /// This object has a unique set of properties which give additional information about the armour.
        /// </summary>
        public class ArmourTypeInfo : IItemTypeInfo
        {

            public string type { get; set; }
            public string weight_class { get; set; }
            public int defence { get; set; }
            public flagArray[] infusion_slots { get; set; }
            public InfixUpgrade infix_upgrade { get; set; }
            public int suffix_item_id { get; set; }
            public int? secondary_suffix_item_id { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of back will have a object property called back.
        /// This object has a unique set of properties which give additional information about the back.
        /// back is different to most other Item properties in that it doesn't have a property of "type"
        /// </summary>
        public class BackTypeInfo
        {
            public infusion_slot[] infusion_slots { get; set; }
            public InfixUpgrade infix_upgrade { get; set; }
            public int suffix_item_id { get; set; }
            public int? secondary_suffix_item_id { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of bag will have a object property called bag.
        /// This object has a unique set of properties which give additional information about the bag.
        /// bag is different to most other Item properties in that it doesn't have a property of "type"
        /// </summary>
        public class BagTypeInfo
        {
            public int no_sell_or_sort { get; set; }
            public int size { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of bag will have a object property called bag.
        /// This object has a unique set of properties which give additional information about the bag.
        /// bag is different to most other Item properties in that it has different states of property
        /// population based on its type. As taken from the API documentation the rules are:
         
        /// Consumable types "Generic","Food" and "Utility" may have the following properties:
        ///duration_ms (integer): effect duration in milliseconds
        ///description (string): effect descriptions

        ///Consumable types "Unlock" have the property:
        ///unlock_type (string): type of unlock
        ///Possible values:
        ///"BagSlot"
        ///"BankTab"
        ///"CollectibleCapacity"
        ///"Content"
        ///"CraftingRecipe"
        ///"Dye"

        ///Consumable types "Unlock" with "unlock_type"="CraftingRecipe" have the property:
        ///recipe_id (integer): ID of the recipe that will be unlocked after using the consumable

        ///Consumable types "Unlock" with "unlock_type"="Dye" have the property:
        ///color_id (integer): ID of the color that will be unlocked after using the consumable
        /// </summary>
        public class ConsumableTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
            public int? duration_ms { get; set; }
            public string descrition { get; set; }
            public string unlock_type { get; set; }
            public int? recipe_id { get; set; }
            public int? color_id { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of Container will have a object property called Container.
        /// This object has a unique set of properties which give additional information about the Container.
        /// </summary>
        public class ContainerTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of Gathering will have a object property called Gathering.
        /// This object has a unique set of properties which give additional information about the Gathering.
        /// </summary>
        public class GatheringTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of Gizmo will have a object property called Gizmo.
        /// This object has a unique set of properties which give additional information about the Gizmo.
        /// </summary>
        public class GizmoTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of Tool will have a object property called Tool.
        /// This object has a unique set of properties which give additional information about the Tool.
        /// </summary>
        public class ToolTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
            public int charges { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of Trinket will have a object property called Trinket.
        /// This object has a unique set of properties which give additional information about the Trinket.
        /// </summary>
        public class TrinketTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
            public infusion_slot[] infusion_slots { get; set; }
            public InfixUpgrade infix_upgrade { get; set; }
            public int suffix_item_id { get; set; }
            public int? secondary_suffix_item_id { get; set; }
        }

        public class UpgradeComponentTypeInfo : IItemTypeInfo
        {
            public string type { get; set; }
            public string[] flags { get; set; }
            public string[] infusion_upgrade_flags { get; set; }
            public InfixUpgrade infix_upgrade { get; set; }
            public string suffix { get; set; }
        }

        /// <summary>
        /// Any GW2Item with a type of weapon will have a object property called weapon.
        /// This object has a unique set of properties which give additional information about the weapon.
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
        }

        /// <summary>
        /// Used by some items, different to other properties of the same name for the other items.
        /// not an array of flags but instead an object in its own right.
        /// </summary>
        public class infusion_slot
        {
            public int item_id { get; set; }
            public string[] flags { get; set; }
        }

        /// <summary>
        /// Used by a number of IItemTypeInfo implementing classes
        /// </summary>
        public class Buff
        {
            public int skill_id { get; set; }
            public string description { get; set; }
        }

        /// <summary>
        /// Used by a number of IItemTypeInfo implementing classes
        /// </summary>
        public class Attribute
        {
            public string attribute { get; set; }
            public int modifier { get; set; }
        }

        /// <summary>
        /// Used by a number of IItemTypeInfo implementing classes
        /// </summary>
        public class InfixUpgrade
        {
            public Buff buff { get; set; }
            public Attribute[] attributes { get; set; }
        }

        /// <summary>
        /// A number of IItemTypeInfo implementing classes have a property type which is an array of flags
        /// </summary>
        public class flagArray
        {
            public string[] flags { get; set; }
        }

        /// <summary>
        /// All items from the API have a specific ItemType object as their final property.
        /// Many item types have a value of type (but not all).
        /// </summary>
        public interface IItemTypeInfo
        {
            string type { get; set; }
        }
    }

}
