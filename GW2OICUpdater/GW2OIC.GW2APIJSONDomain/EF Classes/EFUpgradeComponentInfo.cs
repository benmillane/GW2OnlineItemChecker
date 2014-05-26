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
    }
}
