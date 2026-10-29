using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedPOHObjects {
        public static List<POH_Room> RoomTypes = new() {
            new("Parlor", ["Bookcase", "Chair", "Curtains", "Fireplace", "Rug", "Teleport Focus"], 1_000, 1),
            new("Garden", ["Big Plant", "Small Plant", "Small Plant", "Tree", "Plot"], 1_000, 1),
            new("Kitchen", ["Keg", "Cat Basket", "Larder", "Shelf", "Sink", "Spice Rack", "Stove", "Counter"], 5_000, 5),
            new("Dining Room", ["Curtains", "Decoration", "Fireplace", "Seating", "Table"], 5_000, 10),
            new("Workshop", ["Primary Station", "Secondary Station", "Tool Rack", "Repair Bench"], 10_000, 15), // TODO: Re-add clockwork bench when it matters for quests
            new("Bedroom", ["Bed", "Corner", "Curtains", "Dresser", "Fireplace", "Rug", "Wardrobe"], 10_000, 20)
        }; 
        // Missing Skill Hall, Games Room, Combat Room, Quest Hall, Menagerie, Costume Room, Formal Garden, Throne Room, Superior Garden, and Achievement Gallery
        // Some have to be workshopped a bit to give them an actual valuable use

        public static void InitPOHObjects(Dictionary<string, POH_Object> ObjLib, Dictionary<string, Spell> SpellLib, Dictionary<string, Location> Atlas) {
            List<POH_Object> toAdd = new();

            List<MaterialDef> Woods = Materials.Woods;

            for (int i = 0; i < 10; i++) { // Tiered items
                toAdd.Add(new("Bookcase", Woods[i].Name + " bookcase", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " bookcase. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 3, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier, "clueBookcase"));
                toAdd.Add(new("Chair", Woods[i].Name + " chair", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " chair. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 2, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                toAdd.Add(new("Chair", Woods[i].Name + " armchair", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " armchair. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 3, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level + 5, "Construction")], (int) Woods[i].Tier));
                
                toAdd.Add(new("Counter", Woods[i].Name + " counter", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " counter to prepare food. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 3, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level + 5, "Construction")], (int) Woods[i].Tier));
                
                toAdd.Add(new("Decoration", Woods[i].Name + " wall decoration", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " carving of your family crest. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 2, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction"), new("Data", 1, "HasCrest", summ: "Must have spoken to Sir Renitee to know your family crest.")], (int) Woods[i].Tier));
                toAdd.Add(new("Seating", Woods[i].Name + " bench", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " bench for guests to sit. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",4", "nails" + Woods[i].Descriptor + ",8" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 4, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                toAdd.Add(new("Table", Woods[i].Name + " dining table", "A" + (Helper.VowelStart(Woods[i].Name.ToLower()) ? "n " : " ") + Woods[i].Name.ToLower() + " dining table. Holds plenty of food. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",6", "nails" + Woods[i].Descriptor + ",12" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 6, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                
                if (i < 9) {
                    toAdd.Add(new("Bed", Woods[i].Name + " bed", "Great for sleeping in. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",5", "nails" + Woods[i].Descriptor + ",10" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 5, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier, acts: [ new("POH", "Rest", "", 0)] ));
                    toAdd.Add(new("Corner", Woods[i].Name + " clock", "Time is a tool you can put on the wall or wear it on your rizt. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 2, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level + 5, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Dresser", Woods[i].Name + " dresser", "To help you do your hair. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4", "glassMolten,1" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 2, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Wardrobe", Woods[i].Name + " wardrobe", "A place to keep all your clothes. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 3, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Globe", Woods[i].Name + " globe", "A wooden planet of your very own. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 3, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Telescope", Woods[i].Name + " telescope", "Used for observing heavenly bodies. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4", "glassMolten,1" ], ["hammer,1", "saw,1"], (30 * (int) Woods[i].Tier) * 2, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier, activateText: "You peer through the telescope at the night sky.", acts: [ new("POH", "Telescope", "", 0) ]));
                
                } else {
                    toAdd.Add(new("Bed", "Gilded katalox bed", "Great for sleeping in. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",5", "nails" + Woods[i].Descriptor + ",10", "goldLeaf,2" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 5) + 600, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier, acts: [ new("POH", "Rest", "", 0)] ));
                    toAdd.Add(new("Corner", "Gilded katalox clock", "Time is a tool you can put on the wall or wear it on your rizt. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4", "goldLeaf,1" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 2) + 300, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level + 5, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Dresser", "Gilded katalox dresser", "To help you do your hair. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4", "glassMolten,2", "goldLeaf,1" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 2) + 300, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Wardrobe", "Gilded katalox wardrobe", "A place to keep all your clothes. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6", "goldLeaf,1" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 3) + 300, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Globe", "Gilded katalox globe", "A wooden planet of your very own. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",3", "nails" + Woods[i].Descriptor + ",6", "goldLeaf,1" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 3) + 300, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier));
                    toAdd.Add(new("Telescope", "Gilded katalox telescope", "Used for observing heavenly bodies. Provides " + (int) Woods[i].Tier + " comfort.", [ "plank" + Woods[i].Name + ",2", "nails" + Woods[i].Descriptor + ",4", "glassMolten,1", "goldLeaf,1" ], ["hammer,1", "saw,1"], ((30 * (int) Woods[i].Tier) * 2) + 300, Woods[i].R, Woods[i].G, Woods[i].B, [ new("Skill", Woods[i].Level, "Construction")], (int) Woods[i].Tier, activateText: "You peer through the telescope at the night sky.", acts: [ new("POH", "Telescope", "", 0) ]));
                }
            }

            // Parlor
            {
                toAdd.Add(new("Teleport Focus", "Teleportation focus", "Allows you to teleport to this house, provided the house is active. Only one needed per house.", [ "plankAcacia,8", "nailsGold,16", "stoneMagic" ], ["hammer,1", "saw,1"], 2200, Color.MediumPurple, [ new("Skill", 49, "Construction")]));
                
                toAdd.Add(new("Curtains", "Torn curtains", "Some ragged curtains. Provides 1 comfort.", [ "plankPoplar,3", "nailsCopper,6", "clothBolt,3" ], ["hammer,1", "saw,1"], 135, Color.Crimson.GetDarker(), [ new("Skill", 2, "Construction")], 1));
                toAdd.Add(new("Curtains", "Curtains", "Some nice curtains. Provides 2 comfort.", [ "plankElm,3", "nailsBronze,6", "clothBolt,3" ], ["hammer,1", "saw,1"], 225, Color.Crimson.GetDark(), [ new("Skill", 18, "Construction")], 2));
                toAdd.Add(new("Curtains", "Opulent curtains", "Some gaudy curtains. Provides 5 comfort.", [ "plankAcacia,3", "nailsGold,6", "clothBolt,3" ], ["hammer,1", "saw,1"], 495, Color.Crimson, [ new("Skill", 40, "Construction")], 5));
            
                toAdd.Add(new("Fireplace", "Clay fireplace", "A clay fireplace. May be used for Cooking. Provides 1 comfort.", [ "claySoft,3"  ], ["hammer,1", "saw,1"], 30, Color.SaddleBrown, [ new("Skill", 3, "Construction")], 1, station: "Fire"));
                toAdd.Add(new("Fireplace", "Stone fireplace", "A limestone fireplace. May be used for Cooking. Provides 4 comfort.", [ "blockLimestone,3"  ], ["hammer,1", "saw,1"], 40, Color.DarkGray, [ new("Skill", 33, "Construction")], 4, station: "Fire"));
                toAdd.Add(new("Fireplace", "Marble fireplace", "A marble fireplace. May be used for Cooking. Provides 7 comfort.", [ "blockMarble,3"  ], ["hammer,1", "saw,1"], 1500, Color.White, [ new("Skill", 63, "Construction")], 7, station: "Fire"));
            
                toAdd.Add(new("Rug", "Brown rug", "An ugly rug, but better than a bare floor. Provides 1 comfort.", [ "clothBolt,2"  ], ["hammer,1", "saw,1"], 30, Color.SaddleBrown, [ new("Skill", 2, "Construction")], 1));
                toAdd.Add(new("Rug", "Rug", "A nice rug. Provides 2 comfort.", [ "clothBolt,4"  ], ["hammer,1", "saw,1"], 60, Color.Maroon, [ new("Skill", 13, "Construction")], 2));
                toAdd.Add(new("Rug", "Opulent rug", "An opulent rug woven with gold leaf. Provides 7 comfort.", [ "clothBolt,4", "goldLeaf,1"  ], ["hammer,1", "saw,1"], 360, Color.Crimson, [ new("Skill", 65, "Construction")], 7));
            }

            // Garden
            {
                toAdd.Add(new("Tree", "Poplar tree", "One of the most common trees in the multiverse. Regrows after chopping.", [ "plantPotPoplar,1"  ], ["shovel,1"], 30, ColorLib.Poplar, [ new("Skill", 1, "Construction"), new("Skill", 1, "Farming")], 0, "treePoplar"));
                toAdd.Add(new("Tree", "Elm tree", "A beautiful old elm. Regrows after chopping.", [ "plantPotElm,1"  ], ["shovel,1"], 60, ColorLib.Elm, [ new("Skill", 10, "Construction"), new("Skill", 10, "Farming")], 0, "treeElm"));
                toAdd.Add(new("Tree", "Walnut tree", "Usually grows near water. Regrows after chopping.", [ "plantPotWalnut,1"  ], ["shovel,1"], 90, ColorLib.Walnut, [ new("Skill", 20, "Construction"), new("Skill", 20, "Farming")], 0, "treeWalnut"));
                toAdd.Add(new("Tree", "Holly tree", "A beautiful old holly tree. Regrows after chopping.", [ "plantPotHolly,1"  ], ["shovel,1"], 120, ColorLib.Holly, [ new("Skill", 30, "Construction"), new("Skill", 30, "Farming")], 0, "treeHolly"));
                toAdd.Add(new("Tree", "Acacia tree", "Provides some welcome shade! Regrows after chopping.", [ "plantPotAcacia,1"  ], ["shovel,1"], 150, ColorLib.Acacia, [ new("Skill", 40, "Construction"), new("Skill", 40, "Farming")], 0, "treeAcacia"));
                toAdd.Add(new("Tree", "Birch tree", "Provides some welcome shade. Regrows after chopping.", [ "plantPotBirch,1"  ], ["shovel,1"], 180, ColorLib.Birch, [ new("Skill", 50, "Construction"), new("Skill", 50, "Farming")], 0, "treeBirch"));
                toAdd.Add(new("Tree", "Hickory tree", "A beautiful old hickory tree. Regrows after chopping.", [ "plantPotHickory,1"  ], ["shovel,1"], 210, ColorLib.Hickory, [ new("Skill", 60, "Construction"), new("Skill", 60, "Farming")], 0, "treeHickory"));
                toAdd.Add(new("Tree", "Bloodwood tree", "An ominous red-wooded tree. Regrows after chopping.", [ "plantPotBloodwood,1"  ], ["shovel,1"], 240, ColorLib.Bloodwood, [ new("Skill", 70, "Construction"), new("Skill", 70, "Farming")], 0, "treeBloodwood"));
                toAdd.Add(new("Tree", "Camatillo tree", "The tree shimmers with a magical force. Regrows after chopping.", [ "plantPotCamatillo,1"  ], ["shovel,1"], 270, ColorLib.Camatillo, [ new("Skill", 80, "Construction"), new("Skill", 80, "Farming")], 0, "treeCamatillo"));
                toAdd.Add(new("Tree", "Katalox tree", "The aged tree dominates with its huge presence. Regrows after chopping.", [ "plantPotKatalox,1"  ], ["shovel,1"], 300, ColorLib.Katalox, [ new("Skill", 90, "Construction"), new("Skill", 90, "Farming")], 0, "treeKatalox"));
             
                toAdd.Add(new("Big Plant", "Blueberry bush", "Thurgo would love this. Pies on demand!", [ "seedBlueberry,10"  ], ["shovel,1"], 30, Color.ForestGreen, [ new("Skill", 5, "Construction"), new("Skill", 10, "Farming")], 0, "plantBlueberry"));
                toAdd.Add(new("Big Plant", "Nightshade bush", "Why do you need a regular source of nightshade berries?", [ "seedNightshade,5"  ], ["shovel,1"], 30, Color.ForestGreen, [ new("Skill", 10, "Construction"), new("Skill", 10, "Farming")], 0, "plantNightshade"));
                toAdd.Add(new("Big Plant", "Doogle bush", "Don't tell Fluffs.", [ "doogle,5"  ], ["shovel,1"], 30, Color.ForestGreen, [ new("Skill", 5, "Construction"), new("Skill", 5, "Farming")], 0, "plantDoogle"));
                toAdd.Add(new("Big Plant", "Nettle bush", "All the nettle tea you want, but at what cost?", [ "nettles,5"  ], ["shovel,1"], 30, Color.ForestGreen, [ new("Skill", 5, "Construction"), new("Skill", 5, "Farming")], 0, "plantNettles"));
                // TODO: Requires stuff from Forestry events, revisit this when that gets figured out
                //toAdd.Add(new("Big Plant", "Beehive", "The bees buzz happily. Provides honeycomb and wax.", [ "nettles,5"  ], ["shovel,1"], 30, Color.ForestGreen, [ new("Skill", 5, "Construction"), new("Skill", 5, "Farming")], 0, "plantNettles"));
            
                toAdd.Add(new("Small Plant", "Marigolds", "A small patch of marigolds. Lovely!", [ "seedMarigold,5"  ], ["shovel,1"], 15, 255, 165, 0, [ new("Skill", 1, "Construction"), new("Skill", 2, "Farming")], 1));
                toAdd.Add(new("Small Plant", "Rosemary", "A small patch of rosemary. Lovely!", [ "seedRosemary,5"  ], ["shovel,1"], 15, 255, 165, 0, [ new("Skill", 1, "Construction"), new("Skill", 11, "Farming")], 2));
                toAdd.Add(new("Small Plant", "Nasturtiums", "A small patch of nasturtiums. Lovely!", [ "seedNasturtium,5"  ], ["shovel,1"], 15, 255, 0, 0, [ new("Skill", 1, "Construction"), new("Skill", 24, "Farming")], 3));
                toAdd.Add(new("Small Plant", "White Lilies", "A small patch of white lilies. Lovely!", [ "seedWhiteLily,5"  ], ["shovel,1"], 15, Color.White, [ new("Skill", 1, "Construction"), new("Skill", 52, "Farming")], 6));
            
                toAdd.Add(new("Plot", "Sand pit", "A box of sand you can fill buckets with.", [ "bucketSand,4", "plankPoplar,8", "nailsCopper,16" ], ["hammer,1", "saw,1", "shovel,1"], 300, Color.SandyBrown, [ new("Skill", 1, "Construction")], station: "Sand")); 
                toAdd.Add(new("Plot", "Clay deposit", "Some unearthed clay you could mine.", [ "clayDust,8", "plankPoplar,8", "nailsCopper,16" ], ["hammer,1", "saw,1", "shovel,1"], 300, Color.SandyBrown, [ new("Skill", 1, "Construction")], gather: "rockClay"));

                toAdd.Add(new("Plot", "Allotment patch", "An allotment patch, allowing you to grow produce.", [ "bucketCompost,4", "plankPoplar,8", "nailsCopper,16" ], ["hammer,1", "saw,1", "shovel,1"], 300, Color.SaddleBrown, [ new("Skill", 1, "Construction")], patch: "Allotment"));
                toAdd.Add(new("Plot", "Flower patch", "A flower patch, allowing you to grow flowers.", [ "bucketCompost,4", "plankElm,8", "nailsBronze,16" ], ["hammer,1", "saw,1", "shovel,1"], 540, Color.SaddleBrown, [ new("Skill", 10, "Construction")], patch: "Flower"));
                toAdd.Add(new("Plot", "Herb patch", "An herb patch, allowing you to grow herbs.", [ "bucketCompost,4", "plankWalnut,8", "nailsIron,16" ], ["hammer,1", "saw,1", "shovel,1"], 780, Color.SaddleBrown, [ new("Skill", 20, "Construction")], patch: "Herb"));
                toAdd.Add(new("Plot", "Hops patch", "A hops patch, allowing you to grow hops.", [ "bucketCompost,4", "plankHolly,8", "nailsSilver,16" ], ["hammer,1", "saw,1", "shovel,1"], 1020, Color.SaddleBrown, [ new("Skill", 30, "Construction")], patch: "Hops"));
                toAdd.Add(new("Plot", "Bush patch", "A bush patch, allowing you to grow a bush.", [ "bucketCompost,4", "plankAcacia,8", "nailsGold,16" ], ["hammer,1", "saw,1", "shovel,1"], 1260, Color.SaddleBrown, [ new("Skill", 40, "Construction")], patch: "Bush"));
                toAdd.Add(new("Plot", "Fruit tree patch", "A fruit tree patch, allowing you to grow a fruit tree.", [ "bucketCompost,4", "plankBirch,8", "nailsPlatinum,16" ], ["hammer,1", "saw,1", "shovel,1"], 1500, Color.SaddleBrown, [ new("Skill", 50, "Construction")], patch: "Fruit Tree"));
                toAdd.Add(new("Plot", "Tree patch", "A tree patch, allowing you to grow a tree.", [ "bucketCompost,4", "plankHickory,8", "nailsSteel,16" ], ["hammer,1", "saw,1", "shovel,1"], 1740, Color.SaddleBrown, [ new("Skill", 60, "Construction")], patch: "Tree"));
                toAdd.Add(new("Plot", "Cactus patch", "A cactus patch, allowing you to grow cacti.", [ "bucketCompost,4", "plankBloodwood,8", "nailsCobalt,16" ], ["hammer,1", "saw,1", "shovel,1"], 1980, Color.SaddleBrown, [ new("Skill", 70, "Construction")], patch: "Cactus"));
            }

            // Kitchen
            {
                toAdd.Add(new("Keg", "Beer keg", "A keg full of beer.", [ "plankPoplar,3", "nailsCopper,6", "beer,8"  ], ["hammer,1", "saw,1"], 90, Color.SaddleBrown, [ new("Skill", 7, "Construction"), new("Skill", 5, "Cooking")], station: "Beer Keg"));
                toAdd.Add(new("Keg", "Cider keg", "A keg full of cider.", [ "plankElm,3", "nailsBronze,6", "cider,8"  ], ["hammer,1", "saw,1"], 180, Color.SaddleBrown, [ new("Skill", 12, "Construction"), new("Skill", 14, "Cooking")], station: "Cider Keg"));
                
                toAdd.Add(new("Cat Basket", "Cat blanket", "A place for your pet to sleep. Provides 1 comfort.", [ "clothBolt,1"  ], ["hammer,1", "saw,1"], 15, Color.SaddleBrown, [ new("Skill", 5, "Construction")], 1));
                toAdd.Add(new("Cat Basket", "Cat basket", "Your pet would love to sleep here. Provides 2 comfort.", [ "clothBolt,1", "plankElm,2", "nailsBronze,4"  ], ["hammer,1", "saw,1"], 135, Color.SaddleBrown, [ new("Skill", 19, "Construction")], 2));
                toAdd.Add(new("Cat Basket", "Cushioned basket", "A luxurious sleeping place for your pet. Provides 4 comfort.", [ "woolRaw,2", "plankHolly,2", "nailsSilver,4" ], ["hammer,1", "saw,1"], 250, Color.Crimson, [ new("Skill", 33, "Construction")], 4));
            
                toAdd.Add(new("Larder", "Poplar larder", "A poplar larder to keep food cool.", [ "plankPoplar,8", "nailsCopper,16"  ], ["hammer,1", "saw,1"], 240, ColorLib.Poplar, [ new("Skill", 1, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves" ]});
                toAdd.Add(new("Larder", "Elm larder", "An elm larder to keep food cool.", [ "plankElm,8", "nailsBronze,16"  ], ["hammer,1", "saw,1"], 480, ColorLib.Elm, [ new("Skill", 10, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour" ]});
                toAdd.Add(new("Larder", "Walnut larder", "A walnut larder to keep food cool.", [ "plankWalnut,8", "nailsIron,16"  ], ["hammer,1", "saw,1"], 720, ColorLib.Walnut, [ new("Skill", 20, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken" ]});
                toAdd.Add(new("Larder", "Holly larder", "A holly larder to keep food cool.", [ "plankHolly,8", "nailsSilver,16"  ], ["hammer,1", "saw,1"], 960, ColorLib.Holly, [ new("Skill", 30, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken", "cheese" ]});
                toAdd.Add(new("Larder", "Acacia larder", "An acacia larder to keep food cool.", [ "plankAcacia,8", "nailsGold,16"  ], ["hammer,1", "saw,1"], 1200, ColorLib.Acacia, [ new("Skill", 40, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken", "cheese", "potato" ]});
                toAdd.Add(new("Larder", "Birch larder", "A birch larder to keep food cool.", [ "plankBirch,8", "nailsPlatinum,16"  ], ["hammer,1", "saw,1"], 1440, ColorLib.Birch, [ new("Skill", 50, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken", "cheese", "potato", "garlic" ]});
                toAdd.Add(new("Larder", "Hickory larder", "A hickory larder to keep food cool.", [ "plankHickory,8", "nailsSteel,16"  ], ["hammer,1", "saw,1"], 1680, ColorLib.Hickory, [ new("Skill", 60, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken", "cheese", "potato", "garlic", "onion" ]});
                toAdd.Add(new("Larder", "Bloodwood larder", "A bloodwood larder to keep food cool.", [ "plankBloodwood,8", "nailsCobalt,16"  ], ["hammer,1", "saw,1"], 1920, ColorLib.Bloodwood, [ new("Skill", 70, "Construction")]) { ShopItems = [ "bucketMilk", "teaLeaves", "potFlour", "eggChicken", "cheese", "potato", "garlic", "onion", "tomato" ]});
            
                toAdd.Add(new("Shelf", "Poplar shelf", "Shelves full of kitchen utensils.", [ "plankPoplar,3", "nailsCopper,6"  ], ["hammer,1", "saw,1"], 90, ColorLib.Poplar, [ new("Skill", 5, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotClayEmpty", "cupClayEmpty" ]});
                toAdd.Add(new("Shelf", "Elm shelf", "Shelves full of kitchen utensils.", [ "plankElm,3", "nailsBronze,6", "claySoft,6" ], ["hammer,1", "saw,1"], 240, ColorLib.Elm, [ new("Skill", 15, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotClayEmpty", "cupClayEmpty", "beerGlass" ]});
                toAdd.Add(new("Shelf", "Walnut shelf", "Shelves full of kitchen utensils.", [ "plankWalnut,3", "nailsIron,6", "claySoft,6" ], ["hammer,1", "saw,1"], 330, ColorLib.Walnut, [ new("Skill", 25, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotPorcelainEmpty", "cupPorcelainEmpty", "beerGlass", "tinCakeEmpty" ]});
                toAdd.Add(new("Shelf", "Holly shelf", "Shelves full of kitchen utensils.", [ "plankHolly,3", "nailsSilver,6", "claySoft,6" ], ["hammer,1", "saw,1"], 420, ColorLib.Holly, [ new("Skill", 35, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotPorcelainEmpty", "cupPorcelainEmpty", "beerGlass", "tinCakeEmpty", "bowlEmpty" ]});
                toAdd.Add(new("Shelf", "Acacia shelf", "Shelves full of kitchen utensils.", [ "plankAcacia,3", "nailsGold,6", "claySoft,6" ], ["hammer,1", "saw,1"], 510, ColorLib.Acacia, [ new("Skill", 45, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotPorcelainEmpty", "cupPorcelainEmpty", "beerGlass", "tinCakeEmpty", "bowlEmpty", "pieShell" ]});
                toAdd.Add(new("Shelf", "Birch shelf", "Shelves full of kitchen utensils.", [ "plankBirch,3", "nailsPlatinum,6", "claySoft,6" ], ["hammer,1", "saw,1"], 600, ColorLib.Birch, [ new("Skill", 55, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotPorcelainEmpty", "cupPorcelainEmpty", "beerGlass", "tinCakeEmpty", "bowlEmpty", "pieShell", "potEmpty" ]});
                toAdd.Add(new("Shelf", "Hickory shelf", "Shelves full of kitchen utensils.", [ "plankHickory,3", "nailsSteel,6", "claySoft,6", "goldLeaf,2" ], ["hammer,1", "saw,1"], 1290, ColorLib.Hickory, [ new("Skill", 65, "Construction")]) { ShopItems = [ "kettleEmpty", "teapotAntiqueEmpty", "cupAntiqueEmpty", "beerGlass", "tinCakeEmpty", "bowlEmpty", "pieShell", "potEmpty", "chefHat" ]});
            
                toAdd.Add(new("Sink", "Pump and drain", "Shelves full of kitchen utensils.", [ "barCopper,5"  ], ["hammer,1", "saw,1"], 25, ColorLib.Copper, [ new("Skill", 7, "Construction")], station: "Sink"));
                toAdd.Add(new("Sink", "Pump and tub", "Shelves full of kitchen utensils.", [ "barIron,10"  ], ["hammer,1", "saw,1"], 150, ColorLib.Iron, [ new("Skill", 27, "Construction")], station: "Sink"));
                toAdd.Add(new("Sink", "Sink", "Shelves full of kitchen utensils.", [ "barGold,15"  ], ["hammer,1", "saw,1"], 375, ColorLib.Gold, [ new("Skill", 47, "Construction")], station: "Sink"));
                
                toAdd.Add(new("Spice Rack", "Spice rack", "Rack used to store spices.", [ "plankHickory,3", "nailsSteel,6", "claySoft,6", "spiceBrown", "spiceOrange", "spiceRed", "spiceYellow"  ], ["hammer,1", "saw,1"], 630, ColorLib.Hickory, [ new("Skill", 60, "Construction")]) { ShopItems = [ "spiceBrown", "spiceOrange", "spiceRed", "spiceYellow", "spiceGnome" ]});
            
                toAdd.Add(new("Stove", "Firepit", "A basic cooking fire.", [ "barCopper,1", "claySoft,2" ], ["hammer,1", "saw,1"], 25, Color.SandyBrown, [ new("Skill", 5, "Construction")], station: "Fire"));
                toAdd.Add(new("Stove", "Firepit with hook", "A cooking fire.", [ "barBronze,2", "claySoft,2" ], ["hammer,1", "saw,1"], 40, Color.SandyBrown, [ new("Skill", 11, "Construction")], station: "Fire"));
                toAdd.Add(new("Stove", "Small oven", "Good for baking bread.", [ "barIron,4" ], ["hammer,1", "saw,1"], 60, Color.SandyBrown, [ new("Skill", 24, "Construction")], station: "Fire"));
                toAdd.Add(new("Stove", "Large oven", "Good for baking pizza.", [ "barIron,5" ], ["hammer,1", "saw,1"], 75, Color.SandyBrown, [ new("Skill", 29, "Construction")], station: "Fire"));
                toAdd.Add(new("Stove", "Silver range", "Finally a proper range.", [ "barSilver,6" ], ["hammer,1", "saw,1"], 120, ColorLib.Silver, [ new("Skill", 34, "Construction")], station: "Range"));
                toAdd.Add(new("Stove", "Gold range", "A fairly fancy frange.", [ "barGold,8" ], ["hammer,1", "saw,1"], 200, ColorLib.Gold, [ new("Skill", 42, "Construction")], station: "Range"));
            }

            // Workshop
            {
                toAdd.Add(new("Tool Rack", "Basic tool rack", "Provides saws, hammers, chisels, and shears.", [ "plankElm,2", "nailsBronze,4"  ], ["hammer,1", "saw,1"], 120, ColorLib.Elm, [ new("Skill", 15, "Construction")], shops: [ "saw", "hammer", "chisel", "shears" ]));
                toAdd.Add(new("Tool Rack", "Advanced tool rack", "Basic Tool Rack, but also buckets, knives, spades, and tinderboxes.", [ "plankWalnut,2", "nailsIron,4"  ], ["hammer,1", "saw,1"], 180, ColorLib.Walnut, [ new("Skill", 25, "Construction")], shops: [ "saw", "hammer", "chisel", "shears", "bucketEmpty", "knife", "shovel", "tinderbox" ]));
                toAdd.Add(new("Tool Rack", "Expert tool rack", "Advanced Tool Rack, but also brown aprons, glassblowing pipes, and needles.", [ "plankHolly,2", "nailsSilver,4"  ], ["hammer,1", "saw,1"], 240, ColorLib.Holly, [ new("Skill", 35, "Construction")], shops: [ "saw", "hammer", "chisel", "shears", "bucketEmpty", "knife", "shovel", "tinderbox", "brownApron", "glassblowingPipe", "needle" ]));
                toAdd.Add(new("Tool Rack", "Master tool rack", "Expert Tool Rack, but also amulet, necklace, ring, holy symbol, bracelet, and tiara moulds.", [ "plankAcacia,2", "nailsGold,4"  ], ["hammer,1", "saw,1"], 300, ColorLib.Acacia, [ new("Skill", 44, "Construction")], shops: [ "saw", "hammer", "chisel", "shears", "bucketEmpty", "knife", "shovel", "tinderbox", "brownApron", "glassblowingPipe", "needle" ]));
            
                toAdd.Add(new("Primary Station", "Pottery wheel", "Allows you to work clay.", [ "blockLimestone,1", "plankElm,2", "nailsBronze,4" ], ["hammer,1", "saw,1"], 75, Color.DimGray, [ new("Skill", 10, "Construction")], station: "Pottery Wheel"));
                toAdd.Add(new("Primary Station", "Alchemy workbench", "Makes it easier to turn herbs into potions.", [ "plankWalnut,4", "nailsIron,8" ], ["hammer,1", "saw,1"], 360, ColorLib.Walnut, [ new("Skill", 20, "Construction")], station: "Alchemy Workbench"));
            
                toAdd.Add(new("Primary Station", "Copper anvil", "Allows you to work metals up to Copper.", [ "barCopper,5", "plankPoplar,2", "nailsCopper,4" ], ["hammer,1", "saw,1"], 85, ColorLib.Copper, [ new("Skill", 1, "Construction")], station: "Copper Anvil"));
                toAdd.Add(new("Primary Station", "Bronze anvil", "Allows you to work metals up to Bronze.", [ "barBronze,5", "plankElm,2", "nailsBronze,4" ], ["hammer,1", "saw,1"], 170, ColorLib.Bronze, [ new("Skill", 10, "Construction")], station: "Bronze Anvil"));
                toAdd.Add(new("Primary Station", "Iron anvil", "Allows you to work metals up to Iron.", [ "barIron,5", "plankWalnut,2", "nailsIron,4" ], ["hammer,1", "saw,1"], 255, ColorLib.Iron, [ new("Skill", 20, "Construction")], station: "Iron Anvil"));
                toAdd.Add(new("Primary Station", "Silver anvil", "Allows you to work metals up to Silver.", [ "barSilver,5", "plankHolly,2", "nailsSilver,4" ], ["hammer,1", "saw,1"], 340, ColorLib.Silver, [ new("Skill", 30, "Construction")], station: "Silver Anvil"));
                toAdd.Add(new("Primary Station", "Gold anvil", "Allows you to work metals up to Gold.", [ "barGold,5", "plankAcacia,2", "nailsGold,4" ], ["hammer,1", "saw,1"], 425, ColorLib.Gold, [ new("Skill", 40, "Construction")], station: "Gold Anvil"));
                toAdd.Add(new("Primary Station", "Platinum anvil", "Allows you to work metals up to Platinum.", [ "barPlatinum,5", "plankBirch,2", "nailsPlatinum,4" ], ["hammer,1", "saw,1"], 510, ColorLib.Platinum, [ new("Skill", 50, "Construction")], station: "Platinum Anvil"));
                toAdd.Add(new("Primary Station", "Steel anvil", "Allows you to work metals up to Steel.", [ "barSteel,5", "plankHickory,2", "nailsSteel,4" ], ["hammer,1", "saw,1"], 595, ColorLib.Steel, [ new("Skill", 60, "Construction")], station: "Steel Anvil"));
                toAdd.Add(new("Primary Station", "Cobalt anvil", "Allows you to work metals up to Cobalt.", [ "barCobalt,5", "plankBloodwood,2", "nailsCobalt,4" ], ["hammer,1", "saw,1"], 680, ColorLib.Cobalt, [ new("Skill", 70, "Construction")], station: "Cobalt Anvil"));
                toAdd.Add(new("Primary Station", "Tungsten anvil", "Allows you to work metals up to Tungsten.", [ "barTungsten,5", "plankCamatillo,2", "nailsTungsten,4" ], ["hammer,1", "saw,1"], 765, ColorLib.Tungsten, [ new("Skill", 80, "Construction")], station: "Tungsten Anvil"));
                toAdd.Add(new("Primary Station", "Titanium anvil", "Allows you to work metals up to Titanium.", [ "barTitanium,5", "plankKatalox,2", "nailsTitanium,4" ], ["hammer,1", "saw,1"], 850, ColorLib.Titanium, [ new("Skill", 90, "Construction")], station: "Titanium Anvil"));
            
                toAdd.Add(new("Secondary Station", "Copper furnace", "Allows you to smelt metals up to Copper.", [ "barCopper,15", "plankPoplar,2", "nailsCopper,4" ], ["hammer,1", "saw,1"], 135, ColorLib.Copper, [ new("Skill", 1, "Construction")], station: "Copper Furnace"));
                toAdd.Add(new("Secondary Station", "Bronze furnace", "Allows you to smelt metals up to Bronze.", [ "barBronze,15", "plankElm,2", "nailsBronze,4" ], ["hammer,1", "saw,1"], 270, ColorLib.Bronze, [ new("Skill", 10, "Construction")], station: "Bronze Furnace"));
                toAdd.Add(new("Secondary Station", "Iron furnace", "Allows you to smelt metals up to Iron.", [ "barIron,15", "plankWalnut,2", "nailsIron,4" ], ["hammer,1", "saw,1"], 405, ColorLib.Iron, [ new("Skill", 20, "Construction")], station: "Iron Furnace"));
                toAdd.Add(new("Secondary Station", "Silver furnace", "Allows you to smelt metals up to Silver.", [ "barSilver,15", "plankHolly,2", "nailsSilver,4" ], ["hammer,1", "saw,1"], 540, ColorLib.Silver, [ new("Skill", 30, "Construction")], station: "Silver Furnace"));
                toAdd.Add(new("Secondary Station", "Gold furnace", "Allows you to smelt metals up to Gold.", [ "barGold,15", "plankAcacia,2", "nailsGold,4" ], ["hammer,1", "saw,1"], 675, ColorLib.Gold, [ new("Skill", 40, "Construction")], station: "Gold Furnace"));
                toAdd.Add(new("Secondary Station", "Platinum furnace", "Allows you to smelt metals up to Platinum.", [ "barPlatinum,15", "plankBirch,2", "nailsPlatinum,4" ], ["hammer,1", "saw,1"], 810, ColorLib.Platinum, [ new("Skill", 50, "Construction")], station: "Platinum Furnace"));
                toAdd.Add(new("Secondary Station", "Steel furnace", "Allows you to smelt metals up to Steel.", [ "barSteel,15", "plankHickory,2", "nailsSteel,4" ], ["hammer,1", "saw,1"], 945, ColorLib.Steel, [ new("Skill", 60, "Construction")], station: "Steel Furnace"));
                toAdd.Add(new("Secondary Station", "Cobalt furnace", "Allows you to smelt metals up to Cobalt.", [ "barCobalt,15", "plankBloodwood,2", "nailsCobalt,4" ], ["hammer,1", "saw,1"], 1080, ColorLib.Cobalt, [ new("Skill", 70, "Construction")], station: "Cobalt Furnace"));
                toAdd.Add(new("Secondary Station", "Tungsten furnace", "Allows you to smelt metals up to Tungsten.", [ "barTungsten,15", "plankCamatillo,2", "nailsTungsten,4" ], ["hammer,1", "saw,1"], 1215, ColorLib.Tungsten, [ new("Skill", 80, "Construction")], station: "Tungsten Furnace"));
                toAdd.Add(new("Secondary Station", "Titanium furnace", "Allows you to smelt metals up to Titanium.", [ "barTitanium,15", "plankKatalox,2", "nailsTitanium,4" ], ["hammer,1", "saw,1"], 1350, ColorLib.Titanium, [ new("Skill", 90, "Construction")], station: "Titanium Furnace"));
            
                toAdd.Add(new("Secondary Station", "Pottery kiln", "Fires pottery into ceramics.", [ "claySoft,12" ], ["hammer,1", "saw,1"], 120, Color.SandyBrown, [ new("Skill", 10, "Construction")], station: "Pottery Kiln"));
                toAdd.Add(new("Secondary Station", "Crucible", "Allows you to cast molten metal into shape with moulds.", [ "barIron,15" ], ["hammer,1", "saw,1"], 225, Color.DarkGray, [ new("Skill", 20, "Construction")], station: "Casting"));
                toAdd.Add(new("Secondary Station", "Spinning wheel", "Spins fibers into fabrics.", [ "plankWalnut,4", "nailsIron,8" ], ["hammer,1", "saw,1"], 360, ColorLib.Walnut, [ new("Skill", 20, "Construction")], station: "Spinning Wheel"));
                toAdd.Add(new("Secondary Station", "Tanning rack", "Turns hides into leather.", [ "plankWalnut,8", "nailsIron,16" ], ["hammer,1", "saw,1"], 720, ColorLib.Walnut, [ new("Skill", 20, "Construction")], station: "Tannery"));
                    /*
                    toAdd.Add(new("Clockwork Bench", "Toy bench", "Create toy horseys and wooden cats.", [ "plankElm,4", "nailsBronze,8" ], ["hammer,1", "saw,1"], 240, Color.SandyBrown, [ new("Skill", 16, "Construction")], station: "Toy Bench"));
                    toAdd.Add(new("Clockwork Bench", "Basic clockwork bench", "Toy bench, but also clockwork mechanisms.", [ "plankWalnut,4", "nailsIron,8", "glassMolten,1" ], ["hammer,1", "saw,1"], 370, Color.SandyBrown, [ new("Skill", 25, "Construction")], station: "Basic Clockwork"));
                    toAdd.Add(new("Clockwork Bench", "Advanced clockwork bench", "Basic clockwork bench, but also toy soldiers, toy dolls, and clockwork suits.", [ "plankHolly,4", "nailsSilver,8", "glassMolten,3" ], ["hammer,1", "saw,1"], 510, Color.SandyBrown, [ new("Skill", 34, "Construction")], station: "Advanced Clockwork"));
                    toAdd.Add(new("Clockwork Bench", "Expert clockwork bench", "Create toy horseys and wooden cats.", [ "plankAcacia,6", "nailsGold,8", "glassMolten,3" ], ["hammer,1", "saw,1"], 830, Color.SandyBrown, [ new("Skill", 42, "Construction")], station: "Expert Clockwork"));
                    */
            }

            for (int i = 0; i < toAdd.Count; i++) { 
                ObjLib.Add(toAdd[i].Name, toAdd[i]);
            }
        }
    }
}
