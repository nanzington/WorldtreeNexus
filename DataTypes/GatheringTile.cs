using Newtonsoft.Json;
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class GatheringTile {
        public string Name = "";
        public string ID = "";

        public string Skill = "";
        public int Level = 1;
        public int ExpGranted = 0;

        public string InteractVerb = ""; 
        public int DepleteChance = 100;

        public int RestockTime = 1; 
         
        public string NeedToolCat = "";
        public string NeededBait = "";
        public string CustomLogMessage = "";

        public List<RunAction> Actions = new();
        public List<Requirement> Reqs = new();
        public bool ShowAnyways = true;

        public List<WeightedItem>? PossibleItems = null;

        [JsonIgnore]
        public double LastGathered = 0;

        public GatheringTile(string id, string name, string verb, int deplete, int restock, string skill = "", int skLevel = 0, int exp = 0, string neededTool = "", string neededBait = "", List<WeightedItem>? items = null, List<Requirement>? reqs = null, bool show = true, List<RunAction>? actions = null, string customLog = "") {
            ID = id;
            Name = name;
            InteractVerb = verb; 
            DepleteChance = deplete;
            RestockTime = restock;

            PossibleItems = items;
            Skill = skill;
            Level = skLevel;
            ExpGranted = exp; 
              
            NeedToolCat = neededTool;
            NeededBait = neededBait;


            if (actions != null)
                Actions = actions;
            if (reqs != null)
                Reqs = reqs;
            
            ShowAnyways = show; 
            CustomLogMessage = customLog;
        }


        public WeightedItem? PickItem(int level) {
            if (PossibleItems != null && PossibleItems.Count > 0)
                return Helper.ChooseWeighted(PossibleItems, Skill, level);
            return null;
        }

        public void Gather(Player p, MessageLog log, Dictionary<string, Item> itemLibrary, Location currentLoc, List<Skill> Recents) {
            if (CanGather(p) == "") {
                foreach (var act in Actions) { act.Execute();  } 
                ClueLogic.GenericStep(p, log, "Gather", ID);  
                
                int esl = 100;
                int levelDiff = Level - esl; // if they don't specify a skill it should essentially just autosucceed every time for now, may need to revisit later
                if (Skill != "") {
                    esl = p.GetEffectiveSkillLevel(Skill); 
                    levelDiff = Level - esl; // apply by subtracting this from your esl during the roll. so negative is good by making your target number higher

                    if (NeedToolCat != "") {  
                        foreach (var kv in p.Equipment) {
                            if (kv.Value.GetRef() is Item eqp && eqp.MiscString == NeedToolCat) {
                                if (eqp.EquipLevel <= p.GetEffectiveSkillLevel(Skill)) { 
                                    levelDiff = Level - eqp.EquipLevel; // Readjust based on tool used level instead of player level, this is where it can become positive and become a penalty
                                }
                            }
                        }

                        for (int i = 0; i < p.Inventory.Count; i++) {
                            if (p.Inventory[i].GetRef() is Item inv && inv.MiscString == NeedToolCat) {
                                if (inv.EquipLevel <= p.GetEffectiveSkillLevel(Skill)) {
                                    levelDiff = Level - inv.EquipLevel; // Readjust based on tool used level instead of player level, this is where it can become positive and become a penalty
                                }
                            }
                        }

                        // This should result in levelDiff being negative if they're using a higher tool, zero if tool is equal, positive if tool is worse than level req
                    }  
                }

                if (NeededBait != "") { p.ConsumeItems([NeededBait + ",1"]); } 
                     
                 
                WeightedItem? output = PickItem(esl);

                // Check to see if a quest is progressed by gathering from this type of gatherSpot successfully
                foreach (var quest in GameLoop.WTN.QuestLibrary) { quest.Value.CheckProgress(p, "Gather", ID, 1); }
                 
                if (CustomLogMessage != "") { log.AddMessage(new ColoredString(CustomLogMessage, Color.Yellow, Color.Black)); }

                if (PossibleItems != null && PossibleItems.Count > 0) {
                    if (output != null && itemLibrary.TryGetValue(output.Item, out Item? receive) && receive != null) {
                        // Try to pick it up, if it failed then it fell to the ground.
                        if (p.TryPickup(receive, 1)) {
                            log.AddMessage(new ColoredString("You get " + receive.Name.ToLower() + " from the " + Name + ".", Color.Green, Color.Black));
                        } else {
                            log.AddMessage(new ColoredString("Your inventory is full so the " + receive.Name.ToLower() + " falls to the ground.", Color.Goldenrod, Color.Black));
                        }

                        // Check to see if a quest is progressed by gathering this specific item
                        foreach (var quest in GameLoop.WTN.QuestLibrary) { quest.Value.CheckProgress(p, "GatheredItem", output.Item, 1); }

                        // If the output specifies a different exp gained give that, otherwise give the normal exp
                        if (Skill != "") {
                            if (output.MiscInt2 != 0) { p.TryGrantExp(Skill, output.MiscInt2, log, Recents); } 
                            else { p.TryGrantExp(Skill, ExpGranted, log, Recents); }
                        }

                        int deplete = GameLoop.rand.Next(100) + 1; 
                        if (deplete <= DepleteChance) { LastGathered = Helper.Time(); } 
                    } else {
                        log.AddMessage(new ColoredString("You " + InteractVerb.ToLower() + " the " + Name.ToLower() + " but got nothing.", Color.Crimson, Color.Black)); 
                    }  
                }
            } else {
                log.AddMessage(new ColoredString("You need " + CanGather(p) + " to do that.", Color.Crimson, Color.Black));
            }
        } 

        public string CanGather(Player p) { 
            if (p.Skills.ContainsKey(Skill) && p.Skills[Skill].Level < Level)
                return Level + " " + Skill;
            if (LastGathered + (RestockTime * 1000) > Helper.Time() && LastGathered != 0)
                return "to wait for it to replenish";
            if (!p.Skills.ContainsKey(Skill) && Level > 0)
                return Level + " " + Skill;
            if (NeedToolCat != "") {
                bool foundTool = false;
                foreach (var kv in p.Equipment) {
                    if (kv.Value.GetRef() is Item eqp && eqp.MiscString == NeedToolCat) {
                        if (eqp.EquipLevel <= p.GetEffectiveSkillLevel(Skill)) {
                            foundTool = true;
                        }
                    }
                }

                for (int i = 0; i < p.Inventory.Count; i++) {
                    if (p.Inventory[i].GetRef() is Item inv && inv.MiscString == NeedToolCat) {
                        if (inv.EquipLevel <= p.GetEffectiveSkillLevel(Skill)) {
                            foundTool = true;
                        }
                    }
                }

                if (!foundTool)
                    return "a " + NeedToolCat;
            }

            if (NeededBait != "") {
                if (NeededBait != "keyClue") {
                    if (!p.HasAllItems([NeededBait + ",1"])) {
                        return "a " + GameLoop.WTN.ResolveItemName(NeededBait).ToLower(); 
                    }
                } else {
                    return "a clue key, likely dropped by a nearby monster.";
                }
            }

            if (Reqs != null && Reqs.Count > 0) {
                foreach (var req in Reqs) {
                    if (!req.CheckRequirement(p, false, true)) {
                        return req.GetSummary();
                    }
                }
            }

            return "";
        }
    }
}
