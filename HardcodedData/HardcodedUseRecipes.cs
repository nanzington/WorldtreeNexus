using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedUseRecipes {
        public static void InitUseRecipes(Dictionary<TwoWayString, Recipe> RecipeLib) {
            List<Recipe> toAdd = new();

            // Smithing, ore mixes
            toAdd.Add(new("oreCopper", "oreTin", "oreMixBronze", 1, 1, 1, "Smithing", 1, 2)); 
            toAdd.Add(new("oreIron", "oreCoal", "oreMixSteel", 1, 1, 1, "Smithing", 60, 8));

            foreach (var metal in Materials.Metals) { 
                toAdd.Add(new("knife", "bar" + metal.Name, "shavings" + metal.Name, 0, 1, 1, "Crafting", metal.Level, (int) (metal.Tier * 3)));
            }

            // Fletching
            foreach (var wood in Materials.Woods) {  
                toAdd.Add(new("tinderbox", "log" + wood.Name, "_fire", 0, 1, 1, miscStr: "ashes" + wood.Name)); 

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
            foreach (var fish in Materials.Fish) { 
                toAdd.Add(new("knife", "fishRaw" + fish.SimpleName, "fishFillet" + fish.SimpleName, 0, 1, 1, "Cooking", fish.Level, 5, returns: [ "fishScales" + fish.SimpleName ]));
            }


            toAdd.Add(new("potFlour", "bucketWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "bucketEmpty"]));
            toAdd.Add(new("potFlour", "jugWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "jugEmpty"]));
            toAdd.Add(new("potFlour", "bowlWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "bowlEmpty"]));
            toAdd.Add(new("potFlour", "potWater", "doughBread", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty", "potEmpty"]));
            
            
            toAdd.Add(new("eggChicken", "bowlEmpty", "bowlEgg", 1, 1, 1, "Cooking", 1, 0));
            toAdd.Add(new("potFlour", "bowlEgg", "bowlBatter", 1, 1, 1, "Cooking", 1, 0, returns: ["potEmpty"]));
            toAdd.Add(new("bowlBatter", "fishFilletPollock", "batteredPollock", 1, 1, 1, "Cooking", 1, 0, returns: ["bowlEmpty"]));
            toAdd.Add(new("knife", "potato", "potatoSlicesRaw", 0, 1, 1, "Cooking", 1, 0));
            toAdd.Add(new("knife", "potatoSlicesRaw", "potatoSticksRaw", 0, 1, 2, "Cooking", 1, 0));
            toAdd.Add(new("fishSticks", "potatoSticksFried", "mealFishChips", 1, 1, 1, "Cooking", 1, 10));

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
               
            // Crafting 
            foreach (var mat in Materials.Jewels) { 
                toAdd.Add(new("amulet" + mat.Name + "U", "woolBall", "amulet" + mat.Name, 1, 1, 1, "Crafting", mat.Level, 5)); 
                toAdd.Add(new("amulet" + mat.OtherMaterial + "U", "woolBall", "amulet" + mat.OtherMaterial, 1, 1, 1, "Crafting", mat.Level, 5));  
                toAdd.Add(new("uncut" + mat.Name, "chisel", "cut" + mat.Name, 1, 0, 1, "Crafting", mat.Level, mat.ExpMultiplier));  
            }
             
            toAdd.Add(new("unstrungSymbol", "woolBall", "unblessedSymbol", 1, 1, 1, "Crafting", 16, 4)); 

            foreach (var wood in Materials.Woods) { 
                toAdd.Add(new("wand" + wood.Name + "Unf", "cut" + Materials.JewelNames[(int) wood.Tier - 1], "wand" + wood.Name, s: "Crafting", lv: wood.Level, exp: (int) (20 * wood.Tier))); 
                toAdd.Add(new("potWater", "ashes" + wood.Name, "potLye"));
                toAdd.Add(new("pestleMortar", "log" + wood.Name, "pulp" + wood.Name, fQ: 0, s: "Crafting", lv: wood.Level, exp: (int) (5 * wood.Tier))); 
                toAdd.Add(new("potLye", "chips" + wood.Name, "potChips" + wood.Name, s: "Crafting", lv: wood.Level, exp: (int) (10 * wood.Tier))); 
                toAdd.Add(new("mouldPaper", "pulp" + wood.Name, "paper" + wood.Name, fQ: 0, oQ: 2, s: "Crafting", lv: wood.Level, exp: (int) (5 * wood.Tier))); 

                
                toAdd.Add(new("plantPot", "seed" + wood.Name, "plantPot" + wood.Name, 1, 1, 1, "Farming", wood.Level, (int) wood.Tier * 10)); 
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
            toAdd.Add(new("pestleMortar", "bonesRegular", "bonesRegularGround", 0, s: "Alchemy", lv: 1, exp: 5));
            toAdd.Add(new("pestleMortar", "unicornHorn", "unicornHornGround", 0, s: "Alchemy", lv: 1, exp: 5));
              

            for (int i = 0; i < toAdd.Count; i++) {
                TwoWayString ID = new(toAdd[i].FirstItem, toAdd[i].SecondItem);
                RecipeLib.Add(ID, toAdd[i]);
            }
        }
    }
}
