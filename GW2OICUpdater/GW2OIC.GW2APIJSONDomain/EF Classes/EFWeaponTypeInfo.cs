using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFWeaponTypeInfo
    {
        public int EFWeaponTypeInfoID { get; set; } //PK
        public string type { get; set; }
        public string damage_type { get; set; }
        public int min_power { get; set; }
        public int max_power { get; set; }
        public int defence { get; set; }
        
        public int? suffix_item_id { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Property
        public virtual EFGW2Item EFGW2Item { get; set; }
        public virtual WeaponFlagArray[] infusion_slots { get; set; }
    }

    public class WeaponFlagArray
    {
        public int WeaponFlagArrayID { get; set; } //PK

        //FK
        public int EFWeaponTypeInfoID { get; set; }

        //Navigation Properties
        public virtual List<WeaponFlagArrayString> flags { get; set; }
        public virtual EFWeaponTypeInfo EFWeaponTypeInfo { get; set; }
    }

    public class WeaponFlagArrayString
    {
        public int WeaponFlagArrayStringID { get; set; } //PK

        //FK
        public int WeaponFlagArrayID { get; set; }

        //Navigation Properties
        public WeaponFlagArray WeaponFlagArray { get; set; }
    }
}
