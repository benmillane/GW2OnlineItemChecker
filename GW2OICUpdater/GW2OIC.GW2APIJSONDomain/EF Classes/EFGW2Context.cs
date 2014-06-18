using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFGW2Context : DbContext
    {
        public DbSet<EFGW2Item> GW2Items { get; set; }
        public DbSet<EFArmorTypeInfo> GW2Armors { get; set; }
        public DbSet<EFBackTypeInfo> GW2Backs { get; set; }
        public DbSet<EFBagTypeInfo> GW2Bags { get; set; }
        public DbSet<EFConsumableTypeInfo> GW2Consumables { get; set; }
        public DbSet<EFContainerTypeInfo> GW2Containers { get; set; }
        public DbSet<EFGatheringTypeInfo> GW2Gathering { get; set; }
        public DbSet<EFGizmoTypeInfo> GW2Gizmos { get; set; }
        public DbSet<EFToolTypeInfo> GW2Tools { get; set; }
        public DbSet<EFTrinketTypeInfo> GW2Trinkets { get; set; }
        public DbSet<EFUpgradeComponentTypeInfo> GW2Upgrades { get; set; }
        public DbSet<EFWeaponTypeInfo> GW2Weapons { get; set; }
    }
}
