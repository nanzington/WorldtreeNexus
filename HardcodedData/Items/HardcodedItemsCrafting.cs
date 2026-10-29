using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsCrafting {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Wool", "Nice and fluffy.", "woolRaw", 255, 255, 255, 5));
            itemsToAdd.Add(new Item("Silk", "It's a sheet of silk.", "clothSilk", Color.AntiqueWhite, 30)); 
            itemsToAdd.Add(new Item("Ball of wool", "Spun from wool.", "woolBall", 255, 255, 255, 10)); 
            itemsToAdd.Add(new Item("Bolt of cloth", "A bolt of ordinary cloth.", "clothBolt", 255, 255, 255, 50)); 
            itemsToAdd.Add(new Item("Chisel", "Good for detailed crafting.", "chisel", Color.SaddleBrown, 15));
             
            itemsToAdd.Add(new Item("Amulet mould", "Used to make amulets.", "mouldAmulet", Color.White, 5));
            itemsToAdd.Add(new Item("Bracelet mould", "Used to make bracelets and anklets.", "mouldBracelet", Color.White, 5)); 
            itemsToAdd.Add(new Item("Holy mould", "Used to make holy symbols of Saradomin.", "mouldHoly", Color.White, 5)); 
            itemsToAdd.Add(new Item("Necklace mould", "Used to make necklaces.", "mouldNecklace", Color.White, 5));
            itemsToAdd.Add(new Item("Ring mould", "Used to make rings.", "mouldRing", Color.White, 5));

            // Jewellery Factory
            foreach (var mat in Materials.Jewels) {
                itemsToAdd.Add(new Item("Uncut " + mat.Name.ToLower(), "An uncut " + mat.Name.ToLower() + ". Used in Crafting (" + mat.Level + ").", "uncut" + mat.Name, mat.R, mat.G, mat.B, (int) (mat.CostMultiplier * 0.9)));
                itemsToAdd.Add(new Item(mat.Name, "This looks valuable.", "cut" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier));
                
                itemsToAdd.Add(new Item(mat.Name + " ring", "A ring made from " + mat.Name.ToLower() + ".", "ring" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Ring" });
                itemsToAdd.Add(new Item(mat.Name + " amulet", "An amulet made from " + mat.Name.ToLower() + ".", "amulet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " amulet (u)", "An unstrung amulet made from " + mat.Name.ToLower() + ". Can be strung with a ball of wool.", "amulet" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " necklace", "A necklace made from " + mat.Name.ToLower() + ".", "necklace" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " bracelet", "A bracelet made from " + mat.Name.ToLower() + ".", "bracelet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Hands" });
            }

            foreach (var mat in Materials.Metals) {
                itemsToAdd.Add(new Item(mat.Name + " ring", "A ring made from " + mat.Name.ToLower() + ".", "ring" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Ring" });
                itemsToAdd.Add(new Item(mat.Name + " amulet", "An amulet made from " + mat.Name.ToLower() + ".", "amulet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " amulet (u)", "An unstrung amulet made from " + mat.Name.ToLower() + ". Can be strung with a ball of wool.", "amulet" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " necklace", "A necklace made from " + mat.Name.ToLower() + ".", "necklace" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " bracelet", "A bracelet made from " + mat.Name.ToLower() + ".", "bracelet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Hands" });
            }
                
            itemsToAdd.Add(new Item("Unstrung symbol", "It needs a string so I can wear it.", "unstrungSymbol", Color.Gray, 200));
            itemsToAdd.Add(new Item("Unblessed symbol", "A symbol of Saradomin.", "unblessedSymbol", Color.Gray, 200) { EquipSlot = "Amulet" });
            itemsToAdd.Add(new Item("Holy symbol", "A blessed holy symbol of Saradomin.", "holySymbol", Color.DarkGray, 300) { EquipSlot = "Amulet" }); 
            
            itemsToAdd.Add(new Item("Clay dust", "Some hard dry clay.", "clayDust", 207, 185, 151, 1));
            itemsToAdd.Add(new Item("Soft clay", "Clay soft enough to mould.", "claySoft", 205, 127, 50, 2));
            itemsToAdd.Add(new Item("Unfired pot", "I need to put this in a pottery kiln.", "unfiredPot", 205, 127, 50, 1));
            itemsToAdd.Add(new Item("Unfired cup", "I need to put this in a pottery kiln.", "unfiredCup", 205, 127, 50, 2));
            itemsToAdd.Add(new Item("Unfired pie dish", "I need to put this in a pottery kiln.", "unfiredPieDish", 205, 127, 50, 3));
            itemsToAdd.Add(new Item("Unfired bowl", "I need to put this in a pottery kiln.", "unfiredBowl", 205, 127, 50, 2));
            itemsToAdd.Add(new Item("Unfired plant pot", "I need to put this in a pottery kiln.", "unfiredPlantPot", 205, 127, 50, 1));
            itemsToAdd.Add(new Item("Unfired pot lid", "I need to put this in a pottery kiln.", "unfiredPotLid", 205, 127, 50, 10));
            itemsToAdd.Add(new Item("Pot", "This pot is empty.", "potEmpty", 207, 185, 151, 1));
            itemsToAdd.Add(new Item("Empty cup", "An empty cup.", "cupEmpty", 255, 255, 255, 2));
            itemsToAdd.Add(new Item("Pie dish", "Deceptively pie shaped.", "pieEmpty", 207, 185, 151, 3));
            itemsToAdd.Add(new Item("Bowl", "Useful for mixing things.", "bowlEmpty", 207, 185, 151, 4));
            itemsToAdd.Add(new Item("Empty plant pot", "An empty plant pot.", "plantPotEmpty", 207, 185, 151, 1) { UseString = "FillPot" });
            itemsToAdd.Add(new Item("Pot lid", "This should fit on a normal-sized pot.", "potLid", 207, 185, 151, 15));
            itemsToAdd.Add(new Item("Airtight pot", "This is pretty well sealed.", "potAirtight", 207, 185, 151, 10));
                
            itemsToAdd.Add(new Item("Bucket of sand", "A bucket filled with sand. One of the ingredients for making glass.", "bucketSand", 111, 66, 33, 2));
            itemsToAdd.Add(new Item("Seaweed", "Slightly damp seaweed.", "seaweed", Color.SeaGreen, 2));
            itemsToAdd.Add(new Item("Swamp weed", "Swamp weed found in the caves near Dorgesh-Kaan.", "weedSwamp", Color.ForestGreen, 2));
            itemsToAdd.Add(new Item("Soda ash", "One of the ingredients for making glass.", "ashSoda", Color.White, 2));
            itemsToAdd.Add(new Item("Molten glass", "Hot glass ready to be blown into useful objects.", "glassMolten", Color.Orange, 2));
            itemsToAdd.Add(new Item("Lantern lens", "A roughly circular disc of glass.", "glassLens", ColorLib.Steel, 70)); 
            itemsToAdd.Add(new Item("Empty candle lantern", "A candle in a glass cage.", "candleLanternEmpty", ColorLib.Steel, 15));
            itemsToAdd.Add(new Item("Fishbowl", "An empty fishbowl.", "fishbowlEmpty", Color.White, 1));
            itemsToAdd.Add(new Item("Unpowered orb", "Could be imbued with elemental energy.", "orbUnpowered", ColorLib.Steel, 100));
             
            itemsToAdd.Add(new Item("Grain", "Some wheat hands.", "grain", 207, 185, 151, 2));
            

            // Ranged Armor Factory  
            itemsToAdd.Add(new Item("Cowhide", "This should be tanned before I can use it.", "cowhide", 255, 255, 255, 10));
            itemsToAdd.Add(new Item("Soft leather", "Suitable for craftworks now.", "leatherSoft", 165, 42, 42, 10));
            itemsToAdd.Add(new Item("Hard leather", "Might offer some real protection if made into armor.", "leatherHard", 139, 69, 19, 20)); 

            List<MaterialDef> Leathers = new(Materials.Leathers) { Materials.Studded };
            foreach (var leather in Leathers) {
                int fullMult = leather.CostMultiplier;

                Item coif = new Item(leather.Name + " coif", "Provides " + leather.Descriptor + " ranged protection for the head.", "coif" + leather.Name, leather.R, leather.G, leather.B, fullMult * 2) {
                    EquipSlot = "Head",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(coif);

                Item body = new Item(leather.Name + " body", "Provides " + leather.Descriptor + " ranged protection for the torso.", "body" + leather.Name, leather.R, leather.G, leather.B, fullMult * 5) {
                    EquipSlot = "Body",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(body);

                Item chaps = new Item(leather.Name + " chaps", "Provides " + leather.Descriptor + " ranged protection for the legs.", "chaps" + leather.Name, leather.R, leather.G, leather.B, fullMult * 3) {
                    EquipSlot = "Legs",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(chaps);

                Item boots = new Item(leather.Name + " boots", "Provides " + leather.Descriptor + " ranged protection for the feet.", "boots" + leather.Name, leather.R, leather.G, leather.B, fullMult) {
                    EquipSlot = "Feet",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(boots);

                Item vambraces = new Item(leather.Name + " vambraces", "Provides " + leather.Descriptor + " ranged protection for the hands.", "vambraces" + leather.Name, leather.R, leather.G, leather.B, fullMult) {
                    EquipSlot = "Hands",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(vambraces);

                Item shield = new Item(leather.Name + " shield", "A shield for rangers, made of " + leather.Name + ".", "shield" + leather.Name, leather.R, leather.G, leather.B, fullMult) {
                    EquipSlot = "Offhand",  EquipTier = leather.Tier, EquipSkill = "Defense", EquipLevel = leather.Level, MiscString = "DefenseRange"
                };
                itemsToAdd.Add(shield); 
            }

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
