using WorldtreeNexus.DataTypes; 

namespace WorldtreeNexus.Hardcodes {
    public class LocationsNexus {
        public static void InitLocs(Dictionary<string, Location> Atlas, Dictionary<string, GatheringTile> Gathers, Dictionary<string, AreaMonster> Monsters) {
            List<Location> locsToAdd = new();

            if (GameLoop.DemoMode) {
                // "Fun" little easter egg, only this location is altered by demo mode. If you can manage to escape the location to the rest of the Nexus then it will work like the full game
                // But being unable to pass through the plaza would limit what you can do with that jail break. At best just exploring the Nexus unless you can find a way to break into the worlds
                locsToAdd.Add(new Location("WTN_Plaza", "Worldtree Nexus Plaza", "Worldtree Nexus") {
                    SongHere = "Hometown",
                    DescriptionBlocks = [
                        new("That's the end of the demo! Thank you for taking the time to try out my game. I hope you enjoyed your time, and if you encountered any bugs, want to make suggestions for future content or tweaks to existing content, want to follow the development progress, or even just want to talk about the game feel free to join the discord linked on the main menu! /n /n If you wish to continue playing this character, a teleport back to Tutorial Island is provided for your convenience. /n /n Thanks again!")
                    ],
                    ConnectedLocations = [ new("TI_Main") ]
                });
            } else {
                locsToAdd.Add(new Location("WTN_Plaza", "Worldtree Nexus Plaza", "Worldtree Nexus") {
                    SongHere = "Hometown",
                    DescriptionBlocks = [
                        new("The beating heart of the Worldtree Nexus. A large stone plaza with a portal frame set into the center, through which you can catch glimpses of strange other places among the swirling purple fog. There are a few stores directly connected to the plaza, plus a news stand near the portal itself informing visitors of recent events. /n /n There are roads branching out in various directions from here. Regardless of time of day, a small but steady stream of people pours through the plaza on their way to the portal or other parts of the city.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Portal", alt: "(Step into Portal)"), 
                        new("WTN_Commercial"),
                        new("WTN_Residential"),
                        new("WTN_Park"),
                        new("WTN_SewersPlaza", alt: "(Enter Sewer)"),
                        new("WTN_CrossroadsInn"),
                        new("WTN_Prims", req: [ new("TimeBetween", 420, miscint2: 1320) ])
                    ],
                    //ShopItemsHere = [ "newspaper0" ], 
                    ProcessingStations = [ "Fountain" ],
                    GatheringSpots = [ "treePoplar", "treePoplar", "treePoplar", "treeElm" ],
                    NPCsHere = [ "wtnMaxStatz" ]
                });
            }

            // Plaza
            {
                locsToAdd.Add(new Location("WTN_Portal", "The Place Between Places", "Worldtree Nexus") {
                    SongHere = "Away",
                    Outside = false,
                    DescriptionBlocks = [
                        new("You find yourself in a strange void of swirling black and purple mist. Strands of shining white light lead away from you in different directions, and you feel that following them will lead to you other worlds. A stronger golden line tethers you back to the Worldtree, allowing you to find your way back to the Plaza.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza", alt: "(Exit Portal)")
                    ]
                });

                locsToAdd.Add(new Location("WTN_Prims", "Prim's Primers", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("This is a small but cozy shop just off the Plaza, filled with bookshelves claiming to contain knowledge about the various worlds to which the Worldtree connects. Near the front door is a counter with a register, and a short bespectacled woman with distinct mouselike features sits on an tall stool behind it. She seems quite focused on her work, writing something in a notebook, and her tail swishes back and forth as she thinks.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza")
                    ],
                    NPCsHere = [ "wtnPrimaShop" ]
                });

                locsToAdd.Add(new Location("WTN_CrossroadsInn", "The Crossroads Inn", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("A well decorated but homey inn. The staff generally tries to keep the rowdiness of the crowd from getting out of hand, but because they're at the Plaza and get a lot of traffic, sometimes those efforts are in vain.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza")
                    ],
                    NPCsHere = [ "wtnBart" ],
                    GatheringSpots = [ "innSleepMorning", "innSleepAfternoon", "innSleepNight", "innSleepMidnight" ],
                    ShopItemsHere = [ "beer" ]
                });
            }

            // Commercial
            {
                locsToAdd.Add(new Location("WTN_Commercial", "Commercial District", "Worldtree Nexus") { 
                    DescriptionBlocks = [
                        new("A bustling section of the city full of shops. A plaza, smaller than the main plaza of course, is central to the district and has some market stalls where venders hawk their wares. Flashy signs attempt to grab the eye to lure you into their respective shops."),
                        new("The stall merchants shout at passerby to get their attention, while shoppers talk and laugh amonst themselves. Some may find the resulting cacophony of life overwhelming, while others may take comfort in the press of the crowds.", [ new("TimeBetween", 540, miscint2: 1260)]),
                        new("The district is sedate at this time, with people having largely done their shopping during the day. Any merchants still at their stall still attempt to lure in the occasional customer, but due to noise ordinances have toned down the volume.", [ new("TimeOutside", 540, miscint2: 1260)])
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza"), 
                        new("WTN_Entertainment"),
                        new("WTN_Guildhalls"),
                        new("WTN_Administration"), // Government buildings and such
                        new("WTN_SewersCommercial", alt: "(Enter Sewer)"),
                        new("WTN_Realtor"), // Nexus Nooks
                        new("WTN_TradeHall"),
                        new("WTN_ShopSeed", req: [ new("TimeBetween", 420, miscint2: 1320) ]), // Sneeds, mostly sells low level seeds
                        new("WTN_ShopAdventure", req: [ new("TimeBetween", 420, miscint2: 1320) ]),
                        new("WTN_ShopGeneral", req: [ new("TimeBetween", 420, miscint2: 1320) ]),
                        new("WTN_ShopButcher", req: [ new("TimeBetween", 420, miscint2: 1320) ]),
                        new("WTN_WaywardPalate", req: [ new("TimeBetween", 420, miscint2: 1320) ]), // The player-owned restaurant area
                        new("WTN_ShopGrocery", req: [ new("TimeBetween", 420, miscint2: 1320) ]), // Sells various fruits/vegetables/etc
                        new("WTN_ShopHerbalist", req: [ new("TimeBetween", 420, miscint2: 1320) ]), // Sells some low level herbs and potions
                        new("WTN_ShopBooks", req: [ new("TimeBetween", 420, miscint2: 1320) ]), // Sells books, mostly recreational but maybe some with a purpose
                        new("WTN_ShopButcher", req: [ new("TimeBetween", 420, miscint2: 1320) ])
                    ],
                    GatheringSpots = [ "stallSeedLow" ]
                });

                locsToAdd.Add(new Location("WTN_TradeHall", "Trade Hall", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("This is a large illustrious building dedicated to frequent commerce. There are booths lined up to place buy and sell orders at, along with tellers to access items in your bank at will. Some kind of magical displays hover in the air above the trade floor showing fluctuating prices of different high value items, with the crowd reacting loudly as their items jump or fall in value.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    IsBank = true,
                    ProcessingStations = [ "Trade Hall" ]
                });

                locsToAdd.Add(new Location("WTN_Realtor", "Nexus Nooks", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("This is a cramped office, the walls lined with shelves stacked with ledgers and documents. An estate agent is sitting behind the main desk, with a couple chairs in front of it for potential customers. The desk is covered with trinkets, and has a portfolio of potential homes to purchase.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "estateAgent" ]
                });

                locsToAdd.Add(new Location("WTN_ShopSeed", "Feed and Seed", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("A tidy shop just off the market square. Rows of shelves hold a variety of common seeds for those with green thumbs, nicely categorized by type. There's also a small selection of general tools that may be useful on a farm.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnSneed" ],
                    GatheringSpots = [ "jobFeedSeed" ],
                    ShopItemsHere = [ 
                    "___Tools_________", "bucketCompost", "shovel", "shears", "plantPotEmpty",
                    "___Herbs_________", "seedNeela", "seedMidori", "seedNimbu", "seedKiiro", "seedBaingani", "seedMurasaki", "seedLal", "seedMazent",
                    "___Produce_______", "seedBellpepper", "seedBroccoli", "seedCabbage", "seedCarrot", "seedCauliflower", "seedCucumber", "seedLettuce", "seedOnion", "seedPotato", "seedSweetcorn", "seedSweetpeas", "seedTomato",
                    "___Fiber_________", "seedXiangdao", "seedVeneficus", "seedZauberer", "seedVolshebnik",
                    "___Flowers_______", "seedSunflower", "seedTulip", "seedOrchid", "seedChrysanthemum",
                    "___Bushes________", "seedStrawberry", "seedNightshade", "seedBlueberry", "seedRaspberry",
                    "___Trees_________", "seedPoplar", "seedElm", "seedWalnut", "seedHolly"]
                });

                locsToAdd.Add(new Location("WTN_ShopButcher", "Meat Cute", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("A surprisingly modern-looking store, at least by the standards of the fantasy vibe most of the rest of the Nexus goes for. The floor is clean white tile, counters all metal surfaces. Behind the counter is a row of coolers with cuts of meat stacked on piles of ice. You can feel the chill even without approaching them.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnBlaine" ],
                    GatheringSpots = [ "jobMeatCute" ],
                    ShopItemsHere = [ "meatRawBeef", "meatRawRat", "meatRawBear", "meatRawChicken" ]
                });

                locsToAdd.Add(new Location("WTN_ShopAdventure", "The Handy Haversack", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("The shelves and racks in this store cater to aspiring heroes, providing a variety of gear that may be useful when adventuring or exploring. Hilda used to advertise that the gear would keep you safer than competitors gear, but her lawyers recently advised against that after some unfortunate incidents.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnHilda" ],
                    GatheringSpots = [ "jobHandyHaversack" ],
                    ShopItemsHere = [ 
                    "___General_______", "bedroll", "compass", "rationTravel", "rope", "tinderbox", "waterskin",
                    "___Lights________", "candle", "torch", "candleLantern", "oilLantern", "oilLamp", "oilFlask",
                    "___Melee Gear____", "swordCopper", "kiteshieldCopper", "platebodyCopper", "platelegsCopper",
                    "___Range Gear____", "shortbowPoplar", "arrowsCopper", "bodyLeather", "chapsLeather", 
                    "___Magic Gear____", "wandPoplar", "hoodXiangdao", "robeTopXiangdao", "robeBottomXiangdao" ]
                });

                locsToAdd.Add(new Location("WTN_ShopGrocery", "The Farmer's Market", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("The front room of this shop is dominated by bins of produce kept magically fresh. A portly gentleman wearing simple farmers overalls sits behind the counter reading a small book.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnDavid" ],
                    GatheringSpots = [ "jobFarmersMarket" ],
                    ShopItemsHere = [ 
                    "___Fruits________", "strawberry", "blueberry", "raspberry",
                    "___Vegetables____", "bellpepper", "broccoli", "cabbage", "carrot", "cauliflower", "cucumber", "lettuce", "onion", "potato", "sweetcorn", "sweetpeas", "tomato"]
                });

                locsToAdd.Add(new Location("WTN_ShopHerbalist", "Potent Potables", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("There is a lingering scent of failed alchemical mixtures in this shop. Carefully sorted and labelled bins of herbs line the shelves, along with some more basic equipment for actually creating potions. A neglected selection of non-herb ingredients fills one lonely shelf.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnEurekaEarl" ],
                    GatheringSpots = [ "jobPotentPotables" ],
                    ShopItemsHere = [ 
                    "___Equipment_____", "pestleMortar", "alchemyBrazier", "alchemyLoupe", "vialEmpty", "vialWater", "vialEmptyPack", "vialWaterPack",
                    "___Potions_______", "potionAttack", "potionStrength", "potionDefense", "potionRanged", "potionMagic",
                    "___Herbs_________", "cleanNeela", "cleanMidori", "cleanNimbu", "cleanKiiro", "cleanBaingani", "cleanMurasaki", "cleanLal", "cleanMazent",
                    "___Reagents______", "eyeCuy", "bonesRegularGround", "ashesPoplar", "shavingsCopper" ]
                });

                locsToAdd.Add(new Location("WTN_ShopCraft", "Crafty Crafters", "Worldtree Nexus") { 
                    Outside = false,
                    DescriptionBlocks = [
                        new("'A shop for crafters, craftiness not required!' the sign proclaims. It certainly seems to be true as you step into the store, as the shelves are all filled with various tools for crafting and low-level materials for people to train with.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Commercial")
                    ],
                    NPCsHere = [ "wtnCecilia" ],
                    GatheringSpots = [ "jobCraftyCrafters" ],
                    ShopItemsHere = [ 
                    "___Tools_________", "chisel", "glassblowingPipe", "hammer", "knife", "needle", "saw", "shovel",
                    "___Containers____", "bowlEmpty", "bucketEmpty", "cupEmpty", "jugEmpty", "potEmpty",
                    "___Moulds________", "mouldAmulet", "mouldBracelet", "mouldBrooch", "mouldNecklace", "mouldRing",
                    "___Materials_____", "boltXiangdao", "boltVeneficus", "boltZauberer", "boltVolshebnik", "leatherSoft", "leatherHard"]
                });
            }

            // Residential District
            {
                locsToAdd.Add(new Location("WTN_Residential", "Residential District", "Worldtree Nexus") { 
                    DescriptionBlocks = [
                        new("This part of the city is where most of the homes for regular citizens are placed. There are rows of standalone houses, and also apartment complexes that offer a lower cost housing option. The streets are lined with trees, and the district is kept quite clean by the residents and a local cleaning agency.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza"), 
                        new("WTN_Entertainment"), 
                        new("WTN_Temples"),
                        new("WTN_SewersResidential", alt: "(Enter Sewer)"), 
                        new("WTN_Apartments"), 
                        new("WTN_Temples")
                    ]
                });
            }


            // Sewer
            {

            }


            for (int i = 0; i < locsToAdd.Count; i++) {
                for (int j = 0; j < locsToAdd[i].GatheringSpots.Count; j++) {
                    if (Gathers.TryGetValue(locsToAdd[i].GatheringSpots[j], out GatheringTile? gather) && gather != null) {
                        locsToAdd[i].LocalGathers.Add(Helper.Clone(gather));
                    }
                }

                for (int j = 0; j < locsToAdd[i].AreaMonsters.Count; j++) {
                    if (Monsters.TryGetValue(locsToAdd[i].AreaMonsters[j], out AreaMonster? mon) && mon != null) {
                        locsToAdd[i].MonstersHere.Add(Helper.Clone(mon));
                    }
                }


                Atlas.Add(locsToAdd[i].ID, locsToAdd[i]);
            }
        }
    }
}
