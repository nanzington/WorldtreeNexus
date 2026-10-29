using Troschuetz.Random;
using WorldtreeNexus.DataTypes;
using Key = SadConsole.Input.Keys;

namespace WorldtreeNexus.Managers {
    public static class ItemUseLogic {
        public static int UsingSlot = -1;

        public static bool UseItem(ItemWrapper itemWrap, Player player) {
            if (itemWrap.GetRef() is Item item) { 
                if (item.UseString == "GetGold") {
                    player.GiveGold(item.UseInt); 
                    GameLoop.WTN.Log.AddMessage("You open the " + item.Name + " and find " + item.UseInt + " gold pieces.");
                } else if (item.UseString == "Heal") {
                    player.CurrentHP = Math.Clamp(player.CurrentHP + item.UseInt, player.CurrentHP, player.Skills["Hitpoints"].Level);
                    GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the " + item.Name.ToLowerInvariant() + " and recover some Hitpoints.", Color.Goldenrod, Color.Black));

                    if (item.Potion != null) {
                        for (int i = 0; i < item.Potion.Count; i++) {
                            player.TryAddPotionEffect(item.Potion[i].Stat, item.Potion[i].Change + (item.Potion[i].Change > 0 ? player.CurrentRestedBuff : 0));
                        } 
                    }
                }  else if (item.UseString == "Hurt") {
                    player.CurrentHP = Math.Clamp(player.CurrentHP - item.UseInt, 0, player.CurrentHP);
                    GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the " + item.Name.ToLowerInvariant() + ". It tastes... painful. You lose " + item.UseInt + " health.", Color.Goldenrod, Color.Black));

                    if (item.Potion != null) {
                        for (int i = 0; i < item.Potion.Count; i++) {
                            player.TryAddPotionEffect(item.Potion[i].Stat, item.Potion[i].Change + (item.Potion[i].Change > 0 ? player.CurrentRestedBuff : 0));
                        } 
                    }
                } else if (item.UseString == "Kebab") {
                    int num = GameLoop.rand.Next(32) + 1;
                    if (num == 1) { 
                        player.CurrentHP = Math.Clamp(player.CurrentHP + 7, player.CurrentHP, player.Skills["Hitpoints"].Level);
                        player.TryAddPotionEffect("Attack", 2);
                        player.TryAddPotionEffect("Strength", 2);
                        player.TryAddPotionEffect("Defense", 2);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. Wow, that was an amazing kebab! You feel really invigorated.", Color.Lime, Color.Black));
                    } else if (num <= 9) {
                        player.CurrentHP = Math.Clamp(player.CurrentHP + 6, player.CurrentHP, player.Skills["Hitpoints"].Level);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. That was a good kebab. You feel a lot better.", Color.Green, Color.Black));
                    } else if (num <= 29) {
                        player.CurrentHP = Math.Clamp(player.CurrentHP + 3, player.CurrentHP, player.Skills["Hitpoints"].Level);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. It heals some health.", Color.Green, Color.Black));
                    } else if (num <= 30) {
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. That kebab didn't seem to do a lot.", Color.Yellow, Color.Black));
                    } else if (num <= 31) { 
                        string randSkill = player.Skills.Keys.ToList()[GameLoop.rand.Next(player.Skills.Count)];
                        while (randSkill == "Hitpoints") { 
                            randSkill = player.Skills.Keys.ToList()[GameLoop.rand.Next(player.Skills.Count)];
                        }
                        player.TryAddPotionEffect(randSkill, -3);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. That tasted a bit dodgy. You feel a bit ill.", Color.Crimson, Color.Black));
                        GameLoop.WTN.Log.AddMessage(new ColoredString("Eating the kebab has damaged your " + randSkill + " stat.", Color.Crimson, Color.Black));
                    } else if (num <= 32) {
                        string randSkill = player.Skills.Keys.ToList()[GameLoop.rand.Next(player.Skills.Count)];
                        while (randSkill == "Hitpoints") { 
                            randSkill = player.Skills.Keys.ToList()[GameLoop.rand.Next(player.Skills.Count)];
                        }
                        player.TryAddPotionEffect(randSkill, -4);
                        player.TryAddPotionEffect("Attack", -3);
                        player.TryAddPotionEffect("Strength", -3);
                        player.TryAddPotionEffect("Defense", -3);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You eat the kebab. That tasted very dodgy. You feel very ill.", Color.Crimson, Color.Black));
                        GameLoop.WTN.Log.AddMessage(new ColoredString("Eating the kebab has done damage to some of your stats.", Color.Crimson, Color.Black));
                    }
                } else if (item.UseString == "FillPot") {
                    if (GameLoop.WTN.ItemLibrary.TryGetValue("plantPot", out Item? filledPot) && filledPot != null) {
                        player.TryPickup(filledPot, 1);
                    } else {
                        return false;
                    }
                } else if (item.UseString == "TeleSpawn") {
                    player.NavLoc = player.NavRespawn;
                    itemWrap.Charges -= 1;

                    if (itemWrap.Charges <= 0) { 
                        GameLoop.WTN.Log.AddMessage(new ColoredString("Your ring of returning runs out of charge and shatters.", Color.Crimson, Color.Black));
                        return true;
                    } else {
                        return false;
                    }
                } else if (item.UseString == "TeleportMenuCost") {
                    ExtraWindows.Teleport.IsVisible = true;
                    ExtraWindows.TeleWrap = itemWrap;
                    ExtraWindows.TeleFairyRing = false;
                    ExtraWindows.TeleCostsCharges = true;
                    ExtraWindows.TeleportDests = item.TeleportLocations;
                    return false;
                } else if (item.UseString == "Compost") {
                    if (GameLoop.WTN.Atlas.ContainsKey(player.NavLoc)) {
                        Location curr = GameLoop.WTN.Atlas[player.NavLoc];

                        bool foundPlantSpot = false;

                        for (int i = 0; i < curr.FarmingPatchesHere.Count; i++) {
                            if (player.FarmingPatches.ContainsKey(curr.FarmingPatchesHere[i])) {
                                FarmingPatch patch = player.FarmingPatches[curr.FarmingPatchesHere[i]];

                                if (patch.SeedPlanted != "" && patch.Compost < item.UseInt) {
                                    patch.Compost = item.UseInt;
                                    foundPlantSpot = true;
                                    GameLoop.WTN.Log.AddMessage(new ColoredString("Applied compost to a patch growing " + GameLoop.WTN.ResolveItemName(patch.SeedPlanted) + ".", Color.Crimson, Color.Black));
                                    break;
                                }
                            }
                        }

                        if (!foundPlantSpot) {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("No patches here that need compost.", Color.Crimson, Color.Black));
                            return false;
                        }
                    }
                } else if (item.UseString == "PlantSeed") {
                    if (GameLoop.WTN.Atlas.ContainsKey(player.NavLoc)) {
                        Location curr = GameLoop.WTN.Atlas[player.NavLoc];

                        bool foundPlantSpot = false;

                        for (int i = 0; i < curr.FarmingPatchesHere.Count; i++) {
                            if (player.FarmingPatches.ContainsKey(curr.FarmingPatchesHere[i])) {
                                FarmingPatch patch = player.FarmingPatches[curr.FarmingPatchesHere[i]];

                                if (patch.PatchType == item.UseString2 && patch.SeedPlanted == "") {
                                    if (player.Skills["Farming"].Level >= item.UseInt) {
                                        patch.SeedPlanted = item.ID;
                                        patch.TimeLeft = item.UseInt3;
                                        patch.RegrowTime = item.UseInt4;
                                        foundPlantSpot = true;
                                        GameLoop.WTN.Log.AddMessage(new ColoredString("You plant the " + item.Name.ToLowerInvariant() + ".", Color.Goldenrod, Color.Black));

                                        if (player.Equipment.TryGetValue("Amulet", out ItemWrapper? eqp) && eqp != null && eqp.ID == "amuletBounty" && GameLoop.rand.Next(4) == 0) {
                                            eqp.Charges -= 1; 
                                            GameLoop.WTN.Log.AddMessage(new ColoredString("Your amulet of bounty saves you a seed!", Color.AntiqueWhite, Color.Black));

                                            if (eqp.Charges <= 0) { 
                                                GameLoop.WTN.Log.AddMessage(new ColoredString("Your amulet of bounty runs out of charge and shatters.", Color.Crimson, Color.Black));
                                                player.Equipment.Remove("Amulet");
                                            }
                                            return false;
                                        }

                                        if (item.Name.Contains("Plant pot")) {
                                            if (GameLoop.WTN.ItemLibrary.TryGetValue("plantPotEmpty", out Item? newPot) && newPot != null) {
                                                player.TryPickup(newPot, 1);
                                            }
                                        }
                                    } else {
                                        GameLoop.WTN.Log.AddMessage(new ColoredString("You need " + item.UseInt + " Farming to plant that.", Color.Crimson, Color.Black));
                                        return false;
                                    }
                                    break;
                                }
                            }
                        }
                    
                        if (!foundPlantSpot) {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("No " + item.UseString2.ToLowerInvariant() + " patches here to plant that.", Color.Crimson, Color.Black));
                            return false;
                        }
                    } else {
                        return false;
                    }
                } else if (item.UseString == "Dig") {
                    ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Dig");
                    ClueLogic.GenericStep(player, GameLoop.WTN.Log, "Map");
                    ClueLogic.GenericStep(player, GameLoop.WTN.Log, "HotCold");

                    if (GameLoop.WTN.Atlas.TryGetValue(player.NavLoc, out Location? curr) && curr != null && curr.DigItem != "") { 
                        if (curr.LastDigTime + (curr.DigCooldown * 1000) < Helper.Time() || curr.LastDigTime == 0) { 
                            if (GameLoop.WTN.ResolveItem(curr.DigItem) is Item dug) { 
                                curr.LastDigTime = Helper.Time();
                                player.TryPickup(dug, dug.Quantity);
                                if (!player.ItemsEverObtained.Contains(dug.ID)) { player.ItemsEverObtained.Add(dug.ID); } 
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You already dug up an item here recently. (" + curr.DigCooldown + " second cooldown)", Color.Crimson, Color.Black));
                        }
                    }
                } else if (item.UseString == "ClueTutorial") {
                    ClueLogic.SetOrShowStep("Tutorial", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueBeginner") {
                    ClueLogic.SetOrShowStep("Beginner", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueEasy") {
                    ClueLogic.SetOrShowStep("Easy", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueMedium") {
                    ClueLogic.SetOrShowStep("Medium", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueHard") {
                    ClueLogic.SetOrShowStep("Hard", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueElite") {
                    ClueLogic.SetOrShowStep("Elite", player, GameLoop.WTN.Log);
                } else if (item.UseString == "ClueMaster") {
                    ClueLogic.SetOrShowStep("Master", player, GameLoop.WTN.Log);
                } else if (item.UseString == "Casket") {
                    List<ItemDrop> rolledItems = new();
                    List<ItemDrop> guaranteedItems = new();
                     
                    if (!player.CollectionLogClues.ContainsKey(item.ID))
                        player.CollectionLogClues.Add(item.ID, new(item.ID)); 
                    player.CollectionLogClues[item.ID].KillCount += 1;

                    while (rolledItems.Count < 5) {
                        for (int j = 0; j < item.DropTable.Count; j++) {
                            ItemDrop drop = item.DropTable[j]; 
                            CollectionLogEntry log = player.CollectionLogClues[drop.AltLog != "" ? drop.AltLog : item.ID];

                            log.DropsObtained.TryGetValue(drop.ItemID, out int prevObtained);
                            Item? rolled = drop.RollDrop(player, log, false, true);

                            if (rolled != null) {
                                if (player.DropModifier == 1 && prevObtained == 0 && log.KillCount >= (int) Math.Ceiling(drop.InY / (double) (drop.DropX * player.DropMultiplier)) && !guaranteedItems.Contains(drop) && !rolledItems.Contains(drop)) { // Didn't have drop before, have drop now, at drop rate, probably dry protection
                                    guaranteedItems.Add(drop);
                                } else if (player.DropModifier == 2) { // If it's on No RNG Drops the drops should only ever come back not null 
                                    guaranteedItems.Add(drop);
                                } else {
                                    rolledItems.Add(drop);
                                }
                            }
                        }

                        if (player.DropModifier == 2) // No RNG Drops will never reach 5 items rolled so just break out after one check
                            break;
                    }

                    rolledItems.Shuffle();
                 
                
                    GameLoop.WTN.Log.AddMessage(new ColoredString("You open the casket...", Color.Green, Color.Black));
                    for (int i = 0; i < 5; i++) {
                        if (i < rolledItems.Count) {
                            guaranteedItems.Remove(rolledItems[i]);
                            if (GameLoop.WTN.ItemLibrary.TryGetValue(rolledItems[i].ItemID, out Item? rolled) && rolled != null) {
                                Item spawn = new(rolled);

                                if (rolledItems[i].QuantityMin == rolledItems[i].QuantityMax) { spawn.Quantity = rolledItems[i].QuantityMin; } 
                                else { spawn.Quantity = GameLoop.rand.Next(rolledItems[i].QuantityMax - rolledItems[i].QuantityMin) + rolledItems[i].QuantityMin; }  

                                bool newToLog = false;
                                if (rolledItems[i].AltLog == "") {
                                    player.CollectionLogClues[item.ID].DropsObtained[rolledItems[i].ItemID] += 1;
                                } else {
                                    if (player.CollectionLogClues.TryGetValue(rolledItems[i].AltLog, out CollectionLogEntry? log) && log != null) {
                                        log.DropsObtained[rolledItems[i].ItemID] += 1;
                                        if (log.DropsObtained[rolledItems[i].ItemID] == 1) { newToLog = true; }
                                    }
                                }

                                Color excitement = Color.Goldenrod;
                                if (rolledItems[i].InY >= 100) { excitement = Color.Green; }
                                if (rolledItems[i].InY >= 1000) { excitement = Color.Lime; }
                                
                                string name = (spawn.Quantity > 1 ? spawn.Quantity + "x " : "") + spawn.Name + (spawn.Quantity > 1 && spawn.Name[^1] != 's' ? "s" : "");

                                GameLoop.WTN.Log.AddMessage(new ColoredString("The casket had " + name + " in it!" + (newToLog ? " (new!)" : ""), excitement, Color.Black));
                                player.TryPickup(spawn, spawn.Quantity); 
                                if (!player.ItemsEverObtained.Contains(spawn.ID)) { player.ItemsEverObtained.Add(spawn.ID); }
                            }
                        } else { 
                            player.GiveGold(item.UseInt);
                            GameLoop.WTN.Log.AddMessage(new ColoredString("The casket had " + item.UseInt + " gold pieces in it.", Color.DarkGoldenrod, Color.Black));
                        }
                    }

                    
                    
                    if (guaranteedItems.Count > 0) {
                        GameLoop.WTN.Log.AddMessage(new ColoredString("Due to Dry Protection it also has:", Color.Green, Color.Black));
                        for (int i = 0; i < guaranteedItems.Count; i++) { 
                           if (GameLoop.WTN.ItemLibrary.TryGetValue(guaranteedItems[i].ItemID, out Item? rolled) && rolled != null) {
                                Item spawn = new(rolled);

                                if (guaranteedItems[i].QuantityMin == guaranteedItems[i].QuantityMax) { spawn.Quantity = guaranteedItems[i].QuantityMin; } 
                                else { spawn.Quantity = GameLoop.rand.Next(guaranteedItems[i].QuantityMax - guaranteedItems[i].QuantityMin) + guaranteedItems[i].QuantityMin; }  

                                bool newToLog = false;
                                if (guaranteedItems[i].AltLog == "") {
                                    player.CollectionLogClues[item.ID].DropsObtained[guaranteedItems[i].ItemID] += 1;
                                } else {
                                    if (player.CollectionLogClues.TryGetValue(guaranteedItems[i].AltLog, out CollectionLogEntry? log) && log != null) {
                                        log.DropsObtained[guaranteedItems[i].ItemID] += 1;
                                        if (log.DropsObtained[guaranteedItems[i].ItemID] == 1) { newToLog = true; }
                                    }
                                }

                                Color excitement = Color.Goldenrod;
                                if (guaranteedItems[i].InY >= 100) { excitement = Color.Green; }
                                if (guaranteedItems[i].InY >= 1000) { excitement = Color.Lime; }

                                string name = (spawn.Quantity > 1 ? spawn.Quantity + "x " : "") + spawn.Name + (spawn.Quantity > 1 && spawn.Name[^1] != 's' ? "s" : "");

                                GameLoop.WTN.Log.AddMessage(new ColoredString("The casket had " + name + " in it!" + (newToLog ? " (new!)" : ""), excitement, Color.Black));
                                player.TryPickup(spawn, spawn.Quantity);
                                if (!player.ItemsEverObtained.Contains(spawn.ID)) { player.ItemsEverObtained.Add(spawn.ID); } 
                            }
                        }
                    }
                } else if (item.UseString == "Needle") {
                    ExtraWindows.CraftingMenu.IsVisible = true;
                    ExtraWindows.CraftingMaxLevel = 99;
                    ExtraWindows.CraftingType = "Needle";
                } else if (item.UseString == "Knife") {
                    ExtraWindows.CraftingMenu.IsVisible = true;
                    ExtraWindows.CraftingMaxLevel = 99;
                    ExtraWindows.CraftingType = "Knife";
                }  else if (item.UseString == "Baking") {
                    ExtraWindows.CraftingMenu.IsVisible = true;
                    ExtraWindows.CraftingMaxLevel = 99;
                    ExtraWindows.CraftingType = "Baking";
                } else if (item.UseString == "Glassblowing Pipe") {
                    ExtraWindows.CraftingMenu.IsVisible = true;
                    ExtraWindows.CraftingMaxLevel = 99;
                    ExtraWindows.CraftingType = "Glassblowing Pipe";
                } else if (item.UseString == "Map") {
                    ExtraWindows.Map.IsVisible = true;
                    ExtraWindows.MapViewing = item.UseString2;
                    ExtraWindows.MapW = item.UseInt;
                    ExtraWindows.MapH = item.UseInt2;
                } else if (item.UseString == "Book") {
                    ExtraWindows.Book.IsVisible = true;
                    ExtraWindows.BookID = item.UseString2;
                    ExtraWindows.LeftPage = 0;
                } else if (item.UseString == "SecondExamine") {
                    GameLoop.WTN.Log.AddMessage(new ColoredString(item.MiscString, Color.SandyBrown, Color.Black));

                    foreach (var kv in GameLoop.WTN.QuestLibrary) {
                        kv.Value.CheckProgress(player, "ExamineItem", item.ID, 0);
                    }
                } else if (item.UseString == "CleanHerb") {
                    if (player.Skills.TryGetValue("Alchemy", out Skill? herb) && herb != null) {
                        if (herb.Level >= item.UseInt) {
                            if (GameLoop.WTN.ItemLibrary.TryGetValue(item.ItemReturned, out Item? spawn) && spawn != null) { 
                                player.TryGrantExp("Alchemy", item.UseInt2, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                return true;
                            } else {
                                GameLoop.WTN.Log.AddMessage(new ColoredString(item.ItemReturned + " does not currently exist, herb preserved.", Color.Crimson, Color.Black));
                                return false;
                            }
                        } else { 
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You need " + item.UseInt + " Alchemy to clean that. (Have " + herb.Level + ")", Color.Crimson, Color.Black));
                            return false;
                        }
                    } else {
                        GameLoop.WTN.Log.AddMessage(new ColoredString("Malformed skill list, could not find Alchemy entry.", Color.Crimson, Color.Black));
                        return false;
                    }
                } else if (item.UseString == "Potion") {
                    if (item.Potion != null) {
                        for (int i = 0; i < item.Potion.Count; i++) {
                            if (item.Potion[i].Stat == "Heal") { 
                                player.CurrentHP = Math.Clamp(player.CurrentHP + item.Potion[i].Change, player.CurrentHP, player.Skills["Hitpoints"].Level);
                                GameLoop.WTN.Log.AddMessage(new ColoredString("The " + item.Name.ToLowerInvariant() + " restores some Hitpoints.", Color.Goldenrod, Color.Black)); 
                            } else if (item.Potion[i].Stat == "Restore") {  
                                foreach (var pot in player.ActivePotions) {
                                    if (pot.Change < 0) {
                                        pot.Change = Math.Clamp(pot.Change + item.Potion[i].Change + (item.Potion[i].Change > 0 ? player.CurrentRestedBuff : 0), pot.Change, 0);
                                    }
                                }
                            } else {
                                bool found = false;
                                for (int j = 0; j < player.ActivePotions.Count; j++) {
                                    if (player.ActivePotions[j].Stat == item.Potion[i].Stat) {
                                        found = true;
                                        if (player.ActivePotions[j].Change < 0) {
                                            player.ActivePotions[j].Change += item.Potion[i].Change; 
                                        } else {
                                            if (player.ActivePotions[j].Change < item.Potion[i].Change + player.CurrentRestedBuff) {
                                                player.ActivePotions[j].Change = item.Potion[i].Change + player.CurrentRestedBuff; 
                                            } 
                                        }
                                    }
                                }

                                if (!found)
                                    player.ActivePotions.Add(new(item.Potion[i].Stat, item.Potion[i].Change + (item.Potion[i].Change > 0 ? player.CurrentRestedBuff : 0))); 

                                if (item.Potion[i].Stat == "Antipoison" && player.PoisonStatus > 0) {
                                    player.PoisonStatus = 0;
                                    GameLoop.WTN.Log.AddMessage("The antipoison cures your poison.", Color.Lime);
                                }
                            } 
                        }

                        return true;
                    }
                } else if (item.UseString == "Light") {
                    if (player.HasAllItems(["tinderbox,1"])) {
                        itemWrap.ID = item.UseString2;
                        GameLoop.WTN.Log.AddMessage("You light the " + item.Name + ".", Color.Yellow);
                    } else { 
                        GameLoop.WTN.Log.AddMessage("You need something to actually light that with, to light it.", Color.Crimson);
                    }
                    return false;
                } else if (item.UseString == "Extinguish") {
                    itemWrap.ID = item.UseString2;
                    GameLoop.WTN.Log.AddMessage("You extinguish the " + item.Name + ".", Color.Yellow);
                    if (!player.ItemsEverObtained.Contains(itemWrap.ID)) { player.ItemsEverObtained.Add(itemWrap.ID); }
                    return false;
                } else if (item.UseString == "Bell") { 
                    GameLoop.WTN.Log.AddMessage("You jangle the bell about for a bit.", Color.Yellow);
                    return false;
                } else if (item.UseString == "ViewInventory") {
                    ExtraWindows.ConWrap = itemWrap;
                    ExtraWindows.InventoryContainer.IsVisible = true;
                    return false;
                } else if (item.UseString == "LampAll") {
                    string[] split = item.UseString2.Split(",");

                    foreach (var skill in split) {
                        player.TryGrantExp(skill, item.UseInt, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                    } 
                    return true;
                } else if (item.UseString == "Gold") {
                    if (player.CoinPouch) {
                        int qty = 1;
                        if (Helper.EitherShift()) { qty *= 5; }
                        if (Helper.EitherControl()) { qty *= 10; }
                        if (Helper.KeyDown(Key.Space)) { qty *= 1000; }
                        if (qty > itemWrap.Quantity || Helper.EitherAlt()) { qty = itemWrap.Quantity; }

                        itemWrap.Quantity -= qty;
                        player.GiveGold(qty); 
                    } else { 
                        GameLoop.WTN.Log.AddMessage("You can't use the coin pouch to put these away, so you just fiddle with them a bit.", Color.Crimson);
                    }
                    return false;
                } else if (item.UseString == "Transform") {
                    itemWrap.ID = item.UseString2;
                    if (!player.ItemsEverObtained.Contains(itemWrap.ID)) { player.ItemsEverObtained.Add(itemWrap.ID); }
                    return false;
                } else if (item.UseString == "Teleport") {
                    if (GameLoop.WTN.Atlas.ContainsKey(item.UseString2)) {
                        if (item.UsesCharges) {
                            if (itemWrap.Charges > 0) { 
                                GameLoop.WTN.Log.AddMessage("You teleport to " + GameLoop.WTN.Atlas[item.UseString2].DisplayName + ".", Color.MediumPurple);
                                player.NavLoc = item.UseString2;
                                return true;
                            } else if (itemWrap.Charges < 0) { 
                                GameLoop.WTN.Log.AddMessage("You teleport to " + GameLoop.WTN.Atlas[item.UseString2].DisplayName + ".", Color.MediumPurple);
                                player.NavLoc = item.UseString2;
                                return true;
                            }
                        } else { 
                            GameLoop.WTN.Log.AddMessage("You teleport to " + GameLoop.WTN.Atlas[item.UseString2].DisplayName + ".", Color.MediumPurple);
                            player.NavLoc = item.UseString2;
                            return true;
                        } 
                    }

                    return false;
                } else if (item.UseString == "ItemPack") {
                    if (GameLoop.WTN.ResolveItem(item.UseString2) is Item unpacked) {
                        unpacked.Quantity = item.UseInt;
                        
                        player.TryPickup(unpacked, unpacked.Quantity, true);
                    } else {
                        GameLoop.WTN.Log.AddMessage("It doesn't seem like there's anything in the pack just yet, so you decide to hold on to it.", Color.Crimson);
                        return false;
                    }
                } else if (item.UseString == "LampChoice") {
                    ExtraWindows.LampAmount = item.UseInt;
                    if (item.UseString2 == "All") {
                        ExtraWindows.LampSkills = player.Skills.Keys.Order().ToList();
                    } else {
                        ExtraWindows.LampSkills = item.UseString2.Split(",").ToList();
                    }
                    ExtraWindows.LampWrap = itemWrap;
                    ExtraWindows.LampMenu.IsVisible = true;
                    return false;
                } else if (item.UseString == "CatMenu") {
                    ExtraWindows.CatMenu.IsVisible = true;
                } else if (item.UseString == "TalismanMenu") {
                    ExtraWindows.Talisman.IsVisible = true;
                    ExtraWindows.TalismanInk = itemWrap;
                    ExtraWindows.TalismanPaper = null;
                    ExtraWindows.TalismanDrawing = ""; 
                } else if (item.UseString == "CozyCottages") {
                    if (player.CozyDestID != "") {
                        if (GameLoop.WTN.Atlas.TryGetValue(player.CozyDestID, out Location? ccDest) && ccDest != null) {
                            string build = "";
                            foreach (var kv in player.CozyContractSpots) {
                                if (!kv.Repaired) {
                                    if (build != "") {
                                        build += ", ";
                                    }

                                    build += kv.Name;
                                }
                            }

                            build += ".";

                            GameLoop.WTN.Log.AddMessage("Your current contract is " + ccDest.DisplayName + " in " + ccDest.CozyTown + ". Remaining: " + build, Color.SandyBrown);
                        } else { 
                            GameLoop.WTN.Log.AddMessage("Malformed Cozy Cottages destination ID: " + player.CozyDestID + ". Report this, contract cleared for now.", Color.Crimson);
                            GameLoop.WTN.player.CozyDestID = "";
                            GameLoop.WTN.player.CozyContractSpots.Clear();
                        }
                    } else {
                        GameLoop.WTN.Log.AddMessage("You do not currently have a Cozy Cottages contract. Get one at an Estate Agent if desired.", Color.Crimson);
                    }
                    return false;
                } else if (item.UseString == "Teapot") {
                    foreach (var kv in player.Inventory) {
                        if (kv.ID == "cupClayEmpty" && !kv.Noted) { kv.ID = "cupClayTea"; kv.Charges = 1; return true; }
                        if (kv.ID == "cupPorcelainEmpty" && !kv.Noted) { kv.ID = "cupPorcelainTea"; kv.Charges = 1; return true; }
                        if (kv.ID == "cupAntiqueEmpty" && !kv.Noted) { kv.ID = "cupAntiqueTea"; kv.Charges = 1; return true; }
                    }
                    
                    GameLoop.WTN.Log.AddMessage("You don't have a cup to pour the tea out into.", Color.Crimson);
                    return false;
                } else if (item.UseString == "CompassMenu") {
                    ExtraWindows.Compass.IsVisible = true;
                    return false;
                } else if (item.UseString == "HouseTele") { 
                    ExtraWindows.HouseMenu.IsVisible = true;
                    ExtraWindows.HouseTeleport = true;
                    ExtraWindows.HouseTablet = true;
                } else if (item.UseString == "SleepingPotion") {
                    if (player.HasAllItems(["potionSleepingUnf,1", "potionSleepingWing,1", "potionSleepingTail,1", "potionSleepingEar,1", "potionSleepingHorn,1"])) {
                        if (GameLoop.WTN.ResolveItem("potionSleeping") is Item sleepingPotion) {
                            player.ConsumeItems(["potionSleepingUnf,1", "potionSleepingWing,1", "potionSleepingTail,1", "potionSleepingEar,1", "potionSleepingHorn,1"]);
                            player.TryPickup(sleepingPotion, 1);
                            GameLoop.WTN.Log.AddMessage("You successfully mix a Sleeping potion. Now you just have to get it to Juliet without her family seeing you.", Color.Turquoise);
                            return true;
                        }
                    } else { 
                        GameLoop.WTN.Log.AddMessage("Hmm, missing some ingredients. Better check the recipe list again.", Color.Crimson);
                    }
                } else if (item.UseString == "ManualPaper") { 
                    if (GameLoop.WTN.ResolveItem(item.ID.Replace("pulp", "paper")) is Item paper) {
                        int qty = 1;
                        if (Helper.EitherShift()) { qty *= 5; }
                        if (Helper.EitherControl()) { qty *= 10; }
                        if (qty > itemWrap.Quantity || Helper.EitherAlt()) { qty = itemWrap.Quantity; }

                        itemWrap.Quantity -= qty;
                        player.TryPickup(paper, qty);  
                    }
                    return false;
                } else if (item.UseString == "Bones") { 
                    GameLoop.WTN.Log.AddMessage("You lay the " + item.Name.ToLower() + " to rest, gaining " + item.UseInt + " Prayer experience.", Color.Yellow);
                    player.TryGrantExp("Prayer", item.UseInt, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                }

                return true;
            }
            return false;
        }

        public static bool TryCombineItems(Player player, string first, string second) {
            UsingSlot = -1;
            int i = -1;

            for(int j = 0; j < player.Inventory.Count; j++) {
                if (UsingSlot == -1 && player.Inventory[j].ID == first)
                    UsingSlot = j;
                if (UsingSlot != j && player.Inventory[j].ID == second)
                    i = j;
            } 

            if (UsingSlot != -1 && i != -1) {
                return TryCombineItems(player, i);
            }

            UsingSlot = -1;

            return false;
        }


        public static bool TryCombineItems(Player player, int i) {
            if (UsingSlot == -1 || UsingSlot >= player.Inventory.Count) {
                UsingSlot = i;
            }
            else {
                string first = player.Inventory[UsingSlot].ID;
                string second = player.Inventory[i].ID; 
                int firstSlot = UsingSlot;
                int secondSlot = i;

                if (first.Contains("potion") && second.Contains("potion") && first == second) {
                    if (player.Inventory[i].Charges + player.Inventory[UsingSlot].Charges <= 4) {
                        player.Inventory[i].Charges += player.Inventory[UsingSlot].Charges;
                        player.Inventory.RemoveAt(UsingSlot);
                        player.TryPickup(new Item(GameLoop.WTN.ItemLibrary["vialEmpty"]), 1);
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You combine the potions into one vial.", Color.Turquoise, Color.Black));
                    } else {
                        int diff = 4 - player.Inventory[i].Charges;
                        if (diff > 0) {
                            player.Inventory[i].Charges = 4;
                            player.Inventory[UsingSlot].Charges -= diff;
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You fill up one of the vials to the brim.", Color.Turquoise, Color.Black));
                        } else { 
                            GameLoop.WTN.Log.AddMessage(new ColoredString("That vial is already as full as possible.", Color.Crimson, Color.Black));
                        }
                    }

                    UsingSlot = -1;
                    return true;
                }
                
                if (GameLoop.WTN.ResolveItem(first) is Item firstCharge && GameLoop.WTN.ResolveItem(second) is Item secondCharge) {   
                    ItemWrapper firstChargeWrap = player.Inventory[firstSlot];
                    ItemWrapper secondChargeWrap = player.Inventory[secondSlot];

                    if (secondCharge.ChargeItem == first) {
                        ItemWrapper swap = new(firstChargeWrap);
                        firstChargeWrap = secondChargeWrap;
                        secondChargeWrap = swap;

                        Item swapItem = new(firstCharge);
                        firstCharge = secondCharge;
                        secondCharge = swapItem;
                        
                        int swapSlot = firstSlot;
                        firstSlot = secondSlot;
                        secondSlot = swapSlot;

                        string swapStr = first;
                        first = second;
                        second = swapStr;
                    } 
                     
                    if (firstCharge.ChargeItem == second) {
                        if (secondChargeWrap.Charges != 0) {
                            firstChargeWrap.Charges += secondChargeWrap.Charges;
                            if (secondCharge.ShattersAtZeroCharges) {
                                player.Inventory.RemoveAt(secondSlot);
                            }
                        } else {
                            firstChargeWrap.Charges += secondChargeWrap.Quantity;
                            player.Inventory.RemoveAt(secondSlot);
                        }

                        return true;
                    } 
                }

                // Check to see if there's some container stuff that could happen
                if (GameLoop.WTN.ResolveItem(first) is Item firstPouch && GameLoop.WTN.ResolveItem(second) is Item secondPouch) {  
                    if (secondPouch.ContainableIDs.Contains(first)) { 
                        Item swapPouch = new(firstPouch);
                        firstPouch = secondPouch;
                        secondPouch = swapPouch;

                        string swapStr = first;
                        first = second;
                        second = swapStr;

                        int swapSlot = firstSlot;
                        firstSlot = secondSlot;
                        secondSlot = swapSlot;
                    }

                    ItemWrapper firstPouchWrap = player.Inventory[firstSlot];
                    ItemWrapper secondPouchWrap = player.Inventory[secondSlot];

                    if (firstPouch.ContainableIDs.Contains(second)) {  
                        foreach (var conWrap in firstPouchWrap.Containing) {
                            if (conWrap.ID == second && conWrap.GetRef() is Item con) {
                                if (!conWrap.Noted && (con.Stackable || firstPouch.ContainerStacksUnstackable)) {
                                    if (conWrap.Quantity + secondPouchWrap.Quantity < firstPouch.ContainerMaxStack) {
                                        conWrap.Quantity += secondPouchWrap.Quantity;
                                        player.Inventory.RemoveAt(secondSlot);
                                    } else {
                                        int placed = firstPouch.ContainerMaxStack - conWrap.Quantity;
                                        conWrap.Quantity += placed;
                                        secondPouchWrap.Quantity -= placed;
                                        
                                        GameLoop.WTN.Log.AddMessage("Container can't hold anymore of that item.");

                                        if (secondPouchWrap.Quantity <= 0) {
                                            player.Inventory.RemoveAt(secondSlot);
                                        }
                                    }
                                    return true;
                                }
                            } 
                        }

                        if (firstPouch.ContainerSlots > 0 && firstPouch.ContainerSlots > firstPouchWrap.Containing.Count) {
                            firstPouchWrap.Containing.Add(secondPouchWrap);
                            player.Inventory.RemoveAt(secondSlot);
                            return true;
                        } else { 
                            GameLoop.WTN.Log.AddMessage("Container is too full to hold any more items.");
                        }
                    } 
                }
                
                 
                TwoWayString two = new TwoWayString(first, second);
                if (GameLoop.WTN.UseRecipes.ContainsKey(two)) {
                    SidebarManager.LastPerformedRecipe = two;
                    Recipe rec = GameLoop.WTN.UseRecipes[two];

                    if (rec.FirstItem == second) {
                        firstSlot = i;
                        secondSlot = UsingSlot;
                    }

                    ItemWrapper firstWrap = player.Inventory[firstSlot];
                    ItemWrapper secondWrap = player.Inventory[secondSlot];

                    Item? firstItem = firstWrap.GetRef();
                    Item? secondItem = secondWrap.GetRef();

                    if (firstItem == null || secondItem == null)
                        return false;
                     
                    UsingSlot = -1; 

                    if (rec.NeededTool != "" && !player.HasAllItems([rec.NeededTool + ",1"], false, true)) {
                        GameLoop.WTN.Log.AddMessage(new ColoredString("You need a " + GameLoop.WTN.ResolveItemName(rec.NeededTool) + " to do that.", Color.Crimson, Color.Black));
                        return false;
                    }

                    if (rec.ExtraReqs.Count > 0) {
                        foreach (var req in rec.ExtraReqs) {
                            if (!req.CheckRequirement(player, false, true)) { 
                                GameLoop.WTN.Log.AddMessage(new ColoredString("Missing requirement to combine those: " + req.GetSummary(), Color.Crimson, Color.Black));
                                return false;
                            }
                        }
                    }

                    if (!firstWrap.Noted && !secondWrap.Noted) { 
                        if (firstWrap.Quantity < rec.FirstQty) {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You need " + rec.FirstQty + " " + firstItem.Name + " to do that.", Color.Crimson, Color.Black));
                            return false;
                        }

                        if (secondWrap.Quantity < rec.SecondQty) {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You need " + rec.SecondQty + " " + secondItem.Name + " to do that.", Color.Crimson, Color.Black));
                            return false;
                        }

                        firstWrap.Quantity -= rec.FirstQty;
                        if (firstWrap.Quantity <= 0)
                            player.Inventory.Remove(firstWrap);

                        secondWrap.Quantity -= rec.SecondQty;
                        if (secondWrap.Quantity <= 0)
                            player.Inventory.Remove(secondWrap);

                        if (rec.OutputItem[0] != '_') {
                            int failRoll = GameLoop.rand.Next(100);  
                                // TODO: Make cooking gauntlets lower fail level after Family Crest is implemented

                            int skillForRoll = 50 + (player.GetEffectiveSkillLevel(rec.SkillUsed) - rec.SkillLevelReq);

                            string id = rec.OutputItem;

                            if (rec.FailID == "" || failRoll <= skillForRoll || (rec.SkillUsed == "Cooking" && player.Equipment.TryGetValue("Cape", out ItemWrapper? cape) && cape != null && cape.ID == "capeSkillCooking")) {
                                id = rec.OutputItem;
                            } else {
                                id = rec.FailID;
                            }

                            if (GameLoop.WTN.ItemLibrary.ContainsKey(id)) {
                                Item made = new(GameLoop.WTN.ItemLibrary[id]);
                                made.Quantity = rec.OutputQty;
                                player.TryPickup(made, made.Quantity);
                            } else {
                                GameLoop.WTN.Log.AddMessage(new ColoredString("You get the feeling that should've resulted in " + id + ", but that item doesn't exist.", Color.Crimson, Color.Black));
                            }
                        } else {
                            if (rec.OutputItem == "_fire") {
                                if (GameLoop.WTN.Atlas.ContainsKey(player.NavLoc) && GameLoop.WTN.ProcessingStations.ContainsKey("Range")) {
                                    Location curr = GameLoop.WTN.Atlas[player.NavLoc];
                                                     
                                    ProcessingStation fire = Helper.Clone(GameLoop.WTN.ProcessingStations["Range"]);
                                    fire.Name = "Fire";
                                    fire.TimeLeft = rec.OutputQty;
                                    fire.TimeMade = Helper.Time();
                                    fire.ItemOnExpire = rec.MiscString;
                                                     
                                    curr.TempStations.Add(fire);
                                }
                                                
                                GameLoop.WTN.Log.AddMessage(new ColoredString("You start a fire with the " + secondItem.Name + ".", Color.OrangeRed, Color.Black));
                            }
                        }

                        if (rec.ReturnIDs.Count > 0) {
                            for (int ret = 0; ret < rec.ReturnIDs.Count; ret++) {
                                if (GameLoop.WTN.ItemLibrary.ContainsKey(rec.ReturnIDs[ret])) {
                                    Item made = new(GameLoop.WTN.ItemLibrary[rec.ReturnIDs[ret]]);
                                    made.Quantity = 1;

                                    player.TryPickup(made, made.Quantity);
                                } else {
                                    GameLoop.WTN.Log.AddMessage(new ColoredString("You get the feeling that should've resulted in " + GameLoop.WTN.ResolveItemName(rec.ReturnIDs[ret]) + ", but that item doesn't exist.", Color.Crimson, Color.Black));
                                }
                            }
                        }

                        player.TryGrantExp(rec.SkillUsed, rec.ExpGranted, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);

                        return true;
                    }
                }

                // Check to see if it's alchemy related
                if (GameLoop.WTN.ResolveItem(first) is Item firstAlch && GameLoop.WTN.ResolveItem(second) is Item secondAlch && !firstAlch.Noted && !secondAlch.Noted) {   
                    ItemWrapper firstAlchWrap = player.Inventory[firstSlot];
                    ItemWrapper secondAlchWrap = player.Inventory[secondSlot];

                    if ((firstAlchWrap.Alchemy != null && secondAlchWrap.Alchemy == null) || first == "alchemyMixture") { // For standardization try to make the item with alchemy stats the second item 
                        ItemWrapper swap = firstAlchWrap;
                        firstAlchWrap = secondAlchWrap;
                        secondAlchWrap = swap;

                        Item swapItem = new(firstAlch);
                        firstAlch = secondAlch;
                        secondAlch = swapItem;
                        
                        int swapSlot = firstSlot;
                        firstSlot = secondSlot;
                        secondSlot = swapSlot;

                        string swapStr = first;
                        first = second;
                        second = swapStr;
                    }
                    
                    UsingSlot = -1;

                    // At this point if both have alch stats they shouldn't switch, if they both do but the first is a mixture they switch, and if only the first has stats they switch.

                    int tier = player.GetSkillTier("Alchemy");

                    if (firstAlchWrap.Alchemy != null && secondAlchWrap.Alchemy != null) { // if both have stats then both are either ingredients or mixtures
                        if (first == "alchemyMixture" && second == "alchemyMixture") { // if they're both mixtures, average their stats if actions are left
                            if (firstAlchWrap.Alchemy.ActionsTaken.Count + secondAlchWrap.Alchemy.ActionsTaken.Count < tier) { // Averaging takes up an action though
                                int red = firstAlchWrap.Alchemy.Red + secondAlchWrap.Alchemy.Red;
                                int black = firstAlchWrap.Alchemy.Black + secondAlchWrap.Alchemy.Black;
                                int yellow = firstAlchWrap.Alchemy.Yellow + secondAlchWrap.Alchemy.Yellow;
                                int white = firstAlchWrap.Alchemy.White = secondAlchWrap.Alchemy.White;

                                firstAlchWrap.Alchemy.Red = (int) Math.Round(red / 2.0, MidpointRounding.ToZero);
                                firstAlchWrap.Alchemy.Black = (int) Math.Round(black / 2.0, MidpointRounding.ToZero);
                                firstAlchWrap.Alchemy.Yellow = (int) Math.Round(yellow / 2.0, MidpointRounding.ToZero);
                                firstAlchWrap.Alchemy.White = (int) Math.Round(white / 2.0, MidpointRounding.ToZero);
                                firstAlchWrap.Alchemy.ActionsTaken.Add("Mixed");
                                firstAlchWrap.Alchemy.Ingredients.AddRange(secondAlchWrap.Alchemy.Ingredients);
                                
                                secondAlchWrap.Alchemy.Red = (int) Math.Round(red / 2.0, MidpointRounding.ToZero);
                                secondAlchWrap.Alchemy.Black = (int) Math.Round(black / 2.0, MidpointRounding.ToZero);
                                secondAlchWrap.Alchemy.Yellow = (int) Math.Round(yellow / 2.0, MidpointRounding.ToZero);
                                secondAlchWrap.Alchemy.White = (int) Math.Round(white / 2.0, MidpointRounding.ToZero);
                                secondAlchWrap.Alchemy.ActionsTaken.Add("Mixed");
                                secondAlchWrap.Alchemy.Ingredients = new(firstAlchWrap.Alchemy.Ingredients);
                                
                                GameLoop.WTN.Log.AddMessage("You combine the mixtures and then split the resulting liquid between the vials.", Color.Turquoise);
                                return true;
                            } else {
                                GameLoop.WTN.Log.AddMessage("One or both mixtures are already at the limit for how many times you can modify them.", Color.Crimson);
                            }
                        } else if (second == "alchemyMixture") { // if only the second is a mixture (which should be the case if a mixture is involved but both aren't mixtures)
                            if (secondAlchWrap.Alchemy.Ingredients.Count < tier + 1) {
                                if (firstAlchWrap.Alchemy.Level <= player.GetEffectiveSkillLevel("Alchemy")) {
                                    secondAlchWrap.Alchemy.Red += firstAlchWrap.Alchemy.Red;
                                    secondAlchWrap.Alchemy.Black += firstAlchWrap.Alchemy.Black;
                                    secondAlchWrap.Alchemy.Yellow += firstAlchWrap.Alchemy.Yellow;
                                    secondAlchWrap.Alchemy.White += firstAlchWrap.Alchemy.White;
                                    secondAlchWrap.Alchemy.Ingredients.Add(first);
                                
                                    GameLoop.WTN.Log.AddMessage("You add " + firstAlch.Name.ToLower() + " to the mixture.", Color.Turquoise);
                                    player.ConsumeItems([first + ",1"]);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("Your alchemy level is too low to use " + firstAlch.Name.ToLower() + ", need level " + firstAlchWrap.Alchemy.Level + ".", Color.Crimson);
                                }
                            } else {
                                GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many ingredients you can currently add.", Color.Crimson);
                            }
                        } else { // at this point theoretically you shouldn't be able to have anything but two ingredients 
                            GameLoop.WTN.Log.AddMessage("Can't combine those ingredients that way.", Color.Crimson);
                        }

                        return false;
                    } else if ((firstAlchWrap.Alchemy == null && secondAlchWrap.Alchemy != null) || first == "alchemyLoupe") { // only the second should have alchemy stats here
                        if (first == "alchemyLoupe") {
                            if (secondAlchWrap.Alchemy != null) {
                                string vals = secondAlchWrap.Alchemy.Red.ToString().Align(HorizontalAlignment.Right, 3) + "R / " +
                                              secondAlchWrap.Alchemy.Black.ToString().Align(HorizontalAlignment.Right, 3) + "B / " +
                                              secondAlchWrap.Alchemy.Yellow.ToString().Align(HorizontalAlignment.Right, 3) + "Y / " +
                                              secondAlchWrap.Alchemy.White.ToString().Align(HorizontalAlignment.Right, 3) + "W";
                                if (second == "alchemyMixture") { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is currently: " +  vals + " (" + secondAlchWrap.Alchemy.Ingredients.Count + " ingredients, " + secondAlchWrap.Alchemy.ActionsTaken.Count + " actions)", Color.Yellow);
                                } else {
                                    GameLoop.WTN.Log.AddMessage("You analyze the " + secondAlch.Name.ToLower() + ": " + vals, Color.Yellow);
                                }
                            } else {
                                GameLoop.WTN.Log.AddMessage("You analyze the " + secondAlch.Name.ToLower() + ", but it has no alchemical potential.", Color.Yellow);
                            }
                            return true;
                        }

                        if (secondAlchWrap.Alchemy != null) {
                            if (first == "vialWater") {
                                if (second == "alchemyMixture") {
                                    if (GameLoop.WTN.ResolveItem("alchemyMixture") is Item mix) {
                                        player.ConsumeItems([first + ",1"]);

                                        int red = mix.Alchemy.Red + secondAlchWrap.Alchemy.Red;
                                        int black = mix.Alchemy.Black + secondAlchWrap.Alchemy.Black;
                                        int yellow = mix.Alchemy.Yellow + secondAlchWrap.Alchemy.Yellow;
                                        int white = mix.Alchemy.White = secondAlchWrap.Alchemy.White;

                                        mix.Alchemy.Red = (int) Math.Round(red / 2.0, MidpointRounding.ToZero);
                                        mix.Alchemy.Black = (int) Math.Round(black / 2.0, MidpointRounding.ToZero);
                                        mix.Alchemy.Yellow = (int) Math.Round(yellow / 2.0, MidpointRounding.ToZero);
                                        mix.Alchemy.White = (int) Math.Round(white / 2.0, MidpointRounding.ToZero);
                                        mix.Alchemy.Ingredients = new(secondAlchWrap.Alchemy.Ingredients);
                                        mix.Alchemy.ActionsTaken.Add("Diluted");
                                
                                        secondAlchWrap.Alchemy.Red = (int) Math.Round(red / 2.0, MidpointRounding.ToZero);
                                        secondAlchWrap.Alchemy.Black = (int) Math.Round(black / 2.0, MidpointRounding.ToZero);
                                        secondAlchWrap.Alchemy.Yellow = (int) Math.Round(yellow / 2.0, MidpointRounding.ToZero);
                                        secondAlchWrap.Alchemy.White = (int) Math.Round(white / 2.0, MidpointRounding.ToZero);
                                        secondAlchWrap.Alchemy.ActionsTaken.Add("Diluted");

                                        player.TryPickup(mix, 1);
                                 
                                        GameLoop.WTN.Log.AddMessage(new ColoredString("You dilute the mixture with water, splitting the liquid between both vials.", Color.Turquoise, Color.Black));
                                        return true;
                                    }
                                } else {
                                    if (secondAlchWrap.Alchemy.Level <= player.GetEffectiveSkillLevel("Alchemy")) {
                                        if (GameLoop.WTN.ResolveItem("alchemyMixture") is Item mix) {
                                            player.ConsumeItems([first + ",1", second + ",1"]);
                                            mix.Alchemy = new(secondAlchWrap.Alchemy);
                                            mix.Alchemy.Ingredients.Add(second);

                                            player.TryPickup(mix, 1);
                                 
                                            GameLoop.WTN.Log.AddMessage(new ColoredString("You start a new alchemical mixture.", Color.Turquoise, Color.Black));
                                            return true;
                                        } 
                                    } else { 
                                        GameLoop.WTN.Log.AddMessage("Your alchemy level is too low to use " + secondAlch.Name.ToLower() + ", need level " + secondAlchWrap.Alchemy.Level + ".", Color.Crimson);
                                        return false;
                                    }
                                }
                            }

                            if (first == "alchemyBrazier" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.Ingredients.Count + secondAlchWrap.Alchemy.ActionsTaken.Count >= 2) {
                                    bool foundMatching = false;
                                    foreach (var kv in GameLoop.WTN.PotionRecipeLibrary) {
                                        if (kv.Value.ReqsMet(secondAlchWrap.Alchemy)) {
                                            if (GameLoop.WTN.ResolveItem(kv.Value.PotionID) is Item potion) {
                                                foundMatching = true;
                                            
                                                player.Inventory.RemoveAt(secondSlot);

                                                int qty = potion.ID.Substring(0, 3) == "ink" ? 50 : potion.ID.Substring(0, 3) == "oil" ? 10 : 1;

                                                player.TryPickup(potion, qty);
                                            
                                                GameLoop.WTN.Log.AddMessage(new ColoredString("You heat the mixture and it turns into a" + (Helper.VowelStart(potion.Name.ToLower()) ? "n " : " ") + potion.Name.ToLower() + ".", Color.Lime, Color.Black));
                                                player.TryGrantExp("Alchemy", kv.Value.ExpGranted, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                                break;
                                            }
                                        }
                                    }

                                    if (!foundMatching) { 
                                        if (GameLoop.WTN.ResolveItem("alchemyFailure") is Item potion) {
                                            foundMatching = true;
                                            
                                            player.Inventory.RemoveAt(secondSlot);
                                            player.TryPickup(potion, 1);
                                            
                                            GameLoop.WTN.Log.AddMessage(new ColoredString("You heat the mixture, but the recipe was wrong in some way so it turns into useless goop.", Color.Crimson, Color.Black));
                                        } 
                                    }

                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage(new ColoredString("You decide not to heat the mixture just yet, as a single ingredient in some water does not a potion make.", Color.Crimson, Color.Black));
                                    return false;
                                }
                            }

                            if (first == "alchemyRetort" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    secondAlchWrap.Alchemy.Red++;
                                    secondAlchWrap.Alchemy.Black--;
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Retort");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your retort. (+1 Red, -1 Black)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyAlembic" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    secondAlchWrap.Alchemy.Black++;
                                    secondAlchWrap.Alchemy.Yellow--;
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Alembic");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your alembic. (+1 Black, -1 Yellow)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyCrucible" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    secondAlchWrap.Alchemy.Yellow++;
                                    secondAlchWrap.Alchemy.White--;
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Crucible");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your crucible. (+1 Yellow, -1 White)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyAludel" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    secondAlchWrap.Alchemy.White++;
                                    secondAlchWrap.Alchemy.Red--;
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Aludel");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your aludel. (+1 White, -1 Red)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyCalcinator" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    secondAlchWrap.Alchemy.Red += (secondAlchWrap.Alchemy.Red > 0 ? -1 : secondAlchWrap.Alchemy.Red < 0 ? 1 : 0);
                                    secondAlchWrap.Alchemy.Black += (secondAlchWrap.Alchemy.Black > 0 ? -1 : secondAlchWrap.Alchemy.Black < 0 ? 1 : 0); 
                                    secondAlchWrap.Alchemy.Yellow += (secondAlchWrap.Alchemy.Yellow > 0 ? -1 : secondAlchWrap.Alchemy.Yellow < 0 ? 1 : 0); 
                                    secondAlchWrap.Alchemy.White += (secondAlchWrap.Alchemy.White > 0 ? -1 : secondAlchWrap.Alchemy.White < 0 ? 1 : 0); 
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Calcinator");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your calcinator. (All 1 towards Zero)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemySwizzler" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    int total = Math.Abs(secondAlchWrap.Alchemy.Red) + Math.Abs(secondAlchWrap.Alchemy.Black) + Math.Abs(secondAlchWrap.Alchemy.Yellow) + Math.Abs(secondAlchWrap.Alchemy.White);
                                    int avg = (int) Math.Round(total / 4.0, MidpointRounding.ToZero);

                                    secondAlchWrap.Alchemy.Red = (secondAlchWrap.Alchemy.Red < 0 ? avg * -1 : avg);
                                    secondAlchWrap.Alchemy.Black = (secondAlchWrap.Alchemy.Black < 0 ? avg * -1 : avg);
                                    secondAlchWrap.Alchemy.Yellow = (secondAlchWrap.Alchemy.Yellow < 0 ? avg * -1 : avg);
                                    secondAlchWrap.Alchemy.White = (secondAlchWrap.Alchemy.White < 0 ? avg * -1 : avg);
                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Swizzler");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your swizzler. (Average all, round toward zero, maintain polarity)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyAgitator" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    int white = secondAlchWrap.Alchemy.White;
                                    secondAlchWrap.Alchemy.White = secondAlchWrap.Alchemy.Yellow;
                                    secondAlchWrap.Alchemy.Yellow = secondAlchWrap.Alchemy.Black;
                                    secondAlchWrap.Alchemy.Black = secondAlchWrap.Alchemy.Red;
                                    secondAlchWrap.Alchemy.Red = white;

                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Agitator");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your agitator. (Red -> Black -> Yellow -> White -> Red)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyDeagitator" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) {
                                    int red = secondAlchWrap.Alchemy.Red;
                                    secondAlchWrap.Alchemy.Red = secondAlchWrap.Alchemy.Black;
                                    secondAlchWrap.Alchemy.Black = secondAlchWrap.Alchemy.Yellow;
                                    secondAlchWrap.Alchemy.Yellow = secondAlchWrap.Alchemy.White;
                                    secondAlchWrap.Alchemy.White = red;

                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Deagitator");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your agitator. (Red <- Black <- Yellow <- White <- Red)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }

                            if (first == "alchemyInverter" && second == "alchemyMixture") {
                                if (secondAlchWrap.Alchemy.ActionsTaken.Count < tier) { 
                                    secondAlchWrap.Alchemy.Red *= -1;
                                    secondAlchWrap.Alchemy.Black *= -1;
                                    secondAlchWrap.Alchemy.Yellow *= -1;
                                    secondAlchWrap.Alchemy.White *= -1;

                                    secondAlchWrap.Alchemy.ActionsTaken.Add("Inverter");
                                    GameLoop.WTN.Log.AddMessage("You adjust the mixture using your agitator. (All flip polarity)", Color.Turquoise);
                                    return true;
                                } else { 
                                    GameLoop.WTN.Log.AddMessage("That mixture is already at the limit for how many times you may adjust it.", Color.Crimson);
                                    return false;
                                }
                            }
                        }
                    }
                }

                GameLoop.WTN.Log.AddMessage(new ColoredString("Those two items don't combine like that.", Color.Crimson, Color.Black));
                UsingSlot = -1;
                
            }

            return false;
        }

        public static bool TryEquipItem(Player player, int i) {
            if (player.Inventory[i].GetRef() is Item eqp) {
                bool canEquip = true;

                if (eqp.EquipSkill != "") {
                    if (player.Skills.ContainsKey(eqp.EquipSkill)) {
                        if (player.Skills[eqp.EquipSkill].Level < eqp.EquipLevel) {
                            GameLoop.WTN.Log.AddMessage("You need at least " + eqp.EquipLevel + " " + eqp.EquipSkill + " to equip that.", Color.Crimson);
                            canEquip = false;
                        }
                    }
                }

                if (eqp.EquipReq != null) {
                    if (!eqp.EquipReq.CheckRequirement(player, false, true)) { 
                        GameLoop.WTN.Log.AddMessage("Missing equip requirement: " + eqp.EquipReq.GetSummary(), Color.Crimson);
                        canEquip = false;
                    }
                }

                if (canEquip) {     
                    if (player.Equipment.ContainsKey(eqp.EquipSlot)) {
                        if (player.Equipment[eqp.EquipSlot].ID == player.Inventory[i].ID && eqp.Stackable) {
                            player.Equipment[eqp.EquipSlot].Quantity += player.Inventory[i].Quantity; 
                            player.Inventory.RemoveAt(i);
                            return true;
                        } else {
                            ItemWrapper unequip = player.Equipment[eqp.EquipSlot];
                            player.TryPickup(unequip, unequip.Quantity);
                            player.Equipment.Remove(eqp.EquipSlot); 
                        }
                    }

                    if (eqp.EquipSlot == "Weapon" && eqp.TwoHanded && player.Equipment.ContainsKey("Offhand")) {
                        ItemWrapper offhand = player.Equipment["Offhand"];
                        player.TryPickup(offhand, offhand.Quantity);
                        player.Equipment.Remove("Offhand");
                    }

                    if (eqp.EquipSlot == "Offhand" && player.Equipment.TryGetValue("Weapon", out ItemWrapper? wrap) && wrap.GetRef() is Item item && item.TwoHanded) {
                        ItemWrapper unequip = player.Equipment["Weapon"];
                        player.TryPickup(unequip, unequip.Quantity);
                        player.Equipment.Remove("Weapon");
                    }
                    
                    player.Equipment.Add(eqp.EquipSlot, player.Inventory[i]); 
                    player.Inventory.RemoveAt(i); 

                    return true;
                }

                return false;
            }
            return false;
        }
        

        public static bool TryChargeItem(Player p, int slot) {
            if (slot >= 0 && slot < p.Inventory.Count) {
                ItemWrapper wrap = p.Inventory[slot];
                if (wrap.GetRef() is Item inv) {
                    if (inv.ChargeItem != "") {
                        int qty = Helper.QuantitySelector(0, int.MaxValue, false, false, true);

                        bool foundAny = false;
                        while (p.HasAllItems([inv.ChargeItem + ",1"]) && qty > 0) {
                            qty--; 
                            p.ConsumeItems([inv.ChargeItem + ",1"]);
                            wrap.Charges++;
                            foundAny = true;
                        }

                        return foundAny;
                    }
                }
            }

            return false;
        }
    }
}
