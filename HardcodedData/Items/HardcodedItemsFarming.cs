using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsFarming {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
             
            // // Farming - Allotments
            {
                itemsToAdd.Add(new Item("Potato seed", "Aren't potatoes potato seeds?", "seedPotato", 205, 127, 50, 5, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "potato",
                    UseInt = 1 /* Level */, UseInt2 = 10 /* Exp on Harvest */, UseInt3 = 2400 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Potato", "A tuber most versatile.", "potato", 205, 127, 50, 5) { UseString = "Heal", UseInt = 1 });

                itemsToAdd.Add(new Item("Onion seed", "An onion seed - plant in an allotment. (5)", "seedOnion", 240, 234, 214, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "onion",
                    UseInt = 7 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Onion", "A strong smelling onion.", "onion", 240, 234, 214, 12));

                itemsToAdd.Add(new Item("Cabbage seed", "A cabbage seed - plant in an allotment. (7)", "seedCabbage", 175, 97, 20, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cabbage",
                    UseInt = 7 /* Level */,  UseInt2 = 21 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cabbage", "Yuck, I don't like cabbage.", "cabbage", 34, 139, 34, 15) { UseString = "Heal", UseInt = 1 });

                itemsToAdd.Add(new Item("Tomato seed", "A tomato seed - plant in an allotment. (12)", "seedTomato", 255, 255, 0, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "tomato",
                    UseInt = 12 /* Level */,  UseInt2 = 27 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Tomato", "This would make good ketchup.", "tomato", 220, 20, 60, 14) { UseString = "Heal", UseInt = 2 });

                itemsToAdd.Add(new Item("Sweetcorn seed", "A sweetcorn seed - plant in an allotment. (20)", "seedSweetcorn", 255, 255, 0, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "sweetcorn",
                    UseInt = 20 /* Level */,  UseInt2 = 36 /* Exp On Harvest */, UseInt3 = 3600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sweetcorn", "Raw sweetcorn.", "sweetcorn", 255, 255, 0, 20));

                itemsToAdd.Add(new Item("Strawberry seed", "A strawberry seed - plant in an allotment. (31)", "seedStrawberry", 255, 255, 0, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "strawberry",
                    UseInt = 31 /* Level */,  UseInt2 = 55 /* Exp On Harvest */, UseInt3 = 3600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Strawberry", "A freshly picked strawberry.", "strawberry", 220, 20, 60, 20) { UseString = "Heal", UseInt = 4 });

                itemsToAdd.Add(new Item("Watermelon seed", "A watermelon seed - plant in an allotment. (47)", "seedWatermelon", 50, 50, 50, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "watermelon",
                    UseInt = 47 /* Level */,  UseInt2 = 102 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Watermelon", "A juicy watermelon.", "watermelon", 34, 139, 34, 20) { UseString = "Heal", UseInt = 10 });

                itemsToAdd.Add(new Item("Snape grass seed", "A snape grass seed - plant in an allotment. (38)", "seedSnapegrass", 0, 255, 0, 20, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "snapegrass",
                    UseInt = 38 /* Level */,  UseInt2 = 80 /* Exp On Harvest */, UseInt3 = 12000 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Snape grass", "Strange spiky grass.", "snapegrass", 46, 139, 87, 10));
            }

            // // Farming - Flowers
            {
                itemsToAdd.Add(new Item("Marigold seed", "A marigold seed - plant in a flower patch. (2)", "seedMarigold", 245, 245, 220, 85, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "marigold",
                    UseInt = 2 /* Level */,  UseInt2 = 55 /* Exp On Harvest */, UseInt3 = 1200 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Marigold", "A bunch of marigolds.", "marigold", 255, 165, 0, 1));
                
                itemsToAdd.Add(new Item("Rosemary seed", "A rosemary seed - plant in a flower patch. (11)", "seedRosemary", 85, 107, 47, 98, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "rosemary",
                    UseInt = 11 /* Level */,  UseInt2 = 79 /* Exp On Harvest */, UseInt3 = 1200 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Rosemary", "Some rosemary.", "rosemary", 255, 165, 0, 2)); 

                itemsToAdd.Add(new Item("Nasturtium seed", "A nasturtium seed - plant in a flower patch. (24)", "seedNasturtium", 245, 245, 220, 11, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "nasturtium",
                    UseInt = 24 /* Level */,  UseInt2 = 130 /* Exp On Harvest */, UseInt3 = 1200 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Nasturtium", "A bunch of nasturtiums.", "nasturtium", 255, 0, 0, 4));

                itemsToAdd.Add(new Item("Woad seed", "A woad seed - plant in a flower patch. (25)", "seedWoad", Color.Beige, 11, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "woad",
                    UseInt = 25 /* Level */,  UseInt2 = 135 /* Exp On Harvest */, UseInt3 = 1200 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Woad leaf", "A slightly bluish leaf.", "woad", Color.DodgerBlue, 4, true));

                itemsToAdd.Add(new Item("Limpwurt seed", "A limpwurt seed - plant in a flower patch. (7)", "seedLimpwurt", Color.SandyBrown, 11, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "limpwurt",
                    UseInt = 7 /* Level */,  UseInt2 = 70 /* Exp On Harvest */, UseInt3 = 1200 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Limpwurt root", "The root of a limpwurt plant.", "limpwurt", Color.SandyBrown, 4, true));

                itemsToAdd.Add(new Item("White lily seed", "A white lily seed - plant in a flower patch. (52)", "seedWhiteLily", Color.DodgerBlue, 1250, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "ashes",
                    UseInt = 52 /* Level */,  UseInt2 = 300 /* Exp On Harvest */, UseInt3 = 9600 /* Growth time in seconds */ 

                }); 
            }

            // // Farming - Hops
            {
                // Barley
                itemsToAdd.Add(new Item("Barley seed", "A barley seed - plant in a hops patch. (3)", "seedBarley", Color.Wheat, 15, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsBarley",
                    UseInt = 3 /* Level */,  UseInt2 = 18 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Barley", "A handful of barley.", "hopsBarley", Color.Wheat, 5));

                // Hammerstone
                itemsToAdd.Add(new Item("Hammerstone seed", "A hammerstone hops seed - plant in a hops patch. (4)", "seedHammerstone", Color.DarkOliveGreen, 20, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsHammerstone",
                    UseInt = 4 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Hammerstone hops", "A handful of Hammerstone hops.", "hopsHammerstone", Color.DarkOliveGreen, 8));

                // Asgarnian
                itemsToAdd.Add(new Item("Asgarnian seed", "An asgarnian hops seed - plant in a hops patch. (8)", "seedAsgarnian", Color.DarkOliveGreen, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsAsgarnian",
                    UseInt = 8 /* Level */,  UseInt2 = 24 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Asgarnian hops", "A handful of Asgarnian hops.", "hopsAsgarnian", Color.DarkOliveGreen, 10));

                // Wendlewick
                itemsToAdd.Add(new Item("Wendlewick seed", "A wendlewick hops seed - plant in a hops patch. (11)", "seedWendlewick", Color.ForestGreen, 40, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsWendlewick",
                    UseInt = 11 /* Level */,  UseInt2 = 26 /* Exp On Harvest */, UseInt3 = 3000 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Wendlewick hops", "A handful of Wendlewick hops.", "hopsWendlewick", Color.ForestGreen, 15));

                // Jute
                itemsToAdd.Add(new Item("Jute seed", "A jute plant seed - plant in a hops patch. (13)", "seedJute", Color.SandyBrown, 40, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "jute",
                    UseInt = 13 /* Level */,  UseInt2 = 28 /* Exp On Harvest */, UseInt3 = 3000 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Jute fiber", "I can weave this to make sacks.", "jute", Color.SandyBrown, 15));
                 
                // Yanillian
                itemsToAdd.Add(new Item("Yanillian seed", "A yanillian hops seed - plant in a hops patch. (16)", "seedYanillian", Color.Goldenrod, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsYanillian",
                    UseInt = 16 /* Level */,  UseInt2 = 31 /* Exp On Harvest */, UseInt3 = 3600 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Yanillian hops", "A handful of Yanillian hops.", "hopsYanillian", Color.Goldenrod, 20));

                // Krandorian
                itemsToAdd.Add(new Item("Krandorian seed", "A yanillian hops seed - plant in a hops patch. (21)", "seedKrandorian", Color.SandyBrown, 60, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsKrandorian",
                    UseInt = 21 /* Level */,  UseInt2 = 37 /* Exp On Harvest */, UseInt3 = 4200 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Krandorian hops", "A handful of Krandorian hops.", "hopsKrandorian", Color.SandyBrown, 25));

                // Wildblood
                itemsToAdd.Add(new Item("Wildblood seed", "A wildblood hops seed - plant in a hops patch. (28)", "seedWildblood", Color.IndianRed, 70, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "hopsWildblood",
                    UseInt = 28 /* Level */,  UseInt2 = 49 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Wildblood hops", "A handful of Wildblood hops.", "hopsWildblood", Color.IndianRed, 30));

                // Grapevine
                itemsToAdd.Add(new Item("Grapevine seed", "A grapevine seed - plant in a hops patch. (49)", "seedGrapevine", Color.DimGray, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Hops", UseString3 = "grapes",
                    UseInt = 49 /* Level */,  UseInt2 = 92 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
                });
                itemsToAdd.Add(new Item("Grapes", "Good grapes for winemaking.", "grapes", Color.Purple, 40));
            }

            // // Farming - Bush
            {
                // Blueberry
                itemsToAdd.Add(new Item("Blueberry seed", "A blueberry bush seed - plant in a bush patch. (10)", "seedBlueberry", Color.PaleVioletRed, 5, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "blueberry",
                    UseInt = 1 /* Level */,  UseInt2 = 10 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Blueberries", "Lovely blue berries.", "blueberry", Color.CadetBlue, 3)); 

                // Nightshade
                itemsToAdd.Add(new Item("Nightshade seed", "A nightshade bush seed - plant in a bush patch. (10)", "seedNightshade", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "nightshade",
                    UseInt = 10 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Nightshade berries", "Deadly red berries.", "nightshade", Color.Red, 3)); 
            }
            
            itemsToAdd.Add(new Item("Plant pot", "A plant pot filled with soil.", "plantPot", 207, 185, 151, 1));
            // // Farming - Trees
            {
                // Poplar
                itemsToAdd.Add(new Item("Poplar seed", "A poplar seed - use on a plant pot to make a sapling.", "seedTreePoplar", ColorLib.Poplar, 25, true));
                itemsToAdd.Add(new Item("Plant pot (poplar)", "A poplar sapling in a pot. Plant in a tree patch.", "plantPotPoplar", ColorLib.Poplar, 25) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logPoplar",
                    UseInt = 1 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Elm
                itemsToAdd.Add(new Item("Elm seed", "An elm seed - use on a plant pot to make a sapling. (10)", "seedTreeElm", ColorLib.Elm, 50, true));
                itemsToAdd.Add(new Item("Plant pot (elm)", "An elm sapling in a pot. Plant in a tree patch. (10)", "plantPotElm", ColorLib.Elm, 50) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logElm",
                    UseInt = 10 /* Level */,  UseInt2 = 200 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Walnut
                itemsToAdd.Add(new Item("Walnut seed", "A walnut seed - use on a plant pot to make a sapling. (20)", "seedTreeWalnut", ColorLib.Walnut, 75, true));
                itemsToAdd.Add(new Item("Plant pot (walnut)", "A walnut sapling in a pot. Plant in a tree patch. (20)", "plantPotWalnut", ColorLib.Walnut, 75) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logWalnut",
                    UseInt = 20 /* Level */,  UseInt2 = 300 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Holly
                itemsToAdd.Add(new Item("Holly seed", "A holly seed - use on a plant pot to make a sapling. (30)", "seedTreeHolly", ColorLib.Holly, 100, true));
                itemsToAdd.Add(new Item("Plant pot (holly)", "A holly sapling in a pot. Plant in a tree patch. (30)", "plantPotHolly", ColorLib.Holly, 100) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logHolly",
                    UseInt = 30 /* Level */,  UseInt2 = 400 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Acacia
                itemsToAdd.Add(new Item("Acacia seed", "An acacia seed - use on a plant pot to make a sapling. (40)", "seedTreeAcacia", ColorLib.Acacia, 125, true));
                itemsToAdd.Add(new Item("Plant pot (acacia)", "An acacia sapling in a pot. Plant in a tree patch. (40)", "plantPotAcacia", ColorLib.Acacia, 125) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logAcacia",
                    UseInt = 40 /* Level */,  UseInt2 = 500 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Birch
                itemsToAdd.Add(new Item("Birch seed", "A birch seed - use on a plant pot to make a sapling. (50)", "seedTreeBirch", ColorLib.Birch, 150, true));
                itemsToAdd.Add(new Item("Plant pot (birch)", "A birch sapling in a pot. Plant in a tree patch. (50)", "plantPotBirch", ColorLib.Birch, 150) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logBirch",
                    UseInt = 50 /* Level */,  UseInt2 = 600 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Hickory
                itemsToAdd.Add(new Item("Hickory seed", "A hickory seed - use on a plant pot to make a sapling. (60)", "seedTreeHickory", ColorLib.Hickory, 175, true));
                itemsToAdd.Add(new Item("Plant pot (hickory)", "A hickory sapling in a pot. Plant in a tree patch. (60)", "plantPotHickory", ColorLib.Hickory, 175) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logHickory",
                    UseInt = 60 /* Level */,  UseInt2 = 700 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Bloodwood
                itemsToAdd.Add(new Item("Bloodwood seed", "A bloodwood seed - use on a plant pot to make a sapling. (70)", "seedTreeBloodwood", ColorLib.Bloodwood, 200, true));
                itemsToAdd.Add(new Item("Plant pot (bloodwood)", "A bloodwood sapling in a pot. Plant in a tree patch. (70)", "plantPotBloodwood", ColorLib.Bloodwood, 200) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logBloodwood",
                    UseInt = 70 /* Level */,  UseInt2 = 800 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Camatillo
                itemsToAdd.Add(new Item("Camatillo seed", "A camatillo seed - use on a plant pot to make a sapling. (80)", "seedTreeCamatillo", ColorLib.Camatillo, 300, true));
                itemsToAdd.Add(new Item("Plant pot (camatillo)", "A camatillo sapling in a pot. Plant in a tree patch. (80)", "plantPotCamatillo", ColorLib.Camatillo, 300) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logCamatillo",
                    UseInt = 80 /* Level */,  UseInt2 = 900 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });

                // Katalox
                itemsToAdd.Add(new Item("Katalox seed", "A katalox seed - use on a plant pot to make a sapling. (90)", "seedTreeKatalox", ColorLib.Katalox, 500, true));
                itemsToAdd.Add(new Item("Plant pot (katalox)", "A katalox sapling in a pot. Plant in a tree patch. (90)", "plantPotKatalox", ColorLib.Katalox, 500) {
                    UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "logKatalox",
                    UseInt = 90 /* Level */,  UseInt2 = 1000 /* Exp On Harvest */, UseInt3 = 960 /* Growth time in seconds */, UseInt4 = 960 /* Regrowth time in seconds */
                });
            }

            // // Farming - Fruit Trees
            {  
                // Apple Tree
                itemsToAdd.Add(new Item("Apple tree seed", "An apple tree seed - use on a plant pot to make a sapling. (27)", "seedTreeApple", ColorLib.Walnut, 20, true));
                itemsToAdd.Add(new Item("Plant pot (apple)", "An apple tree sapling in a pot. Plant in a fruit tree patch. (27)", "plantPotApple", ColorLib.Walnut, 20) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitApple",
                    UseInt = 27 /* Level */,  UseInt2 = 500 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Apple", "Keeps the doctor away.", "fruitApple", Color.Lime, 36));

                // Banana Tree
                itemsToAdd.Add(new Item("Banana tree seed", "A banana tree seed - use on a plant pot to make a sapling. (33)", "seedTreeBanana", Color.AntiqueWhite, 30, true));
                itemsToAdd.Add(new Item("Plant pot (banana)", "A banana tree sapling in a pot. Plant in a fruit tree patch. (33)", "plantPotBanana", Color.AntiqueWhite, 30) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitBanana",
                    UseInt = 33 /* Level */,  UseInt2 = 550 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Banana", "Mmm banana.", "fruitBanana", Color.Yellow, 10) { UseString = "Heal", UseInt = 2 });
                itemsToAdd.Add(new Item("Sliced banana", "You swear you had more than three slices before.", "fruitBananaSlices", Color.Yellow, 10) { UseString = "Heal", UseInt = 2 });
                itemsToAdd.Add(new Item("Peach", "A tasty fruit.", "fruitPeach", Color.Yellow, 10) { UseString = "Heal", UseInt = 8 });

                // Orange Tree
                itemsToAdd.Add(new Item("Orange tree seed", "An orange tree seed - use on a plant pot to make a sapling. (39)", "seedTreeOrange", Color.AntiqueWhite, 30, true));
                itemsToAdd.Add(new Item("Plant pot (orange)", "An orange tree sapling in a pot. Plant in a fruit tree patch. (39)", "plantPotOrange", Color.AntiqueWhite, 30) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitOrange",
                    UseInt = 39 /* Level */,  UseInt2 = 600 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Orange", "A common fruit.", "fruitOrange", Color.MonoGameOrange, 70) { UseString = "Heal", UseInt = 2 });
                itemsToAdd.Add(new Item("Orange slices", "Fresh orange slices.", "fruitOrangeSlices", Color.MonoGameOrange, 70) { UseString = "Heal", UseInt = 2 });
                itemsToAdd.Add(new Item("Orange chunks", "Fresh chunks of orange.", "fruitOrangeChunks", Color.MonoGameOrange, 70) { UseString = "Heal", UseInt = 2 });

                // Curry Tree
                itemsToAdd.Add(new Item("Curry tree seed", "A curry tree seed - use on a plant pot to make a sapling. (42)", "seedTreeCurry", Color.Orange, 40, true));
                itemsToAdd.Add(new Item("Plant pot (curry)", "A curry tree sapling in a pot. Plant in a fruit tree patch. (42)", "plantPotCurry", Color.Orange, 40) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "curryLeaf",
                    UseInt = 42 /* Level */,  UseInt2 = 650 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Curry leaf", "I could make a spicy curry with this.", "curryLeaf", Color.SandyBrown, 20));

                // Pineapple
                itemsToAdd.Add(new Item("Pineapple seed", "A pineapple seed - use on a plant pot to make a sapling. (51)", "seedtreePoplarapple", Color.SaddleBrown, 75, true));
                itemsToAdd.Add(new Item("Plant pot (pineapple)", "A pineapple seedling in a pot. Plant in a fruit tree patch. (51)", "plantPotPineapple", Color.SaddleBrown, 75) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitPineapple",
                    UseInt = 51 /* Level */,  UseInt2 = 700 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Pineapple", "It can be cut up into something more manageable with a knife.", "fruitPineapple", Color.Yellow, 20));
                itemsToAdd.Add(new Item("Pineapple chunks", "Fresh chunks of pineapple.", "fruitPineappleChunks", Color.Yellow, 5) { UseString = "Heal", UseInt = 2 });
                itemsToAdd.Add(new Item("Pineapple ring", "Exotic fruit.", "fruitPineappleRing", Color.Yellow, 5) { UseString = "Heal", UseInt = 2 });

                // Papaya Tree
                itemsToAdd.Add(new Item("Papaya tree seed", "A papaya tree seed - use on a plant pot to make a sapling. (57)", "seedTreePapaya", Color.DimGray, 120, true));
                itemsToAdd.Add(new Item("Plant pot (papaya)", "A papaya tree sapling in a pot. Plant in a fruit tree patch. (57)", "plantPotPapaya", Color.DimGray, 120) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitPapaya",
                    UseInt = 57 /* Level */,  UseInt2 = 750 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Papaya", "Papaya, papaya, pa-paya-paya!", "fruitPapaya", Color.YellowGreen, 64) { UseString = "Heal", UseInt = 8 });

                // Palm Tree
                itemsToAdd.Add(new Item("Palm tree seed", "A palm tree seed - use on a plant pot to make a sapling. (68)", "seedTreePalm", Color.Wheat, 250, true));
                itemsToAdd.Add(new Item("Plant pot (coconut)", "A palm tree sapling in a pot. Plant in a fruit tree patch. (68)", "plantPotPalm", Color.Wheat, 250) {
                    UseString = "PlantSeed", UseString2 = "Fruit Tree", UseString3 = "fruitCoconut",
                    UseInt = 68 /* Level */,  UseInt2 = 800 /* Exp On Harvest */, UseInt3 = 57600 /* Growth time in seconds */, UseInt4 = 2400 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Coconut", "It's a coconut.", "fruitCoconut", Color.SaddleBrown, 90));
                itemsToAdd.Add(new Item("Half coconut", "It's a coconut.", "fruitCoconutHalf", Color.SaddleBrown, 90));
                itemsToAdd.Add(new Item("Coconut milk", "A vial filled with coconut milk.", "fruitCoconutMilk", Color.White, 90));
                itemsToAdd.Add(new Item("Coconut shell", "All the milk has been removed.", "fruitCoconutShell", Color.SaddleBrown, 90));
            }


            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
