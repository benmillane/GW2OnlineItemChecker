using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFBackTypeInfo
    {
        public BackInfusion_Slot[] infusion_slots { get; set; }
        public BackInfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }
    }

    public class BackInfusion_Slot
    {
        public int item_id { get; set; }
        public string[] flags { get; set; }
    }

    public class BackInfixUpgrade
    {
        public BackBuff buff { get; set; }
        public BackAttribute[] attributes { get; set; }
    }

    public class BackBuff
    {
        public int skill_id { get; set; }
        public string description { get; set; }
    }

    public class BackAttribute
    {
        public string attribute { get; set; }
        public int modifier { get; set; }
    }

}
