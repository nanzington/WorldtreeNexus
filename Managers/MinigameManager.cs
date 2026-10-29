using System;
using System.Collections.Generic;
using System.Text;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.Hardcodes;
using WorldtreeNexus.UI;

namespace WorldtreeNexus.Managers {
    public static class MinigameManager {  
        public static int MH_Tier = -1; 
        public static int MH_ScrollTop = 0;
        public static List<string> MH_Planks = [ "plankPoplar", "plankElm", "plankWalnut", "plankHolly", "plankAcacia", "plankBirch", "plankHickory", "plankBloodwood", "plankCamatillo", "plankKatalox" ];
        
        public static int POH_ViewingRoom = 0;
        public static string POH_Menu = "Overview";
        public static string POH_Submenu = "";
        public static bool POH_BuildMode = false;
        public static string POH_Typing = ""; 
        public static List<POH_Object> POH_PossibleObjs = new();
        public static int POH_ScrollTop = 0;
        public static bool POH_OnlyBuildable = false;
        

        public static void Draw(UI_EmbeddedMini mini, Player player, int resX, int resY) { 
            if (GameLoop.WTN.Atlas.TryGetValue(player.NavLoc, out Location? curr) && curr != null) {
                string minigame = curr.MinigameID;
                 
            
                if (curr.ID == player.CozyDestID && player.CozyContractSpots.Count > 0) {
                    if (MH_Tier == -1) { MH_Tier = player.GetEffectiveSkillLevel("Construction") / 10; }
                    int level = Math.Clamp(MH_Tier * 10, 1, 90);
                    mini.Con.Print(resX + 4, resY, (GameLoop.WTN.ResolveItemName(MH_Planks[MH_Tier]) + " (" + level + " Con)").Align(HorizontalAlignment.Center, 31));
                    mini.Con.PrintClickable(resX + 1, resY, new ColoredString("<--", MH_Tier > 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { MH_Tier = Math.Clamp(MH_Tier - 1, 0, 9); });
                    mini.Con.PrintClickable(resX + 35, resY, new ColoredString("-->", MH_Tier < 9 ? Color.White : Color.DarkSlateGray, Color.Black), () => { MH_Tier = Math.Clamp(MH_Tier + 1, 0, 9); });
                    
                    mini.Con.DrawLine(new Point(resX + 1, resY + 1), new Point(resX + 37, resY + 1), 196, Color.White);
                    
                    int spaces = 34 - resY - 2;

                    if (player.CozyContractSpots.Count > spaces) {
                        if (Helper.ScrolledDown()) { MH_ScrollTop = Helper.QuantitySelector(MH_ScrollTop, player.CozyContractSpots.Count - spaces); }
                        if (Helper.ScrolledUp()) { MH_ScrollTop = Helper.QuantitySelector(MH_ScrollTop, player.CozyContractSpots.Count - spaces, true); }
                    } else {
                        MH_ScrollTop = 0;
                    }
                    
                    for (int i = MH_ScrollTop; i < player.CozyContractSpots.Count && i < MH_ScrollTop + spaces; i++) {
                        M_CozyCottagesHotspot hot = player.CozyContractSpots[i];
                        List<string> mats = hot.NeededItems(MH_Tier);

                        mini.Con.Print(resX + 1, resY + (i - MH_ScrollTop) + 2, Helper.Checkmark(hot.Repaired));
                        mini.Con.PrintClickable(resX + 3, resY + (i - MH_ScrollTop) + 2, new ColoredString("?", Color.MediumPurple, Color.Black), () => {
                            string build = "To repair this: ";

                            List<string> mats = hot.NeededItems(MH_Tier);

                            foreach (var str in mats) {
                                string[] split = str.Split(",");

                                if (build != "To repair this: ") {
                                    build += ", ";
                                }

                                build += split[1] + "x " + GameLoop.WTN.ResolveItemName(split[0]);
                            }

                            build += ". Hammer, saw.";
                            
                            GameLoop.WTN.Log.AddMessage(build, Color.SandyBrown);
                        });

                        if (!hot.Repaired) {
                            mini.Con.PrintClickable(resX + 5, resY + (i - MH_ScrollTop) + 2, new ColoredString(hot.Name, player.HasAllItems(mats) ? Color.Green : Color.Crimson, Color.Black), () => {
                                if (player.HasAllItems(mats)) {
                                    if (player.HasAllItems(["hammer,1", "saw,1"])) {
                                        player.ConsumeItems(mats);
                                        hot.Repaired = true;
                                    } else { 
                                        GameLoop.WTN.Log.AddMessage("You have all the materials, but need a hammer and saw to repair that.", Color.Crimson);
                                    }
                                } else {
                                    GameLoop.WTN.Log.AddMessage("You are missing some materials to repair that.", Color.Crimson);
                                }
                            });
                        } else {
                            mini.Con.Print(resX + 5, resY + (i - MH_ScrollTop) + 2, hot.Name);
                        }
                    }

                    return;
                }

                if (curr.PlayerHomeHere != "") {
                    if (player.Homes.TryGetValue(curr.PlayerHomeHere, out PlayerOwnedHome? home) && home != null) {
                        mini.Con.Print(resX + 2, resY, "Home Management Menu", Color.White);
                        mini.Con.PrintClickable(resX + 30, resY, new ColoredString("(BUILD)", POH_BuildMode ? Color.White : Color.DarkSlateGray, Color.Black), () => { POH_BuildMode = !POH_BuildMode; });
                        mini.Con.DrawLine(new Point(resX + 1, resY + 1), new Point(resX + 37, resY + 1), 196, Color.White);

                        POH_ViewingRoom = Math.Clamp(POH_ViewingRoom, 0, home.Rooms.Count - 1);
                        
                        if (!POH_BuildMode) { // Not in build mode, all we can really do is display objects here and allow them to be activated
                            mini.Con.Print(resX + 2, resY + 2, "Objects Here");

                            if (home.Rooms[POH_ViewingRoom].BuiltObjects.Count > 0) {
                                int pObj = resY + 3;

                                foreach (var obj in home.Rooms[POH_ViewingRoom].BuiltObjects) {
                                    if (GameLoop.WTN.POH_ObjectLib.TryGetValue(obj, out POH_Object? actual) && actual != null) {
                                        mini.Con.Print(resX + 2, pObj, "|");
                                        mini.Con.PrintClickable(resX + 1, pObj, new ColoredString("?", Color.MediumPurple, Color.Black), () => {
                                            if (actual.Examine != "") { GameLoop.WTN.Log.AddMessage(actual.Examine, Color.SandyBrown); }
                                            else { GameLoop.WTN.Log.AddMessage("Just a" + (Helper.VowelStart(actual.Name.ToLower()) ? "n " : " ") + actual.Name.ToLower(), Color.SandyBrown); }
                                        });

                                        if (actual.ActivateText != "" || actual.Activation.Count > 0) {
                                            mini.Con.PrintClickable(resX + 4, pObj++, actual.GetName(), () => {
                                                if (actual.ActivateText != "") { GameLoop.WTN.Log.AddMessage(actual.ActivateText, Color.SandyBrown); }

                                                foreach (var act in actual.Activation) { act.Execute(); }
                                            });
                                        } else {
                                            mini.Con.Print(resX + 4, pObj++, actual.GetName());
                                        }
                                    }
                                }
                            } else { 
                                mini.Con.Print(resX + 2, resY + 3, "| (no objects built here)", Color.DarkSlateGray);
                            }
                        } else { // In build mode, allow players to do some stuff
                            if (POH_Menu == "Overview") { 
                                mini.Con.Print(resX + 2, resY + 2, "Select a Menu");

                                mini.Con.PrintClickable(resX + 2, resY + 3, "| Room Management", () => { POH_Menu = "Rooms"; POH_Submenu = ""; });
                                mini.Con.PrintClickable(resX + 2, resY + 4, "| Add/Remove Objects", () => { POH_Menu = "Objects"; POH_Submenu = ""; });
                            } else if (POH_Menu == "Rooms") {
                                int currentRooms = home.Rooms.Count;
                                int maxRooms = player.GetSkillTier("Construction");
                                if (POH_Submenu != "AddRoom") {
                                    mini.Con.PrintClickable(resX + 31, resY + 2, new ColoredString("(BACK)", Color.White, Color.Black), () => { POH_Menu = "Overview"; });
                                    mini.Con.Print(resX + 2, resY + 2, "Room Count: " + currentRooms + " / " + maxRooms);

                                    int roomY = resY + 3; 
                                    for (int count = 0; count < home.Rooms.Count; count++) { 
                                        string nameDisp = (home.Rooms[count].RoomName != "" ? home.Rooms[count].RoomName : home.Rooms[count].RoomType);
                                        if (POH_Typing == "roomName" + count && home.Rooms[count].RoomName == "") { nameDisp = "(type a name)"; }

                                        // let player rename rooms to whatever they like
                                        mini.Con.PrintStringField(resX + 2, roomY, "| " + nameDisp.Align(HorizontalAlignment.Left, 27) + " (" + home.Rooms[count].BuiltObjects.Count + "/" + home.Rooms[count].MaxObjects() + ")", ref home.Rooms[count].RoomName, ref POH_Typing, "roomName" + count, true);
                                        
                                        bool shouldBreak = false;
                                        mini.Con.PrintClickable(resX + 1, roomY++, new ColoredString("X", Color.Crimson, Color.Black), () => {
                                            if (count == POH_ViewingRoom) {
                                                GameLoop.WTN.Log.AddMessage("You probably shouldn't destroy the room you're standing in.", Color.Crimson);
                                            } else if (home.Rooms.Count == 1) { 
                                                GameLoop.WTN.Log.AddMessage("You probably shouldn't destroy the last room in your home.", Color.Crimson);
                                            } else {
                                                if (Helper.KeyDown(SadConsole.Input.Keys.Space)) { // hold space to confirm
                                                    home.Rooms.RemoveAt(count); 

                                                    if (count < POH_ViewingRoom) {
                                                        POH_ViewingRoom--;
                                                    }

                                                    Math.Clamp(POH_ViewingRoom, 0, home.Rooms.Count);

                                                    shouldBreak = true;
                                                } else { 
                                                    GameLoop.WTN.Log.AddMessage("If you really want to destroy the room, hold SPACE. No resources or gold will be returned to you.", Color.Crimson);
                                                }
                                            }
                                        }); 

                                        if (shouldBreak) { break; }
                                    }

                                    
                                    mini.Con.PrintClickable(resX + 2, roomY++, new ColoredString("(Add a Room)", currentRooms < maxRooms ? Color.Green : Color.DarkSlateGray, Color.Black), () => { POH_Submenu = "AddRoom"; });
                                } else { 
                                    mini.Con.PrintClickable(resX + 31, resY + 2, new ColoredString("(BACK)", Color.White, Color.Black), () => { POH_Submenu = ""; });
                                    mini.Con.Print(resX + 2, resY + 2, "Add Which?");

                                    int printY = resY + 3;
                                    foreach (var roomType in HardcodedPOHObjects.RoomTypes) {
                                        bool canBuild = player.GetEffectiveSkillLevel("Construction") >= roomType.LevelToBuy &&
                                                      player.GoldTotal() >= roomType.CostToBuy &&
                                                      currentRooms < maxRooms;
                                        mini.Con.PrintClickable(resX + 2, printY++, new ColoredString("| ") + new ColoredString(roomType.RoomType, canBuild ? Color.White : Color.Crimson, Color.Black) + new ColoredString(" [" + roomType.CostToBuy + "]", Color.Goldenrod, Color.Black), () => {
                                            if (canBuild) {
                                                player.TakeGold(roomType.CostToBuy);
                                                home.Rooms.Add(new(roomType));
                                                GameLoop.WTN.Log.AddMessage("You add a " + roomType.RoomType.ToLower() + " to your home.", Color.Lime);
                                            } else {
                                                GameLoop.WTN.Log.AddMessage("Need " + roomType.LevelToBuy + " Construction, " + roomType.CostToBuy + "gp, and a room slot open to build that.", Color.Crimson);
                                            }
                                        });
                                    }
                                }
                            } else if (POH_Menu == "Objects") {
                                POH_Room room = home.Rooms[POH_ViewingRoom];
                                if (POH_Submenu == "") {
                                    mini.Con.PrintClickable(resX + 31, resY + 2, new ColoredString("(BACK)", Color.White, Color.Black), () => { POH_Menu = "Overview"; });
                                    mini.Con.Print(resX + 2, resY + 2, "Objects Built Here");
                                     
                                    List<string> hotspots = new(room.HotspotData);

                                    int roomY = resY + 3;
                                    for (int count = 0; count < room.BuiltObjects.Count; count++) {
                                        if (GameLoop.WTN.POH_ObjectLib.TryGetValue(room.BuiltObjects[count], out POH_Object? obj) && obj != null) {
                                            hotspots.Remove(obj.HotspotType);
                                            mini.Con.Print(resX + 2, roomY, "| " + obj.GetName());

                                            bool shouldBreak = false;
                                            mini.Con.PrintClickable(resX + 1, roomY++, new ColoredString("X", Color.Crimson, Color.Black), () => {
                                                if (Helper.KeyDown(SadConsole.Input.Keys.Space)) { // hold space to confirm
                                                    if (obj.SetsPatch != "") {
                                                        if (room.Patch.SeedPlanted == "") {
                                                            room.Patch.PatchType = "";
                                                            room.BuiltObjects.RemoveAt(count);
                                                            shouldBreak = true;
                                                        } else {
                                                            GameLoop.WTN.Log.AddMessage("There's something growing in that patch right now. You should clear it out or let it grow before destroying it.", Color.Crimson);
                                                        }
                                                    } else { 
                                                        room.BuiltObjects.RemoveAt(count);
                                                        shouldBreak = true;
                                                    }
                                                } else {
                                                    GameLoop.WTN.Log.AddMessage("If you really want to destroy the object, hold SPACE. No resources or gold will be returned to you.", Color.Crimson);
                                                }
                                            });

                                            if (shouldBreak) { break; }
                                        }
                                    }

                                    if (room.BuiltObjects.Count == 0) {
                                        mini.Con.Print(resX + 2, roomY++, "| (no objects built here)", Color.DarkSlateGray);
                                    }

                                    roomY++;

                                    mini.Con.Print(resX + 2, roomY++, "Empty Hotspots Here");

                                    for (int hot = 0; hot < hotspots.Count; hot++) {
                                        mini.Con.PrintClickable(resX + 2, roomY++, "| " + hotspots[hot], () => { POH_Submenu = hotspots[hot]; POH_UpdateObjs(hotspots[hot]); });
                                    }

                                    if (hotspots.Count == 0 && !room.EverFinished) {
                                        room.EverFinished = true;
                                    }
                                } else { // Clicked an open hotspot probably or the data is malformed 
                                    mini.Con.PrintClickable(resX + 31, resY + 2, new ColoredString("(BACK)", Color.White, Color.Black), () => { POH_Submenu = ""; });
                                    mini.Con.PrintClickable(resX + 14, resY + 2, new ColoredString("(ONLY BUILDABLE)", POH_OnlyBuildable ? Color.White : Color.DarkSlateGray, Color.Black), () => { POH_OnlyBuildable = !POH_OnlyBuildable; POH_UpdateObjs(POH_Submenu); });
                                    mini.Con.Print(resX + 2, resY + 2, "Build What?");

                                    int printY = resY + 3;

                                    for (int ob = POH_ScrollTop; ob < POH_PossibleObjs.Count && printY < 38; ob++) {
                                        bool hasMats = player.HasAllItems(POH_PossibleObjs[ob].MaterialsNeeded);
                                        bool hasTools = player.HasAllItems(POH_PossibleObjs[ob].ToolsNeeded);
                                        bool meetsAllReqs = true;

                                        foreach (var req in POH_PossibleObjs[ob].RequirementsToBuild) {
                                            if (!req.CheckRequirement(player, false, false)) {
                                                meetsAllReqs = false;
                                            }
                                        }

                                        if (!hasMats || !hasTools) { meetsAllReqs = false; }

                                        ColoredString name = meetsAllReqs ? POH_PossibleObjs[ob].GetName() : new ColoredString(POH_PossibleObjs[ob].Name, Color.Crimson, Color.Black);

                                        mini.Con.Print(resX + 2, printY, "|", Color.White);
                                        mini.Con.PrintClickable(resX + 4, printY, new ColoredString("?", Color.MediumPurple, Color.Black), () => { POH_PrintReqs(POH_PossibleObjs[ob], hasMats, hasTools, meetsAllReqs); });
                                        mini.Con.PrintClickable(resX + 6, printY++, name, () => {
                                            if (meetsAllReqs) {
                                                player.ConsumeItems(POH_PossibleObjs[ob].MaterialsNeeded);
                                                player.TryGrantExp("Construction", POH_PossibleObjs[ob].ExpGiven, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                                room.BuiltObjects.Add(POH_PossibleObjs[ob].Name);

                                                if (POH_PossibleObjs[ob].SetsPatch != "") {
                                                    room.Patch.PatchType = POH_PossibleObjs[ob].SetsPatch;
                                                }

                                                POH_Submenu = "";

                                                GameLoop.WTN.Log.AddMessage("You built a" + (Helper.VowelStart(POH_PossibleObjs[ob].Name.ToLower()) ? "n ": " ") + POH_PossibleObjs[ob].Name.ToLower() + ".", Color.SandyBrown);
                                            } else {
                                                POH_PrintReqs(POH_PossibleObjs[ob], hasMats, hasTools, meetsAllReqs);
                                            }
                                        });
                                    } 

                                    if (POH_PossibleObjs.Count == 0) {
                                        mini.Con.Print(resX + 2, printY++, "| (no items buildable)", Color.DarkSlateGray);
                                    }
                                }
                            }

                            int finishCount = 0;
                            foreach (var room in home.Rooms) {
                                if (room.EverFinished) { finishCount++; }
                            }

                            if (home.MaxFinishedRooms < finishCount) {
                                home.MaxFinishedRooms++;
                                int exp = (player.GetSkillTier("Construction") * 30) * 20;
                                GameLoop.WTN.Log.AddMessage("You have fully furnished " + finishCount + " rooms here, and are granted " + String.Format($"{exp:n0}") + " Construction experience.", Color.Lime); 
                            }
                        }
                    }

                    return;
                }
                
                
                
                mini.Con.Print(resX + 2, resY, "Minigames Here", Color.White);
                mini.Con.Print(resX + 2, resY + 1, "| (no minigame active)", Color.DarkSlateGray);
            }
        }

        public static bool AnyMinigame(Player player) { 
            if (GameLoop.WTN.Atlas.TryGetValue(player.NavLoc, out Location? curr) && curr != null) {
                string minigame = curr.MinigameID;

                if (minigame != "") { return true; } 
                if (curr.ID == player.CozyDestID && player.CozyContractSpots.Count > 0) { return true; }
                if (curr.PlayerHomeHere != "")  { return true; }
            }

            return false;
        } 
        
        public static void MH_GetContract() {
            if (GameLoop.WTN.Atlas.TryGetValue(GameLoop.WTN.player.NavLoc, out Location? curr)) { 
                List<Location> possibleDestinations = GameLoop.WTN.Atlas.Values.Where(o => (o.Region == curr.Region && o.CCHotspots.Count > 0)).ToList();

                if (possibleDestinations.Count > 0) {
                    Location dest = possibleDestinations[0]; 
                    if (possibleDestinations.Count > 1) { dest = possibleDestinations[GameLoop.rand.Next(possibleDestinations.Count)]; }

                    List<M_CozyCottagesHotspot> possibleSpots = new();

                    foreach (var str in dest.CCHotspots) {
                        if (GameLoop.WTN.M_HotspotLib.TryGetValue(str, out M_CozyCottagesHotspot? spot) && spot != null) {
                            possibleSpots.Add(new(spot));
                        }
                    }

                    if (possibleSpots.Count < 5) {
                        return; // If there aren't a full 5 spots for a contract don't even bother, no free experience here
                    }

                    possibleSpots.Shuffle();

                    for (int i = 0; i < possibleSpots.Count; i++) {
                        if (i < 5) {
                            possibleSpots[i].Repaired = false;
                        } else {
                            possibleSpots[i].Repaired = true;
                        }
                    }

                    possibleSpots = possibleSpots.OrderBy(o => o.Name).ToList();
                    GameLoop.WTN.player.CozyContractSpots = possibleSpots;
                    GameLoop.WTN.player.CozyDestID = dest.ID;
                }
            } 
        }    
    
        public static void POH_UpdateObjs(string objType) {
            if (POH_PossibleObjs == null) { POH_PossibleObjs = new(); }
            POH_PossibleObjs.Clear();

            POH_PossibleObjs = GameLoop.WTN.POH_ObjectLib.Values.Where(o => o.HotspotType == objType && (!POH_OnlyBuildable || o.CanBuild())).ToList(); 
        } 
        
        public static void POH_PrintReqs(POH_Object obj, bool hasMats, bool hasTools, bool meetsAll) {
            GameLoop.WTN.Log.AddMessage("Requirements to build " + obj.Name.ToLower() + ": ", meetsAll ? Color.Lime : Color.Crimson);

            string mats = "| Materials: "; 
            foreach (var mat in obj.MaterialsNeeded) {
                string[] split = mat.Split(",");

                if (mats != "| Materials: ") { mats += ", "; }

                mats += (split.Length > 1 ? split[1] + "x " : " ") + GameLoop.WTN.ResolveItemName(split[0]).ToLower();
            } 
            mats += "."; 
            GameLoop.WTN.Log.AddMessage(mats, hasMats ? Color.Lime : Color.Crimson);

            string tools = "| Tools: "; 
            foreach (var tool in obj.ToolsNeeded) {
                string[] split = tool.Split(",");

                if (tools != "| Tools: ") { tools += ", "; }

                tools += (split.Length > 1 ? split[1] + "x " : " ") + GameLoop.WTN.ResolveItemName(split[0]).ToLower();
            } 
            tools += "."; 
            GameLoop.WTN.Log.AddMessage(tools, hasTools ? Color.Lime : Color.Crimson);

            foreach (var req in obj.RequirementsToBuild) { 
                GameLoop.WTN.Log.AddMessage("| " + req.GetSummary(), req.CheckRequirement(GameLoop.WTN.player, false) ? Color.Lime : Color.Crimson);
            }
        }
        
    }
}
