using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.Hardcodes {
    public static class PotionRecipes {
        public static void InitRecipes(Dictionary<string, PotionRecipe> recipeLib) {
            List<PotionRecipe> toAdd = new();

            // Exp guidelines: 20 * higher tier of ingredient in perfect recipe


            // Traditional potions
            toAdd.Add(new("potionAttack", r: -14, b: -6, y: 2, w: 9, exp: 20, pLv: 1)); // Perfect: neela + cuy eye
            toAdd.Add(new("potionStrength", r: -6, b: 0, y: -13, w: 7, exp: 40, pLv: 10)); // Perfect: kiiro + unicorn horn dust
             
            toAdd.Add(new("potionDefense", r: 0, b: -2, y: -17, w: -13, exp: 20, pLv: 1)); // Perfect: cod scales + raw bear meat
            toAdd.Add(new("potionRanged", r: 19, b: 18, y: 3, w: -10, exp: 20, pLv: 1)); // Perfect: broccoli + chocolate dust
            toAdd.Add(new("potionMagic", r: 4, b: -11, y: -2, w: -4, exp: 20, pLv: 1)); // Perfect: shaggy mane + midori
            toAdd.Add(new("potionMelee", r: 11, b: 18, y: -1, w: -13, exp: 40, pLv: 10)); // Perfect: raw bear meat + bronze shavings
            toAdd.Add(new("potionCombat", r: 9, b: 7, y: 9, w: 16, exp: 60, pLv: 20)); // Perfect: baingani + minnow scales
            
            /* Need more level 1 ingredients for these to really be viable
            toAdd.Add(new("potionSuperAttack", r: 0, b: 0, y: 0, w: 0, exp: 80, pLv: 30));
            toAdd.Add(new("potionSuperStrength", r: 0, b: 0, y: 0, w: 0, exp: 80, pLv: 30));
            toAdd.Add(new("potionSuperDefense", r: 0, b: 0, y: 0, w: 0, exp: 80, pLv: 30));
            toAdd.Add(new("potionSuperMagic", r: 0, b: 0, y: 0, w: 0, exp: 80, pLv: 30));
            toAdd.Add(new("potionSuperRanged", r: 0, b: 0, y: 0, w: 0, exp: 80, pLv: 30));
            toAdd.Add(new("potionSuperMelee", r: 0, b: 0, y: 0, w: 0, exp: 100, pLv: 40));
            toAdd.Add(new("potionSuperCombat", r: 0, b: 0, y: 0, w: 0, exp: 120, pLv: 50));
            */


            // Essentia
            toAdd.Add(new("essenceRedUp", r: 1, b: 0, y: 0, w: 0, exp: 240, pLv: 101));
            toAdd.Add(new("essenceRedDown", r: -1, b: 0, y: 0, w: 0, exp: 140, pLv: 101));
            toAdd.Add(new("essenceBlackUp", r: 0, b: 1, y: 0, w: 0, exp: 180, pLv: 101)); 
            toAdd.Add(new("essenceBlackDown", r: 0, b: -1, y: 0, w: 0, exp: 180, pLv: 101));
            toAdd.Add(new("essenceYellowUp", r: 0, b: 0, y: 1, w: 0, exp: 240, pLv: 101)); 
            toAdd.Add(new("essenceYellowDown", r: 0, b: 0, y: -1, w: 0, exp: 180, pLv: 101));
            toAdd.Add(new("essenceWhiteUp", r: 0, b: 0, y: 0, w: 1, exp: 180, pLv: 101));
            toAdd.Add(new("essenceWhiteDown", r: 0, b: 0, y: 0, w: -1, exp: 240, pLv: 101));

             
            // Talisman inks
            toAdd.Add(new("inkNovice", r: -13, b: -12, y: -2, w: 12, exp: 20, pLv: 1)); // Perfect: midori + ground bones
            toAdd.Add(new("inkBeginner", r: -10, b: -4, y: -1, w: 12, exp: 40, pLv: 10)); // Perfect: nimbu + elm ashes
            /*toAdd.Add(new("inkApprentice", r: 12, b: -9, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkAdept", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkJourneyman", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkExpert", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkArtisan", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkMaster", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkGrandmaster", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkParagon", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));
            toAdd.Add(new("inkDivine", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1));*/


            // Prayer oils
            toAdd.Add(new("oilInitiateUn", r: 0, b: -10, y: 10, w: -7, exp: 20, pLv: 1)); // Perfect: midori + poplar ashes
            toAdd.Add(new("oilAcolyteUn", r: 10, b: 21, y: 1, w: -13, exp: 40, pLv: 10)); // Perfect: bronze shavings + tea leaves
            /*toAdd.Add(new("oilDevoteeUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilDiscipleUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilAdeptUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilClericUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilPriestUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilBishopUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilHierophantUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilExarchUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); 
            toAdd.Add(new("oilGodsUn", r: 0, b: 0, y: 0, w: 0, exp: 240, pLv: 1)); */

            for (int i = 0; i < toAdd.Count; i++) {
                recipeLib.TryAdd(toAdd[i].PotionID, toAdd[i]);
            }
        }
    }
}
