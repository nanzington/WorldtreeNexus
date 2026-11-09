using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class Skill {
        public string Name = "";
        public int Level = 1;
        public int Exp = 0;

        public Skill(string n) {
            Name = n;
        }

        public void GrantExp(int amt, MessageLog log, List<Skill> RecentSkills) {
            Exp += amt;
            
            while (Exp >= ExpToLevel() && Level < 100) {
                Level++;

                if (Name == "Prayer") {
                    GameLoop.WTN.player.CurrentPrayer += 10;
                }
                 
                if (log != null) {
                    log.AddMessage("You levelled " + Name + " to " + Level + ".");

                    if (Level == 100)
                        log.AddMessage("You have mastered " + Name + "!");
                }

                if (SteamManager.SteamInitialized && GameLoop.WTN.player.ExpMultiplier == 1) {
                    if (Level % 10 == 0) { 
                        if (SteamManager.TryUnlockAchievement("Main_Skill_" + Level)) {  
                            log?.AddMessage("Achievement unlocked: Reach level " + Level + " in any skill on 1x Experience.");
                        }
                    }

                    if (Level == 100) {
                        if (SteamManager.TryUnlockAchievement("Skill_" + Name + "_100")) {  
                            log?.AddMessage("Achievement unlocked: Reach level 100 in any " + Name + " on 1x Experience.");
                        }

                        bool pure = true;
                        bool allMax = true;
                        foreach (var kv in GameLoop.WTN.player.Skills) {
                            if (kv.Value.Name != Name) {
                                if ((kv.Value.Name == "Hitpoints" && kv.Value.Level > 10) || (kv.Value.Name != "Hitpoints" && kv.Value.Level > 1)) {
                                    pure = false;
                                    break;
                                }
                            }

                            if (kv.Value.Level < 100) {
                                allMax = false;
                            }
                        }

                        if (pure) {
                            if (SteamManager.TryUnlockAchievement("Overachiever_Pure")) {  
                                log?.AddMessage("Achievement unlocked: Reach level 100 in any skill, on 1x Experience, without ever having levelled another skill.");
                            }
                        }

                        if (allMax && !GameLoop.WTN.player.OnlyPayToWin) {
                            if (SteamManager.TryUnlockAchievement("Overachiever_Max")) {  
                                log?.AddMessage("Achievement unlocked: Reach level 100 in every skill on 1x Experience.");
                            }
                        }

                        if (allMax && GameLoop.WTN.player.OnlyPayToWin) {
                            if (SteamManager.TryUnlockAchievement("Overachiever_P2W")) {  
                                log?.AddMessage("Achievement unlocked: Reach level 100 in every skill on 1x Experience, with 'Only Pay to Win' enabled.");
                            }
                        }
                    }
                }
            }

            if (RecentSkills != null) {
                if (RecentSkills.Contains(this)) {
                    RecentSkills.Remove(this);
                }

                if (RecentSkills.Count > 10)
                    RecentSkills.RemoveAt(10);

                RecentSkills.Insert(0, this);
            }
        }

        public int ExpToLevel() { 
            return (int) ((1060 - ((Level + 4) * 9)) * (Math.Pow(2, ((Level + 4) / 5f)))) / 5 - 356;

            return (int)(Math.Floor(0.125 * (Level + 1) * (Level)) 
                       + Math.Floor(75 * ((Math.Pow(2, (Level + 1) / 7f) - Math.Pow(2, 1f / 7f)) / (Math.Pow(2, 1f / 7f) - 1)))
                       + Math.Floor(0.109 * (Level + 1)));
        }

        public int EXPNeeded() {
            return ExpToLevel() - Exp;
        }
    }
}
