using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GW2OIC.GW2APIJSONDomain.EF_Classes
{
    public class EFGW2Context : DbContext
    {
        public DbSet<EFGW2Item> GW2Items { get; set; }
        public DbSet<EFGame_Type> GW2Game_Types { get; set; }
        public DbSet<EFFlag> GW2Flags { get; set; }
        public DbSet<EFRestriction> GW2Restrictions { get; set; }
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
        public DbSet<ArmorFlagArray> GW2ArmourFlag { get; set; }
        public DbSet<ArmorFlagArrayString> GW2ArmourFlagString { get; set; }
        public DbSet<ArmorInfixUpgrade> GW2ArmorInfixUpgrades { get; set; }
        public DbSet<ArmorBuff> GW2ArmorBuffs { get; set; }
        public DbSet<ArmorAttribute> GW2ArmorAttributes { get; set; }
        public DbSet<BackInfusion_Slot> GW2BackInfusion_Slots { get; set; }
        public DbSet<BackFlag> GW2BackFlags { get; set; }
        public DbSet<BackInfixUpgrade> GW2BackInfixUpgrades { get; set; }
        public DbSet<BackBuff> GW2BackBuffs { get; set; }
        public DbSet<BackAttribute> GW2BackAttributes { get; set; }
    }
}
