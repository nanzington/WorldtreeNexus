namespace WorldtreeNexus.DataTypes {
    public class Requirement {
        public string RequirementType = "";
        public int MiscInt = 0;
        public int MiscInt2 = 0;
        public string MiscString = "";
        public string MiscString2 = "";
        public bool ConsumeItem = false;

        public string CustomSummary = "";

        public Requirement(string ty, int misc1 = 0, string misc2 = "", bool consume = false, string misc3 = "", string summ = "", int miscint2 = 0) {
            RequirementType = ty;
            MiscInt = misc1;
            MiscInt2 = miscint2;
            MiscString = misc2;
            MiscString2 = misc3;
            ConsumeItem = consume;
            CustomSummary = summ;
        }

        public string GetSummary() {
            if (CustomSummary != "") {
                return CustomSummary;
            }

            if (RequirementType == "Skill") {
                if (MiscString == "All") { 
                    return "Need level " + MiscInt + " in all skills";
                } 
                return "Need level " + MiscInt + " " + MiscString;
            }

            if (RequirementType == "NotSkill") {
                if (MiscString == "All") { 
                    return "Need below level " + MiscInt + " in all skills";
                }
                return "Need below level " + MiscInt + " " + MiscString;
            }

            if (RequirementType == "QuestAt") {
                if (GameLoop.WTN.QuestLibrary.TryGetValue(MiscString, out Quest? req)) {
                    if (req != null) {
                        if (req.CompleteStage == MiscInt)
                            return "Completed Quest: " + req.Name;
                        else
                            return "Quest: " + req.Name + " [stage " + MiscInt + "]";
                    }
                }

                return "Progessed " + MiscString + " to a point";
            }

            if (RequirementType == "QuestNot") {
                if (GameLoop.WTN.QuestLibrary.TryGetValue(MiscString, out Quest? req)) {
                    if (req != null) {
                        if (req.CompleteStage == MiscInt)
                            return "Not completed Quest: " + req.Name;
                        else
                            return "Quest: " + req.Name + " [not stage " + MiscInt + "]";
                    }
                }

                return "Not at this stage of " + MiscString;
            }

            if (RequirementType == "QuestBelow") {
                if (GameLoop.WTN.QuestLibrary.TryGetValue(MiscString, out Quest? req)) {
                    if (req != null) {
                        return "Quest: " + req.Name + " [Below Stage " + MiscInt + "]";
                    }
                }

                return "Incomplete " + MiscString;
            }

            if (RequirementType == "QuestPast") {
                if (GameLoop.WTN.QuestLibrary.TryGetValue(MiscString, out Quest? req)) {
                    if (req != null) {
                        return "Quest: " + req.Name + " [At or Above Stage " + MiscInt + "]";
                    }
                }

                return "Partial Completion " + MiscString;
            }

            if (RequirementType == "Item") {
                if (MiscString == "Gold") {
                    return "Need " + MiscInt + " gold";
                }
                return "Need " + MiscInt + "x " + GameLoop.WTN.ResolveItemName(MiscString);
            }

            if (RequirementType == "NotItem") { 
                return "Need to NOT have " + MiscInt + "x " + GameLoop.WTN.ResolveItemName(MiscString);
            }

            if (RequirementType == "CollectionLogComplete") {
                if (MiscString.Contains("clue"))
                    return "Completed the " + MiscString + " collection log";
                else if (MiscString.Contains("boss")) {
                    return "Completed the " + GameLoop.WTN.ResolveBossName(MiscString) + " collection log";
                }
                else {
                    return "Completed the " + GameLoop.WTN.ResolveMonsterName(MiscString) + " collection log";
                }
            }

            if (RequirementType == "KillCount") {
                if (MiscString.Contains("clue"))
                    return "Completed " + MiscInt + "x " + MiscString;
                else {
                    return "Killed " + MiscInt + "x " + GameLoop.WTN.ResolveMonsterName(MiscString);
                }
            } 

            if (RequirementType == "NotWearing") { 
                return "Not wearing a " + GameLoop.WTN.ResolveItemName(MiscString); 
            }
            
            if (RequirementType == "Wearing") { 
                return "Wearing a " + GameLoop.WTN.ResolveItemName(MiscString); 
            } 

            if (RequirementType == "Data") {
                return "WorldState: " + MiscString + " " + MiscString2 + " " + MiscInt;
            }

            if (RequirementType == "ItemOwned") {
                return GameLoop.WTN.ResolveItemName(MiscString) + " in inventory, equipment, or bank.";
            }
            
            if (RequirementType == "ItemNotOwned") {
                return GameLoop.WTN.ResolveItemName(MiscString) + " not in inventory, equipment, or bank.";
            }

            if (RequirementType == "DiaryComplete") {
                return "Must complete the " + MiscString + " " + MiscString2 + " Achievement Diary.";
            }

            if (RequirementType == "AnyEquipInSlot") {
                return "Must be wearing any item in the " + MiscString + " slot.";
            }

            if (RequirementType == "ClueMedium") {
                return "Only while a specific medium clue step is active. (" + MiscString + ")";
            }

            if (RequirementType == "CombatAtLeast") {
                return "Must have Combat level " + MiscInt + " or higher.";
            }

            if (RequirementType == "CombatAtMost") {
                return "Must have Combat level " + MiscInt + " or lower.";
            }

            if (RequirementType == "Region") { return "Must be in " + MiscString + "."; }

            if (RequirementType == "POHNotOwned") { return "Must not already own the house in " + GameLoop.WTN.ResolveLocationName(MiscString) + "."; }
            if (RequirementType == "POHOwned") { return "Must own the house in " + GameLoop.WTN.ResolveLocationName(MiscString) + "."; }
            if (RequirementType == "AnyPOH") { return "Must own a home anywhere."; }
            if (RequirementType == "POHActive") { return "Must own this home, and have it currently active (set at any Estate Agent)."; }

            if (RequirementType == "CanSlash") { return "Must have any item that deals slashing damage, or a knife."; }
            
            if (RequirementType == "TempMonsterCount") { return "Must be fewer than " + MiscInt + " summoned monsters here."; }

            if (RequirementType == "TimeBetween") { 
                bool twelve = GameLoop.WTN.player.Clock != null ? GameLoop.WTN.player.Clock.TwelveHour : true; 
                return "Must be between " + Helper.ConvertTime(MiscInt, twelve) + " and " + Helper.ConvertTime(MiscInt2, twelve);
            }

            if (RequirementType == "TimeOutside") { 
                bool twelve = GameLoop.WTN.player.Clock != null ? GameLoop.WTN.player.Clock.TwelveHour : true; 
                return "Must NOT be between " + Helper.ConvertTime(MiscInt, twelve) + " and " + Helper.ConvertTime(MiscInt2, twelve);
            }

            return "";
        }


        public bool CheckRequirement(Player p, bool itemsNotedOkay, bool itemsEquippedOkay = false) {
            if (RequirementType == "Skill") {
                if (MiscString == "All") {
                    foreach (var kv in p.Skills) {
                        if (kv.Value.Level < MiscInt) {
                            return false;
                        }
                    }
                    return true;
                } else {
                    if (p.Skills.ContainsKey(MiscString)) {
                        if (p.Skills[MiscString].Level >= MiscInt) {
                            return true;
                        }
                    }
                }
            }

            if (RequirementType == "NotSkill") {
                if (MiscString == "All") {
                    foreach (var kv in p.Skills) {
                        if (kv.Value.Level > MiscInt) {
                            return false;
                        }
                    }
                    return true;
                } else {
                    if (p.Skills.ContainsKey(MiscString)) {
                        if (p.Skills[MiscString].Level < MiscInt) {
                            return true;
                        }
                    }
                }
            }

            if (RequirementType == "QuestAt") {
                if (p.QuestLog.TryGetValue(MiscString, out QuestStatus? quest)) {
                    if (quest.CurrentStage == MiscInt) {
                        return true;
                    }
                } else {
                    if (MiscInt == -1) {
                        return true;
                    } else {
                        return false;
                    }
                }
            }

            if (RequirementType == "QuestNot") {
                if (p.QuestLog.TryGetValue(MiscString, out QuestStatus? quest)) {
                    if (quest.CurrentStage != MiscInt) {
                        return true;
                    }
                } else {
                    if (MiscInt == -1) {
                        return false;
                    } else {
                        return true;
                    }
                }
            }

            if (RequirementType == "QuestBelow") {
                if (p.QuestLog.TryGetValue(MiscString, out QuestStatus? quest)) {
                    if (quest.CurrentStage < MiscInt) {
                        return true;
                    }
                } else {
                    if (MiscInt > -1) {
                        return true;
                    } else {
                        return false;
                    }
                }
            }

            if (RequirementType == "QuestPast") {
                if (p.QuestLog.TryGetValue(MiscString, out QuestStatus? quest)) {
                    if (quest.CurrentStage >= MiscInt) {
                        return true;
                    }
                }
            }

            if (RequirementType == "Item") {
                if (MiscString == "Gold") {
                    if (p.GoldTotal() >= MiscInt) {
                        return true;
                    }
                } else { 
                    if (p.HasAllItems([MiscString+","+MiscInt], itemsNotedOkay, itemsEquippedOkay)) {
                        return true;
                    }
                }
            }

            if (RequirementType == "NotItem") {
                if (MiscString == "Gold") {
                    if (p.GoldTotal() < MiscInt) {
                        return true;
                    }
                } else {
                    if (!p.HasAllItems([MiscString+","+MiscInt])) {
                        return true;
                    } 
                }
            }

            if (RequirementType == "Wearing") {
                foreach (var kv in p.Equipment) {
                    if (kv.Value.ID == MiscString) {
                        return true;
                    }
                }

                return false;
            }

            if (RequirementType == "NotWearing") {
                foreach (var kv in p.Equipment) {
                    if (kv.Value.ID == MiscString) {
                        return false;
                    }
                }

                return true;
            }

            if (RequirementType == "CollectionLogComplete") {
                if (MiscString.Contains("clue")) {
                    List<string> clueTypes = [ "Tutorial", "Beginner", "Easy", "Medium", "Hard", "Elite", "Master" ];

                    for (int i = 0; i < clueTypes.Count; i++) { 
                        if (MiscString == clueTypes[i] + " clue") {
                            if (p.CollectionLogClues.TryGetValue("casket" + clueTypes[i], out CollectionLogEntry? log) && log != null) {
                                if (GameLoop.WTN.ItemLibrary.TryGetValue("casket" + clueTypes[i], out Item? cask) && cask != null) {
                                    if (cask.DropTable.Count == log.DropsObtained.Count) {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                } else if (MiscString.Contains("boss")) {
                    if (p.CollectionLogBoss.TryGetValue(MiscString, out CollectionLogEntry? log) && log != null) {
                        if (GameLoop.WTN.BossLibrary.TryGetValue(MiscString, out BossFight? mon) && mon != null) {
                            if (mon.DropTable.Count == log.DropsObtained.Count) {
                                return true;
                            }
                    
                        }
                    }
                } else {
                    if (p.CollectionLog.TryGetValue(MiscString, out CollectionLogEntry? log) && log != null) {
                        if (GameLoop.WTN.MonsterLibrary.TryGetValue(MiscString, out AreaMonster? mon) && mon != null) {
                            if (mon.DropTable.Count == log.DropsObtained.Count) {
                                return true;
                            }
                    
                        }
                    }
                }
            }

            if (RequirementType == "KillCount") {
                if (MiscString.Contains("clue")) {
                    List<string> clueTypes = [ "Tutorial", "Beginner", "Easy", "Medium", "Hard", "Elite", "Master" ];

                    for (int i = 0; i < clueTypes.Count; i++) { 
                        if (MiscString == clueTypes[i] + " clue") {
                            if (p.CollectionLogClues.TryGetValue("casket" + clueTypes[i], out CollectionLogEntry? log) && log != null) {
                                if (log.KillCount >= MiscInt) {
                                    return true;
                                }
                            }
                        }
                    }
                } else {
                    if (p.CollectionLog.TryGetValue(MiscString, out CollectionLogEntry? log) && log != null) {
                        if (log.KillCount >= MiscInt) {
                            return true;
                        }
                    }
                }
            }

            if (RequirementType == "Data") {
                return Helper.CompareWorldState(MiscString, MiscString2, MiscInt);
            } 

            if (RequirementType == "ItemOwned") { 
                foreach (var kv in p.Inventory) { if (kv.ID == MiscString) { return true; } }
                foreach (var kv in p.Equipment) { if (kv.Value.ID == MiscString) { return true; } }
                foreach (var kv in p.BankedItems) { if (kv.ID == MiscString) { return true; } }
            }

            if (RequirementType == "ItemNotOwned") {
                foreach (var kv in p.Inventory) { if (kv.ID == MiscString) { return false; } }
                foreach (var kv in p.Equipment) { if (kv.Value.ID == MiscString) { return false; } }
                foreach (var kv in p.BankedItems) { if (kv.ID == MiscString) { return false; } }

                return true;
            }

            if (RequirementType == "AnyEquipInSlot") {
                if (p.Equipment.ContainsKey(MiscString)) {
                    return true;
                }
            }

            if (RequirementType == "ClueMedium") { if (p.CurrentClueMedium == MiscString) { return true; } }


            if (RequirementType == "CombatAtLeast") { if (p.GetCombatLevel() >= MiscInt) { return true; } }
            if (RequirementType == "CombatAtMost") { if (p.GetCombatLevel() <= MiscInt) { return true; } }
              
            if (RequirementType == "Region") { if (p.GetRegion() == MiscString) { return true; }}

            if (RequirementType == "POHNotOwned") { if (!p.Homes.ContainsKey(MiscString)) { return true; }}
            if (RequirementType == "POHOwned") { if (p.Homes.ContainsKey(MiscString)) { return true; }}
            if (RequirementType == "AnyPOH") { if (p.Homes.Count > 0) { return true; }}
            if (RequirementType == "POHActive") { if (p.Homes.TryGetValue(MiscString, out PlayerOwnedHome? home) && home != null && home.Active) { return true; }}
             

            if (RequirementType == "TempMonsterCountAbove") {
                int count = 0;
                if (GameLoop.WTN.Atlas.TryGetValue(p.NavLoc, out Location? curr) && curr != null) {
                    foreach (var mon in curr.MonstersHere) {
                        if (mon.Temporary) { count++; }
                    }
                }

                if (count > MiscInt) {
                    return true;
                }
            }

            if (RequirementType == "TimeBetween") {
                if (GameLoop.WTN.player.Clock != null) {
                    int currTime = (GameLoop.WTN.player.Clock.Hour * 60) + GameLoop.WTN.player.Clock.Minute;

                    if (currTime >= MiscInt && currTime <= MiscInt2) { return true; }
                }
            }

            if (RequirementType == "TimeOutside") {
                if (GameLoop.WTN.player.Clock != null) {
                    int currTime = (GameLoop.WTN.player.Clock.Hour * 60) + GameLoop.WTN.player.Clock.Minute;

                    if (currTime < MiscInt || currTime > MiscInt2) { return true; }
                }
            }

            return false;
        }
    }
}
