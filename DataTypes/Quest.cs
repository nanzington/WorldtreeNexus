using System;
using System.Collections.Generic;
using System.Text;
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class Quest {
        public string ID = "";
        public string Name = "";
        public string Length = "";
        public string Difficulty = "";
        public string Description = "";
        public List<string> RegionsNeeded = new();

        public string StartNPC = "";
        public string StartLoc = "";

        public int QuestPoints = 0;

        public int DateFullyImplemented = 0; // YYYYMMDD, ex 20260828 for August 28, 2026
         
        public int CompleteStage = 0;

        public List<Requirement> RequirementsToStart = new();

        public Dictionary<int, QuestStage> Stages = new();
        public List<RunAction> ActionsOnComplete = new();

        public Quest(string id, string name, string length, string diff, string desc, int complete, List<string> regions) {
            ID = id;
            Name = name;
            Length = length;
            Difficulty = diff;
            Description = desc;

            CompleteStage = complete;
            RegionsNeeded = regions;
        }


        public bool CanStartQuest(Player p) {
            bool allPassed = true;
            for (int i = 0; i < RequirementsToStart.Count; i++) {
                if (!RequirementsToStart[i].CheckRequirement(p, true)) {
                    allPassed = false;
                }
            }

            return allPassed;
        }

        public int CurrentStage() {
            if (GameLoop.WTN.player.QuestLog.TryGetValue(ID, out QuestStatus? status)) {
                return status.CurrentStage;
            }

            return -1;
        }

        public bool AtAnEnd(bool countFalseEnd = false) {
            if (Stages.TryGetValue(CurrentStage(), out QuestStage? stage) && stage != null) {
                if (stage.EndStage == 1 || (stage.EndStage == 2 && countFalseEnd)) { return true; } 
            }

            return false;
        }
    }
}
