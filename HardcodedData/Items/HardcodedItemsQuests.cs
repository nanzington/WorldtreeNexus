using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsQuests {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Combat lamp (tiny)", "Grants 100 experience to each of Attack, Strength, Defense, Ranged, and Magic.", "combatLampTiny", Color.White, 1, trade: false) { UseString = "LampAll", UseString2 = "Attack,Strength,Defense,Ranged,Magic", UseInt = 100 });
            
            itemsToAdd.Add(new Item("Chargebow", "A brightly colored chargebow that fires magical arrows.", "chargebow", ColorLib.Elm, 20) {
                EquipSlot = "Weapon", EquipTier = 1, EquipLevel = 1, EquipDamageType = "RangedStandard", EquipElement = "Water", EquipSkill = "Ranged", EquipAmmo = "Chargebow", TwoHanded = true
            });  
            
            itemsToAdd.Add(new Item("Combat lamp (1k)", "Grants 1,000 experience to your choice of Attack, Strength, Defense, Hitpoints, Ranged, or Magic.", "lampCombat1k", Color.White, 1, trade: false) { ConsumedOnUse = false, UseString = "LampChoice", UseString2 = "Attack,Strength,Defense,Hitpoints,Ranged,Magic", UseInt = 1000 });
            
            itemsToAdd.Add(new Item("Romeo's letter [Q]", "A sappy love letter written by Romeo for Juliet. (Romeo & Juliet)", "letterRomeo", Color.SkyBlue, 0, trade: false) { ConsumedOnUse = false, UseString = "Book", UseString2 = "letterRomeo" });
            itemsToAdd.Add(new Item("Juliet's letter [Q]", "A sappier love letter written by Juliet for Romeo. (Romeo & Juliet)", "letterJuliet", Color.HotPink, 0, trade: false) { ConsumedOnUse = false, UseString = "Book", UseString2 = "letterJuliet" });
            itemsToAdd.Add(new Item("Cleaner disguise [Q]", "A disguise to allow me to pose as a cleaner. (Romeo & Juliet)", "disguiseCleaner", Color.Beige, 0, trade: false) { Cosmetic = true, EquipSlot = "Body" });
            itemsToAdd.Add(new Item("Sleeping potion (unf) [Q]", "A vial of water with some nightshade berries added. Needs more ingredients to be complete. (Romeo & Juliet)", "potionSleepingUnf", Color.Magenta, 0, trade: false) { ConsumedOnUse = false, UseString = "SleepingPotion" });
            itemsToAdd.Add(new Item("Wing of rat [Q]", "The wing of a rat. (Romeo & Juliet)", "potionSleepingWing", Color.DimGray, 0, trade: false));
            itemsToAdd.Add(new Item("Tail of frog [Q]", "The tail of a frog. (Romeo & Juliet)", "potionSleepingTail", Color.ForestGreen, 0, trade: false));
            itemsToAdd.Add(new Item("Ear of snake [Q]", "The ear of a snake. (Romeo & Juliet)", "potionSleepingEar", Color.Pink, 0, trade: false));
            itemsToAdd.Add(new Item("Horn of dog [Q]", "The horn of a dog. (Romeo & Juliet)", "potionSleepingHorn", Color.White, 0, trade: false));
            itemsToAdd.Add(new Item("Sleeping potion [Q]", "A vial of death sleeping draught. (Romeo & Juliet)", "potionSleeping", Color.Magenta, 0, trade: false));
            itemsToAdd.Add(new Item("Sleeping potion list [Q]", "A list of the ingredients to finish a sleeping potion. (Romeo & Juliet)", "potionSleepingList", Color.SandyBrown, 0, trade: false) { ConsumedOnUse = false, UseString = "Book", UseString2 = "potionSleepingList" });
            itemsToAdd.Add(new Item("Tybalt's sword [Q]", "A fine steel sword. Soon to be a little less fine. (Romeo & Juliet)", "swordTybalt", ColorLib.Steel, 0, trade: false));
            itemsToAdd.Add(new Item("Brittle sword [Q]", "A steel sword with the temper ruined. Will shatter easily under stress. (Romeo & Juliet)", "swordBrittle", Color.Silver, 0, trade: false));
            


            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
