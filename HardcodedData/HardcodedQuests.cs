using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedQuests {
        public static void InitQuests(Dictionary<string, Quest> QuestLib) {
            List<Quest> toAdd = new();

            toAdd.Add(new("TII_OnTheJobTraining", "On the Job Training", "Very Short", "Novice", "", 90, new() { "Tutorial Island" }) {
                StartNPC = "tiFatherGuy",
                StartLoc = "TI_Temple",
                DateFullyImplemented = 20260828,
                Rewards = { new("Item", "Gold", 1000) },
                QuestPoints = 1,
                Stages = new() {
                    {
                        0,
                        new("Father Guy has suggested I take a look around the island to find places the ghost lingers, and see if there are any suspicious items around that might help him move on.", 10, "ExamineItem", "TI_HI_RustedSword")
                    },
                }
            }); 

            for (int i = 0; i < toAdd.Count; i++) {
                QuestLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
