using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFUpgradeComponentTypeInfo
    {
        public string type { get; set; }
        public string[] flags { get; set; }
        public string[] infusion_upgrade_flags { get; set; }
        public UpgradeComponentInfixUpgrade infix_upgrade { get; set; }
        public string suffix { get; set; }

        //FK
        public int EFGW2ItemID { get; set; }

        //Navigation Property
        public virtual EFGW2Item EFGW2Item { get; set; }

    }

    public class UpgradeComponentInfixUpgrade
    {
        public UpgradeComponentBuff buff { get; set; }
        public UpgradeComponentAttribute[] attributes { get; set; }
    }

    public class UpgradeComponentBuff
    {
        public int skill_id { get; set; }
        public string description { get; set; }
    }

    public class UpgradeComponentAttribute
    {
        public string attribute { get; set; }
        public int modifier { get; set; }
    }
}
