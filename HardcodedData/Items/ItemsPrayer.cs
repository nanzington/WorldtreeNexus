using GoRogue.GameFramework;
using System.Security.Cryptography;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsPrayer {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            List<string> Bones = ["Regular", "Big" ];  

            foreach (var bone in Materials.Bones) {
                itemsToAdd.Add(new Item(bone.Name, "Can be buried for " + bone.ExpMultiplier + " Prayer experience.", bone.SimpleName, bone.GetColor(), bone.CostMultiplier) { UseString = "Bones", UseInt = bone.ExpMultiplier });
                itemsToAdd.Add(new Item("Cleansed " + bone.Name.ToLower(), "Can be buried for " + (int) Math.Clamp(Math.Floor(bone.ExpMultiplier * 1.1), bone.ExpMultiplier + 1, int.MaxValue) + " Prayer experience.", bone.SimpleName + "Cleansed", bone.GetColor().GetBright(), bone.CostMultiplier, trade: false) { UseString = "Bones", UseInt = (int) Math.Clamp(Math.Floor(bone.ExpMultiplier * 1.1), bone.ExpMultiplier + 1, int.MaxValue) });
            }

            foreach (var oil in Materials.Oils) {
                itemsToAdd.Add(new Item("Oil of the " + oil.Name + " (un)", "Must be blessed at an altar before it can be used.", "oil" + oil.Name, oil.GetColor(), oil.CostMultiplier, true) { EquipLevel = oil.Level });

                foreach (var bone in Materials.Bones) {
                    itemsToAdd.Add(new Item(bone.Name + " (" + oil.Name.Substring(0, 2) + ")", bone.Name + " anointed with Oil of the " + oil.Name + ". Must be burned, rather than buried.", bone.SimpleName + oil.Name, bone.GetColor(), bone.CostMultiplier + oil.CostMultiplier) { EquipLevel = oil.Level });
                }
            } 

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
