using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFTrinketTypeInfo
    {
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
        public int item_id { get; set; }
        public string[] flags { get; set; }
    }

    public class TrinketBuff
    {
        public int skill_id { get; set; }
        public string description { get; set; }
    }

    public class TrinketAttribute
    {
        public string attribute { get; set; }
        public int modifier { get; set; }
    }

    public class TrinketInfixUpgrade
    {
        public TrinketBuff buff { get; set; }
        public TrinketAttribute[] attributes { get; set; }
    }

}
