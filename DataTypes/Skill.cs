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
                 
                if (log != null) {
                    log.AddMessage("You levelled " + Name + " to " + Level + ".");

                    if (Level == 100)
                        log.AddMessage("You have mastered " + Name + "!");
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
