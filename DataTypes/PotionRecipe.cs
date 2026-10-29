namespace WorldtreeNexus.DataTypes {
    public class PotionRecipe {
        public string PotionID = "";
        public int Red = 0;
        public int Black = 0;
        public int Yellow = 0;
        public int White = 0;
        public int ExpGranted = 0;

        public List<string> RequiredIngredients = new();
        public List<string> RequiredActions = new();

        public PotionRecipe(string id, int r, int b, int y, int w, int exp, List<string>? ingredients = null, List<string>? acts = null) {
            PotionID = id;
            Red = r;
            Black = b;
            Yellow = y;
            White = w;
            ExpGranted = exp;

            if (ingredients != null) { RequiredIngredients = ingredients; } 
            if (acts != null) { RequiredActions = acts; }
        }

        public bool ReqsMet(AlchemyStats stats) {
            if (Red != stats.Red) { return false; }
            if (Black != stats.Black) { return false; }
            if (Yellow != stats.Yellow) { return false; }
            if (White != stats.White) { return false; }

            foreach (var ing in RequiredIngredients) {
                if (!stats.Ingredients.Contains(ing)) { return false; }
            }

            foreach (var act in RequiredActions) {
                if (!stats.ActionsTaken.Contains(act)) { return false; }
            }

            return true;
        }
    }
}
