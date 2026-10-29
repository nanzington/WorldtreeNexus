using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsClues {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Clue scroll box", "I can store my clue scrolls in this.", "clueScrollBox", Color.Khaki, 5000) { UseString = "ViewInventory", ConsumedOnUse = false, ContainerStacksUnstackable = true, ContainerSlots = 7, ContainableIDs = [ "clueScrollTutorial", "clueScrollBeginner", "clueScrollEasy", "clueScrollMedium", "clueScrollHard", "clueScrollElite", "clueScrollMaster" ]}); 
            

            // Tutorial Clues
            itemsToAdd.Add(new Item("Clue scroll (tutorial)", "A treasure hunt taking place entirely on Tutorial Island.", "clueScrollTutorial", 207, 185, 151, 0, false, false) {
                UseString = "ClueTutorial", 
                ConsumedOnUse = false,
                DestroyOnDrop = true
            });

            itemsToAdd.Add(new Item("Clue casket (tutorial)", "The treasure at the end of the hunt! What could be inside?", "casketTutorial", 218, 165, 32, 0, true, false) {
                UseString = "Casket",
                UseString2 = "Tutorial",
                UseInt = 10,
                DropTable = {
                    new ItemDrop("clueScrollBox", 1, 25, 1, 1),
                    new ItemDrop("clueCatEars", 1, 20, 1, 1),
                    new ItemDrop("clueCornyApron", 1, 20, 1, 1),
                    new ItemDrop("clueKilt", 1, 20, 1, 1),
                    new ItemDrop("cluePowerGlove", 1, 20, 1, 1),
                    new ItemDrop("clueProgrammerSocks", 1, 20, 1, 1),
                    new ItemDrop("helmTutorial", 1, 20, 1, 1), 
                    new ItemDrop("platebodyTutorial", 1, 20, 1, 1), 
                    new ItemDrop("chainmailTutorial", 1, 20, 1, 1),
                    new ItemDrop("platelegsTutorial", 1, 20, 1, 1),
                    new ItemDrop("plateskirtTutorial", 1, 20, 1, 1),  
                    new ItemDrop("gauntletsTutorial", 1, 20, 1, 1), 
                    new ItemDrop("swordTutorial", 1, 20, 1, 1), 
                    new ItemDrop("spearTutorial", 1, 20, 1, 1),  
                    new ItemDrop("battleaxeTutorial", 1, 20, 1, 1), 
                    new ItemDrop("sword2hTutorial", 1, 20, 1, 1), 
                    new ItemDrop("warhammerTutorial", 1, 20, 1, 1), 
                    new ItemDrop("sqShieldTutorial", 1, 20, 1, 1), 
                    new ItemDrop("kiteshieldTutorial", 1, 20, 1, 1),  
                    new ItemDrop("maceTutorial", 1, 20, 1, 1), 
                    new ItemDrop("daggerTutorial", 1, 20, 1, 1), 
                    new ItemDrop("scimitarTutorial", 1, 20, 1, 1), 
                    new ItemDrop("pickaxeTutorial", 1, 20, 1, 1), 
                    new ItemDrop("hatchetTutorial", 1, 20, 1, 1),      
                    new ItemDrop("bootsTutorial", 1, 20, 1, 1),
                    new ItemDrop("clueSilkHood", 1, 20, 1, 1),
                    new ItemDrop("clueSilkRobes", 1, 20, 1, 1),
                    new ItemDrop("clueSilkUnderwear", 1, 20, 1, 1),
                    new ItemDrop("clueSilkGloves", 1, 20, 1, 1),
                    new ItemDrop("clueSilkSocks", 1, 20, 1, 1),
                    new ItemDrop("clueFauxleatherCoif", 1, 20, 1, 1),
                    new ItemDrop("clueFauxleatherBody", 1, 20, 1, 1),
                    new ItemDrop("clueFauxleatherChaps", 1, 20, 1, 1),
                    new ItemDrop("clueFauxleatherVambraces", 1, 20, 1, 1),
                    new ItemDrop("clueFauxleatherBoots", 1, 20, 1, 1),
                    new ItemDrop("clueShortfaux", 1, 20, 1, 1),
                    new ItemDrop("arrowsCopper", 1, 4, 100, 200), 
                    new ItemDrop("arrowsTutorial", 1, 4, 50, 100),
                    new ItemDrop("boltsTutorial", 1, 4, 50, 100),
                    new ItemDrop("knivesCopper", 1, 4, 200, 400),
                    new ItemDrop("knivesTutorial", 1, 4, 100, 200)
                }
            });

            // Clue (Tutorial) Uniques
            itemsToAdd.Add(new Item("Cat ear headband", "A cute headband that makes you look like you have cat ears.", "clueCatEars", 255, 105, 180, 500) { EquipSlot = "Head", Cosmetic = true });
            itemsToAdd.Add(new Item("Corny apron", "An apron reading 'Kiss the Cook'.", "clueCornyApron", 255, 255, 255, 500) { EquipSlot = "Body", Cosmetic = true, CountsAsIDs = ["whiteApron"] });
            itemsToAdd.Add(new Item("Kilt", "A bit breezy but quite comfortable.", "clueKilt", 34, 139, 34, 500) { EquipSlot = "Legs", Cosmetic = true });
            itemsToAdd.Add(new Item("Power glove", "A gauntlet with a bunch of buttons on it. Seems wildly impractical.", "cluePowerGlove", 150, 150, 150, 500) { EquipSlot = "Hands", Cosmetic = true });
            itemsToAdd.Add(new Item("Programmer socks", "Thigh-high socks with blue stripes.", "clueProgrammerSocks", 135, 206, 235, 500) { EquipSlot = "Feet", Cosmetic = true });
            
            itemsToAdd.Add(new Item("Silky hood", "A silk hood. Slightly magical, very comfortable.", "clueSilkHood", 147, 112, 219, 500) { EquipSlot = "Head", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
            itemsToAdd.Add(new Item("Silky robes", "A set of silk robes. Slightly magical, very comfortable.", "clueSilkRobes", 147, 112, 219, 500) { EquipSlot = "Body", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
            itemsToAdd.Add(new Item("Silky underwear", "A pair of silk underwear. Slightly magical, very comfortable.", "clueSilkUnderwear", 147, 112, 219, 500) { EquipSlot = "Legs", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
            itemsToAdd.Add(new Item("Silky gloves", "A pair of silk gloves. Slightly magical, very comfortable.", "clueSilkGloves", 147, 112, 219, 500) { EquipSlot = "Hands", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
            itemsToAdd.Add(new Item("Silky socks", "A pair of silk socks. Slightly magical, very comfortable.", "clueSilkSocks", 147, 112, 219, 500) { EquipSlot = "Feet", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseMagic" });
                 
            itemsToAdd.Add(new Item("Fauxleather coif", "A coif made of fauxleather. You may have gotten scammed.", "clueFauxleatherCoif", 255, 165, 50, 500) { EquipSlot = "Head", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseRange" });
            itemsToAdd.Add(new Item("Fauxleather body", "A body made of fauxleather. You may have gotten scammed.", "clueFauxleatherBody", 255, 165, 50, 500) { EquipSlot = "Body", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseRange" });
            itemsToAdd.Add(new Item("Fauxleather chaps", "Chaps made of fauxleather. You may have gotten scammed.", "clueFauxleatherChaps", 255, 165, 50, 500) { EquipSlot = "Legs", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseRange" });
            itemsToAdd.Add(new Item("Fauxleather vambraces", "Vambraces made of fauxleather. You may have gotten scammed.", "clueFauxleatherVambraces", 255, 165, 50, 500) { EquipSlot = "Hands", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseRange" });
            itemsToAdd.Add(new Item("Fauxleather boots", "Boots made of fauxleather. You may have gotten scammed.", "clueFauxleatherBoots", 255, 165, 50, 500) { EquipSlot = "Feet", EquipTier = 2, EquipSkill = "Defense", EquipLevel = 1, MiscString = "DefenseRange" });
            itemsToAdd.Add(new Item("Fauxbone shortbow", "A shortbow that appears to be made of a fake bone. You may have gotten scammed.", "clueShortfaux", 255, 255, 255, 500) { EquipSlot = "Weapon", EquipTier = 1, EquipDamageType = "RangedStandard", EquipElement = "Earth", EquipSkill = "Ranged", EquipLevel = 1, EquipAmmo = "RangedStandard", TwoHanded = true });
            
            
            // Beginner Clues
            itemsToAdd.Add(new Item("Clue scroll (beginner)", "Hopefully leads to treasure.", "clueScrollBeginner", 207, 185, 151, 0, false, false) {
                UseString = "ClueBeginner", 
                ConsumedOnUse = false,
                DestroyOnDrop = true
            }); 

            // Easy Clues
            itemsToAdd.Add(new Item("Clue scroll (easy)", "Hopefully leads to treasure.", "clueScrollEasy", 207, 185, 151, 0, false, false) {
                UseString = "ClueEasy", 
                ConsumedOnUse = false,
                DestroyOnDrop = true
            }); 
            
            // Medium Clues
            itemsToAdd.Add(new Item("Clue scroll (medium)", "Hopefully leads to treasure.", "clueScrollMedium", 207, 185, 151, 0, false, false) {
                UseString = "ClueMedium", 
                ConsumedOnUse = false,
                DestroyOnDrop = true
            }); 

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
