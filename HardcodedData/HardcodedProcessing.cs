using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedProcessing {
        public static void InitProcessors(Dictionary<string, ProcessingStation> Stations) {
            List<ProcessingStation> toAdd = new();

            ProcessingStation Furnace = new("Furnace") {
                Recipes = new() {
                    new ProcessingRecipe("swordTybalt", "swordBrittle") { Actions = [ new("Quest", "MI_RomeoJuliet", "", 100), new("CustomLog", "I've ruined Tybalt's sword, and should return it to the sword shop for him to pick up.", "", 3) ] },
                    new ProcessingRecipe("bucketSand", "glassMolten", "Crafting", 1, 20, secondaryIn: "ashSoda", secondaryOut: "bucketEmpty"), 
                    new ProcessingRecipe("oreCopper", "barCopper", "Smithing", 1, 10),  
                    new ProcessingRecipe("oreMixBronze", "barBronze", "Smithing", 10, 20),
                    new ProcessingRecipe("oreIron", "barIron", "Smithing", 20, 30),
                    new ProcessingRecipe("oreSilver", "barSilver", "Smithing", 30, 40),
                    new ProcessingRecipe("oreGold", "barGold", "Smithing", 40, 50),
                    new ProcessingRecipe("orePlatinum", "barPlatinum", "Smithing", 50, 60),
                    new ProcessingRecipe("oreMixSteel", "barSteel", "Smithing", 60, 70),
                    new ProcessingRecipe("oreCobalt", "barCobalt", "Smithing", 70, 80),
                    new ProcessingRecipe("oreTungsten", "barTungsten", "Smithing", 80, 90),
                    new ProcessingRecipe("oreTitanium", "barTitanium", "Smithing", 90, 100) // yes yes there's no such thing as titanium ore and it should be rutile or ilmenite but that may confuse players
                }
            }; 
            toAdd.Add(Furnace);

            // Creates the copies for the POH workshop
            List<string> MetalNames = ["Copper", "Bronze", "Iron", "Silver", "Gold", "Platinum", "Steel", "Cobalt", "Tungsten", "Titanium" ];
            for (int i = 0; i < 10; i++) {
                int adjLevel = i;
                if (adjLevel == 0) { adjLevel = 1; }
                else { adjLevel *= 10; }

                ProcessingStation furnaceCopy = Furnace.Clone();
                furnaceCopy.Name = MetalNames[i] + " Furnace"; furnaceCopy.DontIncludeInCounts = true; furnaceCopy.MaxLevel = adjLevel;
                toAdd.Add(furnaceCopy);
            } 

            toAdd.Add(new("Casting") { OpensUI = true });

            toAdd.Add(new("Dairy Churn") {
                Recipes = new() {
                    new ProcessingRecipe("bucketMilk", "cream", "Cooking", 21, 18, secondaryOut: "bucketEmpty"),
                    new ProcessingRecipe("cream", "butter", "Cooking", 38, 23),
                    new ProcessingRecipe("butter", "cheese", "Cooking", 48, 24)
                }
            });

            toAdd.Add(new("Sawmill") {
                Recipes = new() {
                    new ProcessingRecipe("logPoplar", "plankPoplar", "Construction", 1, secondaryIn: "Gold,20", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logElm", "plankElm", "Construction", 10, secondaryIn: "Gold,40", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logWalnut", "plankWalnut", "Construction", 20, secondaryIn: "Gold,80", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logHolly", "plankHolly", "Construction", 30, secondaryIn: "Gold,120", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logAcacia", "plankAcacia", "Construction", 40, secondaryIn: "Gold,160", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logBirch", "plankBirch", "Construction", 50, secondaryIn: "Gold,200", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logHickory", "plankHickory", "Construction", 60, secondaryIn: "Gold,240", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logBloodwood", "plankBloodwood", "Construction", 70, secondaryIn: "Gold,480", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logCamatillo", "plankCamatillo", "Construction", 80, secondaryIn: "Gold,720", outQty: 4, noteOut: true),
                    new ProcessingRecipe("logKatalox", "plankKatalox", "Construction", 90, secondaryIn: "Gold,960", outQty: 4, noteOut: true)
                }
            });

            toAdd.Add(new("Tannery") {
                Recipes = new() {
                    new ProcessingRecipe("cowhide", "leatherSoft", "Crafting", 1, 5),
                    new ProcessingRecipe("leatherSoft", "leatherHard", "Crafting", 10, 5)
                }
            });

            toAdd.Add(new("Anvil") { OpensUI = true });  
            toAdd.Add(new("Copper Anvil", true, true, 1, "Anvil"));
            toAdd.Add(new("Bronze Anvil", true, true, 10, "Anvil"));
            toAdd.Add(new("Iron Anvil", true, true, 20, "Anvil"));
            toAdd.Add(new("Silver Anvil", true, true, 30, "Anvil"));
            toAdd.Add(new("Gold Anvil", true, true, 40, "Anvil"));
            toAdd.Add(new("Platinum Anvil", true, true, 50, "Anvil"));
            toAdd.Add(new("Steel Anvil", true, true, 60, "Anvil"));
            toAdd.Add(new("Cobalt Anvil", true, true, 70, "Anvil"));
            toAdd.Add(new("Tungsten Anvil", true, true, 80, "Anvil"));
            toAdd.Add(new("Titanium Anvil", true, true, 90, "Anvil"));


            toAdd.Add(new("Trade Hall") { OpensUI = true });
            toAdd.Add(new("Trade Hall Collection") { OpensUI = true });

            ProcessingStation Range = new("Range") {
                Recipes = new() {
                    new ProcessingRecipe("seaweed", "ashSoda"),
                    new ProcessingRecipe("weedSwamp", "ashSoda"),
                    new ProcessingRecipe("potChipsPoplar", "pulpPoplar", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsElm", "pulpElm", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsWalnut", "pulpWalnut", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsHolly", "pulpHolly", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsAcacia", "pulpAcacia", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsBirch", "pulpBirch", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsHickory", "pulpHickory", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsBloodwood", "pulpBloodwood", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsCamatillo", "pulpCamatillo", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("potChipsKatalox", "pulpKatalox", secondaryOut: "potEmpty", outQty: 5),
                    new ProcessingRecipe("meatRawCuy", "meatCooked", "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new ProcessingRecipe("meatRawBeef", "meatCooked", "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new ProcessingRecipe("meatRawRat", "meatCooked", "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new ProcessingRecipe("meatRawBear", "meatCooked", "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new ProcessingRecipe("meatCooked", "burntMeat", "Cooking", 1, 3),
                    new ProcessingRecipe("burntMeat", "sinew", "Cooking", 1, 3),
                    new ProcessingRecipe("meatRawChicken", "meatCookedChicken", "Cooking", 1, 30, failOutput: "burntFood", failStop: 31),
                    new("kettleFull", "kettleHot")
                }
            };
             
            foreach (var fish in Materials.Fish) {
                Range.Recipes.Add(new("fishRaw" + fish.Name, "fishCooked" + fish.Name, "Cooking", fish.Level, fish.ExpMultiplier, failOutput: "burntMeat", failStop: fish.Level + 30));
            }

            ProcessingStation Fire = Range.Clone();
            Fire.Name = "Fire";
            Fire.DontIncludeInCounts = true;

            foreach (var rec in Fire.Recipes) {
                if (rec.StopFailingLevel > 0) {
                    rec.StopFailingLevel += 10;
                }
            }

            ProcessingStation holyBasin = new("Holy Fountain") { Recipes = new() };
            ProcessingStation funeraryPyre = new("Funerary Pyre") { Recipes = new() };

            foreach (var bone in Materials.Bones) {
                holyBasin.Recipes.Add(new ProcessingRecipe(bone.SimpleName, bone.SimpleName + "Cleansed"));

                foreach (var oil in Materials.Oils) {
                    double boost = 0.2 * oil.Tier;
                    int exp = (int) Math.Clamp(Math.Floor(bone.ExpMultiplier * boost), bone.ExpMultiplier + oil.Tier, int.MaxValue);
                    int pyreExp = (int) Math.Clamp(Math.Floor(exp * 1.5), exp + 1, int.MaxValue);
                    Fire.Recipes.Add(new ProcessingRecipe(bone.SimpleName + oil.Name, "_PrayerExp", "Prayer", oil.Level, exp) { 
                        Actions = [ new("CustomLog", "You offer the bones to the gods at your fire. They are pleased, and you receive " + exp + " Prayer experience for your devotion.", "", 4) ]
                    });

                    funeraryPyre.Recipes.Add(new ProcessingRecipe(bone.SimpleName + oil.Name, "_PrayerExpPyre", "Prayer", oil.Level, pyreExp) { 
                        Actions = [ new("CustomLog", "You offer the bones to the gods at the pyre. They are very pleased, and you receive " + pyreExp + " Prayer experience for your devotion.", "", 4) ]
                    });
                }
            }
            toAdd.Add(holyBasin);
            toAdd.Add(funeraryPyre);

            toAdd.Add(Range);
            toAdd.Add(Fire);

            toAdd.Add(new("Pottery Wheel") { OpensUI = true });

            toAdd.Add(new("Pottery Kiln") {
                Recipes = new() {
                    new ProcessingRecipe("unfiredPot", "potEmpty", "Crafting", 1, 7),
                    new ProcessingRecipe("unfiredCup", "cupEmpty", "Crafting", 3, 9),
                    new ProcessingRecipe("unfiredPieDish", "pieEmpty", "Crafting", 7, 15),
                    new ProcessingRecipe("unfiredBowl", "bowlEmpty", "Crafting", 8, 18),
                    new ProcessingRecipe("unfiredPlantPot", "plantPotEmpty", "Crafting", 19, 20),
                    new ProcessingRecipe("unfiredPotLid", "potLid", "Crafting", 20, 30)
                }
            });

            ProcessingStation sink = new("Sink") {
                Recipes = new() {
                    new ProcessingRecipe("bucketEmpty", "bucketWater"), 
                    new ProcessingRecipe("potEmpty", "potWater"), 
                    new ProcessingRecipe("clayDust", "claySoft"), 
                    new ProcessingRecipe("vialEmpty", "vialWater"), 
                    new ProcessingRecipe("bowlEmpty", "bowlWater"), 
                    new ProcessingRecipe("jugEmpty", "jugWater"), 
                    new ProcessingRecipe("potFlour", "doughBread", secondaryOut: "potEmpty"),
                    new ("kettleEmpty", "kettleFull")
                }
            };

            ProcessingStation fountain = Helper.Clone(sink);
            fountain.Name = "Fountain";
            fountain.DontIncludeInCounts = true;

            toAdd.Add(sink);
            toAdd.Add(fountain);

            toAdd.Add(new("Sand") { Recipes = new() { new ProcessingRecipe("bucketEmpty", "bucketSand") } });


            toAdd.Add(new("Spinning Wheel") {
                Recipes = new() {
                    new ProcessingRecipe("flax", "bowstring", "Crafting", 1, 5),
                    new ProcessingRecipe("sinew", "crossbowString", "Crafting", 1, 5),
                    new ProcessingRecipe("woolRaw", "woolBall", "Crafting", 1, 3),
                    new ProcessingRecipe("woolBall,4", "clothBolt", "Crafting", 1, 10)
                }
            });

            toAdd.Add(new("Windmill") {
                Recipes = new() {
                    new ProcessingRecipe("grain", "potFlour", secondaryIn: "potEmpty")
                }
            });

            
            List<string> Inks = ["Novice", "Beginner", "Apprentice", "Adept", "Journeyman", "Expert", "Artisan", "Master", "Grandmaster", "Paragon", "Divine" ];
            List<string> Imbuements = ["Metal", "Water", "Wood", "Fire", "Earth", "Destruction", "Restoration", "Alteration", "Mysticism", "Conjuration", "Illusion" ]; 
            
            toAdd.Add(new("Magic Altar") {
                Recipes = new() {
                    new ProcessingRecipe("inkNovice", "inkNoviceImbued"),
                    new ProcessingRecipe("inkBeginner", "inkBeginnerImbued"),
                    new ProcessingRecipe("inkApprentice", "inkApprenticeImbued"),
                    new ProcessingRecipe("inkAdept", "inkAdeptImbued"),
                    new ProcessingRecipe("inkJourneyman", "inkJourneymanImbued"),
                    new ProcessingRecipe("inkExpert", "inkExpertImbued"),
                    new ProcessingRecipe("inkArtisan", "inkArtisanImbued"),
                    new ProcessingRecipe("inkMaster", "inkMasterImbued"),
                    new ProcessingRecipe("inkGrandmaster", "inkGrandmasterImbued"),
                    new ProcessingRecipe("inkParagon", "inkParagonImbued"),
                    new ProcessingRecipe("inkDivine", "inkDivineImbued")
                }
            });

            foreach (var imbue in Imbuements) {
                 toAdd.Add(new(imbue + " Altar", dont: true) {
                    Recipes = new() {
                        new ProcessingRecipe("inkNovice", "inkNovice" + imbue),
                        new ProcessingRecipe("inkBeginner", "inkBeginner" + imbue),
                        new ProcessingRecipe("inkApprentice", "inkApprentice" + imbue),
                        new ProcessingRecipe("inkAdept", "inkAdept" + imbue),
                        new ProcessingRecipe("inkJourneyman", "inkJourneyman" + imbue),
                        new ProcessingRecipe("inkExpert", "inkExpert" + imbue),
                        new ProcessingRecipe("inkArtisan", "inkArtisan" + imbue),
                        new ProcessingRecipe("inkMaster", "inkMaster" + imbue),
                        new ProcessingRecipe("inkGrandmaster", "inkGrandmaster" + imbue),
                        new ProcessingRecipe("inkParagon", "inkParagon" + imbue),
                        new ProcessingRecipe("inkDivine", "inkDivine" + imbue)
                    }
                });
            }

            toAdd.Add(new("Dairy Cow") { Recipes = new() { new ProcessingRecipe("bucketEmpty", "bucketMilk") } });

            toAdd.Add(new("Beer Keg") { Recipes = new() { new ProcessingRecipe("beerGlass", "beer") } });
            toAdd.Add(new("Cider Keg") { Recipes = new() { new ProcessingRecipe("beerGlass", "cider") } }); 

            for (int i = 0; i < toAdd.Count; i++) {
                Stations.Add(toAdd[i].Name, toAdd[i]);
            }
        }
    }
}
