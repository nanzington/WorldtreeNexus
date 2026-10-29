using System;
using System.Collections.Generic;
using System.Text;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.Managers;
using static SadConsole.UI.Controls.Table.TableCells.Layout;

namespace WorldtreeNexus.UI {
    public static class UI_LocResources {  

        public static void DrawResources(Location curr, Player player, UI_EmbeddedMini mini, int resourceX, int resourceY, MessageLog Log, PlayerOwnedHome? home) { 
            mini.Con.Print(resourceX + 2, resourceY++, "Resource Nodes Here");
            int startY = resourceY;

            if (curr.LocalGathers.Where(o => (o.CanGather(player) == "" && !o.ShowAnyways) || o.ShowAnyways).ToList().Count > 0) {
                for (int i = 0; i < curr.LocalGathers.Count; i++) {
                    GatheringTile tile = curr.LocalGathers[i];
                    mini.Con.Print(resourceX + 2, resourceY, "|");

                    Color interact = Color.White;

                    if (tile.LastGathered + (tile.RestockTime * 1000) < Helper.Time() || tile.LastGathered == 0) {
                        if (tile.CanGather(player) == "") {
                            interact = Color.Green;
                        }
                        else {
                            interact = Color.Crimson;
                        }

                        mini.Con.PrintClickable(resourceX + 4, resourceY++, new ColoredString(tile.InteractVerb + " " + tile.Name, interact, Color.Black), () => { tile.Gather(player, Log, GameLoop.WTN.ItemLibrary, curr, SidebarManager.RecentlyTrainedSkills); });
                    }
                    else {
                        int secondsToRestock = (int)Math.Floor((tile.LastGathered + (tile.RestockTime * 1000) - Helper.Time()) / 1000f);
                        mini.Con.Print(resourceX + 4, resourceY++, tile.InteractVerb + " " + tile.Name + " [" + secondsToRestock + "]");
                    }
                }
            }
             
            if (home != null) {
                foreach (var obj in home.Rooms[MinigameManager.POH_ViewingRoom].BuiltObjects) {
                    if (GameLoop.WTN.POH_ObjectLib.TryGetValue(obj, out POH_Object? actual) && actual != null) {
                        if (actual.AddsGather != "") { 
                            if (GameLoop.WTN.GatherSpots.TryGetValue(actual.AddsGather, out GatheringTile? tile) && tile != null) { 
                                mini.Con.Print(resourceX + 2, resourceY, "|");

                                Color interact = Color.White;

                                if (tile.LastGathered + (tile.RestockTime * 1000) < Helper.Time() || tile.LastGathered == 0) {
                                    if (tile.CanGather(player) == "") {
                                        interact = Color.Green;
                                    }
                                    else {
                                        interact = Color.Crimson;
                                    }

                                    mini.Con.PrintClickable(resourceX + 4, resourceY++, new ColoredString(tile.InteractVerb + " " + tile.Name, interact, Color.Black), () => { tile.Gather(player, Log, GameLoop.WTN.ItemLibrary, curr, SidebarManager.RecentlyTrainedSkills); });
                                }
                                else {
                                    int secondsToRestock = (int)Math.Floor((tile.LastGathered + (tile.RestockTime * 1000) - Helper.Time()) / 1000f);
                                    mini.Con.Print(resourceX + 4, resourceY++, tile.InteractVerb + " " + tile.Name + " [" + secondsToRestock + "]");
                                }
                            } else { 
                                mini.Con.Print(resourceX + 2, resourceY++, "|" + actual.AddsGather, Color.DarkSlateGray);
                            } 
                        }
                    }
                }
            }

            if (startY == resourceY) {
                mini.Con.Print(resourceX + 2, resourceY, "|");
                mini.Con.Print(resourceX + 4, resourceY++, "(no resources here)", Color.DarkSlateGray);
            } 
        }
    }
}
