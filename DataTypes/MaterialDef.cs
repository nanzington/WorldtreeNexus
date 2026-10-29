namespace WorldtreeNexus.DataTypes {
    public class MaterialDef {
        public string Name = "";
        public string SimpleName = "";
        public int R = 255;
        public int G = 255;
        public int B = 255;
        public int A = 255;

        public double Tier = 1;
        public int Level = 1;

        public int CostMultiplier = 1;
        public int ExpMultiplier = 1;
        public string Descriptor = "";
        public string OtherMaterial = "";

        public MaterialDef(string name, Color c, double tier, int lv, int cost, int exp, string desc, string simple = "", string extraMat = "") : this(name, c.R, c.G, c.B, c.A, tier, lv, cost, exp, desc, simple, extraMat) { }

        public MaterialDef(string name, int r, int g, int b, int a, double tier, int lv, int cost, int exp, string desc, string simple = "", string extraMat = "") {
            Name = name;
            R = r;
            G = g;
            B = b;
            A = a;
            Tier = tier;
            Level = lv;

            CostMultiplier = cost;
            ExpMultiplier = exp;
            Descriptor = desc;
            SimpleName = simple;
            OtherMaterial = extraMat;
        } 

        public Color GetColor() {
            return new Color(R, G, B, A);
        }
    }
}
