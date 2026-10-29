using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedUseRecipes {
        public static void InitUseRecipes(Dictionary<TwoWayString, Recipe> RecipeLib) {
            List<Recipe> toAdd = new();

            toAdd.Add(new("tinderbox", "logPoplar", "_fire", 0, 1, 1, miscStr: "ashesPoplar")); 
            toAdd.Add(new("tinderbox", "logElm", "_fire", 0, 1, 1,  miscStr: "ashesElm")); 
            toAdd.Add(new("tinderbox", "logWalnut", "_fire", 0, 1, 1, miscStr: "ashesWalnut")); 
            toAdd.Add(new("tinderbox", "logHolly", "_fire", 0, 1, 1, miscStr: "ashesHolly")); 
            toAdd.Add(new("tinderbox", "logAcacia", "_fire", 0, 1, 1, miscStr: "ashesAcacia")); 
            toAdd.Add(new("tinderbox", "logBirch", "_fire", 0, 1, 1, miscStr: "ashesBirch")); 
            toAdd.Add(new("tinderbox", "logHickory", "_fire", 0, 1, 1, miscStr: "ashesHickory")); 
            toAdd.Add(new("tinderbox", "logBloodwood", "_fire", 0, 1, 1, miscStr: "ashesBloodwood")); 
            toAdd.Add(new("tinderbox", "logCamatillo", "_fire", 0, 1, 1, miscStr: "ashesCamatillo")); 
            toAdd.Add(new("tinderbox", "logKatalox", "_fire", 0, 1, 1, miscStr: "ashesKatalox"));

            // Smithing, ore mixes
            toAdd.Add(new("oreCopper", "oreTin", "oreMixBronze", 1, 1, 1, "Smithing", 1, 2)); 
            toAdd.Add(new("oreIron", "oreCoal", "oreMixSteel", 1, 1, 1, "Smithing", 60, 8));

            // Fletching
            foreach (var wood in Materials.Woods) { 
                toAdd.Add(new("bowstring", "shortbow" + wood.Name + "U", "shortbow" + wood.Name, 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 15));
                toAdd.Add(new("bowstring", "longbow" + wood.Name + "U", "longbow" + wood.Name, 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 15));

                toAdd.Add(new("stock" + wood.Name, "limbs" + wood.OtherMaterial, "crossbow" + wood.Name + "U", 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 10));
                toAdd.Add(new("crossbowString", "crossbow" + wood.Name + "U", "crossbow" + wood.Name, 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 20)); 

                toAdd.Add(new("headlessShaft", "arrowheads" + wood.OtherMaterial, "arrows" + wood.OtherMaterial, 15, 15, 15, "Fletching", wood.Level, (int) wood.Tier * 20)); 
                toAdd.Add(new("boltsUnf" + wood.OtherMaterial, "feather", "bolts" + wood.OtherMaterial, 10, 10, 10, "Fletching", wood.Level, (int) wood.Tier * 10)); 
                 
                toAdd.Add(new("rod" + wood.Name + "U", "bowstring", "rod" + wood.Name + "S", 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 15)); 
                toAdd.Add(new("rod" + wood.Name + "S", "hook" + wood.OtherMaterial, "rod" + wood.Name, 1, 1, 1, "Fletching", wood.Level, (int) wood.Tier * 5)); 
            }

            toAdd.Add(new("arrowshaft", "feather", "headlessShaft", 15, 15, 15, "Fletching", 1, 15)); 



            // Cooking 
            toAdd.Add(new("potFlour", "bucketWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "bucketEmpty"]));
            toAdd.Add(new("potFlour", "jugWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "jugEmpty"]));
            toAdd.Add(new("potFlour", "bowlWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "bowlEmpty"]));
            
            toAdd.Add(new("pieEmpty", "doughPastry", "pieShell", 1, 1, 1, "Cooking", 1, 0)); 
            
            toAdd.Add(new("tinCakeEmpty", "eggChicken", "tinCakeEgg", 1, 1, 1, "Cooking", 40, 0)); 
            toAdd.Add(new("tinCakeEgg", "potFlour", "tinCakeFlour", 1, 1, 1, "Cooking", 40, 0, returns: ["potEmpty"])); 
            toAdd.Add(new("tinCakeFlour", "bucketMilk", "tinCakeBatter", 1, 1, 1, "Cooking", 40, 0, returns: ["bucketEmpty"])); 
            
            toAdd.Add(new("teapotClayEmpty", "teaLeaves", "teapotClayLeaves", 1, 1, 1, "Cooking", 20, 0 )); 
            toAdd.Add(new("teapotPorcelainEmpty", "teaLeaves", "teapotPorcelainLeaves", 1, 1, 1, "Cooking", 20, 0 )); 
            toAdd.Add(new("teapotAntiqueEmpty", "teaLeaves", "teapotAntiqueLeaves", 1, 1, 1, "Cooking", 20, 0 ));
            toAdd.Add(new("teapotClayLeaves", "kettleHot", "teapotClayTea", 1, 1, 1, "Cooking", 20, 52, returns: ["kettleEmpty"] )); 
            toAdd.Add(new("teapotPorcelainLeaves", "kettleHot", "teapotPorcelainTea", 1, 1, 1, "Cooking", 20, 52, returns: ["kettleEmpty"] )); 
            toAdd.Add(new("teapotAntiqueLeaves", "kettleHot", "teapotAntiqueTea", 1, 1, 1, "Cooking", 20, 52, returns: ["kettleEmpty"] )); 
            
            toAdd.Add(new("cupClayTea", "bucketMilk", "cupClayTeaMilk", returns: ["bucketEmpty"] )); 
            toAdd.Add(new("cupPorcelainTea", "bucketMilk", "cupPorcelainTeaMilk", returns: ["bucketEmpty"] )); 
            toAdd.Add(new("cupAntiqueTea", "bucketMilk", "cupAntiqueTeaMilk", returns: ["bucketEmpty"] )); 
               
             
            // Farming 
            toAdd.Add(new("plantPot", "seedTreePoplar", "plantPotPoplar", 1, 1, 1, "Farming", 1, 10)); 
            toAdd.Add(new("plantPot", "seedTreeElm", "plantPotElm", 1, 1, 1, "Farming", 10, 20)); 
            toAdd.Add(new("plantPot", "seedTreeWalnut", "plantPotWalnut", 1, 1, 1, "Farming", 20, 30)); 
            toAdd.Add(new("plantPot", "seedTreeHolly", "plantPotHolly", 1, 1, 1, "Farming", 30, 40)); 
            toAdd.Add(new("plantPot", "seedTreeAcacia", "plantPotAcacia", 1, 1, 1, "Farming", 40, 50)); 
            toAdd.Add(new("plantPot", "seedTreeBirch", "plantPotBirch", 1, 1, 1, "Farming", 50, 60)); 
            toAdd.Add(new("plantPot", "seedTreeHickory", "plantPotHickory", 1, 1, 1, "Farming", 60, 70)); 
            toAdd.Add(new("plantPot", "seedTreeBloodwood", "plantPotBloodwood", 1, 1, 1, "Farming", 70, 80)); 
            toAdd.Add(new("plantPot", "seedTreeCamatillo", "plantPotCamatillo", 1, 1, 1, "Farming", 80, 90)); 
            toAdd.Add(new("plantPot", "seedTreeKatalox", "plantPotKatalox", 1, 1, 1, "Farming", 90, 100)); 

            // Crafting 
            foreach (var mat in Materials.Jewels) { 
                toAdd.Add(new("amulet" + mat.Name + "U", "woolBall", "amulet" + mat.Name, 1, 1, 1, "Crafting", mat.Level, 5)); 
                toAdd.Add(new("amulet" + mat.OtherMaterial + "U", "woolBall", "amulet" + mat.OtherMaterial, 1, 1, 1, "Crafting", mat.Level, 5));  
                toAdd.Add(new("uncut" + mat.Name, "chisel", "cut" + mat.Name, 1, 0, 1, "Crafting", mat.Level, mat.ExpMultiplier));  
            }
             
            toAdd.Add(new("unstrungSymbol", "woolBall", "unblessedSymbol", 1, 1, 1, "Crafting", 16, 4)); 

            toAdd.Add(new("bodyHardleather", "studsIron", "bodyStudded", 1, 1, 1, "Crafting", 20, 40)); 
            toAdd.Add(new("coifHardleather", "studsIron", "coifStudded", 1, 1, 1, "Crafting", 20, 40)); 
            toAdd.Add(new("chapsHardleather", "studsIron", "chapsStudded", 1, 1, 1, "Crafting", 20, 40)); 
            toAdd.Add(new("vambracesHardleather", "studsIron", "vambracesStudded", 1, 1, 1, "Crafting", 20, 40)); 
            toAdd.Add(new("bootsHardleather", "studsIron", "bootsStudded", 1, 1, 1, "Crafting", 20, 40)); 

            foreach (var wood in Materials.Woods) { 
                toAdd.Add(new("wand" + wood.Name + "Unf", "cut" + Materials.JewelNames[(int) wood.Tier - 1], "wand" + wood.Name, s: "Crafting", lv: wood.Level, exp: (int) (20 * wood.Tier))); 
                toAdd.Add(new("potWater", "ashes" + wood.Name, "potLye"));
                toAdd.Add(new("pestleMortar", "log" + wood.Name, "pulp" + wood.Name, fQ: 0, s: "Crafting", lv: wood.Level, exp: (int) (5 * wood.Tier))); 
                toAdd.Add(new("potLye", "chips" + wood.Name, "potChips" + wood.Name, s: "Crafting", lv: wood.Level, exp: (int) (10 * wood.Tier))); 
                toAdd.Add(new("mouldPaper", "pulp" + wood.Name, "paper" + wood.Name, fQ: 0, oQ: 2, s: "Crafting", lv: wood.Level, exp: (int) (5 * wood.Tier))); 
            }

            
            toAdd.Add(new("candle", "candleLanternEmpty", "candleLantern"));
            toAdd.Add(new("candleLit", "candleLanternEmpty", "candleLanternLit")); 
            toAdd.Add(new("oilLamp", "oilLanternFrame", "oilLantern", s: "Crafting", lv: 26, exp: 50));
            toAdd.Add(new("oilLampLit", "oilLanternFrame", "oilLanternLit", s: "Crafting", lv: 26, exp: 50)); 
             
            toAdd.Add(new("knife", "fruitBanana", "fruitBananaSlices", 0));  
            toAdd.Add(new("knife", "fruitOrange", "fruitOrangeSlices", 0)); 
            toAdd.Add(new("knife", "fruitOrangeSlices", "fruitOrangeChunks", 0)); 
            toAdd.Add(new("knife", "fruitPineapple", "fruitPineappleRing", 0, oQ: 4)); 
            toAdd.Add(new("knife", "fruitPineappleRing", "fruitPineappleChunks", 0)); 
            toAdd.Add(new("hammer", "fruitCoconut", "fruitCoconutHalf", 0)); 
            toAdd.Add(new("vialEmpty", "fruitCoconutHalf", "fruitCoconutMilk", returns: ["fruitCoconutShell"]));    
              
            toAdd.Add(new("vialWater", "nightshade", "potionSleepingUnf"));

            // Alchemy 
            toAdd.Add(new("pestleMortar", "bonesRegular", "bonesRegularGround", s: "Alchemy", lv: 1, exp: 5));
            toAdd.Add(new("pestleMortar", "unicornHorn", "unicornHornGround", s: "Alchemy", lv: 1, exp: 5));
              

            for (int i = 0; i < toAdd.Count; i++) {
                TwoWayString ID = new(toAdd[i].FirstItem, toAdd[i].SecondItem);
                RecipeLib.Add(ID, toAdd[i]);
            }
        }
    }
}
