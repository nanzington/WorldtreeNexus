using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsCooking {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Burnt meat", "Oh dear, it's totally burnt!", "burntMeat", Color.DimGray, 1));
            itemsToAdd.Add(new Item("Burnt food", "Completely inedible now, whatever it was supposed to be.", "burntFood", Color.DimGray, 1));
            itemsToAdd.Add(new Item("Burnt food bowl", "Completely inedible now, whatever it was. At least the bowl is salvageable.", "burntBowl", Color.DimGray, 1) { UseString = "Transform", UseString2 = "bowlEmpty" });
            itemsToAdd.Add(new Item("Burnt pie", "Completely inedible now, whatever it was. At least the dish is salvageable.", "burntPie", Color.DimGray, 1) { UseString = "Transform", UseString2 = "pieEmpty" });
            
            itemsToAdd.Add(new Item("Cooked sweetcorn", "A nice cob of cooked sweetcorn.", "sweetcornCooked", Color.Goldenrod, 9) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ] });
            

            foreach (var fish in Materials.Fish) { 
                Color cooked = Color.Lerp(new Color(fish.R, fish.G, fish.B), Color.Orange, 0.5f);
                itemsToAdd.Add(new Item("Raw " + fish.Name.ToLower(), "A raw " + fish.Descriptor + ". Cook with " + fish.Level + " Cooking.", "fishRaw" + fish.SimpleName, fish.R, fish.G, fish.B, fish.CostMultiplier) { SpoilTimer = 144 }); 
                itemsToAdd.Add(new Item("Grilled " + fish.Name.ToLower(), "Nicely grilled " + fish.Descriptor + ".", "fishCooked" + fish.SimpleName, cooked, fish.CostMultiplier) { SpoilTimer = 432, UseString = "Potion", Potion = [ new("Heal", (int) fish.Tier), new("Hunger", 10) ] }); 
                itemsToAdd.Add(new Item(fish.Name + " fillet", "A " + fish.Descriptor + " cleaned, prepared, and cut into a fillet.", "fishFillet" + fish.SimpleName, cooked, fish.CostMultiplier)); 
            }
            itemsToAdd.Add(new Item("Minnow scales", "A pile of minnow scales.", "fishScalesMinnow", Color.SpringGreen, 1) { Alchemy = new(5, 8, 3, 14, 1) }); 
            itemsToAdd.Add(new Item("Bluegill scales", "A pile of bluegill scales.", "fishScalesBluegill", Color.SeaGreen, 2) { Alchemy = new(-7, 8, -6, -9, 1) }); 
            itemsToAdd.Add(new Item("Pollock scales", "A pile of pollock scales.", "fishScalesPollock", Color.DarkGray, 1) { Alchemy = new(7, 3, 10, 10, 1) }); 
            itemsToAdd.Add(new Item("Cod scales", "A pile of cod scales.", "fishScalesCod", ColorLib.PastelYellow, 2) { Alchemy = new(-7, -9, -8, -6, 1) }); 
                


            itemsToAdd.Add(new Item("Raw cuy meat", "A cut of meat taken from a giant guinea pig.", "meatRawCuy", 138, 3, 3, 10) { SpoilTimer = 144, Alchemy = new(-13, -6, 7, -4, 1) });
            itemsToAdd.Add(new Item("Raw beef", "A cut of meat taken from a cow.", "meatRawBeef", 138, 3, 3, 5) { SpoilTimer = 142, Alchemy = new(-11, 8, 8, -3, 1) });
            itemsToAdd.Add(new Item("Raw rat meat", "A cut of meat taken from a rat.", "meatRawRat", 138, 3, 3, 10) { SpoilTimer = 142, Alchemy = new(-6, 14, 4, 6, 1) });
            itemsToAdd.Add(new Item("Raw bear meat", "A cut of meat taken from a bear.", "meatRawBear", 138, 3, 3, 50) { SpoilTimer = 142, Alchemy = new(7, 7, -9, -7, 1) });
            itemsToAdd.Add(new Item("Raw chicken", "A whole chicken, currently very inedible.", "meatRawChicken", 242, 209, 209, 10) { SpoilTimer = 142, Alchemy = new(-3, -8, -7, 12, 1) });
             
            itemsToAdd.Add(new Item("Cooked meat", "A cooked cut of meat.", "meatCooked", 150, 100, 50, 10) { SpoilTimer = 432, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ] }); 
            itemsToAdd.Add(new Item("Cooked chicken", "A cooked chicken.", "meatCookedChicken", 150, 100, 50, 10) { SpoilTimer = 432, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ] });
            
            itemsToAdd.Add(new Item("Pie shell", "I need to find a filling for this pie.", "pieShell", Color.SandyBrown, 4)); 
            
            itemsToAdd.Add(new Item("Tea leaves", "Mmm, how about a nice cup of tea?", "teaLeaves", Color.ForestGreen, 1, trade: false) { Alchemy = new(6, 10, -7, -7, 1) }); 
            itemsToAdd.Add(new Item("Kettle (empty)", "The kettle is empty.", "kettleEmpty", ColorLib.Steel, 1, trade: false)); 
            itemsToAdd.Add(new Item("Kettle (full)", "The kettle is full of water.", "kettleFull", ColorLib.Steel, 1, trade: false)); 
            itemsToAdd.Add(new Item("Kettle (hot)", "The kettle is full of boiling water.", "kettleHot", ColorLib.Steel, 1, trade: false)); 
            itemsToAdd.Add(new Item("Clay teapot (empty)", "Needs some tea leaves.", "teapotClayEmpty", Color.SandyBrown, 1, trade: false)); 
            itemsToAdd.Add(new Item("Clay teapot (leaves)", "Needs some hot water.", "teapotClayLeaves", Color.SandyBrown, 1, trade: false)); 
            itemsToAdd.Add(new Item("Clay teapot (tea)", "Ahhhh, lovely. Where's my cup?", "teapotClayTea", Color.SandyBrown, 1, trade: false) { UseString = "Teapot", UsesCharges = true, UseInt4 = 4, ItemReturned = "teapotClayEmpty"}); 
            itemsToAdd.Add(new Item("Porcelain teapot (empty)", "Needs some tea leaves.", "teapotPorcelainEmpty", Color.White, 1, trade: false)); 
            itemsToAdd.Add(new Item("Porcelain teapot (leaves)", "Needs some hot water.", "teapotPorcelainLeaves", Color.White, 1, trade: false)); 
            itemsToAdd.Add(new Item("Porcelain teapot (tea)", "Ahhhh, lovely. Where's my cup?", "teapotPorcelainTea", Color.White, 1, trade: false) { UseString = "Teapot", UsesCharges = true, UseInt4 = 4, ItemReturned = "teapotPorcelainEmpty"}); 
            itemsToAdd.Add(new Item("Antique teapot (empty)", "Needs some tea leaves.", "teapotAntiqueEmpty", Color.AntiqueWhite, 1, trade: false)); 
            itemsToAdd.Add(new Item("Antique teapot (leaves)", "Needs some hot water.", "teapotAntiqueLeaves", Color.AntiqueWhite, 1, trade: false));
            itemsToAdd.Add(new Item("Antique teapot (tea)", "Ahhhh, lovely. Where's my cup?", "teapotAntiqueTea", Color.AntiqueWhite, 1, trade: false) { UseString = "Teapot", UsesCharges = true, UseInt4 = 4, ItemReturned = "teapotAntiqueEmpty"});
            itemsToAdd.Add(new Item("Clay cup (empty)", "An empty cup.", "cupClayEmpty", Color.SandyBrown, 1, trade: false)); 
            itemsToAdd.Add(new Item("Porcelain cup (empty)", "An empty cup.", "cupPorcelainEmpty", Color.White, 1, trade: false)); 
            itemsToAdd.Add(new Item("Antique cup (empty)", "An empty cup.", "cupAntiqueEmpty", Color.AntiqueWhite, 1, trade: false));  
            itemsToAdd.Add(new Item("Cup of tea", "A lovely cup of tea.", "cupClayTea", Color.SandyBrown, 1, trade: false) { UseString = "Potion", UseInt4 = 1, ItemReturned = "cupClayEmpty", Potion = [ new("Construction", 1), new("Thirst", 35) ]}); 
            itemsToAdd.Add(new Item("Porcelain cup of tea", "A lovelier cup of tea.", "cupPorcelainTea", Color.White, 1, trade: false) { UseString = "Potion", UseInt4 = 1, ItemReturned = "cupPorcelainEmpty", Potion = [ new("Construction", 2), new("Thirst", 35) ]}); 
            itemsToAdd.Add(new Item("Antique cup of tea", "A loveliest cup of tea.", "cupAntiqueTea", Color.AntiqueWhite, 1, trade: false) { UseString = "Potion", UseInt4 = 1, ItemReturned = "cupAntiqueEmpty", Potion = [ new("Construction", 3), new("Thirst", 35) ]}); 

            itemsToAdd.Add(new Item("Cup of tea w/ milk", "A lovely cup of tea. Has some milk added.", "cupClayTeaMilk", Color.SandyBrown, 1, trade: false) { SpoilTimer = 432, UseString = "Potion", UseInt4 = 1, ItemReturned = "cupClayEmpty", Potion = [ new("Construction", 1), new("Thirst", 35) ]}); 
            itemsToAdd.Add(new Item("Porcelain cup of tea w/ milk", "A lovelier cup of tea. Has some milk added.", "cupPorcelainTeaMilk", Color.White, 1, trade: false) { SpoilTimer = 432, UseString = "Potion", UseInt4 = 1, ItemReturned = "cupPorcelainEmpty", Potion = [ new("Construction", 2), new("Thirst", 35) ]}); 
            itemsToAdd.Add(new Item("Antique cup of tea w/ milk", "A loveliest cup of tea. Has some milk added.", "cupAntiqueTeaMilk", Color.AntiqueWhite, 1, trade: false) { SpoilTimer = 432, UseString = "Potion", UseInt4 = 1, ItemReturned = "cupAntiqueEmpty", Potion = [ new("Construction", 3), new("Thirst", 35) ]}); 


            itemsToAdd.Add(new Item("Beer glass", "I need to fill this with beer.", "beerGlass", 200, 200, 200, 2));
            itemsToAdd.Add(new Item("Beer", "A glass of frothy ale.", "beer", 255, 255, 0, 2) { UseString = "Potion", UseInt4 = 1, ItemReturned = "beerGlass", Potion = [ new("Heal", 1), new("Attack", -2), new("Strength", 2), new("Thirst", 20) ]});

            itemsToAdd.Add(new Item("Garlic", "Deters vampires.", "garlic", Color.AntiqueWhite, 3) { Alchemy = new(-6, 8, -8, 8, 1) });
             
            itemsToAdd.Add(new Item("Raw potato slices", "A potato sliced into equal portions.", "potatoSlicesRaw", Color.AntiqueWhite, 3) { SpoilTimer = 432 });
            itemsToAdd.Add(new Item("Raw potato sticks", "A potato cut into sticks.", "potatoSticksRaw", Color.AntiqueWhite, 3) { SpoilTimer = 432 });
            itemsToAdd.Add(new Item("Raw potato cubes", "A potato diced into cubes.", "potatoCubesRaw", Color.AntiqueWhite, 3) { SpoilTimer = 432 });
            itemsToAdd.Add(new Item("Fried potato sticks", "A serving of potato sticks deepfried in oil to golden perfection.", "potatoSticksFried", Color.Goldenrod, 10) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ]});
            itemsToAdd.Add(new Item("Baked potato", "A potato, baked until the inside is nice and fluffy. Could use some butter.", "potatoBaked", 205, 127, 50, 10) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ]});

            itemsToAdd.Add(new Item("Egg", "An egg from a chicken. Could be fried or scrambled, perhaps.", "eggChicken", 233, 185, 93, 4) { Alchemy = new(-8, 10, 7, -5, 1) });
            itemsToAdd.Add(new Item("Bowl of egg", "A bowl with an egg cracked into it.", "bowlEgg", Color.Yellow, 3));
            itemsToAdd.Add(new Item("Bowl of batter", "A bowl of simple egg and flour batter.", "bowlBatter", Color.Beige, 3));
            itemsToAdd.Add(new Item("Battered pollock", "A pollock fillet rolled in batter.", "batteredPollock", Color.Beige, 3) { SpoilTimer = 432 });
            itemsToAdd.Add(new Item("Fish sticks", "A battered pollock fillet, deepfried to crispy goodness.", "fishSticks", Color.PaleGoldenrod, 10) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ]});
            itemsToAdd.Add(new Item("Fish and chips", "Fried pollock with a side of fried potatoes. Terrible for your arteries, but tastes great!", "mealFishChips", Color.Goldenrod, 30) { SpoilTimer = 432, UseString = "Potion", Potion = [ new("Heal", 5), new("Hunger", 30) ]});


            itemsToAdd.Add(new Item("Pot of flour", "A pot full of flour.", "potFlour", 207, 185, 151, 10) { Alchemy = new(13, -8, -7, -2, 1, "potEmpty") });
            itemsToAdd.Add(new Item("Bread dough", "Some uncooked dough.", "doughBread", 221, 199, 160, 4) { UseString = "Baking" });
            itemsToAdd.Add(new Item("Pizza base", "I need to add some tomato next.", "doughPizza", 221, 199, 160, 4) { UseString = "Baking" });
            itemsToAdd.Add(new Item("Pastry dough", "Some uncooked dough.", "doughPastry", 221, 199, 160, 4) { UseString = "Baking" });
            itemsToAdd.Add(new Item("Bread", "Nice crispy bread.", "bread", 233, 185, 93, 12) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 2), new("Hunger", 10) ]}); 
            itemsToAdd.Add(new Item("Cake", "A plain sponge cake.", "cake", 255, 255, 255, 50) { SpoilTimer = 432, UseString = "Potion", Potion = [ new("Heal", 10), new("Hunger", 30) ]});
              
            itemsToAdd.Add(new Item("Pot of water", "A pot filled with water.", "potWater", 207, 185, 151, 1));
            itemsToAdd.Add(new Item("Pot of lye", "A pot filled with water and wood ash.", "potLye", 207, 185, 151, 6) { Alchemy = new(-6, 8, 9, 7, 1, "potEmpty") });

            itemsToAdd.Add(new Item("Bucket of water", "A bucket filled with water.", "bucketWater", 111, 66, 33, 2) { UseString = "Potion", Potion = [ new("Thirst", 30) ]});
            itemsToAdd.Add(new Item("Bucket of milk", "A bucket filled with milk.", "bucketMilk", 111, 66, 33, 2) { SpoilTimer = 1008, Alchemy = new(-11, -7, -5, -7, 1, "potEmpty"), UseString = "Potion", Potion = [ new("Thirst", 30) ] });
            itemsToAdd.Add(new Item("Bottomless milk bucket", "It's a bucket of milk that never ends!", "bucketMilkBottomless", 111, 66, 33, 15000) { CountsAsIDs = ["bucketMilk"], UseInt4 = -1 });
            itemsToAdd.Add(new Item("Pot of cream", "Fresh cream.", "cream", Color.White, 4));
            itemsToAdd.Add(new Item("Pat of butter", "A pat of freshly churned butter.", "butter", Color.LightYellow, 8));
            itemsToAdd.Add(new Item("Cheese", "Cheese, Gromit! Cheese!", "cheese", Color.Yellow, 12) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ]});
            itemsToAdd.Add(new Item("Jug of water", "A jug filled with water.", "jugWater", 200, 200, 200, 1) { UseString = "Potion", Potion = [ new("Thirst", 30) ]});
            itemsToAdd.Add(new Item("Jug of wine", "A jug filled with wine.", "jugWine", 200, 200, 200, 100) { UseString = "Potion", ItemReturned = "jugEmpty", UseInt4 = 1, Potion = [ new("Attack", -2), new("Heal", 11), new("Thirst", 20) ]});
            itemsToAdd.Add(new Item("Bottle of wine", "A very good vintage.", "bottleWine", Color.IndianRed, 500) { UseString = "Potion", ItemReturned = "bottleEmpty", UseInt4 = 1, Potion = [ new("Attack", -3), new("Heal", 14) ]});
            itemsToAdd.Add(new Item("Empty wine bottle", "The one has clearly been taken down and passed around.", "bottleEmpty", Color.White, 2));
            itemsToAdd.Add(new Item("Bowl of water", "A bowl filled with water.", "bowlWater", 207, 185, 151, 4) { UseString = "Potion", Potion = [ new("Thirst", 30) ] });
            itemsToAdd.Add(new Item("Cake tin", "Useful for baking cakes.", "tinCakeEmpty", 100, 100, 100, 10));
            itemsToAdd.Add(new Item("Cake tin (egg)", "A cake tin with an egg cracked into it. Needs flour and milk.", "tinCakeEgg", 100, 100, 100, 13));
            itemsToAdd.Add(new Item("Cake tin (egg, flour)", "A cake tin with an egg and some flour. Still needs milk.", "tinCakeFlour", 100, 100, 100, 16));
            itemsToAdd.Add(new Item("Cake tin (batter)", "A tin full of cake batter, ready for cooking.", "tinCakeBatter", 100, 100, 100, 20));

            itemsToAdd.Add(new Item("Chocolate bar", "Mmmmmmmm chocolate.", "chocolateBar", Color.Chocolate, 10) { SpoilTimer = 720, UseString = "Potion", Potion = [ new("Heal", 1), new("Rest", 2), new("Hunger", 5) ] });
            itemsToAdd.Add(new Item("Chocolate dust", "It's ground up chocolate.", "chocolateDust", Color.Chocolate, 10) { Alchemy = new(13, 7, -5, -5, 1) });


            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
