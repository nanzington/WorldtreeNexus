using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class QuestStage {
        public string Description = "";
        public string QuickDesc = "";
        public int LeadsToStage = 0;

        public string ProgressType = "";
        public string MiscString = "";
        public int MiscInt = 0;

        public string ReachedLog = ""; // Displayed in the log when this quest stage is reached

        public int EndStage = 0; // 0 = no, 1 = Quest Complete, 2 = Quest Complete?
        public List<QuestReward> Rewards = new(); // Rewards given for reaching this stage, typically only for use at end points of quests

        public QuestStage(string desc, int toStage, string prog = "", string misc = "", int num = 0, string quickDesc = "") {
            Description = desc;
            QuickDesc = quickDesc;
            LeadsToStage = toStage;

            ProgressType = prog;
            MiscString = misc;
            MiscInt = num;
        } 

        public void ProcessRewards(Player p, string ID) {
            foreach (var kv in Rewards) {
                if (kv.RewardType == "Experience") {
                    GameLoop.WTN.Log.AddMessage("You gain " + kv.MiscInt + " " + kv.MiscString + " experience.", Color.Yellow);
                    p.TryGrantExp(kv.MiscString, kv.MiscInt, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                }

                if (kv.RewardType == "Item") {
                    if (kv.MiscString == "Gold") {
                        GameLoop.WTN.Log.AddMessage("You receive " + kv.MiscInt + " gold.", Color.Yellow);
                        p.GiveGold(kv.MiscInt); 
                    } else { 
                        if (GameLoop.WTN.ItemLibrary.TryGetValue(kv.MiscString, out Item? reward) && reward != null) {
                            if (kv.MiscInt == 1)
                                GameLoop.WTN.Log.AddMessage("You receive a" + (Helper.VowelStart(reward.Name.ToLower()) ? "n " : " ") +  reward.Name.ToLower() + ".", Color.Yellow);
                            else
                                GameLoop.WTN.Log.AddMessage("You receive " + kv.MiscInt + "x " + reward.Name.ToLower() + ".", Color.Yellow);

                            Item pickup = new(reward);
                            pickup.Quantity = kv.MiscInt;
                            p.TryPickup(pickup, pickup.Quantity);
                        }
                    }
                }

                if (kv.RewardType == "RandomItem") {
                    if (kv.MiscString == "kitten") {
                        List<string> kittenColors = [ "kittenBlack", "kittenGray", "kittenWhite", "kittenOrange", "kittenBrown", "kittenCalico" ];

                        if (GameLoop.WTN.ResolveItem(kittenColors[GameLoop.rand.Next(kittenColors.Count)]) is Item kitten) { 
                            GameLoop.WTN.Log.AddMessage("You receive a " + kitten.Name.ToLower(), Color.Yellow);
                            p.TryPickup(kitten, 1);
                        }
                    }
                }
            }

            if (ID == "TI_OnTheJobTraining") {
                if (SteamManager.TryUnlockAchievement("Main_TutorialQuest")) {  
                    GameLoop.WTN.Log.AddMessage("Achievement unlocked: Complete the Tutorial Quest, 'On The Job Training'.");
                }
            }
        }
    }
}
