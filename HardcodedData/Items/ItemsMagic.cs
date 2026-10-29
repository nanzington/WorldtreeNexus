using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsMagic {
        public static void InitItems(Dictionary<string, Item> ItemLibrary, Dictionary<string, Spell> SpellLibrary) {
            List<Item> itemsToAdd = new();

            List<string> Inks = ["Novice", "Beginner", "Apprentice", "Adept", "Journeyman", "Expert", "Artisan", "Master", "Grandmaster", "Paragon", "Divine" ]; 

            for (int i = 0; i < Inks.Count; i++) {
                int tier = i + 1;
                int level = (i == 0 ? 1 : i * 10);
                itemsToAdd.Add(new Item(Inks[i] + " ink", "Used to draw talismans (" + level + " Crafting).", "ink" + Inks[i], Color.DimGray, 1 * tier, true) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });

                // Buying anything but basic ink intentionally not possible, as no price could make it worthwhile over just buying talismans directly. 
                itemsToAdd.Add(new Item(Inks[i] + " ink (i)", "Used to draw talismans (" + level + " Crafting). Imbued with magical energy.", "ink" + Inks[i] + "Imbued", new Color(28, 106, 53), 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });

                itemsToAdd.Add(new Item(Inks[i] + " ink (Me)", "Used to draw talismans (" + level + " Crafting). Imbued with metal energy.", "ink" + Inks[i] + "Metal", ColorLib.Steel, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Wa)", "Used to draw talismans (" + level + " Crafting). Imbued with water energy.", "ink" + Inks[i] + "Water", Color.DodgerBlue, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Wo)", "Used to draw talismans (" + level + " Crafting). Imbued with wood energy.", "ink" + Inks[i] + "Wood", Color.ForestGreen, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Fi)", "Used to draw talismans (" + level + " Crafting). Imbued with fire energy.", "ink" + Inks[i] + "Fire", Color.Firebrick, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false }); 
                itemsToAdd.Add(new Item(Inks[i] + " ink (Ea)", "Used to draw talismans (" + level + " Crafting). Imbued with earth energy.", "ink" + Inks[i] + "Earth", Color.Yellow, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                
                itemsToAdd.Add(new Item(Inks[i] + " ink (De)", "Used to draw talismans (" + level + " Crafting). Imbued with destruction energy.", "ink" + Inks[i] + "Destruction", Color.Crimson, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Re)", "Used to draw talismans (" + level + " Crafting). Imbued with restoration energy.", "ink" + Inks[i] + "Restoration", Color.White, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Al)", "Used to draw talismans (" + level + " Crafting). Imbued with alteration energy.", "ink" + Inks[i] + "Alteration", Color.Cyan, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (My)", "Used to draw talismans (" + level + " Crafting). Imbued with mysticism energy.", "ink" + Inks[i] + "Mysticism", Color.MediumPurple, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Co)", "Used to draw talismans (" + level + " Crafting). Imbued with conjuration energy.", "ink" + Inks[i] + "Conjuration", Color.Goldenrod, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
                itemsToAdd.Add(new Item(Inks[i] + " ink (Il)", "Used to draw talismans (" + level + " Crafting). Imbued with illusion energy.", "ink" + Inks[i] + "Illusion", Color.HotPink, 0, true, false) { EquipLevel = level, UseString = "TalismanMenu", ConsumedOnUse = false });
            } 
            
            itemsToAdd.Add(new Item("Metal talisman", "A talisman imbued with Metal energy.", "talismanMetal", ColorLib.Steel, 20, true));
            itemsToAdd.Add(new Item("Water talisman", "A talisman imbued with Water energy.", "talismanWater", Color.DodgerBlue, 20, true));
            itemsToAdd.Add(new Item("Wood talisman", "A talisman imbued with Wood energy.", "talismanWood", Color.ForestGreen, 20, true));
            itemsToAdd.Add(new Item("Fire talisman", "A talisman imbued with Fire energy.", "talismanFire", Color.Firebrick, 20, true));
            itemsToAdd.Add(new Item("Earth talisman", "A talisman imbued with Earth energy.", "talismanEarth", Color.Yellow, 20, true));
            
            itemsToAdd.Add(new Item("Destruction talisman", "A talisman imbued with Destruction energy.", "talismanDestruction", Color.Crimson, 20, true));
            itemsToAdd.Add(new Item("Restoration talisman", "A talisman imbued with Restoration energy.", "talismanRestoration", Color.White, 20, true));
            itemsToAdd.Add(new Item("Alteration talisman", "A talisman imbued with Alteration energy.", "talismanAlteration", Color.Cyan, 20, true));
            itemsToAdd.Add(new Item("Mysticism talisman", "A talisman imbued with Mysticism energy.", "talismanMysticism", Color.MediumPurple, 20, true));
            itemsToAdd.Add(new Item("Conjuration talisman", "A talisman imbued with Conjuration energy.", "talismanConjuration", Color.Goldenrod, 20, true));
            itemsToAdd.Add(new Item("Illusion talisman", "A talisman imbued with Illusion energy.", "talismanIllusion", Color.HotPink, 20, true));

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
