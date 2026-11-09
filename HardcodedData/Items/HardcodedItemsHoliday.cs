using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsHoliday {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
             
            itemsToAdd.Add(new Item("Teleport card", "A card which has magical properties.", "cardTeleport", Color.White, 100, true));
            


            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
