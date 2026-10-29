using WorldtreeNexus.DataTypes; 

namespace WorldtreeNexus.Hardcodes {
    public class LocationsTutorial {
        public static void InitLocs(Dictionary<string, Location> Atlas, Dictionary<string, GatheringTile> Gathers, Dictionary<string, AreaMonster> Monsters) {
            List<Location> locsToAdd = new();

            locsToAdd.Add(new Location("TI_StartHut", "The Hut of New Beginnings", "Tutorial Island") {
                SongHere = "Gymnopedie 1",
                DescriptionBlocks = [
                    new("You find yourself in a small cozy shack. A window on the wall provides a nice view of the sea. A few bookshelves with pristine tomes are set against the wall, and the spaces they don't cover have some shelves hanging from the walls. Various knick-knacks and old trophies fill all the shelf space. /n /n In an armchair next to the roaring fireplace sits a bespectacled man dressed rather nicely. He seems kindly, used to dealing with confused newcomers.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                NPCsHere = [ "guyTutorial" ]
            });

            locsToAdd.Add(new Location("TI_Main", "Crossroads", "Tutorial Island") {
                SongHere = "Gymnopedie 1",
                DescriptionBlocks = [
                    new("You stand on a small island in a bay. There are a few scattered buildings here, designed to help teach some basic activities. There is a bank, a temple, a building that new people appear in, a shack housing a ladder to the cavern below, and the home of a local wizard. There is a pond near the new player building at the center of the island, and the island itself is lightly forested with paths between the buildings.")
                ],
                ConnectedLocations = [
                    new("TI_StartHut"),
                    new("TI_Bank"),
                    new("TI_Cavern"),
                    new("TI_Docks"),
                    new("TI_Farmstead"),
                    new("TI_GeneralStore"),
                    new("TI_Graveyard"),
                    new("TI_Kitchen"),
                    new("TI_MagicAltar"),
                    new("TI_Temple"),
                    new("TI_WizardHut")
                ],
                GatheringSpots = [ "treePoplar", "treePoplar", "treePoplar", "treePoplar", "treePoplar", "treePoplar", "treePoplar", "fishPondShallow", "fishPondShallow" ],
                NPCsHere = [ "man", "man", "man" ],
                AreaMonsters = [ "man", "man", "man" ]
            });

            locsToAdd.Add(new Location("TI_Bank", "Bank", "Tutorial Island") {
                DescriptionBlocks = [
                    new("The floor in here is tiled, with a row of wooden bankstands dividing the room in two. Behind the counter stands a row of bank tellers in matching grey suits, ready to serve any patrons that enter.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                NPCsHere = [ "guyBanking", "estateAgent" ],
                IsBank = true
            }); 

            locsToAdd.Add(new Location("TI_Cavern", "Cavern", "Tutorial Island") {
                DescriptionBlocks = [
                    new("The cramped cavern holds a small smithing area next to some copper ore rocks, and a metal fenced area holding a few guinea pigs the size of golden retrievers. Their wheeks echo slightly in the large cavern. It looks like there used to be a path off to another cavern, but at some point part of the ceiling collapsed and mostly blocked it. You could probably squeeze through the cracks to get through still.")
                ],
                ConnectedLocations = [
                    new("TI_Main"),
                    new("TI_Cuy"),
                    new("TI_DungeonEntrance", exp: 5, skill: "Agility") 
                ],
                ProcessingStations = [ "Furnace", "Anvil" ],
                GatheringSpots = [ "oreCopper", "oreCopper", "oreCopper", "oreCopper", "rockGemCommon", "rockClay", "rockClay" ],
                NPCsHere = [ "guySmithing" ]
            });

            // Cavern sub-areas
            {
                locsToAdd.Add(new Location("TI_Cuy", "Giant Guinea Pig Cage", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("The main food source of the residents of Tutorial Island, considered something of a delicacy. Despite being called 'giant', the cuy only come up to your knees. They scurry around you on the ground, largely ignoring your presence, wheeking occasionally. A metal fence separates this area from the rest of the cavern, keeping the animals away from the mining and smithing area. The combat tutor stands here 'supervising' you.")
                    ],
                    ConnectedLocations = [ new("TI_Cavern") ],
                    AreaMonsters = [ "cuyGiant", "cuyGiant", "cuyGiant" ],
                    NPCsHere = [ "guyCombat" ]
                });

                locsToAdd.Add(new Location("TI_DungeonEntrance", "Old Agility Course - Entrance", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("The dimly lit cavern contains a rickety old agility course, along with overgrown vegetation and shambling hordes of zombies in the pit below. In the center of the pit is a tunnel that the zombies are coming out of. It seems like failing any of the obstacles will result in falling down to the zombies. The first bit of the course involves swinging across some monkey bars, but you could also simply jump down into the pit if you wanted.")
                    ],
                    ConnectedLocations = [
                        new("TI_Cavern", exp: 5, skill: "Agility"),
                        new("TI_Agility1", exp: 5, skill: "Agility", alt: "(Cross Monkey Bars)"),
                        new("TI_AgilityPit", alt: "(Jump in Pit)") 
                    ]
                });

                locsToAdd.Add(new Location("TI_AgilityPit", "Old Agility Course - Pit", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("The pit has many zombies in it, any that happen to end up near you taking swipes in your direction. On one side of the pit are some grooves in the wall that you could use to climb back up to the entrance of the course. In the center is a tunnel that gives you an ominous feeling as you stand near it. Something powerful may be waiting inside.")
                    ],
                    ConnectedLocations = [
                        new("TI_DungeonEntrance", alt: "(Climb to Entrance)"),
                        new("TI_BossCave", alt: "(Enter Ominous Tunnel)")
                    ],
                    AreaMonsters = [ "tiZombie", "tiZombie", "tiZombie", "tiZombie", "tiZombie", "tiZombie" ]
                });

                locsToAdd.Add(new Location("TI_Agility1", "Old Agility Course - Past the Monkey Bars", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("A few small herb bushes cling to the wall, crowding the already thin walkway. The next obstacle is a series of small poles you must jump across the tops of to reach the next ledge.")
                    ],
                    ConnectedLocations = [
                        new("TI_Agility2", exp: 5, skill: "Agility", alt: "(Hop Across Poles)"),
                        new("TI_AgilityPit", alt: "(Jump in Pit)")
                    ],
                    GatheringSpots = [ "plantNeela", "plantNeela", "plantNeela", "plantMidori", "plantMidori", "plantMidori" ]
                });

                locsToAdd.Add(new Location("TI_Agility2", "Old Agility Course - Past the Poles", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("You are most of the way around the agility course now. This walkway is a little wider than the last, and uncrowded by vegetation. There are a few ore veins in the wall that you could mine. The obstacle leading to the next ledge is an old rotting balance beam.")
                    ],
                    ConnectedLocations = [
                        new("TI_Agility3", exp: 5, skill: "Agility", alt: "(Cross Balance Beam)"),
                        new("TI_AgilityPit", alt: "(Jump in Pit)")
                    ],
                    GatheringSpots = [ "oreCopper", "oreCopper", "oreCopper" ]
                });

                locsToAdd.Add(new Location("TI_Agility3", "Old Agility Course - Past the Balance Beam", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("The end of the agility course is just up ahead, across a rolling log obstacle. Some roots from the trees above hang down from the ceiling here and could be chopped.")
                    ],
                    ConnectedLocations = [
                        new("TI_DungeonEntrance", exp: 20, skill: "Agility", alt: "(Cross Rolling Log)"),
                        new("TI_AgilityPit", alt: "(Jump in Pit)")
                    ],
                    GatheringSpots = [ "rootsPoplar", "rootsPoplar", "rootsPoplar" ]
                });

                locsToAdd.Add(new Location("TI_BossCave", "Old Agility Course - Zombie Lair", "Tutorial Island") {
                    DescriptionBlocks = [
                        new("A short way into the tunnel it widens out into a small cavern. The smell of rotten flesh has grown overwhelming and you can finally see the source, a hulking zombie so large it can barely fit in this small cavern. It definitely could not fit through the tunnel to get out to the Agility Course. The huge zombie seems like it won't attack you until you approach, it's just walking in small circles dragging its huge club along the ground.")
                    ],
                    BossHere = "bossZombie",
                    ConnectedLocations = [ new("TI_AgilityPit") ]
                });
            }

            
            locsToAdd.Add(new Location("TI_Docks", "Docks", "Tutorial Island") {
                DescriptionBlocks = [
                    new("The smell of the sea fills the air here. The docks themselves are rickety old wood, long saturated with sea water. An old man sits near the end of one of the piers on a small stool. He has a bucket of fish next to him that never seems to fill up as he periodically pulls up more fish with his rod.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                GatheringSpots = [ "fishSeaShallow", "fishSeaShallow" ],
                NPCsHere = [ "guyFishing" ], 
                DigItem = "clueScrollTutorial"
            });

            locsToAdd.Add(new Location("TI_Farmstead", "Farming Guy's Farmstead", "Tutorial Island") {
                DescriptionBlocks = [
                    new("An idyllic little farmstead owned by Farming Guy. Some animals wander around aimlessly in a nearby pen, staring blankly off to the horizon when they aren't chewing on grass. /n /n There are a few farm plots here suitable for vegetables, and a dairy cow for milking. A bucket is conveniently placed next to the cow for those who didn't bring their own.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                NPCsHere = [ "guyFarming" ],
                GatheringSpots = [ "sheep", "sheep", "sheep" ],
                ProcessingStations = [ "Dairy Cow" ],
                ItemSpawns = [ new("bucketEmpty", 5) ],
                AreaMonsters = [ "cow", "cow", "cow", "chicken", "chicken", "chicken", "ram" ],
                FarmingPatchesHere = [ "TI_allotment1", "TI_allotment2", "TI_allotment3" ],
                CCHotspots = [ "shelf", "bedSmall", "chair", "table", "desk", "lighting", "lighting", "portrait", "drawers", "bookcase" ]
            });

            locsToAdd.Add(new Location("TI_GeneralStore", "General Store", "Tutorial Island") {
                DescriptionBlocks = [
                    new("An assortment of products one could almost mistake for knick-knacks line the shelves of this small building. Most of it doesn't appear to be too useful, but there are a few items of interest. There doesn't seem to be a shopkeeper around, but a jar on the counter indicates that the store is running on an honor system.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                ShopItemsHere = [ "tinderbox", "seedPotato", "shovel", "hammer", "saw", "needle", "knife", "hatchetCopper", "pickaxeCopper", "rodPoplar", "vialEmpty", "candle", "compass", "chisel", "shears" ],
                GatheringSpots = [ "clueCrates" ],
                ProcessingStations = [ "Tannery", "Pottery Kiln", "Pottery Wheel" ],
                NPCsHere = [ "tiDrunkPirate" ],
                CozyTown = "Tutorial Island",
                CCHotspots = [ "shelf", "shelf", "shelf", "shelf", "counter", "lighting", "lighting", "portrait", "stool", "lighting" ]
            });

            locsToAdd.Add(new Location("TI_Graveyard", "Graveyard", "Tutorial Island") { 
                DescriptionBlocks = [
                    new("This is a small well maintained graveyard surrounded by a low metal fence. It only has a few graves in it. Some flowers and stones are placed at a couple of them."),
                    new("The graveyard is particularly eerie at night. A thick fog clings the ground, obscuring your footing. You feel as though you're being watched by many unseen eyes.", [ new("TimeOutside", 120, miscint2: 1319)])
                ],
                ConnectedLocations = [ new("TI_Main") ],
                GatheringSpots = [ "tombstone1", "tombstone2", "tombstone3", "tombstone4" ], 
                DigItem = "bonesRegular"
            });

            locsToAdd.Add(new Location("TI_Kitchen", "Kitchen", "Tutorial Island") {
                DescriptionBlocks = [
                    new("The small building holds little more than a cooking range and a sink. The floor is checkered tiles, and some cooking implements hang from the walls. There's a bucket next to the sink.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                ProcessingStations = [ "Range", "Sink" ],
                ItemSpawns = [ new("potEmpty", 1) ],
                NPCsHere = [ "guyCooking" ]
            }); 

            locsToAdd.Add(new Location("TI_MagicAltar", "Magical Altar", "Tutorial Island") { 
                DescriptionBlocks = [
                    new("In a small clearing off to one side of a path lies a cracked stone altar engraved with magical symbols. A few crumbling pillars circle the altar, and a soft light pulses from the cracks in the altar itself. Planted near the bases of the pillars are a few sprigs of wild flax.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                ProcessingStations = [ "Magic Altar" ],
                NPCsHere = [ "guyTalisman" ],
                ShopItemsHere = [ "inkNovice", "paperPoplar", "talismanMetal", "talismanWater", "talismanWood", "talismanFire", "talismanEarth", "talismanDestruction" ],
                GatheringSpots = [ "plantFlax", "plantFlax", "plantFlax", "plantFlax" ]
            });

            locsToAdd.Add(new Location("TI_Temple", "Temple", "Tutorial Island") {
                DescriptionBlocks = [
                    new("Rows of wooden pews with red cushions line the room to either stand of the center path. A small altar is at the far end of the room, overlooked by a stained glass window depicting Saradomin, god of order.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                NPCsHere = [ "guyFather" ],
                GatheringSpots = [ "altar" ],
                ProcessingStations = [ "Holy Fountain" ],
                CozyTown = "Tutorial Island",
                CCHotspots = [ "pew", "pew", "pew", "pew", "votary", "lighting", "lighting", "stand", "stand", "lighting" ]
            });

            locsToAdd.Add(new Location("TI_WizardHut", "Wizard Hut", "Tutorial Island") {
                DescriptionBlocks = [
                    new("The inside of the shack is cramped and full of various knick-knacks and doodads. Some might call the mess 'homey' or 'cozy', but the most accurate descriptor might be 'eccentric'. Piles of books are placed haphazardly on the floor, leaving only narrow paths leading to each of the important spots in the room. An elderly wizard with a long flowing beard and classic blue robes sits at a small desk near a window, looking outside as he smokes from a pipe. A spinning wheel is tucked into a corner near the foot of the bed.")
                ],
                ConnectedLocations = [ new("TI_Main") ],
                NPCsHere = [ "tiWizardAtrel" ],
                ProcessingStations = [ "Spinning Wheel" ]
            }); 


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
