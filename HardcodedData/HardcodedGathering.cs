using WorldtreeNexus.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedGathering {
        public static void InitGathers(Dictionary<string, GatheringTile> GatherSpots) {
            // These use ItemDrop tables
            List<GatheringTile> tiles = new();
            tiles.Add(new GatheringTile("attunementObelisk", "Elemental Obelisk", "Attune Self at", 100, 0, actions: [ new("ChangeAttunement", "", "", 0)], customLog: "_"));
            tiles.Add(new GatheringTile("shoplift", "Here", "Shoplift", 100, 0, actions: [ new("ChangeAttunement", "", "", 0)], customLog: "_"));


            tiles.Add(new GatheringTile("plantFlax", "Wild Flax", "Pick", 60, 10, items: [ new("flax") ])); 
            tiles.Add(new GatheringTile("plantPotato", "Potato Plant", "Pick", 100, 5, items: [ new("potato") ])); 
            tiles.Add(new GatheringTile("plantCabbage", "Cabbage Plant", "Pick", 100, 5, items: [ new("cabbage") ])); 
            tiles.Add(new GatheringTile("plantOnion", "Onion Plant", "Pick", 100, 5, items: [ new("onion") ])); 
            tiles.Add(new GatheringTile("plantGrain", "Wheat", "Pick", 100, 5, items: [ new("grain") ])); 
            tiles.Add(new GatheringTile("plantNightshade", "Nightshade Bush", "Pick", 100, 30, items: [ new("nightshade") ]));
            tiles.Add(new GatheringTile("plantBlueberry", "Blueberry Bush", "Pick", 100, 30, items: [ new("blueberry") ]));
            tiles.Add(new GatheringTile("plantNeela", "Neela Bush", "Pick", 100, 5, items: [ new("grimyNeela") ]));
            tiles.Add(new GatheringTile("plantMidori", "Midori Bush", "Pick", 100, 5, items: [ new("grimyMidori") ]));

            tiles.Add(new GatheringTile("treePoplar", "Poplar Tree", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: [ new("logPoplar") ]));
            tiles.Add(new GatheringTile("rootsPoplar", "Poplar Roots", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: [ new("logPoplar") ]));
            tiles.Add(new GatheringTile("treeDead", "Dead Tree", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: [ new("logPoplar") ]));
            tiles.Add(new GatheringTile("treeElm", "Elm Tree", "Chop", 70, 20, "Woodcutting", 10, 38, neededTool: "Hatchet", items: [ new("logElm") ]));
            tiles.Add(new GatheringTile("treeWalnut", "Walnut Tree", "Chop", 70, 20, "Woodcutting", 20, 68, neededTool: "Hatchet", items: [ new("logWalnut") ]));
            tiles.Add(new GatheringTile("treeHolly", "Holly Tree", "Chop", 70, 20, "Woodcutting", 30, 85, neededTool: "Hatchet", items: [ new("logHolly") ]));
            tiles.Add(new GatheringTile("treeAcacia", "Acacia Tree", "Chop", 60, 30, "Woodcutting", 40, neededTool: "Hatchet", items: [ new("logAcacia") ]));
            tiles.Add(new GatheringTile("treeBirch", "Birch Tree", "Chop", 60, 30, "Woodcutting", 50, 80, neededTool: "Hatchet", items: [ new("logBirch") ]));
            tiles.Add(new GatheringTile("treeHickory", "Hickory Tree", "Chop", 50, 40, "Woodcutting", 60, 125, neededTool: "Hatchet", items: [ new("logHickory") ]));
            tiles.Add(new GatheringTile("treeBloodwood", "Bloodwood Tree", "Chop", 50, 40, "Woodcutting", 70, 188, neededTool: "Hatchet", items: [ new("logBloodwood") ]));
            tiles.Add(new GatheringTile("treeCamatillo", "Camatillo Tree", "Chop", 40, 50, "Woodcutting", 80, 365, neededTool: "Hatchet", items: [ new("logCamatillo") ]));
            tiles.Add(new GatheringTile("treeKatalox", "Katalox Tree", "Chop", 30, 60, "Woodcutting", 90, 425, neededTool: "Hatchet", items: [ new("logKatalox") ]));

            tiles.Add(new GatheringTile("rockClay", "Clay Deposit", "Mine", 20, 10, "Mining", 1, 5, neededTool: "Pickaxe", items: [ new("clayDust") ])); 
            tiles.Add(new GatheringTile("rockGemCommon", "Gem Rock (Common)", "Mine", 100, 8, "Mining", 1, 10, neededTool: "Pickaxe", items: [ new("uncutQuartz"), new("uncutGarnet", y: 3, reqs: [new("Skill", 10, "Mining")], altexp: 20), new("uncutEmerald", y: 5, reqs: [new("Skill", 20, "Mining")], altexp: 30) ]));
            tiles.Add(new GatheringTile("rockGemUncommon", "Gem Rock (Uncommon)", "Mine", 100, 8, "Mining", 20, 30, neededTool: "Pickaxe", items: [ new("uncutEmerald"), new("uncutSapphire", y: 3, reqs: [new("Skill", 30, "Mining")], altexp: 40), new("uncutRuby", y: 5, reqs: [new("Skill", 40, "Mining")], altexp: 50) ]));
            tiles.Add(new GatheringTile("oreCopper", "Copper Ore", "Mine", 100, 5, "Mining", 1, 10, neededTool: "Pickaxe", items: [ new("oreCopper") ]));
            tiles.Add(new GatheringTile("oreTin", "Tin Ore", "Mine", 100, 6, "Mining", 10, 20, neededTool: "Pickaxe", items: [ new("oreTin") ]));
            tiles.Add(new GatheringTile("oreIron", "Iron Ore", "Mine", 100, 7, "Mining", 20, 30, neededTool: "Pickaxe", items: [ new("oreIron") ]));
            tiles.Add(new GatheringTile("oreSilver", "Silver Ore", "Mine", 100, 8, "Mining", 30, 40, neededTool: "Pickaxe", items: [ new("oreSilver") ]));
            tiles.Add(new GatheringTile("oreGold", "Gold Ore", "Mine", 100, 9, "Mining", 40, 50, neededTool: "Pickaxe", items: [ new("oreGold") ]));
            tiles.Add(new GatheringTile("orePlatinum", "Platinum Ore", "Mine", 100, 10, "Mining", 50, 60, neededTool: "Pickaxe", items: [ new("orePlatinum") ]));
            tiles.Add(new GatheringTile("oreCoal", "Coal Ore", "Mine", 100, 11, "Mining", 60, 70, neededTool: "Pickaxe", items: [ new("oreCoal") ]));
            tiles.Add(new GatheringTile("oreCobalt", "Cobalt Ore", "Mine", 100, 12, "Mining", 70, 80, neededTool: "Pickaxe", items: [ new("oreCobalt") ]));
            tiles.Add(new GatheringTile("oreTungsten", "Tungsten Ore", "Mine", 100, 13, "Mining", 80, 90, neededTool: "Pickaxe", items: [ new("oreTungsten") ]));
            tiles.Add(new GatheringTile("oreTitanium", "Titanium Ore", "Mine", 100, 14, "Mining", 90, 100, neededTool: "Pickaxe", items: [ new("oreTitanium") ]));

            tiles.Add(new GatheringTile("fishPondShallow", "Pond Shallows", "Fish", 10, 15, "Fishing", 1, 10, neededTool: "Fishing rod", items: [ new("fishRawMinnow"), new("fishRawBluegill", y: 3, reqs: [new("Skill", 5, "Fishing")], altexp: 15) ]));
            tiles.Add(new GatheringTile("fishSeaShallow", "Sea Shallows", "Fish", 10, 15, "Fishing", 1, 10, neededTool: "Fishing rod", items: [ new("fishRawPollock"), new("fishRawCod", y: 3, reqs: [new("Skill", 5, "Fishing")], altexp: 15) ]));
            

            tiles.Add(new GatheringTile("stallSeedLow", "Seed Stall", "Steal from", 30, 10, "Thieving", 1, 10, items: [ ..DropTables.SeedsAllLow ]));
            tiles.Add(new GatheringTile("stallBaker", "Baker Stall", "Steal from", 30, 10, "Thieving", 1, 10, items: [ ..DropTables.SeedsAllLow ]));
            
            
            tiles.Add(new GatheringTile("jobHandyHaversack", "The Handy Haversack", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "The Handy Haversack", "", 100)], customLog: "_"));
            tiles.Add(new GatheringTile("jobFarmersMarket", "The Farmer's Market", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "The Farmer's Market", "", 100)], customLog: "_"));
            tiles.Add(new GatheringTile("jobFeedSeed", "Feed and Seed", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "Feed and Seed", "Farming", 50)], customLog: "_"));
            tiles.Add(new GatheringTile("jobPotentPotables", "Potent Potables", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "Potent Potables", "Alchemy", 50)], customLog: "_"));
            tiles.Add(new GatheringTile("jobCraftyCrafters", "Crafty Crafters", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "Crafty Crafters", "Crafting", 50)], customLog: "_"));
            tiles.Add(new GatheringTile("jobMeatCute", "Meat Cute", "Work at", 100, 0, reqs: [ new("TimeBetween", 540, miscint2: 1260)], actions: [ new("HourlyJob", "Meat Cute", "Cooking", 50)], customLog: "_"));

            tiles.Add(new GatheringTile("innSleepMorning", "(100gp)", "Sleep until Morning", 100, 0, reqs: [ new("Item", 100, "Gold") ], actions: [ new("SleepInn", "Morning", "", 100)], customLog: "_"));
            tiles.Add(new GatheringTile("innSleepAfternoon", "(100gp)", "Sleep until Noon", 100, 0, reqs: [ new("Item", 100, "Gold") ], actions: [ new("SleepInn", "Afternoon", "", 100)], customLog: "_"));
            tiles.Add(new GatheringTile("innSleepNight", "(100gp)", "Sleep until Night", 100, 0, reqs: [ new("Item", 100, "Gold") ], actions: [ new("SleepInn", "Night", "", 100)], customLog: "_"));
            tiles.Add(new GatheringTile("innSleepMidnight", "(100gp)", "Sleep until Midnight", 100, 0, reqs: [ new("Item", 100, "Gold") ], actions: [ new("SleepInn", "Midnight", "", 100)], customLog: "_"));


            tiles.Add(new GatheringTile("sheep", "Sheep", "Shear", 100, 5, "Farming", 0, 0, "Shears", items: [ new("woolRaw") ]));
            tiles.Add(new GatheringTile("clueCrates", "Crates", "Search", 100, 5, items: [ new("knife", reqs: [ new("NotItem", 1, "knife") ]), new("tinderbox", reqs: [ new("NotItem", 1, "tinderbox") ]), new("shovel", reqs: [ new("NotItem", 1, "shovel") ]), new("needle", reqs: [ new("NotItem", 1, "needle") ]), new("chisel", reqs: [ new("NotItem", 1, "chisel") ]), new("shears", reqs: [ new("NotItem", 1, "shears") ]), new("saw", reqs: [ new("NotItem", 1, "saw") ])] ));
            tiles.Add(new GatheringTile("clueBoxes", "Boxes", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueBookcase", "Bookcase", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueDrawers", "Drawers", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueBarrel", "Barrel", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueChest", "Chest", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueWardrobe", "Wardrobe", "Search", 100, 5));
            tiles.Add(new GatheringTile("bookshelfWizard", "Bookshelves", "Search", 100, 0));
            tiles.Add(new GatheringTile("altar", "Altar", "Pray at", 100, 0, actions: [ new("RefillPrayer", "", "", 0) ]));
            
            tiles.Add(new GatheringTile("clueDrawersLocked", "Drawers", "Search", 100, 5, neededBait: "keyClue"));

            tiles.Add(new GatheringTile("dummyAttack", "Attack Dummy", "Strike", 100, 1, "Attack", 1, 5, items: [ new("_Attack") ], reqs: [ new("NotSkill", 8, "Attack", summ: "Must not be above level 8 Attack.") ])); 
            tiles.Add(new GatheringTile("dummyStrength", "Strength Dummy", "Strike", 100, 1, "Strength", 1, 5, items: [ new("_Strength")], reqs: [ new("NotSkill", 8, "Strength", summ: "Must not be above level 8 Strength.") ])); 
            
            tiles.Add(new GatheringTile("tombstone1", "Tombstone", "Read", 100, 0, customLog: "The tombstone reads: 'I told you I was sick.'."));
            tiles.Add(new GatheringTile("tombstone2", "Tombstone", "Read", 100, 0, customLog: "A tombstone dedicated to John Gold. It reads: 'Reader, if cash thou art in want, dig four feet deep and thou wilt find a Gold.'."));
            tiles.Add(new GatheringTile("tombstone3", "Tombstone", "Read", 100, 0, customLog: "The tombstone reads: 'I was somebody. Who, is no business of yours.'."));
            tiles.Add(new GatheringTile("tombstone4", "Tombstone", "Read", 100, 0, customLog: "The tombstone reads: 'It's dark down here!'."));


            tiles.Add(new GatheringTile("leptocClean", "Room", "Clean", 100, 60, actions: [ new("LeptocClean", "", "", 0) ]));
            tiles.Add(new GatheringTile("leptocPiano", "Piano", "Play", 100, 0));
            

            for (int i = 0; i < tiles.Count; i++) {
                GatherSpots.Add(tiles[i].ID, tiles[i]);
            } 
        }
    }
}
