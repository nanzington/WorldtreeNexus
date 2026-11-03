using SadConsole.Entities;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedProcessing {
        public static void InitProcessors(Dictionary<string, ProcessingStation> Stations) {
            List<ProcessingStation> toAdd = new();

            ProcessingStation Furnace = new("Furnace") {
                Recipes = new() {
                    new("swordTybalt",   "swordBrittle") { Actions = [ new("Quest", "MI_RomeoJuliet", "", 100), new("CustomLog", "I've ruined Tybalt's sword, and should return it to the sword shop for him to pick up.", "", 3) ] },
                    new("bucketSand",    "glassMolten",   "Crafting", 1, 20, secondaryIn: "ashSoda", secondaryOut: "bucketEmpty"), 
                    new("oreCopper",     "barCopper",     "Smithing",   1,  10),  
                    new("oreMixBronze",  "barBronze",     "Smithing",  10,  20),
                    new("oreIron",       "barIron",       "Smithing",  20,  30),
                    new("oreSilver",     "barSilver",     "Smithing",  30,  40),
                    new("oreGold",       "barGold",       "Smithing",  40,  50),
                    new("orePlatinum",   "barPlatinum",   "Smithing",  50,  60),
                    new("oreMixSteel",   "barSteel",      "Smithing",  60,  70),
                    new("oreCobalt",     "barCobalt",     "Smithing",  70,  80),
                    new("oreTungsten",   "barTungsten",   "Smithing",  80,  90),
                    new("oreTitanium",   "barTitanium",   "Smithing",  90, 100), // yes yes there's no such thing as titanium ore and it should be rutile or ilmenite but that may confuse players
                    new("oreYggdrasite", "barYggdrasite", "Smithing", 100, 150) 
                }
            }; 
            toAdd.Add(Furnace);

            // Creates the copies for the POH workshop
            List<string> MetalNames = ["Copper", "Bronze", "Iron", "Silver", "Gold", "Platinum", "Steel", "Cobalt", "Tungsten", "Titanium", "Yggdrasite" ];
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
                    new("bucketMilk", "cream",  "Cooking", 21, 18, secondaryOut: "bucketEmpty"),
                    new("cream",      "butter", "Cooking", 38, 23),
                    new("butter",     "cheese", "Cooking", 48, 24)
                }
            });

            ProcessingStation sawmill = new("Sawmill");
            ProcessingStation papermill = new("Papermill");

            toAdd.Add(new("Sawmill") {
                Recipes = new() {
                    new("logPoplar",    "plankPoplar",    "Construction",   1, secondaryIn: "Gold,20",    outQty: 4, noteOut: true),
                    new("logElm",       "plankElm",       "Construction",  10, secondaryIn: "Gold,60",    outQty: 4, noteOut: true),
                    new("logWalnut",    "plankWalnut",    "Construction",  20, secondaryIn: "Gold,100",   outQty: 4, noteOut: true),
                    new("logHolly",     "plankHolly",     "Construction",  30, secondaryIn: "Gold,200",   outQty: 4, noteOut: true),
                    new("logAcacia",    "plankAcacia",    "Construction",  40, secondaryIn: "Gold,600",   outQty: 4, noteOut: true),
                    new("logBirch",     "plankBirch",     "Construction",  50, secondaryIn: "Gold,1000",  outQty: 4, noteOut: true),
                    new("logHickory",   "plankHickory",   "Construction",  60, secondaryIn: "Gold,2000",  outQty: 4, noteOut: true),
                    new("logBloodwood", "plankBloodwood", "Construction",  70, secondaryIn: "Gold,6000",  outQty: 4, noteOut: true),
                    new("logCamatillo", "plankCamatillo", "Construction",  80, secondaryIn: "Gold,10000", outQty: 4, noteOut: true),
                    new("logKatalox",   "plankKatalox",   "Construction",  90, secondaryIn: "Gold,20000", outQty: 4, noteOut: true),
                    new("logWorldtree", "plankWorldtree", "Construction", 100, secondaryIn: "Gold,60000", outQty: 4, noteOut: true)
                }
            });

            toAdd.Add(new("Papermill") {
                Recipes = new() {
                    new("logPoplar",    "paperPoplar",    "Construction",   1, secondaryIn: "Gold,8",     outQty: 5, noteOut: true),
                    new("logElm",       "paperElm",       "Construction",  10, secondaryIn: "Gold,24",    outQty: 5, noteOut: true),
                    new("logWalnut",    "paperWalnut",    "Construction",  20, secondaryIn: "Gold,40",    outQty: 5, noteOut: true),
                    new("logHolly",     "paperHolly",     "Construction",  30, secondaryIn: "Gold,80",    outQty: 5, noteOut: true),
                    new("logAcacia",    "paperAcacia",    "Construction",  40, secondaryIn: "Gold,240",   outQty: 5, noteOut: true),
                    new("logBirch",     "paperBirch",     "Construction",  50, secondaryIn: "Gold,400",   outQty: 5, noteOut: true),
                    new("logHickory",   "paperHickory",   "Construction",  60, secondaryIn: "Gold,800",   outQty: 5, noteOut: true),
                    new("logBloodwood", "paperBloodwood", "Construction",  70, secondaryIn: "Gold,2400",  outQty: 5, noteOut: true),
                    new("logCamatillo", "paperCamatillo", "Construction",  80, secondaryIn: "Gold,4000",  outQty: 5, noteOut: true),
                    new("logKatalox",   "paperKatalox",   "Construction",  90, secondaryIn: "Gold,8000",  outQty: 5, noteOut: true),
                    new("logWorldtree", "paperWorldtree", "Construction", 100, secondaryIn: "Gold,24000", outQty: 5, noteOut: true)
                }
            });

            toAdd.Add(new("Tannery") {
                Recipes = new() {
                    new("cowhide",     "leatherSoft", "Crafting",  1, 5),
                    new("leatherSoft", "leatherHard", "Crafting", 10, 5)
                }
            });

            toAdd.Add(new("Anvil") { OpensUI = true });  
            toAdd.Add(new("Copper Anvil",     true, true,   1, "Anvil"));
            toAdd.Add(new("Bronze Anvil",     true, true,  10, "Anvil"));
            toAdd.Add(new("Iron Anvil",       true, true,  20, "Anvil"));
            toAdd.Add(new("Silver Anvil",     true, true,  30, "Anvil"));
            toAdd.Add(new("Gold Anvil",       true, true,  40, "Anvil"));
            toAdd.Add(new("Platinum Anvil",   true, true,  50, "Anvil"));
            toAdd.Add(new("Steel Anvil",      true, true,  60, "Anvil"));
            toAdd.Add(new("Cobalt Anvil",     true, true,  70, "Anvil"));
            toAdd.Add(new("Tungsten Anvil",   true, true,  80, "Anvil"));
            toAdd.Add(new("Titanium Anvil",   true, true,  90, "Anvil"));
            toAdd.Add(new("Yggdrasite Anvil", true, true, 100, "Anvil"));


            toAdd.Add(new("Trade Hall") { OpensUI = true });
            toAdd.Add(new("Trade Hall Collection") { OpensUI = true });

            toAdd.Add(new("Deep Fryer") {
                Recipes = new() {
                    new("batteredPollock", "fishSticks", "Cooking", 1, 40, failOutput: "burntFood", failStop: 31),
                    new("potatoSticksRaw", "potatoSticksFried", "Cooking", 1, 40, failOutput: "burntFood", failStop: 31),
                }
            });

            ProcessingStation Range = new("Range") {
                Recipes = new() {
                    new("seaweed",           "ashSoda"),
                    new("weedSwamp",         "ashSoda"),
                    new("potChipsPoplar",    "pulpPoplar",    secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsElm",       "pulpElm",       secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsWalnut",    "pulpWalnut",    secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsHolly",     "pulpHolly",     secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsAcacia",    "pulpAcacia",    secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsBirch",     "pulpBirch",     secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsHickory",   "pulpHickory",   secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsBloodwood", "pulpBloodwood", secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsCamatillo", "pulpCamatillo", secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsKatalox",   "pulpKatalox",   secondaryOut: "potEmpty", outQty: 5),
                    new("potChipsWorldtree", "pulpWorldtree", secondaryOut: "potEmpty", outQty: 5),
                    new("meatRawCuy",        "meatCooked",        "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new("meatRawBeef",       "meatCooked",        "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new("meatRawRat",        "meatCooked",        "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new("meatRawBear",       "meatCooked",        "Cooking", 1, 30, failOutput: "burntMeat", failStop: 31),
                    new("meatCooked",        "burntMeat",         "Cooking", 1, 3),
                    new("burntMeat",         "sinew",             "Cooking", 1, 3),
                    new("meatRawChicken",    "meatCookedChicken", "Cooking", 1, 30, failOutput: "burntFood", failStop: 31),
                    new("potato",            "potatoBaked",       "Cooking", 1, 30, failOutput: "burntFood", failStop: 31),
                    new("kettleFull",        "kettleHot")
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
                holyBasin.Recipes.Add(new(bone.SimpleName, bone.SimpleName + "Cleansed"));

                foreach (var oil in Materials.Oils) {
                    double boost = 0.2 * oil.Tier;
                    int exp = (int) Math.Clamp(Math.Floor(bone.ExpMultiplier * boost), bone.ExpMultiplier + oil.Tier, int.MaxValue);
                    int pyreExp = (int) Math.Clamp(Math.Floor(exp * 1.5), exp + 1, int.MaxValue);
                    Fire.Recipes.Add(new(bone.SimpleName + oil.Name, "_PrayerExp", "Prayer", oil.Level, exp) { 
                        Actions = [ new("CustomLog", "You offer the bones to the gods at your fire. They are pleased, and you receive " + exp + " Prayer experience for your devotion.", "", 4) ]
                    });

                    funeraryPyre.Recipes.Add(new(bone.SimpleName + oil.Name, "_PrayerExpPyre", "Prayer", oil.Level, pyreExp) { 
                        Actions = [ new("CustomLog", "You offer the bones to the gods at the pyre. They are very pleased, and you receive " + pyreExp + " Prayer experience for your devotion.", "", 4) ]
                    });
                }
            }
            toAdd.Add(holyBasin);
            toAdd.Add(funeraryPyre);

            toAdd.Add(Range);
            toAdd.Add(Fire);


            ProcessingStation altar = new("Altar") { Recipes = new() };
            foreach (var oil in Materials.Oils) { 
                altar.Recipes.Add(new("oil" + oil.Name + "Un", "oil" + oil.Name, "Prayer", oil.Level, (int) oil.Tier));
            }
            toAdd.Add(altar);


            toAdd.Add(new("Pottery Wheel") { OpensUI = true });

            toAdd.Add(new("Pottery Kiln") {
                Recipes = new() {
                    new("unfiredPot",      "potEmpty",      "Crafting",  1,  7),
                    new("unfiredCup",      "cupEmpty",      "Crafting",  3,  9),
                    new("unfiredPieDish",  "pieEmpty",      "Crafting",  7, 15),
                    new("unfiredBowl",     "bowlEmpty",     "Crafting",  8, 18),
                    new("unfiredPlantPot", "plantPotEmpty", "Crafting", 19, 20),
                    new("unfiredPotLid",   "potLid",        "Crafting", 20, 30)
                }
            });

            ProcessingStation sink = new("Sink") {
                Recipes = new() {
                    new("bucketEmpty", "bucketWater"), 
                    new("potEmpty",    "potWater"), 
                    new("clayDust",    "claySoft"), 
                    new("vialEmpty",   "vialWater"), 
                    new("bowlEmpty",   "bowlWater"), 
                    new("jugEmpty",    "jugWater"), 
                    new("potFlour",    "doughBread", secondaryOut: "potEmpty"),
                    new("kettleEmpty", "kettleFull")
                }
            };

            ProcessingStation fountain = Helper.Clone(sink);
            fountain.Name = "Fountain";
            fountain.DontIncludeInCounts = true;

            toAdd.Add(sink);
            toAdd.Add(fountain);

            toAdd.Add(new("Sand") { Recipes = new() { new("bucketEmpty", "bucketSand") } });


            toAdd.Add(new("Spinning Wheel") {
                Recipes = new() {
                    new("flax",       "bowstring",      "Crafting", 1,  5),
                    new("sinew",      "crossbowString", "Crafting", 1,  5),
                    new("woolRaw",    "woolBall",       "Crafting", 1,  3),
                    new("woolBall,4", "clothBolt",      "Crafting", 1, 10)
                }
            });

            toAdd.Add(new("Windmill") {
                Recipes = new() {
                    new("grain", "potFlour", secondaryIn: "potEmpty")
                }
            });

            
            List<string> Inks = ["Novice", "Beginner", "Apprentice", "Adept", "Journeyman", "Expert", "Artisan", "Master", "Grandmaster", "Paragon", "Divine" ];
            List<string> Imbuements = ["Metal", "Water", "Wood", "Fire", "Earth", "Destruction", "Restoration", "Alteration", "Mysticism", "Conjuration", "Illusion" ]; 
            
            toAdd.Add(new("Magic Altar") {
                Recipes = new() {
                    new("inkNovice", "inkNoviceImbued"),
                    new("inkBeginner", "inkBeginnerImbued"),
                    new("inkApprentice", "inkApprenticeImbued"),
                    new("inkAdept", "inkAdeptImbued"),
                    new("inkJourneyman", "inkJourneymanImbued"),
                    new("inkExpert", "inkExpertImbued"),
                    new("inkArtisan", "inkArtisanImbued"),
                    new("inkMaster", "inkMasterImbued"),
                    new("inkGrandmaster", "inkGrandmasterImbued"),
                    new("inkParagon", "inkParagonImbued"),
                    new("inkDivine", "inkDivineImbued")
                }
            });

            foreach (var imbue in Imbuements) {
                 toAdd.Add(new(imbue + " Altar", dont: true) {
                    Recipes = new() {
                        new("inkNovice", "inkNovice" + imbue),
                        new("inkBeginner", "inkBeginner" + imbue),
                        new("inkApprentice", "inkApprentice" + imbue),
                        new("inkAdept", "inkAdept" + imbue),
                        new("inkJourneyman", "inkJourneyman" + imbue),
                        new("inkExpert", "inkExpert" + imbue),
                        new("inkArtisan", "inkArtisan" + imbue),
                        new("inkMaster", "inkMaster" + imbue),
                        new("inkGrandmaster", "inkGrandmaster" + imbue),
                        new("inkParagon", "inkParagon" + imbue),
                        new("inkDivine", "inkDivine" + imbue)
                    }
                });
            }

            toAdd.Add(new("Dairy Cow") { Recipes = new() { new("bucketEmpty", "bucketMilk") } });

            toAdd.Add(new("Beer Keg") { Recipes = new() { new("beerGlass", "beer") } });
            toAdd.Add(new("Cider Keg") { Recipes = new() { new("beerGlass", "cider") } }); 

            for (int i = 0; i < toAdd.Count; i++) {
                Stations.Add(toAdd[i].Name, toAdd[i]);
            }
        }
    }
}
