using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFBagTypeInfo
    {
        public int EFBagTypeinfo { get; set; } //PK
        public int no_sell_or_sort { get; set; }
        public int size { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Properties
        public EFGW2Item EFGW2Item { get; set; }

    }
}
