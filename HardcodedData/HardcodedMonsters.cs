using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedMonsters {
        public static void InitMonsters(Dictionary<string, AreaMonster> MonsterLib) {
            List<AreaMonster> toAdd = new();

            toAdd.Add(new("Giant guinea pig", "cuyGiant", level: 1, hp: 3, atk: 2, str: 1, def: 1, aggro: false, weak: "Slash", element: "Earth", dmgType: "Melee") {
                AlchemySecretionID = "bloodCuy",
                DropTable = [ new("eyeCuy", y: 2), new("bonesRegular"), new("meatRawCuy") ] 
            });

            toAdd.Add(new("Cow", "cow", level: 1, hp: 5, atk: 3, str: 0, def: 2, aggro: false, weak: "Stab", element: "Earth", dmgType: "Melee") {
                AlchemySecretionID = "bloodCow",
                DropTable = [ new("bonesRegular"), new("meatRawBeef"), new("cowhide"), new("clueScrollBeginner", y: 128) ] 
            });

            toAdd.Add(new("Chicken", "chicken", level: 1, hp: 2, atk: 1, str: 0, def: 0, aggro: false, weak: "Stab", element: "Earth", dmgType: "Melee") {
                AlchemySecretionID = "bloodChicken", 
                DropTable = [ new("bonesRegular"), new("meatRawChicken"), new("feather", 1, 2, 5, 15), new("clueScrollBeginner", y: 300) ]
            });

            toAdd.Add(new("Zombie", "tiZombie", level: 5, hp: 8, atk: 3, str: 2, def: 0, aggro: false, weak: "Slash", element: "Wood", dmgType: "Melee") {
                AlchemySecretionID = "bloodHumanTainted", AttackSpeedSeconds = 1.2,
                DropTable = [ new("bonesRegular"), new("coins", 1, 10, 10, 50) ]
            });

            toAdd.Add(new("Man", "manDay", level: 5, hp: 8, atk: 3, str: 1, def: 3, aggro: false, weak: "Crush", element: "Earth", dmgType: "Melee") {
                Requirements = [ new("TimeBetween", 420, miscint2: 1260) ], SeeWithoutRequirements = false,
                AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ]
            });
            toAdd.Add(new("Woman", "womanDay", level: 5, hp: 8, atk: 3, str: 1, def: 3, aggro: false, weak: "Crush", element: "Earth", dmgType: "Melee") {
                Requirements = [ new("TimeBetween", 420, miscint2: 1260) ], SeeWithoutRequirements = false,
                AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ]
            });
            toAdd.Add(new("Man", "manNight", level: 5, hp: 8, atk: 3, str: 1, def: 3, aggro: false, weak: "Crush", element: "Earth", dmgType: "Melee") {
                Requirements = [ new("TimeOutside", 420, miscint2: 1260) ], SeeWithoutRequirements = false,
                AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ]
            });
            toAdd.Add(new("Woman", "womanNight", level: 5, hp: 8, atk: 3, str: 1, def: 3, aggro: false, weak: "Crush", element: "Earth", dmgType: "Melee") {
                Requirements = [ new("TimeOutside", 420, miscint2: 1260) ], SeeWithoutRequirements = false,
                AlchemySecretionID = "bloodHuman", DropTable = [ ..DropTables.GenericHumanTable.But() ]
            });
               
            toAdd.Add(new("Frog", "frog", level: 5, hp: 8, atk: 4, str: 0, def: 3, aggro: false, weak: "Bolt", element: "Water", dmgType: "Melee") {
                AlchemySecretionID = "bloodFrog",
                DropTable = [ new("bonesRegular"), new("clueScrollBeginner", y: 90), new("potionSleepingTail", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ] 
            }); 

            toAdd.Add(new("Snake", "snake", level: 5, hp: 6, atk: 3, str: 0, def: 5, aggro: false, weak: "Ray", element: "Fire", dmgType: "Melee") {
                AlchemySecretionID = "venomSnake", PoisonSeverity = 2,
                DropTable = [ new("bonesRegular"), new("potionSleepingEar", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ] 
            }); 

            toAdd.Add(new("Rat", "rat", level: 1, hp: 2, atk: 1, str: 0, def: 5, aggro: false, weak: "Slash", element: "Earth", dmgType: "Melee") {
                AlchemySecretionID = "bloodRat",
                DropTable = [ new("potionSleepingWing", y: 3, reqs: [new("QuestAt", 140, "MI_RomeoJuliet")]) ]
            }); 

            toAdd.Add(new("Ram", "ram", level: 2, hp: 8, atk: 3, str: 0, def: 2, aggro: false, weak: "Stab", element: "Earth", dmgType: "Melee") {
                AlchemySecretionID = "bloodRam", 
                DropTable = [ new("bonesRegular") ]
            }); 

            


            for (int i = 0; i < toAdd.Count; i++) { 
                MonsterLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
