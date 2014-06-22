using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFArmorTypeInfo
    {
        public int EFArmorTypeInfoID { get; set; } //PK
        public string type { get; set; }
        public string weight_class { get; set; }
        public int defence { get; set; }

        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Properties
        public virtual EFGW2Item EFGW2Item { get; set; }
        public virtual List<ArmorFlagArray> infusion_slots { get; set; }
        public virtual ArmorInfixUpgrade infix_upgrade { get; set; }
    }

    public class ArmorInfixUpgrade
    {
        public int ArmorInfixUpgradeID { get; set; } //PK

        //FK
        public int EFArmorTypeInfoID { get; set; }

        //Navigation Properties
        public virtual ArmorBuff buff { get; set; }
        public virtual List<ArmorAttribute> attributes { get; set; }
    }

    public class ArmorBuff
    {
        public int ArmorBuffID { get; set; } //PK
        public int skill_id { get; set; }
        public string description { get; set; }

        //FK
        public int ArmorInfixUpgradeID { get; set; }

        //Navigation Properties
        public ArmorInfixUpgrade ArmorInfixUpgrade { get; set; }
    }

    public class ArmorAttribute
    {
        public int ArmorAttributeID { get; set; } //PK
        public string attribute { get; set; }
        public int modifier { get; set; }

        //FK
        public int ArmorInfixUpgradeID { get; set; }

        //Navigation Properties
        public ArmorInfixUpgrade ArmorInfixUpgrade { get; set; }
    }

    public class ArmorFlagArray
    {
        public int ArmorFlagArrayID { get; set; } //PK

        //FK
        public int EFArmorTypeInfoID { get; set; }

        //Navigation Properties
        public virtual EFArmorTypeInfo EFArmorTypeInfo { get; set; }
    }

    public class ArmorFlagArrayString
    {
        public int ArmorFlagArrayStringID { get; set; } //PK
        public string flag { get; set; }
        
        //FK
        public int ArmorFlagArrayID { get; set; }

        //Navigation Properties
        public virtual ArmorFlagArray ArmorFlagArray { get; set; }

    }

}
