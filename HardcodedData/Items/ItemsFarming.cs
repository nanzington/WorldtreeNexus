using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsFarming {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
             
            // Generally speaking exp = 10 per 600s to grow, multiplied by tier.
            // Seed cost = 1/3/5 progression by tier starting at 10 for level 1. Output cost half of seed cost

            // // Farming - Allotments
            {
                // Potato
                itemsToAdd.Add(new Item("Potato seed", "Aren't potatoes potato seeds? Plant in an allotment. (1)", "seedPotato", Color.SaddleBrown, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "potato",
                    UseInt = 1 /* Level */, UseInt2 = 40 /* Exp on Harvest */, UseInt3 = 2400 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Potato", "A tuber most versatile.", "potato", Color.SaddleBrown, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(3, 6, -14, -7, 1)  });

                // Onion
                itemsToAdd.Add(new Item("Onion seed", "An onion seed - plant in an allotment. (1)", "seedOnion", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "onion",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Onion", "A strong smelling onion.", "onion", Color.Beige, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(6, 9, -6, 9, 1)  });

                // Cabbage
                itemsToAdd.Add(new Item("Cabbage seed", "A cabbage seed - plant in an allotment. (1)", "seedCabbage", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cabbage",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cabbage", "Yuck, I don't like cabbage.", "cabbage", Color.Lime, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(11, -6, -9, -4, 1)  });

                // Tomato
                itemsToAdd.Add(new Item("Tomato seed", "A tomato seed - plant in an allotment. (1)", "seedTomato", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "tomato",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Tomato", "This would make good ketchup.", "tomato", Color.Crimson, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(-8, -6, -5, 11, 1)  });

                // Sweetcorn
                itemsToAdd.Add(new Item("Sweetcorn seed", "A sweetcorn seed - plant in an allotment. (1)", "seedSweetcorn", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "sweetcorn",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sweetcorn", "Raw sweetcorn.", "sweetcorn", Color.Yellow, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(-9, -9, -6, -6, 1)  });
                
                // Lettuce
                itemsToAdd.Add(new Item("Lettuce seed", "A lettuce seed - plant in an allotment. (1)", "seedLettuce", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "lettuce",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Lettuce", "A head of lettuce. Alas, poor Yorick! I grew him.", "lettuce", Color.SpringGreen, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(-7, 12, 4, 7, 1)  });

                // Broccoli
                itemsToAdd.Add(new Item("Broccoli seed", "A broccoli seed - plant in an allotment. (1)", "seedBroccoli", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "broccoli",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Broccoli", "A crown of broccoli.", "broccoli", Color.ForestGreen, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(6, 11, 8, -5, 1)  });

                // Cauliflower
                itemsToAdd.Add(new Item("Cauliflower seed", "A cauliflower seed - plant in an allotment. (1)", "seedCauliflower", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cauliflower",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cauliflower", "A crown of cauliflower.", "cauliflower", Color.AntiqueWhite, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(7, -9, 8, 6, 1)  });

                // Bellpepper
                itemsToAdd.Add(new Item("Bellpepper seed", "A bellpepper seed - plant in an allotment. (1)", "seedBellpepper", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "bellpepper",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Bellpepper", "A nice yellow bellpepper.", "bellpepper", Color.Yellow, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(-11, -4, 7, -8, 1)  });

                // Carrot
                itemsToAdd.Add(new Item("Carrot seed", "A carrot seed - plant in an allotment. (1)", "seedCarrot", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "carrot",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Carrot", "A vibrant orange carrot.", "carrot", Color.Orange, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(7, 7, -6, 10, 1)  });

                // Cucumber
                itemsToAdd.Add(new Item("Cucumber seed", "A cucumber seed - plant in an allotment. (1)", "seedCucumber", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cucumber",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cucumber", "A cucumber. Good in salads.", "cucumber", Color.DarkGreen, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(4, -9, -10, 7, 1)  });

                // Sweetpeas
                itemsToAdd.Add(new Item("Sweetpeas seed", "A sweetpeas seed - plant in an allotment. (1)", "seedSweetpeas", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "sweetpeas",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sweetpeas", "Some fresh peas still in their pods.", "sweetpeas", Color.LawnGreen, 5) { UseString = "Heal", UseInt = 1, Alchemy = new(6, 12, 3, 9, 1)  });

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

            
            // // Farming - Bush
            {
                // Strawberry
                itemsToAdd.Add(new Item("Strawberry seed", "A strawberry seed - plant in an allotment. (1)", "seedStrawberry", 255, 255, 0, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "strawberry",
                    UseInt = 31 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Strawberry", "A freshly picked strawberry.", "strawberry", 220, 20, 60, 20) { UseString = "Heal", UseInt = 4 });

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


            // // Farming - Mushrooms (Safe)
            {
                itemsToAdd.Add(new Item("Shaggy mane spore", "A shaggy mane spore - plant in a mushroom patch. (1)", "seedShaggyMane", Color.AntiqueWhite, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomShaggyMane",
                    UseInt = 1 /* Level */, UseInt2 = 20 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Shaggy mane", "A white mushroom.", "mushroomShaggyMane", 255, 255, 255, 5) { Alchemy = new(8, -8, -5, -9, 1) });

                
                itemsToAdd.Add(new Item("Honeycap spore", "A honeycap spore - plant in a mushroom patch. (10)", "seedHoneycap", Color.AntiqueWhite, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomHoneycap",
                    UseInt = 10 /* Level */, UseInt2 = 40 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Honeycap", "A yellow mushroom.", "mushroomHoneycap", 220, 220, 0, 15) { Alchemy = new(10, 7, -7, 5, 10) });

                
                itemsToAdd.Add(new Item("Deafcup spore", "A deafcup spore - plant in a mushroom patch. (20)", "seedDeafcup", Color.AntiqueWhite, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomDeafcup",
                    UseInt = 20 /* Level */, UseInt2 = 60 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Deafcup", "A black mushroom.", "mushroomDeafcup", 70, 70, 70, 25) { Alchemy = new(7, 4, 10, 7, 20) });


                itemsToAdd.Add(new Item("Conifer tuft spore", "A conifer tuft spore - plant in a mushroom patch. (30)", "seedConiferTuft", Color.AntiqueWhite, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomConiferTuft",
                    UseInt = 30 /* Level */, UseInt2 = 80 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Conifer tuft", "An orange mushroom.", "mushroomConiferTuft", 255, 165, 0, 50) { Alchemy = new(-2, -10, -6, 9, 30) });


                itemsToAdd.Add(new Item("Oyster mushroom spore", "An oyster mushroom spore - plant in a mushroom patch. (40)", "seedOysterMushroom", Color.AntiqueWhite, 300, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomOyster",
                    UseInt = 40 /* Level */, UseInt2 = 100 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Oyster mushroom", "An off-white mushroom.", "mushroomOyster", 250, 235, 215, 150) { Alchemy = new(-7, 9, 4, 6, 40) });


                itemsToAdd.Add(new Item("Milkcap spore", "A milkcap spore - plant in a mushroom patch. (50)", "seedMilkcap", Color.AntiqueWhite, 500, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomMilkcap",
                    UseInt = 50 /* Level */, UseInt2 = 120 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Milkcap", "An off-white mushroom.", "mushroomMilkcap", 196, 164, 132, 250) { Alchemy = new(1, 13, -3, -8, 50) });


                itemsToAdd.Add(new Item("Blewit spore", "A blewit spore - plant in a mushroom patch. (60)", "seedBlewit", Color.AntiqueWhite, 1000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomBlewit",
                    UseInt = 60 /* Level */, UseInt2 = 140 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Blewit", "A pale blue mushroom.", "mushroomBlewit", 135, 206, 235, 500) { Alchemy = new(-8, -7, -5, 4, 60) });


                itemsToAdd.Add(new Item("Chanterelle spore", "A chanterelle spore - plant in a mushroom patch. (70)", "seedChanterelle", Color.AntiqueWhite, 3000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomChanterelle",
                    UseInt = 70 /* Level */, UseInt2 = 160 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Chanterelle", "A brown mushroom.", "mushroomChanterelle", 101, 67, 33, 1500) { Alchemy = new(6, 5, -7, 5, 70) });


                itemsToAdd.Add(new Item("Inkhorn spore", "An inkhorn spore - plant in a mushroom patch. (80)", "seedInkhorn", Color.AntiqueWhite, 5000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomInkhorn",
                    UseInt = 80 /* Level */, UseInt2 = 180 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Inkhorn", "A green mushroom.", "mushroomInkhorn", 50, 205, 50, 2500) { Alchemy = new(-5, 7, 6, 4, 80) });


                itemsToAdd.Add(new Item("Wood ear spore", "A wood ear spore - plant in a mushroom patch. (90)", "seedWoodEar", Color.AntiqueWhite, 10000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomWoodEar",
                    UseInt = 90 /* Level */, UseInt2 = 200 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Wood ear", "A pink mushroom.", "mushroomWoodEar", 255, 209, 220, 5000) { Alchemy = new(-7, -3, 5, 6, 90) });


                itemsToAdd.Add(new Item("Puffball spore", "A puffball spore - plant in a mushroom patch. (100)", "seedPuffball", Color.AntiqueWhite, 30000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomPuffball",
                    UseInt = 100 /* Level */, UseInt2 = 300 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Puffball", "A red mushroom.", "mushroomPuffball", 255, 209, 220, 15000) { Alchemy = new(5, -1, 6, -8, 100) });
            }

            // // Farming - Mushrooms (Toxic)
            {
                itemsToAdd.Add(new Item("Shabby mane spore", "A shabby mane spore - plant in a mushroom patch. (1)", "seedShabbyMane", Color.AntiqueWhite, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomShabbyMane",
                    UseInt = 1 /* Level */, UseInt2 = 20 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Shabby mane", "A white mushroom.", "mushroomShabbyMane", 255, 255, 255, 5) { Alchemy = new(-8, 8, 5, 9, 1) });

                
                itemsToAdd.Add(new Item("Honeycup spore", "A honeycup spore - plant in a mushroom patch. (10)", "seedHoneycup", Color.AntiqueWhite, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomHoneycup",
                    UseInt = 10 /* Level */, UseInt2 = 40 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Honeycup", "A yellow mushroom.", "mushroomHoneycup", 220, 220, 0, 15) { Alchemy = new(-10, -7, 7, -5, 10) });

                
                itemsToAdd.Add(new Item("Deathcap spore", "A deathcap spore - plant in a mushroom patch. (20)", "seedDeathcap", Color.AntiqueWhite, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomDeathcap",
                    UseInt = 20 /* Level */, UseInt2 = 60 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Deathcap", "A black mushroom.", "mushroomDeathcap", 70, 70, 70, 25) { Alchemy = new(-7, -4, -10, -7, 20) });


                itemsToAdd.Add(new Item("Coniform tuft spore", "A coniform tuft spore - plant in a mushroom patch. (30)", "seedConiformTuft", Color.AntiqueWhite, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomConiformTuft",
                    UseInt = 30 /* Level */, UseInt2 = 80 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Coniform tuft", "An orange mushroom.", "mushroomConiformTuft", 255, 165, 0, 50) { Alchemy = new(2, 10, 6, -9, 30) });


                itemsToAdd.Add(new Item("Ostler mushroom spore", "An ostler mushroom spore - plant in a mushroom patch. (40)", "seedOstlerMushroom", Color.AntiqueWhite, 300, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomOstler",
                    UseInt = 40 /* Level */, UseInt2 = 100 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Ostler mushroom", "An off-white mushroom.", "mushroomOstler", 250, 235, 215, 150) { Alchemy = new(7, -9, -4, -6, 40) });


                itemsToAdd.Add(new Item("Miltcup spore", "A miltcup spore - plant in a mushroom patch. (50)", "seedMiltcup", Color.AntiqueWhite, 500, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomMiltcup",
                    UseInt = 50 /* Level */, UseInt2 = 120 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Miltcup", "An off-white mushroom.", "mushroomMiltcup", 196, 164, 132, 250) { Alchemy = new(-1, -13, 3, 8, 50) });


                itemsToAdd.Add(new Item("Bluet spore", "A bluet spore - plant in a mushroom patch. (60)", "seedBluet", Color.AntiqueWhite, 1000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomBluet",
                    UseInt = 60 /* Level */, UseInt2 = 140 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Bluet", "A pale blue mushroom.", "mushroomBluet", 135, 206, 235, 500) { Alchemy = new(8, 7, 5, -4, 60) });


                itemsToAdd.Add(new Item("Champerelle spore", "A champerelle spore - plant in a mushroom patch. (70)", "seedChamperelle", Color.AntiqueWhite, 3000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomChamperelle",
                    UseInt = 70 /* Level */, UseInt2 = 160 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Champerelle", "A brown mushroom.", "mushroomChamperelle", 101, 67, 33, 1500) { Alchemy = new(-6, -5, 7, -5, 70) });


                itemsToAdd.Add(new Item("Inktern spore", "An inktern spore - plant in a mushroom patch. (80)", "seedInktern", Color.AntiqueWhite, 5000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomInktern",
                    UseInt = 80 /* Level */, UseInt2 = 180 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Inktern", "A green mushroom.", "mushroomInktern", 50, 205, 50, 2500) { Alchemy = new(5, -7, -6, -4, 80) });


                itemsToAdd.Add(new Item("Wood eye spore", "A wood eye spore - plant in a mushroom patch. (90)", "seedWoodEye", Color.AntiqueWhite, 10000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomWoodEye",
                    UseInt = 90 /* Level */, UseInt2 = 200 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Wood eye", "A pink mushroom.", "mushroomWoodEye", 255, 209, 220, 5000) { Alchemy = new(7, 3, -5, -6, 90) });


                itemsToAdd.Add(new Item("Punkbull spore", "A punkbull spore - plant in a mushroom patch. (100)", "seedPunkbull", Color.AntiqueWhite, 30000, true) {
                    UseString = "PlantSeed", UseString2 = "Mushroom", UseString3 = "mushroomPunkbull",
                    UseInt = 100 /* Level */, UseInt2 = 300 /* Exp on Harvest */, UseInt3 = 1200 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Punkbull", "A red mushroom.", "mushroomPunkbull", 255, 209, 220, 15000) { Alchemy = new(-5, 1, -6, 8, 100) });
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
