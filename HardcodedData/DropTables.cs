using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class DropTables {

        public static List<ItemDrop> GenericHumanTable = new() {  
            new("bonesRegular", 1, 1, 1, 1),
            new("helmCopper", 1, 64, 1, 1), new("daggerBronze", 1, 128, 1, 1), 
            new("boltsCopper", 1, 6, 2, 12), new("arrowsCopper", 1, 43, 7, 7),
            new("coins", 1, 30, 5, 30),
            new("baitFish", 1, 26, 1, 1), new("cabbage", 1, 128, 1, 1), new("potionEnergy", 1, 15, 1, 1),
            new("clueScrollBeginner", 1, 90, 1, 1), new("clueScrollEasy", 1, 128, 1, 1)
        };

        public static List<ItemDrop> HerbSeeds = new() {  
            new("seedNeela", 1, 10, 1, 1), new("seedMidori", 1, 10, 1, 1),
            new("seedNimbu", 1, 20, 1, 1), new("seedKiiro", 1, 20, 1, 1),
            new("seedBaingani", 1, 30, 1, 1), new("seedMurasaki", 1, 30, 1, 1),
            new("seedLal", 1, 40, 1, 1), new("seedMazent", 1, 40, 1, 1),
            new("seedHara", 1, 50, 1, 1), new("seedKuriiro", 1, 50, 1, 1),
            new("seedGulabi", 1, 60, 1, 1), new("seedKusa", 1, 60, 1, 1),
            new("seedSiyan", 1, 70, 1, 1), new("seedNokoribi", 1, 70, 1, 1),
            new("seedSharab", 1, 80, 1, 1), new("seedAo", 1, 80, 1, 1),
            new("seedPeela", 1, 90, 1, 1), new("seedUmi", 1, 90, 1, 1),
            new("seedNarangi", 1, 100, 1, 1), new("seedAka", 1, 100, 1, 1)
        };
    }
}
