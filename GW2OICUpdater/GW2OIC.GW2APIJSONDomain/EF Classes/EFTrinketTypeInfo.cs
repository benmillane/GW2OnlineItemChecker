using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFTrinketTypeInfo
    {
        public int EFTrinketTypeInfo { get; set; } //PK
        public string type { get; set; }
        public TrinketInfusion_slot[] infusion_slots { get; set; }
        public TrinketInfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Property
        public virtual EFGW2Item EFGW2Item { get; set; }

    }

    public class TrinketInfusion_slot
    {
        public int TrinketInfusion_slotID { get; set; } //PK
        public int item_id { get; set; }

        //FK
        public int EFTrinketTypeInfoID { get; set; }

        //Navigation Property
        public virtual EFTrinketTypeInfo EFTrinketTypeInfo { get; set; }
        public virtual List<TrinketFlag> flags { get; set; }
    }

    public class TrinketFlag
    {
        public int TrinketFlagsID { get; set; } //PK
        public int flag { get; set; }

        //FK
        public int TrinketInfusion_slotID { get; set; }

        //Navigation Properties
        public virtual TrinketInfusion_slot TrinketInfusion_slot { get; set; }
    }

    public class TrinketInfixUpgrade
    {
        public int TrinketInfixUpgradeID { get; set; } //PK

        //FK
        public int EFTrinketTypeInfoID { get; set; }

        //Navigation Properties
        public virtual EFTrinketTypeInfo EFTrinketTypeInfo { get; set; }
        public virtual TrinketBuff buff { get; set; }
        public List<TrinketAttribute> attributes { get; set; }
    }

    /// <summary>
    /// Belongs to TrinketInfixUpgrade (single)
    /// </summary>
    public class TrinketBuff
    {
        public int TrinketBuffID { get; set; } //PK
        public int skill_id { get; set; }
        public string description { get; set; }

        //FK
        public int TrinketInfixUpgradeID { get; set; }

        //Navigation Properties
        public virtual TrinketInfixUpgrade TrinketInfixUpgrade { get; set; }

    }

    /// <summary>
    /// Belongs to TrinketInfixUpgrade (many)
    /// </summary>
    public class TrinketAttribute
    {
        public int TrinketAttributeID { get; set; } //PK
        public string attribute { get; set; }
        public int modifier { get; set; }

        //FK
        public int TrinketInfixUpgradeID { get; set; }

        //Navigation Properties
        public virtual TrinketInfixUpgrade TrinketInfixUpgrade { get; set; }
    }



}
