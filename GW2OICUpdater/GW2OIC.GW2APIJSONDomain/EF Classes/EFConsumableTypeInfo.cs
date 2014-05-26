using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFConsumableTypeInfo
    {
        public string type { get; set; }
        public int? duration_ms { get; set; }
        public string description { get; set; }
        public string unlock_type { get; set; }
        public int? recipe_id { get; set; }
        public int? color_id { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Property
        public virtual EFGW2Item EFGW2Item { get; set; }

    }
}
