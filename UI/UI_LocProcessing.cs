using SadConsole.Input; 
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.Managers;
using Key = SadConsole.Input.Keys;

namespace WorldtreeNexus.UI {
    public static class UI_LocProcessing {  
        public static Rectangle ActivityRect = new Rectangle(new Point(111, 10), new Point(147, 34));
        public static int ActivityItemTop = 0; 
        public static bool WithdrawingNotes = false;

        public static void DrawProcessing(Location curr, Player player, UI_EmbeddedMini mini, int resourceX, int resourceY, MessageLog Log, PlayerOwnedHome? home) { 
            Point mousePos = new MouseScreenObjectState(mini.Con, GameHost.Instance.Mouse).CellPosition; 

            mini.Con.Print(resourceX + 2, resourceY++, "Processing Stations Here");

            int startY = resourceY;
                     
            for (int i = 0; i < curr.ProcessingStations.Count; i++) {
                if (GameLoop.WTN.ProcessingStations.ContainsKey(curr.ProcessingStations[i])) {
                    ProcessingStation station = GameLoop.WTN.ProcessingStations[curr.ProcessingStations[i]];
                    mini.Con.Print(resourceX + 2, resourceY, "|");  

                    mini.Con.PrintClickable(resourceX + 4, resourceY, station.Name, () => { 
                        station.LastWorked = "";
                        station.TryProcessItem(player, Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills); 

                        if (station.OpensUI) {
                            if (station.Name == "Trade Hall") {
                                if (player.TradeHallLimit != 2) {
                                    ExtraWindows.TradeHall.IsVisible = true;
                                    ExtraWindows.THCollectOnly = false;
                                    ExtraWindows.THSellView = null;
                                    ExtraWindows.THListView = null;
                                    ExtraWindows.THSearchFilter = "";
                                    ExtraWindows.THFilterSave = "";
                                    ExtraWindows.UpdateTHItems();
                                } else {
                                    Log.AddMessage("You are not permitted to use the Trade Hall.");
                                }
                            } else if (station.Name == "Trade Hall Collection") {
                                if (player.TradeHallLimit != 2) {
                                    ExtraWindows.TradeHall.IsVisible = true;
                                    ExtraWindows.THCollectOnly = true;
                                    ExtraWindows.THSellView = null;
                                    ExtraWindows.THListView = null;
                                    ExtraWindows.THInventory = false;
                                    ExtraWindows.THSearchFilter = "";
                                    ExtraWindows.THFilterSave = "";
                                    ExtraWindows.THItems = new();
                                } else { 
                                    Log.AddMessage("You are not permitted to use the Trade Hall.");
                                }
                            } else {
                                ExtraWindows.CraftingMenu.IsVisible = true;
                                ExtraWindows.CraftingType = station.Name;
                                ExtraWindows.CraftingMaxLevel = station.MaxLevel;
                            }
                        }
                    });

                    if (!station.OpensUI) {
                        mini.Con.PrintClickable(resourceX + 2, resourceY, new ColoredString(236.AsString(), Color.MediumPurple, Color.Black), () => {
                            station.LastWorked = "";

                            while (station.TryProcessItem(player, Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills)) {

                            }
                        });
                    }

                    resourceY++;
                }
                else {
                    mini.Con.Print(resourceX + 2, resourceY, "|");
                    mini.Con.Print(resourceX + 4, resourceY++, curr.ProcessingStations[i], Color.DarkSlateGray);
                }
            }

            for (int i = curr.TempStations.Count - 1; i >= 0; i--) { 
                ProcessingStation station = curr.TempStations[i];

                int secondsSinceMade = (int) Math.Floor((station.TimeMade + (station.TimeLeft * 60000)) - Helper.Time()) / 1000;

                mini.Con.Print(resourceX + 2, resourceY, "|");
                mini.Con.PrintClickable(resourceX + 4, resourceY++, station.Name + " [" + secondsSinceMade + "]", () => { 
                    station.LastWorked = "";
                    station.TryProcessItem(player, Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills); 
                });

                if (station.TimeLeft != -1) {
                    if (station.TimeMade + (station.TimeLeft * 60000) <= Helper.Time()) {
                        if (GameLoop.WTN.ItemLibrary.ContainsKey(station.ItemOnExpire)) {
                            GameLoop.WTN.TryPlaceItem(player.NavLoc, new(new(GameLoop.WTN.ItemLibrary[station.ItemOnExpire])));
                        }

                        curr.TempStations.RemoveAt(i); 
                    }
                }
            }

            if (home != null) { // TODO: Just a bookmark, delete this once POHs are done and this is definitely working
                foreach (var obj in home.Rooms[MinigameManager.POH_ViewingRoom].BuiltObjects) {
                    if (GameLoop.WTN.POH_ObjectLib.TryGetValue(obj, out POH_Object? actual) && actual != null) {
                        if (actual.AddsStation != "") { 
                            if (GameLoop.WTN.ProcessingStations.ContainsKey(actual.AddsStation)) {
                                ProcessingStation station = GameLoop.WTN.ProcessingStations[actual.AddsStation];
                                mini.Con.Print(resourceX + 2, resourceY, "|");  

                                mini.Con.PrintClickable(resourceX + 4, resourceY, station.Name, () => { 
                                    station.LastWorked = "";
                                    station.TryProcessItem(player, Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills); 

                                    if (station.OpensUI) {
                                        ExtraWindows.CraftingMenu.IsVisible = true;
                                        ExtraWindows.CraftingType = station.Name; 
                                        ExtraWindows.CraftingMaxLevel = station.MaxLevel;
                                    }
                                });

                                if (!station.OpensUI) {
                                    mini.Con.PrintClickable(resourceX + 2, resourceY, new ColoredString(236.AsString(), Color.MediumPurple, Color.Black), () => {
                                        station.LastWorked = "";

                                        while (station.TryProcessItem(player, Log, GameLoop.WTN.ItemLibrary, SidebarManager.RecentlyTrainedSkills)) {

                                        }
                                    });
                                }

                                resourceY++;
                            }
                            else {
                                mini.Con.Print(resourceX + 2, resourceY, "|");
                                mini.Con.Print(resourceX + 4, resourceY++, actual.AddsStation, Color.DarkSlateGray);
                            }
                        }
                    }
                }
            } 

            if (resourceY == startY) {
                mini.Con.Print(resourceX + 2, resourceY, "|");
                mini.Con.Print(resourceX + 4, resourceY++, "(no stations here)", Color.DarkSlateGray);
            }
        }
    }
}
