using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class SpellCombat {
        public string Name = "";
        public string Element = "Metal";
        public string DamageType = "Bolt"; // Bolt, Ray, Wave. No general difference, but enemies can be weak to one of these three in which case it'll do much damage to them.
        public double Speed = 1.0; // Slower = +50% damage (min +2) but 1.5x attack speed, Slow = +25% (min 1) @ 1.25x speed, Medium = +0 @ 1x speed, Fast = -25% (min -1) @ 0.75x speed, Faster = -50% (min -2) @ 0.5x speed
        public int Tier = 1;

        public bool Empowered = false; // If true, also costs (tier / 2) talismans of the empowering type (rounded up), but does 25% more damage
        public bool Lingering = false; // If true, costs 50% more destruction talismans but applies (tier) DoT (each second they take DoT damage then it goes down by 1)
        public bool Vampiric = false; // If true, costs (tier / 2) restoration talismans (rounded up) but you heal for 10% of damage dealt (also rounded up)


        [JsonConstructor]
        public SpellCombat() {}

        public SpellCombat(string name, string element, string damage, double speed, int tier, bool empower = false, bool linger = false, bool vamp = false) {
            Name = name;
            Element = element;
            DamageType = damage;
            Speed = speed;
            Tier = tier;

            Empowered = empower;
            Lingering = linger;
            Vampiric = vamp;
        }

        public SpellCombat(SpellCombat other) {
            Name = other.Name;
            Element = other.Element;
            DamageType = other.DamageType;
            Speed = other.Speed;
            Tier = other.Tier;

            Empowered = other.Empowered;
            Lingering = other.Lingering;
            Vampiric = other.Vampiric;
        }

        public bool Equals(SpellCombat other) {
            if (Name != other.Name) return false;
            if (Element != other.Element) return false;
            if (DamageType != other.DamageType) return false;
            if (Speed != other.Speed) return false;
            if (Tier != other.Tier) return false;

            if (Empowered != other.Empowered) return false;
            if (Lingering != other.Lingering) return false;
            if (Vampiric != other.Vampiric) return false;

            return true;
        }

        public int LevelReq() {
            return Tier == 1 ? 1 : Tier * 10;
        }

        public List<string> Talismans() {
            List<string> talismans = new();

            talismans.Add("talisman" + Element + "," + Tier);

            if (Empowered) {
                if (Element == "Metal") { talismans.Add("talismanEarth," + (int) Math.Ceiling(Tier / 2.0)); }
                if (Element == "Water") { talismans.Add("talismanMetal," + (int) Math.Ceiling(Tier / 2.0)); }
                if (Element == "Wood") { talismans.Add("talismanWater," + (int) Math.Ceiling(Tier / 2.0)); }
                if (Element == "Fire") { talismans.Add("talismanWood," + (int) Math.Ceiling(Tier / 2.0)); }
                if (Element == "Earth") { talismans.Add("talismanFire," + (int) Math.Ceiling(Tier / 2.0)); }
            }

            talismans.Add("talismanDestruction," + (Lingering ? ((int) Math.Ceiling(Tier * 1.5)) : Tier));

            if (Vampiric) {
                talismans.Add("talismanRestoration," + (int) Math.Ceiling(Tier / 2.0));
            }

            return talismans;
        }

        public string GetName(bool skipSet = false) {
            if (Name != "" && !skipSet) { return Name; }

            List<string> numerals = ["I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI" ];

            string build = "";

            if (Empowered) { build += "Emp"; } 
            if (Lingering) { build += "Linger"; }
            if (Vampiric) { build += "Vamp"; }

            build += (build == "" ? "" : " ") + Element + " " + DamageType + " " + numerals[Tier - 1];

            if (Speed == 1.5) { build += " ++"; }
            if (Speed == 1.25) { build += " +"; }
            if (Speed == 0.75) { build += " -"; }
            if (Speed == 0.5) { build += " --"; }

            return build;
        }

        public int CastExp() {
            List<string> tali = Talismans();

            int count = 0;

            foreach (var str in tali) {
                string[] split = str.Split(",");

                if (split.Length > 1) {
                    int.TryParse(split[1], out int num);

                    count += num;
                }
            }

            return count * 3;
        }
    }
}
