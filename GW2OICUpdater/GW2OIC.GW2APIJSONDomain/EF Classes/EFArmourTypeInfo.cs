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
        public armourFlagArray[] infusion_slots { get; set; }
        public armourInfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }
    }
}
