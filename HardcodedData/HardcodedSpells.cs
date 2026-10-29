using WorldtreeNexus.DataTypes; 

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedSpells {
        public static void InitSpells(Dictionary<string, Spell> SpellLib) {
            List<Spell> toAdd = new();

            // // Standard Spellbook

            // Combat Spells


            /*
            List<string> SpellTiers = [ "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI" ];

            for (int i = 0; i < 10; i++) {
                int level = i == 0 ? 1 : i * 10;
                int tier = i + 1;
                toAdd.Add(new("boltMetal" + SpellTiers[i], "Metal Bolt " + SpellTiers[i], "Standard", level, tier * 6, [ "talismanMetal," + tier, "talismanDestruction," + tier ], "Deals 1d(WeaponTier)+" + (tier + 1) + " Metal Damage.", "Combat", tier, "Metal")); 
                toAdd.Add(new("boltWood" + SpellTiers[i], "Wood Bolt " + SpellTiers[i], "Standard", level, tier * 6, [ "talismanWood," + tier, "talismanDestruction," + tier ], "Deals 1d(WeaponTier)+" + (tier + 1) + " Wood Damage.", "Combat", tier, "Wood")); 
                toAdd.Add(new("boltWater" + SpellTiers[i], "Water Bolt " + SpellTiers[i], "Standard", level, tier * 6, [ "talismanWater," + tier, "talismanDestruction," + tier ], "Deals 1d(WeaponTier)+" + (tier + 1) + " Water Damage.", "Combat", tier, "Water")); 
                toAdd.Add(new("boltFire" + SpellTiers[i], "Fire Bolt " + SpellTiers[i], "Standard", level, tier * 6, [ "talismanFire," + tier, "talismanDestruction," + tier ], "Deals 1d(WeaponTier)+" + (tier + 1) + " Fire Damage.", "Combat", tier, "Fire")); 
                toAdd.Add(new("boltEarth" + SpellTiers[i], "Earth Bolt " + SpellTiers[i], "Standard", level, tier * 6, [ "talismanEarth," + tier, "talismanDestruction," + tier ], "Deals 1d(WeaponTier)+" + (tier + 1) + " Earth Damage.", "Combat", tier, "Earth")); 
            }
            */

            /*
            toAdd.Add(new("strikeWind", "Wind Strike", "Standard", 1, 6, [ "runeAir,1", "runeMind,1" ], "A simple air spell.", "Combat", 1, "Air"));
            toAdd.Add(new("strikeWater", "Water Strike", "Standard", 5, 8, [ "runeAir,1", "runeWater,1", "runeMind,1" ], "A simple water spell.", "Combat", 1, "Water"));
            toAdd.Add(new("strikeEarth", "Earth Strike", "Standard", 9, 10, [ "runeAir,1", "runeEarth,2", "runeMind,1" ], "A simple earth spell.", "Combat", 1, "Earth"));
            toAdd.Add(new("strikeFire", "Fire Strike", "Standard", 13, 12, [ "runeAir,2", "runeFire,3", "runeMind,1" ], "A simple fire spell.", "Combat", 1, "Fire"));
            
            toAdd.Add(new("boltWind", "Wind Bolt", "Standard", 17, 14, [ "runeAir,2", "runeChaos,1" ], "A basic air spell.", "Combat", 2, "Air"));
            toAdd.Add(new("boltWater", "Water Bolt", "Standard", 23, 17, [ "runeAir,2", "runeWater,2", "runeChaos,1" ], "A basic water spell.", "Combat", 2, "Water"));
            toAdd.Add(new("boltEarth", "Earth Bolt", "Standard", 29, 20, [ "runeAir,2", "runeEarth,3", "runeChaos,1" ], "A basic earth spell.", "Combat", 2, "Earth"));
            toAdd.Add(new("boltFire", "Fire Bolt", "Standard", 35, 23, [ "runeAir,3", "runeFire,4", "runeChaos,1" ], "A basic fire spell.", "Combat", 2, "Fire"));
             
            toAdd.Add(new("crumbleUndead", "Crumble Undead", "Standard", 39, 25, [ "runeAir,2", "runeEarth,2", "runeChaos,1" ], "A powerful spell against undead.", "Combat", 3, "Undead"));
            
            toAdd.Add(new("blastWind", "Wind Blast", "Standard", 41, 26, [ "runeAir,3", "runeDeath,1" ], "A standard air spell.", "Combat", 3, "Air"));
            toAdd.Add(new("blastWater", "Water Blast", "Standard", 47, 29, [ "runeAir,3", "runeWater,3", "runeDeath,1" ], "A standard water spell.", "Combat", 3, "Water"));
            toAdd.Add(new("blastEarth", "Earth Blast", "Standard", 53, 32, [ "runeAir,3", "runeEarth,4", "runeDeath,1" ], "A standard earth spell.", "Combat", 3, "Earth"));
            toAdd.Add(new("blastFire", "Fire Blast", "Standard", 59, 35, [ "runeAir,4", "runeFire,5", "runeDeath,1" ], "A standard fire spell.", "Combat", 3, "Fire"));
            */

            // Teleport Spells
            toAdd.Add(new("nexusReturnal", "Return to Nexus", "Standard", 0, 0, [ ], "Teleports you to Worldtree Nexus Plaza. 30 minute cooldown.", "Tele", misc: "WTN_Plaza", misc2: "Nexus Plaza", cd: 1800000, acts: [ new("Teleport", "WTN_Plaza", "nexusReturnal", 0)]));
            
            // Utility Spells
            toAdd.Add(new("utilAlchemyLow", "Low Level Alchemy", "Standard", 21, 31, [ "runeFire,3", "runeNature,1" ], "Gives coins equal to 35% of the value of the item the spell was cast on.", "Utility")); 
            toAdd.Add(new("utilSuperheat", "Superheat Item", "Standard", 21, 31, [ "runeFire,4", "runeNature,1" ], "Smelts the first ore mix in the inventory into the equivalent bar, as if using a furnace.", "Utility", acts: [ new("SuperheatItem", "", "utilSuperheat", 0) ])); 
            toAdd.Add(new("utilAlchemyHigh", "High Level Alchemy", "Standard", 55, 65, [ "runeFire,5", "runeNature,1" ], "Gives coins equal to 70%% of the value of the item the spell was cast on.", "Utility")); 
            
            toAdd.Add(new("utilEnchant1", "Lvl 1 Enchant (Sapphire/Opal)", "Standard", 7, 18, [ "runeWater,1", "runeCosmic,1" ], "Enchants jewellery made from sapphire or opal.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant1", 1) ]));
            toAdd.Add(new("utilEnchant2", "Lvl 2 Enchant (Emerald/Jade)", "Standard", 27, 37, [ "runeAir,3", "runeCosmic,1" ], "Enchants jewellery made from emerald or jade.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant2", 2) ])); 
            toAdd.Add(new("utilEnchant3", "Lvl 3 Enchant (Ruby/Red Topaz)", "Standard", 49, 59, [ "runeFire,5", "runeCosmic,1" ], "Enchants jewellery made from ruby or red topaz.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant3", 3) ])); 
            toAdd.Add(new("utilEnchant4", "Lvl 4 Enchant (Diamond)", "Standard", 57, 67, [ "runeEarth,10", "runeCosmic,1" ], "Enchants jewellery made from diamond.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant4", 4) ])); 
            toAdd.Add(new("utilEnchant5", "Lvl 5 Enchant (Dragonstone)", "Standard", 68, 78, [ "runeEarth,15", "runeWater,15", "runeCosmic,1" ], "Enchants jewellery made from dragonstone.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant5", 5) ])); 
            toAdd.Add(new("utilEnchant6", "Lvl 6 Enchant (Onyx)", "Standard", 87, 97, [ "runeEarth,20", "runeFire,20", "runeCosmic,1" ], "Enchants jewellery made from onyx.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant6", 6) ])); 
            toAdd.Add(new("utilEnchant7", "Lvl 7 Enchant (Zenyte)", "Standard", 93, 110, [ "runeBlood,20", "runeCosmic,1", "runeSoul,20" ], "Enchants jewellery made from zenyte.", "Utility", acts: [ new("EnchantItem", "", "utilEnchant7", 7) ]));  
            
            toAdd.Add(new("utilTelegrab", "Telekinetic Grab", "Standard", 33, 43, [ "runeAir,1", "runeLaw,1" ], "Allows you to pick up otherwise inaccessible items.", "Utility"));  
            toAdd.Add(new("utilMonsterInspect", "Monster Inspect", "Standard", 42, 31, [ "runeBody,2", "runeMind,2" ], "Displays information about the monster the spell is cast upon.", "Utility"));  
            

            for (int i = 0; i < toAdd.Count; i++) { 
                SpellLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
