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
}
