using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class BossPhase { 
        public string Name = "";
        public bool ProperName = false;
        public int CurrentHP = 1;
        public int MaxHP = 1;

        public string WeakType = "Slash";
        public string Element = "Earth";
        public List<string> ImmuneTypes = [];

        public int DamageReduction = 0; // Reduce damage by this as a percent unless using their weakness

        public int AttackLv = 1;  
        public int StrengthLv = 0;
        public int DefenseLv = 1;
        public string DefaultDmgType = "Typeless"; 
        public int DefaultPoisonSeverity = 0;
        public List<BossAttack> Specials = [];
          
        public double AttackSpeedSeconds = 1.0;
        public int AttacksBetweenSpecials = 3; 

        public List<BossPhaseCondition> PhaseConditions = [];

        public int HitActionOdds = 0; // 1 in this that hit actions will be triggeredd
        public List<RunAction> HitActions = [];

        public List<RunAction> DeathActions = [];

        public List<Requirement> InvincibleIfAll = [];
         
        public BossPhase(string name, int maxHP, int atk, int str, int def, string weak, string element, string defDmgType, int dr = 0, double attackSpeed = 1.0) {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = maxHP;

            Element = element;
            WeakType = weak;
            DamageReduction = dr;

            AttackLv = atk;
            StrengthLv = str;
            DefenseLv = def;
             
            DefaultDmgType = defDmgType;
            AttackSpeedSeconds = attackSpeed; 
        }
    }
}
