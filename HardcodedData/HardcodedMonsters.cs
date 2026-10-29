using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedMonsters {
        public static void InitMonsters(Dictionary<string, AreaMonster> MonsterLib) {
            List<AreaMonster> toAdd = new();

            toAdd.Add(new("Giant guinea pig", "cuyGiant", lv: 1, hp: 3, dr: 0, atk: 5, def: 5, false, maxhit: 3, weakness: "Slash", element: "Earth", 5, "Melee") { 
                DropTable = new() { new("eyeCuy", 1, 2, 1, 1), new("bonesRegular", 1, 1, 1, 1), new("meatRawCuy", 1, 1, 1, 1) } 
            });

            toAdd.Add(new("Cow", "cow", lv: 1, hp: 5, dr: 0, atk: 0, def: 5, false, maxhit: 2, weakness: "Stab", element: "Earth", 5, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1), new("meatRawBeef", 1, 1, 1, 1), new("cowhide", 1, 1, 1, 1), new("clueScrollBeginner", 1, 128, 1, 1) } 
            });

            toAdd.Add(new("Chicken", "chicken", lv: 1, hp: 2, dr: 0, atk: 0, def: 0, false, maxhit: 1, weakness: "Stab", element: "Earth", 5, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1), new("meatRawChicken", 1, 1, 1, 1), new("feather", 1, 2, 5, 15), new("clueScrollBeginner", 1, 300, 1, 1) }
            });

            toAdd.Add(new("Zombie", "tiZombie", lv: 5, hp: 8, dr: 0, atk: 10, def: 5, false, maxhit: 4, weakness: "Slash", element: "Wood", 10, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1), new("coins", 1, 10, 10, 50), new("alchemyRecipeAttack", 1, 20, 1, 1) } 
            });

            toAdd.Add(new("Man", "man", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee") { DropTable = new() { DropTables.GenericHumanTable.But() } });
            toAdd.Add(new("Woman", "woman", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee") { DropTable = new() { DropTables.GenericHumanTable.But() } });

            toAdd.Add(new("Frog", "frog", lv: 5, hp: 8, dr: 0, atk: 8, def: 10, false, maxhit: 1, weakness: "Bolt", element: "Water", 1, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1), new("clueScrollBeginner", 1, 90, 1, 1), new("potionSleepingTail", 1, 3, 1, 1, req: new("QuestAt", 140, "MI_RomeoJuliet")) } 
            });

            toAdd.Add(new("Snake", "snake", lv: 5, hp: 6, dr: 0, atk: 10, def: 5, false, maxhit: 1, weakness: "Ray", element: "Fire", 1, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1), new("potionSleepingEar", 1, 3, 1, 1, req: new("QuestAt", 140, "MI_RomeoJuliet")) } 
            });

            toAdd.Add(new("Rat", "rat", lv: 1, hp: 2, dr: 0, atk: 0, def: 0, false, maxhit: 1, weakness: "Slash", element: "Earth", 1, "Melee", specialCat: "Ratlike") { 
                DropTable = new() { new("potionSleepingWing", 1, 3, 1, 1, req: new("QuestAt", 140, "MI_RomeoJuliet")) }
            });


            toAdd.Add(new("Ram", "ram", lv: 2, hp: 8, dr: 0, atk: 10, def: 0, false, maxhit: 1, weakness: "Stab", element: "Earth", 1, "Melee") { 
                DropTable = new() { new("bonesRegular", 1, 1, 1, 1) } 
            });
            


            for (int i = 0; i < toAdd.Count; i++) { 
                MonsterLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
