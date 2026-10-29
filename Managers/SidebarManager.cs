using GoRogue.DiceNotation.Terms;
using SadConsole.Input;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.UI;

namespace WorldtreeNexus.Managers {  
    public static class SidebarManager {
        public static string SidebarMenu = "Inventory"; 
        public static int SwapSlot = -1;
        public static List<Skill> RecentlyTrainedSkills = new();
        
        public static double LastHealedTick = 0; 
        public static double LastPrayerTick = 0; 
        public static double LastPoisonTick = 0; 
        public static int SidebarScrollTop = 0;
        public static Rectangle SidebarRect = new Rectangle(new Point(0, 15), new Point(54, 34));
        
        public static string QuestSort = "A->Z"; 
        public static string MagicTab = "Combat"; 

        public static string TypingField = "";

        public static TwoWayString LastFoundRecipe = null;
        public static TwoWayString LastPerformedRecipe = null;

        public static void Draw(UI_EmbeddedMini mini, Player player) {
            Point mousePos = new MouseScreenObjectState(mini.Con, GameHost.Instance.Mouse).CellPosition;
            double time = Helper.Time();

            mini.Con.DrawLine(new Point(55, 0), new Point(55, 34), 179);
             
            
            if (LastHealedTick + 3000 < time) {
                if (player.Equipment.TryGetValue("Hands", out ItemWrapper? eqp) && eqp != null && eqp.ID == "braceletRegen") {
                    player.CurrentHP = Math.Clamp(player.CurrentHP + 1, 0, player.Skills["Hitpoints"].Level);
                }
                player.CurrentHP = Math.Clamp(player.CurrentHP + 1, 0, player.Skills["Hitpoints"].Level);
                LastHealedTick = time;
            }
            
            int prayBonus = player.GetPrayerBonus();
            bool prayerTicking = LastPrayerTick + 2000 + (prayBonus * 100) <= time;
            if (prayerTicking) { // Every 1 second, plus 100ms per +1 prayer bonus on worn equipment
                LastPrayerTick = time;
                if (player.ActivePrayers.Count > 0) {
                    if (player.CurrentPrayer == 0) { 
                        player.ActivePrayers.Clear(); 
                    } else {
                        player.CurrentPrayer = Math.Clamp(player.CurrentPrayer - player.ActivePrayers.Count, 0, player.CurrentPrayer);
                    }
                }
            }

            if (player.PoisonStatus > 0) {
                if (LastPoisonTick + 15000 < time) {
                    LastPoisonTick = time;

                    int poisonDamage = Math.Max(1, (int) Math.Floor((player.PoisonStatus + 4) / 5.0));
                    GameLoop.WTN.Log.AddMessage("You take " + poisonDamage + " damage from poison.", Color.Lime);
                    player.TakeDamage(poisonDamage, GameLoop.WTN.Log);

                    player.PoisonStatus -= 1;
                    if (player.PoisonStatus == 0) {
                        GameLoop.WTN.Log.AddMessage("You are no longer poisoned.", Color.Lime);
                    }
                }
            }

            if (player.Clock != null) {
                mini.Con.PrintClickable(1, 0, new ColoredString(player.Clock.GetTime(), Color.White, Color.Black), () => { player.Clock.TwelveHour = !player.Clock.TwelveHour; });
            }

            mini.Con.Print(0, 2, "    HP: " + player.CurrentHP.ToString().Align(HorizontalAlignment.Right, 4, ' ') + " / " + player.Skills["Hitpoints"].Level.ToString().Align(HorizontalAlignment.Right, 4, ' '), Color.Crimson);
            mini.Con.Print(0, 3, "Prayer: " + player.CurrentPrayer.ToString().Align(HorizontalAlignment.Right, 4, ' ') + " / " + player.GetMaxPrayer().ToString().Align(HorizontalAlignment.Right, 4, ' '), prayerTicking ? Color.White : Color.DodgerBlue);
            
            

            mini.Con.Print(0, 5, " Level: " + player.GetCombatLevel(), Color.Yellow); 

            bool magic = player.IsMaging();

            string dmgType = player.GetDamageType();
            dmgType = dmgType.Contains("Ranged") ? dmgType.Replace("Ranged", "Ra") : dmgType;
            string dmgDisp = dmgType.Substring(0, 3); 

            dmgDisp += " " + player.GetDamageElement();

            mini.Con.Print(0, 6, "MaxHit: " + player.MaxDamage() + " " + dmgDisp, Color.Yellow); 
            mini.Con.Print(0, 7, "DR: " + player.TotalArmorValue("Melee") + 20.AsString() + " / " + player.TotalArmorValue("Magic") + 19.AsString() + " / " + player.TotalArmorValue("Ranged") + 18.AsString(), Color.Yellow); 


            if (player.CombatCasting != null) {
                string castingWhich = "Casting Spell #";

                if (player.CombatSpell1 != null && player.CombatSpell1.Equals(player.CombatCasting)) { castingWhich += "1"; }
                else if (player.CombatSpell2 != null && player.CombatSpell2.Equals(player.CombatCasting)) { castingWhich += "2"; }
                else if (player.CombatSpell3 != null && player.CombatSpell3.Equals(player.CombatCasting)) { castingWhich += "3"; }
                else if (player.CombatSpell4 != null && player.CombatSpell4.Equals(player.CombatCasting)) { castingWhich += "4"; }
                else if (player.CombatSpell5 != null && player.CombatSpell5.Equals(player.CombatCasting)) { castingWhich += "5"; }
                else { castingWhich += "E"; }
                    
                mini.Con.PrintClickable(0, 9, new ColoredString("*" + castingWhich.Align(HorizontalAlignment.Center, 18) + "*", Color.SkyBlue, Color.Black), () => { player.CombatCasting = null; });
            }

            if (player.CoinPouch) {
                mini.Con.PrintClickable(0, 11, new ColoredString((String.Format($"{player.HeldGold:n0}") + 15.AsString()).Align(HorizontalAlignment.Right, 19), Color.Goldenrod, Color.Black), () => {
                    if (GameLoop.WTN.ResolveItem("coins") is Item coin) {
                        int qty = 1;
                        if (Helper.EitherShift()) { qty *= 5; }
                        if (Helper.EitherControl()) { qty *= 10; }
                        if (Helper.KeyDown(Keys.Space)) { qty *= 1000; }
                        if (qty > player.HeldGold || Helper.EitherAlt()) { qty = player.HeldGold; }

                        player.HeldGold -= qty;
                        player.TryPickup(coin, qty); 
                    }
                });
            }

            mini.Con.DrawLine(new Point(20, 0), new Point(20, 11), 179);
            mini.Con.Print(21, 0, "Recently Trained Skills");
            mini.Con.Print(21, 1, "Skill Name        Lv      To Next", Color.SlateGray);
            if (RecentlyTrainedSkills.Count > 0) {
                for (int i = 0; i < RecentlyTrainedSkills.Count; i++) {
                    int toNext = RecentlyTrainedSkills[i].EXPNeeded();
                    mini.Con.Print(21, 2 + i, "| " + RecentlyTrainedSkills[i].Name);
                    mini.Con.Print(38, 2 + i, RecentlyTrainedSkills[i].Level.ToString().PadLeft(3));

                    if (RecentlyTrainedSkills[i].Level < 100) {
                        mini.Con.Print(47, 2 + i, toNext.ToString().PadLeft(7));
                    } else { 
                        mini.Con.Print(47, 2 + i, "MAXED".PadLeft(7), Color.Lime);
                    }
                }
            }

            if (GameLoop.WTN.Atlas.ContainsKey(player.NavLoc)) {
                Location curr = GameLoop.WTN.Atlas[player.NavLoc];


                if (curr.ItemSpawns.Count > 0) {  
                    for (int i = 0; i < curr.ItemSpawns.Count; i++) {  
                        if (curr.ItemSpawns[i].LastPickedUp + (curr.ItemSpawns[i].RespawnTimer * 1000) < Helper.Time() || curr.ItemSpawns[i].LastPickedUp == 0) { 
                            int spawnedCount = 0;

                            if (curr.ItemSpawns[i].ReqToSpawn != null && !curr.ItemSpawns[i].ReqToSpawn.CheckRequirement(player, true, true)) {
                                continue;
                            } 
                             
                            for (int j = 0; j < curr.ItemsHere.Count; j++) {
                                if (player.RandomItems == 0) {
                                    if (curr.ItemsHere[j].ID == curr.ItemSpawns[i].ItemID && curr.ItemsHere[j].Inaccessible == curr.ItemSpawns[i].Inaccessible) {
                                        spawnedCount += curr.ItemsHere[j].Quantity;
                                    }
                                } else {
                                    if (GameLoop.WTN.ItemLibrary.ContainsKey(curr.ItemSpawns[i].ItemID)) {
                                        if (curr.ItemsHere[j].ID == GameLoop.WTN.ItemLibrary[curr.ItemSpawns[i].ItemID].ID && curr.ItemsHere[j].Inaccessible == curr.ItemSpawns[i].Inaccessible) { 
                                            spawnedCount += curr.ItemsHere[j].Quantity;
                                        }
                                    }
                                }
                            }

                            if (spawnedCount < curr.ItemSpawns[i].SpawnCount) {
                                if (GameLoop.WTN.ItemLibrary.ContainsKey(curr.ItemSpawns[i].ItemID)) {
                                    Item spawn = new(GameLoop.WTN.ItemLibrary[curr.ItemSpawns[i].ItemID]);

                                    if (curr.ItemSpawns[i].Inaccessible) {
                                        spawn.Inaccessible = true;
                                    }

                                    GameLoop.WTN.TryPlaceItem(curr.ID, new(spawn, spawn.Inaccessible));
                                    curr.ItemSpawns[i].LastPickedUp = Helper.Time();
                                }
                            }
                        }
                    }
                }




                mini.Con.DrawLine(new Point(0, 12), new Point(54, 12), 196);
                int hx = 0;
                mini.Con.PrintClickable(hx, 13, new ColoredString("INV", SidebarMenu == "Inventory" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Inventory"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " "); 
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("EQP", SidebarMenu == "Equipment" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Equipment"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("SKL", SidebarMenu == "Skills" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Skills"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("MAG", SidebarMenu == "Magic" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Magic"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("PRA", SidebarMenu == "Prayer" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Prayer"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("EMO", SidebarMenu == "Emote" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Emote"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("QST", SidebarMenu == "Quest" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Quest"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("LOG", SidebarMenu == "Log" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Log"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("POT", SidebarMenu == "Potions" ? Color.Yellow : Color.White, Color.Black), () => { SidebarMenu = "Potions"; });
                hx = hx + 3;
                mini.Con.Print(hx, 13, " ");
                hx = hx + 1;
                mini.Con.PrintClickable(hx, 13, new ColoredString("MUS", SidebarMenu == "Music" ? Color.Yellow : Color.White, Color.Black), () => { 
                    SidebarMenu = "Music"; 

                    int scrollTop = 0;
                    List<KeyValuePair<string, IrrKlang.ISoundSource>> songs = GameLoop.SoundManager.Songs.OrderBy(o => o.Key).ToList();

                    for (int i = 0; i < songs.Count; i++) {
                        if (GameLoop.SoundManager.CurrentSong == songs[i].Key) {
                            scrollTop = i - 9;
                        }
                    }
                    
                    SidebarScrollTop = Math.Clamp(scrollTop, 0, songs.Count);
                    //SidebarScrollTop = Math.Clamp(scrollTop, 0, songs.Count - 18);
                });


                mini.Con.DrawLine(new Point(0, 14), new Point(54, 14), 196);

                if (SidebarMenu == "Inventory") {

                    for (int i = 0; i < player.InventoryLimit; i++) {
                        mini.Con.DrawLine(new Point(0, 15 + i), new Point(54, 15 + i), '-', Color.DarkSlateGray);

                        if (i < player.Inventory.Count && player.Inventory[i].GetRef() is Item inv) {
                            int shop = curr.ShopItemsHere.Contains(player.Inventory[i].ID) ? 2 : curr.ShopItemsHere.Count > 0 ? 1 : 0;
                            ColoredString name = inv.GetNameCS(player.Inventory[i].Quantity, shop, player.Inventory[i].Charges, player.Inventory[i].Noted, player.Inventory[i]);

                            mini.Con.Print(0, 15 + i, (mousePos.X < 55 && mousePos.Y == 15 + i) ? name.GetDarker() : name);

                            bool dropped = false; 

                            int px = 52;
                            
                            mini.Con.PrintClickable(54, 15 + i, new ColoredString("X", Color.Crimson, Color.Black), () => { dropped = player.TryDrop(i); });

                            if (dropped)
                                break;

                             if (GameLoop.WTN.SpellLibrary.TryGetValue("utilAlchemyHigh", out Spell? highAlch) && highAlch != null) { 
                                if (player.CanCast(highAlch) == "") {
                                    mini.Con.PrintClickable(px, 15 + i, new ColoredString(247.AsString() + " ", Color.Lime, Color.Black), () => {
                                        if (player.Inventory[i].GetRef() is Item alched) {
                                            if (alched.HighAlchVal() > 0) {  
                                                player.Inventory[i].Quantity -= 1;  
                                                highAlch.Cast(player, GameLoop.WTN.Log, RecentlyTrainedSkills);  
                                                player.GiveGold(alched.HighAlchVal()); 
                                                GameLoop.WTN.Log.AddMessage(new ColoredString("You cast High Alchemy and convert the " + alched.Name + " into " + alched.HighAlchVal() + " gold.", Color.Goldenrod, Color.Black));
                                                
                                            }
                                        }
                                    }); 
                                    px -= 2;

                                    if (player.Inventory[i].Quantity <= 0) {
                                        player.Inventory.RemoveAt(i);
                                        dropped = true;
                                    }
                                }
                            }

                            if (dropped)
                                break;

                            if (GameLoop.WTN.SpellLibrary.TryGetValue("utilAlchemyLow", out Spell? lowAlch) && lowAlch != null) { 
                                if (player.CanCast(lowAlch) == "") {
                                    mini.Con.PrintClickable(px, 15 + i, new ColoredString("~ ", Color.Green, Color.Black), () => {
                                        if (player.Inventory[i].GetRef() is Item alched) {
                                            if (alched.LowAlchVal() > 0) {  
                                                player.Inventory[i].Quantity -= 1;
                                                 
                                                lowAlch.Cast(player, GameLoop.WTN.Log, RecentlyTrainedSkills);  
                                                player.GiveGold(alched.LowAlchVal()); 
                                                GameLoop.WTN.Log.AddMessage(new ColoredString("You cast Low Alchemy and convert the " + alched.Name + " into " + alched.LowAlchVal() + " gold.", Color.DarkGoldenrod, Color.Black));
                                            }
                                        }
                                    }); 
                                    px -= 2;

                                    if (player.Inventory[i].Quantity <= 0) {
                                        player.Inventory.RemoveAt(i);
                                        dropped = true;
                                    }
                                }
                            } 

                            if (dropped)
                                break;

                            mini.Con.PrintClickable(px, 15 + i, new ColoredString("? ", Color.MediumPurple, Color.Black), () => { 
                                if (player.Inventory[i].Containing.Count == 0) {
                                    List<string> kittenColors = [ "kittenBlack", "kittenGray", "kittenWhite", "kittenOrange", "kittenBrown", "kittenCalico" ];
                                    if (kittenColors.Contains(player.Inventory[i].ID)) {
                                        int minSinceFed = player.Inventory[i].MiscInt / 60;
                                        int minSincePlay = player.Inventory[i].MiscInt2 / 60;
                                        int minAge = player.Inventory[i].MiscInt3 / 60;
                                        GameLoop.WTN.Log.AddMessage(new ColoredString(inv.ExamineText + " (" + minSinceFed + " minutes since fed, " + minSincePlay + " minutes without play, " + minAge + " minutes old)", Color.SandyBrown, Color.Black));
                                    } else {
                                        List<string> catColors = [ "catBlack", "catGray", "catWhite", "catOrange", "catBrown", "catCalico" ];
                                        if (catColors.Contains(player.Inventory[i].ID)) {
                                            int minAge = player.Inventory[i].MiscInt3 / 60;
                                            GameLoop.WTN.Log.AddMessage(new ColoredString(inv.ExamineText + " (" + minAge + " minutes old)", Color.SandyBrown, Color.Black));
                                        } else {
                                            GameLoop.WTN.Log.AddMessage(new ColoredString(inv.ExamineText, Color.SandyBrown, Color.Black));
                                        }
                                    }
                                } else {
                                    string build = inv.Name + ": ";

                                    for (int con = 0; con < player.Inventory[i].Containing.Count; con++) {
                                        build += (con != 0 ? ", " : "") + (player.Inventory[i].Containing[con].Quantity > 1 ? player.Inventory[i].Containing[con].Quantity + "x " : " ") + GameLoop.WTN.ResolveItemName(player.Inventory[i].Containing[con].ID);
                                    } 

                                    GameLoop.WTN.Log.AddMessage(build, Color.SandyBrown); 
                                }

                                foreach (var kv in GameLoop.WTN.QuestLibrary) {
                                    kv.Value.CheckProgress(player, "ExamineItem", player.Inventory[i].ID, 0);
                                }
                            });

                            px -= 2;

                            mini.Con.PrintClickable(px, 15 + i, new ColoredString("> ", Color.Turquoise, Color.Black), () => {
                                if (SwapSlot == -1) {
                                    SwapSlot = i;
                                }
                                else { 
                                    ItemWrapper first = new(player.Inventory[SwapSlot]);
                                    player.Inventory[SwapSlot] = new(player.Inventory[i]);
                                    player.Inventory[i] = first;
                                    SwapSlot = -1;
                                }
                            });

                            px -= 2;

                            if (!player.Inventory[i].Noted) {
                                mini.Con.PrintClickable(px, 15 + i, new ColoredString("U ", ItemUseLogic.UsingSlot == i ? Color.Green : Color.Yellow, Color.Black), () => {
                                    if (ItemUseLogic.UsingSlot != i && ItemUseLogic.TryCombineItems(player, i)) {
                                        dropped = true;
                                    }
                                });
                            }
                            px -= 2;
                            if (dropped)
                                break;

                            if (inv.UseString != "") {
                                if (!player.Inventory[i].Noted) { 
                                    mini.Con.PrintClickable(px, 15 + i, new ColoredString("* ", Color.Yellow, Color.Black), () => { 
                                        bool success = ItemUseLogic.UseItem(player.Inventory[i], player);
                                        bool flagForDeletion = false;

                                        if (inv.ConsumedOnUse && success) { 
                                            if (inv.UsesCharges) {
                                                if (player.Inventory[i].Charges > 0) { 
                                                    player.Inventory[i].Charges--; 
                                                    if (player.Inventory[i].Charges <= 0 && inv.ShattersAtZeroCharges) { 
                                                        flagForDeletion = true;
                                                        if (inv.ItemReturned == "") {
                                                            GameLoop.WTN.Log.AddMessage("Your " + inv.Name + " runs out of uses and shatters.", Color.MediumPurple);
                                                        }
                                                    } else if (player.Inventory[i].Charges <= 0 && !inv.ShattersAtZeroCharges) {  
                                                        GameLoop.WTN.Log.AddMessage("Your " + inv.Name + " runs out of charges.", Color.MediumPurple);
                                                    } 
                                                } else if (player.Inventory[i].Charges == 0) { 
                                                    GameLoop.WTN.Log.AddMessage("That item doesn't have any charges left.", Color.Crimson);
                                                }
                                            } else { 
                                                player.Inventory[i].Quantity -= 1; 
                                                if (player.Inventory[i].Quantity <= 0) {
                                                    flagForDeletion = true;
                                                } 
                                            }
                                        } 

                                        if (player.Inventory.Count <= i) {
                                            dropped = true;
                                            return;
                                        }

                                        if (flagForDeletion || player.Inventory[i].Quantity <= 0) {
                                            player.Inventory.RemoveAt(i);
                                            dropped = true;
                                             
                                            if (inv.ItemReturned != "" && GameLoop.WTN.ResolveItem(inv.ItemReturned) is Item returned) {
                                                player.TryPickup(returned, 1);
                                            }
                                        } 
                                    });
                                    px -= 2;
                                }
                            }

                            if (dropped)
                                break;

                            if (inv.EquipSlot != "" && !player.Inventory[i].Noted) {
                                mini.Con.PrintClickable(px, 15 + i, new ColoredString("E ", Color.Yellow, Color.Black), () => { dropped = ItemUseLogic.TryEquipItem(player, i); });
                                px -= 2;
                            } 

                            if (inv.ChargeItem != "" && !player.Inventory[i].Noted && player.HasAllItems([inv.ChargeItem + ",1"])) {
                                mini.Con.PrintClickable(px, 15 + i, new ColoredString("+ ", Color.Turquoise, Color.Black), () => { dropped = ItemUseLogic.TryChargeItem(player, i); });
                                px -= 2;
                            } 

                            if (dropped)
                                break;
                        }
                    }
                }

                else if (SidebarMenu == "Equipment") {
                    mini.Con.Print(36, 32, " Combat EXP Split");
                    mini.Con.PrintClickable(39, 33, "ATK " + player.OffenseExpSplit, () => {
                        player.OffenseExpSplit = Math.Clamp(player.OffenseExpSplit + 1, 0, 4);
                    });

                    mini.Con.Print(45, 33, ":");

                    mini.Con.PrintClickable(47, 33, 4 - player.OffenseExpSplit + " STR", () => {
                        player.OffenseExpSplit = Math.Clamp(player.OffenseExpSplit - 1, 0, 4);
                    });

                    

                    mini.Con.PrintClickable(39, 34, "DEF " + player.DefenseExpSplit, () => {
                        player.DefenseExpSplit = Math.Clamp(player.DefenseExpSplit + 1, 0, 4);
                    });

                    mini.Con.Print(45, 34, ":");

                    mini.Con.PrintClickable(47, 34, 4 - player.DefenseExpSplit + " HIT", () => {
                        player.DefenseExpSplit = Math.Clamp(player.DefenseExpSplit - 1, 0, 4);
                    });

                    mini.Con.Print(1, 15, "Equipped Items");

                    int printY = 16;

                    mini.Con.Print(1, printY, "|   Weapon: "); 
                    if (player.Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrap) && wepWrap.GetRef() is Item wep) {
                        ColoredString name = wep.GetNameCS(wepWrap.Quantity, 0, wepWrap.Charges, wepWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Weapon"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Weapon");
                        });

                        if (wep.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(wepWrap, player);

                                if (wep.ConsumedOnUse && success) {
                                    wepWrap.TryConsume();
                                }

                                if (wepWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Weapon"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "| Off-hand: ");
                    if (player.Equipment.TryGetValue("Offhand", out ItemWrapper? offWrap) && offWrap.GetRef() is Item off) {
                        ColoredString name = off.GetNameCS(offWrap.Quantity, 0, offWrap.Charges, offWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Offhand"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Offhand");
                        });

                        if (off.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(offWrap, player);

                                if (off.ConsumedOnUse && success) {
                                    offWrap.TryConsume();
                                }

                                if (offWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Offhand"); 
                                }
                            });  
                        }
                    }
                     
                    printY++;

                    mini.Con.Print(1, printY, "|     Head: "); 
                    if (player.Equipment.TryGetValue("Head", out ItemWrapper? headWrap) && headWrap.GetRef() is Item head) {
                        ColoredString name = head.GetNameCS(headWrap.Quantity, 0, headWrap.Charges, headWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Head"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Head");
                        });

                        if (head.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(headWrap, player);

                                if (head.ConsumedOnUse && success) {
                                    headWrap.TryConsume();
                                }

                                if (headWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Head"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Body: "); 
                    if (player.Equipment.TryGetValue("Body", out ItemWrapper? bodyWrap) && bodyWrap.GetRef() is Item body) { 
                        ColoredString name = body.GetNameCS(bodyWrap.Quantity, 0, bodyWrap.Charges, bodyWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Body"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Body");
                        });

                        if (body.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(bodyWrap, player);

                                if (body.ConsumedOnUse && success) {
                                    bodyWrap.TryConsume();
                                }

                                if (bodyWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Body"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Legs: "); 
                    if (player.Equipment.TryGetValue("Legs", out ItemWrapper? legWrap) && legWrap.GetRef() is Item legs) {
                        ColoredString name = legs.GetNameCS(legWrap.Quantity, 0, legWrap.Charges, legWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Legs"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Legs");
                        });

                        if (legs.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(legWrap, player);

                                if (legs.ConsumedOnUse && success) {
                                    legWrap.TryConsume();
                                }

                                if (legWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Legs"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|    Hands: ");
                    if (player.Equipment.TryGetValue("Hands", out ItemWrapper? handWrap) && handWrap.GetRef() is Item hands) {
                        ColoredString name = hands.GetNameCS(handWrap.Quantity, 0, handWrap.Charges, handWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Hands"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Hands");
                        });

                        if (hands.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(handWrap, player);

                                if (hands.ConsumedOnUse && success) {
                                    handWrap.TryConsume();
                                }

                                if (handWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Hands"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Feet: ");
                    if (player.Equipment.TryGetValue("Feet", out ItemWrapper? feetWrap) && feetWrap.GetRef() is Item feet) {
                        ColoredString name = feet.GetNameCS(feetWrap.Quantity, 0, feetWrap.Charges, feetWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Feet"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Feet");
                        });

                        if (feet.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(feetWrap, player);

                                if (feet.ConsumedOnUse && success) {
                                    feetWrap.TryConsume();
                                }

                                if (feetWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Feet"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Cape: ");
                    if (player.Equipment.TryGetValue("Cape", out ItemWrapper? capeWrap) && capeWrap.GetRef() is Item cape) {
                        ColoredString name = cape.GetNameCS(capeWrap.Quantity, 0, capeWrap.Charges, capeWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Cape"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Cape");
                        });

                        if (cape.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(capeWrap, player);

                                if (cape.ConsumedOnUse && success) {
                                    capeWrap.TryConsume();
                                }

                                if (capeWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Cape"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Ring: ");
                    if (player.Equipment.TryGetValue("Ring", out ItemWrapper? ringWrap) && ringWrap.GetRef() is Item ring) {
                        ColoredString name = ring.GetNameCS(ringWrap.Quantity, 0, ringWrap.Charges, ringWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Ring"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Ring");
                        });

                        if (ring.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(ringWrap, player);

                                if (ring.ConsumedOnUse && success) {
                                    ringWrap.TryConsume();
                                }

                                if (ringWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Ring"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|   Amulet: ");
                    if (player.Equipment.TryGetValue("Amulet", out ItemWrapper? amuletWrap) && amuletWrap.GetRef() is Item amulet) {
                        ColoredString name = amulet.GetNameCS(amuletWrap.Quantity, 0, amuletWrap.Charges, amuletWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Amulet"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Amulet");
                        });

                        if (amulet.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(amuletWrap, player);

                                if (amulet.ConsumedOnUse && success) {
                                    amuletWrap.TryConsume();
                                }

                                if (amuletWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Amulet"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|   Pocket: ");
                    if (player.Equipment.TryGetValue("Pocket", out ItemWrapper? pocketWrap) && pocketWrap.GetRef() is Item pocket) {
                        ColoredString name = pocket.GetNameCS(pocketWrap.Quantity, 0, pocketWrap.Charges, pocketWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Pocket"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Pocket");
                        });

                        if (pocket.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(pocketWrap, player);

                                if (pocket.ConsumedOnUse && success) {
                                    pocketWrap.TryConsume();
                                }

                                if (pocketWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Pocket"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|     Ammo: ");
                    if (player.Equipment.TryGetValue("Ammo", out ItemWrapper? ammoWrap) && ammoWrap.GetRef() is Item ammo) { 
                        ColoredString name = ammo.GetNameCS(ammoWrap.Quantity, 0, ammoWrap.Charges, ammoWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Ammo"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Ammo");
                        });

                        if (ammo.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(ammoWrap, player);

                                if (ammo.ConsumedOnUse && success) {
                                    ammoWrap.TryConsume();
                                }

                                if (ammoWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Ammo"); 
                                }
                            });  
                        }
                    }

                    printY++;

                    mini.Con.Print(1, printY, "|      Pet: ");
                    if (player.Equipment.TryGetValue("Pet", out ItemWrapper? petWrap) && petWrap.GetRef() is Item pet) { 
                        ColoredString name = pet.GetNameCS(petWrap.Quantity, 0, petWrap.Charges, petWrap.Noted);
                        mini.Con.PrintClickable(13, printY, name, () => {
                            ItemWrapper item = player.Equipment["Pet"];
                            player.TryPickup(item, item.Quantity);
                            player.Equipment.Remove("Pet");
                        });

                        if (pet.UseString != "") {  
                            mini.Con.PrintClickable(13 + name.Length + 1, printY, new ColoredString("*", Color.Yellow, Color.Black), () => { 
                                bool success = ItemUseLogic.UseItem(petWrap, player);

                                if (pet.ConsumedOnUse && success) {
                                    petWrap.TryConsume();
                                }

                                if (petWrap.Quantity <= 0) {
                                    player.Equipment.Remove("Pet"); 
                                }
                            });  
                        }
                    }
                }
            
                else if (SidebarMenu == "Skills") {
                    List<Skill> playerSkills = player.Skills.Values.OrderBy(f => f.Name).ToList();

                    mini.Con.Print(1, 15, "Skill Name");
                    mini.Con.Print(21, 15, "Lv");
                    mini.Con.Print(29, 15, "Next Lv At");
                    mini.Con.Print(45, 15, "Total Exp");

                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    int printY = 17;
                      
                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }

                    SidebarScrollTop = Math.Clamp(SidebarScrollTop, 0, player.Skills.Count - 18);
                        
                    if (SidebarRect.Contains(mousePos)) {
                        if (player.Skills.Count > 18) {
                            if (Helper.ScrolledUp()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop - qty, 0, player.Skills.Count - 18); }
                            if (Helper.ScrolledDown()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop + qty, 0, player.Skills.Count - 18); }
                        } else {
                            SidebarScrollTop = 0;
                        }
                    }

                    for (int i = SidebarScrollTop; i < playerSkills.Count && i < SidebarScrollTop + 18; i++) {
                        bool mouseHovering = mousePos.X < 54 && mousePos.Y == printY;

                        mini.Con.PrintClickable(1, printY, new ColoredString(playerSkills[i].Name, mouseHovering ? Color.Yellow : Color.White, Color.Black), () => {
                            ExtraWindows.Compendium.IsVisible = true;
                            ExtraWindows.ResetAllCompendiumValues(); 
                            ExtraWindows.CompendiumSidebarTop = 0;
                            ExtraWindows.CompendiumSourceTop = 0;
                            ExtraWindows.CompendiumDropTop = 0;
                            ExtraWindows.CompendiumCat = "Skills";
                            ExtraWindows.CompendiumViewingID = playerSkills[i].Name;
                            ExtraWindows.Sources = ExtraWindows.AllSkillUses(playerSkills[i].Name);
                        });

                        int esl = player.GetEffectiveSkillLevel(playerSkills[i].Name);

                        mini.Con.Print(20, printY, playerSkills[i].Level.ToString().PadLeft(3), mouseHovering ? Color.Yellow : Color.White);

                        if (esl != playerSkills[i].Level) {
                            mini.Con.Print(25, printY, ("(" + esl.ToString() + ")"), mouseHovering ? Color.Yellow : esl < playerSkills[i].Level ? Color.Crimson : Color.Lime);
                        }

                        if (playerSkills[i].Level < 100) {
                            if (player.PayToWin == 0) { 
                                mini.Con.Print(30, printY, $"{playerSkills[i].ExpToLevel():n00}".PadLeft(10), mouseHovering ? Color.Yellow : Color.White);
                            } else {
                                int actualExpNeeded = (int)Math.Ceiling((double) playerSkills[i].EXPNeeded() / (double) player.ExpMultiplier);
                                Color couldBuy = Color.Lime;
                                if (player.GoldTotal() < player.PayToWin * actualExpNeeded) { couldBuy = Color.Crimson; }

                                mini.Con.PrintClickable(30, printY, new ColoredString($"{playerSkills[i].EXPNeeded():n00}".PadLeft(10), mouseHovering ? couldBuy : Color.White, Color.Black), () => {
                                    player.TryGrantExp(playerSkills[i].Name, actualExpNeeded, GameLoop.WTN.Log, RecentlyTrainedSkills, true);
                                });
                            }
                        } else {
                            mini.Con.Print(35, printY, "MAXED", mouseHovering ? Color.Yellow : Color.Lime);
                        }


                        mini.Con.Print(41, printY, $"{playerSkills[i].Exp:n00}".PadLeft(13), mouseHovering ? Color.Yellow : Color.White);

                        printY++;
                    }
                }

                else if (SidebarMenu == "Emote") {
                    mini.Con.Print(1, 15, "Emote Name"); 
                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    int printY = 17; 
                    mini.Con.PrintClickable(1, printY++, "Nod Head", () => { GameLoop.WTN.Log.AddMessage("You nod your head.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Nod"); });
                    mini.Con.PrintClickable(1, printY++, "Shake Head", () => { GameLoop.WTN.Log.AddMessage("You shake your head.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Shake"); });
                    mini.Con.PrintClickable(1, printY++, "Think", () => { GameLoop.WTN.Log.AddMessage("You ponder for a moment.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Think"); });
                    mini.Con.PrintClickable(1, printY++, "Beckon", () => { GameLoop.WTN.Log.AddMessage("You beckon to nobody in particular.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Beckon"); });
                    mini.Con.PrintClickable(1, printY++, "Dance", () => { GameLoop.WTN.Log.AddMessage("You shake your body in a dance.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Dance"); });
                    mini.Con.PrintClickable(1, printY++, "Cry", () => { GameLoop.WTN.Log.AddMessage("You break down and cry for a moment.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Cry"); }); 
                    mini.Con.PrintClickable(1, printY++, "Clap", () => { GameLoop.WTN.Log.AddMessage("You clap your hands.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Clap"); });
                    mini.Con.PrintClickable(1, printY++, "Wave", () => { GameLoop.WTN.Log.AddMessage("You wave your arm vigorously.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Wave"); });

                    printY = 17;
                    mini.Con.PrintClickable(20, printY++, "Laugh", () => { GameLoop.WTN.Log.AddMessage("You throw your head back and laugh heartily.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Laugh"); });
                    mini.Con.PrintClickable(20, printY++, "Jig", () => { GameLoop.WTN.Log.AddMessage("You dance a little jig.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Jig"); });
                    mini.Con.PrintClickable(20, printY++, "Blow Kiss", () => { GameLoop.WTN.Log.AddMessage("You blow a kiss.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "BlowKiss"); }); 
                    mini.Con.PrintClickable(20, printY++, "Salute", () => { GameLoop.WTN.Log.AddMessage("You put your hand to your head in a crisp salute.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Salute"); });
                    mini.Con.PrintClickable(20, printY++, "Bow", () => { GameLoop.WTN.Log.AddMessage("You take a bow.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Bow"); });
                    mini.Con.PrintClickable(20, printY++, "Shrug", () => { GameLoop.WTN.Log.AddMessage("You shrug your shoulders.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Shrug"); });
                    mini.Con.PrintClickable(20, printY++, "Jump for Joy", () => { GameLoop.WTN.Log.AddMessage("You jump for joy.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "JumpForJoy"); });
                    mini.Con.PrintClickable(20, printY++, "Spin", () => { GameLoop.WTN.Log.AddMessage("You twirl around quickly with your arms stretched out.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Spin"); });

                    printY = 17;
                    mini.Con.PrintClickable(40, printY++, "Panic", () => { GameLoop.WTN.Log.AddMessage("You panic for a moment.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Panic"); });
                    mini.Con.PrintClickable(40, printY++, "Shake Fist", () => { GameLoop.WTN.Log.AddMessage("You shake your fist in anger.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "ShakeFist"); });
                    mini.Con.PrintClickable(40, printY++, "Cheer", () => { GameLoop.WTN.Log.AddMessage("You cheer. Hurray!", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Cheer"); });
                    mini.Con.PrintClickable(40, printY++, "Yawn", () => { GameLoop.WTN.Log.AddMessage("You let out a yawn.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Yawn"); });
                    mini.Con.PrintClickable(40, printY++, "Headbang", () => { GameLoop.WTN.Log.AddMessage("You bang your head to music only you can hear.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Headbang"); });
                    mini.Con.PrintClickable(40, printY++, "Raspberry", () => { GameLoop.WTN.Log.AddMessage("You blow a raspberry.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "Raspberry"); });
                    mini.Con.PrintClickable(40, printY++, "Sit Down", () => { GameLoop.WTN.Log.AddMessage("You sit down for a bit. This was nice.", Color.Yellow); ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Emote", "SitDown"); });
                } else if (SidebarMenu == "Quest") {
                    mini.Con.Print(1, 15, "Quest Name");
                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    int printQuest = 0;

                    int questPoints = 0;
                    int totalPossibleQP = 0;

                    int questsCompleted = 0;
                    int totalQuests = 0;

                    foreach (var quest in GameLoop.WTN.QuestLibrary) {
                        if (quest.Value.CurrentStage() == quest.Value.CompleteStage) {
                            questPoints += quest.Value.QuestPoints;
                            questsCompleted++;
                        }

                        totalPossibleQP += quest.Value.QuestPoints;
                        totalQuests++;
                    }

                    List<Quest> sortedList = GameLoop.WTN.QuestLibrary.Values.Where(o => o.CurrentStage() > -1).ToList();

                    if (QuestSort == "A->Z") {
                        sortedList = sortedList.OrderBy(o => o.Name).ToList();
                    } else if (QuestSort == "!A->Z") {
                        sortedList = sortedList.OrderBy(o => o.Name).Reverse().ToList();
                    } else if (QuestSort == "Release") {
                        sortedList = sortedList.OrderBy(o => o.DateFullyImplemented).ToList();
                    } else if (QuestSort == "!Release") {
                        sortedList = sortedList.OrderBy(o => o.DateFullyImplemented).Reverse().ToList();
                    }

                    int qty = 1;
                    if (Helper.EitherShift())
                        qty *= 5;
                    if (Helper.EitherControl())
                        qty *= 10;

                    if (SidebarRect.Contains(mousePos)) {
                        if (sortedList.Count > 18) {
                            if (Helper.ScrolledUp()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop - qty, 0, sortedList.Count - 18); }
                            if (Helper.ScrolledDown()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop + qty, 0, sortedList.Count - 18); }
                        } else {
                            SidebarScrollTop = 0;
                        }
                    }

                    for (int quest = SidebarScrollTop; quest < sortedList.Count && quest < SidebarScrollTop + 18; quest++) {
                        Color col = Color.DarkSlateGray;

                        if (sortedList[quest].CanStartQuest(player)) {
                            col = Color.Crimson;
                        }

                        if (sortedList[quest].CurrentStage() != -1) {
                            col = Color.Yellow;
                        }

                        if (sortedList[quest].CurrentStage() == sortedList[quest].CompleteStage) {
                            col = Color.Lime;
                        }

                        mini.Con.PrintClickable(0, 17 + printQuest, new ColoredString(sortedList[quest].Name, col, Color.Black), () => {
                            ExtraWindows.Quests.IsVisible = true;
                            ExtraWindows.ViewingQuestID = sortedList[quest].ID;
                             
                            if (sortedList[quest].CurrentStage() == -1) {
                                ExtraWindows.QuestOverview = true;
                            } else {
                                ExtraWindows.QuestOverview = false;
                                ExtraWindows.QuestBlockScrollTop = 0;
                            } 
                        });

                        printQuest++; 
                    }

                    mini.Con.Print(28, 15, "Quests Complete: " + questsCompleted.ToString().Align(HorizontalAlignment.Right, 3) + " / " + totalQuests.ToString().Align(HorizontalAlignment.Right, 3));

                     
                    mini.Con.Print(31, 34, "Quest Points: " + questPoints.ToString().Align(HorizontalAlignment.Right, 3) + " / " + totalPossibleQP.ToString().Align(HorizontalAlignment.Right, 3));

                    mini.Con.DrawLine(new Point(0, 33), new Point(54, 33), 196);

                    mini.Con.PrintClickable(0, 34, new ColoredString("A->Z", QuestSort == "A->Z" ? Color.Lime : QuestSort == "!A->Z" ? Color.Crimson : Color.White, Color.Black), () => {
                        if (QuestSort == "A->Z") {
                            QuestSort = "!A->Z";
                        } else {
                            QuestSort = "A->Z";
                        }
                    });
                    mini.Con.PrintClickable(5, 34, new ColoredString("Release", QuestSort == "Release" ? Color.Lime : QuestSort == "!Release" ? Color.Crimson : Color.White, Color.Black), () => {
                        if (QuestSort == "Release") {
                            QuestSort = "!Release";
                        } else {
                            QuestSort = "Release";
                        }
                    });
                } else if (SidebarMenu == "Magic") { 
                    mini.Con.Print(1, 15, player.MagicBook + " Spellbook Spells");
                    
                    mini.Con.PrintClickable(38, 15, new ColoredString("Combat", MagicTab == "Combat" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { MagicTab = "Combat"; });
                    mini.Con.PrintClickable(45, 15, new ColoredString("Tele", MagicTab == "Tele" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { MagicTab = "Tele"; });
                    mini.Con.PrintClickable(50, 15, new ColoredString("Util", MagicTab == "Utility" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { MagicTab = "Utility"; });

                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    if (MagicTab == "Combat") { 
                        if (player.CombatViewing == null) { player.CombatViewing = new(); }

                        // Saved spell configurations
                        {
                            // Spell 1
                            if (player.CombatSpell1 != null) {
                                mini.Con.PrintClickable(1, 17, new ColoredString(player.CombatSpell1.GetName(), player.CombatViewing.Equals(player.CombatSpell1) ? Color.Lime : Color.White, Color.Black), () => {
                                    player.CombatViewing = new(player.CombatSpell1);
                                });  
                                string canCast = player.CanCast(player.CombatSpell1);
                                mini.Con.PrintClickable(43, 17, "[" + new ColoredString(19.AsString(), canCast == "" ? Color.Turquoise : Color.Crimson, Color.Black) + new ColoredString("]"), () => { 
                                    if (canCast == "") {
                                        player.CombatCasting = new(player.CombatSpell1); 
                                        player.CombatViewing = new(player.CombatSpell1); 
                                    } else {
                                        GameLoop.WTN.Log.AddMessage("Cannot cast this spell: " + canCast, Color.Crimson);
                                    }
                                });
                                
                                mini.Con.PrintClickable(47, 17, "[" + new ColoredString("X", Color.Crimson, Color.Black) + new ColoredString("]"), () => { player.CombatSpell1 = null; });
                            } else {
                                mini.Con.Print(1, 17, "(empty spell slot)", Color.DarkSlateGray); 
                            }
                            mini.Con.PrintClickable(51, 17, "[" + new ColoredString("+", Color.Lime, Color.Black) + new ColoredString("]"), () => { player.CombatSpell1 = new(player.CombatViewing); });

                            // Spell 2
                            if (player.CombatSpell2 != null) {
                                mini.Con.PrintClickable(1, 18, new ColoredString(player.CombatSpell2.GetName(), player.CombatViewing.Equals(player.CombatSpell2) ? Color.Lime : Color.White, Color.Black), () => {
                                    player.CombatViewing = new(player.CombatSpell2);
                                });  
                                string canCast = player.CanCast(player.CombatSpell2);
                                mini.Con.PrintClickable(43, 18, "[" + new ColoredString(19.AsString(), canCast == "" ? Color.Turquoise : Color.Crimson, Color.Black) + new ColoredString("]"), () => { 
                                    if (canCast == "") {
                                        player.CombatCasting = new(player.CombatSpell2); 
                                        player.CombatViewing = new(player.CombatSpell2); 
                                    } else {
                                        GameLoop.WTN.Log.AddMessage("Cannot cast this spell: " + canCast, Color.Crimson);
                                    }
                                });
                                
                                mini.Con.PrintClickable(47, 18, "[" + new ColoredString("X", Color.Crimson, Color.Black) + new ColoredString("]"), () => { player.CombatSpell2 = null; });
                            } else {
                                mini.Con.Print(1, 18, "(empty spell slot)", Color.DarkSlateGray); 
                            }
                            mini.Con.PrintClickable(51, 18, "[" + new ColoredString("+", Color.Lime, Color.Black) + new ColoredString("]"), () => { player.CombatSpell2 = new(player.CombatViewing); });

                            // Spell 3
                            if (player.CombatSpell3 != null) {
                                mini.Con.PrintClickable(1, 19, new ColoredString(player.CombatSpell3.GetName(), player.CombatViewing.Equals(player.CombatSpell3) ? Color.Lime : Color.White, Color.Black), () => {
                                    player.CombatViewing = new(player.CombatSpell3);
                                });  
                                string canCast = player.CanCast(player.CombatSpell3);
                                mini.Con.PrintClickable(43, 19, "[" + new ColoredString(19.AsString(), canCast == "" ? Color.Turquoise : Color.Crimson, Color.Black) + new ColoredString("]"), () => { 
                                    if (canCast == "") {
                                        player.CombatCasting = new(player.CombatSpell3); 
                                        player.CombatViewing = new(player.CombatSpell3); 
                                    } else {
                                        GameLoop.WTN.Log.AddMessage("Cannot cast this spell: " + canCast, Color.Crimson);
                                    }
                                });
                                
                                mini.Con.PrintClickable(47, 19, "[" + new ColoredString("X", Color.Crimson, Color.Black) + new ColoredString("]"), () => { player.CombatSpell3 = null; });
                            } else {
                                mini.Con.Print(1, 19, "(empty spell slot)", Color.DarkSlateGray); 
                            }
                            mini.Con.PrintClickable(51, 19, "[" + new ColoredString("+", Color.Lime, Color.Black) + new ColoredString("]"), () => { player.CombatSpell3 = new(player.CombatViewing); });
                        
                            // Spell 4
                            if (player.CombatSpell4 != null) {
                                mini.Con.PrintClickable(1, 20, new ColoredString(player.CombatSpell4.GetName(), player.CombatViewing.Equals(player.CombatSpell4) ? Color.Lime : Color.White, Color.Black), () => {
                                    player.CombatViewing = new(player.CombatSpell4);
                                });  
                                string canCast = player.CanCast(player.CombatSpell4);
                                mini.Con.PrintClickable(43, 20, "[" + new ColoredString(19.AsString(), canCast == "" ? Color.Turquoise : Color.Crimson, Color.Black) + new ColoredString("]"), () => { 
                                    if (canCast == "") {
                                        player.CombatCasting = new(player.CombatSpell4); 
                                        player.CombatViewing = new(player.CombatSpell4); 
                                    } else {
                                        GameLoop.WTN.Log.AddMessage("Cannot cast this spell: " + canCast, Color.Crimson);
                                    }
                                });
                                
                                mini.Con.PrintClickable(47, 20, "[" + new ColoredString("X", Color.Crimson, Color.Black) + new ColoredString("]"), () => { player.CombatSpell4 = null; });
                            } else {
                                mini.Con.Print(1, 20, "(empty spell slot)", Color.DarkSlateGray); 
                            }
                            mini.Con.PrintClickable(51, 20, "[" + new ColoredString("+", Color.Lime, Color.Black) + new ColoredString("]"), () => { player.CombatSpell4 = new(player.CombatViewing); });
                            
                            // Spell 5
                            if (player.CombatSpell5 != null) {
                                mini.Con.PrintClickable(1, 21, new ColoredString(player.CombatSpell5.GetName(), player.CombatViewing.Equals(player.CombatSpell5) ? Color.Lime : Color.White, Color.Black), () => {
                                    player.CombatViewing = new(player.CombatSpell5);
                                });  
                                string canCast = player.CanCast(player.CombatSpell5);
                                mini.Con.PrintClickable(43, 21, "[" + new ColoredString(19.AsString(), canCast == "" ? Color.Turquoise : Color.Crimson, Color.Black) + new ColoredString("]"), () => { 
                                    if (canCast == "") {
                                        player.CombatCasting = new(player.CombatSpell5); 
                                        player.CombatViewing = new(player.CombatSpell5); 
                                    } else {
                                        GameLoop.WTN.Log.AddMessage("Cannot cast this spell: " + canCast, Color.Crimson);
                                    }
                                });
                                
                                mini.Con.PrintClickable(47, 21, "[" + new ColoredString("X", Color.Crimson, Color.Black) + new ColoredString("]"), () => { player.CombatSpell5 = null; });
                            } else {
                                mini.Con.Print(1, 21, "(empty spell slot)", Color.DarkSlateGray); 
                            }
                            mini.Con.PrintClickable(51, 21, "[" + new ColoredString("+", Color.Lime, Color.Black) + new ColoredString("]"), () => { player.CombatSpell5 = new(player.CombatViewing); });
                        }
                        mini.Con.DrawLine(new Point(0, 22), new Point(54, 22), 196);

                        mini.Con.Print(1, 23, "AutoName: " + player.CombatViewing.GetName(true)); 
                        mini.Con.PrintStringField(1, 24, "Set Name: ", ref player.CombatViewing.Name, ref TypingField, "combatViewName");

                        mini.Con.Print(1, 26, "    Element: "); 
                        mini.Con.PrintClickable(14, 26, new ColoredString("Metal", player.CombatViewing.Element == "Metal" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Element = "Metal"; });
                        mini.Con.PrintClickable(22, 26, new ColoredString("Water", player.CombatViewing.Element == "Water" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Element = "Water"; });
                        mini.Con.PrintClickable(30, 26, new ColoredString("Wood", player.CombatViewing.Element == "Wood" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Element = "Wood"; });
                        mini.Con.PrintClickable(38, 26, new ColoredString("Fire", player.CombatViewing.Element == "Fire" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Element = "Fire"; });
                        mini.Con.PrintClickable(46, 26, new ColoredString("Earth", player.CombatViewing.Element == "Earth" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Element = "Earth"; });

                        mini.Con.Print(1, 27, "Damage Type: "); 
                        mini.Con.PrintClickable(14, 27, new ColoredString("Bolt", player.CombatViewing.DamageType == "Bolt" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.DamageType = "Bolt"; });
                        mini.Con.PrintClickable(22, 27, new ColoredString("Ray", player.CombatViewing.DamageType == "Ray" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.DamageType = "Ray"; });
                        mini.Con.PrintClickable(30, 27, new ColoredString("Wave", player.CombatViewing.DamageType == "Wave" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.DamageType = "Wave"; });
                        
                        mini.Con.Print(1, 28, " Cast Speed: "); 
                        mini.Con.PrintClickable(14, 28, new ColoredString("Slower", player.CombatViewing.Speed == 1.5 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Speed = 1.5; });
                        mini.Con.PrintClickable(22, 28, new ColoredString("Slow", player.CombatViewing.Speed == 1.25 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Speed = 1.25; });
                        mini.Con.PrintClickable(30, 28, new ColoredString("Medium", player.CombatViewing.Speed ==  1.0 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Speed = 1.0; });
                        mini.Con.PrintClickable(38, 28, new ColoredString("Fast", player.CombatViewing.Speed == 1.25 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Speed = 1.25; });
                        mini.Con.PrintClickable(46, 28, new ColoredString("Faster", player.CombatViewing.Speed == 1.5 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { player.CombatViewing.Speed = 1.5; });
                        
                        mini.Con.PrintClickable(1, 29, "Empowered " + Helper.Checkmark(player.CombatViewing.Empowered), () => { player.CombatViewing.Empowered.Flip(); });
                        mini.Con.PrintClickable(13, 29, new ColoredString("?", Color.MediumPurple, Color.Black), () => { GameLoop.WTN.Log.AddMessage("Spell damage +25%. Spell costs (tier / 2) elemental talismans complementary to main element. ", Color.Yellow); });
                        mini.Con.PrintClickableBool(19, 29, "Lingering ", ref player.CombatViewing.Lingering);
                        mini.Con.PrintClickable(31, 29, new ColoredString("?", Color.MediumPurple, Color.Black), () => { GameLoop.WTN.Log.AddMessage("A successful hit set bleed to " + player.CombatViewing.Tier + ", dealing that much damage and then reducing by 1 each second. Spell costs 50% more Destruction talismans.", Color.Yellow); });
                        mini.Con.PrintClickableBool(37, 29, "Vampiric ", ref player.CombatViewing.Vampiric);
                        mini.Con.PrintClickable(49, 29, new ColoredString("?", Color.MediumPurple, Color.Black), () => { GameLoop.WTN.Log.AddMessage("Heal for 10% of damage dealt, rounded to nearest whole number (minimum 0). Spell costs (tier / 2) Restoration talismans.", Color.Yellow); });

                        mini.Con.Print(1, 31, "Tier: "); 
                        mini.Con.PrintClickable(7, 31, new ColoredString("I", player.CombatViewing.Tier == 1 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 1) { player.CombatViewing.Tier = 1; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 1 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(9, 31, new ColoredString("II", player.CombatViewing.Tier == 2 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 10) { player.CombatViewing.Tier = 2; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 10 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(12, 31, new ColoredString("III", player.CombatViewing.Tier == 3 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 20) { player.CombatViewing.Tier = 3; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 20 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(16, 31, new ColoredString("IV", player.CombatViewing.Tier == 4 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 30) { player.CombatViewing.Tier = 4; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 30 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(19, 31, new ColoredString("V", player.CombatViewing.Tier == 5 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 40) { player.CombatViewing.Tier = 5; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 40 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(21, 31, new ColoredString("VI", player.CombatViewing.Tier == 6 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 50) { player.CombatViewing.Tier = 6; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 50 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(24, 31, new ColoredString("VII", player.CombatViewing.Tier == 7 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 60) { player.CombatViewing.Tier = 7; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 60 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(28, 31, new ColoredString("VIII", player.CombatViewing.Tier == 8 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 70) { player.CombatViewing.Tier = 8; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 70 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(33, 31, new ColoredString("IX", player.CombatViewing.Tier == 9 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 80) { player.CombatViewing.Tier = 9; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 80 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(36, 31, new ColoredString("X", player.CombatViewing.Tier == 10 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 90) { player.CombatViewing.Tier = 10; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 90 or higher to use that tier.", Color.Crimson); }
                        });
                        mini.Con.PrintClickable(38, 31, new ColoredString("XI", player.CombatViewing.Tier == 11 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                            if (player.GetEffectiveSkillLevel("Magic") >= 100) { player.CombatViewing.Tier = 11; }
                            else { GameLoop.WTN.Log.AddMessage("Must have an effective Magic level of 100 or higher to use that tier.", Color.Crimson); }
                        });

                        List<string> talismans = player.CombatViewing.Talismans();
                        string build = ""; 
                        foreach (var tali in talismans) {
                            string[] split = tali.Split(",");
                            build += (tali == talismans[0] ? "" : ", ") + split[1] + "x " + split[0].Replace("talisman", "");
                        }
                        mini.Con.Print(1, 33, "Talisman Cost: ");
                        mini.Con.Print(1, 34, build);

                        mini.Con.Print(23, 33, "Theoretical Max Damage  : " + player.MaxDamage(true));
                        mini.Con.PrintClickable(46, 33, new ColoredString("?", Color.MediumPurple, Color.Black), () => { GameLoop.WTN.Log.AddMessage("Magic damage is based on spell tier and Magic level, but spell tier is capped by the tier of your equipped weapon.", Color.Yellow); });
                    } else {
                        List<Spell> spells = new();

                        foreach (var kv in GameLoop.WTN.SpellLibrary) {
                            if (kv.Value.Book == player.MagicBook && kv.Value.Category == MagicTab) {
                                spells.Add(kv.Value);
                            }
                        }

                        for (int i = 0; i < spells.Count; i++) {
                            string cast = player.CanCast(spells[i]);

                            mini.Con.PrintClickable(6, 17 + i, new ColoredString(spells[i].Name, cast.Contains("cooldown") ? Color.Yellow : cast.Contains("Magic") ? Color.DarkSlateGray : cast != "" ? Color.Crimson : Color.White, Color.Black), () => { 
                                if (cast == "") {
                                    if (MagicTab == "Tele") {
                                        if (spells[i].ID != "teleHome") {
                                            spells[i].Cast(player, GameLoop.WTN.Log, RecentlyTrainedSkills);
                                        }

                                        foreach (var act in spells[i].CastActions) {
                                            act.Execute();
                                        }
                                    }

                                    if (MagicTab == "Utility") {
                                        if (spells[i].ID == "utilBonesBananas" || spells[i].ID == "utilBonesPeaches" || spells[i].ID == "utilSuperheat" || spells[i].ID.Contains("utilEnchant")) {
                                            foreach (var act in spells[i].CastActions) {
                                                act.Execute();
                                            } 
                                        }

                                        if (spells[i].ID == "utilAlchemyLow") {   
                                            GameLoop.WTN.Log.AddMessage("Cast this by clicking the ~ icon on an item line in your inventory.", Color.Crimson); 
                                        }

                                        if (spells[i].ID == "utilAlchemyHigh") {   
                                            GameLoop.WTN.Log.AddMessage("Cast this by clicking the " + 247.AsString() + " icon on an item line in your inventory.", Color.Crimson); 
                                        }
                                    }
                                } else {
                                    GameLoop.WTN.Log.AddMessage(new ColoredString("Cannot cast spell: " + cast, Color.Crimson, Color.Black));
                                }
                            });

                            mini.Con.Print(1, 17+i, spells[i].Level.ToString().Align(HorizontalAlignment.Right, 2));
                            mini.Con.PrintClickable(4, 17+i, new ColoredString("?", Color.MediumPurple, Color.Black), () => { GameLoop.WTN.Log.AddMessage(spells[i].Description); });
                        }
                    }
                } else if (SidebarMenu == "Log") {
                    mini.Con.Print(1, 15, "Clue Collection Logs");

                    if (!player.CollectionLogClues.ContainsKey("casketTutorial")) {
                        player.CollectionLogClues.Add("casketTutorial", new("casketTutorial"));
                    }

                    if (player.CollectionLogClues.TryGetValue("casketTutorial", out CollectionLogEntry? tutLog) && tutLog != null)
                        mini.Con.PrintClickable(1, 16, new ColoredString("| Tutorial: " + tutLog.ActualObtained().ToString().Align(HorizontalAlignment.Right, 3) + " / " + tutLog.TryFindTotal().ToString().Align(HorizontalAlignment.Right, 3), tutLog.LogComplete() ? Color.Lime : Color.White, Color.Black), () => { ExtraWindows.CollectionID = "casketTutorial"; ExtraWindows.CollectionLog.IsVisible = true; ExtraWindows.CollectionDropTop = 0; ExtraWindows.CollectionCat = "Clue"; });
                    else 
                        mini.Con.Print(1, 16, "| Tutorial: ");

                    if (!player.CollectionLogClues.ContainsKey("casketBeginner")) {
                        player.CollectionLogClues.Add("casketBeginner", new("casketBeginner"));
                    }

                    if (player.CollectionLogClues.TryGetValue("casketBeginner", out CollectionLogEntry? begLog) && begLog != null)
                        mini.Con.PrintClickable(1, 17, new ColoredString("| Beginner: " + begLog.ActualObtained().ToString().Align(HorizontalAlignment.Right, 3) + " / " + begLog.TryFindTotal().ToString().Align(HorizontalAlignment.Right, 3), begLog.LogComplete() ? Color.Lime : Color.White, Color.Black), () => { ExtraWindows.CollectionID = "casketBeginner"; ExtraWindows.CollectionLog.IsVisible = true; ExtraWindows.CollectionDropTop = 0; ExtraWindows.CollectionCat = "Clue"; });
                    else 
                        mini.Con.Print(1, 17, "| Beginner: ");

                    if (!player.CollectionLogClues.ContainsKey("casketEasy")) {
                        player.CollectionLogClues.Add("casketEasy", new("casketEasy"));
                    }

                    if (player.CollectionLogClues.TryGetValue("casketEasy", out CollectionLogEntry? easyLog) && easyLog != null)
                        mini.Con.PrintClickable(1, 18, new ColoredString("|     Easy: " + easyLog.ActualObtained().ToString().Align(HorizontalAlignment.Right, 3) + " / " + easyLog.TryFindTotal().ToString().Align(HorizontalAlignment.Right, 3), easyLog.LogComplete() ? Color.Lime : Color.White, Color.Black), () => { ExtraWindows.CollectionID = "casketEasy"; ExtraWindows.CollectionLog.IsVisible = true; ExtraWindows.CollectionDropTop = 0; ExtraWindows.CollectionCat = "Clue"; });
                    else 
                        mini.Con.Print(1, 18, "|     Easy: ");
                     
                    if (!player.CollectionLogClues.ContainsKey("casketMedium")) {
                        player.CollectionLogClues.Add("casketMedium", new("casketMedium"));
                    }

                    if (player.CollectionLogClues.TryGetValue("casketMedium", out CollectionLogEntry? mediumLog) && mediumLog != null)
                        mini.Con.PrintClickable(1, 19, new ColoredString("|   Medium: " + mediumLog.ActualObtained().ToString().Align(HorizontalAlignment.Right, 3) + " / " + mediumLog.TryFindTotal().ToString().Align(HorizontalAlignment.Right, 3), mediumLog.LogComplete() ? Color.Lime : Color.White, Color.Black), () => { ExtraWindows.CollectionID = "casketMedium"; ExtraWindows.CollectionLog.IsVisible = true; ExtraWindows.CollectionDropTop = 0; ExtraWindows.CollectionCat = "Clue"; });
                    else 
                        mini.Con.Print(1, 19, "|   Medium: ");
                     
                    mini.Con.Print(1, 20, "|     Hard: ");
                    mini.Con.Print(1, 21, "|    Elite: ");
                    mini.Con.Print(1, 22, "|   Master: ");

                    if (!player.CollectionLogClues.ContainsKey("General")) {
                        player.CollectionLogClues.Add("General", new("General"));
                    }

                    if (player.CollectionLogClues.TryGetValue("General", out CollectionLogEntry? genLog) && genLog != null)
                        mini.Con.PrintClickable(1, 23, new ColoredString("|  General: " + genLog.ActualObtained().ToString().Align(HorizontalAlignment.Right, 3) + " / " + genLog.TryFindTotal().ToString().Align(HorizontalAlignment.Right, 3), genLog.LogComplete() ? Color.Lime : Color.White, Color.Black), () => { ExtraWindows.CollectionID = "General"; ExtraWindows.CollectionLog.IsVisible = true; ExtraWindows.CollectionDropTop = 0; ExtraWindows.CollectionCat = "Clue"; });
                    else 
                        mini.Con.Print(1, 23, "|  General: ");
                } else if (SidebarMenu == "Potions") {
                    mini.Con.Print(1, 15, "Active Potion Effects", Color.White);
                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    int qty = 1;
                    if (Helper.EitherShift())
                        qty *= 5;
                    if (Helper.EitherControl())
                        qty *= 10;

                    if (player.ActivePotions.Count > 18) {
                        if (Helper.ScrolledUp()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop - qty, 0, player.ActivePotions.Count - 18); }
                        if (Helper.ScrolledDown()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop + qty, 0, player.ActivePotions.Count - 18); }
                    } else {
                        SidebarScrollTop = 0;
                    }
                    
                    int printY = 17;
                    if (player.ActivePotions.Count > 0) { 
                        for (int pot = SidebarScrollTop; pot < player.ActivePotions.Count && pot < SidebarScrollTop + 18; pot++) {
                            Color col = player.ActivePotions[pot].Change > 0 ? Color.Green : Color.Crimson;
                            if (mousePos.Y == printY && mousePos.X < 55) {
                                col = col.GetDark();
                            }

                            mini.Con.Print(1, printY++, new ColoredString("| ") + new ColoredString(player.ActivePotions[pot].Stat.Align(HorizontalAlignment.Left, 45) + " (" + ((player.ActivePotions[pot].Change > 0 ? "+" : "") + player.ActivePotions[pot].Change).ToString().Align(HorizontalAlignment.Right, 3) + ")", col, Color.Black));
                        }
                    } else {
                        mini.Con.Print(1, printY++, "(no active potion effects)", Color.DarkSlateGray);
                    }
                }
                else if (SidebarMenu == "Music") { 
                    mini.Con.PrintClickable(1, 15, new ColoredString("Auto", player.MusicMode == "Auto" ? Color.Yellow : Color.White, Color.Black), () => {
                        player.MusicMode = "Auto";
                        GameLoop.SoundManager.CurrentSong = "";
                        GameLoop.SoundManager.music.StopAllSounds();
                    });

                    mini.Con.PrintClickable(6, 15, new ColoredString("Shuffle UPC", player.MusicMode == "Shuffle UPC" ? Color.Yellow : Color.White, Color.Black), () => {
                        GameLoop.SoundManager.music.StopAllSounds();
                        player.MusicMode = "Shuffle UPC";
                        GameLoop.SoundManager.CurrentSong = "";
                        GameLoop.SoundManager.music.StopAllSounds();
                        GameLoop.SoundManager.PickMusic();
                    });
                     
                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196);

                    List<KeyValuePair<string, IrrKlang.ISoundSource>> songs = GameLoop.SoundManager.Songs.OrderBy(o => o.Key).ToList();

                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }

                    int songListLength = 18;
                    
                    if (songs.Count > songListLength) {
                        if (Helper.ScrolledUp()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop - qty, 0, songs.Count - songListLength); }
                        if (Helper.ScrolledDown()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop + qty, 0, songs.Count - songListLength); }
                    } else {
                        SidebarScrollTop = 0;
                    }


                    for (int i = SidebarScrollTop; i < songs.Count && i < SidebarScrollTop + songListLength; i++) {
                        bool songUnlocked = player.UnlockedSongs.Contains(songs[i].Key) || player.AllSongsUnlocked;
                        mini.Con.PrintClickable(1, 17 + (i - SidebarScrollTop), new ColoredString(songs[i].Key, GameLoop.SoundManager.CurrentSong == songs[i].Key ? Color.Green : songUnlocked ? Color.White : Color.DarkSlateGray, Color.Black), () => {
                            if (songUnlocked) {
                                player.MusicMode = "Shuffle UPC";
                                GameLoop.SoundManager.CurrentSong = "";
                                GameLoop.SoundManager.music.StopAllSounds();
                                GameLoop.SoundManager.PickMusic(songs[i].Key);
                            }
                        });
                    }
                } else if (SidebarMenu == "Prayer") {
                    mini.Con.Print(7, 15, "Prayer Name", Color.White);
                    mini.Con.Print(1, 15, "Lvl", Color.White);

                    mini.Con.PrintClickable(47, 15, new ColoredString("ALL OFF", Color.Crimson, Color.Black), () => {
                        player.ActivePrayers.Clear();
                    }); 
                     
                    mini.Con.DrawLine(new Point(0, 16), new Point(54, 16), 196); 

                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }

                    int prayerLength = 18;

                    List<Prayer> prayers = GameLoop.WTN.PrayerLibrary.Values.ToList();
                    
                    if (prayers.Count > prayerLength) {
                        if (Helper.ScrolledUp()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop - qty, 0, prayers.Count - prayerLength); }
                        if (Helper.ScrolledDown()) { SidebarScrollTop = Math.Clamp(SidebarScrollTop + qty, 0, prayers.Count - prayerLength); }
                    } else {
                        SidebarScrollTop = 0;
                    }


                    for (int i = SidebarScrollTop; i < prayers.Count && i < SidebarScrollTop + prayerLength; i++) {
                        bool alreadyOn = player.ActivePrayers.Contains(prayers[i].Name);
                        int pLevel = player.GetEffectiveSkillLevel("Prayer");
                        bool hasLevel = pLevel >= prayers[i].Level;
                        
                        mini.Con.Print(1, 17 + (i - SidebarScrollTop), prayers[i].Level.ToString().Align(HorizontalAlignment.Right, 3), Color.White);

                        mini.Con.PrintClickable(5, 17 + (i - SidebarScrollTop), new ColoredString("?", Color.MediumPurple, Color.Black), () => {
                            GameLoop.WTN.Log.AddMessage(prayers[i].Description + " (Level " + prayers[i].Level + ")", Color.Yellow);
                        });

                        mini.Con.PrintClickable(7, 17 + (i - SidebarScrollTop), new ColoredString(prayers[i].Name, alreadyOn ? Color.Lime : hasLevel ? Color.White : Color.DarkSlateGray, Color.Black), () => {
                            if (hasLevel) {
                                if (player.CurrentPrayer > 0) {
                                    if (player.ActivePrayers.Contains(prayers[i].Name)) { 
                                        player.ActivePrayers.Remove(prayers[i].Name);
                                    } else {
                                        if (prayers[i].ConflictsWith.Count > 0) {
                                            foreach (var str in prayers[i].ConflictsWith) {
                                                player.ActivePrayers.Remove(str);
                                            }
                                        }

                                        player.ActivePrayers.Add(prayers[i].Name);
                                    }
                                } else {
                                    GameLoop.WTN.Log.AddMessage("No prayer points remaining. Refill by praying at an altar or by using potions.", Color.Crimson);
                                }
                            } else { 
                                GameLoop.WTN.Log.AddMessage("Need level " + prayers[i].Level + " Prayer to use that. (Have " + pLevel + ")", Color.Crimson);
                            }
                        }); 
                        
                        //mini.Con.DrawLine(new(3, 17 + (i - SidebarScrollTop)), new(54, 17 + (i - SidebarScrollTop)), '-', Color.DarkSlateGray);
                    }
                }
            } 
        }

    }
}
