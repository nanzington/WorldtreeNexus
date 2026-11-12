using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedBosses {
        public static void InitBosses(Dictionary<string, BossFight> BossLib) {
            List<BossFight> toAdd = new();

            toAdd.Add(new("bossZombie", 10, [
                new BossPhase("Huge Zombie", 20, 1, 2, 2, "Slash", "Wood", "Melee", 0, 2) {
                    Specials = [
                        new("The huge zombie roars and rears back, preparing to slam the huge club into the ground. Move to a lane that isn't yellow or red quickly!", 5, "Melee", [ 1 ]),
                        new("The huge zombie groans angrily and prepares to swipe to either side. Move to a lane that isn't yellow or red quickly!", 5, "Melee", [ 0, 2 ])
                    ]
                }
            ], 3, true) { 
                SpecialCategory = "Undead",
                DropTable = [
                    new("petBabyZombie", 1, 50, 1, 1),
                    new("clubHuger", 1, 20, 1, 1), 
                    new("clubHuge", 1, 10, 1, 1),
                    new("arrowsCopper", 1, 4, 10, 20), 
                    new("talismanDestruction", 1, 4, 10, 20), 
                    new("talisman", 1, 4, 10, 20), 
                    new("fleshRotten", 1, 1, 1, 1),
                    new("bonesBig", 1, 1, 1, 1) 
                ]
            });

            for (int i = 0; i < toAdd.Count; i++) { 
                BossLib.TryAdd(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
