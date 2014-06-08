using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFUpgradeComponentTypeInfo
    {
        public int EFUpgradeComponentTypeInfoID { get; set; } //PK
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
        public int UpgradeComponentInfixUpgradeID { get; set; }

        //FK
        public int EFUpgradeComponentTypeInfoID { get; set; }

        //Navigation Properties
        public virtual UpgradeComponentBuff buff { get; set; }
        public virtual UpgradeComponentAttribute[] attributes { get; set; }
    }

    public class UpgradeComponentBuff
    {
        public int UpgradeComponentBuffID { get; set; }
        public int skill_id { get; set; }
        public string description { get; set; }

        //FK
        public int UpgradeComponentInfixUpgradeID { get; set; }

        //Navigation properties
        public virtual UpgradeComponentInfixUpgrade UpgradeComponentInfixUpgrade { get; set; }

    }

    public class UpgradeComponentAttribute
    {
        public int UpgradeComponentAttributeID { get; set; }
        public string attribute { get; set; }
        public int modifier { get; set; }

        //FK
        public int UpgradeComponentInfixUpgradeID { get; set; }

        //Navigation properties
        public virtual UpgradeComponentInfixUpgrade UpgradeComponentInfixUpgrade { get; set; }
    }
}
