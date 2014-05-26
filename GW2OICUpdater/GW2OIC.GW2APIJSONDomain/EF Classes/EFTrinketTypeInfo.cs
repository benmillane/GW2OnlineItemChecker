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
        public trinketInfusion_slot[] infusion_slots { get; set; }
        public trinketInfixUpgrade infix_upgrade { get; set; }
        public int suffix_item_id { get; set; }
        public int? secondary_suffix_item_id { get; set; }
    }
}
