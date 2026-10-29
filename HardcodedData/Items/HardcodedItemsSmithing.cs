using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsSmithing {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Copper ore", "A pile of copper ore nuggets.", "oreCopper", ColorLib.Copper, 5));
            itemsToAdd.Add(new Item("Copper bar", "It's a bar of copper.", "barCopper", ColorLib.Copper, 10));

            itemsToAdd.Add(new Item("Tin ore", "A pile of tin ore nuggets.", "oreTin", Color.DarkGray, 15)); 
            itemsToAdd.Add(new Item("Bronze ore mix", "A mix of copper and tin ore nuggets.", "oreMixBronze", ColorLib.Bronze, 20)); 
            itemsToAdd.Add(new Item("Bronze bar", "It's a bar of bronze.", "barBronze", ColorLib.Bronze, 30));

            itemsToAdd.Add(new Item("Iron ore", "A pile of iron ore nuggets.", "oreIron", ColorLib.Bronze, 50)); 
            itemsToAdd.Add(new Item("Iron bar", "It's a bar of iron.", "barIron", ColorLib.Iron, 60));
            
            itemsToAdd.Add(new Item("Silver ore", "A pile of silver ore nuggets.", "oreSilver", ColorLib.Silver, 110)); 
            itemsToAdd.Add(new Item("Silver bar", "It's a bar of silver.", "barSilver", ColorLib.Silver, 120));
            
            itemsToAdd.Add(new Item("Gold ore", "A pile of gold ore nuggets.", "oreGold", ColorLib.Gold, 230)); 
            itemsToAdd.Add(new Item("Gold bar", "It's a bar of gold.", "barGold", ColorLib.Gold, 240));
             
            itemsToAdd.Add(new Item("Platinum ore", "A pile of platinum ore nuggets.", "orePlatinum", ColorLib.Platinum, 470)); 
            itemsToAdd.Add(new Item("Platinum bar", "It's a bar of platinum.", "barPlatinum", ColorLib.Platinum, 480));

            itemsToAdd.Add(new Item("Coal", "A lump of raw coal.", "oreCoal", Color.DimGray, 940)); 
            itemsToAdd.Add(new Item("Steel ore mix", "A mix of iron ore nuggets and coal.", "oreMixSteel", ColorLib.Steel, 990)); 
            itemsToAdd.Add(new Item("Steel bar", "It's a bar of iron.", "barSteel", ColorLib.Steel, 1000)); 
            
            itemsToAdd.Add(new Item("Cobalt ore", "A pile of cobalt ore nuggets.", "oreCobalt", ColorLib.Cobalt, 1990)); 
            itemsToAdd.Add(new Item("Cobalt bar", "It's a bar of cobalt.", "barCobalt", ColorLib.Cobalt, 2000)); 

            itemsToAdd.Add(new Item("Tungsten ore", "A pile of tungsten ore nuggets.", "oreTungsten", ColorLib.Tungsten, 3990)); 
            itemsToAdd.Add(new Item("Tungsten bar", "It's a bar of tungsten.", "barTungsten", ColorLib.Tungsten, 4000)); 
            
            itemsToAdd.Add(new Item("Titanium ore", "A pile of titanium ore nuggets.", "oreTitanium", ColorLib.Titanium, 7990)); 
            itemsToAdd.Add(new Item("Titanium bar", "It's a bar of titanium.", "barTitanium", ColorLib.Titanium, 8000));

            // Smithing Factory
            List<MaterialDef> Metals = new(Materials.Metals) {
                Materials.Tutorial
            }; 

            for (int i = 0; i < Metals.Count; i++) {
                int fullMult = Metals[i].CostMultiplier;

                Item helm = new Item(Metals[i].Name + " helmet", "Provides " + Metals[i].Descriptor + " melee protection for the head.", "helm" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 2) {
                    EquipSlot = "Head",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(helm);

                Item platebody = new Item(Metals[i].Name + " platebody", "Provides " + Metals[i].Descriptor + " melee protection for the torso.", "platebody" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 5) {
                    EquipSlot = "Body",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(platebody);

                Item chainmail = new Item(Metals[i].Name + " chainmail", "Provides " + Metals[i].Descriptor + " melee protection for the torso.", "chainmail" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 5) {
                    EquipSlot = "Body",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(chainmail);

                Item platelegs = new Item(Metals[i].Name + " platelegs", "Provides " + Metals[i].Descriptor + " melee protection for the legs.", "platelegs" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 3) {
                    EquipSlot = "Legs",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(platelegs);

                Item plateskirt = new Item(Metals[i].Name + " plateskirt", "Provides " + Metals[i].Descriptor + " melee protection for the legs.", "plateskirt" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 3) {
                    EquipSlot = "Legs",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(plateskirt);

                Item boots = new Item(Metals[i].Name + " boots", "Provides " + Metals[i].Descriptor + " melee protection for the feet.", "boots" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult) {
                    EquipSlot = "Feet",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(boots);

                Item gauntlets = new Item(Metals[i].Name + " gauntlets", "Provides " + Metals[i].Descriptor + " melee protection for the hands.", "gauntlets" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult) {
                    EquipSlot = "Hands",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(gauntlets);

                Item arrows = new Item(Metals[i].Name + " arrows", "Time flies like an arrow. Fruit flies like a banana.", "arrows" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 15, true) {
                    EquipSlot = "Ammo",  EquipTier = Metals[i].Tier, EquipSkill = "Ranged", EquipLevel = Metals[i].Level, EquipDamageType = "RangedStandard", EquipElement = "Wood"
                };
                itemsToAdd.Add(arrows);

                Item unfbolts = new Item(Metals[i].Name + " bolts (unf)", Metals[i].Name + " crossbow bolts, sans feathers.", "boltsUnf" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 15, true);
                itemsToAdd.Add(unfbolts);

                Item bolts = new Item(Metals[i].Name + " bolts", Metals[i].Name + " crossbow bolts.", "bolts" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 15, true) {
                    EquipSlot = "Ammo",  EquipTier = Metals[i].Tier, EquipSkill = "Ranged", EquipLevel = Metals[i].Level, EquipDamageType = "RangedHeavy", EquipElement = "Metal"
                };
                itemsToAdd.Add(bolts);

                Item knives = new Item(Metals[i].Name + " knives", "A finely balanced throwing knife.", "knives" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 5, true) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Ranged", EquipLevel = Metals[i].Level, EquipDamageType = "RangedLight", EquipElement = "Metal", EquipAmmo = "Self"
                };
                itemsToAdd.Add(knives);

                Item arrowheads = new Item(Metals[i].Name + " arrowheads", "I can make some arrows with these.", "arrowheads" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 15, true);
                itemsToAdd.Add(arrowheads);

                Item hatchet = new Item(Metals[i].Name + " hatchet", "Good for chopping trees.", "hatchet" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult, misc: "Hatchet") {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Slash", EquipElement = "Metal", CountsAsIDs = [ "axe" ]
                };
                itemsToAdd.Add(hatchet);

                Item pickaxe = new Item(Metals[i].Name + " pickaxe", "Good for Mining.", "pickaxe" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult, misc: "Pickaxe") {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Stab", EquipElement = "Metal", AttackSpeed = 1.5
                };
                itemsToAdd.Add(pickaxe);

                Item dagger = new Item(Metals[i].Name + " dagger", "Good for stabbing.", "dagger" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Stab", EquipElement = "Metal"
                };
                itemsToAdd.Add(dagger);

                Item sword = new Item(Metals[i].Name + " sword", "Good for slashing.", "sword" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Slash", EquipElement = "Metal"
                };
                itemsToAdd.Add(sword);

                Item mace = new Item(Metals[i].Name + " mace", "Good for crushing.", "mace" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Crush", EquipElement = "Metal"
                };
                itemsToAdd.Add(mace); 

                Item scimitar = new Item(Metals[i].Name + " scimitar", "Good for slashing quickly.", "scimitar" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 2) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Slash", EquipElement = "Metal", AttackSpeed = 0.75
                };
                itemsToAdd.Add(scimitar);

                Item spear = new Item(Metals[i].Name + " spear", "Good for stabbing quickly.", "spear" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 2) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Stab", EquipElement = "Metal", AttackSpeed = 0.75, TwoHanded = true
                };
                itemsToAdd.Add(spear);

                Item battleaxe = new Item(Metals[i].Name + " battleaxe", "Powerful slashes but slow.", "battleaxe" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 4) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier + 1, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Slash", EquipElement = "Metal", AttackSpeed = 1.5, TwoHanded = true
                };
                itemsToAdd.Add(battleaxe);
                 
                Item sword2h = new Item(Metals[i].Name + " 2h sword", "Powerful stabs but slow.", "sword2h" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 4) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier + 1, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Stab", EquipElement = "Metal", AttackSpeed = 1.5, TwoHanded = true
                };
                itemsToAdd.Add(sword2h);

                Item warhammer = new Item(Metals[i].Name + " warhammer", "Powerful crushing but slow.", "warhammer" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 4) {
                    EquipSlot = "Weapon",  EquipTier = Metals[i].Tier + 1, EquipSkill = "Attack", EquipLevel = Metals[i].Level, EquipDamageType = "Crush", EquipElement = "Metal", AttackSpeed = 1.5, TwoHanded = true
                };
                itemsToAdd.Add(warhammer);

                Item defender = new Item(Metals[i].Name + " defender", "A defensive weapon.", "defender" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult, trade: false) {
                    EquipSlot = "Offhand",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "Defender"
                };
                itemsToAdd.Add(defender);

                Item sqshield = new Item(Metals[i].Name + " square shield", "A medium square shield.", "sqShield" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 2) {
                    EquipSlot = "Offhand",  EquipTier = Metals[i].Tier, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(sqshield);

                Item kiteshield = new Item(Metals[i].Name + " kiteshield", "A large metal shield.", "kiteshield" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult * 3) {
                    EquipSlot = "Offhand",  EquipTier = Metals[i].Tier + 1, EquipSkill = "Defense", EquipLevel = Metals[i].Level, MiscString = "DefenseMelee"
                };
                itemsToAdd.Add(kiteshield);

                
                if (Metals[i].Name != "Tutorial") {
                    itemsToAdd.Add(new Item(Metals[i].Name + " crossbow limbs", "Can be combined with a" + (Helper.VowelStart(Materials.WoodNames[(int) Metals[i].Tier - 1].ToLower()) ? "n " : " ") + Materials.WoodNames[(int) Metals[i].Tier - 1].ToLower() + " stock to make an unstrung crossbow.", "limbs" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult));

                    itemsToAdd.Add(new Item(Metals[i].Name + " fish hook", "A" + (Helper.VowelStart(Metals[i].Name.ToLower()) ? "n " : " ") + Metals[i].Name.ToLower() + " fish hook, needs to be attached to a " + Materials.WoodNames[(int) Metals[i].Tier - 1].ToLower() + " pole.", "hook" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult, true));

                    itemsToAdd.Add(new Item(Metals[i].Name + " nails", "Nails made of " + Metals[i].Name.ToLower() + ".", "nails" + Metals[i].Name, Metals[i].R, Metals[i].G, Metals[i].B, fullMult / 15, true));
                } 
            }


            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
