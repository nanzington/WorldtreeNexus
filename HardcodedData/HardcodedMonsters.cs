using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedMonsters {
        public static void InitMonsters(Dictionary<string, AreaMonster> MonsterLib) {
            List<AreaMonster> toAdd = new();

            toAdd.Add(new("Giant guinea pig", "cuyGiant", lv: 1, hp: 3, dr: 0, atk: 5, def: 5, false, maxhit: 3, weakness: "Slash", element: "Earth", 5, "Melee") { 
                AlchemySecretionID = "bloodCuy",
                DropTable = [ new("eyeCuy", y: 2), new("bonesRegular"), new("meatRawCuy") ]
            });

            toAdd.Add(new("Cow", "cow", lv: 1, hp: 5, dr: 0, atk: 0, def: 5, false, maxhit: 2, weakness: "Stab", element: "Earth", 5, "Melee") { 
                AlchemySecretionID = "bloodCow",
                DropTable = [ new("bonesRegular"), new("meatRawBeef"), new("cowhide"), new("clueScrollBeginner", y: 128) ] 
            });

            toAdd.Add(new("Chicken", "chicken", lv: 1, hp: 2, dr: 0, atk: 0, def: 0, false, maxhit: 1, weakness: "Stab", element: "Earth", 5, "Melee") {
                AlchemySecretionID = "bloodChicken", 
                DropTable = [ new("bonesRegular"), new("meatRawChicken"), new("feather", 1, 2, 5, 15), new("clueScrollBeginner", y: 300) ]
            });

            toAdd.Add(new("Zombie", "tiZombie", lv: 5, hp: 8, dr: 0, atk: 10, def: 5, false, maxhit: 4, weakness: "Slash", element: "Wood", 10, "Melee") {
                AlchemySecretionID = "bloodHumanTainted", 
                DropTable = [ new("bonesRegular"), new("coins", 1, 10, 10, 50) ]
            });

            toAdd.Add(new("Man", "manDay", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee", reqs: [ new("TimeBetween", 420, miscint2: 1260) ], seeAnyways: false) { AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ] });
            toAdd.Add(new("Woman", "womanDay", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee", reqs: [ new("TimeBetween", 420, miscint2: 1260) ], seeAnyways: false) { AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ] });

            toAdd.Add(new("Man", "manNight", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee", reqs: [ new("TimeOutside", 420, miscint2: 1260) ], seeAnyways: false) { AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ] });
            toAdd.Add(new("Woman", "womanNight", lv: 2, hp: 7, dr: 0, atk: 5, def: 5, false, maxhit: 1, weakness: "Crush", element: "Earth", 1, "Melee", reqs: [ new("TimeOutside", 420, miscint2: 1260) ], seeAnyways: false) { AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ] });


            toAdd.Add(new("Frog", "frog", lv: 5, hp: 8, dr: 0, atk: 8, def: 10, false, maxhit: 1, weakness: "Bolt", element: "Water", 1, "Melee") { 
                AlchemySecretionID = "bloodFrog",
                DropTable = [ new("bonesRegular"), new("clueScrollBeginner", y: 90), new("potionSleepingTail", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ] 
            });

            toAdd.Add(new("Snake", "snake", lv: 5, hp: 6, dr: 0, atk: 10, def: 5, false, maxhit: 1, weakness: "Ray", element: "Fire", 1, "Melee") { 
                AlchemySecretionID = "venomSnake",
                DropTable = [ new("bonesRegular"), new("potionSleepingEar", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ] 
            });

            toAdd.Add(new("Rat", "rat", lv: 1, hp: 2, dr: 0, atk: 0, def: 0, false, maxhit: 1, weakness: "Slash", element: "Earth", 1, "Melee", specialCat: "Ratlike") { 
                AlchemySecretionID = "bloodRat",
                DropTable = [ new("potionSleepingWing", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ]
            });


            toAdd.Add(new("Ram", "ram", lv: 2, hp: 8, dr: 0, atk: 10, def: 0, false, maxhit: 1, weakness: "Stab", element: "Earth", 1, "Melee") {
                AlchemySecretionID = "bloodRam", 
                DropTable = [ new("bonesRegular") ]
            });
            


            for (int i = 0; i < toAdd.Count; i++) { 
                MonsterLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
