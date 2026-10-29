using System;
using System.Collections.Generic;
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

                        if (AttackingBoss) {
                            LastClickTime = Helper.Time();
                        }
                    }
                });
                    
                double timeToAttack = boss.TimeLastAttacked + boss.Phases[boss.CurrentPhase].AttackSpeedInMS - Helper.Time(); 
                string bossDice = boss.Phases[boss.CurrentPhase].DefaultDmgDice;
                string bossType = boss.Phases[boss.CurrentPhase].DefaultDmgType;
                int bossPoisonSeverity = boss.Phases[boss.CurrentPhase].DefaultPoisonSeverity;

                if (boss.UsingMove != -1 && boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove) {
                    bossDice = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].DamageDice;
                    bossType = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].DamageType;
                    bossPoisonSeverity = boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].PoisonSeverity;
                }

                bool reachedKillLimit = player.KillLimit == 0 ? true : false;
                if (player.CollectionLogBoss.ContainsKey(boss.ID)) {
                    reachedKillLimit = player.KillLimit != -1 && player.CollectionLogBoss[boss.ID].KillCount >= player.KillLimit; 
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

                    if (boss.CurrentLane == i) {
                        Color col = Color.White;

                        if (boss.UsingMove != -1) {
                            if (boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove) {
                                if (boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].AdjustedLanes(boss.LaneWhenMoveSelected, boss.LanesHere).Contains(i)) {
                                    if (timeToAttack > boss.Phases[boss.CurrentPhase].AttackSpeedInMS / 2.0) {
                                        col = Color.Yellow;
                                    } else {
                                        col = Color.Crimson;
                                    }
                                }
                            }
                        }

                        mini.Con.PrintClickable(65, printY++, new ColoredString("(standing here)", col, Color.Black), () => { boss.CurrentLane = i; });
                    } else {
                        Color col = Color.DarkSlateGray;

                        if (boss.UsingMove != -1) {
                            if (boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove) {
                                if (boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].AdjustedLanes(boss.LaneWhenMoveSelected, boss.LanesHere).Contains(i)) {
                                    if (timeToAttack > boss.Phases[boss.CurrentPhase].AttackSpeedInMS / 2.0) {
                                        col = Color.Yellow;
                                    } else {
                                        col = Color.Crimson;
                                    }
                                }
                            }
                        }

                        mini.Con.PrintClickable(65, printY++, new ColoredString("(empty)", col, Color.Black), () => { boss.CurrentLane = i; });
                    }
                }

                if (GraceTimeStart + 5000 < Helper.Time() && boss.TimeLastAttacked + boss.Phases[boss.CurrentPhase].AttackSpeedInMS < Helper.Time() && boss.Phases[boss.CurrentPhase].CurrentHP > 0) {
                    if (boss.AggroLevel > player.GetCombatLevel() || boss.AlwaysAggro || boss.AttackingPlayer) {
                        boss.TimeLastAttacked = Helper.Time();

                        int dmg = GoRogue.DiceNotation.Dice.Roll(bossDice);
                        if (dmg < 0)
                            dmg = 0;

                        int modified = dmg;
                             

                        int hitChance = GameLoop.rand.Next(100);

                        bool safespotting = false;

                        if (player.Equipment.TryGetValue("Weapon", out ItemWrapper? weaponWrap) && weaponWrap.GetRef() is Item weapon) {
                            if (weapon.EquipSkill == "Ranged") {
                                if (bossType == "Melee") {
                                    safespotting = true;
                                }
                            }
                        }

                        if (player.IsMaging() && bossType == "Melee") {
                            safespotting = true;
                        }

                        if (boss.UsingMove != -1 && boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove && boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].SummonID != "") {
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

                        if (!safespotting && boss.UsingMove != -1 && boss.Phases[boss.CurrentPhase].Specials.Count > boss.UsingMove && !boss.Phases[boss.CurrentPhase].Specials[boss.UsingMove].AdjustedLanes(boss.LaneWhenMoveSelected, boss.LanesHere).Contains(boss.CurrentLane)) {
                            safespotting = true;
                            Log.AddMessage(new ColoredString("You deftly dodge out of the way of the boss' special attack.", Color.Green, Color.Black));
                        } 

                        if (!safespotting) {
                            if (hitChance < 25 + (player.GetEffectiveSkillLevel("Defense") / 4.0)) {
                                Log.AddMessage(new ColoredString(boss.Phases[boss.CurrentPhase].Name + " tried to hit you but missed!", Color.Yellow, Color.Black));
                            } else {
                                modified -= player.TotalArmorValue(bossType); 
                                         
                                if (dmg != modified) {
                                    if (modified <= 0) {
                                        Log.AddMessage(new ColoredString(boss.Phases[boss.CurrentPhase].Name + " hit you for " + dmg + ", but you took no damage!", Color.Crimson, Color.Black));
                                    } else {
                                        Log.AddMessage(new ColoredString(boss.Phases[boss.CurrentPhase].Name + " hit you for " + dmg + ", reduced to " + modified + "!", Color.Crimson, Color.Black));
                                    }
                                } else {
                                    Log.AddMessage(new ColoredString(boss.Phases[boss.CurrentPhase].Name + " hit you for " + dmg + "!", Color.Crimson, Color.Black));
                                }

                                if (modified > 0) {
                                    if (bossPoisonSeverity > 0) {
                                        int odds = bossType == "Melee" ? 4 : bossType == "Ranged" ? 8 : 1;

                                        if (GameLoop.rand.Next(odds) == 0 && player.PoisonStatus < bossPoisonSeverity) {
                                            bool antipoison = false;
                                            foreach (var pcheck in player.ActivePotions) {
                                                if (pcheck.Stat == "Antipoison" && pcheck.Change > 0) {
                                                    antipoison = true;
                                                }
                                            }
                                            if (!antipoison) {
                                                player.PoisonStatus = bossPoisonSeverity;
                                                Log.AddMessage("You have been poisoned!", Color.Lime);
                                            }
                                        }
                                    }

                                    if (player.Equipment.TryGetValue("Ring", out ItemWrapper? ring) && ring != null && ring.ID == "ringRecoil") {
                                        int reflect = (modified / 10) + 1;

                                        if (reflect > ring.Charges)
                                            reflect = ring.Charges;

                                        ring.Charges -= reflect; 
                                        Log.AddMessage(new ColoredString("Your ring of recoil reflected " + reflect + " damage back!", Color.DeepSkyBlue, Color.Black));

                                        if (ring.Charges <= 0) { 
                                            Log.AddMessage(new ColoredString("Your ring of recoil runs out of charge and shatters.", Color.Crimson, Color.Black));
                                            player.Equipment.Remove("Ring");
                                        }
                                    }
                                }
                                    
                                bool died = modified > 0 ? player.TakeDamage(modified, Log) : false;

                                if (died) {
                                    AttackingBoss = false;
                                    return printY; 
                                }
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
                }

                double attackSpeed = 1.0;
                     
                if (player.Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrap) && wepWrap.GetRef() is Item wep) { 
                    attackSpeed = wep.AttackSpeed;
                }

                int ammo = 0;

                if (LastHitTime + (1000 * attackSpeed) < Helper.Time() && boss.Phases[boss.CurrentPhase].CurrentHP > 0 && AttackingBoss) {
                    LastHitTime = Helper.Time();
                    boss.AttackingPlayer = true;

                    int hitChance = GameLoop.rand.Next(100); 
                             
                    // Remove a unit of ammo if this is a ranged weapon
                    ammo = player.UseRangedAmmo(false); 

                    if (ammo >= 0) {
                        string whichSkill = player.IsMaging() ? "Magic" : ammo == 1 ? "Ranged" : "Attack";

                        if (player.IsMaging()) {  
                            player.ConsumeItems(player.CombatCasting.Talismans(), false, true);  
                            player.TryGrantExp("Magic", player.CombatCasting.CastExp(), Log, SidebarManager.RecentlyTrainedSkills);
                        }

                        double eqpAccuracy = 0; 
                        foreach (var kv in player.Equipment) {
                            if (kv.Value.GetRef() is Item eqp) {
                                if (eqp.MiscString == "HitChance") {
                                    eqpAccuracy += eqp.EquipTier;
                                }
                            }
                        }

                        if (curr.Dark && !player.HasLightSource()) { 
                            Log.AddMessage(new ColoredString("You can't see well enough to land an attack!", Color.Crimson, Color.Black));
                            hitChance = 999;
                        }

                        if (hitChance > 25 + (player.GetEffectiveSkillLevel(whichSkill) / 2.0) + eqpAccuracy) {
                            Log.AddMessage(new ColoredString("You tried to hit the " + boss.Phases[boss.CurrentPhase].Name + " but missed!", Color.Crimson, Color.Black));
                        } else {
                            int pdmg = GameLoop.rand.Next(player.MaxDamage()); 

                            if (player.GetDamageType() == boss.Phases[boss.CurrentPhase].WeakType) { pdmg = (int)Math.Ceiling(pdmg * 1.5f); }
                            if (Materials.ElementalWeaknesses.TryGetValue(boss.Phases[boss.CurrentPhase].Element, out string? weak) && weak != null && weak == player.GetDamageElement()) { pdmg = (int) Math.Ceiling(pdmg * 1.5); }
                            if (Materials.ElementalStrengths.TryGetValue(boss.Phases[boss.CurrentPhase].Element, out string? strong) && strong != null && strong == player.GetDamageElement()) { pdmg = (int) Math.Floor(pdmg * 0.5); }
                                     

                            if (boss.Phases[boss.CurrentPhase].ImmuneTypes.Contains(player.GetDamageType())) { pdmg = 0; } 

                            if (boss.SpecialCategory != "" && (player.GetDamageType() == boss.SpecialCategory || player.GetSecondaryDamageType() == boss.SpecialCategory)) { // Mostly for Crumble Undead, but open to similar spells for Demons, Vamps, etc
                                pdmg = (int)Math.Ceiling(pdmg * 2f);
                            }
                            
                            bool crit = false;
                            int critTarget = 20;
                            int critRoll = GameLoop.rand.Next(20) + 1; 
                            if (critRoll >= critTarget) { crit = true; pdmg *= 2; } 


                            if (pdmg > boss.Phases[boss.CurrentPhase].CurrentHP)
                                pdmg = boss.Phases[boss.CurrentPhase].CurrentHP;

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
                                boss.Phases[boss.CurrentPhase].CurrentHP -= pdmg;
                                     
                                Log.AddMessage(new ColoredString("You hit " + (boss.Phases[boss.CurrentPhase].ProperName ? "" : "the ") + boss.Phases[boss.CurrentPhase].Name + " for " + pdmg + "." + (crit ? " Critical Hit!" : ""), crit ? Color.Lime : Color.Green, Color.Black));
                                
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
                            }

                            player.GainCombatExp((int) (pdmg * boss.ExpMultiplier), reachedKillLimit, ammo == 1);

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

                    if ((thisOne.Level > player.GetCombatLevel() && thisOne.AlwaysAggro) || thisOne.AttackingPlayer)
                        nameCol = Color.Crimson;

                    if (thisOne == AttackingMonster)
                        nameCol = Color.Yellow;

                    if (thisOne.CurrentHP <= 0)
                        nameCol = nameCol.GetDarker();

                    if (!thisOne.AllReqsMet(player)) { 
                        nameCol = Color.DarkSlateGray; 
                        thisOne.CurrentHP = -1;
                        continue;
                    }

                    if (GraceTimeStart + 5000 < Helper.Time() && thisOne.TimeLastAttacked + (2000 * thisOne.AttackSpeedSeconds) < Helper.Time() && thisOne.CurrentHP > 0) {
                        if ((thisOne.AggroLevel > player.GetCombatLevel() && thisOne.AlwaysAggro) || thisOne.AttackingPlayer) {
                            thisOne.TimeLastAttacked = Helper.Time();

                            int dmg = GameLoop.rand.Next(thisOne.MaxHit + 1);
                            if (dmg < 0)
                                dmg = 0;
                            int modified = dmg;
                              
                            if (!player.Safespotting(thisOne.DamageType, thisOne.Inaccessible)) {
                                if (GameLoop.rand.Next(100) + (thisOne.AttackLv / 4) < 25 + (player.GetEffectiveSkillLevel("Defense") / 4.0)) {
                                    Log.AddMessage(new ColoredString(thisOne.Name + " tried to hit you but missed!", Color.Yellow, Color.Black));
                                } else {
                                    modified -= player.TotalArmorValue(thisOne.DamageType); 

                                    if (Materials.ElementalWeaknesses.TryGetValue(player.ElementalAttunement, out string? weak) && weak != null && weak == thisOne.Element) { modified = (int) Math.Ceiling(modified * 1.5); }
                                    if (Materials.ElementalStrengths.TryGetValue(player.ElementalAttunement, out string? strong) && strong != null && strong == thisOne.Element) { modified = (int) Math.Floor(modified * 0.5); }
                                          
                                    if (dmg != modified) {
                                        if (modified <= 0) {
                                            Log.AddMessage(new ColoredString(thisOne.Name + " hit you for " + dmg + ", but you took no damage!", Color.DarkRed, Color.Black));
                                        } else if (modified < dmg) {
                                            Log.AddMessage(new ColoredString(thisOne.Name + " hit you for " + dmg + ", reduced to " + modified + "!", Color.Crimson.GetDarker(), Color.Black));
                                        } else if (modified >= dmg) {
                                            Log.AddMessage(new ColoredString(thisOne.Name + " hit you for " + dmg + ", but did " + modified + " because of elemental weakness!", Color.Red, Color.Black));
                                        }
                                    } else {
                                        Log.AddMessage(new ColoredString(thisOne.Name + " hit you for " + dmg + "!", Color.Crimson, Color.Black));
                                    }

                                    if (modified > 0) {
                                        if (thisOne.PoisonSeverity > 0) {
                                            int odds = thisOne.DamageType == "Melee" ? 4 : thisOne.DamageType == "Ranged" ? 8 : 1;

                                            if (GameLoop.rand.Next(odds) == 0 && player.PoisonStatus < thisOne.PoisonSeverity) {
                                                if (player.PotionStatus("Antipoison") <= 0) {
                                                    player.PoisonStatus = thisOne.PoisonSeverity;
                                                    Log.AddMessage("You have been poisoned!", Color.Lime);
                                                }
                                            }
                                        }
                                    }

                                    bool died = modified > 0 ? player.TakeDamage(modified, Log) : false; 

                                    if (died) {
                                        AttackingMonster = null;
                                        return printY; 
                                    }
                                }
                            }
                        }
                    }

                    double attackSpeed = 1.0;

                    if (player.Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrap) && wepWrap.GetRef() is Item wep) { attackSpeed = wep.AttackSpeed; }

                    int ammo = 0;

                    if (AttackingMonster != null && LastHitTime + (2000 * attackSpeed) < Helper.Time() && AttackingMonster.CurrentHP > 0) {
                        LastHitTime = Helper.Time();
                        AttackingMonster.AttackingPlayer = true;

                        reachedKillLimit = player.KillLimit == 0 ? true : false;
                        if (player.CollectionLog.ContainsKey(AttackingMonster.ID)) {
                            reachedKillLimit = player.KillLimit != -1 && player.CollectionLog[AttackingMonster.ID].KillCount >= player.KillLimit;
                        }

                        int hitChance = GameLoop.rand.Next(100); 
                             
                        // Remove a unit of ammo if this is a ranged weapon
                        ammo = player.UseRangedAmmo(AttackingMonster.Inaccessible);

                        if (ammo >= 0) {
                            string whichSkill = player.IsMaging() ? "Magic" : ammo == 1 ? "Ranged" : "Attack";

                            if (player.IsMaging() && player.CombatCasting != null) { 
                                player.ConsumeItems(player.CombatCasting.Talismans(), false, true);  
                                player.TryGrantExp("Magic", player.CombatCasting.CastExp(), Log, SidebarManager.RecentlyTrainedSkills); 
                            }

                            double eqpAccuracy = 0; 
                            foreach (var kv in player.Equipment) {
                                if (kv.Value.GetRef() is Item eqp) {
                                    if (eqp.MiscString == "HitChance") {
                                        eqpAccuracy += eqp.EquipTier;
                                    }
                                }
                            }

                            string dmgType = player.GetDamageType();
                            if (AttackingMonster.Inaccessible && (dmgType == "Crush" || dmgType == "Stab" || dmgType == "Slash")) {
                                Log.AddMessage(new ColoredString("You can't reach this enemy with melee attacks. Try ranged or magic instead.", Color.Crimson, Color.Black));
                            } else {
                                if (curr.Dark && !player.HasLightSource()) { 
                                    Log.AddMessage(new ColoredString("You can't see well enough to land an attack!", Color.Crimson, Color.Black));
                                    hitChance = 999;
                                }

                                if (hitChance + (player.GetEffectiveSkillLevel(whichSkill) / 4.0) + eqpAccuracy < 25 + (AttackingMonster.DefenseLv / 4)) {
                                    Log.AddMessage(new ColoredString("You tried to hit " + (AttackingMonster.ProperName ? "" : "the ") + AttackingMonster.Name + " but missed!", Color.Crimson, Color.Black));
                                } else {
                                    int pdmg = GameLoop.rand.Next(player.MaxDamage() + 1);

                                    if (player.GetDamageType() == AttackingMonster.WeakType) { pdmg = (int)Math.Ceiling(pdmg * 1.5f); }
                                    Materials.ElementalWeaknesses.TryGetValue(AttackingMonster.Element, out string? weak);
                                    if (weak != null && weak != "" && player.GetDamageElement() == weak) { pdmg = (int)Math.Ceiling(pdmg * 1.5f); }
                                    Materials.ElementalStrengths.TryGetValue(AttackingMonster.Element, out string? strong);
                                    if (strong != null && strong != "" && player.GetDamageElement() == strong) { pdmg = (int)Math.Ceiling(pdmg * 0.5f); }

                                         
                                    bool eitherDamageSpecial = AttackingMonster.SpecialCategory != "" && (player.GetDamageType() == AttackingMonster.SpecialCategory || player.GetSecondaryDamageType() == AttackingMonster.SpecialCategory);

                                    if (eitherDamageSpecial) { // Mostly for Crumble Undead, but open to similar spells for Demons, Vamps, etc
                                        pdmg = (int)Math.Ceiling(pdmg * 2f);
                                    }
                                    
                                    bool crit = false; int critTarget = 20; int critRoll = GameLoop.rand.Next(20) + 1; 
                                    if (critRoll >= critTarget) { crit = true; pdmg *= 2; } 

                                    if (pdmg > AttackingMonster.CurrentHP)
                                        pdmg = AttackingMonster.CurrentHP;

                                    AttackingMonster.CurrentHP -= pdmg;
                                     
                                    Log.AddMessage(new ColoredString("You hit " + (AttackingMonster.ProperName ? "" : "the ") + AttackingMonster.Name + " for " + pdmg + "." + (crit ? " Critical Hit!" : ""), crit ? Color.Lime : Color.Green, Color.Black));
                                    
                                    player.GainCombatExp(pdmg, reachedKillLimit, ammo == 1);
                                     
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
                            int wins = Helper.CombatSimulator(player.GetSimBlock(curr.MonstersHere[i].DamageType), curr.MonstersHere[i].GetSimBlock(), 100);

                            Color col = Color.White;

                            if (wins > 80) { col = Color.Lime; }
                            else if (wins > 60) { col = Color.ForestGreen; }
                            else if (wins < 20) { col = Color.Crimson; }
                            else if (wins < 40) { col = Color.Yellow; }

                            Log.AddMessage("Approximate odds of success against " + curr.MonstersHere[i].Name + " (with no food or prayer): " + wins + "%", col);  
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
