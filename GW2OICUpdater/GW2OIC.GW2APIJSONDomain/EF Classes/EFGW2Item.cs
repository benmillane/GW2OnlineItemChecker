using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFGW2Item
    {
        public int EFGW2ItemID { get; set; } //PK
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

        //Navigation Properties
        public virtual EFArmorTypeInfo armor { get; set; }
        public virtual EFBackTypeInfo back { get; set; }
        public virtual EFBagTypeInfo bag { get; set; }
        public virtual EFConsumableTypeInfo consumable { get; set; }
        public virtual EFContainerTypeInfo container { get; set; }
        public virtual EFGatheringTypeInfo gathering { get; set; }
        public virtual EFGizmoTypeInfo gizmo { get; set; }
        public virtual EFToolTypeInfo tool { get; set; }
        public virtual EFTrinketTypeInfo trinket { get; set; }
        public virtual EFUpgradeComponentTypeInfo upgrade_component { get; set; }
        public virtual EFWeaponTypeInfo weapon { get; set; }
    }
}
