using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedSpells {
        public static void InitSpells(Dictionary<string, Spell> SpellLib) {
            List<Spell> toAdd = new();

            // // Spells marked as "Standard" book (third argument) show up always, otherwise they only appear if your region matches. Mostly for hiding world-specific teleports unless you're in that world.

            // Teleport Spells
            toAdd.Add(new("nexusReturnal", "Return to Nexus", "Standard", 0, 0, [ ], "Teleports you to Worldtree Nexus Plaza. 30 minute cooldown.", "Tele", misc: "WTN_Plaza", misc2: "Nexus Plaza", cd: 1800000, acts: [ new("Teleport", "WTN_Plaza", "nexusReturnal", 0)]));
            toAdd.Add(new("teleNexus", "Nexus Teleport", "Standard", 10, 20, [ "talismanWater,2", "talismanMysticism,1" ], "Teleports you to Worldtree Nexus Plaza.", "Tele", misc: "WTN_Plaza", misc2: "Nexus Plaza", cd: 250, acts: [ new("Teleport", "WTN_Plaza", "teleNexus", 0)]));
            toAdd.Add(new("teleBar", "Bar Teleport", "Standard", 1, 10, [ "talismanWater,2", "talismanMysticism,1" ], "Teleports you to the nearest bar or inn you could reach in your current region.", "Tele", cd: 250, acts: [ new("TeleportSearch", "Bar", "teleBar", 0)]));
            toAdd.Add(new("teleTemple", "Temple Teleport", "Standard", 10, 20, [ "talismanFire,2", "talismanMysticism,1" ], "Teleports you to the nearest temple you could reach in your current region.", "Tele", cd: 250, acts: [ new("TeleportSearch", "Temple", "teleTemple", 0)]));
            toAdd.Add(new("teleFarm", "Farm Teleport", "Standard", 20, 30, [ "talismanWood,2", "talismanMysticism,1" ], "Teleports you to the nearest farm plot you could reach in your current region.", "Tele", cd: 250, acts: [ new("TeleportSearch", "Farm", "teleFarm", 0)]));
            //toAdd.Add(new("teleBank", "Bank Teleport", "Standard", 30, 40, [ "talismanEarth,2", "talismanMysticism,1" ], "Teleports you to the nearest bank you could reach in your current region.", "Tele", cd: 250, acts: [ new("TeleportSearch", "Bank", "teleBank", 0)]));
            toAdd.Add(new("teleBank", "Bank Teleport", "Standard", 40, 50, [ "talismanMetal,2", "talismanMysticism,1" ], "Teleports you to the nearest bank you could reach in your current region.", "Tele", cd: 250, acts: [ new("TeleportSearch", "Bank", "teleBank", 0)]));
            // need at least one more for earth talismans

            // Utility Spells
            toAdd.Add(new("utilAlchemyLow", "Low Level Alchemy", "Standard", 30, 40, [ "talismanMetal,3", "talismanAlteration,1" ], "Gives coins equal to 35% of the value of the item the spell was cast on.", "Utility")); 
            toAdd.Add(new("utilSuperheat", "Superheat Item", "Standard", 30, 40, [ "talismanFire,3", "talismanAlteration,1" ], "Smelts the first ore mix in the inventory into the equivalent bar, as if using a furnace.", "Utility", acts: [ new("SuperheatItem", "", "utilSuperheat", 0) ])); 
            toAdd.Add(new("utilAlchemyHigh", "High Level Alchemy", "Standard", 60, 70, [ "talismanMetal,6", "talismanAlteration,2" ], "Gives coins equal to 70% of the value of the item the spell was cast on.", "Utility")); 
            
            for (int i = 0; i < Materials.Jewels.Count; i++) {
                int tier = i + 1;
                int level = i == 0 ? 1 : i * 10;
                toAdd.Add(new("utilEnchant" + tier, "Enchant " + Materials.Jewels[i].Name, "Standard", level, tier * 10, [ "talismanMysticism," + tier, "talismanAlteration," + tier ], "Enchants jewellery made from " + Materials.Jewels[i].Name.ToLower() + ".", "Utility", acts: [ new("EnchantItem", "", "utilEnchant" + tier, tier) ]));
            }

            toAdd.Add(new("utilTelegrab", "Telekinetic Grab", "Standard", 33, 43, [ "talismanEarth,1", "talismanMysticism,1" ], "Allows you to pick up otherwise inaccessible items.", "Utility"));  
            toAdd.Add(new("utilMonsterInspect", "Monster Inspect", "Standard", 42, 31, [ "talismanWood,2", "talismanMysticism,2" ], "Displays information about the monster the spell is cast upon.", "Utility"));  
            

            for (int i = 0; i < 11; i++) {
                int tier = i + 1;
                int level = i == 0 ? 1 : i * 10;
                // This is maybe a little strong but it's going to be on a minute long global cooldown at least
                toAdd.Add(new("utilCure" + tier, "Cure Wounds " + Materials.RomanNumerals[i], "Standard", level, tier * 10, [ "talismanEarth," + (tier * 2), "talismanWood," + tier, "talismanRestoration," + tier ], "Heals you for " + (tier * 2) + " hitpoints. Shared cooldown of 1 minute with all other Cure spells.", "Utility", acts: [ new("CureSpell", "", "utilCure" + tier, tier * 2)]));  
                
                
            }

            for (int i = 0; i < toAdd.Count; i++) { 
                SpellLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
