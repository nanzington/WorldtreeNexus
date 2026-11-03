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
                        new("WTN_Prims", [ new("TimeBetween", 480, miscint2: 1200) ])
                    ],
                    ShopItemsHere = [ "newspaper0" ]
                });
            }

            // Plaza
            {
                locsToAdd.Add(new Location("WTN_Portal", "The Place Between Places", "Worldtree Nexus") {
                    SongHere = "Away",
                    DescriptionBlocks = [
                        new("You find yourself in a strange void of swirling black and purple mist. Strands of shining white light lead away from you in different directions, and you feel that following them will lead to you other worlds. A stronger golden line tethers you back to the Worldtree, allowing you to find your way back to the Plaza.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza", alt: "(Exit Portal)")
                    ]
                });

                locsToAdd.Add(new Location("WTN_Prims", "Prim's Primers", "Worldtree Nexus") { 
                    DescriptionBlocks = [
                        new("This is a small but cozy shop just off the Plaza, filled with bookshelves claiming to contain knowledge about the various worlds to which the Worldtree connects. Near the front door is a counter with a register, and a short bespectacled woman with distinct mouselike features sits on an tall stool behind it. She seems quite focused on her work, writing something in a notebook, and her tail swishes back and forth as she thinks.")
                    ],
                    ConnectedLocations = [ 
                        new("WTN_Plaza")
                    ],
                    NPCsHere = [ "wtnPrimaShop" ]
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
                        new("WTN_Realtor", [ new("TimeBetween", 480, miscint2: 1200) ]), // Nexus Nooks
                        new("WTN_ShopSeed", [ new("TimeBetween", 480, miscint2: 1200) ]), // Sneeds, mostly sells low level seeds
                        new("WTN_ShopAdventure", [ new("TimeBetween", 480, miscint2: 1200) ]),
                        new("WTN_ShopGeneral", [ new("TimeBetween", 480, miscint2: 1200) ]),
                        new("WTN_ShopButcher", [ new("TimeBetween", 480, miscint2: 1200) ]),
                        new("WTN_WaywardPalate", [ new("TimeBetween", 480, miscint2: 1200) ]), // The player-owned restaurant area
                        new("WTN_ShopProduce", [ new("TimeBetween", 480, miscint2: 1200) ]), // Sells various fruits/vegetables/etc
                        new("WTN_ShopHerbalist", [ new("TimeBetween", 480, miscint2: 1200) ]), // Sells some low level herbs and potions
                        new("WTN_ShopBooks", [ new("TimeBetween", 480, miscint2: 1200) ]), // Sells books, mostly recreational but maybe some with a purpose
                        new("WTN_ShopButcher", [ new("TimeBetween", 480, miscint2: 1200) ])
                    ],
                    GatheringSpots = [ "stallSeedLow" ]
                });
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
