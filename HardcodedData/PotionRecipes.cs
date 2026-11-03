using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.Hardcodes {
    public static class PotionRecipes {
        public static void InitRecipes(Dictionary<string, PotionRecipe> recipeLib) {
            List<PotionRecipe> toAdd = new();

            // Exp guidelines: 20 * higher tier of ingredient in perfect recipe


            // Traditional potions
            toAdd.Add(new("potionAttack", -14, -6, 2, 9, 20)); // Perfect: neela + cuy eye
            toAdd.Add(new("potionStrength", -6, 0, -13, 7, 40)); // Perfect: kiiro + unicorn horn dust
            
            /* Need more level 1 ingredients for these to really be viable
            toAdd.Add(new("potionDefense", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionRanged", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionMagic", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionMelee", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionCombat", 4, -6, 1, -11, 40));
            
            toAdd.Add(new("potionSuperAttack", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperStrength", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperDefense", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperMagic", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperRanged", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperMelee", 4, -6, 1, -11, 40));
            toAdd.Add(new("potionSuperCombat", 4, -6, 1, -11, 40));
            */


            // Essentia
            toAdd.Add(new("essenceRedUp", 1, 0, 0, 0, 240));
            toAdd.Add(new("essenceRedDown", -1, 0, 0, 0, 140));
            toAdd.Add(new("essenceBlackUp", 0, 1, 0, 0, 180)); 
            toAdd.Add(new("essenceBlackDown", 0, -1, 0, 0, 180));
            toAdd.Add(new("essenceYellowUp", 0, 0, 1, 0, 240)); 
            toAdd.Add(new("essenceYellowDown", 0, 0, -1, 0, 180));
            toAdd.Add(new("essenceWhiteUp", 0, 0, 0, 1, 180));
            toAdd.Add(new("essenceWhiteDown", 0, 0, 0, -1, 240));

             
            // Talisman inks
            toAdd.Add(new("inkNovice", -13, -12, -2, 12, 20)); // Perfect: midori + ground bones
            toAdd.Add(new("inkBeginner", -10, -4, -1, 12, 40)); // Perfect: nimbu + elm ashes
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
            toAdd.Add(new("oilInitiateUn", 0, -10, 10, -7, 20)); // Perfect: midori + poplar ashes
            /*toAdd.Add(new("oilAcolyteUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilDevoteeUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilDiscipleUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilAdeptUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilClericUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilPriestUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilBishopUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilHierophantUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilExarchUn", 0, 0, 0, 0, 240)); 
            toAdd.Add(new("oilGodsUn", 0, 0, 0, 0, 240)); */

            for (int i = 0; i < toAdd.Count; i++) {
                recipeLib.TryAdd(toAdd[i].PotionID, toAdd[i]);
            }
        }
    }
}
