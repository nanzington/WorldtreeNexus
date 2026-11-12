using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.DataTypes {
    public class CombatSim {
        public int CurrentHP = 0;
        public int MaxHP = 0;

        public int AttackLv = 1; // Attack if Melee, Magic if Magic, Ranged if Ranged 
        public int DefenseLv = 1;

        public int MaxDamage = 0;
        public string DamageType = "Crush";
        public string DamageElement = "Earth";

        public int AttackSpeedInMS = 2000;

        public int DRvsStyle = 0; 
        public string WeakType = "";
        public string Element = ""; 

        public int LastAttackTime = 0;


        public CombatSim() {}
        public CombatSim(int hp, int atk, int def, int maxDmg, string dmgType, string dmgElement, int atkSpeed, int dr, string weakType, string element) {
            CurrentHP = hp;
            MaxHP = hp;

            AttackLv = atk;
            DefenseLv = def;

            MaxDamage = maxDmg;
            DamageType = dmgType;
            DamageElement = dmgElement; 

            AttackSpeedInMS = atkSpeed;
            DRvsStyle = dr;

            WeakType = weakType;
            Element = element;
        }
    }

    public class CombatSim2 {
        public double CurrentHP = 0;
        public int MaxHP = 0;

        public int ToHit = 0; // Attack if Melee, Magic if Magic, Ranged if Ranged 
        public int ToArmor = 0; // AC is 10 + this

        public int MaxDamage = 0;
        public string DamageType = "Crush";
        public string DamageElement = "Earth";

        public int AttackSpeedInMS = 2000;

        public int DRvsStyle = 0; 
        public string WeakType = "";
        public string Element = "";  


        public CombatSim2() {}
        public CombatSim2(int hp, int toHit, int toArmor, int maxDmg, string dmgType, string dmgElement, int atkSpeed, int dr, string weakType, string element) {
            CurrentHP = hp;
            MaxHP = hp;

            ToHit = toHit;
            ToArmor = toArmor;

            MaxDamage = maxDmg;
            DamageType = dmgType;
            DamageElement = dmgElement; 

            AttackSpeedInMS = atkSpeed;
            DRvsStyle = dr;

            WeakType = weakType;
            Element = element;
        }
    }

    public class CombatSim3 {
        public double CurrentHP = 0;
        public int MaxHP = 0;

        public List<int> AttackDeck = new();
        public List<int> DefenseDeck = new(); 

        public int MaxDamage = 0;
        public string DamageType = "Crush";
        public string DamageElement = "Earth";

        public int AttackSpeedInMS = 2000;

        public int DRvsStyle = 0; 
        public string WeakType = "";
        public string Element = "";  


        public CombatSim3() {}
        public CombatSim3(int hp, int wepTier, int strBonus, int defenseLv, string dmgType, string dmgElement, int atkSpeed, int dr, string weakType, string element) {
            CurrentHP = hp;
            MaxHP = hp;

            AttackDeck = [ ..Enumerable.Range(1 + strBonus, Math.Max(1, (wepTier * 2) + 2)) ];
            DefenseDeck = [ ..Enumerable.Range(0, (defenseLv + 3)) ];

            DamageType = dmgType;
            DamageElement = dmgElement; 

            AttackSpeedInMS = atkSpeed;
            DRvsStyle = dr;

            WeakType = weakType;
            Element = element;
        }

        public double ElementMulti(string what) {
            if (Materials.ElementalWeaknesses.TryGetValue(Element, out string? weak) && weak != null && weak == what) { return 1.25; }
            if (Materials.ElementalStrengths.TryGetValue(Element, out string? strong) && strong != null && strong == what) { return 0.75; }
            return 1.0;
        }
    }
}
