using GW2OIC.GW2APIJSONDomain;
using GW2OIC.GW2APIJSONDomain.EF_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2OIC.BLL.Mapping
{

    public class APIToEFMapper
    {
        public void ConvertAPIItemToEFItem(GW2Item apiItem)
        {
            EFGW2Item efItem = new EFGW2Item();

            if (!PopulateStandardProperties(apiItem, efItem))
            {
                throw new InvalidOperationException("Unable to convert apiItem to database item");
            }

        }

        /// <summary>
        /// Create base item for database
        /// </summary>
        /// <param name="apiItem"></param>
        /// <param name="efItem"></param>
        /// <returns></returns>
        private bool PopulateStandardProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    //Standard properties
                    efItem.item_id = apiItem.item_id;
                    efItem.name = apiItem.name;
                    efItem.description = apiItem.description;
                    efItem.type = apiItem.type;
                    efItem.level = apiItem.level;
                    efItem.rarity = apiItem.rarity;
                    efItem.vendor_value = apiItem.vendor_value;
                    efItem.icon_file_id = apiItem.icon_file_id;
                    efItem.icon_file_signature = apiItem.icon_file_signature;
                    efItem.default_skin = apiItem.default_skin;

                    context.GW2Items.Add(efItem);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Unable to populate standard properties");
                return false;
            }

        }

        /// <summary>
        /// Create database entries for each item in the 3 arrays that belong to the API item.
        /// Linked to the main EFGW2Item by its ID property.
        /// </summary>
        /// <param name="apiItem"></param>
        /// <param name="efItem"></param>
        /// <returns></returns>
        private bool PopulateArrayProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    foreach (string i in apiItem.game_types)
                    {
                        EFGame_Type gt = new EFGame_Type();
                        gt.EFGW2ItemID = efItem.EFGW2ItemID;
                        gt.gameType = i;
                        context.GW2Game_Types.Add(gt);
                        context.SaveChanges();
                    }

                    foreach (string i in apiItem.flags)
                    {
                        EFFlag flag = new EFFlag();
                        flag.EFGW2ItemID = efItem.EFGW2ItemID;
                        flag.flag = i;
                        context.GW2Flags.Add(flag);
                        context.SaveChanges();
                    }

                    foreach (string i in apiItem.restrictions)
                    {
                        EFRestriction res = new EFRestriction();
                        res.EFGW2ItemID = efItem.EFGW2ItemID;
                        res.restriction = i;
                        context.GW2Restrictions.Add(res);
                        context.SaveChanges();
                    }

                    return true;
                }

            }
            catch
            {
                Console.WriteLine("Unable to add array properties");
                return false;
            }
        }

        /// <summary>
        /// Creates a database entry for the armour sub type plus all of its children types.
        /// </summary>
        /// <param name="apiItem"></param>
        /// <param name="efItem"></param>
        /// <returns></returns>
        private bool PopulateArmorProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFArmorTypeInfo arm = new EFArmorTypeInfo();
                    arm.EFGW2ItemID = efItem.EFGW2ItemID;
                    arm.type = apiItem.armor.type;
                    arm.weight_class = apiItem.armor.weight_class;
                    arm.defence = apiItem.armor.defence;
                    arm.suffix_item_id = apiItem.armor.suffix_item_id;
                    arm.secondary_suffix_item_id = apiItem.armor.secondary_suffix_item_id;
                    context.GW2Armors.Add(arm);
                    context.SaveChanges();

                    foreach (var i in apiItem.armor.infusion_slots)
                    {

                        ArmorFlagArray FA = new ArmorFlagArray();
                        FA.EFArmorTypeInfoID = arm.EFArmorTypeInfoID;
                        context.GW2ArmourFlag.Add(FA);
                        context.SaveChanges();

                        foreach (var p in i.flags)
                        {
                            ArmorFlagArrayString FAS = new ArmorFlagArrayString();
                            FAS.ArmorFlagArrayID = FA.ArmorFlagArrayID;
                            FAS.flag = p;
                            context.GW2ArmourFlagString.Add(FAS);
                            context.SaveChanges();
                        }
                    }

                    ArmorInfixUpgrade infix = new ArmorInfixUpgrade();
                    infix.EFArmorTypeInfoID = arm.EFArmorTypeInfoID;
                    context.GW2ArmorInfixUpgrades.Add(infix);
                    context.SaveChanges();

                    ArmorBuff AB = new ArmorBuff();
                    AB.ArmorInfixUpgradeID = infix.ArmorInfixUpgradeID;
                    AB.description = apiItem.armor.infix_upgrade.buff.description;
                    AB.skill_id = apiItem.armor.infix_upgrade.buff.skill_id;
                    context.GW2ArmorBuffs.Add(AB);
                    context.SaveChanges();

                    foreach (var i in apiItem.armor.infix_upgrade.attributes)
                    {
                        ArmorAttribute at = new ArmorAttribute();
                        at.ArmorInfixUpgradeID = infix.ArmorInfixUpgradeID;
                        at.attribute = i.attribute;
                        at.modifier = i.modifier;
                        context.GW2ArmorAttributes.Add(at);
                        context.SaveChanges();
                    }
                    return true;

                }

            }
            catch
            {
                Console.WriteLine("Unable to add armor details");
                return false;
            }
        }

        private bool PopulateBackProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try 
            { 
                using (var context = new EFGW2Context())
                {
                    EFBackTypeInfo bk = new EFBackTypeInfo();
                    bk.EFGW2ItemID = efItem.EFGW2ItemID;
                    bk.suffix_item_id = apiItem.back.suffix_item_id;
                    bk.secondary_suffix_item_id = apiItem.back.suffix_item_id;
                    context.GW2Backs.Add(bk);
                    context.SaveChanges();

                    foreach (var i in apiItem.back.infusion_slots)
                    {
                        BackInfusion_Slot inf = new BackInfusion_Slot();
                        inf.EFBackTypeInfoID = bk.EFBackTypeInfoID;
                        inf.item_id = i.item_id;
                        context.GW2BackInfusion_Slots.Add(inf);
                        context.SaveChanges();

                        foreach (var p in i.flags)
                        {
                            BackFlag bf = new BackFlag();
                            bf.BackInfusion_SlotID = inf.BackInfusion_SlotID;
                            bf.flag = p;
                            context.GW2BackFlags.Add(bf);
                            context.SaveChanges();
                        }
                    }

                    BackInfixUpgrade biu = new BackInfixUpgrade();
                    biu.EFBackTypeInfoID = bk.EFBackTypeInfoID;
                    context.GW2BackInfixUpgrades.Add(biu);

                    BackBuff backB = new BackBuff();
                    backB.BackInfixUpgradeID = biu.BackInfixUpgradeID;
                    backB.description = apiItem.back.infix_upgrade.buff.description;
                    backB.skill_id = apiItem.back.infix_upgrade.buff.skill_id;
                    context.GW2BackBuffs.Add(backB);
                    context.SaveChanges();

                    foreach (var i in apiItem.back.infix_upgrade.attributes)
                    {
                        BackAttribute backA = new BackAttribute();
                        backA.BackInfixUpgradeID = biu.BackInfixUpgradeID;
                        backA.attribute = i.attribute;
                        backA.modifier = i.modifier;
                        context.GW2BackAttributes.Add(backA);
                        context.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Unable to add back details");
                return false;
            }
        }

        private bool PopulateBagProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFBagTypeInfo bag = new EFBagTypeInfo();
                    bag.EFGW2ItemID = efItem.EFGW2ItemID;
                    bag.no_sell_or_sort = apiItem.bag.no_sell_or_sort;
                    bag.size = apiItem.bag.size;
                    context.GW2Bags.Add(bag);
                    context.SaveChanges();
                }
                return true;
                
            }
            catch
            {
                Console.WriteLine("Unable to populate bag details");
                return false;
            }
        }

        private bool PopulateConsumableTypeInfo(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFConsumableTypeInfo cons = new EFConsumableTypeInfo();
                    cons.EFGW2ItemID = efItem.EFGW2ItemID;
                    cons.type = apiItem.consumable.type;
                    cons.duration_ms = apiItem.consumable.duration_ms;
                    cons.description = apiItem.consumable.description;
                    cons.unlock_type = apiItem.consumable.unlock_type;
                    cons.recipe_id = apiItem.consumable.recipe_id;
                    cons.color_id = apiItem.consumable.color_id;
                    context.GW2Consumables.Add(cons);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                Console.WriteLine("Unable to populate consumable details");
                return false;
            }
        }

        private bool PopulateContainerProperties(GW2Item apiItem, EFGW2Item efitem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFContainerTypeInfo cont = new EFContainerTypeInfo();
                    cont.EFGW2ItemID = efitem.EFGW2ItemID;
                    cont.type = apiItem.container.type;
                    context.GW2Containers.Add(cont);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Unable to populate container details");
                return false;
            }
        }

        private bool PopulateGatheringProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFGatheringTypeInfo gath = new EFGatheringTypeInfo();
                    gath.EFGW2ItemID = efItem.EFGW2ItemID;
                    gath.type = apiItem.gathering.type;
                    context.GW2Gathering.Add(gath);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Unable to populate gathering details");
                return false;
            }
        }

        private bool PopulateGizmoProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFGizmoTypeInfo giz = new EFGizmoTypeInfo();
                    giz.EFGW2ItemID = efItem.EFGW2ItemID;
                    giz.type = apiItem.gizmo.type;
                    context.GW2Gizmos.Add(giz);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Unable to populate gizmo details");
                return false;
            }
        }

        private bool PopulateToolProperties(GW2Item apiItem, EFGW2Item efItem)
        {
            try
            {
                using (var context = new EFGW2Context())
                {
                    EFToolTypeInfo tool = new EFToolTypeInfo();
                    tool.EFGW2ItemID = efItem.EFGW2ItemID;
                    tool.charges = apiItem.tool.charges;
                    tool.type = apiItem.tool.type;
                    context.GW2Tools.Add(tool);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Unable to populate tool details");
                return false;
            }
        }



            //try
            //{
            //    using (var context = new EFGW2Context())
            //    {
                    
                    //context.TYPEHERE.Add(VARHERE);
                    //context.SaveChanges();
            //    }

            //    return true;
            //}
            //catch
            //{
            //    Console.WriteLine("");
            //    return false;
            //}
            ////TODO

    }
}
