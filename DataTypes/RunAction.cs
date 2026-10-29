using Microsoft.Xna.Framework.Audio;
using WorldtreeNexus.HardcodedData;
using WorldtreeNexus.Hardcodes;
using WorldtreeNexus.Managers;
using WorldtreeNexus.UI;

namespace WorldtreeNexus.DataTypes {
    public class RunAction {
        public string ActionID = "";
        public string MiscString = "";
        public string MiscString2 = "";
        public int MiscInt = 0;

        public RunAction(string id, string misc, string misc2, int miscint) {
            ActionID = id;
            MiscString = misc;
            MiscString2 = misc2;
            MiscInt = miscint;
        }

        public void Execute() {
            Player player = GameLoop.WTN.player;
            MessageLog Log = GameLoop.WTN.Log;

            if (ActionID != "") {
                if (ActionID == "Quest") {
                    player.TrySetQuest(MiscString, MiscInt);
                } 
                            
                if (ActionID == "Data") {
                    Helper.AlterWorldState(MiscString, MiscString2, MiscInt);
                }

                if (ActionID == "TempSkillBoost") { 
                    player.TryAddPotionEffect(MiscString, MiscInt); 
                }

                if (ActionID == "OpenUI") {
                    if (MiscString == "Shop") {
                        ExtraWindows.Shop.IsVisible = true;
                        ExtraWindows.ShopID = MiscString2;
                        ExtraWindows.BuildShop();
                    } else if (MiscString == "ManagePOH") {
                        ExtraWindows.HouseMenu.IsVisible = true;
                        ExtraWindows.HouseTeleport = false;
                    } else if (MiscString == "TelePOH") {
                        ExtraWindows.HouseMenu.IsVisible = true;
                        ExtraWindows.HouseTeleport = true;
                        ExtraWindows.HouseTablet = false;
                    }
                }

                if (ActionID == "GiveItem") {
                    if (GameLoop.WTN.ResolveItem(MiscString) is Item given) {
                        player.TryPickup(given, MiscInt);
                    }
                }

                if (ActionID == "EndDialogue") {
                    UI_LocNPCs.ConversationPartner = null;
                    GameLoop.WTN.SelectedMenu = "NPCs";
                }

                if (ActionID == "UnlockSong") {
                    if (!player.AllSongsUnlocked && !player.UnlockedSongs.Contains(MiscString)) { 
                        player.UnlockedSongs.Add(MiscString); 
                        Log.AddMessage("You have unlocked the song: " + MiscString, Color.Turquoise);
                    }

                    if (player.MusicMode == "Auto" && GameLoop.SoundManager.CurrentSong != MiscString && GameLoop.SoundManager.PlayingSounds.Count == 0) {
                        GameLoop.SoundManager.PickMusic(MiscString);
                    }
                }

                if (ActionID == "CustomLog") {
                    Color col = Color.White;
                    if (MiscInt == 1) { col = Color.Lime; }
                    else if (MiscInt == 2) { col = Color.Crimson; }
                    else if (MiscInt == 3) { col = Color.Turquoise; }
                    else if (MiscInt == 4) { col = Color.Yellow; }
                    Log.AddMessage(MiscString, col);
                } 

                if (ActionID == "RefillPrayer") {
                    player.CurrentPrayer = player.GetMaxPrayer();
                    Log.AddMessage("You pray at the altar, restoring your prayer points to full.", Color.DodgerBlue);
                }

                if (ActionID == "ClueHelp") {
                    bool printedAny = false;
                    if (player.CurrentClueBeginner != "") { Log.AddMessage("Beginner: " + ClueLogic.HelpLog("Beginner", player), Color.DodgerBlue); printedAny = true; }
                    if (player.CurrentClueEasy != "") {     Log.AddMessage("    Easy: " + ClueLogic.HelpLog("Easy", player), Color.DodgerBlue); printedAny = true; }
                    if (player.CurrentClueMedium != "") {   Log.AddMessage("  Medium: " + ClueLogic.HelpLog("Medium", player), Color.DodgerBlue); printedAny = true; }
                    if (player.CurrentClueHard != "") {     Log.AddMessage("    Hard: " + ClueLogic.HelpLog("Hard", player), Color.DodgerBlue); printedAny = true; }
                    if (player.CurrentClueElite != "") {    Log.AddMessage("   Elite: " + ClueLogic.HelpLog("Elite", player), Color.DodgerBlue); printedAny = true; }
                    if (player.CurrentClueMaster != "") {   Log.AddMessage("  Master: " + ClueLogic.HelpLog("Master", player), Color.DodgerBlue); printedAny = true; }
                                                        
                    if (!printedAny) {
                        Log.AddMessage("Looks like you haven't got any clue steps active right now!", Color.DodgerBlue);
                    }
                }

                if (ActionID == "HansTime") {
                    int totalSeconds = player.SecondsPlayed;
                    int days = (totalSeconds > 86400 ? totalSeconds / 86400 : 0);
                    totalSeconds -= (days * 86400);
                    int hours = (totalSeconds > 3600 ? totalSeconds / 3600 : 0);
                    totalSeconds -= (hours * 3600);
                    int minutes = (totalSeconds > 60 ? totalSeconds / 60 : 0);
                    totalSeconds -= (minutes * 60);

                    string time = (days > 1 ? days + " days, " : days > 0 ? days + " day, " : "") +
                                    (hours > 1 ? hours + " hours, " : hours > 0 ? hours + " hour, " : "") +
                                    (minutes > 1 ? minutes + " minutes, " : minutes > 0 ? minutes + " minute, " : "") +
                                    (totalSeconds > 1 ? totalSeconds + " seconds" : totalSeconds > 0 ? totalSeconds + " second" : "") + ".";

                    Log.AddMessage("You've played for a total of " + time, Color.DodgerBlue);
                }

                if (ActionID == "Minigame") {
                    if (MiscString == "GetCozyContract") {
                        if (player.CozyDestID == "") {
                            player.CozyContractSpots.Clear();
                            MinigameManager.MH_GetContract();

                            if (!player.HasAllItems(["cozyCottagesContract"])) {
                                if (GameLoop.WTN.ResolveItem("cozyCottagesContract") is Item contract) {
                                    player.TryPickup(contract, 1);
                                }
                            }

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

                                GameLoop.WTN.Log.AddMessage("Your new contract is " + ccDest.DisplayName + " in " + ccDest.CozyTown + ". Remaining: " + build, Color.SandyBrown);
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage("You already have a contract and should finish that before getting a new one.", Color.Crimson);
                        }
                    } else if (MiscString == "ViewCozyContract") {
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
                            GameLoop.WTN.Log.AddMessage("You do not currently have a Cozy Cottages contract.", Color.Crimson);
                        }
                    }
                }

                if (ActionID == "BoughtHouse") {
                    PlayerOwnedHome newHouse = new(MiscString2);
                    newHouse.Rooms.Add(new(HardcodedPOHObjects.RoomTypes[0]));

                    if (player.Homes.Values.Where(o => o.Active).ToList().Count < player.GetSkillTier("Construction")) {
                        newHouse.Active = true;
                    }

                    player.Homes.TryAdd(MiscString, newHouse);
                }

                if (ActionID == "POH") {
                    if (MiscString == "Rest") {
                        if (player.TimeLastRested + 3600 < Helper.Time()) { // Can only rest if it's been at least an hour of playtime since last rest
                            if (GameLoop.WTN.Atlas.TryGetValue(player.NavLoc, out Location? curr) && curr != null) { 
                                PlayerOwnedHome? home = null;

                                if (curr.PlayerHomeHere != "" && player.Homes.TryGetValue(curr.PlayerHomeHere, out PlayerOwnedHome? tempHome)) {
                                    home = tempHome;
                                }

                                if (home != null) {
                                    int restBuff = Math.Clamp(home.TotalComfort() / 30, 1, 5); 
                                    player.CurrentRestedBuff = restBuff; 
                                    player.TimeLastRested = player.SecondsPlayed;
                                    player.ActivePotions.Add(new("Well Rested", restBuff));  
                                    Log.AddMessage("You take a nap and wake up feeling well rested. (+" + restBuff + ")", Color.Lime);
                                } else {
                                    Log.AddMessage("You don't seem to be in a home at the moment.", Color.Crimson);
                                }
                            }
                        } else {
                            double ms = (player.TimeLastRested + 3600) - Helper.Time();
                            int minutes = (int) (ms / 60);

                            Log.AddMessage("You aren't tired yet. Try again in " + minutes + " minute" + (minutes > 1 ? "s." : "."), Color.Crimson);
                        }
                    }
                }

                if (ActionID == "Teleport") { 
                    if (player.GetRegion() == "Tutorial Island") { 
                        player.NavLoc = "TI_Main";
                        GameLoop.WTN.Log.AddMessage("The pull of the island distorts your magic and you appear in the center of Tutorial Island.", Color.MediumPurple);
                    } else {
                        if (GameLoop.WTN.Atlas.TryGetValue(MiscString, out Location? dest)) { 
                            player.NavLoc = MiscString;
                            if (MiscInt != 1)
                                GameLoop.WTN.Log.AddMessage("You teleport to " + dest.DisplayName + ".", Color.MediumPurple);
                            else
                                GameLoop.WTN.Log.AddMessage("You travel to " + dest.DisplayName + ".", Color.MediumPurple);
                        } else {
                            GameLoop.WTN.Log.AddMessage("Destination does not exist.", Color.Crimson);
                        } 
                    } 
                }

                if (ActionID == "TransmuteBones") {
                    bool anyBones = false;
                    int extras = 0;
                    foreach (var kv in player.Inventory) {
                        if (new List<string>() { "bonesRegular", "bonesWolf", "bonesBat", "bonesBig", "bonesBleached", "bonesBurnt", "bonesJogre", "bonesMonkey", "mtaBone1", "mtaBone2", "mtaBone3", "mtaBone4", "bonesAlan" }.Contains(kv.ID) && !kv.Noted) {
                            if (kv.ID.Contains("mtaBone")) {
                                int qty = 0; 
                                                    
                                extras += qty;
                            }
                            kv.ID = "fruit" + MiscString;
                            anyBones = true; 
                        }
                    }

                    if (extras > 0) {
                        if (GameLoop.WTN.ItemLibrary.TryGetValue("fruit" + MiscString, out Item? banan) && banan != null) {
                            player.TryPickup(new Item(banan), extras);
                        }
                    }

                    if (anyBones) {
                        if (GameLoop.WTN.SpellLibrary.TryGetValue(MiscString2, out Spell? bones) && bones != null) {
                            bones.Cast(player, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                            string plural = (MiscString == "Banana" ? "Bananas" : "Peaches");
                            GameLoop.WTN.Log.AddMessage("You cast Bones to " + plural + " and all your bones become " + plural.ToLower() + ".", Color.MediumPurple);
                        }
                    } else {
                        GameLoop.WTN.Log.AddMessage("You have no applicable bones to transmute.", Color.Crimson);
                    }
                }

                if (ActionID == "SuperheatItem") {
                    if (GameLoop.WTN.ProcessingStations.TryGetValue("Furnace", out ProcessingStation? furnace) && furnace != null) {
                        furnace.LastWorked = "";
                        if (furnace.TryProcessItem(player, GameLoop.WTN.Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills)) {
                            if (GameLoop.WTN.SpellLibrary.TryGetValue(MiscString2, out Spell? superheat) && superheat != null) {
                                superheat.Cast(player, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                GameLoop.WTN.Log.AddMessage("You cast Superheat Item and smelt an ore mix into a bar.", Color.MediumPurple);
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage("You have no ore mixes you have the smithing level to be able to smelt.", Color.Crimson);
                        }
                    }
                }

                if (ActionID == "EnchantItem") {
                    List<string> types = [ "sapphire/opal", "emerald/jade", "ruby/red topaz", "diamond", "dragonstone", "onyx", "zenyte" ];
                    if (GameLoop.WTN.ProcessingStations.TryGetValue("Level " + MiscInt + " Enchanter", out ProcessingStation? enchant) && enchant != null) {
                        enchant.LastWorked = "";
                        if (enchant.TryProcessItem(player, GameLoop.WTN.Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills)) {
                            if (GameLoop.WTN.SpellLibrary.TryGetValue(MiscString2, out Spell? spell)) {
                                spell.Cast(player, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                GameLoop.WTN.Log.AddMessage("You enchant a piece of " + types[MiscInt - 1] + " jewellery.", Color.MediumPurple);
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage("You have no unenchanted " + types[MiscInt - 1] + " jewellery to enchant.", Color.Crimson);
                        }
                    } 
                }

                if (ActionID == "LeptocClean") { 
                    Helper.AlterWorldState("LeptocTimesCleaned", "add", 1); 

                    GameLoop.WTN.Log.AddMessage("You tidy up the room.", Color.Yellow);

                    if (Helper.ReadWorldState("LeptocTimesCleaned") == 3) { 
                        GameLoop.WTN.Log.AddMessage("Wait, why am I actually cleaning? This was just an excuse to get into the mansion.", Color.Yellow);
                    }
                }

                if (ActionID == "SummonTempMonster") {
                    if (GameLoop.WTN.Atlas.TryGetValue(player.NavLoc, out Location? curr) && curr != null) {
                        if (GameLoop.WTN.MonsterLibrary.TryGetValue(MiscString, out AreaMonster? mon)) { 
                            for (int i = 0; i < MiscInt; i++) { 
                                Log.AddMessage(MiscString2 + " summons a" + (Helper.VowelStart(mon.Name.ToLower()) ? "n ": " ") + mon.Name.ToLower() + "!", Color.Crimson);
                                AreaMonster summonCopy = Helper.Clone(mon);
                                summonCopy.Temporary = true;
                                curr.MonstersHere.Add(summonCopy);
                            }
                        }
                    }
                }
            }
        }
    }
}
