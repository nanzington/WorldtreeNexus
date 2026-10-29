using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItems {
        public static void InitItems(Dictionary<string, Item> ItemLibrary, Dictionary<string, Spell> SpellLib) {

            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Limestone brick", "A well carved limestone block.", "blockLimestone", Color.DarkGray, 20));
            itemsToAdd.Add(new Item("Clockwork", "A clockwork mechanism.", "clockwork", Color.DarkGray, 500));
            itemsToAdd.Add(new Item("Marble block", "A beautifully carved marble block.", "blockMarble", Color.White, 250_000));
            itemsToAdd.Add(new Item("Gold leaf", "A very delicate sheet of gold.", "goldLeaf", Color.Gold, 100_000));
            itemsToAdd.Add(new Item("Magic stone", "A magic stone to make high-level furniture.", "stoneMagic", Color.Gray, 750_000));
            itemsToAdd.Add(new Item("Condensed gold", "The gold standard of gold.", "goldCondensed", Color.Gold, 8_000_000));

            itemsToAdd.Add(new Item("Tinderbox", "An arsonist's best friend.", "tinderbox", 255, 255, 255, 5));
            itemsToAdd.Add(new Item("Ashes", "A pile of wood ash.", "ashes", 200, 200, 200, 5));
            itemsToAdd.Add(new Item("Hammer", "Good for hitting things!", "hammer", 150, 150, 150, 5));
            itemsToAdd.Add(new Item("Saw", "Good for cutting wood.", "saw", 150, 150, 150, 10)); 
            itemsToAdd.Add(new Item("Knife", "Good for chopping or whittling, not so much for stabbing.", "knife", 150, 150, 150, 5) { UseString = "Knife", ConsumedOnUse = false});
            itemsToAdd.Add(new Item("Needle", "Now to get a camel through eye of this thing...", "needle", 200, 200, 200, 1) { UseString = "Needle", ConsumedOnUse = false});
            itemsToAdd.Add(new Item("Glassblowing pipe", "Used to form molten glass into useful items.", "glassblowingPipe", ColorLib.Steel, 2) { UseString = "Glassblowing Pipe", ConsumedOnUse = false});
            itemsToAdd.Add(new Item("Feather", "I could probably make arrows with this. Or put one in my cap!", "feather", 255, 255, 255, 2, true)); 
            itemsToAdd.Add(new Item("Iron studs", "A set of studs for leather armour.", "studsIron", ColorLib.Iron, 45)); 
            itemsToAdd.Add(new Item("Shears", "Necessary to de-wool sheep.", "shears", ColorLib.Steel, 5, misc: "Shears"));
            itemsToAdd.Add(new Item("Papyrus", "Used for making notes.", "papyrus", Color.Khaki, 10));
            itemsToAdd.Add(new Item("Waterskin (0)", "A completely empty waterskin - you'll need to fill it up.", "waterskin0", Color.Khaki, 15));
            itemsToAdd.Add(new Item("Waterskin (1)", "A nearly empty waterskin with one portion of water.", "waterskin1", Color.Khaki, 18));
            itemsToAdd.Add(new Item("Waterskin (2)", "A half empty waterskin with two portions of water.", "waterskin2", Color.Khaki, 24));
            itemsToAdd.Add(new Item("Waterskin (3)", "A nearly full waterskin with three portions of water.", "waterskin3", Color.Khaki, 27));
            itemsToAdd.Add(new Item("Waterskin (4)", "A full waterskin with four portions of water.", "waterskin4", Color.Khaki, 30));
            itemsToAdd.Add(new Item("Rope", "A coil of rope.", "rope", Color.SaddleBrown, 18));
            itemsToAdd.Add(new Item("Cozy Cottages contract", "A note detailing your current active Cozy Cottages contract, if any. Activate to check.", "cozyCottagesContract", Color.Beige, 1) { UseString = "CozyCottages", ConsumedOnUse = false});
            itemsToAdd.Add(new Item("Compass", "Points to any map within 20 connections. Only considers usable primary connection destinations. May not result in fastest possible route.", "compass", ColorLib.Steel, 100) { UseString = "CompassMenu", ConsumedOnUse = false });
             
            itemsToAdd.Add(new Item("Fish bait", "For use with a fishing rod.", "baitFish", 233, 185, 93, 3, true));
             
            itemsToAdd.Add(new Item("Arrow shaft", "The most important part of an arrow.", "arrowshaft", 139, 69, 19, 2, true));
            itemsToAdd.Add(new Item("Headless shafts", "An arrow shaft with a feather attached. Needs to be tipped.", "headlessShaft", 139, 69, 19, 2, true));
            itemsToAdd.Add(new Item("Flax", "I should use this with a spinning wheel.", "flax", 189, 246, 254, 5));
            itemsToAdd.Add(new Item("Bow string", "I need a bow stave to attach this to.", "bowstring", 207, 185, 151, 10));
            itemsToAdd.Add(new Item("Sinew", "I can use this to make a crossbow string.", "sinew", 207, 185, 151, 10));
            itemsToAdd.Add(new Item("Crossbow string", "A string for a crossbow.", "crossbowString", 207, 185, 151, 10)); 

            // Fletching Factory
            itemsToAdd.Add(new Item("Poplar ashes", "A small pile of poplar ash.", "ashesPoplar", ColorLib.Poplar, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(-2, 3, -3, 3, 1) });
            itemsToAdd.Add(new Item("Elm ashes", "A small pile of elm ash.", "ashesElm", ColorLib.Elm, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(0, -3, -4, 3, 10) });
            itemsToAdd.Add(new Item("Walnut ashes", "A small pile of walnut ash.", "ashesWalnut", ColorLib.Walnut, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(6, 0, 0, -3, 20) });
            itemsToAdd.Add(new Item("Holly ashes", "A small pile of holly ash.", "ashesHolly", ColorLib.Holly, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(1, -2, 4, 1, 30) });
            itemsToAdd.Add(new Item("Acacia ashes", "A small pile of acacia ash.", "ashesAcacia", ColorLib.Acacia, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(0, -4, 2, -1, 40) });
            itemsToAdd.Add(new Item("Birch ashes", "A small pile of birch ash.", "ashesBirch", ColorLib.Birch, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(-3, 1, 0, 2, 50) });
            itemsToAdd.Add(new Item("Hickory ashes", "A small pile of hickory ash.", "ashesHickory", ColorLib.Hickory, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(0, 2, -2, -1, 60) });
            itemsToAdd.Add(new Item("Bloodwood ashes", "A small pile of bloodwood ash.", "ashesBloodwood", ColorLib.Bloodwood, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(2, 1, 1, 0, 70) });
            itemsToAdd.Add(new Item("Camatillo ashes", "A small pile of camatillo ash.", "ashesCamatillo", ColorLib.Camatillo, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(0, -2, 1, 0, 80) });
            itemsToAdd.Add(new Item("Katalox ashes", "A small pile of katalox ash.", "ashesKatalox", ColorLib.Katalox, 5) { CountsAsIDs = [ "ashes" ], Alchemy = new(-1, -1, 0, 0, 90) });
             
            itemsToAdd.Add(new Item("Paper mould", "A mould for making sheets of paper.", "mouldPaper", ColorLib.Poplar, 20));

            foreach (var mat in Materials.Woods) { 
                itemsToAdd.Add(new Item(mat.Name + " log", "A bundle of " + mat.Name.ToLower() + " logs.", "log" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " chips", "A pile of " + mat.Name.ToLower() + " chips. Needs to be added to a pot of lye (water + ashes).", "chips" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item("Pot of " + mat.Name.ToLower() + " chips", "A pot of lye with " + mat.Name.ToLower() + " chips. Needs to be heated.", "potChips" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier + 6));
                itemsToAdd.Add(new Item(mat.Name + " pulp", "A lump of " + mat.Name.ToLower() + " pulp. Needs to be pressed into sheets.", "pulp" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier / 5, true) { UseString = "ManualPaper" });
                itemsToAdd.Add(new Item(mat.Name + " paper", "A sheet of " + mat.Name.ToLower() + " paper. Will generally need level " + mat.Level + " to use.", "paper" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier / 5, true) { EquipLevel = mat.Level });
                
                itemsToAdd.Add(new Item(mat.Name + " rod", "A fishing rod made of " + mat.Name.ToLower() + ".", "rod" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier, misc: "Fishing rod") { EquipLevel = mat.Level });
                itemsToAdd.Add(new Item(mat.Name + " rod (u)", "A fishing pole made of " + mat.Name.ToLower() + ". Needs a", "rod" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " rod (s)", "A strung fishing pole made of " + mat.Name.ToLower() + ". Still needs a " + Materials.MetalNames[(int) mat.Tier - 1].ToLower() + " hook.", "rod" + mat.Name + "S", mat.R, mat.G, mat.B, mat.CostMultiplier));

                itemsToAdd.Add(new Item(mat.Name + " shortbow (u)", "A shortbow stave fletched from " + mat.Name.ToLower() + ".", "shortbow" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " shortbow", "A shortbow fletched from " + mat.Name.ToLower() + ".", "shortbow" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier + 15) {
                    EquipSlot = "Weapon",
                    EquipTier = mat.Tier,
                    EquipLevel = mat.Level, 
                    EquipDamageType = "RangedStandard",
                    EquipElement = "Wood",
                    EquipSkill = "Ranged",
                    EquipAmmo = "RangedStandard",
                    AttackSpeed = 0.75, 
                    TwoHanded = true
                });

                itemsToAdd.Add(new Item(mat.Name + " longbow (u)", "A longbow stave fletched from " + mat.Name.ToLower() + ".", "longbow" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " longbow", "A longbow fletched from " + mat.Name.ToLower() + ".", "longbow" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier + 15) {
                    EquipSlot = "Weapon",
                    EquipTier = mat.Tier + 1,
                    EquipLevel = mat.Level, 
                    EquipDamageType = "RangedStandard",
                    EquipElement = "Wood",
                    EquipSkill = "Ranged",
                    EquipAmmo = "RangedStandard",
                    AttackSpeed = 1.25, 
                    TwoHanded = true
                });

                itemsToAdd.Add(new Item(mat.Name + " composite bow", "A composite bow fletched from " + mat.Name.ToLower() + ".", "compbow" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier * 10) {
                    EquipSlot = "Weapon",
                    EquipTier = mat.Tier + 1,
                    EquipLevel = mat.Level, 
                    EquipDamageType = "RangedStandard",
                    EquipElement = "Wood",
                    EquipSkill = "Ranged",
                    EquipAmmo = "RangedStandard", 
                    TwoHanded = true
                });

                itemsToAdd.Add(new Item(mat.Name + " stock", "A crossbow stock fletched from " + mat.Name.ToLower() + ". Could be attached to " + mat.Descriptor + " limbs.", "stock" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " crossbow (u)", "An unstrung crossbow stock fletched from " + mat.Name.ToLower() + " attached to " + mat.Descriptor + " limbs.", "crossbow" + mat.Name + "U", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " crossbow", "A crossbow made from " + mat.Name.ToLower() + " and " + mat.Descriptor + ". Fires bolts.", "crossbow" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier * 2) {
                    EquipSlot = "Weapon",
                    EquipTier = mat.Tier,
                    EquipLevel = mat.Level, 
                    EquipDamageType = "RangedHeavy",
                    EquipElement = "Metal",
                    EquipSkill = "Ranged",
                    EquipAmmo = "RangedHeavy",
                    AttackSpeed = 1.5
                }); 

                itemsToAdd.Add(new Item(mat.Name + " wand shaft", "A wand shaft fletched from " + mat.Name.ToLower() + ". Needs to be tipped with a cut " + Materials.JewelNames[(int) mat.Tier - 1].ToLower() + ".", "wand" + mat.Name + "Unf", mat.R, mat.G, mat.B, mat.CostMultiplier));
                itemsToAdd.Add(new Item(mat.Name + " wand", "A wand fletched from " + mat.Name.ToLower() + ". (T" + mat.Tier + ")", "wand" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier + Materials.JewelCosts[(int) mat.Tier - 1]) {
                    EquipSlot = "Weapon",
                    EquipTier = mat.Tier,
                    EquipLevel = mat.Level, 
                    EquipDamageType = "Crush",
                    EquipElement = "Wood",
                    EquipSkill = "Magic"
                });

                itemsToAdd.Add(new Item(mat.Name + " plank", "A plank carved from a" + (Helper.VowelStart(mat.Name.ToLower()) ? "n " : " ") + mat.Name.ToLower() + " log.", "plank" + mat.Name, mat.R, mat.G, mat.B, mat.CostMultiplier * 2));
                
            }   

            itemsToAdd.Add(new Item("Shovel", "Could be used to dig for buried treasure.", "shovel", 200, 200, 200, 3) { UseString = "Dig", ConsumedOnUse = false });
            itemsToAdd.Add(new Item("Candle (lit)", "A lit candle.", "candleLit", Color.Yellow, 3) { UseString = "Extinguish", UseString2 = "candle", ConsumedOnUse = false, ExposedFlame = true, ProvidesLight = true });
            itemsToAdd.Add(new Item("Candle", "A candle.", "candle", Color.White, 3) { UseString = "Light", UseString2 = "candleLit", ConsumedOnUse = false });
            itemsToAdd.Add(new Item("Candle lantern (lit)", "A flickering candle in a glass cage.", "candleLanternLit", Color.Yellow, 15) { UseString = "Extinguish", UseString2 = "candleLantern", ConsumedOnUse = false, ProvidesLight = true });
            itemsToAdd.Add(new Item("Candle lantern", "A candle in a glass cage.", "candleLantern", ColorLib.Steel, 15) { UseString = "Light", UseString2 = "candleLanternLit", ConsumedOnUse = false });
            itemsToAdd.Add(new Item("Torch (lit)", "A lit torch.", "torchLit", Color.Yellow, 3) { UseString = "Extinguish", UseString2 = "torch", ConsumedOnUse = false, ExposedFlame = true, ProvidesLight = true });
            itemsToAdd.Add(new Item("Torch", "A torch.", "torch", Color.SaddleBrown, 3) { UseString = "Light", UseString2 = "torchLit", ConsumedOnUse = false });
            itemsToAdd.Add(new Item("Oil lantern frame", "Add the oil lamp to complete.", "oilLanternFrame", ColorLib.Steel, 90)); 
            itemsToAdd.Add(new Item("Empty oil lamp", "An oil lamp with no oil in it.", "oilLampEmpty", ColorLib.Steel, 25)); 
            itemsToAdd.Add(new Item("Oil lamp (lit)", "Not the genie sort.", "oilLampLit", Color.Yellow, 28) { UseString = "Extinguish", UseString2 = "oilLamp", ConsumedOnUse = false, ExposedFlame = true, ProvidesLight = true });
            itemsToAdd.Add(new Item("Oil lamp", "Not the genie sort.", "oilLamp", ColorLib.Steel, 28) { UseString = "Light", UseString2 = "oilLampLit", ConsumedOnUse = false });
            itemsToAdd.Add(new Item("Empty oil lantern", "An oil lantern with no oil in it.", "oilLanternEmpty", ColorLib.Steel, 125)); 
            itemsToAdd.Add(new Item("Oil lantern (lit)", "It lights your way through the dark places of the earth.", "oilLanternLit", Color.Yellow, 125) { UseString = "Extinguish", UseString2 = "oilLantern", ConsumedOnUse = false, ProvidesLight = true });
            itemsToAdd.Add(new Item("Oil lantern", "An unlit oil lantern.", "oilLantern", ColorLib.Steel, 125) { UseString = "Light", UseString2 = "oilLanternLit", ConsumedOnUse = false });
            

            itemsToAdd.Add(new Item("Tutorial Island cape", "A cape signifying you completed all challenges on Tutorial Island. Congratulations!", "capeCompTI", 135, 206, 235, 0, trade: false) { EquipSlot = "Cape", EquipTier = 1, MiscString = "OmniBoost" });
            
            {
                // ordinary wizard
                itemsToAdd.Add(new Item("Blue wizard hat", "A silly pointed hat.", "wizardBlueHat", 0, 157, 196, 2) { EquipSlot = "Head", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                itemsToAdd.Add(new Item("Blue wizard shirt", "I can do better magic in this.", "wizardBlueRobe", 0, 157, 196, 15) { EquipSlot = "Body", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                itemsToAdd.Add(new Item("Blue wizard skirt", "I can do better magic in this.", "wizardBlueBottom", 0, 157, 196, 15) { EquipSlot = "Legs", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                itemsToAdd.Add(new Item("Black wizard hat", "A silly pointed hat.", "wizardBlackHat", Color.DimGray, 2) { EquipSlot = "Head", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                itemsToAdd.Add(new Item("Black wizard shirt", "I can do better magic in this.", "wizardBlackRobe", Color.DimGray, 15) { EquipSlot = "Body", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                itemsToAdd.Add(new Item("Black wizard skirt", "I can do better magic in this.", "wizardBlackBottom", Color.DimGray, 15) { EquipSlot = "Legs", EquipTier = 1, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
            }

            itemsToAdd.Add(new Item("Herb sack", "You can store grimy herbs in here, up to 30 of each kind.", "sackHerb", Color.SandyBrown, 1, trade: false) {  UseString = "ViewInventory", ConsumedOnUse = false, ContainerStacksUnstackable = true, ContainerMaxStack = 30, ContainerSlots = 30, ContainableIDs = [ "herbGrimyArbuck", "herbGrimyAvantoe", "herbGrimyBloodweed", "herbGrimyCadantine", "herbGrimyDwarfweed", "herbGrimyFellstalk", "herbGrimyGuam", "herbGrimyHarralander", "herbGrimyIrit", "herbGrimyKwuarm", "herbGrimyLantadyme", "herbGrimyMarrentill", "herbGrimyRanarr", "herbGrimySnapdragon", "herbGrimySpiritweed", "herbGrimyTarromin", "herbGrimyToadflax", "herbGrimyTorstol", "herbGrimyWergali" ] });
            

            itemsToAdd.Add(new Item("Chef's hat", "What a silly hat.", "chefHat", 255, 255, 255, 2) { EquipSlot = "Head", Cosmetic = true });
            itemsToAdd.Add(new Item("White apron", "A chef's apron.", "whiteApron", 255, 255, 255, 2) { EquipSlot = "Body", Cosmetic = true });
            itemsToAdd.Add(new Item("Brown apron", "A craftsman's apron.", "brownApron", Color.SaddleBrown, 2) { EquipSlot = "Body", Cosmetic = true });
            itemsToAdd.Add(new Item("Black cape", "A warm black cape.", "capeBlack", Color.DimGray, 7) { EquipSlot = "Cape", Cosmetic = true });
             

            // Pickpocket Loot
            itemsToAdd.Add(new Item("Small coin pouch", "Has a few coins in it.", "coinPouchSmall", 111, 66, 33, 5, true, false) { UseString = "GetGold", UseInt = 5 });
            itemsToAdd.Add(new Item("Medium coin pouch", "Has a few more coins in it.", "coinPouchMedium", 111, 66, 33, 5, true, false) { UseString = "GetGold", UseInt = 20 });
              


            itemsToAdd.Add(new Item("Empty bucket", "An empty bucket. Could probably hold something.", "bucketEmpty", 111, 66, 33, 2)); 
            itemsToAdd.Add(new Item("Bucket of compost", "Good for plants, helps them grow.", "bucketCompost", 111, 66, 33, 2) { UseString = "Compost", UseInt = 1, ItemReturned = "bucketEmpty" });
            itemsToAdd.Add(new Item("Empty jug", "An empty jug. Could probably hold something.", "jugEmpty", 200, 200, 200, 1));
            


            itemsToAdd.Add(new Item("Huge club", "Upon closer inspection this is actually a huge femur.", "clubHuge", 255, 255, 255, 1000) {
                EquipSlot = "Weapon",  EquipTier = 3, EquipSkill = "Attack", EquipLevel = 10, EquipDamageType = "Crush", EquipElement = "Earth", AttackSpeed = 1.5
            });itemsToAdd.Add(new Item("Huger club", "Where did that zombie even get such a large bone? You can barely move this thing.", "clubHuger", 255, 255, 255, 5000) {
                EquipSlot = "Weapon",  EquipTier = 4, EquipSkill = "Attack", EquipLevel = 10, EquipDamageType = "Crush", EquipElement = "Earth", AttackSpeed = 2
            });
            itemsToAdd.Add(new Item("Rotten flesh", "This doesn't really seem edible...", "fleshRotten", 150, 100, 50, 4) { UseString = "Heal", UseInt = 2, Potion = new() { new("Attack", -3) } });
            
            
            
            itemsToAdd.Add(new Item("Swamp tar", "A foul smelling thick tar-like substance.", "swampTar", 50, 50, 50, 1, true));
            
            
            itemsToAdd.Add(new Item("Unicorn horn", "This horn has restorative properties.", "unicornHorn", Color.SandyBrown, 20));
            itemsToAdd.Add(new Item("Chocolate bar", "Mmmmmmmm chocolate.", "chocolateBar", Color.Chocolate, 10));
            itemsToAdd.Add(new Item("Chocolate dust", "It's ground up chocolate.", "chocolateDust", Color.Chocolate, 10));

            
            itemsToAdd.Add(new Item("Coins", "Filthy lucre. Activate to add to your coin pouch.", "coins", Color.Goldenrod, 1, true) { UseString = "Gold" });
            itemsToAdd.Add(new Item("Key (clue step)", "Used to open the container you need to access for your clue step.", "keyClue", Color.Goldenrod, 0, trade: false));

            itemsToAdd.Add(new Item("Construction guidebook", "Curious about home ownership? Read this!", "bookConstructionGuide", Color.SaddleBrown, 1) { ConsumedOnUse = false, UseString = "Book", UseString2 = "bookConstructionGuide" });
            itemsToAdd.Add(new Item("Papermaker pamphlet", "A brief guide outlining the steps to create paper.", "bookPapermaker", Color.AntiqueWhite, 1) { ConsumedOnUse = false, UseString = "Book", UseString2 = "bookPapermaker" });
            

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
