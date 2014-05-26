using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFArmourTypeInfo
    {
        public string type { get; set; }
        public string weight_class { get; set; }
        public int defence { get; set; }
        public ArmourFlagArray[] infusion_slots { get; set; }
        public ArmourInfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }
    }

    public class ArmourBuff
    {
        public int skill_id { get; set; }
        public string description { get; set; }
    }

    public class ArmourAttribute
    {
        public string attribute { get; set; }
        public int modifier { get; set; }
    }

    public class ArmourInfixUpgrade
    {
        public ArmourBuff buff { get; set; }
        public ArmourAttribute[] attributes { get; set; }
    }

    public class ArmourFlagArray
    {
        public string[] flags { get; set; }
    }

}
