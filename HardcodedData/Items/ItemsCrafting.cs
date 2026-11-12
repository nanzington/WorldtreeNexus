using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsCrafting {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Wool", "Nice and fluffy.", "woolRaw", 255, 255, 255, 5));
            itemsToAdd.Add(new Item("Silk", "It's a sheet of silk.", "clothSilk", Color.AntiqueWhite, 30)); 
            itemsToAdd.Add(new Item("Ball of wool", "Spun from wool.", "woolBall", 255, 255, 255, 10)); 
            itemsToAdd.Add(new Item("Bolt of cloth", "A bolt of ordinary cloth.", "clothBolt", 255, 255, 255, 50)); 
            itemsToAdd.Add(new Item("Chisel", "Good for detailed crafting.", "chisel", Color.SaddleBrown, 15));
             
            itemsToAdd.Add(new Item("Amulet mould", "Used to make amulets.", "mouldAmulet", Color.White, 5));
            itemsToAdd.Add(new Item("Bracelet mould", "Used to make bracelets and anklets.", "mouldBracelet", Color.White, 5)); 
            itemsToAdd.Add(new Item("Brooch mould", "Used to make brooches.", "mouldBrooch", Color.White, 5));
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
                itemsToAdd.Add(new Item(mat.Name + " brooch", "A brooch made from " + mat.Name.ToLower() + ".", "brooch" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Pocket" });
            }

            foreach (var mat in Materials.Metals) {
                itemsToAdd.Add(new Item(mat.Name + " ring", "A ring made from " + mat.Name.ToLower() + ".", "ring" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Ring" });
                itemsToAdd.Add(new Item(mat.Name + " amulet", "An amulet made from " + mat.Name.ToLower() + ".", "amulet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " amulet (u)", "An unstrung amulet made from " + mat.Name.ToLower() + ". Can be strung with a ball of wool.", "amulet" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " necklace", "A necklace made from " + mat.Name.ToLower() + ".", "necklace" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item(mat.Name + " bracelet", "A bracelet made from " + mat.Name.ToLower() + ".", "bracelet" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item(mat.Name + " brooch", "A brooch made from " + mat.Name.ToLower() + ".", "brooch" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier) { EquipSlot = "Pocket" });
            }

            // Enchanted Jewellery
            // Price: jewel + metal, +10% rounded up
            // Function: maybe rotate slots? Teleport, skilling efficiency, combat efficiency, general utility, specific skill booster
            { 
                // Quartz: 1/1, (combat eff2, general utility, teleport, skilling eff, combat eff)
                itemsToAdd.Add(new Item("Ring of reprisal", "When you take damage from an enemy, deal one point of damage to them.", "ringQuartzE", Color.DarkGray, 72) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Quartz amulet (e)", "An enchanted quartz amulet.", "amuletQuartzE", Color.DarkGray, 72) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Quartz necklace (e)", "An enchanted quartz necklace.", "necklaceQuartzE", Color.DarkGray, 72) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Quartz bracelet (e)", "An enchanted quartz bracelet.", "braceletQuartzE", Color.DarkGray, 72) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Quartz brooch (e)", "An enchanted quartz brooch.", "broochQuartzE", Color.DarkGray, 72) { EquipSlot = "Pocket" });

                // Garnet: 2/10 (combat eff, combat eff2, general utility, teleport, skilling eff)
                itemsToAdd.Add(new Item("Garnet ring (e)", "An enchanted garnet ring.", "ringGarnetE", Color.Orange, 160) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Garnet amulet (e)", "An enchanted garnet amulet.", "amuletGarnetE", Color.Orange, 160) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Garnet necklace (e)", "An enchanted garnet necklace.", "necklaceGarnetE", Color.Orange, 160) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Garnet bracelet (e)", "An enchanted garnet bracelet.", "braceletGarnetE", Color.Orange, 160) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Garnet brooch (e)", "An enchanted garnet brooch.", "broochGarnetE", Color.Orange, 160) { EquipSlot = "Pocket" });

                // Emerald: 3/20 (Skilling eff, combat eff, combat eff2, general utility, teleport)
                itemsToAdd.Add(new Item("Emerald ring (e)", "An enchanted emerald ring.", "ringEmeraldE", Color.Lime, 429) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Emerald amulet (e)", "An enchanted emerald amulet.", "amuletEmeraldE", Color.Lime, 429) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Emerald necklace (e)", "An enchanted emerald necklace.", "necklaceEmeraldE", Color.Lime, 429) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Emerald bracelet (e)", "An enchanted emerald bracelet.", "braceletEmeraldE", Color.Lime, 429) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Emerald brooch (e)", "An enchanted emerald brooch.", "broochEmeraldE", Color.Lime, 429) { EquipSlot = "Pocket" });

                // Sapphire: 4/30 (Teleport, skilling eff, combat eff, combat eff2, general utility)
                itemsToAdd.Add(new Item("Sapphire ring (e)", "An enchanted sapphire ring.", "ringSapphireE", Color.DodgerBlue, 748) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Sapphire amulet (e)", "An enchanted sapphire amulet.", "amuletSapphireE", Color.DodgerBlue, 748) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Sapphire necklace (e)", "An enchanted sapphire necklace.", "necklaceSapphireE", Color.DodgerBlue, 748) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Sapphire bracelet (e)", "An enchanted sapphire bracelet.", "braceletSapphireE", Color.DodgerBlue, 748) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Brooch of wealth", "Rolls drops one extra time while worn.", "broochSapphireE", Color.DodgerBlue, 748) { EquipSlot = "Pocket" });

                // Ruby: 5/40 (general utility, teleport, skilling eff, combat eff, combat eff2)
                itemsToAdd.Add(new Item("Ruby ring (e)", "An enchanted ruby ring.", "ringRubyE", Color.Crimson, 1496) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Ruby amulet (e)", "An enchanted ruby amulet.", "amuletRubyE", Color.Crimson, 1496) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Ruby necklace (e)", "An enchanted ruby necklace.", "necklaceRubyE", Color.Crimson, 1496) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Ruby bracelet (e)", "An enchanted ruby bracelet.", "braceletRubyE", Color.Crimson, 1496) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Ruby brooch (e)", "An enchanted ruby brooch.", "broochRubyE", Color.Crimson, 1496) { EquipSlot = "Pocket" });

                // Amethyst: 6/50 (combat eff2, general utility, teleport, skilling eff, combat eff)
                itemsToAdd.Add(new Item("Amethyst ring (e)", "An enchanted amethyst ring.", "ringAmethystE", Color.MediumPurple, 4092) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Amethyst amulet (e)", "An enchanted amethyst amulet.", "amuletAmethystE", Color.MediumPurple, 4092) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Amethyst necklace (e)", "An enchanted amethyst necklace.", "necklaceAmethystE", Color.MediumPurple, 4092) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Amethyst bracelet (e)", "An enchanted amethyst bracelet.", "braceletAmethystE", Color.MediumPurple, 4092) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Amethyst brooch (e)", "An enchanted amethyst brooch.", "broochAmethystE", Color.MediumPurple, 4092) { EquipSlot = "Pocket" });

                // Morganite: 7/60 (combat eff, combat eff2, general utility, teleport, skilling eff)
                itemsToAdd.Add(new Item("Morganite ring (e)", "An enchanted morganite ring.", "ringMorganiteE", Color.HotPink, 7150) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Morganite amulet (e)", "An enchanted morganite amulet.", "amuletMorganiteE", Color.HotPink, 7150) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Morganite necklace (e)", "An enchanted morganite necklace.", "necklaceMorganiteE", Color.HotPink, 7150) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Morganite bracelet (e)", "An enchanted morganite bracelet.", "braceletMorganiteE", Color.HotPink, 7150) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Morganite brooch (e)", "An enchanted morganite brooch.", "broochMorganiteE", Color.HotPink, 7150) { EquipSlot = "Pocket" });

                // Heliodor: 8/70 (skilling eff, combat eff, combat eff2, general utility, teleport)
                itemsToAdd.Add(new Item("Heliodor ring (e)", "An enchanted heliodor ring.", "ringHeliodorE", Color.Yellow, 14300) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Heliodor amulet (e)", "An enchanted heliodor amulet.", "amuletHeliodorE", Color.Yellow, 14300) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Heliodor necklace (e)", "An enchanted heliodor necklace.", "necklaceHeliodorE", Color.Yellow, 14300) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Heliodor bracelet (e)", "An enchanted heliodor bracelet.", "braceletHeliodorE", Color.Yellow, 14300) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Heliodor brooch (e)", "An enchanted heliodor brooch.", "broochHeliodorE", Color.Yellow, 14300) { EquipSlot = "Pocket" });

                // Diamond: 9/80 (Teleport, skilling eff, combat eff, combat eff2, general utility)
                itemsToAdd.Add(new Item("Diamond ring (e)", "An enchanted diamond ring.", "ringDiamondE", Color.White, 39600) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Diamond amulet (e)", "An enchanted diamond amulet.", "amuletDiamondE", Color.White, 39600) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Diamond necklace (e)", "An enchanted diamond necklace.", "necklaceDiamondE", Color.White, 39600) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Diamond bracelet (e)", "An enchanted diamond bracelet.", "braceletDiamondE", Color.White, 39600) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Brooch of fortune", "Rolls drops two extra times while worn.", "broochDiamondE", Color.White, 39600) { EquipSlot = "Pocket" });

                // Obsidian: 10/90 (general utility, teleport, skilling eff, combat eff, combat eff2)
                itemsToAdd.Add(new Item("Obsidian ring (e)", "An enchanted obsidian ring.", "ringObsidianE", Color.DimGray, 68200) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Obsidian amulet (e)", "An enchanted obsidian amulet.", "amuletObsidianE", Color.DimGray, 68200) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Obsidian necklace (e)", "An enchanted obsidian necklace.", "necklaceObsidianE", Color.DimGray, 68200) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Obsidian bracelet (e)", "An enchanted obsidian bracelet.", "braceletObsidianE", Color.DimGray, 68200) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Obsidian brooch (e)", "An enchanted obsidian brooch.", "broochObsidianE", Color.DimGray, 68200) { EquipSlot = "Pocket" });

                // Spacetime: 11/100 (combat eff2, general utility, teleport, skilling eff, combat eff)
                itemsToAdd.Add(new Item("Spacetime ring (e)", "An enchanted spacetime ring.", "ringSpacetimeE", Color.Purple, 136400) { EquipSlot = "Ring" }); 
                itemsToAdd.Add(new Item("Spacetime amulet (e)", "An enchanted spacetime amulet.", "amuletSpacetimeE", Color.Purple, 136400) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Spacetime necklace (e)", "An enchanted spacetime necklace.", "necklaceSpacetimeE", Color.Purple, 136400) { EquipSlot = "Amulet" });
                itemsToAdd.Add(new Item("Spacetime bracelet (e)", "An enchanted spacetime bracelet.", "braceletSpacetimeE", Color.Purple, 136400) { EquipSlot = "Hands" });
                itemsToAdd.Add(new Item("Spacetime brooch (e)", "An enchanted spacetime brooch.", "broochSpacetimeE", Color.Purple, 136400) { EquipSlot = "Pocket" });


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
            itemsToAdd.Add(new Item("Minotaur hide", "Needs to be tanned before use.", "hideMinotaur", Color.BurlyWood, 30));
            itemsToAdd.Add(new Item("Hard leather", "Tanned minotaur hide. Used in Crafting. (10)", "leatherHard", 139, 69, 19, 20)); 

            List<MaterialDef> Leathers = Materials.Leathers;
            foreach (var leather in Leathers) {
                int fullMult = leather.CostMultiplier;

                Item coif = new Item(leather.Name + " coif", "Provides " + leather.Descriptor + " ranged protection for the head.", "coif" + leather.Name, leather.R, leather.G, leather.B, fullMult) {
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

            foreach (var cloth in Materials.Cloths) { 
                itemsToAdd.Add(new Item("Bolt of " + cloth.Name.ToLower(), "A bolt of cloth, used in Crafting. (" + cloth.Level + ")", "bolt" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier));

                itemsToAdd.Add(new Item(cloth.Name + " hood", "Provides " + cloth.Descriptor + " magic protection for the head.", "hood" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier) {
                    EquipSlot = "Head",  EquipTier = cloth.Tier, EquipSkill = "Defense", EquipLevel = cloth.Level, MiscString = "DefenseMagic"
                });

                itemsToAdd.Add(new Item(cloth.Name + " robe top", "Provides " + cloth.Descriptor + " magic protection for the torso.", "robeTop" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier * 5) {
                    EquipSlot = "Body",  EquipTier = cloth.Tier, EquipSkill = "Defense", EquipLevel = cloth.Level, MiscString = "DefenseMagic"
                });

                itemsToAdd.Add(new Item(cloth.Name + " robe bottom", "Provides " + cloth.Descriptor + " magic protection for the legs.", "robeBottom" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier * 3) {
                    EquipSlot = "Legs",  EquipTier = cloth.Tier, EquipSkill = "Defense", EquipLevel = cloth.Level, MiscString = "DefenseMagic"
                });

                itemsToAdd.Add(new Item(cloth.Name + " footwraps", "Provides " + cloth.Descriptor + " magic protection for the feet.", "footwraps" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier) {
                    EquipSlot = "Feet",  EquipTier = cloth.Tier, EquipSkill = "Defense", EquipLevel = cloth.Level, MiscString = "DefenseMagic"
                });

                itemsToAdd.Add(new Item(cloth.Name + " gloves", "Provides " + cloth.Descriptor + " magic protection for the hands.", "gloves" + cloth.Name, cloth.R, cloth.G, cloth.B, cloth.CostMultiplier) {
                    EquipSlot = "Hands",  EquipTier = cloth.Tier, EquipSkill = "Defense", EquipLevel = cloth.Level, MiscString = "DefenseMagic"
                });
            }

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
