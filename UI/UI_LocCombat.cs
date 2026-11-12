using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.UI {
    public static class UI_LocCombat { 
        public static AreaMonster AttackingMonster = null;
        public static bool AttackingBoss = false;
        public static double LastHitTime = 0;
        public static double GraceTimeStart = 0;
        public static string Targetting = "Single";  

        public static double LastClickTime = 0;

        public static int DrawCombat(Location curr, Player player, UI_EmbeddedMini mini, int printY, MessageLog Log) {
            if ((AttackingBoss || AttackingMonster != null) && LastClickTime + 600_000 < Helper.Time()) { // if player hasn't clicked an enemy in 10 minutes, stop fighting
                AttackingBoss = false;
                AttackingMonster = null; 

                GameLoop.WTN.Log.AddMessage("You feel your arms get tired of this repetitive motion. To prove your determination and continue attacking, click to attack an enemy again.");
            }



            if (curr.BossHere != "" && GameLoop.WTN.BossLibrary.TryGetValue(curr.BossHere, out BossFight? boss) && boss != null && boss.Phases.Count > boss.CurrentPhase) {  
                mini.Con.DrawLine(new Point(56, printY), new Point(109, printY++), 196);
                mini.Con.Print(57, printY, "Boss Here: ");

                mini.Con.PrintClickable(68, printY, "(Log)", () => {
                    ExtraWindows.CollectionLog.IsVisible = true;
                    ExtraWindows.CollectionID = boss.ID;
                    ExtraWindows.CollectionCat = "Boss";
                    ExtraWindows.CollectionDropTop = 0;
                });

                mini.Con.PrintClickable(74, printY, new ColoredString("(Attack)", AttackingBoss ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => {
                    if (!AttackingBoss && curr.Dark && !player.HasLightSource()) {
                        Log.AddMessage("It may be a bad idea to aggravate a monster you can't currently see to hit.");
                    } else {
                        AttackingBoss = !AttackingBoss; 
                        if (AttackingBoss) { LastClickTime = Helper.Time(); }
                    }
                });
                    
                double timeToAttack = boss.TimeLastAttacked + (boss.Phases[boss.CurrentPhase].AttackSpeedSeconds * 2000) - Helper.Time(); 
                 
                string bossType = boss.Phases[boss.CurrentPhase].DefaultDmgType;
                string bossElement = boss.Phases[boss.CurrentPhase].Element;
                int bossPoisonSeverity = boss.Phases[boss.CurrentPhase].DefaultPoisonSeverity;
                int atkBoost = 0;

                bool bossUsingSpecial = boss.UsingMove != -1 && boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove;

                if (bossUsingSpecial) { 
                    atkBoost = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].DamageAdd;
                    bossType = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].DamageType;
                    bossElement = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].DamageElement;
                    bossPoisonSeverity = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].PoisonSeverity;
                }

                bool reachedKillLimit = player.KillLimit == 0 ? true : false;
                if (player.CollectionLogBoss.TryGetValue(boss.ID, out CollectionLogEntry? bossLog) && bossLog != null) {
                    reachedKillLimit = player.KillLimit != -1 && bossLog.KillCount >= player.KillLimit; 
                }

                if (GraceTimeStart + 5000 > Helper.Time()) {
                    mini.Con.Print(98, printY, "Grace: " + Math.Floor(GraceTimeStart + 5000 - Helper.Time()), Color.DarkSlateGray);
                } else { 
                    if (timeToAttack > 0 && boss.Phases[boss.CurrentPhase].CurrentHP > 0)
                        mini.Con.Print(95, printY, "Attack:  " + (Math.Floor(timeToAttack)).ToString().Align(HorizontalAlignment.Right, 5));
                } 

                printY++; 

                mini.Con.Print(57, printY, "| " + boss.Phases[boss.CurrentPhase].Name + " (" + boss.Phases[boss.CurrentPhase].CurrentHP + "/" + boss.Phases[boss.CurrentPhase].MaxHP + " hp)", (boss.AggroLevel > player.GetCombatLevel() || boss.AlwaysAggro || boss.AttackingPlayer) ? Color.Crimson : Color.White);
                mini.Con.Print(97, printY, "Next: " + bossType.Align(HorizontalAlignment.Right, 6));
                    

                printY += 2;


                    
                mini.Con.Print(57, printY++, "Lanes ");
                for (int i = 0; i < boss.LanesHere; i++) {
                    mini.Con.PrintClickable(57, printY, "| Lane: ", () => { boss.CurrentLane = i; });
                     
                    Color col = boss.CurrentLane == i ? Color.White : Color.DarkSlateGray;

                    if (boss.UsingMove != -1) {
                        if (boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove) {
                            if (boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].AdjustedLanes(boss.LaneWhenMoveSelected, boss.LanesHere).Contains(i)) {
                                if (timeToAttack > (2000 * boss.Phases[boss.CurrentPhase].AttackSpeedSeconds) / 2.0) {
                                    col = Color.Yellow;
                                } else {
                                    col = Color.Crimson;
                                }
                            }
                        }
                    }

                    mini.Con.PrintClickable(65, printY++, new ColoredString(boss.CurrentLane == i ? "(standing here)" : "(empty)", col, Color.Black), () => { boss.CurrentLane = i; });
                }

                bool aggressive = (boss.AggroLevel > player.GetCombatLevel() && boss.AlwaysAggro) || boss.AttackingPlayer;
                bool safespotting = player.Safespotting(bossType);
                
                if (!safespotting && (bossUsingSpecial && !boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].AdjustedLanes(boss.LaneWhenMoveSelected, boss.LanesHere).Contains(boss.CurrentLane))) {
                    safespotting = true;
                    Log.AddMessage(new ColoredString("You deftly dodge out of the way of the boss' special attack.", Color.Green, Color.Black));
                }

                if (GraceTimeStart + 5000 < Helper.Time() && timeToAttack <= 0 && boss.Phases[boss.CurrentPhase].CurrentHP > 0 && aggressive) { 
                    boss.TimeLastAttacked = Helper.Time();

                    if (bossUsingSpecial && boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].SummonID != "") {
                        if (GameLoop.WTN.MonsterLibrary.TryGetValue(boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].SummonID, out AreaMonster? summon) && summon != null) {
                            int amount = GoRogue.DiceNotation.Dice.Roll(boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].SummonDice);

                            for (int i = 0; i < amount; i++) {
                                Log.AddMessage(boss.Phases[boss.CurrentPhase].Name + " summons a" + (Helper.VowelStart(summon.Name.ToLower()) ? "n ": " ") + summon.Name.ToLower() + "!", Color.Crimson);
                                AreaMonster summonCopy = Helper.Clone(summon);
                                summonCopy.Temporary = true;
                                curr.MonstersHere.Add(summonCopy);
                            }
                        }
                    } 

                    if (!safespotting) {
                        if (boss.AttackDeck.Count == 0) { boss.ResetAttackDeck(); }
                        if (player.DefenseDeck.Count == 0) { player.ResetDefenseDeck(); }

                        int atk = boss.AttackDeck.Pop();
                        atk = (int) Math.Ceiling(atk * player.ElementMulti(bossElement));
                        int def = player.DefenseDeck.Pop();

                        player.ModifyDefense(ref atk, ref def);

                        int diff = atk - def;
                        int dr = player.TotalArmorValue(bossType);

                        int dmg = Math.Max(0, diff - dr);

                        bool poisoning = (bossPoisonSeverity > player.PoisonStatus && player.PotionStatus("Antipoison") <= 0 && dmg > 0);
                        Log.AddMessage(boss.GetName() + " attacks you: " + dmg + " damage (" + atk + " vs " + def + (dr > 0 ? ", -" + dr + " from armor": "") + ")." + (poisoning ? " You are poisoned!" : ""), Color.Crimson);
                        
                        if (dmg > 0) {
                            if (poisoning) { player.PoisonStatus = bossPoisonSeverity; }
                            bool died = player.TakeDamage(dmg, Log);

                            if (died) { AttackingBoss = false; boss.AttackingPlayer = false; return printY; }
                        }
                    }

                    if (boss.UsingMove != -1) {
                        boss.UsingMove = -1;
                        boss.MovesSinceSpecial = 0;
                    } else {
                        boss.MovesSinceSpecial++;

                        if (boss.MovesSinceSpecial == boss.Phases[boss.CurrentPhase].AttacksBetweenSpecials && boss.Phases[boss.CurrentPhase].Specials.Count > 0) {
                            boss.UsingMove = GameLoop.rand.Next(boss.Phases[boss.CurrentPhase].Specials.Count);
                            boss.LaneWhenMoveSelected = boss.CurrentLane;
                            Log.AddMessage(boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].WarningText, Color.Yellow);
                        }
                    } 
                } 

                int ammo = 0;

                if (LastHitTime + player.GetAttackSpeed() < Helper.Time() && boss.Phases[boss.CurrentPhase].CurrentHP > 0 && AttackingBoss) {
                    LastHitTime = Helper.Time();
                    boss.AttackingPlayer = true;

                    if (player.AttackDeck.Count == 0) { player.ResetAttackDeck(); }
                    if (boss.DefenseDeck.Count == 0) { player.ResetDefenseDeck(); }

                    int hitChance = GameLoop.rand.Next(100); 
                             
                    // Remove a unit of ammo if this is a ranged weapon
                    ammo = player.UseRangedAmmo(false); 

                    if (ammo >= 0) {
                        string whichSkill = player.IsMaging() ? "Magic" : ammo == 1 ? "Ranged" : "Attack";

                        if (player.IsMaging()) {  
                            player.ConsumeItems(player.CombatCasting.Talismans(), false, true);  
                            player.TryGrantExp("Magic", player.CombatCasting.CastExp(), Log, SidebarManager.RecentlyTrainedSkills);
                        }

                        if (curr.Dark && !player.HasLightSource()) { 
                            Log.AddMessage(new ColoredString("You can't see well enough to land an attack!", Color.Crimson, Color.Black));
                        } else {
                            int atk = player.AttackDeck.Pop(); 
                            atk = (int) Math.Ceiling(atk * boss.ElementMulti(player.GetDamageElement())); // If elemental interaction, modify atk card
                            int def = boss.DefenseDeck.Pop();

                            bool crit = false;
                            player.ModifyAttack(ref atk, ref def, boss.CurrentHP(), ref crit, boss.GetWeakType(), boss.SpecialCategory);

                            int diff = atk - def;
                            int dr = boss.GetDR();
                            int dmg = Math.Max(0, diff - dr);

                            if (dmg > boss.CurrentHP()) { dmg = boss.CurrentHP(); }

                            bool bossImmune = false;
                            if (boss.Phases[boss.CurrentPhase].InvincibleIfAll.Count > 0) {
                                bossImmune = true;
                                foreach (var req in boss.Phases[boss.CurrentPhase].InvincibleIfAll) {
                                    if (!req.CheckRequirement(player, false, false)) {
                                        bossImmune = false;
                                        Log.AddMessage(req.GetSummary(), Color.Crimson);
                                    }
                                }
                            }

                            if (!bossImmune) {
                                boss.TakeDamage(dmg);

                                Log.AddMessage("You attack " + boss.GetName() + ": " + dmg + " damage (" + atk + " vs " + def + (dr > 0 ? ", -" + dr + " from DR": "") + ").", crit ? Color.Lime : Color.ForestGreen);
                                
                                if (boss.Phases[boss.CurrentPhase].HitActionOdds > 0 && GameLoop.rand.Next(boss.Phases[boss.CurrentPhase].HitActionOdds) == 0) {
                                    foreach (var act in boss.Phases[boss.CurrentPhase].HitActions) {
                                        act.Execute();
                                    }
                                }

                                foreach (var con in boss.Phases[boss.CurrentPhase].PhaseConditions) {
                                    if (boss.Phases.Count > con.NewPhase) {
                                        if (con.When == "Hit") {
                                            if (GameLoop.rand.Next(con.TriggerNum) == 0) {
                                                int currHP = boss.Phases[boss.CurrentPhase].CurrentHP;
                                                boss.CurrentPhase = con.NewPhase;
                                                boss.Phases[boss.CurrentPhase].CurrentHP = Math.Clamp(currHP + con.HealOnTransition, currHP, boss.Phases[boss.CurrentPhase].MaxHP);
                                                GameLoop.WTN.Log.AddMessage(con.GetMessage());
                                            }
                                        }
                                    }
                                }
                                
                                
                                player.GainCombatExp((int) (dmg * boss.ExpMultiplier), reachedKillLimit, ammo == 1);
                          
                                if (boss.Phases[boss.CurrentPhase].CurrentHP <= 0) {
                                    bool canKill = true;
                                    if (boss.KillItem != "") {
                                        if (player.HasAllItems([boss.KillItem +",1"], false, true)) {
                                            player.ConsumeItems([boss.KillItem + ",1"], false, true);
                                        } else {
                                            canKill = false;
                                            boss.Phases[boss.CurrentPhase].CurrentHP = 0;
                                            Log.AddMessage(new ColoredString("You need " + GameLoop.WTN.ResolveItemName(boss.KillItem) + " to finish this enemy off.", Color.Crimson, Color.Black)); 
                                        }
                                    }

                                    if (canKill) {
                                        boss.TimeLastKilled = Helper.Time();
                                        boss.AttackingPlayer = false;

                                        player.TryProgressQuest("Kill", boss.ID); 

                                        if (!player.CollectionLogBoss.ContainsKey(boss.ID))
                                            player.CollectionLogBoss.Add(boss.ID, new(boss.ID));

                                        player.CollectionLogBoss[boss.ID].KillCount += 1; 

                                        if (player.KillLimit != -1 && player.CollectionLogBoss[boss.ID].KillCount == player.KillLimit) {
                                            Log.AddMessage(new ColoredString("You've killed " + player.KillLimit + " " + boss.Phases[boss.CurrentPhase].Name + "s and will no longer receive drops or exp from them."));
                                        }

                                        if (boss.DropTable != null && boss.DropTable.Count > 0) {
                                            for (int j = 0; j < boss.DropTable.Count; j++) {
                                                ItemDrop drop = boss.DropTable[j];

                                                drop.RollDrop(player, player.CollectionLogBoss[boss.ID]);
                                            }
                                        }

                                        if (player.NightmareMode && player.DeathMode == 2 && player.ExpMultiplier == 1 && whichSkill == "Attack") {
                                            if (SteamManager.TryUnlockAchievement("Overachiever_Nightmare_Boss")) {  
                                                Log.AddMessage("Achievement unlocked: Kill a boss on Nightmare mode with Permadeath enabled, on 1x Experience, with a melee attack.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    } else { 
                        Log.AddMessage(new ColoredString("You haven't got any valid ammo for your weapon!", Color.Crimson, Color.Black));
                    }
                }

                if (boss.Phases[boss.CurrentPhase].CurrentHP <= 0 && boss.TimeLastKilled + (boss.RespawnTime * 1000) < Helper.Time()) {
                    boss.CurrentPhase = 0;
                    boss.Phases[boss.CurrentPhase].CurrentHP = boss.Phases[boss.CurrentPhase].MaxHP;  
                    boss.TimeLastAttacked = Helper.Time();
                    boss.AttackingPlayer = false;
                }  

                if (ammo == 1) {
                    List<string> empties = new();
                    foreach (var kv in player.Equipment) {
                        if (kv.Value.Quantity <= 0) {
                            empties.Add(kv.Key);
                        }
                    }

                    foreach (var rem in empties) {
                        player.Equipment.Remove(rem);
                    }
                }
            }

            if (curr.MonstersHere.Where(o => o.AllReqsMet(player)).ToList().Count > 0) {
                mini.Con.DrawLine(new Point(56, printY), new Point(109, printY++), 196);

                mini.Con.Print(57, printY, "Monsters Here: ");
                mini.Con.PrintClickable(72, printY, new ColoredString("(SINGLE)", Targetting == "Single" ? Color.Yellow : Color.White, Color.Black), () => { Targetting = "Single"; });
                mini.Con.PrintClickable(81, printY, new ColoredString("(ORDER)", Targetting == "Order" ? Color.Yellow : Color.White, Color.Black), () => { Targetting = "Order"; });
                mini.Con.PrintClickable(89, printY++, new ColoredString("(RANDOM)", Targetting == "Random" ? Color.Yellow : Color.White, Color.Black), () => { Targetting = "Random"; });

                if (GraceTimeStart + 5000 > Helper.Time()) {
                    mini.Con.Print(98, printY - 1, "Grace: " + Math.Floor(GraceTimeStart + 5000 - Helper.Time()), Color.DarkSlateGray);
                }

                if (AttackingMonster != null && AttackingMonster.CurrentHP <= 0) {
                    if (Targetting == "Order") {
                        for (int j = 0; j < curr.MonstersHere.Count; j++) {
                            if (curr.MonstersHere[j].CurrentHP > 0) { 
                                AttackingMonster = curr.MonstersHere[j];
                                break;
                            }
                        }
                    }
                    else if (Targetting == "Random") { 
                        List<AreaMonster> alive = new();

                        for (int mon = 0; mon < curr.MonstersHere.Count; mon++) {
                            if (curr.MonstersHere[mon].CurrentHP > 0) { 
                                alive.Add(curr.MonstersHere[mon]);
                            }
                        }

                        while (AttackingMonster.CurrentHP <= 0 && alive.Count > 0) {
                            AttackingMonster = alive[GameLoop.rand.Next(alive.Count)];
                        }
                    }
                } 

                for (int i = 0; i < curr.MonstersHere.Count; i++) {
                    AreaMonster thisOne = curr.MonstersHere[i];

                    bool reachedKillLimit = player.KillLimit == 0 ? true : false;
                    if (player.CollectionLog.ContainsKey(thisOne.ID)) {
                        reachedKillLimit = player.KillLimit != -1 && player.CollectionLog[thisOne.ID].KillCount >= player.KillLimit; 
                    }

                    Color nameCol = Color.White;

                    bool aggro = (thisOne.AggroLevel > player.GetCombatLevel() && thisOne.Aggressive) || thisOne.AttackingPlayer;

                    if (aggro) { nameCol = Color.Crimson; } 
                    if (thisOne == AttackingMonster) { nameCol = Color.Yellow; } 
                    if (thisOne.CurrentHP <= 0) { nameCol = nameCol.GetDarker(); } 
                    if (!thisOne.AllReqsMet(player)) { 
                        nameCol = Color.DarkSlateGray; 
                        thisOne.CurrentHP = -1;
                        continue;
                    }

                    if (GraceTimeStart + 5000 < Helper.Time() && thisOne.TimeLastAttacked + (2000 * thisOne.AttackSpeedSeconds) < Helper.Time() 
                    && thisOne.CurrentHP > 0 && aggro && !player.Safespotting(thisOne.DamageType, thisOne.Inaccessible)) {
                        thisOne.TimeLastAttacked = Helper.Time();

                        if (thisOne.AttackDeck.Count == 0) { thisOne.ResetAttackDeck(); }
                        if (player.DefenseDeck.Count == 0) { player.ResetDefenseDeck(); }

                        int atk = thisOne.AttackDeck.Pop();
                        atk = (int) Math.Ceiling(atk * player.ElementMulti(thisOne.Element)); // If elemental interaction, modify atk card
                        int def = player.DefenseDeck.Pop();
                        
                        int diff = atk - def; 
                        int dr = player.TotalArmorValue(thisOne.DamageType);

                        int dmg = Math.Max(0, diff - dr);

                        Log.AddMessage((thisOne.ProperName ? thisOne.Name + " " : "The " + thisOne.Name.ToLower() + " ") + "attacks you: " + dmg + " damage (" + atk + " vs " + def + (dr > 0 ? ", -" + dr + " from armor": "") + ")." + ((thisOne.PoisonSeverity > player.PoisonStatus && player.PotionStatus("Antipoison") <= 0 && dmg > 0) ? " You are poisoned!" : ""), Color.Crimson);
                         
                        if (dmg > 0) { 
                            if (thisOne.PoisonSeverity > player.PoisonStatus && player.PotionStatus("Antipoison") <= 0) { player.PoisonStatus = thisOne.PoisonSeverity; }
                            bool died = player.TakeDamage(dmg, Log);
                            
                            if (died) { AttackingMonster = null; return printY; }
                        } 
                    }
                     
                    int ammo = 0;

                    if (AttackingMonster != null && LastHitTime + player.GetAttackSpeed() < Helper.Time() && AttackingMonster.CurrentHP > 0) {
                        LastHitTime = Helper.Time();
                        AttackingMonster.AttackingPlayer = true;

                        if (player.AttackDeck.Count == 0) { player.ResetAttackDeck(); }
                        if (AttackingMonster.DefenseDeck.Count == 0) { AttackingMonster.ResetDefenseDeck(); }

                        reachedKillLimit = player.KillLimit == 0 ? true : false;
                        if (player.CollectionLog.ContainsKey(AttackingMonster.ID)) { reachedKillLimit = player.KillLimit != -1 && player.CollectionLog[AttackingMonster.ID].KillCount >= player.KillLimit; } 
                             
                        // Remove a unit of ammo if this is a ranged weapon
                        ammo = player.UseRangedAmmo(AttackingMonster.Inaccessible);

                        if (ammo >= 0) {
                            string whichSkill = player.IsMaging() ? "Magic" : ammo == 1 ? "Ranged" : "Attack"; 

                            if (player.IsMaging()) { 
                                player.ConsumeItems(player.CombatCasting.Talismans(), false, true);  
                                player.TryGrantExp("Magic", player.CombatCasting.CastExp(), Log, SidebarManager.RecentlyTrainedSkills); 
                            }

                            if (AttackingMonster.Inaccessible && whichSkill == "Attack") {
                                Log.AddMessage(new ColoredString("You can't reach this enemy with melee attacks. Try ranged or magic instead.", Color.Crimson, Color.Black));
                            } else {
                                if (curr.Dark && !player.HasLightSource()) { 
                                    Log.AddMessage(new ColoredString("You can't see well enough to land an attack!", Color.Crimson, Color.Black)); 
                                } else { 
                                    int atk = player.AttackDeck.Pop();
                                    atk = (int) Math.Ceiling(atk * AttackingMonster.ElementMulti(player.GetDamageElement())); // If elemental interaction, modify atk card
                                    int def = AttackingMonster.DefenseDeck.Pop(); 
                                    if (player.GetDamageType() == AttackingMonster.WeakType) { def = (int) Math.Floor(def * 0.75); }

                                    bool crit = false; 
                                    player.ModifyAttack(ref atk, ref def, AttackingMonster.CurrentHP, ref crit, AttackingMonster.WeakType, AttackingMonster.SpecialCategory);

                                    
                        
                                    int diff = atk - def; 
                                    int dr = AttackingMonster.DamageReduction;

                                    int dmg = Math.Max(0, diff - dr);

                                    if (dmg > AttackingMonster.CurrentHP)
                                        dmg = AttackingMonster.CurrentHP;

                                    AttackingMonster.CurrentHP -= dmg;

                                    Log.AddMessage("You attack " + (thisOne.ProperName ? thisOne.Name + " " : "the " + thisOne.Name.ToLower() + " ") + ": " + dmg + " damage (" + atk + " vs " + def + (dr > 0 ? ", -" + dr + " from DR": "") + ").", crit ? Color.Lime : Color.ForestGreen);
                         
                                    if (dmg > 0) { 
                                        player.GainCombatExp(dmg, reachedKillLimit, ammo == 1);
                                     
                                        if (AttackingMonster.CurrentHP <= 0) {
                                            bool canKill = true;
                                            if (AttackingMonster.KillItem != "") {
                                                if (player.HasAllItems([AttackingMonster.KillItem +",1"], false, true)) {
                                                    player.ConsumeItems([AttackingMonster.KillItem + "," + AttackingMonster.KillItemCount], false, true);
                                                } else {
                                                    canKill = false;
                                                    AttackingMonster.CurrentHP = 0;
                                                    Log.AddMessage(new ColoredString("You need " + GameLoop.WTN.ResolveItemName(AttackingMonster.KillItem) + " to finish this enemy off.", Color.Crimson, Color.Black)); 
                                                }
                                            }

                                            if (canKill) {
                                                AttackingMonster.TimeLastKilled = Helper.Time();
                                                AttackingMonster.AttackingPlayer = false;

                                                player.TryProgressQuest("Kill", AttackingMonster.ID);

                                                if (!player.CollectionLog.ContainsKey(AttackingMonster.ID))
                                                    player.CollectionLog.Add(AttackingMonster.ID, new(AttackingMonster.ID));

                                                player.CollectionLog[AttackingMonster.ID].KillCount += 1;

                                                if (player.KillLimit != -1 && player.CollectionLog[AttackingMonster.ID].KillCount == player.KillLimit) {
                                                    Log.AddMessage(new ColoredString("You've killed " + player.KillLimit + " " + AttackingMonster.Name + "s and will no longer receive drops or exp from them."));
                                                }

                                                if (AttackingMonster.DropTable != null && AttackingMonster.DropTable.Count > 0) {
                                                    for (int j = 0; j < AttackingMonster.DropTable.Count; j++) {
                                                        ItemDrop drop = AttackingMonster.DropTable[j];

                                                        drop.RollDrop(player, player.CollectionLog[AttackingMonster.ID], AttackingMonster.Inaccessible);
                                                    }
                                                }
                                            }
                                        }
                                    } 
                                }
                            }
                        } else { 
                            Log.AddMessage(new ColoredString("You haven't got any valid ammo for your weapon!", Color.Crimson, Color.Black));
                        }
                    }

                    if (thisOne.CurrentHP <= 0 && thisOne.TimeLastKilled + (thisOne.RespawnTime * 1000) < Helper.Time()) {
                        thisOne.CurrentHP = thisOne.MaxHP; 
                        thisOne.TimeLastAttacked = Helper.Time();
                        thisOne.AttackingPlayer = false;
                    } 
                    
                    if (printY < 35) {
                        mini.Con.PrintClickable(56, printY, new ColoredString(20.AsString(), Color.Crimson, Color.Black), () => {
                            int wins = Helper.WarCombatSim(player.GetSimBlock(curr.MonstersHere[i].DamageType), curr.MonstersHere[i].GetSimBlock(), 1000);

                            Color col = Color.White;

                            if (wins > 80) { col = Color.Lime; }
                            else if (wins > 60) { col = Color.ForestGreen; }
                            else if (wins < 20) { col = Color.Crimson; }
                            else if (wins < 40) { col = Color.Yellow; }

                            Log.AddMessage("Approximate odds of success against " + curr.MonstersHere[i].Name + " (with no food or prayer): " + (wins / 10) + "%", col);  
                        });

                        mini.Con.Print(57, printY, "|");

                        if (GameLoop.WTN.SpellLibrary.TryGetValue("utilMonsterInspect", out Spell? inspect) && inspect != null) { 
                            if (player.CanCast(inspect) == "") {
                                mini.Con.PrintClickable(57, printY, new ColoredString("?", Color.MediumPurple, Color.Black), () => {
                                    Log.AddMessage("You cast monster inspect on the " + curr.MonstersHere[i].Name + ".", Color.MediumPurple);
                                    Log.AddMessage(curr.MonstersHere[i].GetSummary(), Color.Yellow);  
                                    inspect.Cast(player, Log, SidebarManager.RecentlyTrainedSkills);  
                                });  
                            }
                        } 
                     
                        mini.Con.PrintClickable(59, printY, new ColoredString(curr.MonstersHere[i].Name, nameCol, Color.Black), () => { 
                            if (curr.Dark && !player.HasLightSource()) { 
                                Log.AddMessage("It may be a bad idea to aggravate a monster you can't currently see to hit.");
                            } else {
                                AttackingMonster = thisOne; 
                                LastClickTime = Helper.Time();
                            }
                        }); 
                        mini.Con.Print(90, printY, ("(" + curr.MonstersHere[i].CurrentHP + "/" + curr.MonstersHere[i].MaxHP + " hp)").Align(HorizontalAlignment.Right, 15));
                        mini.Con.Print(86, printY, ("[" + curr.MonstersHere[i].Level.ToString().Align(HorizontalAlignment.Right, 3) + "]"));

                        mini.Con.PrintClickable(106, printY++, "Log", () => {
                            ExtraWindows.CollectionLog.IsVisible = true;
                            ExtraWindows.CollectionID = curr.MonstersHere[i].ID;
                            ExtraWindows.CollectionDropTop = 0;
                            ExtraWindows.CollectionCat = "Monster";
                        });
                    }

                    if (ammo == 1) {
                        List<string> empties = new();
                        foreach (var kv in player.Equipment) {
                            if (kv.Value.Quantity <= 0) {
                                empties.Add(kv.Key);
                            }
                        }

                        foreach (var rem in empties) {
                            player.Equipment.Remove(rem);
                        }
                    }

                    if (thisOne.CurrentHP <= 0 && thisOne.Temporary) {
                        curr.MonstersHere.Remove(thisOne);
                        break;
                    }
                }
            } 


            return printY;
        }
    }
}
