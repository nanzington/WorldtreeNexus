using Newtonsoft.Json;
using System.Xml.Linq;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.DataTypes {
    public class BossFight {
        public string ID = ""; 
         
        public int Level = 1;

        public string SpecialCategory = "";
        public string KillItem = "";

        public int AggroLevel = 0; // If the players combat level is below this, the monster will automatically attack them 
        public bool AlwaysAggro = false;
         
        public int LanesHere = 3;
        public int RespawnTime = 20; 

        public List<ItemDrop> DropTable = new();
        public double ExpMultiplier = 1.0; 

        public List<BossPhase> Phases = new();

        [JsonIgnore]
        public int CurrentPhase = 0;
        [JsonIgnore]
        public int CurrentLane = 0;
        [JsonIgnore]
        public int UsingMove = -1;
        [JsonIgnore]
        public double TimeLastKilled = 0;
        [JsonIgnore]
        public bool AttackingPlayer = false;
        [JsonIgnore]
        public double TimeLastAttacked = 0;
        [JsonIgnore]
        public double MovesSinceSpecial = 0;
        [JsonIgnore]
        public int LaneWhenMoveSelected = -1;

        [JsonIgnore]
        public List<int> AttackDeck = [];
        [JsonIgnore]
        public List<int> DefenseDeck = [];

        public BossFight(string id, int level, List<BossPhase> phases, int lanes = 3, bool aggro = false) {
            ID = id;  
            Level = level;  
            
            if (aggro)
                AggroLevel = (level * 2) + 1;
            AlwaysAggro = aggro; 

            LanesHere = lanes; 

            Phases = phases; 
        }

        public string GetName() {
            if (Phases.Count > CurrentPhase) {
                return Phases[CurrentPhase].ProperName ? Phases[CurrentPhase].Name : "The " + Phases[CurrentPhase].Name.ToLower();
            } else { 
                return Phases[0].ProperName ? Phases[0].Name : "The " + Phases[CurrentPhase].Name.ToLower();
            }
        }

        public int CurrentHP() {
            if (Phases.Count > CurrentPhase) {
                return Phases[CurrentPhase].CurrentHP;
            } else { 
                return Phases[0].CurrentHP;
            }
        }

        public string GetWeakType() {
            if (Phases.Count > CurrentPhase) {
                return Phases[CurrentPhase].WeakType;
            } else { 
                return Phases[0].WeakType;
            }
        }

        public int GetDR() {
            if (Phases.Count > CurrentPhase) {
                return Phases[CurrentPhase].DamageReduction;
            } else { 
                return Phases[0].DamageReduction;
            }
        }

        public void TakeDamage(int dmg) {
            if (Phases.Count > CurrentPhase) {
                Phases[CurrentPhase].CurrentHP -= dmg;
            } else { 
                Phases[0].CurrentHP -= dmg;
            }
        }

        public void ResetAttackDeck() {
            if (Phases.Count > CurrentPhase) {
                AttackDeck = [ ..Enumerable.Range(1 + Phases[CurrentPhase].StrengthLv, Math.Max(1, (Phases[CurrentPhase].AttackLv * 2) + 2)) ]; 
            } else { 
                AttackDeck = [ ..Enumerable.Range(1 + Phases[0].StrengthLv, Math.Max(1, (Phases[0].AttackLv * 2) + 2)) ]; 
            }
        }

        public void ResetDefenseDeck() {
            if (Phases.Count > CurrentPhase) {
                DefenseDeck = [ ..Enumerable.Range(0, (Phases[CurrentPhase].DefenseLv + 3)) ];
            } else {
                DefenseDeck = [ ..Enumerable.Range(0, (Phases[0].DefenseLv + 3)) ];
            }
        }

        public double ElementMulti(string what) {
            if (Phases.Count > CurrentPhase) {
                if (Materials.ElementalWeaknesses.TryGetValue(Phases[CurrentPhase].Element, out string? weak) && weak != null && weak == what) { return 1.25; }
                if (Materials.ElementalStrengths.TryGetValue(Phases[CurrentPhase].Element, out string? strong) && strong != null && strong == what) { return 0.75; } 
            } else { 
                if (Materials.ElementalWeaknesses.TryGetValue(Phases[0].Element, out string? weak) && weak != null && weak == what) { return 1.25; }
                if (Materials.ElementalStrengths.TryGetValue(Phases[0].Element, out string? strong) && strong != null && strong == what) { return 0.75; }
            }
            return 1.0;
        }
    }
}
