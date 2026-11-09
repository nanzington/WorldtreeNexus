using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;
using static SadConsole.UI.Controls.Table.Cell;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsFarming {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
             
            // Generally speaking exp = 10 per 600s to grow, multiplied by tier.
            // Seed cost = 1/3/5 progression by tier starting at 10 for level 1. Output cost half of seed cost

            // // Farming - Allotments
            {
                // Potato
                itemsToAdd.Add(new Item("Potato seed", "Aren't potatoes potato seeds? Plant in an allotment. (1)", "seedPotato", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "potato",
                    UseInt = 1 /* Level */, UseInt2 = 40 /* Exp on Harvest */, UseInt3 = 2400 /* Growth time in seconds */

                });
                itemsToAdd.Add(new Item("Potato", "A tuber most versatile.", "potato", Color.SaddleBrown, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(3, 6, -14, -7, 1)  });

                // Onion
                itemsToAdd.Add(new Item("Onion seed", "An onion seed - plant in an allotment. (1)", "seedOnion", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "onion",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Onion", "A strong smelling onion.", "onion", Color.Beige, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(6, 9, -6, 9, 1)  });

                // Cabbage
                itemsToAdd.Add(new Item("Cabbage seed", "A cabbage seed - plant in an allotment. (1)", "seedCabbage", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cabbage",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cabbage", "Yuck, I don't like cabbage.", "cabbage", Color.Lime, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(11, -6, -9, -4, 1)  });

                // Tomato
                itemsToAdd.Add(new Item("Tomato seed", "A tomato seed - plant in an allotment. (1)", "seedTomato", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "tomato",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Tomato", "This would make good ketchup.", "tomato", Color.Crimson, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(-8, -6, -5, 11, 1)  });

                // Sweetcorn
                itemsToAdd.Add(new Item("Sweetcorn seed", "A sweetcorn seed - plant in an allotment. (1)", "seedSweetcorn", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "sweetcorn",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sweetcorn", "Raw sweetcorn.", "sweetcorn", Color.Yellow, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(-9, -9, -6, -6, 1)  });
                
                // Lettuce
                itemsToAdd.Add(new Item("Lettuce seed", "A lettuce seed - plant in an allotment. (1)", "seedLettuce", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "lettuce",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Lettuce", "A head of lettuce. Alas, poor Yorick! I grew him.", "lettuce", Color.SpringGreen, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(-7, 12, 4, 7, 1)  });

                // Broccoli
                itemsToAdd.Add(new Item("Broccoli seed", "A broccoli seed - plant in an allotment. (1)", "seedBroccoli", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "broccoli",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Broccoli", "A crown of broccoli.", "broccoli", Color.ForestGreen, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(6, 11, 8, -5, 1)  });

                // Cauliflower
                itemsToAdd.Add(new Item("Cauliflower seed", "A cauliflower seed - plant in an allotment. (1)", "seedCauliflower", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cauliflower",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cauliflower", "A crown of cauliflower.", "cauliflower", Color.AntiqueWhite, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(7, -9, 8, 6, 1)  });

                // Bellpepper
                itemsToAdd.Add(new Item("Bellpepper seed", "A bellpepper seed - plant in an allotment. (1)", "seedBellpepper", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "bellpepper",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Bellpepper", "A nice yellow bellpepper.", "bellpepper", Color.Yellow, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(-11, -4, 7, -8, 1)  });

                // Carrot
                itemsToAdd.Add(new Item("Carrot seed", "A carrot seed - plant in an allotment. (1)", "seedCarrot", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "carrot",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Carrot", "A vibrant orange carrot.", "carrot", Color.Orange, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(7, 7, -6, 10, 1)  });

                // Cucumber
                itemsToAdd.Add(new Item("Cucumber seed", "A cucumber seed - plant in an allotment. (1)", "seedCucumber", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "cucumber",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Cucumber", "A cucumber. Good in salads.", "cucumber", Color.DarkGreen, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(4, -9, -10, 7, 1)  });

                // Sweetpeas
                itemsToAdd.Add(new Item("Sweetpeas seed", "A sweetpeas seed - plant in an allotment. (1)", "seedSweetpeas", Color.DimGray, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "sweetpeas",
                    UseInt = 1 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 2400 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sweetpeas", "Some fresh peas still in their pods.", "sweetpeas", Color.LawnGreen, 5) { SpoilTimer = 1008, UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ], Alchemy = new(6, 12, 3, 9, 1)  });

            }


            // // Farming - Fabrics, but also grown in Allotments
            {
                // Xiangdao
                itemsToAdd.Add(new Item("Xiangdao seed", "A xiangdao fiber seed - plant in an allotment. (1)", "seedXiangdao", Color.Goldenrod, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberXiangdao",
                    UseInt = 1 /* Level */,  UseInt2 = 30 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Xiangdao fibers", "Some raw xiangdao fibers. Spun into cloth with Crafting. (1)", "fiberXiangdao", ColorLib.Chinese, 5) { Alchemy = new(-6, 9, -6, 9, 1) });
            
                // Veneficus
                itemsToAdd.Add(new Item("Veneficus seed", "A veneficus fiber seed - plant in an allotment. (10)", "seedVeneficus", Color.Goldenrod, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberVeneficus",
                    UseInt = 10 /* Level */,  UseInt2 = 60 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Veneficus fibers", "Some raw veneficus fibers. Spun into cloth with Crafting. (10)", "fiberVeneficus", ColorLib.Roman, 15) { Alchemy = new(-8, -3, -11, 7, 10) });
            
                // Zauberer
                itemsToAdd.Add(new Item("Zauberer seed", "A zauberer fiber seed - plant in an allotment. (20)", "seedZauberer", Color.Goldenrod, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberZauberer",
                    UseInt = 20 /* Level */,  UseInt2 = 90 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Zauberer fibers", "Some raw zauberer fibers. Spun into cloth with Crafting. (20)", "fiberZauberer", ColorLib.German, 25) { Alchemy = new(-8, -7, -5, 8, 20) });
            
                // Volshebnik
                itemsToAdd.Add(new Item("Volshebnik seed", "A volshebnik fiber seed - plant in an allotment. (30)", "seedVolshebnik", Color.Goldenrod, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberVolshebnik",
                    UseInt = 30 /* Level */,  UseInt2 = 120 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Volshebnik fibers", "Some raw volshebnik fibers. Spun into cloth with Crafting. (30)", "fiberVolshebnik", ColorLib.Russian, 50) { Alchemy = new(-3, -3, -4, -17, 30) });
            
                // Draiodoir
                itemsToAdd.Add(new Item("Draiodoir seed", "A draiodoir fiber seed - plant in an allotment. (40)", "seedDraiodoir", Color.Goldenrod, 300, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberDraiodoir",
                    UseInt = 40 /* Level */,  UseInt2 = 150 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Draiodoir fibers", "Some raw draiodoir fibers. Spun into cloth with Crafting. (40)", "fiberDraiodoir", ColorLib.Irish, 150) { Alchemy = new(-7, 6, -9, -4, 40) });
            
                // Sahir
                itemsToAdd.Add(new Item("Sahir seed", "A sahir fiber seed - plant in an allotment. (50)", "seedSahir", Color.Goldenrod, 500, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberSahir",
                    UseInt = 50 /* Level */,  UseInt2 = 180 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sahir fibers", "Some raw sahir fibers. Spun into cloth with Crafting. (50)", "fiberSahir", ColorLib.Arabian, 250) { Alchemy = new(-8, 6, 8, 3, 50) });
            
                // Bruxa
                itemsToAdd.Add(new Item("Bruxa seed", "A bruxa fiber seed - plant in an allotment. (60)", "seedBruxa", Color.Goldenrod, 1000, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberBruxa",
                    UseInt = 60 /* Level */,  UseInt2 = 210 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Bruxa fibers", "Some raw bruxa fibers. Spun into cloth with Crafting. (60)", "fiberBruxa", ColorLib.Portuguese, 500) { Alchemy = new(7, -6, 6, -5, 60) });
            
                // Kilokilo
                itemsToAdd.Add(new Item("Kilokilo seed", "A kilokilo fiber seed - plant in an allotment. (70)", "seedKilokilo", Color.Goldenrod, 3000, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberKilokilo",
                    UseInt = 70 /* Level */,  UseInt2 = 240 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Kilokilo fibers", "Some raw kilokilo fibers. Spun into cloth with Crafting. (70)", "fiberKilokilo", Color.Yellow, 1500) { Alchemy = new(4, -8, -6, -5, 70) });
            
                // Kalon
                itemsToAdd.Add(new Item("Kalon seed", "A kalon fiber seed - plant in an allotment. (80)", "seedKalon", Color.Goldenrod, 5000, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberKalon",
                    UseInt = 80 /* Level */,  UseInt2 = 270 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Kalon fibers", "Some raw kalon fibers. Spun into cloth with Crafting. (80)", "fiberKalon", Color.White, 2500) { Alchemy = new(-7, -2, -9, -4, 80) });
            
                // Ilbechin
                itemsToAdd.Add(new Item("Ilbechin seed", "A ilbechin fiber seed - plant in an allotment. (90)", "seedIlbechin", Color.Goldenrod, 10000, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberIlbechin",
                    UseInt = 90 /* Level */,  UseInt2 = 300 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Ilbechin fibers", "Some raw ilbechin fibers. Spun into cloth with Crafting. (90)", "fiberIlbechin", Color.Orange, 5000) { Alchemy = new(6, -5, 3, -7, 90) });
            
                // Taikuri
                itemsToAdd.Add(new Item("Taikuri seed", "A taikuri fiber seed - plant in an allotment. (100)", "seedTaikuri", Color.Goldenrod, 30000, true) {
                    UseString = "PlantSeed", UseString2 = "Allotment", UseString3 = "fiberTaikuri",
                    UseInt = 100 /* Level */,  UseInt2 = 330 /* Exp On Harvest */, UseInt3 = 1800 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Taikuri fibers", "Some raw taikuri fibers. Spun into cloth with Crafting. (100)", "fiberTaikuri", Color.SaddleBrown, 15000) { Alchemy = new(-6, -4, 4, 6, 100) });
            
            }
            
            
            // // Farming - Flowers
            {
                // Sunflower
                itemsToAdd.Add(new Item("Sunflower seed", "A sunflower seed - plant in a flower patch. (1)", "seedSunflower", Color.Beige, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "sunflower",
                    UseInt = 1 /* Level */,  UseInt2 = 10 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Sunflower", "A beautiful sunflower.", "sunflower", Color.Yellow, 5) { Alchemy = new(-6, -7, -8, -9, 1) });
                
                // Tulip
                itemsToAdd.Add(new Item("Tulip seed", "A tulip seed - plant in a flower patch. (10)", "seedTulip", Color.Beige, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "tulip",
                    UseInt = 10 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Tulip", "A beautiful tulip.", "tulip", ColorLib.PastelPink, 15) { Alchemy = new(-11, -4, 7, -7, 10) });
                
                // Orchid
                itemsToAdd.Add(new Item("Orchid seed", "An orchid seed - plant in a flower patch. (20)", "seedOrchid", Color.Beige, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "orchid",
                    UseInt = 20 /* Level */,  UseInt2 = 30 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Orchid", "A beautiful orchid.", "orchid", ColorLib.Roman, 25) { Alchemy = new(-7, 6, 5, -10, 20) });
                
                // Chrysanthemum
                itemsToAdd.Add(new Item("Chrysanthemum seed", "A chrysanthemum seed - plant in a flower patch. (30)", "seedChrysanthemum", Color.Beige, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "chrysanthemum",
                    UseInt = 30 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Chrysanthemum", "A beautiful chrysanthemum.", "chrysanthemum", Color.Orange, 50) { Alchemy = new(-5, 11, -6, 5, 30) });
                
                // Carnation
                itemsToAdd.Add(new Item("Carnation seed", "A carnation seed - plant in a flower patch. (40)", "seedCarnation", Color.Beige, 300, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "carnation",
                    UseInt = 40 /* Level */,  UseInt2 = 50 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Carnation", "A beautiful carnation.", "carnation", Color.Crimson, 150) { Alchemy = new(9, 5, 7, -5, 40) });
                
                // Hydrangea
                itemsToAdd.Add(new Item("Hydrangea seed", "A hydrangea seed - plant in a flower patch. (50)", "seedHydrangea", Color.Beige, 500, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "hydrangea",
                    UseInt = 50 /* Level */,  UseInt2 = 60 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Hydrangea", "A beautiful hydrangea.", "hydrangea", Color.Lavender, 250) { Alchemy = new(6, -4, -10, -5, 50) });
                
                // Peony
                itemsToAdd.Add(new Item("Peony seed", "A peony seed - plant in a flower patch. (60)", "seedPeony", Color.Beige, 1000, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "peony",
                    UseInt = 60 /* Level */,  UseInt2 = 70 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Peony", "A beautiful peony.", "peony", Color.White, 500) { Alchemy = new(3, -7, 8, 6, 60) });
                
                // Daisy
                itemsToAdd.Add(new Item("Daisy seed", "A daisy seed - plant in a flower patch. (70)", "seedDaisy", Color.Beige, 3000, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "daisy",
                    UseInt = 70 /* Level */,  UseInt2 = 80 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Daisy", "A beautiful daisy.", "daisy", Color.Turquoise, 1500) { Alchemy = new(-10, 5, -4, 4, 70) });
                
                // Lily
                itemsToAdd.Add(new Item("Lily seed", "A lily seed - plant in a flower patch. (80)", "seedLily", Color.Beige, 5000, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "lily",
                    UseInt = 80 /* Level */,  UseInt2 = 90 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Lily", "A beautiful lily.", "lily", Color.LightYellow, 2500) { Alchemy = new(-5, -8, 3, -6, 80) });
                
                // Violet
                itemsToAdd.Add(new Item("Violet seed", "A violet seed - plant in a flower patch. (90)", "seedViolet", Color.Beige, 10000, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "violet",
                    UseInt = 90 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Violet", "A beautiful violet.", "violet", Color.MediumPurple, 5000) { Alchemy = new(-8, -5, 5, -3, 90) });
                
                // Rose
                itemsToAdd.Add(new Item("Rose seed", "A rose seed - plant in a flower patch. (100)", "seedRose", Color.Beige, 30000, true) {
                    UseString = "PlantSeed", UseString2 = "Flower", UseString3 = "rose",
                    UseInt = 100 /* Level */,  UseInt2 = 110 /* Exp On Harvest */, UseInt3 = 600 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Rose", "A beautiful rose.", "rose", Color.Red, 15000) { Alchemy = new(6, -4, 3, 7, 100) });
                
            }

            
            // // Farming - Bush
            {
                // Strawberry
                itemsToAdd.Add(new Item("Strawberry seed", "A strawberry bush seed - plant in a bush patch. (1)", "seedStrawberry", Color.SaddleBrown, 10, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "strawberry",
                    UseInt = 1 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */ 

                });
                itemsToAdd.Add(new Item("Strawberry", "A freshly picked strawberry.", "strawberry", Color.Crimson, 1) { SpoilTimer = 1008, Alchemy = new(8, 8, 5, 9, 1), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] });

                // Nightshade
                itemsToAdd.Add(new Item("Nightshade seed", "A nightshade bush seed - plant in a bush patch. (10)", "seedNightshade", Color.SaddleBrown, 30, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "nightshade",
                    UseInt = 10 /* Level */,  UseInt2 = 200 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Nightshade berries", "Deadly red berries.", "nightshade", Color.Red, 3) { SpoilTimer = 1008, Alchemy = new(8, -9, -10, 2, 10), UseString = "Potion", Potion = [ new("Hurt", 1), new("Hunger", 5) ] }); 

                // Blueberry
                itemsToAdd.Add(new Item("Blueberry seed", "A blueberry bush seed - plant in a bush patch. (20)", "seedBlueberry", Color.SaddleBrown, 50, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "blueberry",
                    UseInt = 20 /* Level */,  UseInt2 = 300 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Blueberry", "Blueberries, kinda hit or miss.", "blueberry", Color.DodgerBlue, 5) { SpoilTimer = 1008, Alchemy = new(4, 12, -5, -7, 20), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Raspberry
                itemsToAdd.Add(new Item("Raspberry seed", "A raspberry bush seed - plant in a bush patch. (30)", "seedRaspberry", Color.SaddleBrown, 100, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "raspberry",
                    UseInt = 30 /* Level */,  UseInt2 = 400 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Raspberry", "Raspberries, kinda hit or miss.", "raspberry", Color.Salmon, 10) { SpoilTimer = 1008, Alchemy = new(-10, -6, -5, -6, 30), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Blackcurrant
                itemsToAdd.Add(new Item("Blackcurrant seed", "A blackcurrant bush seed - plant in a bush patch. (40)", "seedBlackcurrant", Color.SaddleBrown, 300, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "blackcurrant",
                    UseInt = 40 /* Level */,  UseInt2 = 500 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Blackcurrant", "Tasty blackcurrant. Bold and self-sufficient.", "blackcurrant", Color.Purple, 30) { SpoilTimer = 1008, Alchemy = new(-5, -8, 7, 6, 40), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Gooseberry
                itemsToAdd.Add(new Item("Gooseberry seed", "A gooseberry bush seed - plant in a bush patch. (50)", "seedGooseberry", Color.SaddleBrown, 500, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "gooseberry",
                    UseInt = 50 /* Level */,  UseInt2 = 600 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Gooseberry", "Like little beads of glass. A bit tastier than glass, though.", "gooseberry", Color.Orange, 50) { SpoilTimer = 1008, Alchemy = new(-7, -5, 9, 4, 50), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Haskap
                itemsToAdd.Add(new Item("Haskap seed", "A haskap bush seed - plant in a bush patch. (60)", "seedHaskap", Color.SaddleBrown, 1000, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "haskap",
                    UseInt = 60 /* Level */,  UseInt2 = 700 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Haskap", "Sometimes also called honeyberries or fly honeysuckle. Sweet but tart.", "haskap", Color.BlueViolet, 100) { SpoilTimer = 1008, Alchemy = new(8, 3, 6, -7, 60), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Grapevine
                itemsToAdd.Add(new Item("Grapevine seed", "A grapevine seed - plant in a bush patch. (70)", "seedGrapevine", Color.SaddleBrown, 3000, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "grapes",
                    UseInt = 70 /* Level */,  UseInt2 = 800 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Grapes", "Could probably be turned into wine.", "grapes", Color.Lime, 300) { SpoilTimer = 1008, Alchemy = new(6, 5, 5, -7, 70), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Fig
                itemsToAdd.Add(new Item("Fig seed", "A fig bush seed - plant in a bush patch. (80)", "seedFig", Color.SaddleBrown, 5000, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "fig",
                    UseInt = 80 /* Level */,  UseInt2 = 900 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Fig", "Does not contain pork.", "fig", Color.MediumPurple, 500) { SpoilTimer = 1008, Alchemy = new(-9, 5, 3, 5, 80), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Aronia
                itemsToAdd.Add(new Item("Aronia seed", "An aronia bush seed - plant in a bush patch. (90)", "seedAronia", Color.SaddleBrown, 10000, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "aronia",
                    UseInt = 90 /* Level */,  UseInt2 = 1000 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Aronia", "Also called chokeberries, quite astringent.", "aronia", Color.DimGray, 1000) { SpoilTimer = 1008, Alchemy = new(-5, -6, 4, -6, 90), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

               // Elderberry
                itemsToAdd.Add(new Item("Elderberry seed", "A elderberry bush seed - plant in a bush patch. (100)", "seedElderberry", Color.SaddleBrown, 30000, true) {
                    UseString = "PlantSeed", UseString2 = "Bush", UseString3 = "elderberry",
                    UseInt = 100 /* Level */,  UseInt2 = 1100 /* Exp On Harvest */, UseInt3 = 6000 /* Growth time in seconds */, UseInt4 = 1200 /* Regrowth time in seconds */
                });
                itemsToAdd.Add(new Item("Elderberry", "Smells just like dad.", "elderberry", Color.IndianRed, 3000) { SpoilTimer = 1008, Alchemy = new(-5, 5, 4, -6, 100), UseString = "Potion", Potion = [ new("Heal", 1), new("Hunger", 5) ] }); 

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
                foreach (var wood in Materials.Woods) {
                    itemsToAdd.Add(new Item(wood.Name + " seed", "A " + wood.Name.ToLower() + " seed - use on a plant pot to make a sapling. (" + wood.Level + ")", "seed" + wood.Name, Color.BurlyWood, wood.CostMultiplier * 2, true));
                    itemsToAdd.Add(new Item("Plant pot (" + wood.Name.ToLower() + ")", "A " + wood.Name.ToLower() + " sapling in a pot. Plant in a tree patch. (" + wood.Level + ")", "plantPot" + wood.Name, wood.R, wood.G, wood.B, wood.CostMultiplier * 2) {
                        UseString = "PlantSeed", UseString2 = "Tree", UseString3 = "log" + wood.Name,
                        UseInt = wood.Level /* Level */,  UseInt2 = 15 * (int) wood.Tier /* Exp On Harvest */, UseInt3 = 900 /* Growth time in seconds */, UseInt4 = 900 /* Regrowth time in seconds */
                    });
                }
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
