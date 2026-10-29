using WorldtreeNexus.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedGathering {
        public static void InitGathers(Dictionary<string, GatheringTile> GatherSpots) {
            List<GatheringTile> tiles = new();
            tiles.Add(new GatheringTile("plantFlax", "Wild Flax", "Pick", 60, 10, items: new() { new("flax", 1) })); 
            tiles.Add(new GatheringTile("plantPotato", "Potato Plant", "Pick", 100, 5, items: new() { new("potato", 1) })); 
            tiles.Add(new GatheringTile("plantCabbage", "Cabbage Plant", "Pick", 100, 5, items: new() { new("cabbage", 1) })); 
            tiles.Add(new GatheringTile("plantOnion", "Onion Plant", "Pick", 100, 5, items: new() { new("onion", 1) })); 
            tiles.Add(new GatheringTile("plantGrain", "Wheat", "Pick", 100, 5, items: new() { new("grain", 1) })); 
            tiles.Add(new GatheringTile("plantNightshade", "Nightshade Bush", "Pick", 100, 30, items: new() { new("nightshade", 1) }));
            tiles.Add(new GatheringTile("plantBlueberry", "Blueberry Bush", "Pick", 100, 30, items: new() { new("blueberry", 1) }));
            tiles.Add(new GatheringTile("plantNeela", "Neela Bush", "Pick", 100, 5, items: new() { new("grimyNeela", 1) }));
            tiles.Add(new GatheringTile("plantMidori", "Midori Bush", "Pick", 100, 5, items: new() { new("grimyMidori", 1) }));

            tiles.Add(new GatheringTile("treePoplar", "Poplar Tree", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: new() { new("logPoplar", 1) }));
            tiles.Add(new GatheringTile("rootsPoplar", "Poplar Roots", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: new() { new("logPoplar", 1) }));
            tiles.Add(new GatheringTile("treeDead", "Dead Tree", "Chop", 100, 10, "Woodcutting", 1, 25, neededTool: "Hatchet", items: new() { new("logPoplar", 1) }));
            tiles.Add(new GatheringTile("treeElm", "Elm Tree", "Chop", 70, 20, "Woodcutting", 10, 38, neededTool: "Hatchet", items: new() { new("logElm", 1) }));
            tiles.Add(new GatheringTile("treeWalnut", "Walnut Tree", "Chop", 70, 20, "Woodcutting", 20, 68, neededTool: "Hatchet", items: new() { new("logWalnut", 1) }));
            tiles.Add(new GatheringTile("treeHolly", "Holly Tree", "Chop", 70, 20, "Woodcutting", 30, 85, neededTool: "Hatchet", items: new() { new("logHolly", 1) }));
            tiles.Add(new GatheringTile("treeAcacia", "Acacia Tree", "Chop", 60, 30, "Woodcutting", 40, neededTool: "Hatchet", items: new() { new("logAcacia", 1) }));
            tiles.Add(new GatheringTile("treeBirch", "Birch Tree", "Chop", 60, 30, "Woodcutting", 50, 80, neededTool: "Hatchet", items: new() { new("logBirch", 1) }));
            tiles.Add(new GatheringTile("treeHickory", "Hickory Tree", "Chop", 50, 40, "Woodcutting", 60, 125, neededTool: "Hatchet", items: new() { new("logHickory", 1) }));
            tiles.Add(new GatheringTile("treeBloodwood", "Bloodwood Tree", "Chop", 50, 40, "Woodcutting", 70, 188, neededTool: "Hatchet", items: new() { new("logBloodwood", 1) }));
            tiles.Add(new GatheringTile("treeCamatillo", "Camatillo Tree", "Chop", 40, 50, "Woodcutting", 80, 365, neededTool: "Hatchet", items: new() { new("logCamatillo", 1) }));
            tiles.Add(new GatheringTile("treeKatalox", "Katalox Tree", "Chop", 30, 60, "Woodcutting", 90, 425, neededTool: "Hatchet", items: new() { new("logKatalox", 1) }));

            tiles.Add(new GatheringTile("rockClay", "Clay Deposit", "Mine", 20, 10, "Mining", 1, 5, neededTool: "Pickaxe", items: new() { new("clayDust", 1) }) ); 
            tiles.Add(new GatheringTile("rockGemCommon", "Gem Rock (Common)", "Mine", 100, 8, "Mining", 1, 10, neededTool: "Pickaxe", items: new() { new("uncutQuartz", 3), new("uncutGarnet", 2, "Mining", 10, 20), new("uncutEmerald", 1, "Mining", 20, 30) }));
            tiles.Add(new GatheringTile("rockGemUncommon", "Gem Rock (Uncommon)", "Mine", 100, 8, "Mining", 20, 30, neededTool: "Pickaxe", items: new() { new("uncutEmerald", 3), new("uncutSapphire", 2, "Mining", 30, 40), new("uncutRuby", 1, "Mining", 40, 50) }));
            tiles.Add(new GatheringTile("oreCopper", "Copper Ore", "Mine", 100, 5, "Mining", 1, 10, neededTool: "Pickaxe", items: new() { new("oreCopper", 1) }));
            tiles.Add(new GatheringTile("oreTin", "Tin Ore", "Mine", 100, 6, "Mining", 10, 20, neededTool: "Pickaxe", items: new() { new("oreTin", 1) }));
            tiles.Add(new GatheringTile("oreIron", "Iron Ore", "Mine", 100, 7, "Mining", 20, 30, neededTool: "Pickaxe", items: new() { new("oreIron", 1) }));
            tiles.Add(new GatheringTile("oreSilver", "Silver Ore", "Mine", 100, 8, "Mining", 30, 40, neededTool: "Pickaxe", items: new() { new("oreSilver", 1) }));
            tiles.Add(new GatheringTile("oreGold", "Gold Ore", "Mine", 100, 9, "Mining", 40, 50, neededTool: "Pickaxe", items: new() { new("oreGold", 1) }));
            tiles.Add(new GatheringTile("orePlatinum", "Platinum Ore", "Mine", 100, 10, "Mining", 50, 60, neededTool: "Pickaxe", items: new() { new("orePlatinum", 1) }));
            tiles.Add(new GatheringTile("oreCoal", "Coal Ore", "Mine", 100, 11, "Mining", 60, 70, neededTool: "Pickaxe", items: new() { new("oreCoal", 1) }));
            tiles.Add(new GatheringTile("oreCobalt", "Cobalt Ore", "Mine", 100, 12, "Mining", 70, 80, neededTool: "Pickaxe", items: new() { new("oreCobalt", 1) }));
            tiles.Add(new GatheringTile("oreTungsten", "Tungsten Ore", "Mine", 100, 13, "Mining", 80, 90, neededTool: "Pickaxe", items: new() { new("oreTungsten", 1) }));
            tiles.Add(new GatheringTile("oreTitanium", "Titanium Ore", "Mine", 100, 14, "Mining", 90, 100, neededTool: "Pickaxe", items: new() { new("oreTitanium", 1) }));

            tiles.Add(new GatheringTile("fishPondShallow", "Pond Shallows", "Fish", 10, 15, "Fishing", 1, 10, neededTool: "Fishing rod", items: new() { new("fishRawMinnow", 3), new("fishRawBluegill", 1, "Fishing", 5, 15) }));
            tiles.Add(new GatheringTile("fishSeaShallow", "Sea Shallows", "Fish", 10, 15, "Fishing", 1, 10, neededTool: "Fishing rod", items: new() { new("fishRawPollock", 3), new("fishRawCod", 1, "Fishing", 5, 15) }));
            tiles.Add(new GatheringTile("fishPondDeep", "Pond Deeps", "Fish", 10, 15, "Fishing", 10, 20, neededTool: "Fishing rod", items: new() { new("fishRawMinnow", 3), new("fishRawBluegill", 1, "Fishing", 10, 25) }));
            

            tiles.Add(new GatheringTile("stallVegetable", "Vegetable Stall", "Steal from", 30, 10, "Thieving", 2, 10, items: new() { new("potato", 2), new("onion", 2), new("cabbage", 2), new("tomato", 2), new("garlic", 1) }));
            tiles.Add(new GatheringTile("stallBakery", "Bakery Stall", "Steal from", 30, 10, "Thieving", 5, 16, items: new() { new("bread", 4), new("cake", 5) }));
            tiles.Add(new GatheringTile("stallCrafting", "Crafting Stall", "Steal from", 30, 10, "Thieving", 10, 16, items: new() { new("chisel", 1), new("mouldNecklace", 5), new("mouldRing", 1) }));
            tiles.Add(new GatheringTile("stallWine", "Wine Stall", "Steal from", 30, 10, "Thieving", 22, 27, items: new() { new("jugEmpty", 12), new("jugWater", 5), new("grapes", 6), new("jugWine", 5), new("bottleWine", 2) }));
            tiles.Add(new GatheringTile("stallSeed", "Seed Stall", "Steal from", 30, 10, "Thieving", 27, 10, items: new() { new("seedPotato", 15), new("seedOnion", 15), new("seedCabbage", 12), new("seedTomato", 5), new("seedSweetcorn", 6), new("seedWatermelon", 2), new("seedBarley", 16), new("seedHammerstone", 20), new("seedAsgarnian", 11), new("seedJute", 7), new("seedYanillian", 9), new("seedKrandorian", 4), new("seedWildblood", 1), new("seedMarigold", 20), new("seedRosemary", 6), new("seedNasturtium", 4) }));


            tiles.Add(new GatheringTile("sheep", "Sheep", "Shear", 100, 5, "Farming", 0, 0, "Shears", items: [ new("woolRaw", 1) ]));
            tiles.Add(new GatheringTile("clueCrates", "Crates", "Search", 100, 5, items: [ new("knife", 1, reqs: [ new("NotItem", 1, "knife") ]), new("tinderbox", 1, reqs: [ new("NotItem", 1, "tinderbox") ]), new("shovel", 1, reqs: [ new("NotItem", 1, "shovel") ]), new("needle", 1, reqs: [ new("NotItem", 1, "needle") ]), new("chisel", 1, reqs: [ new("NotItem", 1, "chisel") ]), new("shears", 1, reqs: [ new("NotItem", 1, "shears") ]), new("saw", 1, reqs: [ new("NotItem", 1, "saw") ])] ));
            tiles.Add(new GatheringTile("clueBoxes", "Boxes", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueBookcase", "Bookcase", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueDrawers", "Drawers", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueBarrel", "Barrel", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueChest", "Chest", "Search", 100, 5));
            tiles.Add(new GatheringTile("clueWardrobe", "Wardrobe", "Search", 100, 5));
            tiles.Add(new GatheringTile("bookshelfWizard", "Bookshelves", "Search", 100, 0));
            tiles.Add(new GatheringTile("altar", "Altar", "Pray at", 100, 0, actions: [ new("RefillPrayer", "", "", 0) ]));
            
            tiles.Add(new GatheringTile("clueDrawersLocked", "Drawers", "Search", 100, 5, neededBait: "keyClue"));

            tiles.Add(new GatheringTile("dummyAttack", "Attack Dummy", "Strike", 100, 1, items: [ new("_Attack", 1, "Attack", 1, 5)], reqs: [ new("NotSkill", 8, "Attack", summ: "Must not be above level 8 Attack.") ])); 
            tiles.Add(new GatheringTile("dummyStrength", "Strength Dummy", "Strike", 100, 1, items: [ new("_Strength", 1, "Strength", 1, 5)], reqs: [ new("NotSkill", 8, "Strength", summ: "Must not be above level 8 Strength.") ])); 
            
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
