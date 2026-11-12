using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.DataTypes {
    public class AreaMonster {
        public string Name = "";
        public string ID = "";
        public bool ProperName = false;

        public int Level = 1; // Just kind of a meaningless guess to try to indicate how strong an enemy might be
        public int CurrentHP = 1;
        public int MaxHP = 1;

        public int AttackLv = 1;
        public int StrengthLv = 0;
        public int DefenseLv = 1;

        public int DamageReduction = 0;

        public int AggroLevel = 0; // If the players combat level is below this, the monster will automatically attack them 
        public bool Aggressive = false;

        public string WeakType = "Slash";
        public string Element = "Earth";
        public string DamageType = "Typeless";
        public double AttackSpeedSeconds = 1.0;
        
        public int PoisonSeverity = 0;


        public int RespawnTime = 5;

        public List<ItemDrop> DropTable = new();

        public List<Requirement> Requirements = new();
        public bool SeeWithoutRequirements = true;

        public bool Inaccessible = false;
        public string SpecialCategory = "";
        public string KillItem = "";
        public int KillItemCount = 0;
        public string AlchemySecretionID = ""; // Usually blood, venom, slime, etc. Get with extraction kit on nonhostile, or automatically after buying upgrade

        public bool Temporary = false; // If temporary, when this is killed remove it from the list
        

        [JsonIgnore]
        public double TimeLastKilled = 0;
        [JsonIgnore]
        public bool AttackingPlayer = false;
        [JsonIgnore]
        public double TimeLastAttacked = 0;
        [JsonIgnore]
        public List<int> AttackDeck = new();
        [JsonIgnore]
        public List<int> DefenseDeck = new();

        public AreaMonster(string name, string id, int level, int hp, int atk, int str, int def, bool aggro, string weak, string element, string dmgType, int dr = 0, double atkSpeed = 1.0) {
            Name = name;
            ID = id;
            Level = level;
            MaxHP = hp;
            CurrentHP = hp;

            AttackLv = atk;
            StrengthLv = str;
            DefenseLv = def;

            AggroLevel = (level * 2) + 1;
            Aggressive = aggro;

            WeakType = weak;
            Element = element;
            DamageType = dmgType;

            DamageReduction = dr;

            AttackSpeedSeconds = atkSpeed;

        } 

        public bool AllReqsMet(Player p) {
            bool all = true;

            if (Requirements != null && Requirements.Count > 0) {
                for (int i = 0; i < Requirements.Count; i++) {
                    if (!Requirements[i].CheckRequirement(p, false, true)) {
                        all = false;
                    }
                }
            }

            return all;
        }

        public string GetSummary() {
            string build = "";

            build += Name + ": Deals up to " + (AttackLv + StrengthLv) + " " + DamageType + " damage. Weak to " + WeakType + ". " + Element + "-aligned.";

            if (DamageReduction > 0)
                build += " " + DamageReduction + " DR.";

            if (SpecialCategory != "") {
                build += " Counts as " + SpecialCategory + ".";
            }

            return build;
        }

        public CombatSim3 GetSimBlock() {
            return new CombatSim3(MaxHP, AttackLv, StrengthLv, DefenseLv, DamageType, Element, (int) (AttackSpeedSeconds * 2000), DamageReduction, WeakType, Element); 
        }

        public void ResetAttackDeck() {
            AttackDeck = [ ..Enumerable.Range(1 + StrengthLv, Math.Max(1, (AttackLv * 2) + 2)) ]; 
        }

        public void ResetDefenseDeck() { 
            DefenseDeck = [ ..Enumerable.Range(0, (DefenseLv + 3)) ];
        }

        public double ElementMulti(string what) {
            if (Materials.ElementalWeaknesses.TryGetValue(Element, out string? weak) && weak != null && weak == what) { return 1.25; }
            if (Materials.ElementalStrengths.TryGetValue(Element, out string? strong) && strong != null && strong == what) { return 0.75; }
            return 1.0;
        }
    }
}
