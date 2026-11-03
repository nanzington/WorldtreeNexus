using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedCraftRecipes {
        public static void InitCrafts(Dictionary<string, List<CraftRecipe>> CraftLib, Dictionary<string, Spell> SpellLib) {
            List<CraftRecipe> toAdd = new(); 

            foreach (var metal in Materials.Metals) {
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "dagger" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "sword" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "mace" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 2, ["bar" + metal.Name + "," + 2], "scimitar" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 2, ["bar" + metal.Name + "," + 2], "spear" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 4, ["bar" + metal.Name + "," + 4], "sword2h" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 4, ["bar" + metal.Name + "," + 4], "warhammer" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 4, ["bar" + metal.Name + "," + 4], "battleaxe" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "hatchet" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "pickaxe" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 2, ["bar" + metal.Name + "," + 2], "helm" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 5, ["bar" + metal.Name + "," + 5], "platebody" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 5, ["bar" + metal.Name + "," + 5], "chainmail" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 3, ["bar" + metal.Name + "," + 3], "platelegs" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 3, ["bar" + metal.Name + "," + 3], "plateskirt" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "boots" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "gauntlets" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "arrowheads" + metal.Name, 15, "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "boltsUnf" + metal.Name, 15, "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "knives" + metal.Name, 5, "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 3, ["bar" + metal.Name + "," + 1], "limbs" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 2, ["bar" + metal.Name + "," + 2], "sqShield" + metal.Name, tool: "hammer"));
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier * 3, ["bar" + metal.Name + "," + 3], "kiteshield" + metal.Name, tool: "hammer")); 
                 
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "nails" + metal.Name, 15, tool: "hammer")); 
                toAdd.Add(new("Anvil", "Smithing", metal.Level, metal.ExpMultiplier, ["bar" + metal.Name + "," + 1], "hook" + metal.Name, tool: "hammer")); 
            }
            
            toAdd.Add(new("Anvil", "Smithing", 20, 75, ["barIron" + "," + 1], "studsIron", tool: "hammer"));
            toAdd.Add(new("Anvil", "Smithing", 26, 25, ["barIron" + "," + 1], "oilLanternFrame", tool: "hammer"));


            foreach (var leather in Materials.Leathers) {  
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier, [leather.SimpleName + "," + 1], "coif" + leather.Name, tool: "needle"));
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier * 5, [leather.SimpleName + "," + 5], "body" + leather.Name, tool: "needle"));
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier * 3, [leather.SimpleName + "," + 3], "chaps" + leather.Name, tool: "needle"));
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier, [leather.SimpleName + "," + 1], "vambraces" + leather.Name, tool: "needle"));
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier, [leather.SimpleName + "," + 1], "boots" + leather.Name, tool: "needle"));
                toAdd.Add(new("Needle", "Crafting", leather.Level, leather.ExpMultiplier * 2, [leather.SimpleName + "," + 2], "shield" + leather.Name, tool: "needle"));
            }

             
            foreach (var wood in Materials.Woods) { 
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 5), ["log" + wood.Name + "," + 1], "arrowshaft", 15, "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "chips" + wood.Name, tool: "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "shortbow" + wood.Name + "U", tool: "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "longbow" + wood.Name + "U", tool: "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "stock" + wood.Name, tool: "knife")); 
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "plank" + wood.Name, tool: "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "wand" + wood.Name + "Unf", tool: "knife"));
                toAdd.Add(new("Knife", "Fletching", wood.Level, (int) (wood.Tier * 15), ["log" + wood.Name + "," + 1], "rod" + wood.Name + "U", tool: "knife"));
            }


            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredPot"));
            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredCup", 4));
            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredPieDish"));
            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredBowl"));
            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredPlantPot"));
            toAdd.Add(new("Pottery Wheel", "Crafting", 1, 10, ["claySoft" + "," +  1], "unfiredPotLid")); 
            
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 1, 20, ["glassMolten,1"], "beerGlass"));
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 1, 20, ["glassMolten,1"], "vialEmpty"));
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 1, 20, ["glassMolten,1"], "candleLanternEmpty"));
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 10, 40, ["glassMolten,1"], "oilLampEmpty"));
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 10, 40, ["glassMolten,1"], "fishbowlEmpty"));
            toAdd.Add(new("Glassblowing Pipe", "Crafting", 20, 60, ["glassMolten,1"], "glassLens")); 


            // Jewellery
            foreach (var mat in Materials.Jewels) {
                List<string> mats = new();
                mats.Add("bar" + mat.OtherMaterial + ",1");
                mats.Add("cut" + mat.Name + ",1");

                
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier * 2, mats, "amulet" + mat.Name + "U", 1, "mouldAmulet")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier * 2, mats, "ring" + mat.Name, 1, "mouldRing")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier * 2, mats, "bracelet" + mat.Name, 1, "mouldBracelet")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier * 2, mats, "necklace" + mat.Name, 1, "mouldNecklace")); 
            }

            foreach (var mat in Materials.Metals) {
                List<string> mats = new();
                mats.Add("bar" + mat.Name + ",1");
                 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier / 10, mats, "amulet" + mat.Name + "U", 1, "mouldAmulet")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier / 10, mats, "ring" + mat.Name, 1, "mouldRing")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier / 10, mats, "bracelet" + mat.Name, 1, "mouldBracelet")); 
                toAdd.Add(new("Casting", "Crafting", mat.Level, mat.ExpMultiplier / 10, mats, "necklace" + mat.Name, 1, "mouldNecklace")); 
            }

            toAdd.Add(new("Casting", "Crafting", 23, 53, ["barSilver,1"], "unstrungSymbol", 1, "mouldHoly")); 

            
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughBread,1"], "doughPizza")); 
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughBread,1"], "doughPastry"));
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughPizza,1"], "doughBread")); 
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughPizza,1"], "doughPastry"));
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughPastry,1"], "doughBread")); 
            toAdd.Add(new("Baking", "Cooking", 1, 0, ["doughPastry,1"], "doughPizza")); 



            for (int i = 0; i < toAdd.Count; i++) {
                if (!CraftLib.ContainsKey(toAdd[i].Station))
                    CraftLib.Add(toAdd[i].Station, new());
                CraftLib[toAdd[i].Station].Add(toAdd[i]);
            }
        }
    }
}
