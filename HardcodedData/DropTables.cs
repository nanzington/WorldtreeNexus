using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class DropTables {

        public static List<ItemDrop> GenericHumanTable = [  
            new("bonesRegular"),
            new("helmCopper", y: 64), new("daggerBronze", y: 128), 
            new("boltsCopper", 1, 6, 2, 12), new("arrowsCopper", 1, 43, 7, 7),
            new("coins", 1, 30, 5, 30),
            new("baitFish", y: 26), new("cabbage", y: 128), new("potionEnergy", y: 15),
            new("clueScrollBeginner", y: 90), new("clueScrollEasy",y: 128)
        ];

        public static List<ItemDrop> SeedsHerbLow = [  
            new("seedNeela", y: 10), new("seedMidori", y: 10),
            new("seedNimbu", y: 20), new("seedKiiro", y: 20),
            new("seedBaingani", y: 30), new("seedMurasaki", y: 30),
            new("seedLal", y: 40), new("seedMazent", y: 40)
        ];

        public static List<ItemDrop> SeedsHerbAll = [ 
            new("seedNeela", y: 10), new("seedMidori", y: 10),
            new("seedNimbu", y: 20), new("seedKiiro", y: 20),
            new("seedBaingani", y: 30), new("seedMurasaki", y: 30),
            new("seedLal", y: 40), new("seedMazent", y: 40),
            new("seedHara", y: 50), new("seedKuriiro", y: 50),
            new("seedGulabi", y: 60), new("seedKusa", y: 60),
            new("seedSiyan", y: 70), new("seedNokoribi", y: 70),
            new("seedSharab", y: 80), new("seedAo", y: 80),
            new("seedPeela", y: 90), new("seedUmi", y: 90),
            new("seedNarangi", y: 100), new("seedAka", y: 100)
        ];

        public static List<ItemDrop> SeedsAllotmentLow = [
            new("seedPotato", y:10), new("seedOnion", y:10), new("seedCabbage", y:10), new("seedTomato", y:10), new("seedSweetcorn", y:10), new("seedLettuce", y:10), 
            new("seedBroccoli", y:10), new("seedCauliflower", y:10), new("seedBellpepper", y:10), new("seedCarrot", y:10), new("seedCucumber", y:10), new("seedSweetpeas", y:10)
        ];


        public static List<ItemDrop> SeedsAllLow = [ ..SeedsHerbLow, ..SeedsAllotmentLow ];
    }
}
