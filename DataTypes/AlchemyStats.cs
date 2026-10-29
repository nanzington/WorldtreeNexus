using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class AlchemyStats {
        public int Red = 0;
        public int Black = 0;
        public int Yellow = 0;
        public int White = 0;
        public int Level = 0;

        public List<string> ActionsTaken = new();
        public List<string> Ingredients = new();

        [JsonConstructor]
        public AlchemyStats() {}

        public AlchemyStats(int r, int b, int y, int w, int lev) {
            Red = r;
            Black = b;
            Yellow = y;
            White = w;
            Level = lev;
        }

        public AlchemyStats(AlchemyStats other) {
            Red = other.Red;
            Black = other.Black;
            Yellow = other.Yellow;
            White = other.White;
            Level = other.Level;

            ActionsTaken = new(other.ActionsTaken);
            Ingredients = new(other.Ingredients);
        }

        public bool CheckMatch(AlchemyStats other) {
            if (Red != other.Red) { return false; }
            if (Black != other.Black) { return false; } 
            if (Yellow != other.Yellow) { return false; }
            if (White != other.White) { return false; }
            
            if (ActionsTaken.Count != other.ActionsTaken.Count) { return false; }
            if (Ingredients.Count != other.Ingredients.Count) { return false; }

            foreach (var act in other.ActionsTaken) { if (!ActionsTaken.Contains(act)) { return false; } }
            foreach (var ing in other.Ingredients) { if (!Ingredients.Contains(ing)) { return false; } }

            return true;
        }

        public AlchemyStats Plus(AlchemyStats other) {
            List<string> ing = new(Ingredients);
            ing.AddRange(other.Ingredients);

            List<string> acts = new(ActionsTaken);
            acts.AddRange(other.ActionsTaken);

            AlchemyStats output = new(Red + other.Red, Black + other.Black, Yellow + other.Yellow, White + other.White, 1) {
                Ingredients = ing,
                ActionsTaken = acts
            };

            return output;
        }
    }
}
