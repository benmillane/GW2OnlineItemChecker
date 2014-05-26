using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFWeaponTypeInfo
    {
        public string type { get; set; }
        public string damage_type { get; set; }
        public int min_power { get; set; }
        public int max_power { get; set; }
        public int defence { get; set; }
        public weaponFlagArray[] infusion_slots { get; set; }
        public int? suffix_item_id { get; set; }
    }
}
