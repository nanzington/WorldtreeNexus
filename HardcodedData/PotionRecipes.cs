using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.Hardcodes {
    public static class PotionRecipes {
        public static void InitRecipes(Dictionary<string, PotionRecipe> recipeLib) {
            List<PotionRecipe> toAdd = new();

            // Exp guidelines: 20 * higher tier of ingredient in perfect recipe


            // Traditional potions
            toAdd.Add(new("potionAttack", 8, 3, -5, 3, 20)); // Perfect: neela + cuy eye
            toAdd.Add(new("potionStrength", 4, -6, 1, -11, 40)); // Perfect: kiiro + unicorn horn dust



            // Essentia
            toAdd.Add(new("essenceRedUp", 1, 0, 0, 0, 240));
            toAdd.Add(new("essenceRedDown", -1, 0, 0, 0, 180)); // Perfect: katalox ashes + nox prima (black up)
            toAdd.Add(new("essenceBlackUp", 0, 1, 0, 0, 180)); // Perfect: aka + gelus ultima (white down)
            toAdd.Add(new("essenceBlackDown", 0, -1, 0, 0, 180)); // Perfect: katalox ashes + ignis prima (red up)
            toAdd.Add(new("essenceYellowUp", 0, 0, 1, 0, 240));
            toAdd.Add(new("essenceYellowDown", 0, 0, -1, 0, 180)); // Perfect: narangi + lux prima (yellow up)
            toAdd.Add(new("essenceWhiteUp", 0, 0, 0, 1, 180)); // Perfect: aka + nox ultima (black down)
            toAdd.Add(new("essenceWhiteDown", 0, 0, 0, -1, 240));

             
            // Talisman inks
            toAdd.Add(new("inkNovice", 5, -4, 5, -2, 120)); // Perfect: midori + nokoribi, Easy: (midori + ground bones + diluted with vial of water)
            toAdd.Add(new("inkBeginner", 3, -7, -1, 3, 40)); // Perfect: nimbu + elm ashes
            /*toAdd.Add(new("inkApprentice", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkAdept", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkJourneyman", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkExpert", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkArtisan", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkMaster", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkGrandmaster", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkParagon", 0, 0, 0, -1, 240));
            toAdd.Add(new("inkDivine", 0, 0, 0, -1, 240));*/


            // Prayer oils
            toAdd.Add(new("oilInitiate", 2, 0, 1, 3, 20)); // Perfect: midori + poplar ashes
            /*toAdd.Add(new("oilAcolyte", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilDevotee", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilDisciple", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilAdept", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilCleric", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilPriest", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilBishop", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilHierophant", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilExarch", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilGods", 0, 0, 0, 0, 240)); */

            for (int i = 0; i < toAdd.Count; i++) {
                recipeLib.TryAdd(toAdd[i].PotionID, toAdd[i]);
            }
        }
    }
}
