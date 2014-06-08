using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    /// <summary>
    /// Belongs to a EFGW2Item (single/optional)
    /// </summary>
    public class EFBackTypeInfo
    {
        public int EFBackTypeInfoID { get; set; } //PK

        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Propeties
        public virtual List<BackInfusion_Slot> infusion_slots { get; set; }
        public virtual BackInfixUpgrade infix_upgrade { get; set; }
        public virtual EFGW2Item EFGW2Item { get; set; }
    }

    /// <summary>
    /// Belongs to a EFBackTypeInfo (many)
    /// </summary>
    public class BackInfusion_Slot
    {
        public int BackInfusion_SlotID { get; set; } //PK
        public int item_id { get; set; }

        //FK
        public int EFBackTypeInfoID { get; set; }

        //Navigation Properties
        public virtual List<string> flags { get; set; }
        public virtual EFBackTypeInfo EFBackTypeInfo { get; set; }

    }

    /// <summary>
    /// Belongs to a EFBackTypeInfo (single)
    /// </summary>
    public class BackInfixUpgrade
    {
        public int BackInfixUpgradeID { get; set; } //PK

        //FK
        public int EFBackTypeInfoID { get; set; }

        //Navigation Properties
        public virtual BackBuff buff { get; set; }
        public virtual List<BackAttribute> attributes { get; set; }
        public virtual EFBackTypeInfo EFBackTypeInfo { get; set; }
    }

    /// <summary>
    /// Belongs to a BackInfixUpgrade (single)
    /// </summary>
    public class BackBuff
    {
        public int BackBuffID { get; set; } //PK
        public int skill_id { get; set; }
        public string description { get; set; }

        //FK
        public int BackInfixUpgradeID { get; set; }

        //Navigation Properties
        public virtual BackInfixUpgrade BackInfixUpgrade { get; set; }

    }

    /// <summary>
    /// Belongs to a BackInfixUpgrade (many)
    /// </summary>
    public class BackAttribute
    {
        public int BackAttributeID { get; set; } //PK
        public string attribute { get; set; }
        public int modifier { get; set; }

        //FK
        public int BackInfixUpgradeID { get; set; }

        //Navigation Properties
        public virtual BackInfixUpgrade BackInfixUpgrade { get; set; }

    }

}
