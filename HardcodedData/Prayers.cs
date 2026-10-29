﻿using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class Prayers {
        public static void InitPrayers(Dictionary<string, Prayer> PrayerLib) {
            List<Prayer> toAdd = new();

            toAdd.Add(new Prayer("Defense I", "Normal", 1, "Boosts Defense by 10%.", "Defense", 10) { ConflictsWith = [ "Defense II", "Defense III", "Defense IV", "Defense V"] });
            toAdd.Add(new Prayer("Strength I", "Normal", 1, "Boosts Strength by 10%.", "Strength", 10) { ConflictsWith = [ "Strength II", "Strength III", "Strength IV", "Strength V"] });
            toAdd.Add(new Prayer("Attack I", "Normal", 1, "Boosts Attack by 10%.", "Attack", 10) { ConflictsWith = [ "Attack II", "Attack III", "Attack IV", "Attack V"] });
            toAdd.Add(new Prayer("Ranged I", "Normal", 1, "Boosts Ranged by 10%.", "Ranged", 10) { ConflictsWith = [ "Ranged II", "Ranged III", "Ranged IV", "Ranged V"] });
            toAdd.Add(new Prayer("Magic I", "Normal", 1, "Boosts Magic by 10%.", "Magic", 10) { ConflictsWith = [ "Magic II", "Magic III", "Magic IV", "Magic V"] }); 
             
            toAdd.Add(new Prayer("Improved Crit I", "Normal", 10, "Critical Chance+ (stacks).")); 
            
            toAdd.Add(new Prayer("Defense II", "Normal", 20, "Boosts Defense by 20%.", "Defense", 20) { ConflictsWith = [ "Defense I", "Defense III", "Defense IV", "Defense V"] });
            toAdd.Add(new Prayer("Strength II", "Normal", 20, "Boosts Strength by 20%.", "Strength", 20) { ConflictsWith = [ "Strength I", "Strength III", "Strength IV", "Strength V"] });
            toAdd.Add(new Prayer("Attack II", "Normal", 20, "Boosts Attack by 20%.", "Attack", 20) { ConflictsWith = [ "Attack I", "Attack III", "Attack IV", "Attack V"] });
            toAdd.Add(new Prayer("Ranged II", "Normal", 20, "Boosts Ranged by 20%.", "Ranged", 20) { ConflictsWith = [ "Ranged I", "Ranged III", "Ranged IV", "Ranged V"] });
            toAdd.Add(new Prayer("Magic II", "Normal", 20, "Boosts Magic by 20%.", "Magic", 20) { ConflictsWith = [ "Magic I", "Magic III", "Magic IV", "Magic V"] }); 
             
            toAdd.Add(new Prayer("Improved Crit II", "Normal", 20, "Critical Chance++ (stacks).")); 
            toAdd.Add(new Prayer("Rapid Heal", "Normal", 25, "Recover health twice as fast.")); 
            toAdd.Add(new Prayer("Improved Crit III", "Normal", 30, "Critical Chance+++ (stacks).")); 
            
            toAdd.Add(new Prayer("Defense III", "Normal", 40, "Boosts Defense by 30%.", "Defense", 30) { ConflictsWith = [ "Defense I", "Defense II", "Defense IV", "Defense V"] });
            toAdd.Add(new Prayer("Strength III", "Normal", 40, "Boosts Strength by 30%.", "Strength", 30) { ConflictsWith = [ "Strength I", "Strength II", "Strength IV", "Strength V"] });
            toAdd.Add(new Prayer("Attack III", "Normal", 40, "Boosts Attack by 30%.", "Attack", 30) { ConflictsWith = [ "Attack I", "Attack II", "Attack IV", "Attack V"] });
            toAdd.Add(new Prayer("Ranged III", "Normal", 40, "Boosts Ranged by 30%.", "Ranged", 30) { ConflictsWith = [ "Ranged I", "Ranged II", "Ranged IV", "Ranged V"] });
            toAdd.Add(new Prayer("Magic III", "Normal", 40, "Boosts Magic by 30%.", "Magic", 30) { ConflictsWith = [ "Magic I", "Magic II", "Magic IV", "Magic V"] }); 
              
            toAdd.Add(new Prayer("Protect from Magic", "Normal", 50, "Cuts magic damage by half.") { ConflictsWith = [ "Protect from Melee", "Protect from Range" ]});
            toAdd.Add(new Prayer("Protect from Melee", "Normal", 50, "Cuts melee damage by half.") { ConflictsWith = [ "Protect from Magic", "Protect from Range" ]});
            toAdd.Add(new Prayer("Protect from Range", "Normal", 50, "Cuts range damage by half.") { ConflictsWith = [ "Protect from Melee", "Protect from Magic" ]});

            toAdd.Add(new Prayer("Defense IV", "Normal", 60, "Boosts Defense by 40%.", "Defense", 40) { ConflictsWith = [ "Defense I", "Defense II", "Defense III", "Defense V"] });
            toAdd.Add(new Prayer("Strength IV", "Normal", 60, "Boosts Strength by 40%.", "Strength", 40) { ConflictsWith = [ "Strength I", "Strength II", "Strength III", "Strength V"] });
            toAdd.Add(new Prayer("Attack IV", "Normal", 60, "Boosts Attack by 40%.", "Attack", 40) { ConflictsWith = [ "Attack I", "Attack II", "Attack III", "Attack V"] });
            toAdd.Add(new Prayer("Ranged IV", "Normal", 60, "Boosts Ranged by 40%.", "Ranged", 40) { ConflictsWith = [ "Ranged I", "Ranged II", "Ranged III", "Ranged V"] });
            toAdd.Add(new Prayer("Magic IV", "Normal", 60, "Boosts Magic by 40%.", "Magic", 40) { ConflictsWith = [ "Magic I", "Magic II", "Magic III", "Magic V"] }); 
             
            toAdd.Add(new Prayer("Defense V", "Normal", 80, "Boosts Defense by 50%.", "Defense", 50) { ConflictsWith = [ "Defense I", "Defense II", "Defense III", "Defense IV"] });
            toAdd.Add(new Prayer("Strength V", "Normal", 80, "Boosts Strength by 50%.", "Strength", 50) { ConflictsWith = [ "Strength I", "Strength II", "Strength III", "Strength IV"] });
            toAdd.Add(new Prayer("Attack V", "Normal", 80, "Boosts Attack by 50%.", "Attack", 50) { ConflictsWith = [ "Attack I", "Attack II", "Attack III", "Attack IV"] });
            toAdd.Add(new Prayer("Ranged V", "Normal", 80, "Boosts Ranged by 50%.", "Ranged", 50) { ConflictsWith = [ "Ranged I", "Ranged II", "Ranged III", "Ranged IV"] });
            toAdd.Add(new Prayer("Magic V", "Normal", 80, "Boosts Magic by 50%.", "Magic", 50) { ConflictsWith = [ "Magic I", "Magic II", "Magic III", "Magic IV"] });  


            for (int i = 0; i < toAdd.Count; i++) {
                PrayerLib.Add(toAdd[i].Name, toAdd[i]);
            }
        }
    }
}