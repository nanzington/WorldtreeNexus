using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldtreeNexus.DataTypes {
    public class AreaMonster {
        public string Name = "";
        public string ID = "";
        public bool ProperName = false;

        public int Level = 1;
        public int CurrentHP = 1;
        public int MaxHP = 1;

        public int AttackLv = 1;
        public int DefenseLv = 1;

        public int DamageReduction = 0;

        public int AggroLevel = 0; // If the players combat level is below this, the monster will automatically attack them 
        public bool AlwaysAggro = false;

        public int MaxHit = 3; 
        public string WeakType = "Slash";
        public string Element = "Earth";
        public string DamageType = "Typeless";
        public double AttackSpeedSeconds = 2.4;
        
        public int PoisonSeverity = 0;


        public int RespawnTime = 1;

        public List<ItemDrop> DropTable = new();

        public List<Requirement> Requirements = new();
        public bool SeeWithoutRequirements = true;

        public bool Inaccessible = false;
        public string SpecialCategory = "";
        public string KillItem = "";
        public int KillItemCount = 0;

        public bool Temporary = false; // If temporary, when this is killed remove it from the list
        

        [JsonIgnore]
        public double TimeLastKilled = 0;
        [JsonIgnore]
        public bool AttackingPlayer = false;
        [JsonIgnore]
        public double TimeLastAttacked = 0;

        public AreaMonster(string n, string id, int lv, int hp, int dr, int atk, int def, bool aggro, int maxhit, string weakness, string element, int respawn, string dtype, double atkSpeed = 2.4, List<Requirement>? reqs = null, bool seeAnyways = true, bool inaccessible = false, string specialCat = "", bool proper = false, bool temp = false) {
            Name = n;
            ID = id;
            Level = lv;
            MaxHP = hp;
            CurrentHP = hp;
            DamageReduction = dr;

            AttackLv = atk;
            DefenseLv = def;

            AggroLevel = (lv * 2) + 1;
            AlwaysAggro = aggro;

            MaxHit = maxhit; 
            WeakType = weakness;
            DamageType = dtype;
            AttackSpeedSeconds = atkSpeed;
            Element = element;

            RespawnTime = respawn;
            Inaccessible = inaccessible;
            SpecialCategory = specialCat; 

            if (reqs != null)
                Requirements = reqs;
            SeeWithoutRequirements = seeAnyways;

            ProperName = proper;
            Temporary = temp;
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

            build += Name + ": Deals up to " + MaxHit + " " + DamageType + " damage. Weak to " + WeakType + ". " + Element + "-aligned.";

            if (DamageReduction > 0)
                build += " " + DamageReduction + " DR.";

            if (SpecialCategory != "") {
                build += " Counts as " + SpecialCategory + ".";
            }

            return build;
        }

        public CombatSim GetSimBlock() {
            return new CombatSim(MaxHP, AttackLv, DefenseLv, MaxHit, DamageType, Element, AttackSpeedSeconds * 2000, DamageReduction, WeakType, Element);
        }
    }
}
