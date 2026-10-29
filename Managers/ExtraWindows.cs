using GoRogue;
using GoRogue.DiceNotation.Terms;
using SadConsole.EasingFunctions;
using SadConsole.Input;
using SadConsole.UI;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;
using Key = SadConsole.Input.Keys;
using Rectangle = SadRogue.Primitives.Rectangle;

namespace WorldtreeNexus.Managers {
    public static class ExtraWindows {
        public static Window CollectionLog;
        public static string CollectionID = "";
        public static int CollectionDropTop = 0;
        public static int CollectionSideTop = 0;
        public static string CollectionCat = "";

        public static Window CraftingMenu;
        public static string CraftingType = "";
        public static string CraftingSubtype = "";
        public static List<CraftRecipe> ActiveRecipes = new();
        public static int CraftingListTop = 0;
        public static int CraftingMaxLevel = 99;

        public static Window Guide;
        public static string GuideTab = "Introduction";
         
        public static Window Quests;
        public static string QuestFilter = "All";
        public static string ViewingQuestID = "";
        public static bool QuestOverview = true;
        public static int QuestBlockScrollTop = 0;
         
        public static Window Compendium;
        public static string CompendiumCat = "Overview";
        public static string CompendiumSubCat = "";
        public static string CompendiumViewingID = "";
        public static string CompendiumViewingID2 = "";
        public static int CompendiumViewingIndex = 0;
        public static int CompendiumViewingIndex2 = 0;
        public static int CompendiumViewingIndex3 = 0; // Basically just for boss phases
        public static int CompendiumSidebarTop = 0;
        public static int CompendiumSourceTop = 0;
        public static int CompendiumDropTop = 0; 
        public static bool CompendiumShowSources = false;
        public static string Filter = "";
        public static string SelectedField = "";


        public static Window Map;
        public static int MapW;
        public static int MapH;
        public static string MapViewing = "";
        public static Color MapLandmark = Color.Turquoise;
        public static Color MapPlayerLoc = Color.Lime;
         
        
        public static Window Debug;
        public static string DebugMenu = "Overview";
        public static int DebugRandomSource = 0;
        public static int DebugAlchemyLevel = 100;

        public static Window Clue;
        public static string CurrentClue = "";

        public static Window Teleport; 
        public static List<string> TeleportDests = new();
        public static ItemWrapper? TeleWrap = null;
        public static bool TeleCostsCharges = false;
        public static bool TeleFairyRing = false;

        public static Window LampMenu; 
        public static List<string> LampSkills = new();
        public static ItemWrapper? LampWrap = null;
        public static int LampAmount = 0;

        public static Window InventoryContainer;
        public static ItemWrapper? ConWrap = null;

        
        public static Window Book;
        public static string BookID = "";
        public static int LeftPage = 0;
         
        public static Window Cutscene;
        public static string CutsceneID = "";
        public static int CutsceneScene = 0;
        public static int CutsceneDialogue = 0;

        public static Window Shop;
        public static string ShopID = "";
        public static int ShopTop = 0;
        public static List<string> ShopItems = new();

        public static Window TradeHall;
        public static bool THCollectOnly = false;
        public static string THBuyID = "";
        public static ItemWrapper? THSellView = null;
        public static THTransaction? THListView = null;
        public static THTransaction? THListPotential = null;
        public static int THPriceEntry = 0;
        public static int THView = 0; // 0: Buying, 1: Selling, 2: Viewing Existing Listing
        public static bool THInventory = false;
        public static string THFilterSave = "";
        public static string THSearchFilter = "";
        public static string THTyping = "";
        public static List<Item> THItems = new();
        public static int THScrollTop = 0;
         
        public static Window CatMenu;

        public static Window HouseMenu;
        public static bool HouseTeleport = false;
        public static bool HouseTablet = false;

        public static Window Compass;
        public static string CompassFilterSaved = "";
        public static string CompassFilterActive = "";
        public static string CompassTyping = "";
        public static int CompassScrollTop = 0;
        public static List<string> CompassRoute = new();
        public static List<Location> CompassFiltered = new();
         
        public static Window Alchemy;
        public static bool AlchemyTraining = false; // Whether or not this was reached from the main menu, if so then override all the inventory checks and such with freeform
        public static string AlchemyTool = "";
        public static int AlchemyLevelMin = 1;
        public static string AlchemyDesc = "";
        public static string AlchemyConfirm = "";
        public static bool AlchemyNeedConfirm = true;
        public static ItemWrapper? AlchemyWrap = null;
        public static AlchemyStats AlchemyTrain = new();
        public static AlchemyStats AlchemyTrainSave = new();
        public static AlchemyStats AlchemyTrainUndo = new();
        public static List<Item> AlchemyItems = new();
        public static int AlchemyItemTop = 0;
        public static string AlchemyItemSearchSaved = "";
        public static string AlchemyItemSearchActive = "";

        
        public static Window Talisman;
        public static Console TalismanHintCon;
        public static Console TalismanCon;
        public static string TalismanDrawing = "";
        public static ItemWrapper? TalismanPaper = null; 
        public static ItemWrapper? TalismanInk = null; 
        public static string TalismanGuide = "Metal";
        public static List<string> TalismanGuideOptions = [ "Metal", "Water", "Wood", "Fire", "Earth", "Destruction", "Restoration", "Alteration", "Mysticism", "Conjuration", "Illusion" ];

        public static bool AnyVisible(string except = "") {
            if (CollectionLog.IsVisible && except != "Collection")
                return true;
            if (CraftingMenu.IsVisible && except != "Crafting")
                return true;
            if (Guide.IsVisible && except != "Guidebook")
                return true;
            if (Quests.IsVisible && except != "Quests")
                return true;
            if (Compendium.IsVisible && except != "Compendium")
                return true;
            if (Map.IsVisible && except != "Map")
                return true;
            if (Debug.IsVisible && except != "Debug")
                return true;
            if (Clue.IsVisible && except != "Clue")
                return true;
            if (Teleport.IsVisible && except != "Teleport")
                return true;
            if (InventoryContainer.IsVisible && except != "InventoryContainer")
                return true;
            if (Book.IsVisible && except != "Book") 
                return true;
            if (Cutscene.IsVisible && except != "Cutscene")
                return true;
            if (Shop.IsVisible && except != "Shop")
                return true;
            if (LampMenu.IsVisible && except != "Lamp") 
                return true;
            if (TradeHall.IsVisible && except != "Trade Hall")
                return true;
            if (CatMenu.IsVisible && except != "Cat Menu")
                return true;
            if (HouseMenu.IsVisible && except != "House Menu")
                return true;
            if (Compass.IsVisible && except != "Compass")
                return true;
            if (Alchemy.IsVisible && except != "Alchemy") 
                return true;
            if (Talisman.IsVisible && except != "Talisman")
                return true;
            
            return false;
        }

        public static void HideAll() {
            CollectionLog.IsVisible = false;
            CraftingMenu.IsVisible = false;
            Guide.IsVisible = false;
            Quests.IsVisible = false;
            Compendium.IsVisible = false;
            Map.IsVisible = false;
            Debug.IsVisible = false;
            Clue.IsVisible = false;
            Teleport.IsVisible = false;
            InventoryContainer.IsVisible = false;
            Book.IsVisible = false;
            Cutscene.IsVisible = false;
            Shop.IsVisible = false;
            LampMenu.IsVisible = false;
            TradeHall.IsVisible = false;
            CatMenu.IsVisible = false;
            HouseMenu.IsVisible = false;
            Compass.IsVisible = false;
            Alchemy.IsVisible = false;
            Talisman.IsVisible = false;
        }

        public static void SetupWindows() {
            CollectionLog = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Collection Log".Align(HorizontalAlignment.Center, 98)};
            Guide = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Guidebook".Align(HorizontalAlignment.Center, 98)};
            CraftingMenu = new(100, 30) { CanDrag = true, Position = new Point(15, 10), Title = "Crafting Menu".Align(HorizontalAlignment.Center, 98)};
            Map = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Map".Align(HorizontalAlignment.Center, 48)};
            Quests = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Quest Log".Align(HorizontalAlignment.Center, 98)};
            Compendium = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Compendium".Align(HorizontalAlignment.Center, 98)};
            Debug = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Debug Menu".Align(HorizontalAlignment.Center, 98)};
            Clue = new(70, 20) { CanDrag = true, Position = new Point(25, 10), Title = "Clue Scroll".Align(HorizontalAlignment.Center, 68)};
            Teleport = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Teleports".Align(HorizontalAlignment.Center, 48)};
            InventoryContainer = new(50, 10) { CanDrag = true, Position = new Point(25, 10), Title = "Inventory COntainer".Align(HorizontalAlignment.Center, 48)}; 
            Book = new(77, 25) { CanDrag = true, Position = new Point(25, 10), Title = "Book".Align(HorizontalAlignment.Center, 75)}; 
            Cutscene = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Cutscene".Align(HorizontalAlignment.Center, 98)};
            Shop = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Shop".Align(HorizontalAlignment.Center, 48)}; 
            LampMenu = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Lamp".Align(HorizontalAlignment.Center, 48)};
            TradeHall = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Trade Hall".Align(HorizontalAlignment.Center, 98)};
            CatMenu = new(20, 7) { CanDrag = true, Position = new Point(25, 10), Title = "Cat Menu".Align(HorizontalAlignment.Center, 18)};
            HouseMenu = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "House Menu".Align(HorizontalAlignment.Center, 48)};
            
            Compass = new(50, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Compass".Align(HorizontalAlignment.Center, 48)};
            
            Alchemy = new(130, 30) { CanDrag = true, Position = new Point(10, 10), Title = "Alchemy".Align(HorizontalAlignment.Center, 98)}; 
            Talisman = new(100, 30) { CanDrag = true, Position = new Point(25, 10), Title = "Talisman".Align(HorizontalAlignment.Center, 98)};
            TalismanCon = new(new CellSurface(12, 12), GameLoop.SquareFont, new Point(12, 12)) { Position = new Point(30, 15)};
            Talisman.Children.Add(TalismanCon);
            TalismanHintCon = new(new CellSurface(10, 5), GameLoop.SquareFont, new Point(12, 12)) { Position = new Point(31, 10)};
            Talisman.Children.Add(TalismanHintCon);
        }

        public static void GuideDraw() {
            Guide.Clear();
            Helper.DrawBox(Guide, 0, 0, 98, 28);
            Guide.Print(2, 0, "[Zero Players Online Guidebook]");
            Guide.DrawLine(new Point(20, 1), new Point(20, 28), 179);

            Guide.PrintClickable(2, 2, new ColoredString("Introduction", GuideTab == "Introduction" ? Color.Yellow : Color.White, Color.Black), () => { GuideTab = "Introduction"; });
            Guide.PrintClickable(2, 4, new ColoredString("Combat", GuideTab == "Combat" ? Color.Yellow : Color.White, Color.Black), () => { GuideTab = "Combat"; });
            Guide.PrintClickable(2, 6, new ColoredString("Skilling", GuideTab == "Skilling" ? Color.Yellow : Color.White, Color.Black), () => { GuideTab = "Skilling"; });
            Guide.PrintClickable(2, 8, new ColoredString("Shops", GuideTab == "Shops" ? Color.Yellow : Color.White, Color.Black), () => { GuideTab = "Shops"; });
            Guide.PrintClickable(2, 10, new ColoredString("NPC Dialogue", GuideTab == "NPC Dialogue" ? Color.Yellow : Color.White, Color.Black), () => { GuideTab = "NPC Dialogue"; });

            int printY = 2;

            if (GuideTab == "Introduction") {

                printY = Guide.PrintMultiLine(22, printY,
                    "Welcome to Zero Players Online! The interface can be a little intimidating but this guide will hopefully ease you into the process of playing the game." + " /n /n " +
                    "The area to the top left contains your important stats readout, including HP and Gold, and skills you've recently gained experience in." + " /n /n " +
                    "Below this readout is the content area, containing tabs you can switch between at the top to view your inventory, equipment, and more." + " /n /n " +
                    "Underneath this and the width of the screen is your message log, where important messages are sent by the game." + " /n /n " +
                    "The top of the right side of the screen is your current location, listing its description and title." + " /n /n " +
                    "To the left below this are connected locations and monsters at this location. You can click a connected location to move to it." + " /n /n " +
                    "Finally to the right is the activity box, containing resources you can collect, items on the ground, NPCs, shop items, and processing stations at this location. Pressing TAB will cycle the tab shown here, or you can click on the letters at the top to change to specific tabs." + " /n /n " +
                    "This is all a lot to take in, but hopefully with some practice it will become more natural to navigate."
                    , 78);
            }
        }
         

        public static void MapDraw() {
            Map.Clear();
            Helper.DrawBox(Map, 0, 0, 48, 28);
            Map.Print(2, 0, "[Map - " + MapViewing + "]");

            string mapIDPrefix = "";

            if (MapViewing == "Maze Area Example") {
                mapIDPrefix = "MAZE_Area";
            }

            int pX = (49 - MapW * 3) / 2;
            int pY = (28 - MapH * 2) / 2;
            
            bool playerInArea = GameLoop.WTN.player.NavLoc.Contains(mapIDPrefix); 
             

            for (int i = 0; i < MapW * MapH; i++) {
                bool playerAtNumber = GameLoop.WTN.player.NavLoc == mapIDPrefix + i;
                bool landmark = false;

                if (GameLoop.WTN.Atlas.TryGetValue(mapIDPrefix + i, out Location? loc)) {
                    landmark = loc.MazeLandmark;
                }

                int x = i % MapW;
                int y = i / MapW;
                Map.DrawLine(new Point(pX, pY + (y * 2)), new Point(pX + (MapW * 3), pY + (y * 2)), 196, Color.Khaki);
                Map.DrawLine(new Point(pX + (x * 3), pY), new Point(pX + (x * 3), pY + (MapH * 2)), 179, Color.Khaki);
                 
                Map.Print(pX + (x * 3) + 1, pY + (y * 2) + 1, i.ToString(), playerAtNumber ? MapPlayerLoc : landmark ? MapLandmark : Color.Khaki);
            }
            Map.DrawLine(new Point(pX + (MapW * 3), pY), new Point(pX + (MapW * 3), pY + (MapH * 2)), 179, Color.Khaki);
            Map.DrawLine(new Point(pX, pY + (MapH * 2)), new Point(pX + (MapW * 3), pY + (MapH * 2)), 196, Color.Khaki);

            for (int i = 0; i < (MapW + 1) * (MapH + 1); i++) {
                int x = i % (MapW + 1);
                int y = i / (MapW + 1);
                Map.Print(pX + (x * 3), pY + (y * 2), "*", Color.Khaki);
            }
             

            
            Map.Print(1, 26, "Click the following lines to change their color.", Color.White);
            Map.PrintClickable(1, 27, new ColoredString("Maps in this color are areas of interest.", MapLandmark, Color.Black), () => { MapLandmark = new Color(GameLoop.rand.Next(256), GameLoop.rand.Next(256), GameLoop.rand.Next(256)); });
            Map.PrintClickable(1, 28, new ColoredString("You are at the map marked in this color.", MapPlayerLoc, Color.Black), () => { MapPlayerLoc = new Color(GameLoop.rand.Next(256), GameLoop.rand.Next(256), GameLoop.rand.Next(256)); });

            Map.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Map.IsVisible = false; });
        }

        public static List<CompendiumResult> Sources = new();
        
        public static void DebugDraw() {
            Debug.Clear();
            Helper.DrawBox(Debug, 0, 0, 98, 28);
            Debug.Print(2, 0, "[Debug Menu]");
            Debug.DrawLine(new Point(20, 1), new Point(20, 28), 179);

            Debug.PrintClickable(2, 1, new ColoredString("Overview", DebugMenu == "Overview" ? Color.Yellow : Color.White, Color.Black), () => { DebugMenu = "Overview"; });
            Debug.PrintClickable(2, 3, new ColoredString("Broken Links", DebugMenu == "Unfound" ? Color.Yellow : Color.White, Color.Black), () => { Sources = DebugSources(); DebugMenu = "Unfound"; CompendiumSourceTop = 0; });
            Debug.PrintClickable(18, 3, new ColoredString("?", Color.MediumPurple, Color.Black), () => { Sources = DebugSources(); DebugMenu = "Unfound"; DebugRandomSource = GameLoop.rand.Next(Sources.Count); CompendiumSourceTop = 0; });
            
            Debug.PrintClickable(2, 4, new ColoredString("Unobtainable Items", DebugMenu == "Unobtainable" ? Color.Yellow : Color.White, Color.Black), () => { Sources = DebugUnobtainable(); DebugMenu = "Unobtainable"; CompendiumSourceTop = 0; });
            Debug.PrintClickable(2, 5, new ColoredString("Unplaced Songs", DebugMenu == "Songs" ? Color.Yellow : Color.White, Color.Black), () => { Sources = DebugSongs(); DebugMenu = "Songs"; CompendiumSourceTop = 0; });
            Debug.PrintClickable(2, 6, new ColoredString("Alchemy Arrays", DebugMenu == "Alchemy" ? Color.Yellow : Color.White, Color.Black), () => { Sources = DebugAlchemy(); DebugMenu = "Alchemy"; CompendiumSourceTop = 0; });
            
            Debug.PrintClickable(2, 7, new ColoredString("Exp Chart", DebugMenu == "Exp Chart" ? Color.Yellow : Color.White, Color.Black), () => { DebugMenu = "Exp Chart"; CompendiumSourceTop = 0; });
            
            if (DebugMenu == "Overview") {
                Debug.Print(22, 1, "         Locations: " + GameLoop.WTN.Atlas.Count);
                Debug.Print(22, 2, "             Items: " + GameLoop.WTN.ItemLibrary.Count);
                Debug.Print(22, 3, "       Use Recipes: " + GameLoop.WTN.UseRecipes.Count);
                Debug.Print(22, 4, "     Craft Recipes: " + GameLoop.WTN.CraftLib.Values.Sum(o => o.Count));
                Debug.Print(22, 5, "Processing Recipes: " + (GameLoop.WTN.ProcessingStations.Values.Where(o => !o.DontIncludeInCounts).Sum(o => o.Recipes.Count)));
                Debug.Print(22, 6, "              NPCs: " + GameLoop.WTN.NPCLibrary.Count);
                Debug.Print(22, 7, "          Monsters: " + GameLoop.WTN.MonsterLibrary.Count);

                int tutorialSteps = GameLoop.WTN.ClueStepLibrary.Values.Where(o => o.Difficulty == "Tutorial").Count();
                int beginnerSteps = GameLoop.WTN.ClueStepLibrary.Values.Where(o => o.Difficulty == "Beginner").Count();
                int easySteps = GameLoop.WTN.ClueStepLibrary.Values.Where(o => o.Difficulty == "Easy").Count();
                int mediumSteps = GameLoop.WTN.ClueStepLibrary.Values.Where(o => o.Difficulty == "Medium").Count();
                int hardSteps = GameLoop.WTN.ClueStepLibrary.Values.Where(o => o.Difficulty == "Hard").Count();


                Debug.Print(22, 8, "        Clue Steps: " + tutorialSteps + "t / " + beginnerSteps + "b / " + easySteps + "e / " + mediumSteps + "m / " + hardSteps + "h");
                Debug.Print(22, 9, "            Quests: " + GameLoop.WTN.QuestLibrary.Count);
            } else if (DebugMenu == "Exp Chart") {  
                
                for (int i = 1; i < 101; i++) {
                    int tier = ((i / 20) + 1);
                    //int exp = (int) (30_000_000 * (Math.Pow(((i + 1) / 99.0), 4.2))); // Quadratic curve, terrible early because it starts so low
                    //int exp = (int) ((1070 - (i * 10)) * (Math.Pow(2, (i / 5f)))); // some weird shit, early metrics are at desired levels but the end is 73 million exp 
                    int exp = (int) ((1060 - ((i + 3) * 9)) * (Math.Pow(2, ((i + 3) / 5f)))) / 5 - 356; // some weird shit 
                    int exp2 = (int) ((1060 - ((i + 2) * 9)) * (Math.Pow(2, ((i + 2) / 5f)))) / 5 - 356; // some weird shit
                    int exp3 = (int) ((1060 - ((i + 1) * 9)) * (Math.Pow(2, ((i + 1) / 5f)))) / 5 - 356; // some weird shit
                    //int exp = (int) (50 * Math.Pow(2, (i / 5f)));
                    //int exp = (int) Math.Pow(100 * Math.Pow(2, (i / 20f)), 2);

                    Debug.Print(21 + ((i / 26) * 20), 0 + ((i % 26) + 1), $"Lv {i}: {exp:n00}", Color.White);
                }
                

            } else { 
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;

                if (Sources.Count > 27) {
                    if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - qty, 0, Sources.Count - 27); }
                    if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + qty, 0, Sources.Count - 27); }
                } else {
                    CompendiumSourceTop = 0;
                }

                int sourceY = 1;
            
                if (DebugMenu == "Unfound")
                    Debug.Print(22, sourceY++, "Things found where the ID may be wrong or refer to a nonexistent item: ", Color.Crimson);
                if (DebugMenu == "Unobtainable")
                    Debug.Print(22, sourceY++, "Items with no source found: ", Color.Crimson);
                if (DebugMenu == "Songs")
                    Debug.Print(22, sourceY++, "Songs that can't be unlocked currently: " + Sources.Count, Color.Crimson);
                if (DebugMenu == "Alchemy") {
                    Debug.Print(22, sourceY++, "Randomized alchemy arrays ", Color.Crimson);
                    Debug.Print(69, 1, "Ingredient Level Cap:", Color.White);
                    Debug.PrintAdjustableInt(91, 1, 3, ref DebugAlchemyLevel, 1, 100);

                }
                for (int source = CompendiumSourceTop; source < Sources.Count && source < CompendiumSourceTop + 27; source++) {
                    Debug.Print(22, sourceY++, Sources[source].Display, DebugRandomSource == sourceY - 2 ? Color.Yellow : Color.White);
                }
            }
        }

        public static List<CompendiumResult> DebugSources() {
            List<CompendiumResult> findings = new();

            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.DigItem != "" && GameLoop.WTN.ResolveItem(kv.Value.DigItem) == null) {
                    findings.Add(new("Loc: " + kv.Value.ID + ": Dig Item (" + kv.Value.DigItem + ")", "", "", "", "", 0));
                }

                foreach (var conn in kv.Value.ConnectedLocations) {
                    if (!GameLoop.WTN.Atlas.ContainsKey(conn.Destination)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Conn Dest (" + conn.Destination + ")", "", "", "", "", 0));
                    }

                    if (conn.CheckFailDest != "" && !GameLoop.WTN.Atlas.ContainsKey(conn.CheckFailDest)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Conn Fail (" + conn.CheckFailDest + ")", "", "", "", "", 0));
                    }
                }

                foreach (var gather in kv.Value.GatheringSpots) {
                    if (!GameLoop.WTN.GatherSpots.ContainsKey(gather)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Gather (" + gather + ")", "", "", "", "", 0));
                    }
                }

                foreach (var station in kv.Value.ProcessingStations) {
                    if (!GameLoop.WTN.ProcessingStations.ContainsKey(station)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Station (" + station + ")", "", "", "", "", 0));
                    }
                }

                foreach (var item in kv.Value.ItemSpawns) {
                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(item.ItemID)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Item Spawn (" + item.ItemID + ")", "", "", "", "", 0));
                    }
                }

                foreach (var mon in kv.Value.AreaMonsters) {
                    if (!GameLoop.WTN.MonsterLibrary.ContainsKey(mon)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Monster (" + mon + ")", "", "", "", "", 0));
                    }
                }

                if (kv.Value.BossHere != "" && !GameLoop.WTN.BossLibrary.ContainsKey(kv.Value.BossHere)) {
                    findings.Add(new("Loc: " + kv.Value.ID + ": Boss (" + kv.Value.BossHere + ")", "", "", "", "", 0));
                }

                foreach (var npc in kv.Value.NPCsHere) {
                    if (!GameLoop.WTN.NPCLibrary.ContainsKey(npc)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": NPC (" + npc + ")", "", "", "", "", 0));
                    }
                }

                foreach (var item in kv.Value.ShopItemsHere) {
                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(item)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Shop Item (" + item + ")", "", "", "", "", 0));
                    }
                }

                foreach (var patch in kv.Value.FarmingPatchesHere) {
                    if (!GameLoop.WTN.player.FarmingPatches.ContainsKey(patch)) {
                        findings.Add(new("Loc: " + kv.Value.ID + ": Farm Patch (" + patch + ")", "", "", "", "", 0));
                    }
                } 
            }

            foreach (var kv in GameLoop.WTN.GatherSpots) {
                if (kv.Value.NeededBait != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.NeededBait)) {
                    findings.Add(new("Gather: " + kv.Value.ID + ": Bait (" + kv.Value.NeededBait + ")", "", "", "", "", 0));
                }

                if (kv.Value.PossibleItems != null) {
                    foreach (var loot in kv.Value.PossibleItems) {
                        if (loot.Item != "" && loot.Item[0] != '*' && loot.Item[0] != '_' && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.Item)) {
                            findings.Add(new("Gather: " + kv.Value.ID + ": Loot (" + loot.Item + ")", "", "", "", "", 0));
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.ItemLibrary) { 
                if (kv.Value.DropTable != null) {
                    foreach (var loot in kv.Value.DropTable) {
                        if (loot.ItemID != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.ItemID)) {
                            findings.Add(new("Item: " + kv.Value.ID + ": Drop Table (" + loot.ItemID + ")", "", "", "", "", 0));
                        }
                    }

                    foreach (var tp in kv.Value.TeleportLocations) {
                        if (tp != "" && !GameLoop.WTN.Atlas.ContainsKey(tp)) {
                            findings.Add(new("Item: " + kv.Value.ID + ": TeleLoc (" + tp + ")", "", "", "", "", 0));
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.ProcessingStations) { 
                if (kv.Value.Recipes != null) {
                    foreach (var loot in kv.Value.Recipes) {  
                        if (loot.InputID.Contains(",")) {
                            string[] split = loot.InputID.Split(",");
                            if (split[0] == "Gold") { continue; }

                            if (loot.InputID != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(split[0])) {
                                findings.Add(new("Process: " + kv.Value.Name + ": Second In (" + split[0] + ")", "", "", "", "", 0));
                            }
                        } else {
                            if (loot.InputID != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.InputID)) {
                                findings.Add(new("Process: " + kv.Value.Name + ": Second In (" + loot.InputID + ")", "", "", "", "", 0));
                            }
                        }

                        if (loot.SecondaryIn.Contains(",")) {
                            string[] split = loot.SecondaryIn.Split(",");
                            if (split[0] == "Gold") { continue; }

                            if (loot.SecondaryIn != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(split[0])) {
                                findings.Add(new("Process: " + kv.Value.Name + ": Second In (" + split[0] + ")", "", "", "", "", 0));
                            }
                        } else {
                            if (loot.SecondaryIn != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.SecondaryIn)) {
                                findings.Add(new("Process: " + kv.Value.Name + ": Second In (" + loot.SecondaryIn + ")", "", "", "", "", 0));
                            }
                        }

                        if (loot.OutputID != "" && loot.OutputID[0] != '*' && loot.OutputID[0] != '_' && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.OutputID)) {
                            findings.Add(new("Process: " + kv.Value.Name + ": Recipe Out (" + loot.OutputID + ")", "", "", "", "", 0));
                        }

                        if (loot.SecondaryOut != "" && loot.SecondaryOut[0] != '*' && loot.SecondaryOut[0] != '_' && !GameLoop.WTN.ItemLibrary.ContainsKey(loot.SecondaryOut)) {
                            findings.Add(new("Process: " + kv.Value.Name + ": Second Out (" + loot.SecondaryOut + ")", "", "", "", "", 0));
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.UseRecipes) {  
                if (kv.Value.FirstItem != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.FirstItem)) {
                    findings.Add(new("UseRecipe: First Item (" + kv.Value.FirstItem + ")", "", "", "", "", 0));
                }
                
                if (kv.Value.SecondItem != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.SecondItem)) {
                    findings.Add(new("UseRecipe: Second Item (" + kv.Value.SecondItem + ")", "", "", "", "", 0));
                } 

                if (kv.Value.OutputItem != "" && kv.Value.OutputItem[0] != '_' && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.OutputItem)) {
                    findings.Add(new("UseRecipe: Output Item (" + kv.Value.OutputItem + ")", "", "", "", "", 0));
                } 
            }

            foreach (var kv in GameLoop.WTN.NPCLibrary) {  
                foreach (var pick in kv.Value.PickpocketLoot) {
                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(pick.ItemID)) {
                        findings.Add(new("NPC: " + kv.Value.ID + " Pickpocket (" + pick.ItemID + ")", "", "", "", "", 0));
                    }
                }

                foreach (var dia in kv.Value.Dialogue) {
                    if (dia.Value.ItemsGiven != null) {
                        foreach (var item in dia.Value.ItemsGiven) {
                            string[] split = item.Split(",");
                            if (split[0] != "Gold" && !GameLoop.WTN.ItemLibrary.ContainsKey(split[0])) {
                                findings.Add(new("NPC: " + kv.Value.ID + " Dialogue (" + split[0] + ")", "", "", "", "", 0));
                            }
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.MonsterLibrary) {  
                foreach (var drop in kv.Value.DropTable) {
                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(drop.ItemID)) {
                        findings.Add(new("Monster: " + kv.Value.ID + " Drop (" + drop.ItemID + ")", "", "", "", "", 0));
                    }
                } 
            }

            foreach (var kv in GameLoop.WTN.CraftLib) {  
                foreach (var rec in kv.Value) {
                    if (rec.ExtraTool != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(rec.ExtraTool)) {
                        findings.Add(new("Craft Rec: " + kv.Key + " Tool (" + rec.ExtraTool + ")", "", "", "", "", 0));
                    }

                    foreach (var need in rec.NeededItems) {
                        string[] split = need.Split(",");
                        if (!GameLoop.WTN.ItemLibrary.ContainsKey(split[0])) {
                            findings.Add(new("Craft Rec: " + kv.Key + " Material (" + split[0] + ")", "", "", "", "", 0));
                        }
                    }

                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(rec.OutputItem)) {
                        findings.Add(new("Craft Rec: " + kv.Key + " Output (" + rec.OutputItem + ")", "", "", "", "", 0));
                    }
                } 
            }

            foreach (var kv in GameLoop.WTN.BossLibrary) {  
                foreach (var drop in kv.Value.DropTable) {
                    if (!GameLoop.WTN.ItemLibrary.ContainsKey(drop.ItemID)) {
                        findings.Add(new("Boss: " + kv.Value.ID + " Drop (" + drop.ItemID + ")", "", "", "", "", 0));
                    }
                } 
            } 

            foreach (var kv in GameLoop.WTN.ClueStepLibrary) {   
                if (kv.Value.Equip1 != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.Equip1)) {
                    findings.Add(new("Clue: " + kv.Value.ID + " Equip1 (" + kv.Value.Equip1 + ")", "", "", "", "", 0));
                } 

                if (kv.Value.Equip2 != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.Equip2)) {
                    findings.Add(new("Clue: " + kv.Value.ID + " Equip2 (" + kv.Value.Equip2 + ")", "", "", "", "", 0));
                }

                if (kv.Value.Equip3 != "" && !GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.Equip3)) {
                    findings.Add(new("Clue: " + kv.Value.ID + " Equip3 (" + kv.Value.Equip3 + ")", "", "", "", "", 0));
                }
            }

            foreach (var kv in GameLoop.WTN.QuestLibrary) {   
                foreach (var reward in kv.Value.Rewards) {
                    if (reward.RewardType == "Item" && reward.MiscString != "" && reward.MiscString != "Gold" && !GameLoop.WTN.ItemLibrary.ContainsKey(reward.MiscString)) {
                        findings.Add(new("Quest: " + kv.Value.ID + " Reward (" + reward.MiscString + ")", "", "", "", "", 0));
                    }  
                }
            }

            return findings;
        }
        
        public static List<CompendiumResult> DebugAlchemy() { 
            List<CompendiumResult> rolls = new();

            for (int i = 0; i < 10; i++) {
                string build = (i == 0 ? "Lv  1" : "Lv " + (i * 10));

                int r = 0;
                int b = 0;
                int y = 0;
                int w = 0;

                for (int j = 0; j < 11 - i; j++) {
                    int randCat = GameLoop.rand.Next(4);

                    if (randCat == 0) { r++; }
                    if (randCat == 1) { b++; }
                    if (randCat == 2) { y++; }
                    if (randCat == 3) { w++; }
                }

                if (GameLoop.rand.Next(2) == 0) { r *= -1; }
                if (GameLoop.rand.Next(2) == 0) { b *= -1; }
                if (GameLoop.rand.Next(2) == 0) { y *= -1; }
                if (GameLoop.rand.Next(2) == 0) { w *= -1; }

                build += " - (" + r.ToString().Align(HorizontalAlignment.Right, 3) + "R / " + b.ToString().Align(HorizontalAlignment.Right, 3) + "B / " + y.ToString().Align(HorizontalAlignment.Right, 3) + "Y / " + w.ToString().Align(HorizontalAlignment.Right, 3) + "W" + ")";

                rolls.Add(new(build, "", "", "", "", 0, 0));
            }

            rolls.Add(new("", "", "", "", "", 0, 0));

            List<string> Colors = [ "Red", "Orange", "Yellow", "Lime", "Green", "Cyan", "Blue", "Purple", "Magenta / Pink", "Maroon / Wine" ];
            Colors.Shuffle();

            for (int i = 0; i < Colors.Count; i++) { 
                rolls.Add(new("Color " + (i == 0 ? " 1" : i * 10) + ": " + Colors[i], "", "", "", "", 0, 0));
            }
             
            rolls.Add(new("", "", "", "", "", 0, 0));

            List<Item> Ingredients = GameLoop.WTN.ItemLibrary.Values.Where(o => (o.Alchemy != null && o.ID != "alchemyMixture" && !o.ID.Contains("essence") && o.Alchemy.Level <= DebugAlchemyLevel)).ToList();

            if (Ingredients.Count > 1) {
                Item ing1 = Ingredients[GameLoop.rand.Next(Ingredients.Count)];
                Item ing2 = Ingredients[GameLoop.rand.Next(Ingredients.Count)];
            
                rolls.Add(new(ing1.GetNameCS(overrideLoupe: true).String + " (" + ing1.Alchemy.Level + ")", "", "", "", "", 0, 0));
                rolls.Add(new(ing2.GetNameCS(overrideLoupe: true).String + " (" + ing2.Alchemy.Level + ")", "", "", "", "", 0, 0));
            }
            return rolls;
        }


        public static void CompendiumDraw() { 
            Point mousePos = new MouseScreenObjectState(Compendium, GameHost.Instance.Mouse).CellPosition;

            Compendium.Clear();
            Helper.DrawBox(Compendium, 0, 0, 98, 28);
            Compendium.Print(2, 0, "[Zero Players Online Compendium]");
            Compendium.DrawLine(new Point(1, 2), new Point(98, 2), 196);

            List<string> Categories = [ "Overview", "Items", "Recipes", "NPCs", "Monsters", "Gathering", "Skills", "Locations", "Quests", "Hunter", "Bosses", "Clues", "Farming", "Spells" ];
             
            if (Helper.RightClicked()) {
                for (int i = 0; i < Categories.Count; i++) {
                    if (Categories[i] == CompendiumCat) {
                        if (i + 1 >= Categories.Count) {
                            CompendiumCat = Categories[0];
                        } else {
                            CompendiumCat = Categories[i+1];
                        }
                        
                        break;
                    }
                }
            }

            int cx = 2;
            for (int i = 0; i < Categories.Count; i++) {
                Compendium.PrintClickable(cx, 1, new ColoredString(CompendiumCat == Categories[i] ? Categories[i] : Categories[i].Substring(0, 2), CompendiumCat == Categories[i] ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = Categories[i]; });
                
                cx += (CompendiumCat == Categories[i] ? Categories[i] : Categories[i].Substring(0, 2)).Length + 1;
            }

            int printY = 3;

            if (CompendiumCat == "Overview") { 
                printY = Compendium.PrintMultiLine(2, printY,
                    "Welcome to Zero Players Online! This is the Compendium, a sort of extremely basic in-game wiki generated directly from the game data and formatted as best as possible." + " /n /n " +
                    "Please take note that there are no spoiler warnings on the pages. You may see information you do not wish to know, or lose out on the sense of discovery from figuring something out yourself. There are no penalties for viewing the information within, but give due consideration before clicking through." + " /n /n " +
                    "The final warning for the Compendium is that the information is not particularly beautified or sorted well. While information will be as complete as possible, it may be difficult to display some things in a way that conveys all intended meaning. Knowledge of the codebase or game mechanics may be required to understand how specific elements connect to eachother." + " /n /n " +
                    ""
                    , 97);
            } 
            else if (CompendiumCat == "Items") { 
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179); 

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "itemFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<Item> items = GameLoop.WTN.ItemLibrary.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (items.Count > 24) {
                    if (mousePos.X < 30) {
                        if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, items.Count - 24); }
                        if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, items.Count - 24); }
                    }
                } else {
                    CompendiumSidebarTop = 0;
                }

                for(int i = CompendiumSidebarTop; i < items.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(1, sidebarY++, items[i].GetNameCS(1, 0), () => { CompendiumViewingID = items[i].ID; CompendiumShowSources = false; });
                }

                if (GameLoop.WTN.ItemLibrary.TryGetValue(CompendiumViewingID, out Item? item)) {
                    int itemY = 3;

                    Compendium.Print(32, itemY++, "     ID: " + item.ID); 
                    Compendium.Print(71, 3, ("Color: r" + item.colR + " / g" + item.colG + " / b" + item.colB).Align(HorizontalAlignment.Right, 27));
                    Compendium.Print(32, itemY++, "   Name: " + item.GetNameCS(1));  
                    Compendium.PrintClickable(84, 4, "[Show Sources]", () => { CompendiumShowSources = !CompendiumShowSources; Sources = ItemSources(item.ID); });

                    if (!CompendiumShowSources) {
                        Compendium.Print(32, itemY++, "  Value: " + item.Value + "gp, HA: " + item.HighAlchVal() + ", LA: " + item.LowAlchVal(), Color.Goldenrod);  
                        itemY = Compendium.PrintMultiLine(32, itemY, "Examine: " + item.ExamineText, 68);  

                        itemY += 2; 

                        Compendium.Print(32, itemY++, "Stackable " + Helper.Checkmark(item.Stackable) + new ColoredString(" / Tradeable ") + Helper.Checkmark(item.Tradeable) + new ColoredString(" / Noteable ")  + Helper.Checkmark(item.Noteable));
                        itemY++;
                        
                        Compendium.Print(32, itemY++, "MiscString: " + (item.MiscString != "" ? item.MiscString : "(none)"), item.MiscString == "" ? Color.DarkSlateGray : Color.White); 
                        itemY++;
                        
                        if (item.EquipSlot != "") {
                            Compendium.Print(32, itemY++, "Equipment Info:", Color.White); 
                            Compendium.Print(32, itemY++, "Slot: " + item.EquipSlot + " / Tier: " + item.EquipTier + " / Dmg Type: " + (item.EquipDamageType != "" ? item.EquipDamageType : "(none)"), Color.White); 
                            Compendium.Print(32, itemY++, "Skill: " + (item.EquipSkill != "" ? item.EquipSkill : "(none)") + " / Level: " + item.EquipLevel + " / Speed: " + item.AttackSpeed, Color.White);
                            Compendium.Print(32, itemY++, new ColoredString("Ammo: " + (item.EquipAmmo != "" ? item.EquipAmmo : "(none)") + " / TwoHanded: ") + Helper.Checkmark(item.TwoHanded));  
                            itemY++;
                        }

                        Compendium.Print(32, itemY++, "Usage Info:    ConsumedOnUse: " + Helper.Checkmark(item.ConsumedOnUse));  
                        Compendium.Print(32, itemY, "UseString: " + (item.UseString != "" ? item.UseString : "(none)"), Color.White); 
                        Compendium.Print(70, itemY++, "UseInt: " + item.UseInt, Color.White); 
                        Compendium.Print(32, itemY, "UseString2: " + (item.UseString2 != "" ? item.UseString2 : "(none)"), Color.White); 
                        Compendium.Print(70, itemY++, "UseInt2: " + item.UseInt2, Color.White); 
                        Compendium.Print(32, itemY, "UseString3: " + (item.UseString3 != "" ? item.UseString3 : "(none)"), Color.White); 
                        Compendium.Print(70, itemY++, "UseInt3: " + item.UseInt3, Color.White); 
                        Compendium.Print(32, itemY, "MustBeEquipped: " + Helper.Checkmark(item.MustBeEquipped)); 
                        Compendium.Print(70, itemY++, "UseInt4: " + item.UseInt4, Color.White); 
                        Compendium.Print(32, itemY, "DestroyOnDrop: " + Helper.Checkmark(item.DestroyOnDrop)); 
                        Compendium.Print(70, itemY, "Cosmetic: " + Helper.Checkmark(item.Cosmetic)); 
                          
                        if (item.Potion.Count > 0) {
                            itemY += 2;
                            Compendium.Print(32, itemY, "Potion Effects: ", Color.White); 
                            for (int pot = 0; pot < item.Potion.Count; pot++) {
                                Compendium.Print(48, itemY++, item.Potion[pot].Stat + " " + (item.Potion[pot].Change > 0 ? "+" : "") + item.Potion[pot].Change, Color.White); 
                            }
                        }

                        if (item.DropTable.Count > 0) {
                            itemY += 2;

                            int drop = 1;
                            if (Helper.EitherShift())
                                drop *= 5;
                            if (Helper.EitherControl())
                                drop *= 10;


                            if (item.DropTable.Count > 9 && mousePos.X > 30) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - drop, 0, item.DropTable.Count - 9); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + drop, 0, item.DropTable.Count - 9); }
                            } else {
                                CompendiumDropTop = 0;
                            }
                            
                            Compendium.Print(32, itemY++, "Drop Table: ", Color.White); 
                            for (int pot = CompendiumDropTop; pot < item.DropTable.Count && pot < CompendiumDropTop + 9; pot++) {
                                Compendium.PrintClickable(32, itemY++, "| " + GameLoop.WTN.ResolveItemName(item.DropTable[pot].ItemID) + " (" + item.DropTable[pot].DropX + "/" + item.DropTable[pot].InY + ")", () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = item.DropTable[pot].ItemID; }); 
                            }

                        }
                    } else {
                        if (Sources.Count > 20) {
                            if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - qty, 0, Sources.Count - 20); }
                            if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + qty, 0, Sources.Count - 20); }
                        } else {
                            CompendiumSourceTop = 0;
                        }

                        int sourceY = 6;
                        
                        Compendium.Print(32, sourceY++, "Potential Item Sources: ", Color.White);

                        for (int source = CompendiumSourceTop; source < Sources.Count && source < CompendiumSourceTop + 20; source++) {
                            Compendium.PrintClickable(32, sourceY++, new ColoredString("| " + Sources[source].Display, Color.White, Color.Black), () => { ResetAllCompendiumValues(); SetAllCompendiumValues(Sources[source]); });
                        }
                    }  
                }
            } 
            else if (CompendiumCat == "Recipes") {
                Compendium.PrintClickable(4, 3, new ColoredString("Use", CompendiumSubCat == "UseRecipe" ? Color.Yellow : Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Recipes"; CompendiumSubCat = "UseRecipe"; });
                Compendium.PrintClickable(11, 3, new ColoredString("Craft", CompendiumSubCat == "CraftRecipe" ? Color.Yellow : Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Recipes"; CompendiumSubCat = "CraftRecipe"; });
                Compendium.PrintClickable(20, 3, new ColoredString("Process", CompendiumSubCat == "ProcessRecipe" ? Color.Yellow : Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Recipes"; CompendiumSubCat = "ProcessRecipe"; });
                Compendium.DrawLine(new Point(1, 4), new Point(29, 4), 196);
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                 
                Compendium.PrintStringField(2, 5, "Filter: ", ref Filter, ref SelectedField, "recipeFilter");
                Compendium.DrawLine(new Point(1, 6), new Point(29, 6), 196);

                if (CompendiumSubCat == "UseRecipe") {
                    List<Recipe> recipes = GameLoop.WTN.UseRecipes.Values.ToList().Where(u => (GameLoop.WTN.ResolveItemName(u.FirstItem).ToLower().Contains(Filter.ToLower()) || GameLoop.WTN.ResolveItemName(u.SecondItem).ToLower().Contains(Filter.ToLower()) || GameLoop.WTN.ResolveItemName(u.OutputItem).ToLower().Contains(Filter.ToLower()))).OrderBy(o => GameLoop.WTN.ResolveItemName(o.OutputItem)).ToList();

                    int qty = 1;
                    if (Helper.EitherShift())
                        qty *= 5;
                    if (Helper.EitherControl())
                        qty *= 10;


                    if (recipes.Count > 20) {
                        if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, recipes.Count - 20); }
                        if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, recipes.Count - 20); }
                    } else {
                        CompendiumSidebarTop = 0;
                    }


                    int sidebarY = 7;
                    for (int i = CompendiumSidebarTop; i < recipes.Count && i < CompendiumSidebarTop + 18; i++) {
                        Item? output = GameLoop.WTN.ResolveItem(recipes[i].OutputItem);
                        if (output != null) {
                            Compendium.PrintClickable(1, sidebarY++, output.GetNameCS(1), () => { CompendiumViewingID = recipes[i].FirstItem; CompendiumViewingID2 = recipes[i].SecondItem; });
                        } else {
                            Compendium.PrintClickable(1, sidebarY++, new ColoredString(GameLoop.WTN.ResolveItemName(recipes[i].OutputItem)), () => { CompendiumViewingID = recipes[i].FirstItem; CompendiumViewingID2 = recipes[i].SecondItem; });
                        }
                    }

                    if (CompendiumViewingID != "" && CompendiumViewingID2 != "") {
                        TwoWayString view = new(CompendiumViewingID, CompendiumViewingID2);

                        int viewY = 3;
                        if (GameLoop.WTN.UseRecipes.TryGetValue(view, out Recipe? viewingRecipe) && viewingRecipe != null) {
                            Compendium.PrintClickable(32, viewY++, new ColoredString(" First Item: " + (viewingRecipe.FirstQty != 0 ? viewingRecipe.FirstQty + "x " : "") + GameLoop.WTN.ResolveItemName(viewingRecipe.FirstItem), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = viewingRecipe.FirstItem; });
                            Compendium.PrintClickable(32, viewY++, new ColoredString("Second Item: " + (viewingRecipe.SecondQty != 0 ? viewingRecipe.SecondQty + "x " : "") + GameLoop.WTN.ResolveItemName(viewingRecipe.SecondItem), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = viewingRecipe.SecondItem; });
                            Compendium.PrintClickable(32, viewY++, new ColoredString("Output Item: " + (viewingRecipe.OutputQty != 0 ? viewingRecipe.OutputQty + "x " : "") + GameLoop.WTN.ResolveItemName(viewingRecipe.OutputItem), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = viewingRecipe.OutputItem; });
                             
                            viewY++;

                            Compendium.Print(32, viewY++, "Skill Level: " + viewingRecipe.SkillLevelReq + " " + viewingRecipe.SkillUsed + " (+" + viewingRecipe.ExpGranted + " exp)", Color.White); 
                            Compendium.Print(32, viewY++, "Misc String: " + viewingRecipe.MiscString, Color.White); 
                             
                            viewY++;
                                
                            Compendium.Print(32, viewY++, " Fail Output: " + viewingRecipe.FailID, Color.White);
                            Compendium.Print(32, viewY++, "Stop Failing: " + viewingRecipe.StopFailLevel, Color.White);

                            if (viewingRecipe.OutputItem == "_fire") {
                                viewY++;
                                Compendium.Print(32, viewY++, "Creates a temporary fire processing station. Uses Range recipes.");
                            }    
                        } 
                    }
                } else if (CompendiumSubCat == "CraftRecipe") {
                    List<string> stations = GameLoop.WTN.CraftLib.Keys.ToList().Where(u => u.ToLower().Contains(Filter.ToLower())).OrderBy(o => o).ToList();

                    int qty = 1;
                    if (Helper.EitherShift())
                        qty *= 5;
                    if (Helper.EitherControl())
                        qty *= 10;


                    if (CompendiumViewingID2 == "") {
                        if (stations.Count > 24) {
                            if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, stations.Count - 24); }
                            if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, stations.Count - 24); }
                        } else {
                            CompendiumSidebarTop = 0;
                        }
                    }


                    int sidebarY = 7;
                    
                    if (CompendiumViewingID2 == "") {
                        for (int i = CompendiumSidebarTop; i < stations.Count && i < CompendiumSidebarTop + 24; i++) { 
                            Compendium.PrintClickable(2, sidebarY++, stations[i], () => { CompendiumViewingID2 = stations[i]; });
                        }
                    } else {
                        if (GameLoop.WTN.CraftLib.TryGetValue(CompendiumViewingID2, out List<CraftRecipe>? recipes) && recipes != null) {
                            recipes = recipes.Where(u => (u.Skill.ToLower().Contains(Filter.ToLower())) || GameLoop.WTN.ResolveItemName(u.ExtraTool).ToLower().Contains(Filter.ToLower()) || GameLoop.WTN.ResolveItemName(u.OutputItem).ToLower().Contains(Filter.ToLower())).OrderBy(o => GameLoop.WTN.ResolveItemName(o.OutputItem)).ToList();
                            List<CraftRecipe> masterRecipes = GameLoop.WTN.CraftLib[CompendiumViewingID2].OrderBy(o => GameLoop.WTN.ResolveItemName(o.OutputItem)).ToList();

                            if (recipes.Count > 20) {
                                if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, recipes.Count - 20); }
                                if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, recipes.Count - 20); }
                            } else {
                                CompendiumSidebarTop = 0;
                            }

                            Compendium.PrintClickable(2, sidebarY++, CompendiumViewingID2.Align(HorizontalAlignment.Left, 21) + "[BACK]", () => { CompendiumViewingID2 = ""; return; });
                            Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                            for (int i = CompendiumSidebarTop; i < recipes.Count && i < CompendiumSidebarTop + 20; i++) {
                                Item? output = GameLoop.WTN.ResolveItem(recipes[i].OutputItem);

                                if (output != null) {
                                    Compendium.PrintClickable(2, sidebarY++, output.GetNameCS(), () => { 
                                        for (int j = 0; j < masterRecipes.Count; j++) {
                                            if (masterRecipes[j] == recipes[i]) {
                                                CompendiumViewingIndex = j;
                                            }
                                        } 
                                    }); 
                                } else {
                                    Compendium.PrintClickable(2, sidebarY++, GameLoop.WTN.ResolveItemName(recipes[i].OutputItem), () => { 
                                        for (int j = 0; j < masterRecipes.Count; j++) {
                                            if (masterRecipes[j] == recipes[i]) {
                                                CompendiumViewingIndex = j;
                                            }
                                        } 
                                    }); 
                                }
                            }
                            
                            if (CompendiumViewingIndex >= 0 && CompendiumViewingIndex < masterRecipes.Count) {
                                CraftRecipe rec = masterRecipes[CompendiumViewingIndex]; 

                                int recY = 3;
                                 
                                Compendium.PrintClickable(32, recY++, new ColoredString("Output Item: " + (rec.OutputQty > 1 ? rec.OutputQty + "x " : "") + GameLoop.WTN.ResolveItemName(rec.OutputItem), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = rec.OutputItem;});
                                Compendium.PrintClickable(32, recY++, new ColoredString("Tool Needed: " + GameLoop.WTN.ResolveItemName(rec.ExtraTool), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = rec.ExtraTool;});
                                recY++;
                                
                                Compendium.Print(32, recY++, "Skill: " + rec.Level + " " + rec.Skill + " (+" + rec.ExpGranted + " exp)", Color.White);
                                recY++; 

                                Compendium.Print(32, recY, "Items Needed: ");
                                for (int reagent = 0; reagent < rec.NeededItems.Count; reagent++) {
                                    string[] split = rec.NeededItems[reagent].Split(",");

                                    if (split.Length == 2) {
                                        Compendium.PrintClickable(46, recY++, new ColoredString(split[1] + "x " + GameLoop.WTN.ResolveItemName(split[0]), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = split[0]; });
                                    } else {
                                        Compendium.PrintClickable(46, recY++, new ColoredString(GameLoop.WTN.ResolveItemName(rec.NeededItems[reagent]), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = rec.NeededItems[reagent]; });
                                    } 
                                }
                            }
                        }
                    }  
                } else if (CompendiumSubCat == "ProcessRecipe") {
                     List<ProcessingStation> stations = GameLoop.WTN.ProcessingStations.Values.ToList().Where(u => u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                    int qty = 1;
                    if (Helper.EitherShift())
                        qty *= 5;
                    if (Helper.EitherControl())
                        qty *= 10;


                    if (CompendiumViewingID2 == "") {
                        if (stations.Count > 22) {
                            if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, stations.Count - 22); }
                            if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, stations.Count - 22); }
                        } else {
                            CompendiumSidebarTop = 0;
                        }
                    }


                    int sidebarY = 7;
                    
                    if (CompendiumViewingID2 == "") {
                        for (int i = CompendiumSidebarTop; i < stations.Count && i < CompendiumSidebarTop + 22; i++) { 
                            Compendium.PrintClickable(2, sidebarY++, stations[i].Name, () => { CompendiumViewingID2 = stations[i].Name; Sources = StationLocations(CompendiumViewingID2); });
                        }
                    } else {
                        if (GameLoop.WTN.ProcessingStations.TryGetValue(CompendiumViewingID2, out ProcessingStation? station) && station != null) {
                            List<ProcessingRecipe> masterRecipes = station.Recipes.OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputID))).ToList();
                            
                            List<ProcessingRecipe> recipes = station.Recipes.Where(u => (GameLoop.WTN.ResolveItemName(u.InputID).ToLower().Contains(Filter.ToLower())) || (GameLoop.WTN.ResolveItemName(u.OutputID).ToLower().Contains(Filter.ToLower()))).OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputID))).ToList();
                            
                            if (recipes.Count > 19) {
                                if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, recipes.Count - 19); }
                                if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, recipes.Count - 19); }
                            } else {
                                CompendiumSidebarTop = 0;
                            }

                            Compendium.Print(2, sidebarY, CompendiumViewingID2, Color.White);
                            Compendium.PrintClickable(28, sidebarY, new ColoredString("X", Color.Crimson, Color.Black), () => { CompendiumViewingID2 = ""; return; });
                            Compendium.PrintClickable(26, sidebarY++, new ColoredString("?", Color.MediumPurple, Color.Black), () => { Sources = StationLocations(CompendiumViewingID2); CompendiumViewingIndex = -1; return; });
                            Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                            int recY = 3; 

                            if (station.OpensUI) { 
                                Compendium.Print(2, sidebarY, "Opens UI for Craft Recipes", Color.White);
                            }

                            for (int i = CompendiumSidebarTop; i < recipes.Count && i < CompendiumSidebarTop + 19; i++) {
                                Item? output = GameLoop.WTN.ResolveItem(recipes[i].OutputID);

                                if (output != null) {
                                    Compendium.PrintClickable(2, sidebarY++, output.GetNameCS(), () => { 
                                        for (int j = 0; j < masterRecipes.Count; j++) {
                                            if (masterRecipes[j] == recipes[i]) {
                                                CompendiumViewingIndex = j;
                                            }
                                        } 
                                    }); 
                                } else {
                                    Compendium.PrintClickable(2, sidebarY++, GameLoop.WTN.ResolveItemName(recipes[i].OutputID), () => { 
                                        for (int j = 0; j < masterRecipes.Count; j++) {
                                            if (masterRecipes[j] == recipes[i]) {
                                                CompendiumViewingIndex = j;
                                            }
                                        } 
                                    }); 
                                }
                            }
                            
                            if (CompendiumViewingIndex == -1) {
                                int srcQty = 1;
                                if (Helper.EitherShift())
                                    srcQty *= 5;
                                if (Helper.EitherControl())
                                    srcQty *= 10;


                                if (Sources.Count > 20) {
                                    if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 20); }
                                    if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 20); }
                                } else {
                                    CompendiumSourceTop = 0;
                                }

                                Compendium.Print(32, recY++, CompendiumViewingID2 + " Locations Found: ", Color.White);
                                if (Sources.Count > 0) {
                                    for (int i = 0; i < Sources.Count; i++) {
                                        Compendium.PrintClickable(32, recY++, "| " + Sources[i].Display, () => { ResetAllCompendiumValues(); SetAllCompendiumValues(Sources[i]); });
                                    }
                                } else { 
                                    Compendium.Print(32, recY++, "| (not found in any map)", Color.DarkSlateGray);
                                }
                            } else if (CompendiumViewingIndex >= 0 && CompendiumViewingIndex < masterRecipes.Count) {
                                ProcessingRecipe rec = masterRecipes[CompendiumViewingIndex];     

                                Compendium.PrintClickable(32, recY++, new ColoredString(" Input Item: " + GameLoop.WTN.ResolveItemName(rec.InputID), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = rec.InputID;});
                                Compendium.PrintClickable(32, recY++, new ColoredString("Output Item: " + GameLoop.WTN.ResolveItemName(rec.OutputID), Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = rec.OutputID;});
                                recY++;
                                
                                Compendium.Print(32, recY++, "Skill: " + rec.SkillLevel + " " + rec.SkillUsed + " (+" + rec.SkillEXP + " exp)", Color.White);

                                recY++;
                                
                                Compendium.Print(32, recY++, " Fail Output: " + rec.FailOutput, Color.White);
                                Compendium.Print(32, recY++, "Stop Failing: " + rec.StopFailingLevel, Color.White);
                            }
                        }
                    }  
                }
            } 
            else if (CompendiumCat == "NPCs") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.NPCLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.NPCLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.NPCLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "npcFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<NPC> npcs = GameLoop.WTN.NPCLibrary.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                for(int i = CompendiumSidebarTop; i < npcs.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(1, sidebarY++, new ColoredString(npcs[i].Name, (CompendiumViewingID == npcs[i].ID ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "NPCs"; CompendiumViewingID = npcs[i].ID; CompendiumViewingIndex = 0; });
                }

                if (GameLoop.WTN.NPCLibrary.TryGetValue(CompendiumViewingID, out NPC? npc) && npc != null) {
                    int npcY = 3;
                    
                    Compendium.Print(32, npcY++, "  ID: " + npc.ID, Color.White);
                    Compendium.Print(32, npcY++, "Name: " + npc.Name, Color.White);
                    Compendium.PrintClickable(82, 3, "[Show Locations]", () => { CompendiumShowSources = !CompendiumShowSources; if (CompendiumShowSources) { Sources = NPCLocations(npc.ID); } });

                    if (CompendiumShowSources) {
                        npcY++;
                        Compendium.Print(32, npcY++, "Locations Found: ", Color.White);
                        for (int i = 0; i < Sources.Count; i++) {
                            Compendium.PrintClickable(32, npcY++, "| " + Sources[i].Display, () => { ResetAllCompendiumValues(); SetAllCompendiumValues(Sources[i]); });
                        }
                    } else { 
                        if (npc.ReqsToSee != null && npc.ReqsToSee.Count > 0) {
                            foreach (var req in npc.ReqsToSee) {
                                npcY++;
                                Compendium.Print(32, npcY++, "Requirement to See: " + req.GetSummary(), Color.White);
                            }
                        }

                        if (npc.PickpocketLevel > 0) {
                            npcY++;
                            Compendium.Print(32, npcY++, "Pickpocket: " + npc.PickpocketLevel + " (+" + npc.PickpocketEXP + " exp)", Color.White);

                            for (int i = 0; i < npc.PickpocketLoot.Count; i++) {
                                Compendium.PrintClickable(32, npcY++, "| " + GameLoop.WTN.ResolveItemName(npc.PickpocketLoot[i].ItemID) + " [" + npc.PickpocketLoot[i].DropX + "/" + npc.PickpocketLoot[i].InY + "]", () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = npc.PickpocketLoot[i].ItemID; });
                            }
                        }

                        if (npc.Dialogue != null && npc.Dialogue.Count > 0) { 
                            npcY++;
                            Compendium.Print(32, npcY++, "Dialogue Stages: ", Color.White); 

                            int diaX = 32;

                            foreach (var kv in npc.Dialogue) {
                                if (diaX > 94) {
                                    diaX = 32;
                                    npcY++;
                                }

                                Compendium.PrintClickable(diaX, npcY, new ColoredString(kv.Key.ToString(), CompendiumViewingIndex == kv.Key ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex = kv.Key; });
                                diaX += kv.Key.ToString().Length + 1; 
                            }

                            npcY += 2;

                            if (npc.Dialogue.TryGetValue(CompendiumViewingIndex, out DialogueStage? stage) && stage != null) {
                                npcY = Compendium.PrintMultiLine(32, npcY, "\"" + stage.Text + "\"", 64);
                                npcY++;
                            
                                if (stage.SetsQuest != "") {
                                    npcY++;
                                    Compendium.PrintClickable(32, npcY++, "Sets Quest: " + stage.SetsQuest + " to stage " + stage.SetsQuestStageTo, () => { ResetAllCompendiumValues(); CompendiumCat = "Quests"; CompendiumViewingID = stage.SetsQuest; CompendiumViewingIndex = stage.SetsQuestStageTo; });
                                }

                                if (stage.ItemsGiven != null && stage.ItemsGiven.Count > 0) {
                                    npcY++;
                                    Compendium.Print(32, npcY++, "Items Given When Stage Reached: ", Color.White);

                                    for (int i = 0; i < stage.ItemsGiven.Count; i++) {
                                        string[] split = stage.ItemsGiven[i].Split(",");
                                        Compendium.PrintClickable(32, npcY++, "| " + (split.Length > 1 && split[1] != "1" ? split[1] + "x " : "") + GameLoop.WTN.ResolveItemName(split[0]), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = split[0]; });
                                    }
                                }

                                if (stage.Choices != null && stage.Choices.Count > 0) { 
                                    npcY++;
                                    Compendium.Print(32, npcY++, "Dialogue Choices: ", Color.White);

                                    int x = 32;
                                    for (int i = 0; i < stage.Choices.Count; i++) { 
                                        Compendium.PrintClickable(x, npcY, new ColoredString(i.ToString(), CompendiumViewingIndex2 == i ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex2 = i; });
                                        x += i.ToString().Length + 1;
                                    }

                                    npcY += 2;

                                    if (stage.Choices.Count > CompendiumViewingIndex2) { 
                                        Compendium.Print(32, npcY++, "Text: " + stage.Choices[CompendiumViewingIndex2].Text, Color.White); 
                                        Compendium.PrintClickable(32, npcY++, "Leads to Stage: " + stage.Choices[CompendiumViewingIndex2].LeadsToStage, () => { CompendiumViewingIndex = stage.Choices[CompendiumViewingIndex2].LeadsToStage; CompendiumViewingIndex2 = 0; });  
                                        if (stage.Choices[CompendiumViewingIndex2].TeleportTo != "")
                                            Compendium.PrintClickable(32, npcY++, "Teleport " + (stage.Choices[CompendiumViewingIndex2].SetSpawnToo ? "(and set spawn)" : "") + ": " + stage.Choices[CompendiumViewingIndex2].TeleportTo, () => { ResetAllCompendiumValues(); CompendiumCat = "Locations"; CompendiumViewingID = stage.Choices[CompendiumViewingIndex2].TeleportTo;});  
                                        if (stage.Choices[CompendiumViewingIndex2].ClickReqs != null && stage.Choices[CompendiumViewingIndex2].ClickReqs.Count > 0) { 
                                            Compendium.Print(32, npcY++, "Requirements to Click: (Show if not met: " + Helper.Checkmark(stage.Choices[CompendiumViewingIndex2].ShowAnyways) + new ColoredString(")")); 

                                            for (int i = 0; i < stage.Choices[CompendiumViewingIndex2].ClickReqs.Count; i++) {
                                                Compendium.Print(32, npcY++, "| " + stage.Choices[CompendiumViewingIndex2].ClickReqs[i].GetSummary(), Color.White); 
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            } 
            else if (CompendiumCat == "Monsters") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.MonsterLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.MonsterLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.MonsterLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "monFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<AreaMonster> mons = GameLoop.WTN.MonsterLibrary.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                for(int i = CompendiumSidebarTop; i < mons.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(mons[i].Name, (CompendiumViewingID == mons[i].ID ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Monsters"; CompendiumViewingID = mons[i].ID; });
                }

                if (GameLoop.WTN.MonsterLibrary.TryGetValue(CompendiumViewingID, out AreaMonster? mon) && mon != null) {
                    int monY = 3;

                    Compendium.Print(32, monY++, "  ID: " + mon.ID, Color.White);
                    Compendium.Print(32, monY++, "Name: " + mon.Name, Color.White);
                    Compendium.PrintClickable(82, 3, "[Show Locations]", () => { CompendiumShowSources = !CompendiumShowSources; if (CompendiumShowSources) { Sources = MonsterLocations(mon.ID); } });
                    
                    if (CompendiumShowSources) {
                        int srcQty = 1;
                        if (Helper.EitherShift())
                            srcQty *= 5;
                        if (Helper.EitherControl())
                            srcQty *= 10;


                        if (Sources.Count > 20) {
                            if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 20); }
                            if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 20); }
                        } else {
                            CompendiumSourceTop = 0;
                        }

                        monY++;
                        Compendium.Print(32, monY++, "Locations Found: ", Color.White);
                        if (Sources.Count > 0) {
                            for (int i = CompendiumSourceTop; i < Sources.Count && i < CompendiumSourceTop + 20; i++) {
                                Compendium.PrintClickable(32, monY++, "| " + Sources[i].Display, () => { SetAllCompendiumValues(Sources[i]); });
                            }
                        } else { 
                            Compendium.Print(32, monY++, "| (not found in any map)", Color.White);
                        }
                    } else {
                        monY++;
                        Compendium.Print(32, monY++, "Level: " + mon.Level, Color.White);
                        Compendium.Print(32, monY++, "MaxHP: " + mon.MaxHP, Color.White);
                        monY++;
                        Compendium.Print(32, monY++, "Damage Reduction: " + mon.DamageReduction + "% (Weakness: " + mon.WeakType + ")", Color.White); 
                        Compendium.Print(32, monY++, "Aggro: Lv" + mon.AggroLevel); 
                        Compendium.Print(32, monY++, "Max Hit: " + mon.MaxHit + " " + mon.DamageType, Color.White);
                        Compendium.Print(32, monY++, "Category: " + mon.SpecialCategory, Color.White);
                        Compendium.Print(32, monY++, "Respawn: " + mon.RespawnTime + " seconds", Color.White);

                        monY++;
                        Compendium.Print(32, monY++, "Drop Table: ", Color.White);

                        if (mon.DropTable.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (mon.DropTable.Count > 10) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, mon.DropTable.Count - 10); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, mon.DropTable.Count - 10); }
                            } else {
                                CompendiumDropTop = 0;
                            }


                            for (int i = CompendiumDropTop; i < mon.DropTable.Count && i < CompendiumDropTop + 10; i++) { 
                                if (mon.DropTable[i].QuantityMin != mon.DropTable[i].QuantityMax) { 
                                    Compendium.Print(32, monY++, "| " + GameLoop.WTN.ResolveItemName(mon.DropTable[i].ItemID) + " (" + mon.DropTable[i].QuantityMin + " - " + mon.DropTable[i].QuantityMax + ") [" + mon.DropTable[i].DropX + "/" + mon.DropTable[i].InY + "]", Color.White);
                                } else { 
                                    Compendium.Print(32, monY++, "| " + GameLoop.WTN.ResolveItemName(mon.DropTable[i].ItemID) + " (" + mon.DropTable[i].QuantityMin + ") [" + mon.DropTable[i].DropX + "/" + mon.DropTable[i].InY + "]", Color.White);
                                }
                            }
                        } else {
                            Compendium.Print(32, monY++, "| " + new ColoredString("no drops", Color.DarkSlateGray, Color.Black));
                        }
                    }
                }
            } 
            else if (CompendiumCat == "Gathering") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.GatherSpots.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.GatherSpots.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.GatherSpots.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "gatherFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<GatheringTile> gathers = GameLoop.WTN.GatherSpots.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                for(int i = CompendiumSidebarTop; i < gathers.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(gathers[i].Name, (CompendiumViewingID == gathers[i].ID ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Gathering"; CompendiumViewingID = gathers[i].ID; });
                }

                if (GameLoop.WTN.GatherSpots.TryGetValue(CompendiumViewingID, out GatheringTile? gather) && gather != null) {
                    int gatherY = 3;

                    Compendium.Print(32, gatherY++, "  ID: " + gather.ID, Color.White);
                    Compendium.Print(32, gatherY++, "Name: " + gather.Name, Color.White);
                    Compendium.PrintClickable(82, 3, "[Show Locations]", () => { CompendiumShowSources = !CompendiumShowSources; if (CompendiumShowSources) { Sources = GatherLocations(gather.ID); } });
                    
                    if (CompendiumShowSources) {
                        gatherY++;
                        Compendium.Print(32, gatherY++, "Locations Found: ", Color.White);

                        if (Sources.Count > 0) {
                            int srcQty = 1;
                            if (Helper.EitherShift())
                                srcQty *= 5;
                            if (Helper.EitherControl())
                                srcQty *= 10;


                            if (Sources.Count > 20) {
                                if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 20); }
                                if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 20); }
                            } else {
                                CompendiumSourceTop = 0;
                            }

                            for (int i = CompendiumSourceTop; i < Sources.Count && i < CompendiumSourceTop + 20; i++) {
                                Compendium.PrintClickable(32, gatherY++, "| " + Sources[i].Display, () => { SetAllCompendiumValues(Sources[i]); });
                            }
                        } else {
                            Compendium.Print(32, gatherY++, "| (not found in any map)", Color.DarkSlateGray);
                        }
                    } else {
                        gatherY++; 
                        if (gather.Skill != "")
                            Compendium.Print(32, gatherY++, "Skill: " + gather.Level + " " + gather.Skill + " (+" + gather.ExpGranted + " exp)", Color.White);
                        if (gather.NeedToolCat != "")
                            Compendium.Print(32, gatherY++, "Needed Tool: " + gather.NeedToolCat, Color.White);
                        Compendium.Print(32, gatherY++, "Deplete Chance: " + gather.DepleteChance, Color.White);
                        Compendium.Print(32, gatherY++, "  Restock Time: " + gather.RestockTime + " seconds", Color.White); 
                     
                        gatherY++;
                        Compendium.Print(32, gatherY++, "Possible Items: ", Color.White);

                        if (gather.PossibleItems != null && gather.PossibleItems.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (gather.PossibleItems.Count > 10) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, gather.PossibleItems.Count - 10); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, gather.PossibleItems.Count - 10); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            int totalWeight = 0;
                            for (int i = 0; i < gather.PossibleItems.Count; i++) { 
                                totalWeight += gather.PossibleItems[i].Weight;
                            }

                            for (int i = CompendiumDropTop; i < gather.PossibleItems.Count && i < CompendiumDropTop + 15; i++) { 
                                Compendium.PrintClickable(32, gatherY++, "| " + GameLoop.WTN.ResolveItemName(gather.PossibleItems[i].Item) + " [" + gather.PossibleItems[i].Weight + "/" + totalWeight + "]", () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = gather.PossibleItems[i].Item; });
                            }
                        } else { 
                            Compendium.Print(32, gatherY++, "| (no drops)", Color.DarkSlateGray);
                        }
                    }
                }
            } 
            else if (CompendiumCat == "Locations") {
                Compendium.DrawLine(new Point(40, 3), new Point(40, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.Atlas.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.Atlas.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.Atlas.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "locFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(39, sidebarY++), 196);

                List<Location> locs = GameLoop.WTN.Atlas.Values.Where(u => (u.DisplayName != null && u.DisplayName.ToLower().Contains(Filter.ToLower())) || (u.Region != null && u.Region.ToLower().Contains(Filter.ToLower()))).OrderBy(o => o.DisplayName).ToList();

                for(int i = CompendiumSidebarTop; i < locs.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(Helper.Truncate(locs[i].DisplayName, 38), (CompendiumViewingID == locs[i].ID ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Locations"; CompendiumViewingID = locs[i].ID; });
                }

                if (GameLoop.WTN.Atlas.TryGetValue(CompendiumViewingID, out Location? loc) && loc != null) {
                    int locY = 3;

                    Compendium.Print(42, locY++, "    ID: " + loc.ID, Color.White);
                    Compendium.Print(42, locY++, "  Name: " + loc.DisplayName, Color.White);
                    Compendium.Print(42, locY++, "Region: " + loc.Region, Color.White);

                    locY++;
                    Compendium.Print(42, locY++, "IsBank: " + Helper.Checkmark(loc.IsBank));
                    Compendium.PrintClickable(42, locY++, "Dig Item: " + (loc.DigItem == "" ? "(none)" : GameLoop.WTN.ResolveItemName(loc.DigItem)), () => { if (loc.DigItem != "") { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = loc.DigItem; }});
                    
                    locY++;
                    List<string> tabs = [ "Gather", "Processing", "Items", "NPCs", "Shop", "Farming Patches", "Monsters", "Boss", "Connections" ];
                    int dx = 55; 
                    if (Helper.HotkeyDown(Key.Tab)) { CompendiumViewingIndex2++; if (CompendiumViewingIndex2 >= tabs.Count) { CompendiumViewingIndex2 = 0;} } 

                    Compendium.Print(42, locY, "Things Here: ", Color.White);
                    for (int i = 0; i < tabs.Count; i++) {
                        Compendium.PrintClickable(dx, locY, new ColoredString(CompendiumViewingIndex2 == i ? tabs[i] : tabs[i][0].ToString(), CompendiumViewingIndex2 == i ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex2 = i; });
                        dx += (CompendiumViewingIndex2 == i ? tabs[i] : tabs[i][0].ToString()).Length + 1;
                    }
                    locY++;

                    CompendiumViewingIndex2 = Math.Clamp(CompendiumViewingIndex2, 0, tabs.Count - 1);
                    if (tabs[CompendiumViewingIndex2] == "Gather") {
                        if (loc.GatheringSpots.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.GatheringSpots.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.GatheringSpots.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.GatheringSpots.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.GatheringSpots.Count && i < CompendiumDropTop + 15; i++) { 
                                Compendium.PrintClickable(42, locY++, "| " + GameLoop.WTN.ResolveGatherName(loc.GatheringSpots[i]), () => { ResetAllCompendiumValues(); CompendiumCat = "Gathering"; CompendiumViewingID = loc.GatheringSpots[i]; });
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no gather spots here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Processing") {
                        if (loc.ProcessingStations.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.ProcessingStations.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.ProcessingStations.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.ProcessingStations.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.ProcessingStations.Count && i < CompendiumDropTop + 15; i++) { 
                                Compendium.PrintClickable(42, locY++, "| " + GameLoop.WTN.ResolveGatherName(loc.ProcessingStations[i]), () => { ResetAllCompendiumValues(); CompendiumCat = "Recipes"; CompendiumSubCat = "ProcessRecipe"; CompendiumViewingID2 = loc.ProcessingStations[i]; });
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no processing stations here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Items") {
                        if (loc.ItemSpawns.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.ItemSpawns.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.ItemSpawns.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.ItemSpawns.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.ItemSpawns.Count && i < CompendiumDropTop + 17; i++) { 
                                Compendium.PrintClickable(42, locY++, "| " + GameLoop.WTN.ResolveItemName(loc.ItemSpawns[i].ItemID) + " (" + (loc.ItemSpawns[i].ReqToSpawn != null ? loc.ItemSpawns[i].ReqToSpawn.GetSummary() + ")" : ""), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = loc.ItemSpawns[i].ItemID; });
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no item spawns here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "NPCs") {
                        if (loc.NPCsHere.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.NPCsHere.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.NPCsHere.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.NPCsHere.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.NPCsHere.Count && i < CompendiumDropTop + 17; i++) { 
                                if (GameLoop.WTN.NPCLibrary.TryGetValue(loc.NPCsHere[i], out NPC? npc)) {
                                    Compendium.PrintClickable(42, locY++, "| " + npc.Name, () => { ResetAllCompendiumValues(); CompendiumCat = "NPCs"; CompendiumViewingID = npc.ID; });
                                } else {
                                    Compendium.PrintClickable(42, locY++, "| " + loc.NPCsHere[i], () => { ResetAllCompendiumValues(); CompendiumCat = "NPCs"; CompendiumViewingID = loc.NPCsHere[i]; });
                                }
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no NPCs here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Shop") {
                        if (loc.ShopItemsHere.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.ShopItemsHere.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.ShopItemsHere.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.ShopItemsHere.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.ShopItemsHere.Count && i < CompendiumDropTop + 17; i++) { 
                                Item? item = GameLoop.WTN.ResolveItem(loc.ShopItemsHere[i]);

                                if (item != null) {
                                    Compendium.PrintClickable(42, locY++, "| " + item.Name + " (" + item.Value + "gp)", () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = item.ID; });
                                } else {
                                    Compendium.PrintClickable(42, locY++, "| " + loc.ShopItemsHere[i], () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = loc.ShopItemsHere[i]; });
                                }
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no shop items here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Farming Patches") {
                        if (loc.FarmingPatchesHere.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.FarmingPatchesHere.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.FarmingPatchesHere.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.FarmingPatchesHere.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.FarmingPatchesHere.Count && i < CompendiumDropTop + 17; i++) {  
                                if (GameLoop.WTN.player.FarmingPatches.TryGetValue(loc.FarmingPatchesHere[i], out FarmingPatch? patch)) {
                                    Compendium.PrintClickable(42, locY++, "| " + patch.PatchType + (patch.SeedPlanted != "" ? " (" + GameLoop.WTN.ResolveItemName(patch.SeedPlanted) + ", " + patch.TimeLeft + ")" : ""), () => { ResetAllCompendiumValues(); CompendiumCat = "Farming"; CompendiumViewingID = patch.ID; });
                                } else {
                                    Compendium.Print(42, locY++, "| " + loc.FarmingPatchesHere[i], Color.White);
                                }
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no farming patches here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Monsters") {
                        if (loc.AreaMonsters.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.AreaMonsters.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.AreaMonsters.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.AreaMonsters.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.AreaMonsters.Count && i < CompendiumDropTop + 17; i++) {  
                                if (GameLoop.WTN.MonsterLibrary.TryGetValue(loc.AreaMonsters[i], out AreaMonster? mon)) {
                                    Compendium.PrintClickable(42, locY++, "| " + mon.Name, () => { ResetAllCompendiumValues(); CompendiumCat = "Monsters"; CompendiumViewingID = mon.ID; });
                                } else {
                                    Compendium.PrintClickable(42, locY++, "| " + loc.AreaMonsters[i], () => { ResetAllCompendiumValues(); CompendiumCat = "Monsters"; CompendiumViewingID = loc.AreaMonsters[i]; });
                                }
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no monsters here)", Color.DarkSlateGray);
                        }
                    } else if (tabs[CompendiumViewingIndex2] == "Boss") {
                        if (loc.BossHere != "") {
                            if (GameLoop.WTN.BossLibrary.TryGetValue(loc.BossHere, out BossFight? boss) && boss != null && boss.Phases.Count > 0) {
                                Compendium.PrintClickable(42, locY++, "| " + boss.Phases[0].Name, () => { ResetAllCompendiumValues(); CompendiumCat = "Bosses"; CompendiumViewingID = boss.ID; });
                            } else { 
                                Compendium.PrintClickable(42, locY++, "| " + loc.BossHere, () => { ResetAllCompendiumValues(); CompendiumCat = "Bosses"; CompendiumViewingID = loc.BossHere; });
                            } 
                        } else {
                            Compendium.Print(42, locY++, "| (no boss here)", Color.DarkSlateGray);
                        }
                    }  else if (tabs[CompendiumViewingIndex2] == "Connections") {
                        if (loc.ConnectedLocations.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (loc.ConnectedLocations.Count > 17) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, loc.ConnectedLocations.Count - 17); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, loc.ConnectedLocations.Count - 17); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < loc.ConnectedLocations.Count && i < CompendiumDropTop + 17; i++) {  
                                Connection conn = loc.ConnectedLocations[i];

                                ColoredString line = new("| " + GameLoop.WTN.ResolveLocationName(conn.Destination));

                                if (conn.AltName != "")
                                    line = new("| " + conn.AltName); 
                                if (conn.ExpTo != "") {
                                    line += new ColoredString(" (+" + conn.ExpGranted + " " + conn.ExpTo + " exp, Check: ") + Helper.Checkmark(conn.SkillCheck) + new ColoredString(")");
                                } 
                                Compendium.PrintClickable(42, locY++, line, () => { ResetAllCompendiumValues(); CompendiumCat = "Locations"; CompendiumViewingID = conn.Destination; }); 
                                 
                                if (conn.SkillCheck) {
                                    Compendium.PrintClickable(42, locY++, "| (above if fail check) " + GameLoop.WTN.ResolveLocationName(conn.CheckFailDest), () => { ResetAllCompendiumValues(); CompendiumCat = "Locations"; CompendiumViewingID = conn.CheckFailDest; });
                                }
                            }
                        } else {
                            Compendium.Print(42, locY++, "| (no connections here)", Color.DarkSlateGray);
                        }
                    }
                }
            } 
            else if (CompendiumCat == "Quests") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.QuestLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.QuestLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.QuestLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "questFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<Quest> quests = GameLoop.WTN.QuestLibrary.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                for(int i = CompendiumSidebarTop; i < quests.Count && i < CompendiumSidebarTop + 24; i++) {
                    Color col = Color.White;

                    if (GameLoop.WTN.player.QuestLog.TryGetValue(quests[i].ID, out QuestStatus? questProg) && questProg != null) {
                        if (questProg.CurrentStage != -1) { col = Color.Yellow; } 
                        if (questProg.CurrentStage == quests[i].CompleteStage) { col = Color.Lime; }
                    } 

                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(quests[i].Name, (CompendiumViewingID == quests[i].ID ? Color.Turquoise : col), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Quests"; CompendiumViewingID = quests[i].ID; });
                }

                if (GameLoop.WTN.QuestLibrary.TryGetValue(CompendiumViewingID, out Quest? quest) && quest != null) {
                    int questY = 3; 

                    Compendium.Print(32, questY++, "          ID: " + quest.ID, Color.White);
                    Compendium.Print(86, questY - 1, "QP: " + quest.QuestPoints, Color.White);
                    Compendium.Print(32, questY++, "        Name: " + quest.Name, Color.White); 
                    Compendium.Print(83, questY - 1, "Added: " + quest.DateFullyImplemented, Color.White);
                    Compendium.Print(32, questY++, "      Length: " + quest.Length, Color.White);  
                    Compendium.Print(32, questY++, "  Difficulty: " + quest.Difficulty, Color.White);

                    if (quest.RegionsNeeded != null && quest.RegionsNeeded.Count > 0) {
                        string regions = ""; 
                        for (int i = 0; i < quest.RegionsNeeded.Count; i++) {
                            regions += (i != 0 ? ", " : "") + quest.RegionsNeeded[i];
                        }

                        Compendium.Print(32, questY++, "Need Regions: " + regions, Color.White);    
                    }
                    questY++;
                    Compendium.Print(32, questY, "Description: ", Color.White); 
                    Compendium.PrintMultiLine(45, questY++, quest.Description, 53);

                    questY += 4;  
                    
                    Compendium.PrintClickable(32, questY++, "  Start NPC: " + GameLoop.WTN.ResolveNPCName(quest.StartNPC), () => { ResetAllCompendiumValues(); CompendiumCat = "Quests"; CompendiumViewingID = quest.StartNPC; }); 
                    questY++;
                    Compendium.Print(32, questY, "Tabs: ", Color.White);
                    Compendium.PrintClickable(38, questY, new ColoredString("Requirements", CompendiumViewingID2 == "Requirements" ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingID2 = "Requirements"; });
                    Compendium.PrintClickable(51, questY, new ColoredString("Rewards", CompendiumViewingID2 == "Rewards" ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingID2 = "Rewards"; });
                    Compendium.PrintClickable(59, questY++, new ColoredString("Stages", CompendiumViewingID2 == "Stages" ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingID2 = "Stages"; });


                    if (CompendiumViewingID2 == "Requirements") {
                        if (quest.RequirementsToStart != null && quest.RequirementsToStart.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (quest.RequirementsToStart.Count > 10) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, quest.RequirementsToStart.Count - 10); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, quest.RequirementsToStart.Count - 10); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < quest.RequirementsToStart.Count && i < CompendiumDropTop + 10 && questY < 29; i++) { 
                                Compendium.Print(32, questY++, "| " + quest.RequirementsToStart[i].GetSummary(), quest.CanStartQuest(GameLoop.WTN.player) ? Color.Lime : Color.Crimson);
                            }
                        } else {
                            Compendium.Print(32, questY++, "| (no requirements)", Color.DarkSlateGray);  
                        }
                    } else if (CompendiumViewingID2 == "Rewards") {
                        if (quest.Rewards != null && quest.Rewards.Count > 0) {
                            int dropQty = 1;
                            if (Helper.EitherShift())
                                dropQty *= 5;
                            if (Helper.EitherControl())
                                dropQty *= 10;


                            if (quest.Rewards.Count > 10) {
                                if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, quest.Rewards.Count - 10); }
                                if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, quest.Rewards.Count - 10); }
                            } else {
                                CompendiumDropTop = 0;
                            } 

                            for (int i = CompendiumDropTop; i < quest.Rewards.Count && i < CompendiumDropTop + 10 && questY < 29; i++) { 
                                Compendium.Print(32, questY++, "| " + quest.Rewards[i].GetSummary(), Color.White);
                            }
                        } else {
                            Compendium.Print(32, questY++, "| (no rewards)", Color.DarkSlateGray);  
                        }
                    }  else if (CompendiumViewingID2 == "Stages") {
                        if (quest.Stages != null && quest.Stages.Count > 0) {  
                            int qx = 32;
                            int qy = questY;
                            questY++;

                            foreach (var kv in quest.Stages) {
                                Compendium.PrintClickable(qx, qy, new ColoredString(kv.Key.ToString(), CompendiumViewingIndex2 == kv.Key ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex2 = kv.Key; return; });
                                qx += kv.Key.ToString().Length + 1;

                                if (kv.Key == CompendiumViewingIndex2) { 
                                    Compendium.Print(32, questY++, "  Next Stage: " + kv.Value.LeadsToStage, Color.White);  
                                    Compendium.Print(32, questY, "ProgressType: " + kv.Value.ProgressType, Color.White);

                                    if (GameLoop.WTN.ItemLibrary.ContainsKey(kv.Value.MiscString))
                                        Compendium.PrintClickable(65, questY++, "Item: " + GameLoop.WTN.ResolveItemName(kv.Value.MiscString), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = kv.Value.MiscString; });
                                    else if (GameLoop.WTN.NPCLibrary.ContainsKey(kv.Value.MiscString))
                                        Compendium.PrintClickable(65, questY++, "NPC: " + GameLoop.WTN.ResolveNPCName(kv.Value.MiscString), () => { ResetAllCompendiumValues(); CompendiumCat = "NPCs"; CompendiumViewingID = kv.Value.MiscString; });
                                    else
                                        Compendium.Print(65, questY++, "MiscString: " + kv.Value.MiscString, Color.White);
                                    if (kv.Value.MiscInt != 0)
                                        Compendium.Print(32, questY++, "     MiscInt: " + kv.Value.MiscInt, Color.White);  
                                    Compendium.PrintMultiLine(32, questY++, " Description: " + kv.Value.Description, 66);
                                } 
                            }
                        } else {
                            Compendium.Print(32, questY++, "| (no stages found, quest may not be implemented yet)", Color.DarkSlateGray);  
                        }
                    } 
                }
            } 
            else if (CompendiumCat == "Bosses") { // TODO: Do another pass over this at some point to make sure it's covering all data
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.BossLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.BossLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.BossLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "bossFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<BossFight> bosses = GameLoop.WTN.BossLibrary.Values.Where(u => u.Phases.Count > 0 && u.Phases[0].Name != null && u.Phases[0].Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Phases[0].Name).ToList();

                for(int i = CompendiumSidebarTop; i < bosses.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(bosses[i].Phases[0].Name, (CompendiumViewingID == bosses[i].ID ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Bosses"; CompendiumViewingID = bosses[i].ID; });
                }

                if (GameLoop.WTN.BossLibrary.TryGetValue(CompendiumViewingID, out BossFight? boss) && boss != null && boss.Phases.Count > 0) {
                    int bossY = 3;

                    Compendium.Print(32, bossY++, "  ID: " + boss.ID, Color.White);
                    Compendium.Print(32, bossY++, "Name: " + boss.Phases[0].Name, Color.White); 
                    Compendium.PrintClickable(82, 3, "[Show Locations]", () => { CompendiumShowSources = !CompendiumShowSources; if (CompendiumShowSources) { Sources = BossLocations(boss.ID); } });
                    
                    if (CompendiumShowSources) {
                        bossY++;
                        Compendium.Print(32, bossY++, "Locations Found: ", Color.White);

                        if (Sources.Count > 0) {
                            int srcQty = 1;
                            if (Helper.EitherShift())
                                srcQty *= 5;
                            if (Helper.EitherControl())
                                srcQty *= 10;


                            if (Sources.Count > 20) {
                                if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 20); }
                                if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 20); }
                            } else {
                                CompendiumSourceTop = 0;
                            }

                            for (int i = CompendiumSourceTop; i < Sources.Count && i < CompendiumSourceTop + 20; i++) {
                                Compendium.PrintClickable(32, bossY++, "| " + Sources[i].Display, () => { SetAllCompendiumValues(Sources[i]); });
                            }
                        } else {
                            Compendium.Print(32, bossY++, "| (not found in any map)", Color.DarkSlateGray);
                        }
                    } else {
                        bossY++; 

                        Compendium.Print(32, bossY++, "Level: " + boss.Level, Color.White);
                        Compendium.Print(32, bossY++, "Aggro: Lv" + boss.AggroLevel + " (Always Aggro: " + Helper.Checkmark(boss.AlwaysAggro) + new ColoredString(")")); 
                        Compendium.Print(32, bossY++, "Special Category: " + boss.SpecialCategory, Color.White); 
                        bossY++; 
                        Compendium.Print(32, bossY++, "Respawn: " + boss.RespawnTime + " seconds", Color.White);
                        Compendium.Print(32, bossY++, "Lanes Here: " + boss.LanesHere, Color.White); 
                        bossY++; 
                        Compendium.Print(32, bossY, "Phase Data: " + CompendiumViewingIndex3, Color.White);
                        if (boss.Phases.Count > 1) {
                            Compendium.PrintClickable(45, bossY, new ColoredString("-->", Color.White, Color.Black), () => { CompendiumViewingIndex3++; if (CompendiumViewingIndex >= boss.Phases.Count) { CompendiumViewingIndex3 = 0; } });
                        }
                        bossY++;

                        CompendiumViewingIndex3 = Math.Clamp(CompendiumViewingIndex3, 0, boss.Phases.Count - 1);

                        Compendium.Print(32, bossY++, "MaxHP: " + boss.Phases[CompendiumViewingIndex3].MaxHP, Color.White);
                        Compendium.Print(32, bossY++, "Damage Reduction: " + boss.Phases[CompendiumViewingIndex3].DamageReduction + "% (Weakness: " + boss.Phases[CompendiumViewingIndex3].WeakType + ")", Color.White);  
                        Compendium.Print(32, bossY++, "Default Damage: " + boss.Phases[CompendiumViewingIndex3].DefaultDmgDice + " " + boss.Phases[CompendiumViewingIndex3].DefaultDmgType, Color.White);
                        Compendium.Print(32, bossY++, "Attack Speed: " + boss.Phases[CompendiumViewingIndex3].AttackSpeedInMS + "ms", Color.White);
                        Compendium.Print(32, bossY++, "Attacks Between Specials: " + boss.Phases[CompendiumViewingIndex3].AttacksBetweenSpecials, Color.White); 

                        bossY++;
                        Compendium.Print(32, bossY, "Tables: ", Color.White);
                        Compendium.PrintClickable(40, bossY, new ColoredString("Drops", CompendiumViewingIndex2 == 0 ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex2 = 0; });
                        Compendium.PrintClickable(46, bossY++, new ColoredString("Attacks", CompendiumViewingIndex2 == 1 ? Color.Yellow : Color.DarkSlateGray, Color.Black), () => { CompendiumViewingIndex2 = 1; }); 

                        if (CompendiumViewingIndex2 == 0) {
                            bossY++;
                            Compendium.Print(32, bossY++, "Possible Items: ", Color.White);

                            if (boss.DropTable != null && boss.DropTable.Count > 0) {
                                int dropQty = 1;
                                if (Helper.EitherShift())
                                    dropQty *= 5;
                                if (Helper.EitherControl())
                                    dropQty *= 10;


                                if (boss.DropTable.Count > 8) {
                                    if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, boss.DropTable.Count - 8); }
                                    if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, boss.DropTable.Count - 8); }
                                } else {
                                    CompendiumDropTop = 0;
                                }  

                                for (int i = CompendiumDropTop; i < boss.DropTable.Count && i < CompendiumDropTop + 8; i++) { 
                                    Compendium.PrintClickable(32, bossY++, "| " + GameLoop.WTN.ResolveItemName(boss.DropTable[i].ItemID) + " [" + boss.DropTable[i].DropX + "/" + boss.DropTable[i].InY + "]", () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = boss.DropTable[i].ItemID; });
                                }
                            } else { 
                                Compendium.Print(32, bossY++, "| (no drops)", Color.DarkSlateGray);
                            }
                        } else if (CompendiumViewingIndex2 == 1) {
                            bossY++;
                            Compendium.Print(32, bossY++, "Possible Attacks: ", Color.White);

                            if (boss.Phases[CompendiumViewingIndex3].Specials != null && boss.Phases[CompendiumViewingIndex3].Specials.Count > 0) {
                                int dropQty = 1;
                                if (Helper.EitherShift())
                                    dropQty *= 5;
                                if (Helper.EitherControl())
                                    dropQty *= 10;


                                if (boss.Phases[CompendiumViewingIndex3].Specials.Count > 4) {
                                    if (Helper.ScrolledUp()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop - dropQty, 0, boss.Phases[CompendiumViewingIndex3].Specials.Count - 4); }
                                    if (Helper.ScrolledDown()) { CompendiumDropTop = Math.Clamp(CompendiumDropTop + dropQty, 0, boss.Phases[CompendiumViewingIndex3].Specials.Count - 4); }
                                } else {
                                    CompendiumDropTop = 0;
                                }  

                                for (int i = CompendiumDropTop; i < boss.Phases[CompendiumViewingIndex3].Specials.Count && i < CompendiumDropTop + 4; i++) {
                                    string lanes = "";

                                    for (int j = 0; j < boss.Phases[CompendiumViewingIndex3].Specials[i].HitsLanes.Count; j++) {
                                        lanes += (j != 0 ? ", " : "") + boss.Phases[CompendiumViewingIndex3].Specials[i].HitsLanes[j];
                                    }
                                    Compendium.Print(32, bossY++, Helper.Truncate(boss.Phases[CompendiumViewingIndex3].Specials[i].WarningText, 67), Color.White);
                                    Compendium.Print(32, bossY++, "> " + boss.Phases[CompendiumViewingIndex3].Specials[i].DamageDice + " " + boss.Phases[CompendiumViewingIndex3].Specials[i].DamageType + ", Lanes: " + lanes, Color.White);
                                }
                            } else { 
                                Compendium.Print(32, bossY++, "| (no specials)", Color.DarkSlateGray);
                            }
                        }
                    }
                }
            }
            else if (CompendiumCat == "Farming") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.player.FarmingPatches.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.player.FarmingPatches.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.player.FarmingPatches.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "farmFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<FarmingPatch> patches = GameLoop.WTN.player.FarmingPatches.Values.Where(u => (u.ID != null && u.ID.ToLower().Contains(Filter.ToLower())) || (u.PatchType != null && u.PatchType.ToLower().Contains(Filter.ToLower()))).OrderBy(o => o.ID).ToList();

                for(int i = CompendiumSidebarTop; i < patches.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(patches[i].ID, (CompendiumViewingID == patches[i].ID ? Color.Turquoise : (patches[i].SeedPlanted != "" && patches[i].TimeLeft <= 0) ? Color.Lime : (patches[i].SeedPlanted != "" && patches[i].TimeLeft > 0) ? Color.Yellow : Color.White), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Farming"; CompendiumViewingID = patches[i].ID; });
                }

                if (GameLoop.WTN.player.FarmingPatches.TryGetValue(CompendiumViewingID, out FarmingPatch? patch) && patch != null) {
                    int patchY = 3;

                    Compendium.Print(32, patchY++, "  ID: " + patch.ID, Color.White);
                    Compendium.Print(32, patchY++, "Type: " + patch.PatchType, Color.White); 
                    Compendium.PrintClickable(82, 3, "[Show Locations]", () => { CompendiumShowSources = !CompendiumShowSources; if (CompendiumShowSources) { Sources = PatchLocations(patch.ID); } });
                    
                    if (CompendiumShowSources) {
                        patchY++;
                        Compendium.Print(32, patchY++, "Locations Found: ", Color.White);

                        if (Sources.Count > 0) {
                            int srcQty = 1;
                            if (Helper.EitherShift())
                                srcQty *= 5;
                            if (Helper.EitherControl())
                                srcQty *= 10;


                            if (Sources.Count > 20) {
                                if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 20); }
                                if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 20); }
                            } else {
                                CompendiumSourceTop = 0;
                            }

                            for (int i = CompendiumSourceTop; i < Sources.Count && i < CompendiumSourceTop + 20; i++) {
                                Compendium.PrintClickable(32, patchY++, "| " + Sources[i].Display, () => { SetAllCompendiumValues(Sources[i]); });
                            }
                        } else {
                            Compendium.Print(32, patchY++, "| (not found in any map)", Color.DarkSlateGray);
                        }
                    } else {
                        patchY++; 

                        if (patch.SeedPlanted != "") {
                            Compendium.PrintClickable(32, patchY++, "Seed Planted: " + GameLoop.WTN.ResolveItemName(patch.SeedPlanted), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = patch.SeedPlanted; });
                            Compendium.Print(32, patchY++, "Time Remaining: " + patch.SeedPlanted, Color.White);
                            Compendium.Print(32, patchY++, "Compost: " + patch.Compost, Color.DarkSlateGray);
                        } else {
                            Compendium.Print(32, patchY++, "No Seed Planted", Color.DarkSlateGray);
                        }
                    }
                }
            } 
            else if (CompendiumCat == "Clues") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.ClueStepLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.ClueStepLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.ClueStepLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "clueFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<ClueStep> clues = GameLoop.WTN.ClueStepLibrary.Values.Where(u => (u.ID != null && u.ID.ToLower().Contains(Filter.ToLower())) || (u.HintText != null && u.HintText.ToLower().Contains(Filter.ToLower()))).OrderBy(o => o.ID).ToList();

                for(int i = CompendiumSidebarTop; i < clues.Count && i < CompendiumSidebarTop + 24; i++) {
                    Color col = Color.White;

                    if (GameLoop.WTN.player.CurrentClueTutorial == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueBeginner == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueEasy == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueMedium == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueHard == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueElite == clues[i].ID)
                        col = Color.Yellow;
                    if (GameLoop.WTN.player.CurrentClueMaster == clues[i].ID)
                        col = Color.Yellow;

                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(clues[i].ID, (CompendiumViewingID == clues[i].ID ? Color.Turquoise : col), Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Clues"; CompendiumViewingID = clues[i].ID; });
                }

                if (GameLoop.WTN.ClueStepLibrary.TryGetValue(CompendiumViewingID, out ClueStep? clue) && clue != null) {
                    int clueY = 3;

                    Compendium.Print(32, clueY++, "  ID: " + clue.ID, Color.White);
                    Compendium.Print(32, clueY, "Hint: ", Color.White);
                    
                    clueY = Compendium.PrintMultiLine(38, clueY++, clue.HintText, 60, Color.SandyBrown.R, Color.SandyBrown.G, Color.SandyBrown.B);
                    
                    clueY += 2; 
                    
                    Compendium.Print(32, clueY++, "Difficulty: " + clue.Difficulty, Color.White);
                    Compendium.Print(32, clueY++, " Clue Type: " + clue.ClueType, Color.White);
                    Compendium.PrintClickable(32, clueY++, " Solve Map: " + GameLoop.WTN.ResolveLocationName(clue.SolveLoc), () => { ResetAllCompendiumValues(); CompendiumCat = "Locations"; CompendiumViewingID = clue.SolveLoc; });
                    Compendium.Print(32, clueY++, "EmoteOrNPC: " + GameLoop.WTN.ResolveNPCName(clue.EmoteOrNpc), Color.White);

                    clueY++; 
                    Compendium.PrintClickable(32, clueY++, "Equip 1: " + GameLoop.WTN.ResolveItemName(clue.Equip1), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = clue.Equip1; });
                    Compendium.PrintClickable(32, clueY++, "Equip 2: " + GameLoop.WTN.ResolveItemName(clue.Equip2), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = clue.Equip2; });
                    Compendium.PrintClickable(32, clueY++, "Equip 3: " + GameLoop.WTN.ResolveItemName(clue.Equip3), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = clue.Equip3; });
                }
            }
            else if (CompendiumCat == "Skills") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.player.Skills.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.player.Skills.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.player.Skills.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3;  
                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "skillFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<Skill> skills = GameLoop.WTN.player.Skills.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Name).ToList();

                for(int i = CompendiumSidebarTop; i < skills.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(skills[i].Name, CompendiumViewingID == skills[i].Name ? Color.Yellow : Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Skills"; CompendiumViewingID = skills[i].Name; Sources = AllSkillUses(skills[i].Name); });
                }

                if (GameLoop.WTN.player.Skills.TryGetValue(CompendiumViewingID, out Skill? skill) && skill != null) {
                    int skillY = 3;

                    Compendium.Print(32, skillY, "Name: " + skill.Name, Color.White);
                    Compendium.Print(57, skillY, "Level: " + skill.Level, Color.White); 
                    Compendium.Print(72, skillY, "Exp: " + skill.Exp + "/" + skill.ExpToLevel(), Color.White);  

                    skillY += 2;

                    if (Sources.Count > 0) {
                        int srcQty = 1;
                        if (Helper.EitherShift())
                            srcQty *= 5;
                        if (Helper.EitherControl())
                            srcQty *= 10;


                        if (Sources.Count > 24) {
                            if (Helper.ScrolledUp()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop - srcQty, 0, Sources.Count - 24); }
                            if (Helper.ScrolledDown()) { CompendiumSourceTop = Math.Clamp(CompendiumSourceTop + srcQty, 0, Sources.Count - 24); }
                        } else {
                            CompendiumSourceTop = 0;
                        }

                        for (int i = CompendiumSourceTop; i < Sources.Count && i < CompendiumSourceTop + 24; i++) {
                            int.TryParse(Sources[i].Display[1..4], out int level);
                            Compendium.PrintClickable(32, skillY++, new ColoredString(Helper.Truncate(Sources[i].Display, 67), level <= skill.Level ? Color.White : Color.DarkSlateGray, Color.Black), () => { SetAllCompendiumValues(Sources[i]); });
                        }
                    } else {
                        Compendium.Print(32, skillY++, "(skill doesn't gate any content)", Color.DarkSlateGray);
                    }   
                }
            }
            else if (CompendiumCat == "Spells") {
                Compendium.DrawLine(new Point(30, 3), new Point(30, 28), 179);
                int qty = 1;
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;


                if (GameLoop.WTN.SpellLibrary.Count > 24) {
                    if (Helper.ScrolledUp()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop - qty, 0, GameLoop.WTN.SpellLibrary.Count - 24); }
                    if (Helper.ScrolledDown()) { CompendiumSidebarTop = Math.Clamp(CompendiumSidebarTop + qty, 0, GameLoop.WTN.SpellLibrary.Count - 24); }
                } else {
                    CompendiumSidebarTop = 0;
                }

                int sidebarY = 3; 

                
                Compendium.PrintStringField(2, sidebarY++, "Filter: ", ref Filter, ref SelectedField, "spellFilter");
                Compendium.DrawLine(new Point(1, sidebarY), new Point(29, sidebarY++), 196);

                List<Spell> spells = GameLoop.WTN.SpellLibrary.Values.Where(u => u.Name != null && u.Name.ToLower().Contains(Filter.ToLower())).OrderBy(o => o.Level).ToList();

                for(int i = CompendiumSidebarTop; i < spells.Count && i < CompendiumSidebarTop + 24; i++) {
                    Compendium.PrintClickable(2, sidebarY++, new ColoredString(spells[i].Name, CompendiumViewingID == spells[i].Name ? Color.Yellow : Color.White, Color.Black), () => { ResetAllCompendiumValues(); CompendiumCat = "Spells"; CompendiumViewingID = spells[i].ID; });
                }

                if (GameLoop.WTN.SpellLibrary.TryGetValue(CompendiumViewingID, out Spell? spell) && spell != null) {
                    int spellY = 3;

                    Compendium.Print(32, spellY++, "       Name: " + spell.Name, Color.White);  
                    Compendium.Print(32, spellY++, "       Book: " + spell.Book, Color.White); 
                    Compendium.Print(32, spellY++, "   Category: " + spell.Category, Color.White); 
                    Compendium.Print(32, spellY++, "Description: " + spell.Description, Color.White); 

                    spellY++;
                    Compendium.Print(32, spellY++, "      Level: " + spell.Level, Color.White);
                    Compendium.Print(32, spellY++, "Exp on Cast: " + spell.ExpOnCast, Color.White);  
                    Compendium.Print(32, spellY++, "       Tier: " + spell.Tier, Color.White);  
                    Compendium.Print(32, spellY++, " MiscString: " + spell.MiscString, Color.White);
                    Compendium.Print(32, spellY++, "Cooldown MS: " + spell.CooldownInMS, Color.White);

                    spellY++;
                    
                    Compendium.Print(32, spellY++, "Runes per Cast: ", Color.White);
                    if (spell.Runes != null && spell.Runes.Count > 0) {
                        for (int i = 0; i < spell.Runes.Count; i++) {
                            string[] split = spell.Runes[i].Split(",");
                            Compendium.PrintClickable(32, spellY++, "| " + (split.Length > 1 ? split[1] + "x " : "") + GameLoop.WTN.ResolveItemName(split[0]), () => { ResetAllCompendiumValues(); CompendiumCat = "Items"; CompendiumViewingID = split[0]; });
                        }
                    } else {
                        Compendium.Print(32, spellY++, "| (no runes required)", Color.DarkSlateGray);
                    }
                } 
            }

            Compendium.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Compendium.IsVisible = false; });    
        }

        public static void ResetAllCompendiumValues() {
            CompendiumCat = "";
            CompendiumSubCat = "";
            CompendiumViewingID = "";
            CompendiumViewingID2 = "";
            CompendiumViewingIndex = 0;
            CompendiumViewingIndex2 = 0;
            CompendiumShowSources = false; 
        }

        public static void SetAllCompendiumValues(CompendiumResult res) {
            CompendiumCat = res.Category;
            CompendiumSubCat = res.SubCategory;
            CompendiumViewingID = res.ViewID;
            CompendiumViewingID2 = res.ViewID2;
            CompendiumViewingIndex = res.ViewIndex;
            CompendiumViewingIndex2 = res.ViewIndex2;
            CompendiumSourceTop = 0;
            CompendiumDropTop = 0;
        }

        public static List<CompendiumResult> StationLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.ProcessingStations != null && kv.Value.ProcessingStations.Count > 0) {
                    if (kv.Value.ProcessingStations.Contains(id)) {
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 1));
                    }
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> PatchLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.FarmingPatchesHere != null && kv.Value.FarmingPatchesHere.Count > 0) {
                    if (kv.Value.FarmingPatchesHere.Contains(id)) {
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 5));
                    }
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

         public static List<CompendiumResult> BossLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.BossHere != null && kv.Value.BossHere == id) { 
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 8)); 
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        } 

        public static List<CompendiumResult> GatherLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.GatheringSpots != null && kv.Value.GatheringSpots.Count > 0) {
                    if (kv.Value.GatheringSpots.Contains(id)) {
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 0));
                    }
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> MonsterLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.AreaMonsters != null && kv.Value.AreaMonsters.Count > 0) {
                    if (kv.Value.AreaMonsters.Contains(id)) {
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 7));
                    }
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> NPCLocations(string id) {
            List<CompendiumResult> sources = new();
            
            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.NPCsHere != null && kv.Value.NPCsHere.Count > 0) {
                    if (kv.Value.NPCsHere.Contains(id)) {
                        sources.Add(new("[" + kv.Value.Region + "] " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 3));
                    }
                }
            }
            
            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> AllSkillUses(string id) {
            List<CompendiumResult> sources = new();

            foreach (var kv in GameLoop.WTN.ItemLibrary) {
                if (kv.Value.EquipSkill == id) {
                    sources.Add(new("[" + kv.Value.EquipLevel.ToString().Align(HorizontalAlignment.Right, 3) + "] Equip " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0) );
                }
            }

            foreach (var kv in GameLoop.WTN.UseRecipes) {
                if (kv.Value.SkillUsed == id) {
                    sources.Add(new("[" + kv.Value.SkillLevelReq.ToString().Align(HorizontalAlignment.Right, 3) + "] Use " + GameLoop.WTN.ResolveItemName(kv.Value.FirstItem) + " on " + GameLoop.WTN.ResolveItemName(kv.Value.SecondItem) + " to make " + GameLoop.WTN.ResolveItemName(kv.Value.OutputItem), "Recipes", "UseRecipe", kv.Value.FirstItem, kv.Value.SecondItem, 0) );
                }
            }

            foreach (var kv in GameLoop.WTN.CraftLib) {
                List<CraftRecipe> recipes = kv.Value.OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputItem))).ToList();
                for (int i = 0; i < recipes.Count; i++) {
                    if (recipes[i].Skill == id) {
                        sources.Add(new("[" + recipes[i].Level.ToString().Align(HorizontalAlignment.Right, 3) + "] Craft " + GameLoop.WTN.ResolveItemName(recipes[i].OutputItem) + " at " + recipes[i].Station, "Recipes", "CraftRecipe", "", recipes[i].Station, i));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.ProcessingStations) {
                List<ProcessingRecipe> recipes = kv.Value.Recipes.OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputID))).ToList();
                for (int i = 0; i < recipes.Count; i++) {
                    if (recipes[i].SkillUsed == id) {
                        if (kv.Value.Name != "Fire")
                            sources.Add(new("[" + recipes[i].SkillLevel.ToString().Align(HorizontalAlignment.Right, 3) + "] Process " + GameLoop.WTN.ResolveItemName(recipes[i].InputID) + " to " + GameLoop.WTN.ResolveItemName(recipes[i].OutputID) + " at " + kv.Value.Name, "Recipes", "ProcessRecipe", "", kv.Value.Name, i));
                    
                        if (recipes[i].SkillUsed == "Cooking" && recipes[i].StopFailingLevel > 0) {
                            sources.Add(new("[" + recipes[i].SkillLevel.ToString().Align(HorizontalAlignment.Right, 3) + "] Stop burning " + GameLoop.WTN.ResolveItemName(recipes[i].InputID) + " on " + kv.Value.Name, "Recipes", "ProcessRecipe", "", kv.Value.Name, i));
                        }    
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.Atlas) {
                for (int i = 0; i < kv.Value.ConnectedLocations.Count; i++) {
                    if (kv.Value.ConnectedLocations[i].ExpTo == id) { 
                        sources.Add(new("[" + kv.Value.ConnectedLocations[i].Level.ToString().Align(HorizontalAlignment.Right, 3) + "] Map: " + kv.Value.DisplayName + " [" + kv.Value.Region + "] to " + (kv.Value.ConnectedLocations[i].AltName == "" ? GameLoop.WTN.ResolveLocationName(kv.Value.ConnectedLocations[i].Destination) : kv.Value.ConnectedLocations[i].AltName), "Locations", "", kv.Value.ID, "", 0, 9));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.ItemLibrary) {  
                if (kv.Value.UseString == "CleanHerb" && id == "Alchemy") {
                    sources.Add(new("[" + kv.Value.UseInt.ToString().Align(HorizontalAlignment.Right, 3) + "] Clean " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0));
                }

                if (kv.Value.UseString == "PlantSeed" && id == "Farming") {
                    sources.Add(new("[" + kv.Value.UseInt.ToString().Align(HorizontalAlignment.Right, 3) + "] Plant " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0));
                }
            }

            foreach (var kv in GameLoop.WTN.GatherSpots) {
                if (kv.Value.Skill == id) {
                    if (kv.Value.PossibleItems != null && kv.Value.PossibleItems.Count > 1) {
                        for (int i = 0; i < kv.Value.PossibleItems.Count; i++) {
                            int level = kv.Value.Level;
                            if (kv.Value.PossibleItems[i].MiscInt != 0)
                                level = kv.Value.PossibleItems[i].MiscInt;

                            sources.Add(new("[" + level.ToString().Align(HorizontalAlignment.Right, 3) + "] " + kv.Value.InteractVerb + " " + kv.Value.Name + " - " + GameLoop.WTN.ResolveItemName(kv.Value.PossibleItems[i].Item), "Gathering", "", kv.Value.ID, "", 0));
                        }
                    } else {
                        sources.Add(new("[" + kv.Value.Level.ToString().Align(HorizontalAlignment.Right, 3) + "] " + kv.Value.InteractVerb + " " + kv.Value.Name, "Gathering", "", kv.Value.ID, "", 0));
                    }
                } 
            }

            foreach (var kv in GameLoop.WTN.QuestLibrary) {
                if (kv.Value.RequirementsToStart != null) {
                    for (int i = 0; i < kv.Value.RequirementsToStart.Count; i++) {
                        if (kv.Value.RequirementsToStart[i].RequirementType == "Skill" && kv.Value.RequirementsToStart[i].MiscString == id) { 
                            sources.Add(new("[" + kv.Value.RequirementsToStart[i].MiscInt.ToString().Align(HorizontalAlignment.Right, 3) + "] Required to Start Quest: " + kv.Value.Name, "Quests", "", kv.Value.ID, "", 0));
                        }
                    }
                } 
            }

            foreach (var kv in GameLoop.WTN.NPCLibrary) {
                if (kv.Value.PickpocketLevel > 0 && id == "Thieving") { 
                    sources.Add(new("[" + kv.Value.PickpocketLevel.ToString().Align(HorizontalAlignment.Right, 3) + "] Pickpocket " + kv.Value.Name, "NPCs", "", kv.Value.ID, "", 0)); 
                }
            } 

            if (id == "Magic") {
                foreach (var kv in GameLoop.WTN.SpellLibrary) {
                    sources.Add(new("[" + kv.Value.Level.ToString().Align(HorizontalAlignment.Right, 3) + "] Cast " + kv.Value.Name + " (" + kv.Value.Book + " Spellbook)", "Spells", "", kv.Value.ID, "", 0));  
                }
            } 

            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> ItemSources(string id) {
            List<CompendiumResult> sources = new();

            foreach (var kv in GameLoop.WTN.UseRecipes) {
                if (kv.Value.OutputItem == id) {
                    sources.Add(new("UseRecipe: " + GameLoop.WTN.ResolveItemName(kv.Value.FirstItem) + " + " + GameLoop.WTN.ResolveItemName(kv.Value.SecondItem), "Recipes", "UseRecipe", kv.Value.FirstItem, kv.Value.SecondItem, 0) );
                }

                if (kv.Value.FailID == id) {
                    sources.Add(new("UseRecipe: " + GameLoop.WTN.ResolveItemName(kv.Value.FirstItem) + " + " + GameLoop.WTN.ResolveItemName(kv.Value.SecondItem) + " failed below " + kv.Value.StopFailLevel + " " + kv.Value.SkillUsed, "Recipes", "UseRecipe", kv.Value.FirstItem, kv.Value.SecondItem, 0));
                }
            }

            foreach (var kv in GameLoop.WTN.CraftLib) {
                List<CraftRecipe> recipes = kv.Value.OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputItem))).ToList();
                for (int i = 0; i < recipes.Count; i++) {
                    if (recipes[i].OutputItem == id) {
                        sources.Add(new("CraftRecipe: " + recipes[i].Level + " " + recipes[i].Skill + " at " + recipes[i].Station, "Recipes", "CraftRecipe", "", recipes[i].Station, i));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.ProcessingStations.Where(o => !o.Value.DontIncludeInCounts)) {
                List<ProcessingRecipe> recipes = kv.Value.Recipes.OrderBy(o => (GameLoop.WTN.ResolveItemName(o.OutputID))).ToList();
                for (int i = 0; i < recipes.Count; i++) {
                    if (recipes[i].OutputID == id) {
                        if (recipes[i].SkillLevel > 0) {
                            sources.Add(new("Processing: " + GameLoop.WTN.ResolveItemName(recipes[i].InputID) + " at " + kv.Value.Name + " (" + recipes[i].SkillLevel + " " + recipes[i].SkillUsed + ")", "Recipes", "ProcessRecipe", "", kv.Value.Name, i));
                        } else {
                            sources.Add(new("Processing: " + GameLoop.WTN.ResolveItemName(recipes[i].InputID) + " at " + kv.Value.Name, "Recipes", "ProcessRecipe", "", kv.Value.Name, i));
                        }
                    }

                    if (recipes[i].FailOutput == id) {
                        sources.Add(new("Processing: " + GameLoop.WTN.ResolveItemName(recipes[i].InputID) + " failed at " + kv.Value.Name + " below " + recipes[i].StopFailingLevel + " " + recipes[i].SkillUsed, "Recipes", "ProcessRecipe", "", kv.Value.Name, i));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.MonsterLibrary) {
                for (int i = 0; i < kv.Value.DropTable.Count; i++) {
                    if (kv.Value.DropTable[i].ItemID == id) {
                        sources.Add(new("Drop: " + kv.Value.DropTable[i].DropX + "/" + kv.Value.DropTable[i].InY + " from " + kv.Value.Name, "Monsters", "", kv.Value.ID, "", 0));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.BossLibrary) {
                for (int i = 0; i < kv.Value.DropTable.Count; i++) {
                    if (kv.Value.DropTable[i].ItemID == id && kv.Value.Phases.Count > 0) {
                        sources.Add(new("Boss: " + kv.Value.DropTable[i].DropX + "/" + kv.Value.DropTable[i].InY + " from " + kv.Value.Phases[0].Name, "Bosses", "", kv.Value.ID, "", 0));
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.Atlas) {
                for (int i = 0; i < kv.Value.ItemSpawns.Count; i++) {
                    if (kv.Value.ItemSpawns[i].ItemID == id) {
                        sources.Add(new("Map Spawn: " + kv.Value.DisplayName, "Locations", "", kv.Value.ID, "", 0, 2));
                    }
                }

                if (kv.Value.ShopItemsHere != null) {
                    for (int i = 0; i < kv.Value.ShopItemsHere.Count; i++) {
                        if (kv.Value.ShopItemsHere[i] == id) {
                            sources.Add(new("Shop: " + kv.Value.DisplayName + " [" + kv.Value.Region + "]", "Locations", "", kv.Value.ID, "", 0, 4));
                        }
                    }
                }

                if (kv.Value.DigItem != null && kv.Value.DigItem != "" && kv.Value.DigItem == id) {
                    sources.Add(new("Dig at Location: " + kv.Value.DisplayName + " [" + kv.Value.Region + "]", "Locations", "", kv.Value.ID, "", 0));
                }
            }

            foreach (var kv in GameLoop.WTN.ItemLibrary) {
                for (int i = 0; i < kv.Value.DropTable.Count; i++) {
                    if (kv.Value.DropTable[i].ItemID == id) {
                        sources.Add(new("Item Loot: " + kv.Value.DropTable[i].DropX + "/" + kv.Value.DropTable[i].InY + " from " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0));
                    }
                }

                if (kv.Value.UseString == "CleanHerb" && kv.Value.UseString2 == id) {
                    sources.Add(new("Clean Herb: " + kv.Value.Name + " at " + kv.Value.UseInt + " Alchemy", "Items", "", kv.Value.ID, "", 0));
                }

                if (kv.Value.UseString == "PlantSeed" && kv.Value.UseString3 == id) {
                    sources.Add(new("Seed Produce: " + kv.Value.Name + " at " + kv.Value.UseInt + " Farming", "Items", "", kv.Value.ID, "", 0));
                }

                if (kv.Value.ItemReturned == id) {
                    sources.Add(new("Returned when " + kv.Value.Name + " is fully consumed.", "Items", "", kv.Value.ID, "", 0));
                }

                if (kv.Value.UseString == "Transform" && kv.Value.UseString2 == id) { sources.Add(new("Received from Activating: " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0)); }
                if (kv.Value.UseString == "Extinguish" && kv.Value.UseString2 == id) { sources.Add(new("Received from Extinguishing: " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0)); }
                if (kv.Value.UseString == "Light" && kv.Value.UseString2 == id) { sources.Add(new("Received from Lighting: " + kv.Value.Name, "Items", "", kv.Value.ID, "", 0)); }
            }

            foreach (var kv in GameLoop.WTN.GatherSpots) {
                if (kv.Value.PossibleItems != null) {
                    for (int i = 0; i < kv.Value.PossibleItems.Count; i++) {
                        if (kv.Value.PossibleItems[i].Item == id) {
                            int totalWeight = 0;

                            for (int j = 0; j < kv.Value.PossibleItems.Count; j++) {
                                totalWeight += kv.Value.PossibleItems[j].Weight;
                            }

                            sources.Add(new("Gather: " + kv.Value.PossibleItems[i].Weight + "/" + totalWeight + " from " + kv.Value.Name, "Gathering", "", kv.Value.ID, "", 0));
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.QuestLibrary) {
                if (kv.Value.Rewards != null) {
                    for (int i = 0; i < kv.Value.Rewards.Count; i++) {
                        if (kv.Value.Rewards[i].RewardType == "Item" && kv.Value.Rewards[i].MiscString == id) {
                            sources.Add(new("Quest Reward: " + kv.Value.Name, "Quests", "", kv.Value.ID, "", 0));
                        }
                    }
                }
            }

            foreach (var kv in GameLoop.WTN.NPCLibrary) {
                if (kv.Value.Dialogue != null) {
                    foreach (var kv2 in kv.Value.Dialogue) {
                        if (kv2.Value.ItemsGiven != null) {
                            for (int i = 0; i < kv2.Value.ItemsGiven.Count; i++) {
                                if (kv2.Value.ItemsGiven[i].Split(",")[0] == id) {
                                    sources.Add(new("Given by NPC: " + kv.Value.Name, "NPCs", "", kv.Value.ID, "", kv2.Key));
                                }
                            }
                        }
                    }

                    if (kv.Value.PickpocketLoot != null) {  
                        for (int i = 0; i < kv.Value.PickpocketLoot.Count; i++) {
                            if (kv.Value.PickpocketLoot[i].ItemID == id) { 
                                sources.Add(new("Pickpocket: " + kv.Value.PickpocketLoot[i].DropX + "/" + kv.Value.PickpocketLoot[i].InY + " from " + kv.Value.Name, "NPCs", "", kv.Value.ID, "", 0));
                            }
                        }
                    }
                }
            }  

            if (GameLoop.WTN.PotionRecipeLibrary.TryGetValue(id, out PotionRecipe? recipe)) {
                List<Item> ingredients = GameLoop.WTN.ItemLibrary.Values.Where(o => o.Alchemy != null && o.ID != "alchemyMixture").ToList();

                foreach (var ing1 in ingredients) {
                    foreach (var ing2 in ingredients) {
                        if (recipe.ReqsMet(ing1.Alchemy.Plus(ing2.Alchemy))) {
                            sources.Add(new("Alchemy: " + ing1.Name + " + " + ing2.Name, "Items", "", ing1.ID, "", 0));
                        }
                    }
                }
            }

            if (id.Contains("ashes") && GameLoop.WTN.ResolveItem(id.Replace("ashes", "log")) is Item log) {
                sources.Add(new("Burn a" + (Helper.VowelStart(log.Name.ToLower()) ? "n " : " ") + log.Name.ToLower() + " and wait for the fire to die.", "Items", "", id, "", 0));
            }

            if (id.Contains("talisman")) { 
                sources.Add(new("Drawn with ink and paper.", "Items", "", id, "", 0));
            }

            if (id == "casketTutorial") { sources.Add(new("Complete a Tutorial treasure trail and receive the casket at the end.", "Items", "", id, "", 0)); }
            if (id == "casketBeginner") { sources.Add(new("Complete a Beginner treasure trail and receive the casket at the end.", "Items", "", id, "", 0)); }
            if (id == "casketEasy") { sources.Add(new("Complete an Easy treasure trail and receive the casket at the end.", "Items", "", id, "", 0)); }
            if (id == "casketMedium") { sources.Add(new("Complete a Medium treasure trail and receive the casket at the end.", "Items", "", id, "", 0)); }

            if (id.Contains("petSkill")) {
                string skill = id.Replace("petSkill", "");
                sources.Add(new("Train " + skill + " (exp / 50,000,000 chance when exp gained).", "Skills", "", skill, "", 0));
            }

            sources = sources.OrderBy(o => o.Display).ToList();
            return sources;
        }

        public static List<CompendiumResult> DebugUnobtainable() { 
            List<CompendiumResult> sources = new();

            foreach (var kv in GameLoop.WTN.ItemLibrary) {
                if (ItemSources(kv.Key).Count == 0) {
                    sources.Add(new("Item: " + GameLoop.WTN.ResolveItemName(kv.Key) + " (" + kv.Key + ")", "", "", "", "", 0, 0));
                }
            }


            return sources;
        }

        public static List<CompendiumResult> DebugSongs() { 
            List<CompendiumResult> sources = new();
            List<string> SongsPlaced = new();

            foreach (var kv in GameLoop.WTN.Atlas) {
                if (kv.Value.SongHere != "") { SongsPlaced.Add(kv.Value.SongHere); } 
            }
            
            foreach (var song in GameLoop.SoundManager.Songs.Keys.OrderBy(o => o).ToList()) {
                if (!SongsPlaced.Contains(song)) { 
                    sources.Add(new(song, "", "", "", "", 0, 0));
                }
            }

            return sources;
        }


        static List<AreaMonster> monsterList = new();
        static List<BossFight> bossList = new();

        public static void CollectionLogDraw() { 
            Point mousePos = new MouseScreenObjectState(CollectionLog, GameHost.Instance.Mouse).CellPosition;
            CollectionLog.Clear();
            Helper.DrawBox(CollectionLog, 0, 0, 98, 28);
            CollectionLog.Print(2, 0, "[Collection Log]");


            CollectionLog.DrawLine(new Point(25, 1), new Point(25, 28), 179, Color.White);

            if (CollectionCat == "Clue") {
                CollectionLog.PrintClickable(2, 1, new ColoredString("Tutorial Casket", CollectionID == "casketTutorial" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketTutorial"; });
                CollectionLog.PrintClickable(2, 2, new ColoredString("Beginner Casket", CollectionID == "casketBeginner" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketBeginner"; });
                CollectionLog.PrintClickable(2, 3, new ColoredString("Easy Casket", CollectionID == "casketEasy" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketEasy"; });
                CollectionLog.PrintClickable(2, 4, new ColoredString("Medium Casket", CollectionID == "casketMedium" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketMedium"; });
                CollectionLog.PrintClickable(2, 5, new ColoredString("Hard Casket", CollectionID == "casketHard" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketHard"; });
                CollectionLog.PrintClickable(2, 6, new ColoredString("Elite Casket", CollectionID == "casketElite" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketElite"; });
                CollectionLog.PrintClickable(2, 7, new ColoredString("Master Casket", CollectionID == "casketMaster" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "casketMaster"; });
                CollectionLog.PrintClickable(2, 7, new ColoredString("General Collection", CollectionID == "General" ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = "General"; });
                
                Item? cask = null;

                GameLoop.WTN.ItemLibrary.TryGetValue(CollectionID, out cask);

                if (CollectionID == "General") {
                    GameLoop.WTN.ItemLibrary.TryGetValue("casketEasy", out cask);
                }


                if (cask != null && GameLoop.WTN.player.CollectionLogClues.ContainsKey(CollectionID)) { 
                    int qty = 1;
                    if (Helper.EitherShift()) {
                        qty *= 5;
                    }
                    if (Helper.EitherControl()) {
                        qty *= 10;
                    }

                    int count = cask.DropTable.Where(o => o.AltLog == CollectionID || (CollectionID != "General" && o.AltLog == "")).ToList().Count;

                    if (count > 24) {
                        if (Helper.ScrolledUp()) { CollectionDropTop = Math.Clamp(CollectionDropTop - qty, 0, count - 24); }
                        if (Helper.ScrolledDown()) { CollectionDropTop = Math.Clamp(CollectionDropTop + qty, 0, count - 24); }
                    }

                    int KC = 0;

                    if (GameLoop.WTN.player.CollectionLogClues.ContainsKey(CollectionID)) {
                        KC = GameLoop.WTN.player.CollectionLogClues[CollectionID].KillCount;
                    }

                    CollectionLog.Print(26, 1, (cask.Name + " (" + KC + " Opened)").Align(HorizontalAlignment.Center, 72), Color.White);
                    CollectionLog.DrawLine(new Point(26, 2), new Point(98, 2), 196, Color.White);
                    CollectionLog.Print(27, 3, "Item Name", Color.White);
                    CollectionLog.Print(79, 3, "Chance", Color.White);
                    CollectionLog.Print(90, 3, "Obtained", Color.White);
                    CollectionLog.DrawLine(new Point(26, 4), new Point(98, 4), 196, Color.White);

                    int printCount = 0;
                    List<ItemDrop> dropsSorted = cask.DropTable.Where(o => o.AltLog == CollectionID || (CollectionID != "General" && o.AltLog == "")).OrderBy(o => o.InY).ThenBy(p => GameLoop.WTN.ResolveItemName(p.ItemID)).ToList();
                    for (int i = CollectionDropTop; i < dropsSorted.Count && i < CollectionDropTop + 24; i++) { 
                        int timesObtained = 0;

                        if (GameLoop.WTN.player.CollectionLogClues[CollectionID].DropsObtained.ContainsKey(dropsSorted[i].ItemID)) {
                            timesObtained = GameLoop.WTN.player.CollectionLogClues[CollectionID].DropsObtained[dropsSorted[i].ItemID];
                        }

                        string name = GameLoop.WTN.ResolveItemName(dropsSorted[i].ItemID); 

                        if (dropsSorted[i].QuantityMax > 1) {
                            if (dropsSorted[i].QuantityMin == dropsSorted[i].QuantityMax) {
                                name += " (" + dropsSorted[i].QuantityMin + ")";
                            } else { 
                                name += " (" + dropsSorted[i].QuantityMin + "-" + dropsSorted[i].QuantityMax + ")";
                            }
                        }

                        string dropchance = (dropsSorted[i].DropX).ToString().PadLeft(5) + " in " + dropsSorted[i].InY;

                        Color col = timesObtained > 0 ? Color.White : Color.DarkSlateGray;
                        if (mousePos.Y == 5 + printCount && mousePos.X > 25)
                            col = col.GetDarker();

                        CollectionLog.Print(27, 5 + printCount, name, col);
                        CollectionLog.Print(88, 5 + printCount, timesObtained.ToString().PadLeft(10), col);
                        CollectionLog.Print(75, 5 + printCount, dropchance, col);
                        printCount++;
                    } 

                    if (CollectionDropTop != 0) {
                        CollectionLog.PrintVertical(99, 5, new ColoredString("^++", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 5, new ColoredString("^++", Color.Lime, Color.Black));
                    }

                    if (cask.DropTable.Count > CollectionDropTop + 24) {
                        CollectionLog.PrintVertical(99, 26, new ColoredString("++v", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 26, new ColoredString("++v", Color.Lime, Color.Black));
                    }
                }
            } else if (CollectionCat == "Boss") {
                bossList.Clear();
                bossList = GameLoop.WTN.BossLibrary.Values.Where(o=>o.Phases.Count > 0).ToList().OrderBy(f => f.Phases[0].Name).ToList();

                for (int i = 0; i < bossList.Count; i++) {
                    CollectionLog.PrintClickable(1, 1 + i, new ColoredString(" " + bossList[i].Phases[0].Name, CollectionID == bossList[i].ID ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = bossList[i].ID; });
                }

                if (GameLoop.WTN.BossLibrary.TryGetValue(CollectionID, out BossFight? view) && view != null && view.Phases.Count > 0) { 
                    if (view.DropTable.Count > 24) {
                        if (Helper.ScrolledUp()) { CollectionDropTop = Math.Clamp(CollectionDropTop - 1, 0, view.DropTable.Count - 24); }
                        if (Helper.ScrolledDown()) { CollectionDropTop = Math.Clamp(CollectionDropTop + 1, 0, view.DropTable.Count - 24); }
                    } else {
                        CollectionDropTop = 0;
                    }

                    int KC = 0;

                    if (GameLoop.WTN.player.CollectionLogBoss.ContainsKey(view.ID)) {
                        KC = GameLoop.WTN.player.CollectionLogBoss[view.ID].KillCount;
                    }

                    CollectionLog.Print(26, 1, (view.Phases[0].Name + " (" + KC + " KC)").Align(HorizontalAlignment.Center, 72), Color.White);
                    CollectionLog.DrawLine(new Point(26, 2), new Point(98, 2), 196, Color.White);
                    CollectionLog.Print(27, 3, "Item Name", Color.White);
                    CollectionLog.Print(79, 3, "Chance", Color.White);
                    CollectionLog.Print(90, 3, "Obtained", Color.White);
                    CollectionLog.DrawLine(new Point(26, 4), new Point(98, 4), 196, Color.White);

                    int printCount = 0; 
                    List<ItemDrop> dropsSorted = view.DropTable.OrderBy(o => o.InY).ThenBy(p => GameLoop.WTN.ResolveItemName(p.ItemID)).ToList();
                    for (int i = CollectionDropTop; i < dropsSorted.Count && i < CollectionDropTop + 24; i++) {
                        int timesObtained = 0;

                        if (GameLoop.WTN.player.CollectionLogBoss.ContainsKey(view.ID)) {
                            if (GameLoop.WTN.player.CollectionLogBoss[view.ID].DropsObtained.ContainsKey(dropsSorted[i].ItemID)) {
                                timesObtained = GameLoop.WTN.player.CollectionLogBoss[view.ID].DropsObtained[dropsSorted[i].ItemID];
                            }
                        }

                        string name = GameLoop.WTN.ResolveItemName(dropsSorted[i].ItemID); 

                        if (dropsSorted[i].QuantityMax > 1) {
                            if (dropsSorted[i].QuantityMin == dropsSorted[i].QuantityMax) {
                                name += " (" + dropsSorted[i].QuantityMin + ")";
                            } else { 
                                name += " (" + dropsSorted[i].QuantityMin + "-" + dropsSorted[i].QuantityMax + ")";
                            }
                        }

                        string dropchance = (dropsSorted[i].DropX).ToString().PadLeft(5) + " in " + dropsSorted[i].InY;

                        Color col = timesObtained > 0 ? Color.White : Color.DarkSlateGray;
                        if (mousePos.Y == 5 + printCount && mousePos.X > 25)
                            col = col.GetDarker();

                        CollectionLog.Print(27, 5 + printCount, name, col);
                        CollectionLog.Print(88, 5 + printCount, timesObtained.ToString().PadLeft(10), col);
                        CollectionLog.Print(75, 5 + printCount, dropchance, col);
                        printCount++;
                    }

                    if (CollectionDropTop != 0) {
                        CollectionLog.PrintVertical(99, 5, new ColoredString("^++", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 5, new ColoredString("^++", Color.Lime, Color.Black));
                    }

                    if (view.DropTable.Count > CollectionDropTop + 24) {
                        CollectionLog.PrintVertical(99, 26, new ColoredString("++v", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 26, new ColoredString("++v", Color.Lime, Color.Black));
                    }
                }
            } else {
                monsterList.Clear();
                monsterList = GameLoop.WTN.MonsterLibrary.Values.ToList().OrderBy(f => f.Name).ToList();

                int qty = 1;
                if (Helper.EitherShift()) { qty *= 5; }
                if (Helper.EitherControl()) { qty *= 10; }

                if (monsterList.Count > 28) {
                    if (Helper.ScrolledUp() && mousePos.X < 26) { CollectionSideTop = Math.Clamp(CollectionSideTop - qty, 0, monsterList.Count - 28); }
                    if (Helper.ScrolledDown() && mousePos.X < 26) { CollectionSideTop = Math.Clamp(CollectionSideTop + qty, 0, monsterList.Count - 28); }
                } else {
                    CollectionSideTop = 0;
                }

                for (int i = CollectionSideTop; i < monsterList.Count && i < CollectionSideTop + 28; i++) {
                    CollectionLog.PrintClickable(1, 1 + (i - CollectionSideTop), new ColoredString(Helper.Truncate(monsterList[i].Name.Align(HorizontalAlignment.Left, 21), 21) + (248.AsString() + monsterList[i].Level.ToString().Align(HorizontalAlignment.Right, 3)), CollectionID == monsterList[i].ID ? Color.Yellow : Color.White, Color.Black), () => { CollectionID = monsterList[i].ID; });
                }

                if (GameLoop.WTN.MonsterLibrary.ContainsKey(CollectionID)) {
                    AreaMonster view = GameLoop.WTN.MonsterLibrary[CollectionID];

                    if (view.DropTable.Count > 24) {
                        if (Helper.ScrolledUp() && mousePos.X > 26) { CollectionDropTop = Math.Clamp(CollectionDropTop - qty, 0, view.DropTable.Count - 24); }
                        if (Helper.ScrolledDown() && mousePos.X > 26) { CollectionDropTop = Math.Clamp(CollectionDropTop + qty, 0, view.DropTable.Count - 24); }
                    } else {
                        CollectionDropTop = 0;
                    }

                    int KC = 0;

                    if (GameLoop.WTN.player.CollectionLog.ContainsKey(view.ID)) {
                        KC = GameLoop.WTN.player.CollectionLog[view.ID].KillCount;
                    }

                    CollectionLog.Print(26, 1, (view.Name + " (" + KC + " KC)").Align(HorizontalAlignment.Center, 72), Color.White);
                    CollectionLog.DrawLine(new Point(26, 2), new Point(98, 2), 196, Color.White);
                    CollectionLog.Print(27, 3, "Item Name", Color.White);
                    CollectionLog.Print(79, 3, "Chance", Color.White);
                    CollectionLog.Print(90, 3, "Obtained", Color.White);
                    CollectionLog.DrawLine(new Point(26, 4), new Point(98, 4), 196, Color.White);

                    int printCount = 0;
                    List<ItemDrop> dropsSorted = view.DropTable.OrderBy(o => o.InY).ThenBy(p => GameLoop.WTN.ResolveItemName(p.ItemID)).ToList();
                    for (int i = CollectionDropTop; i < dropsSorted.Count && i < CollectionDropTop + 24; i++) {
                        int timesObtained = 0;

                        if (GameLoop.WTN.player.CollectionLog.ContainsKey(view.ID)) {
                            if (GameLoop.WTN.player.CollectionLog[view.ID].DropsObtained.ContainsKey(dropsSorted[i].ItemID)) {
                                timesObtained = GameLoop.WTN.player.CollectionLog[view.ID].DropsObtained[dropsSorted[i].ItemID];
                            }
                        }

                        string name = GameLoop.WTN.ResolveItemName(dropsSorted[i].ItemID); 

                        if (dropsSorted[i].QuantityMax > 1) {
                            if (dropsSorted[i].QuantityMin == dropsSorted[i].QuantityMax) {
                                name += " (" + dropsSorted[i].QuantityMin + ")";
                            } else { 
                                name += " (" + dropsSorted[i].QuantityMin + "-" + dropsSorted[i].QuantityMax + ")";
                            }
                        }

                        string dropchance = (dropsSorted[i].DropX).ToString().PadLeft(5) + " in " + dropsSorted[i].InY;

                        Color col = timesObtained > 0 ? Color.White : Color.DarkSlateGray;
                        if (mousePos.Y == 5 + printCount && mousePos.X > 25)
                            col = col.GetDarker();

                        CollectionLog.Print(27, 5 + printCount, name, col);
                        CollectionLog.Print(88, 5 + printCount, timesObtained.ToString().PadLeft(10), col);
                        CollectionLog.Print(75, 5 + printCount, dropchance, col);
                        printCount++;
                    }

                    if (CollectionDropTop != 0) {
                        CollectionLog.PrintVertical(99, 5, new ColoredString("^++", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 5, new ColoredString("^++", Color.Lime, Color.Black));
                    }

                    if (view.DropTable.Count > CollectionDropTop + 24) {
                        CollectionLog.PrintVertical(99, 26, new ColoredString("++v", Color.Lime, Color.Black));
                        CollectionLog.PrintVertical(25, 26, new ColoredString("++v", Color.Lime, Color.Black));
                    }
                }
            }


            
            CollectionLog.PrintClickable(75, 0, new ColoredString("[CLUE]", CollectionCat == "Clue" ? Color.White : Color.DarkSlateGray, Color.Black), () => { CollectionCat = "Clue"; });
            CollectionLog.PrintClickable(82, 0, new ColoredString("[BOSS]", CollectionCat == "Boss" ? Color.White : Color.DarkSlateGray, Color.Black), () => { CollectionCat = "Boss"; }); 
            CollectionLog.PrintClickable(89, 0, new ColoredString("[MONSTER]", CollectionCat == "Monster" ? Color.White : Color.DarkSlateGray, Color.Black), () => { CollectionCat = "Monster"; });

            CollectionLog.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { CollectionLog.IsVisible = false; });
        }

        public static void CraftingMenuDraw() { 
            Point mousePos = new MouseScreenObjectState(CraftingMenu, GameHost.Instance.Mouse).CellPosition;

            CraftingMenu.Clear(); 
            Helper.DrawBox(CraftingMenu, 0, 0, 98, 28);
            CraftingMenu.Print(2, 0, "[Crafting Menu - " + CraftingType + "]");
            CraftingMenu.DrawLine(new Point(25, 1), new Point(25, 28), 179);  

            List<string> ItemsUsed = new();

            if (GameLoop.WTN.CraftLib.ContainsKey(CraftingType)) {
                foreach (var craft in GameLoop.WTN.CraftLib[CraftingType]) {
                    string item = GameLoop.WTN.ResolveItemName(craft.NeededItems[0].Split(",")[0]);
                    if (!ItemsUsed.Contains(item)) {
                        ItemsUsed.Add(item);
                    }
                }

                ItemsUsed.Sort();  

                if (CraftingType == "Anvil") {
                    foreach (var metal in Materials.MetalNames) {
                        ItemsUsed.Remove(metal + " bar");
                    }

                    List<string> temp = new(ItemsUsed);
                    ItemsUsed = new(Materials.MetalNames.Select(o  => o + " bar"));
                    ItemsUsed.AddRange(temp);
                }

                if (CraftingType == "Knife") {
                    foreach (var wood in Materials.WoodNames) {
                        ItemsUsed.Remove(wood + " log");
                    }

                    List<string> temp = new(ItemsUsed);
                    ItemsUsed = new(Materials.WoodNames.Select(o  => o + " log"));
                    ItemsUsed.AddRange(temp);
                }
            }

            if (CraftingSubtype == "" || !ItemsUsed.Contains(CraftingSubtype)) {
                if (ItemsUsed.Count > 0) {
                    CraftingSubtype = ItemsUsed[0];
                    PopulateCraftList();
                }
            } 

            for (int i = 0; i < ItemsUsed.Count; i++) {
                CraftingMenu.PrintClickable(1, 1 + i, ItemsUsed[i], () => { CraftingSubtype = ItemsUsed[i]; PopulateCraftList(); });
            } 

            CraftingMenu.DrawLine(new Point(26, 2), new Point(98, 2), 196, Color.White);
            CraftingMenu.Print(27, 1, "Crafted Item", Color.White); 
            CraftingMenu.Print(60, 1, "Lev", Color.White);
            CraftingMenu.Print(67, 1, "Exp", Color.White);
            CraftingMenu.Print(74, 1, "Input", Color.White);
            CraftingMenu.Print(85, 1, "Tool", Color.White);

            int idx = 1;
            if (Helper.EitherShift())
                idx *= 5;
            if (Helper.EitherControl())
                idx *= 10;


            if (ActiveRecipes.Count > 26) {
                if (Helper.ScrolledUp() && mousePos.X > 25) { CraftingListTop = Math.Clamp(CraftingListTop - idx, 0, ActiveRecipes.Count - 26); }
                if (Helper.ScrolledDown() && mousePos.X > 25) { CraftingListTop = Math.Clamp(CraftingListTop + idx, 0, ActiveRecipes.Count - 26); }
            } else {
                CraftingListTop = 0;
            }

            int printY = 0;
            for (int i = CraftingListTop; i < ActiveRecipes.Count && i < CraftingListTop + 26; i++) {
                CraftRecipe rec = ActiveRecipes[i];
                string name = GameLoop.WTN.ResolveItemName(rec.OutputItem) + (rec.OutputQty > 1 ? " x" + rec.OutputQty : "");

                string[] item = rec.NeededItems[0].Split(",");
                string line = name.Align(HorizontalAlignment.Left, 31, ' ') + 179.AsString() + " "
                    + rec.Level.ToString().Align(HorizontalAlignment.Right, 3) + " " + 179.AsString() + " "
                    + rec.ExpGranted.ToString().Align(HorizontalAlignment.Right, 5) + " " + 179.AsString() + " "
                    + item[1].Align(HorizontalAlignment.Right, 5) + " " + 179.AsString() + " "
                    + GameLoop.WTN.ResolveItemName(rec.ExtraTool);

                if (GameLoop.WTN.player.CanCraft(rec) && rec.Level <= CraftingMaxLevel) { 
                    CraftingMenu.PrintClickable(27, 3 + printY++, new ColoredString(line, Color.White, Color.Black), () => { GameLoop.WTN.player.TryCraft(rec); });
                } else { 
                    CraftingMenu.PrintClickable(27, 3 + printY++, new ColoredString(line, Color.Crimson, Color.Black), () => {
                        string mats = "To make " + GameLoop.WTN.ResolveItemName(rec.OutputItem).ToLower() + ": " + rec.Level + " " + rec.Skill + ", ";

                        for (int mat = 0; mat < rec.NeededItems.Count; mat++) {
                            string[] split = rec.NeededItems[mat].Split(",");
                            mats += (mat == 0 ? "" : ", ") + (split.Length > 1 ? split[1] + "x " : "") + GameLoop.WTN.ResolveItemName(split[0]).ToLower();
                        } 

                        if (rec.ExtraTool != "") {
                            string name = GameLoop.WTN.ResolveItemName(rec.ExtraTool).ToLower();
                            mats += " and a" + (Helper.VowelStart(name) ? "n ": " ") + name + ".";
                        }

                        GameLoop.WTN.Log.AddMessage(mats, Color.Crimson);

                        if (rec.Reqs.Count > 0) { 
                            foreach (var kv in rec.Reqs) { 
                                GameLoop.WTN.Log.AddMessage("Also: " + kv.GetSummary(), kv.CheckRequirement(GameLoop.WTN.player, false, true) ? Color.Lime : Color.Crimson);
                            } 
                        } 

                        if (rec.Level > CraftingMaxLevel) {
                            GameLoop.WTN.Log.AddMessage("And a station or tool capable of level " + rec.Level + " crafts.",  Color.Crimson);
                        }
                    });
                }
            }


            CraftingMenu.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { CraftingMenu.IsVisible = false; });
        }

        public static void PopulateCraftList() {
            ActiveRecipes.Clear();

            if (GameLoop.WTN.CraftLib.ContainsKey(CraftingType)) {
                foreach (var craft in GameLoop.WTN.CraftLib[CraftingType]) {
                    string itemNeeded = GameLoop.WTN.ResolveItemName(craft.NeededItems[0].Split(",")[0]);
                    if (itemNeeded == CraftingSubtype) {
                        ActiveRecipes.Add(craft);
                    }
                }
            }
        }

        public static List<string> QuestLengths = [ "Very Short", "Short", "Medium", "Long", "Very Long" ];
        public static List<string> QuestDifficulties = ["Novice", "Intermediate", "Experienced", "Master", "Grandmaster" ];
        public static List<string> QuestRegions = [ "Asgarnia", "Desert", "Fremennik", "Kandarin", "Karamja", "Misthalin", "Morytania", "Wilderness" ];

        public static void QuestDraw() {
            Quests.Clear();
            Helper.DrawBox(Quests, 0, 0, 98, 28);
            if (ViewingQuestID == "") {
                Quests.Print(2, 0, "[Quest Log - " + QuestFilter + " Quests]");
            } else { 
                if (GameLoop.WTN.QuestLibrary.TryGetValue(ViewingQuestID, out Quest? currQuest)) { 
                    Quests.Print(2, 0, "[Quest Log - " + currQuest.Name + "]");
                } 
            } 
            Quests.DrawLine(new Point(17, 1), new Point(17, 28), 179);

            Quests.PrintClickable(1, 1, new ColoredString("Show All Quests", QuestFilter == "All" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { QuestFilter = "All"; ViewingQuestID = ""; });


            int printSide = 3;
            Quests.Print(1, printSide++, "By Length");
            for (int i = 0; i < QuestLengths.Count; i++) {
                Quests.PrintClickable(2, printSide++, new ColoredString(QuestLengths[i], QuestFilter == QuestLengths[i] ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { QuestFilter = QuestLengths[i]; ViewingQuestID = ""; });
            }
            printSide++;

            Quests.Print(1, printSide++, "By Difficulty");
            for (int i = 0; i < QuestDifficulties.Count; i++) {
                Quests.PrintClickable(2, printSide++, new ColoredString(QuestDifficulties[i], QuestFilter == QuestDifficulties[i] ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { QuestFilter = QuestDifficulties[i]; ViewingQuestID = ""; });
            }
            printSide++;

            Quests.Print(1, printSide, "By Region"); 
            Quests.PrintClickable(11, printSide++, new ColoredString("(Mine)", QuestFilter == "MyRegions" ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { QuestFilter = "MyRegions"; ViewingQuestID = ""; });

            for (int i = 0; i < QuestRegions.Count; i++) {
                Quests.PrintClickable(2, printSide++, new ColoredString(QuestRegions[i], QuestFilter == QuestRegions[i] ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { QuestFilter = QuestRegions[i]; ViewingQuestID = ""; });
            }
            printSide++;

            List<Quest> QuestsInFilter = new();
            QuestsInFilter = QuestsInFilter.OrderBy(o => o.Name).ToList();

            foreach(var kv in GameLoop.WTN.QuestLibrary) {
                if (QuestFilter == "MyRegions") {

                }
                else {
                    if (QuestFilter == "All" || kv.Value.Difficulty == QuestFilter || kv.Value.Length == QuestFilter || kv.Value.RegionsNeeded.Contains(QuestFilter)) {
                        QuestsInFilter.Add(kv.Value);
                    }
                }
            }

            if (ViewingQuestID == "") {
                for(int i = 0; i < QuestsInFilter.Count; i++) { 
                    Color col = Color.DarkSlateGray;

                    if (QuestsInFilter[i].CanStartQuest(GameLoop.WTN.player)) {
                        col = Color.Crimson;
                    }

                    if (QuestsInFilter[i].CurrentStage() != -1) {
                        col = Color.Yellow;
                    }

                    if (QuestsInFilter[i].CurrentStage() == QuestsInFilter[i].CompleteStage) {
                        col = Color.Lime;
                    }

                    Quests.PrintClickable(19, 1 + i, new ColoredString(QuestsInFilter[i].Name, col, Color.Black), () => {
                        ViewingQuestID = QuestsInFilter[i].ID;

                        if (GameLoop.WTN.QuestLibrary.TryGetValue(ViewingQuestID, out Quest? nowViewing)) {
                            if (nowViewing != null) {
                                if (nowViewing.CurrentStage() == -1) {
                                    QuestOverview = true;
                                } else {
                                    QuestOverview = false; 
                                    QuestBlockScrollTop = 0;
                                }
                            } else {
                                QuestOverview = true;
                            }
                        } else {
                            QuestOverview = true;
                        }
                    });
                }
            } else {
                if (GameLoop.WTN.QuestLibrary.TryGetValue(ViewingQuestID, out Quest? currQuest)) {

                    if (QuestOverview) {
                        Quests.Print(19, 1, "Quest Name: " + currQuest.Name);
                        Quests.Print(19, 2, "Difficulty: " + currQuest.Difficulty);
                        Quests.Print(19, 3, "    Length: " + currQuest.Length);
                        Quests.Print(19, 4, " Start NPC: " + GameLoop.WTN.ResolveNPCName(currQuest.StartNPC) + " (" + GameLoop.WTN.ResolveLocationName(currQuest.StartLoc) + ")");

                        int afterDesc = Quests.PrintMultiLine(19, 6, currQuest.Description, 80) + 2;

                        if (currQuest.CurrentStage() != -1) {
                            Quests.PrintClickable(19, afterDesc, "[View Quest Log]", () => { QuestOverview = false; QuestBlockScrollTop = 0; });

                            if (currQuest.CurrentStage() == currQuest.CompleteStage)
                                Quests.Print(19, afterDesc + 2, "Quest Complete!", Color.Lime);
                        }
                    } else {
                        int visibleStages = 0;
                        
                        foreach (var kv in currQuest.Stages) {
                            if (kv.Key <= currQuest.CurrentStage()) {
                                visibleStages++;
                            }
                        }

                        if (Helper.ScrolledDown()) { QuestBlockScrollTop = Math.Clamp(QuestBlockScrollTop - 1, 0, visibleStages - 1); }
                        if (Helper.ScrolledUp()) { QuestBlockScrollTop = Math.Clamp(QuestBlockScrollTop + 1, 0, visibleStages - 1); }


                        Quests.PrintClickable(19, 1, "[View Quest Overview]", () => { QuestOverview = true; });

                        int printY = 28;
                        int count = -1; 

                        foreach (var kv in currQuest.Stages.Reverse()) {
                            if (kv.Key <= currQuest.CurrentStage()) {
                                count++;
                                if (count < QuestBlockScrollTop) { continue; }

                                Color col = kv.Key == currQuest.CurrentStage() ? Color.White : Color.DarkSlateGray;

                                //if (kv.Value.Description.Length >= 80) { printY -= (kv.Value.Description.Length / 75); } 

                                int simPrint = Quests.PrintMultiLine(19, printY, kv.Value.Description, 80, col.R, col.G, col.B, justSim: true);

                                printY -= (simPrint - printY) + 1;

                                if (printY < 2) { break; }

                                Quests.PrintMultiLine(19, printY, kv.Value.Description, 80, col.R, col.G, col.B);
                            }
                        } 

                        if (currQuest.CurrentStage() == currQuest.CompleteStage)
                            Quests.Print(19, 28, "Quest Complete!", Color.Lime);

                        Quests.DrawLine(new Point(1, 29), (98, 29), 196, Color.White);
                    }
                } 
            }

            Quests.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Quests.IsVisible = false; });
        }
    
        
        public static void ClueDraw() {
            Clue.Clear();
            Helper.DrawBox(Clue, 0, 0, 68, 18);
            Clue.Print(2, 0, "[Clue Scroll]".Align(HorizontalAlignment.Center, 66, (char) 196)); 

            if (GameLoop.WTN.ClueStepLibrary.TryGetValue(CurrentClue, out ClueStep? clue) && clue != null) {
                if (GameLoop.WTN.Atlas.TryGetValue(clue.SolveLoc, out Location? loc) && loc != null && loc.DescriptionBlocks.Count > 0) {
                    int endpoint = Clue.PrintMultiLine(2, 0, loc.DescriptionBlocks[0].Description, 66);

                    Clue.Clear();
                    Helper.DrawBox(Clue, 0, 0, 68, 18);
                    Clue.Print(2, 0, "[Clue Scroll]".Align(HorizontalAlignment.Center, 66, (char) 196)); 

                    Clue.PrintMultiLine(2, (20 - endpoint) / 2, loc.DescriptionBlocks[0].Description, 66, center: true);
                }
            }
             
            
            Clue.Print(2, 18, "Find the map location with this description.", Color.DarkSlateGray); 
            Clue.PrintClickable(69, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Clue.IsVisible = false; });
        }    
    
        
        public static void TeleportDraw() {
            Teleport.Clear();
            Helper.DrawBox(Teleport, 0, 0, 48, 28);
            Teleport.Print(2, 0, "[Teleport Options]");

            for(int i = 0; i < TeleportDests.Count; i++) {
                if (GameLoop.WTN.Atlas.TryGetValue(TeleportDests[i], out Location? dest)) { 
                    Teleport.PrintClickable(2, 1 + i, dest.DisplayName, () => { 
                        Teleport.IsVisible = false; 
                        GameLoop.WTN.player.NavLoc = TeleportDests[i]; 
                        GameLoop.WTN.Log.AddMessage("You teleport to " + GameLoop.WTN.ResolveLocationName(TeleportDests[i]) + ".");
                        TeleportDests = new();

                        if (TeleWrap != null && TeleCostsCharges) { 
                            TeleWrap.Charges -= 1;  
                            if (TeleWrap.Charges <= 0) {
                                if (TeleWrap.GetRef() is Item unwrap && unwrap.ShattersAtZeroCharges) {
                                    GameLoop.WTN.Log.AddMessage("Your " + unwrap.Name + " runs out of charges and shatters.", Color.Crimson);
                                    GameLoop.WTN.player.Inventory.Remove(TeleWrap);
                                    
                                    if (unwrap.EquipSlot != "" && GameLoop.WTN.player.Equipment.TryGetValue(unwrap.EquipSlot, out ItemWrapper? wrap) && wrap != null && wrap == TeleWrap) {
                                        GameLoop.WTN.player.Equipment.Remove(unwrap.EquipSlot);
                                    }
                                }
                            }
                        }

                        TeleWrap = null; 
                    });
                } else {
                    Teleport.Print(2, 1 + i, TeleportDests[i], Color.DarkSlateGray);
                }
            }
             
              
            Teleport.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Teleport.IsVisible = false; });
        }    
    
        public static void InventoryContainerDraw() {
            InventoryContainer.Clear();
            Helper.DrawBox(InventoryContainer, 0, 0, 48, 8);
            if (ConWrap != null && ConWrap.GetRef() is Item con) {
                InventoryContainer.Print(2, 0, "[Inventory Container - " + con.Name + "]");

                for (int i = ConWrap.Containing.Count - 1; i >= 0; i--) {
                    if (ConWrap.Containing[i].GetRef() is Item contained) {
                        InventoryContainer.PrintClickable(2, 1 + i, contained.GetNameCS(ConWrap.Containing[i].Quantity, 0, ConWrap.Containing[i].Charges, ConWrap.Containing[i].Noted), () => {
                            int qty = 1;
                            if (Helper.EitherShift()) { qty *= 5; }
                            if (Helper.EitherControl()) { qty *= 10; }
                            if (qty > ConWrap.Containing[i].Quantity || Helper.EitherAlt()) { qty = ConWrap.Containing[i].Quantity; }

                            GameLoop.WTN.player.TryPickup(ConWrap.Containing[i], qty);
                             
                            if (ConWrap.Containing[i].Quantity <= 0) {
                                ConWrap.Containing.RemoveAt(i);
                            }
                        });
                    }
                }
            }
            InventoryContainer.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { InventoryContainer.IsVisible = false; ConWrap = null; });
        }        
    
        
        public static void BookDraw() {
            Book.Clear();
            Helper.DrawBox(Book, 0, 0, 75, 23);

            if (GameLoop.WTN.BookLibrary.TryGetValue(BookID, out Book? book)) {
                Book.Print(1, 0, ("[" + book.Name + "]").Align(HorizontalAlignment.Center, 75, (char) 196));

                if (book.FrameType == 1) {
                    Book.DrawLine(new Point(3, 2), new Point(35, 2), 196, Color.White);
                    Book.DrawLine(new Point(41, 2), new Point(73, 2), 196, Color.White); 
                    Book.Print(36, 3, "\\   /", Color.White);

                    Book.DrawLine(new Point(2, 4), new Point(2, 22), 179, Color.White);
                    Book.DrawLine(new Point(3, 3), new Point(3, 21), 179, Color.White);
                    Book.DrawLine(new Point(73, 3), new Point(73, 21), 179, Color.White);
                    Book.DrawLine(new Point(74, 3), new Point(74, 22), 179, Color.White);

                    Book.DrawLine(new Point(3, 22), new Point(35, 22), 196, Color.White);
                    Book.DrawLine(new Point(41, 22), new Point(73, 22), 196, Color.White); 
                    Book.DrawLine(new Point(3, 23), new Point(35, 23), 196, Color.White);
                    Book.DrawLine(new Point(41, 23), new Point(73, 23), 196, Color.White); 
                    Book.Print(36, 22, "/   \\", Color.White);
                    Book.Print(35, 23, "/     \\", Color.White);
                     
                    Book.Print(3, 2, "/", Color.White);
                    Book.Print(2, 3, "/", Color.White);
                    Book.Print(3, 22, "/", Color.White);
                    Book.Print(2, 23, "/", Color.White);
                     
                    Book.Print(73, 2, "\\", Color.White);
                    Book.Print(74, 3, "\\", Color.White);
                    Book.Print(73, 22, "\\", Color.White);
                    Book.Print(74, 23, "\\", Color.White);
                    Book.Print(36, 23, "_____", Color.White);
                    
                    Book.DrawLine(new Point(37, 4), new Point(37, 21), 179, Color.White);
                    Book.DrawLine(new Point(38, 4), new Point(38, 21), '|', Color.White);
                    Book.DrawLine(new Point(39, 4), new Point(39, 21), 179, Color.White);
                    
                    Book.Print(5, 3, book.Pages[LeftPage].Name, Color.White);
                    Book.PrintMultiLine(5, book.Pages[LeftPage].Name == "" ? 3 : 5, book.Pages[LeftPage].Text, 31);

                    if (book.Pages.Count > LeftPage + 1) { 
                        Book.Print(41, 3, book.Pages[LeftPage + 1].Name.Align(HorizontalAlignment.Right, 31), Color.White);
                        Book.PrintMultiLine(43, book.Pages[LeftPage + 1].Name == "" ? 3 : 5, book.Pages[LeftPage + 1].Text, 31);
                    }

                    if (book.Pages.Count > LeftPage + 2) { 
                        Book.PrintClickable(61, 23, "[NEXT PAGE]", () => { 
                            LeftPage += 2; 
                            book.Pages[LeftPage].Reached(); 
                            if (book.Pages.Count > LeftPage + 1) { 
                                book.Pages[LeftPage+1].Reached(); 
                            }
                        });
                    }
                    if (LeftPage > 1) { Book.PrintClickable(5, 23, "[LAST PAGE]", () => { LeftPage -= 2; }); }
                } else if (book.FrameType == 0) { 
                    Book.DrawLine(new Point(21, 2), new Point(55, 2), 196, Color.White);
                    Book.DrawLine(new Point(21, 21), new Point(55, 21), 196, Color.White);
                    Book.DrawLine(new Point(21, 3), new Point(21, 20), 179, Color.White);
                    Book.DrawLine(new Point(55, 3), new Point(55, 20), 179, Color.White);
                     
                    Book.Print(22, 3, book.Pages[LeftPage].Name.Align(HorizontalAlignment.Center, 33), Color.White);
                    Book.PrintMultiLine(23, book.Pages[LeftPage].Name == "" ? 3 : 5, book.Pages[LeftPage].Text, 31);

                    if (book.Pages.Count > LeftPage + 1) { 
                        Book.PrintClickable(45, 22, "[NEXT PAGE]", () => { 
                            LeftPage += 1; 
                            book.Pages[LeftPage].Reached();
                        });
                    }
                    if (LeftPage > 0) { Book.PrintClickable(21, 22, "[LAST PAGE]", () => { LeftPage -= 1; }); }
                }
            }
            Book.PrintClickable(76, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Book.IsVisible = false; });
        }    
    
        public static void CutsceneDraw() {
            Cutscene.Clear();
            Helper.DrawBox(Cutscene, 0, 0, 98, 28);

            if (GameLoop.WTN.CutsceneLibrary.TryGetValue(CutsceneID, out Cutscene? cut)) { 
                Cutscene.Print(2, 0, ("[" + cut.DisplayTitle + "]").Align(HorizontalAlignment.Center, 98, (char)196));
                
                Helper.DrawBox(Cutscene, 1, 1, 96, 18);
                Helper.DrawBox(Cutscene, 1, 20, 96, 7);

                if (CutsceneScene < cut.Scenes.Count) { 
                    Cutscene.PrintMultiLine(2, 8, cut.Scenes[CutsceneScene].Description, 96, center: true);

                    if (CutsceneDialogue < cut.Scenes[CutsceneScene].DialogueLines.Count) {
                        Cutscene.PrintMultiLine(2, 22, cut.Scenes[CutsceneScene].DialogueLines[CutsceneDialogue], 96, center: true);
                    }

                    if (cut.Scenes[CutsceneScene].DialogueLines.Count > CutsceneDialogue + 1) {
                        Cutscene.PrintClickable(92, 28, "[NEXT]", () => { CutsceneDialogue++; });
                    } else if (cut.Scenes.Count > CutsceneScene + 1) { 
                        Cutscene.PrintClickable(92, 28, "[NEXT]", () => { CutsceneDialogue = 0; CutsceneScene++; });
                    } else {
                        Cutscene.PrintClickable(91, 28, "[CLOSE]", () => { 
                            CutsceneDialogue = 0; 
                            CutsceneScene = 0; 
                            Cutscene.IsVisible = false;
                            
                            cut.ExecuteChanges();
                        });
                    }

                    if (CutsceneDialogue > 0) { 
                        Cutscene.PrintClickable(2, 28, "[BACK]", () => { CutsceneDialogue--; });
                    } else if (CutsceneScene > 0) { 
                        Cutscene.PrintClickable(2, 28, "[BACK]", () => { CutsceneScene--; CutsceneDialogue = cut.Scenes[CutsceneScene].DialogueLines.Count - 1; });
                    }
                } 
            }

            
            Cutscene.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { 
                Cutscene.IsVisible = false; 
                CutsceneScene = 0;
                CutsceneDialogue = 0;
            });
        }
        

        public static void ShopDraw() {
            Shop.Clear();
            Helper.DrawBox(Shop, 0, 0, 48, 28);
            Shop.Print(2, 0, "[Shop - " + ShopID + "]");

            int resourceX = 1;
            int resourceY = 1;

            MessageLog Log = GameLoop.WTN.Log;
             
            foreach (var shopStr in ShopItems) {
                if (GameLoop.WTN.ItemLibrary.ContainsKey(shopStr)) {
                    Item shop = new(GameLoop.WTN.ItemLibrary[shopStr]); 
                    Shop.Print(resourceX, resourceY, "|");
                    int spaceAfterName = 46 - shop.GetName(1, 0, shop.UseInt4).Length;

                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }

                    Shop.PrintClickable(resourceX + 2, resourceY, shop.GetNameCS(1, 0, shop.UseInt4) + new ColoredString(("(" + shop.Value + "gp)").Align(HorizontalAlignment.Right, spaceAfterName)), () => {
                        if (GameLoop.WTN.player.CanUseShops) {
                            if (GameLoop.WTN.player.GoldTotal() >= shop.Value * qty) {
                                GameLoop.WTN.player.TakeGold(shop.Value * qty); 

                                if (qty == 1)
                                    Log.AddMessage("You purchased a" + (Helper.VowelStart(shop.Name.ToLower()) ? "n " : " ") + shop.Name + " for " + shop.Value + " gp.", Color.Goldenrod);
                                else 
                                    Log.AddMessage("You purchased " + qty + "x " + shop.Name + " for " + shop.Value + " gp.", Color.Goldenrod);

                                if (!GameLoop.WTN.player.TryPickup(shop, qty, false, true)) {
                                    Log.AddMessage("Your inventory is full and the "  + shop.Name + " falls to the ground.", Color.Crimson);
                                }
                            } else {
                                Log.AddMessage(new ColoredString("You don't have enough gold to buy that!", Color.Crimson, Color.Black));
                            }
                        } else {
                            Log.AddMessage(new ColoredString("You aren't allowed to use shops.", Color.Crimson, Color.Black));
                        }
                    }); 

                    resourceY++;
                }
                else {
                    Shop.Print(resourceX, resourceY, "|");
                    Shop.Print(resourceX + 2, resourceY++, shopStr, Color.DarkSlateGray);
                }
            }
            
            

            Shop.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Shop.IsVisible = false; });
        }

        public static void BuildShop() {
            ShopItems.Clear();
              
        }

        public static void LampDraw() {
            LampMenu.Clear();
            Helper.DrawBox(LampMenu, 0, 0, 48, 28);
            LampMenu.Print(2, 0, "[Choose a skill to gain " + LampAmount + " experience]");

            for(int i = 0; i < LampSkills.Count; i++) {
                if (GameLoop.WTN.player.Skills.ContainsKey(LampSkills[i])) { 
                    LampMenu.PrintClickable(2, 1 + i, LampSkills[i], () => { 
                        LampMenu.IsVisible = false;  
                        GameLoop.WTN.Log.AddMessage("You gain " + LampAmount + " experience in " + LampSkills[i] + ".");
                        GameLoop.WTN.player.TryGrantExp(LampSkills[i], LampAmount, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                        LampSkills = new();

                        if (LampWrap != null) { 
                            LampWrap.Quantity -= 1;  
                            if (LampWrap.Quantity <= 0) { 
                                GameLoop.WTN.player.Inventory.Remove(LampWrap);
                            }
                        }

                        LampWrap = null; 
                    });
                } else {
                    LampMenu.Print(2, 1 + i, LampSkills[i] + " (skill not found, report this)", Color.DarkSlateGray);
                }
            }
             
              
            LampMenu.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { LampMenu.IsVisible = false; });
        }    
        

        public static void TradeHallDraw() {
            Player p = GameLoop.WTN.player;
            TradeHall.Clear();
            Helper.DrawBox(TradeHall, 0, 0, 98, 28);
            TradeHall.Print(2, 0, "[Trade Hall]".Align(HorizontalAlignment.Center, 98, (char) 196));
            
            TradeHall.DrawLine(new Point(40, 1), new Point(40, 28), 179, Color.White);
            TradeHall.DrawLine(new Point(41, 22), new Point(98, 22), 196, Color.White);
             
            TradeHall.PrintClickable(2, 1, new ColoredString("Inv", THInventory ? Color.Yellow : Color.White, Color.Black), () => { if (!THCollectOnly) { THInventory = true; } });
            TradeHall.PrintClickable(6, 1, new ColoredString("List", !THInventory ? Color.Yellow : Color.White, Color.Black), () => { THInventory = false; });
            TradeHall.DrawLine(new Point(1, 2), new Point(39, 2), 196, Color.White);

            TradeHall.Print(11, 1, 179.AsString(), Color.White);

            TradeHall.PrintStringField(13, 1, "", ref THSearchFilter, ref THTyping, "filter");

            if (THInventory) { // Show the players inventory, allow clicking to potentially create a listing
                int pY = 3;
                foreach (var kv in p.Inventory) {
                    if (kv.GetRef() is Item inv) { 
                        if (inv.Tradeable && inv.Value > 0) {
                            TradeHall.PrintClickable(2, pY++, inv.GetNameCS(kv.Quantity, 2, kv.Charges, kv.Noted), () => {
                                THView = 1;
                                THSellView = kv;
                                THPriceEntry = inv.Value;
                                THListPotential = new(new(kv) { Quantity = 1 }, false, inv.Value);
                            });

                            if (kv == THSellView) {
                                TradeHall.Print(1, pY - 1, ">", Color.White);
                            }
                        } else {
                            TradeHall.Print(2, pY++, inv.GetName(kv.Quantity, 0, kv.Charges, kv.Noted) + " (untradeable)", Color.DarkSlateGray);
                        }
                    } 
                }
            } else { // Show active listings and their prices and likelihoods, allow cancelling
                int pY = 3;
                foreach (var kv in p.ActiveTH) {
                    bool shouldBreak = false;
                    if (kv.Wrap.GetRef() is Item list) {
                        TradeHall.Print(1, pY, Helper.Checkmark(kv.Resolved));
                        TradeHall.PrintClickable(3, pY, list.GetNameCS(kv.Wrap.Quantity), () => {
                            if (kv.Buying) {
                                if (kv.Resolved) { // Buying and the purchase happened
                                    bool noted = list.Noteable && kv.Wrap.Quantity > 1;
                                    p.TryPickup(kv.Wrap, kv.Wrap.Quantity, noted, true);
                                    p.ActiveTH.Remove(kv);
                                    shouldBreak = true;
                                    GameLoop.WTN.Log.AddMessage("Collected item: " + kv.Wrap.Quantity + "x " + GameLoop.WTN.ResolveItemName(kv.Wrap.ID) + ".", Color.Lime);
                                } else { // Buying but purchase did not happen, return gold
                                    p.GiveGold(kv.Wrap.Quantity * kv.ListPrice);
                                    p.ActiveTH.Remove(kv);
                                    shouldBreak = true;
                                    GameLoop.WTN.Log.AddMessage("Cancelled buy offer, " + (kv.Wrap.Quantity * kv.ListPrice) + " gold returned.", Color.Crimson);
                                }
                            } else {
                                if (kv.Resolved) { // Selling and sale happened, give gold
                                    p.GiveGold(kv.Wrap.Quantity * kv.ListPrice);
                                    p.ActiveTH.Remove(kv);
                                    shouldBreak = true;
                                    GameLoop.WTN.Log.AddMessage("Collected gold: " + (kv.Wrap.Quantity * kv.ListPrice) + ".", Color.Lime);
                                } else { // No sale, give back item, note it if needed
                                    bool noted = list.Noteable && kv.Wrap.Quantity > 1;
                                    p.TryPickup(kv.Wrap, kv.Wrap.Quantity, noted, true);
                                    p.ActiveTH.Remove(kv);
                                    shouldBreak = true;
                                    GameLoop.WTN.Log.AddMessage("Cancelled sell offer, " + kv.Wrap.Quantity + "x " + GameLoop.WTN.ResolveItemName(kv.Wrap.ID) + " returned.", Color.Crimson);
                                }
                            }
                        });
                    }

                    if (shouldBreak) {
                        break;
                    }
                }
            }

            if (!THCollectOnly) { 
                if (THFilterSave != THSearchFilter) {
                    THFilterSave = THSearchFilter;
                    UpdateTHItems();
                }

                int show = 21;
                if (THItems.Count > show) {
                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }

                    if (Helper.ScrolledUp()) { THScrollTop = Math.Clamp(THScrollTop - qty, 0, THItems.Count - show); }
                    if (Helper.ScrolledDown()) { THScrollTop = Math.Clamp(THScrollTop + qty, 0, THItems.Count - show); }
                } else {
                    THScrollTop = 0;
                }

                for (int i = THScrollTop; i < THItems.Count && i < THScrollTop + show; i++) {
                    TradeHall.PrintClickable(42, 1 + (i - THScrollTop), THItems[i].GetNameCS(), () => {
                        THView = 0;
                        THListPotential = new(new(THItems[i]), true, THItems[i].Value);
                        THPriceEntry = THItems[i].Value;
                    });
                }
            } else {
                TradeHall.Print(41, 10, "Can only collect items here.".Align(HorizontalAlignment.Center, 57), Color.White);
            }

            if (THListPotential != null) {
                TradeHall.Print(47, 23, THListPotential.Buying ? " BUYING:" : "SELLING:", Color.White);
                if (THListPotential.Wrap.GetRef() is Item potential) {
                    TradeHall.Print(56, 23, potential.GetNameCS(THListPotential.Wrap.Quantity));
                    
                    TradeHall.PrintClickable(42, 25, new ColoredString("Market Price: " + potential.Value, Color.White, Color.Black), () => { THListPotential.ListPrice = potential.Value; }); 

                    int qty = 1;
                    if (Helper.EitherShift()) { qty *= 5; }
                    if (Helper.EitherControl()) { qty *= 10; }
                    if (Helper.KeyDown(Key.Space)) { qty *= 1000; }

                    TradeHall.Print(42, 26, "  List Price: " + THListPotential.ListPrice, Color.White); 
                    int tenPercent = (int) Math.Max(1, Math.Floor(potential.Value / 10.0));

                    TradeHall.PrintClickable(56, 27, "-X", () => { THListPotential.ListPrice = Math.Clamp(THListPotential.ListPrice - qty, 0, THListPotential.ListPrice); });
                    TradeHall.PrintClickable(59, 27, "+X", () => { THListPotential.ListPrice = Math.Clamp(THListPotential.ListPrice + qty, THListPotential.ListPrice, int.MaxValue); });

                    TradeHall.PrintClickable(62, 27, "-10%", () => { THListPotential.ListPrice = Math.Clamp(THListPotential.ListPrice - tenPercent, 0, THListPotential.ListPrice); });
                    TradeHall.PrintClickable(67, 27, "+10%", () => { THListPotential.ListPrice = Math.Clamp(THListPotential.ListPrice + tenPercent, THListPotential.ListPrice, int.MaxValue); });

                    TradeHall.PrintClickable(72, 27, "INSTA", () => { 
                        if (THListPotential.Buying) { THListPotential.ListPrice = potential.Value * 2; }
                        else if (!THListPotential.Buying) { THListPotential.ListPrice = potential.Value / 2; }
                    });


                    TradeHall.Print(42, 28, "    Quantity: ", Color.White);
                    int altHeld = THListPotential.Buying ? (p.HeldGold / THListPotential.ListPrice) : p.ItemHeldCount(THListPotential.Wrap.ID, true, false, false);
                    TradeHall.PrintClickable(56, 28, "-", () => { THListPotential.Wrap.Quantity = Math.Clamp(Helper.EitherAlt() ? 1 : THListPotential.Wrap.Quantity - qty, 1, THListPotential.Wrap.Quantity); });
                    TradeHall.PrintClickable(58, 28, "+", () => { THListPotential.Wrap.Quantity = Math.Clamp(Helper.EitherAlt() ? altHeld : THListPotential.Wrap.Quantity + qty, THListPotential.Wrap.Quantity, (THListPotential.Buying ? int.MaxValue : p.ItemHeldCount(THListPotential.Wrap.ID, true, false, false))); });

                    
                    TradeHall.Print(88, 24, "Total Price", Color.White); 
                    TradeHall.Print(80, 25, (THListPotential.ListPrice * THListPotential.Wrap.Quantity).ToString().Align(HorizontalAlignment.Right, 19), Color.Goldenrod); 


                    bool playerCanList = false;

                    if (THListPotential.Buying) {
                        if (p.GoldTotal() >= THListPotential.Wrap.Quantity * THListPotential.ListPrice) {
                            playerCanList = true;
                        }
                    } else {
                        if (p.HasAllItems([THListPotential.Wrap.ID + "," + THListPotential.Wrap.Quantity], true)) {
                            playerCanList = true;
                        }
                    }

                    TradeHall.Print(95, 26, "Odds", Color.White);

                    int odds = THListPotential.PerSecondDenom();

                    TradeHall.Print(80, 27, (odds == 0 ? "NEVER" : odds == 1 ? "INSTA" : ("1 in " + odds.ToString())).Align(HorizontalAlignment.Right, 19), odds == 0 ? Color.Crimson : odds == 1 ? Color.Lime : Color.White);

                    TradeHall.PrintClickable(93, 28, new ColoredString("[LIST]", playerCanList ? Color.Lime : Color.Crimson, Color.Black), () => {
                        if (p.ActiveTH.Count < 8) {
                            if (THListPotential.Buying) { // Deduct gold
                                THInventory = false;
                                p.ActiveTH.Add(THListPotential);
                                p.TakeGold(THListPotential.ListPrice * THListPotential.Wrap.Quantity);
                                GameLoop.WTN.Log.AddMessage("Listed a buy offer for " + THListPotential.Wrap.Quantity + "x " + potential.Name + " at " + THListPotential.ListPrice + " each (" + (THListPotential.ListPrice * THListPotential.Wrap.Quantity) + " total).", Color.Goldenrod);
                                
                                THListPotential = null; 
                            } else { // Remove items
                                p.ConsumeItems([THListPotential.Wrap.ID + "," + THListPotential.Wrap.Quantity], true);
                                p.ActiveTH.Add(THListPotential);
                                GameLoop.WTN.Log.AddMessage("Listed a sell offer for " + THListPotential.Wrap.Quantity + "x " + potential.Name + " at " + THListPotential.ListPrice + " each (" + (THListPotential.ListPrice * THListPotential.Wrap.Quantity) + " total).", Color.Goldenrod);
                                
                                THListPotential = null; 
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage("Maximum of 8 concurrent listings in the Trade Hall. Take one down to put up a new listing.", Color.Crimson);
                        }
                    });
                }
            }


            TradeHall.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { TradeHall.IsVisible = false; });
        }

        public static void UpdateTHItems() {
            if (GameLoop.WTN.player.TradeHallLimit == 0) {
                THItems = GameLoop.WTN.ItemLibrary.Values.Where(o => (o.ID.ToLower().Contains(THSearchFilter.ToLower()) || o.Name.ToLower().Contains(THSearchFilter.ToLower())) && o.Tradeable && o.Value > 0).ToList();
            } else if (GameLoop.WTN.player.TradeHallLimit == 1) {
                THItems = GameLoop.WTN.ItemLibrary.Values.Where(o => (o.ID.ToLower().Contains(THSearchFilter.ToLower()) || o.Name.ToLower().Contains(THSearchFilter.ToLower())) && o.Tradeable && o.Value > 0).Where(o => GameLoop.WTN.player.ItemsEverObtained.Contains(o.ID)).ToList();
            }
        }
    
        public static void CatDraw() {
            CatMenu.Clear();
            Helper.DrawBox(CatMenu, 0, 0, 18, 5);
            CatMenu.Print(2, 0, "[Cat Menu]");

            if (GameLoop.WTN.player.Equipment.TryGetValue("Pet", out ItemWrapper? pet) && pet != null) {
                CatMenu.PrintClickable(2, 1, "Pet", () => {
                    pet.MiscInt2 = 0;
                    GameLoop.WTN.Log.AddMessage("You pet your cat for a bit. It purrs contentedly.", Color.Yellow);
                });

                CatMenu.Print(11, 1, (pet.MiscInt2 / 60).ToString().Align(HorizontalAlignment.Right, 7));

                CatMenu.PrintClickable(2, 2, "Play", () => {
                    pet.MiscInt2 = 0;
                    GameLoop.WTN.Log.AddMessage("You play with your cat for a bit. It meows happily.", Color.Yellow);
                });
                
                CatMenu.Print(11, 2, (pet.MiscInt2 / 60).ToString().Align(HorizontalAlignment.Right, 7));

                bool hasMilk = GameLoop.WTN.player.HasAllItems(["bucketMilk,1"]);
                CatMenu.PrintClickable(2, 3, new ColoredString("Give Milk", hasMilk ? Color.White : Color.DarkSlateGray, Color.Black), () => {
                    if (hasMilk) {
                        GameLoop.WTN.player.ConsumeItems(["bucketMilk,1"]);
                        GameLoop.WTN.Log.AddMessage("You give your cat some milk. It seems pleased.", Color.Yellow);
                        pet.MiscInt = 0;
                    } else {
                        GameLoop.WTN.Log.AddMessage("You don't have any milk to give it!", Color.Crimson);
                    }
                });
                
                CatMenu.Print(11, 3, (pet.MiscInt / 60).ToString().Align(HorizontalAlignment.Right, 7));

                string firstFishID = "";
                foreach (var kv in GameLoop.WTN.player.Inventory) {
                    if (!kv.Noted && (kv.ID.Contains("fishRaw") || kv.ID.Contains("fishCooked"))) {
                        firstFishID = kv.ID;
                    }
                }

                CatMenu.PrintClickable(2, 4, new ColoredString("Give Fish", firstFishID != "" ? Color.White : Color.DarkSlateGray, Color.Black), () => {
                    if (firstFishID != "") {
                        GameLoop.WTN.player.ConsumeItems([firstFishID + ",1"]);
                        GameLoop.WTN.Log.AddMessage("You give your cat some fish. It seems very pleased.", Color.Yellow);
                        pet.MiscInt = 0;
                    } else {
                        GameLoop.WTN.Log.AddMessage("You don't have any fish to give it!", Color.Crimson);
                    }
                });
                
                CatMenu.Print(11, 4, (pet.MiscInt / 60).ToString().Align(HorizontalAlignment.Right, 7));
                
                if (firstFishID != "") {
                    CatMenu.Print(2, 5, "(" + GameLoop.WTN.ResolveItemName(firstFishID) + ")", Color.DarkSlateGray);
                }
            }

            CatMenu.PrintClickable(19, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { CatMenu.IsVisible = false; });
        }
    
        public static void HouseDraw() {
            Player p = GameLoop.WTN.player;
            HouseMenu.Clear();
            Helper.DrawBox(HouseMenu, 0, 0, 48, 28);
            HouseMenu.Print(2, 0, HouseTeleport ? "[House Teleport]" : "[Home Management]");

            int active = p.Homes.Where(o => o.Value.Active).ToList().Count;
            int max = p.GetSkillTier("Construction");

            HouseMenu.Print(2, 1, "Active Houses: " + active + " / " + max);
            HouseMenu.DrawLine(new Point(1, 2), new Point(48, 2), 196, Color.White);

            int printY = 3;

            // TODO: when more than like 25 houses are available to buy this needs to be updated to be scrollable, maybe sort them by location display name and put active ones at the top too.
            foreach (var kv in p.Homes) {
                HouseMenu.PrintClickable(2, printY++, new ColoredString(GameLoop.WTN.ResolveLocationName(kv.Value.ID), kv.Value.Active ? Color.White : Color.DarkSlateGray, Color.Black), () => {
                    if (HouseTeleport) {
                        if (kv.Value.Active) {
                            if (kv.Value.HasTeleportFocus()) { 
                                if (GameLoop.WTN.SpellLibrary.TryGetValue("teleHome", out Spell? tele)) {
                                    string cast = p.CanCast(tele);
                                    if (cast == "" || HouseTablet) { 
                                        if (GameLoop.WTN.Atlas.TryGetValue(kv.Value.ID, out Location? homeLoc)) { 
                                            if (HouseTablet) {
                                                p.ConsumeItems(["tabteleHome,1"]);
                                            } else {
                                                tele.Cast(p, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
                                            }
                                            p.NavLoc = kv.Value.ID;

                                            HouseMenu.IsVisible = false;
                                            HouseTeleport = false;
                                            HouseTablet = false;

                                            GameLoop.WTN.Log.AddMessage(new ColoredString("You teleport to your " + homeLoc.DisplayName + ".", Color.MediumPurple, Color.Black));
                                        }
                                    }  else {
                                        GameLoop.WTN.Log.AddMessage(new ColoredString("Cannot cast spell: " + cast, Color.Crimson, Color.Black));
                                    }
                                }
                            } else { 
                                GameLoop.WTN.Log.AddMessage("House must have a teleportation focus currently built to teleport to it.", Color.Crimson);
                            }
                        } else {
                            GameLoop.WTN.Log.AddMessage("Can only teleport to active houses.", Color.Crimson);
                        }
                    } else {
                        if (kv.Value.Active) {
                            kv.Value.Active = false;
                        } else if (active < max) {
                            kv.Value.Active = true;
                        }
                    }
                });
            }


            HouseMenu.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { HouseMenu.IsVisible = false; });
        }

        public static void CompassDraw() {
            Compass.Clear();
            Helper.DrawBox(Compass, 0, 0, 48, 28);
            Compass.Print(2, 0, "[Compass - Where To?]");
            Compass.PrintStringField(2, 1, "Search: ", ref CompassFilterActive, ref CompassTyping, "compassFilter");

            if (CompassFilterSaved != CompassFilterActive) {
                CompassFilterSaved = CompassFilterActive;
                CompassUpdate();
            }

            Compass.DrawLine(new Point(1, 2), new Point(48, 2), 196, Color.White);

            int max = 26;

            if (CompassFiltered.Count > max) {
                if (Helper.ScrolledDown()) { Helper.QuantitySelector(CompassScrollTop, CompassFiltered.Count - max); }
                if (Helper.ScrolledUp()) { Helper.QuantitySelector(CompassScrollTop, CompassFiltered.Count - max, true); }
            } else {
                CompassScrollTop = 0;
            }
            for (int i = CompassScrollTop; i < CompassFiltered.Count && i < CompassScrollTop + max; i++) {
                Compass.PrintClickable(2, 3 + (i - CompassScrollTop), CompassFiltered[i].DisplayName, () => {
                    CompassFindRoute(CompassFiltered[i].ID);
                });
            }
             
            Compass.PrintClickable(49, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Compass.IsVisible = false; });
        }

        public static void CompassUpdate() {
            CompassFiltered.Clear();

            CompassFiltered = GameLoop.WTN.Atlas.Values.Where(o => (o.ID.ToLower().Contains(CompassFilterSaved.ToLower()) || o.DisplayName.ToLower().Contains(CompassFilterSaved.ToLower()) )).ToList();
        }


        public static Dictionary<string, int> AllFoundLocations = new();
        public static List<string> CompassCurrentShortest = new();
        public static void CompassFindRoute(string destID) {
            CompassRoute.Clear();
            AllFoundLocations.Clear(); 

            if (GameLoop.WTN.Atlas.TryGetValue(GameLoop.WTN.player.NavLoc, out Location? curr)) {
                foreach (var conn in curr.ConnectedLocations) {
                    if (conn.CanTraverse(GameLoop.WTN.player)) {
                        CompassTryPath(new() { conn.Destination }, conn.Destination, destID, 0);
                    }
                }
            }

            CompassRoute = CompassCurrentShortest;

            if (CompassRoute.Count == 0) { // Should only happen if no route was found within 20 steps, so tell the player
                GameLoop.WTN.Log.AddMessage("Destination not found within 20 map connections.", Color.Crimson);
            } else { 
                GameLoop.WTN.Log.AddMessage("Destination found in " + CompassRoute.Count + " steps. Follow blue locations to reach it.", Color.Turquoise);
            }
        } 

        public static void CompassTryPath(List<string> path, string id, string target, int depth) {
            if ((!AllFoundLocations.ContainsKey(id) || AllFoundLocations[id] > depth) && depth < 20 && (CompassCurrentShortest.Count == 0 || depth < CompassCurrentShortest.Count)) { 
                AllFoundLocations.TryAdd(id, depth);
                AllFoundLocations[id] = depth; 

                if (id == target) {
                    CompassCurrentShortest = path;
                } 

                if (GameLoop.WTN.Atlas.TryGetValue(id, out Location? curr)) {
                    foreach (var conn in curr.ConnectedLocations) {
                        if (conn.CanTraverse(GameLoop.WTN.player)) {
                            CompassTryPath(path.Append(conn.Destination).ToList(), conn.Destination, target, depth + 1);
                        }
                    }
                }
            }
        }
    
        public static void AlchemyDraw() {
            Player p = GameLoop.WTN.player;
            Alchemy.Clear();
            Helper.DrawBox(Alchemy, 0, 0, 128, 28);
            Alchemy.Print(1, 0, "[Alchemy Workshop]".Align(HorizontalAlignment.Center, 128, (char) 196));

            Alchemy.DrawLine(new Point(45, 1), new Point(45, 28), 179, Color.White); 
            Alchemy.DrawLine(new Point(84, 1), new Point(84, 28), 179, Color.White);

            Alchemy.Print(1, 1, "Available Tools".Align(HorizontalAlignment.Center, 43), Color.White);

            Alchemy.PrintClickable(1, 1, new ColoredString("[CONFIRMS]", AlchemyNeedConfirm ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                AlchemyNeedConfirm = !AlchemyNeedConfirm;
                AlchemyConfirm = "";
            });


            Alchemy.DrawLine(new Point(1, 2), new Point(44, 2), 196, Color.White); 

            int y = 3;

            AlchemyStats working = AlchemyTraining ? AlchemyTrain : AlchemyWrap.Alchemy;

            if (AlchemyTraining) {
                if (working.Ingredients.Count > 0) {
                    Alchemy.PrintClickable(1, y++, new ColoredString("Retort (+1 Red, -1 Black)", AlchemyConfirm == "retort" ? Color.Lime : Color.Crimson, Color.Black), () => { 
                        if (AlchemyConfirm == "retort" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            working.Red++; working.Black--; working.ActionsTaken.Add("Retort"); AlchemyConfirm = "";
                        } else {
                            AlchemyConfirm = "retort";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Alembic (+1 Black, -1 Yellow)", AlchemyConfirm == "alembic" ? Color.Lime : Color.DimGray, Color.Black), () => { 
                        if (AlchemyConfirm == "alembic" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            working.Black++; working.Yellow--; working.ActionsTaken.Add("Alembic"); AlchemyConfirm = "";
                        } else {
                            AlchemyConfirm = "alembic";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Crucible (+1 Yellow, -1 White)", AlchemyConfirm == "crucible" ? Color.Lime : Color.Yellow, Color.Black), () => { 
                        if (AlchemyConfirm == "crucible" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            working.Yellow++; working.White--; working.ActionsTaken.Add("Crucible"); AlchemyConfirm = "";
                        } else {
                            AlchemyConfirm = "crucible";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Aludel (+1 White, -1 Red)", AlchemyConfirm == "aludel" ? Color.Lime : Color.White, Color.Black), () => { 
                        if (AlchemyConfirm == "aludel" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            working.White++; working.Red--; working.ActionsTaken.Add("Aludel"); AlchemyConfirm = "";
                        } else {
                            AlchemyConfirm = "aludel";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Calcinator (All 1 towards 0)", AlchemyConfirm == "calcinator" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "calcinator" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            working.Red += (working.Red > 0 ? -1 : working.Red < 0 ? 1 : 0);
                            working.Black += (working.Black > 0 ? -1 : working.Black < 0 ? 1 : 0);
                            working.Yellow += (working.Yellow > 0 ? -1 : working.Yellow < 0 ? 1 : 0);
                            working.White += (working.White > 0 ? -1 : working.White < 0 ? 1 : 0); 
                            working.ActionsTaken.Add("Calcinator"); 
                        } else {
                            AlchemyConfirm = "calcinator";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Swizzler (Average all, maintain polarity)", AlchemyConfirm == "swizzler" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "swizzler" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            int total = Math.Abs(working.Red) + Math.Abs(working.Black) + Math.Abs(working.Yellow) + Math.Abs(working.White);
                            int avg = (int) Math.Round(total / 4.0, MidpointRounding.ToZero);

                            working.Red = (working.Red < 0 ? avg * -1 : avg);
                            working.Black = (working.Black < 0 ? avg * -1 : avg);
                            working.Yellow = (working.Yellow < 0 ? avg * -1 : avg);
                            working.White = (working.White < 0 ? avg * -1 : avg);
                            working.ActionsTaken.Add("Swizzler");
                        } else {
                            AlchemyConfirm = "swizzler";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Agitator (Shift all colors one right)", AlchemyConfirm == "agitator" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "agitator" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            int white = working.White;
                            working.White = working.Yellow;
                            working.Yellow = working.Black;
                            working.Black = working.Red;
                            working.Red = white;
                            working.ActionsTaken.Add("Agitator");
                        } else {
                            AlchemyConfirm = "agitator";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Deagitator (Shift all colors one left)", AlchemyConfirm == "deagitator" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "deagitator" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            int red = working.Red;
                            working.Red = working.Black;
                            working.Black = working.Yellow;
                            working.Yellow = working.White;
                            working.White = red;
                            working.ActionsTaken.Add("Deagitator");
                        } else {
                            AlchemyConfirm = "deagitator";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Inverter (All flip polarity)", AlchemyConfirm == "inverter" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "inverter" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain); 
                            working.Red *= -1;
                            working.Black *= -1;
                            working.Yellow *= -1;
                            working.White *= -1;
                            working.ActionsTaken.Add("Inverter");
                        } else {
                            AlchemyConfirm = "inverter";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Vial of Water (Split with 0/0/0/0)", AlchemyConfirm == "dilute" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "dilute" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain); 
                                
                            AlchemyTrain.Red = (int) Math.Round(AlchemyTrain.Red / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.Black = (int) Math.Round(AlchemyTrain.Black / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.Yellow = (int) Math.Round(AlchemyTrain.Yellow / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.White = (int) Math.Round(AlchemyTrain.White / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.ActionsTaken.Add("Diluted");

                            AlchemyTrainSave = new(AlchemyTrain);
                        } else {
                            AlchemyConfirm = "dilute";
                        }
                    });

                    y++;

                    Alchemy.PrintClickable(1, y++, new ColoredString("Mix Act+Sec (Combine both + half each color)", AlchemyConfirm == "mixed" ? Color.Lime : Color.Gray, Color.Black), () => { 
                        if (AlchemyConfirm == "mixed" || !AlchemyNeedConfirm) {
                            AlchemyTrainUndo = new(AlchemyTrain); 
                                
                            AlchemyTrain.Red = (int) Math.Round((AlchemyTrainSave.Red + AlchemyTrain.Red) / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.Black = (int) Math.Round((AlchemyTrainSave.Black + AlchemyTrain.Black) / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.Yellow = (int) Math.Round((AlchemyTrainSave.Yellow + AlchemyTrain.Yellow) / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.White = (int) Math.Round((AlchemyTrainSave.White + AlchemyTrain.White) / 2.0, MidpointRounding.ToZero);
                            AlchemyTrain.Ingredients.AddRange(AlchemyTrainSave.Ingredients);
                            AlchemyTrain.ActionsTaken.Add("Mixed");

                            List<string> Actions = new(AlchemyTrainSave.ActionsTaken);
                            Actions.Add("Mixed");

                            AlchemyTrainSave = new(AlchemyTrain);
                            AlchemyTrainSave.ActionsTaken = Actions;
                        } else {
                            AlchemyConfirm = "mixed";
                        }
                    });
                } else if (AlchemyTraining && working.Ingredients.Count == 0) {
                    Alchemy.Print(2, 3, "Add an ingredient to begin");
                }

                if (AlchemyItems.Count == 0) { AlchemyItems = GameLoop.WTN.ItemLibrary.Values.Where(o =>  (o.ID != "alchemyMixture") && o.Alchemy != null).ToList(); }

                

                Alchemy.Print(85, 1, "Available Items".Align(HorizontalAlignment.Center, 43), Color.White);
                Alchemy.DrawLine(new Point(85, 2), new Point(128, 2), 196, Color.White); 
                
                Alchemy.PrintStringField(86, 3, "Filter: ", ref AlchemyItemSearchActive, ref SelectedField, "alchemyItemFilter", false);
                Alchemy.DrawLine(new Point(85, 4), new Point(128, 4), 196, Color.White); 

                if (AlchemyItemSearchSaved != AlchemyItemSearchActive) {
                    AlchemyItemSearchSaved = AlchemyItemSearchActive;
                    AlchemyItems = GameLoop.WTN.ItemLibrary.Values.Where(o => (o.Alchemy != null) && (o.ID != "alchemyMixture") && (o.ID.ToLower().Contains(AlchemyItemSearchSaved) || o.Name.ToLower().Contains(AlchemyItemSearchSaved))).ToList();
                }

                y = 5;

                if (AlchemyItems.Count > 24) {
                    if (Helper.ScrolledDown()) { AlchemyItemTop = Helper.QuantitySelector(AlchemyItemTop, AlchemyItems.Count); }
                    if (Helper.ScrolledUp()) { AlchemyItemTop = Helper.QuantitySelector(AlchemyItemTop, AlchemyItems.Count, true); }
                } else {
                    AlchemyItemTop = 0;
                }

                for (int i = AlchemyItemTop; i < AlchemyItems.Count && y < 29; i++) {
                    Alchemy.PrintClickable(86, y++, AlchemyItems[i].GetNameCS(overrideLoupe: true), () => {
                        if (working != null) {
                            AlchemyTrainUndo = new(AlchemyTrain);
                            AlchemyStats alch = AlchemyItems[i].Alchemy;

                            working.Red += alch.Red; working.Black += alch.Black; working.Yellow += alch.Yellow; working.White += alch.White; 
                            working.Ingredients.Add(AlchemyItems[i].ID);
                            
                            if (working.Level < alch.Level) { working.Level = alch.Level; }
                        }
                    });
                }

                if (working != null) { 
                    Alchemy.Print(47, 1, "Active: ", Color.White);
                    Alchemy.Print(54, 1, working.Red.ToString().Align(HorizontalAlignment.Right, 6), Color.Crimson);
                    Alchemy.Print(61, 1, working.Black.ToString().Align(HorizontalAlignment.Right, 6), Color.DimGray);
                    Alchemy.Print(68, 1, working.Yellow.ToString().Align(HorizontalAlignment.Right, 6), Color.Yellow);
                    Alchemy.Print(75, 1, working.White.ToString().Align(HorizontalAlignment.Right, 6), Color.White); 
                    Alchemy.DrawLine(new Point(46, 2), new Point(83, 2), 196, Color.White); 

                    
                    Alchemy.Print(47, 3, "Second: ", Color.White);
                    Alchemy.Print(54, 3, AlchemyTrainSave.Red.ToString().Align(HorizontalAlignment.Right, 6), Color.Crimson);
                    Alchemy.Print(61, 3, AlchemyTrainSave.Black.ToString().Align(HorizontalAlignment.Right, 6), Color.DimGray);
                    Alchemy.Print(68, 3, AlchemyTrainSave.Yellow.ToString().Align(HorizontalAlignment.Right, 6), Color.Yellow);
                    Alchemy.Print(75, 3, AlchemyTrainSave.White.ToString().Align(HorizontalAlignment.Right, 6), Color.White);
                    Alchemy.DrawLine(new Point(46, 4), new Point(83, 4), 196, Color.White); 
                    
                    Alchemy.PrintClickable(47, 5, "Undo", () => { AlchemyTrain = new(AlchemyTrainUndo);  });

                    Alchemy.Print(52, 5, 179.AsString(), Color.White);

                    Alchemy.PrintClickable(54, 5, "Swap", () => {
                        AlchemyStats swap = AlchemyTrain;
                        AlchemyTrain = AlchemyTrainSave;
                        AlchemyTrainSave = swap;

                        AlchemyLevelMin = AlchemyTrain.Level;
                    });
                    
                    Alchemy.Print(59, 5, 179.AsString(), Color.White);
                    
                    Alchemy.Print(61, 5, "Empty: ", Color.White);
                    Alchemy.PrintClickable(69, 5, "Active", () => { AlchemyTrain = new(); AlchemyLevelMin = 1; working = AlchemyTrain; });
                    Alchemy.PrintClickable(77, 5, "Second", () => { AlchemyTrainSave = new(); }); 
                    Alchemy.DrawLine(new Point(46, 6), new Point(83, 6), 196, Color.White); 

                    if (AlchemyLevelMin < ((working.Ingredients.Count - 2) * 10)) { AlchemyLevelMin = ((working.Ingredients.Count - 2) * 10); }
                    if (AlchemyLevelMin < ((working.ActionsTaken.Count - 1) * 10)) { AlchemyLevelMin = ((working.ActionsTaken.Count - 1) * 10); }
                    if (AlchemyLevelMin < working.Level) { AlchemyLevelMin = working.Level; }
                     
                    Alchemy.Print(47, 7, "Would need level " + AlchemyLevelMin + " Alchemy to make", Color.White);
                    Alchemy.DrawLine(new Point(46, 8), new Point(83, 8), 196, Color.White);

                    Alchemy.Print(47, 9, "Ingredients: ", Color.White);
                    int ingY = 10;
                    foreach (var ing in working.Ingredients) { 
                        if (ingY < 29) {
                            if (GameLoop.WTN.ResolveItem(ing) is Item ingredient) { 
                                Alchemy.Print(47, ingY++, ingredient.GetNameCS(overrideLoupe: true));
                            } else { 
                                Alchemy.Print(47, ingY++, ing);
                            }
                        }
                    }
                    if (ingY == 10) { Alchemy.Print(47, ingY++, "(no ingredients)", Color.DarkSlateGray); }

                    ingY++;

                    Alchemy.Print(47, ingY++, "Actions: ", Color.White); 
                    int startY = ingY;
                    foreach (var ing in working.ActionsTaken) {
                        if (ingY < 29)
                            Alchemy.Print(47, ingY++, ing);
                    }
                    if (ingY == startY && ingY != 29) { Alchemy.Print(47, ingY++, "(no actions)", Color.DarkSlateGray); }

                    bool foundMatch = false;
                    foreach (var recKV in GameLoop.WTN.PotionRecipeLibrary) {
                        if (recKV.Value.ReqsMet(working)) {
                            Alchemy.Print(1, 28, "Current: " + GameLoop.WTN.ResolveItemName(recKV.Key), Color.White);
                            foundMatch = true;
                            break;
                        }
                    }

                    if (!foundMatch) { 
                        Alchemy.Print(1, 28, "No potion recipe currently matched.", Color.DarkSlateGray);
                    }
                } 
            }

            if (!AlchemyTraining) {
                if (p.HasAllItems(["alchemyRetort,1"], false, true)) {
                    Alchemy.PrintClickable(1, y++, "Retort (+1R -1B)", () => { 

                    });
                }
            } 
              
            Alchemy.PrintClickable(129, 0, new ColoredString("X", Color.Crimson, Color.Black), () => { Alchemy.IsVisible = false; });
        }
    
        public static void TalismanDraw() {
            MouseScreenObjectState state = new MouseScreenObjectState(TalismanCon, GameHost.Instance.Mouse);
            Point mousePos = state.CellPosition;
            Talisman.Clear();
            TalismanHintCon.Clear();
            TalismanCon.Clear();
            Helper.DrawBox(Talisman, 0, 0, 98, 28); 

            List<ItemWrapper> mats = GameLoop.WTN.player.Inventory.Where(o => o.ID.Substring(0, 5) == "paper" || o.ID.Substring(0, 3) == "ink").ToList();

            Talisman.Print(1, 1, "Inventory Materials", Color.White);
            Talisman.DrawLine(new Point(1, 2), new Point(30, 2), 196, Color.White);
            Talisman.DrawLine(new Point(31, 1), new Point(31, 28), 179, Color.White);

            int printY = 3;

            foreach (var mat in mats) {
                if (mat.GetRef() is Item item) {
                    Talisman.PrintClickable(1, printY++, item.GetNameCS(item.Quantity), () => {
                        if (mat.ID.Substring(0, 5) == "paper") { TalismanPaper = mat; }
                        if (mat.ID.Substring(0, 3) == "ink") { TalismanInk = mat; }
                    });
                }
            }

            printY = 1;
            foreach (var guide in TalismanGuideOptions) {
                Talisman.PrintClickable(84, printY++, new ColoredString(guide.Align(HorizontalAlignment.Right, 14), guide == TalismanGuide ? Color.Lime : Color.DarkSlateGray, Color.Black), () => {
                    TalismanGuide = guide;
                });
            }

            int pX = 52;
            int pY = 16;
            // Automatic hint generator
            if (GameLoop.WTN.TalismanLibrary.TryGetValue(TalismanGuide, out string? target) && target != null) {
                for (int x = 0; x < 10; x++) { // for each column
                    int group = 0;
                    int hintY = 4;
                    bool streak = false; 

                    for (int y = 9; y >= 0; y--) {
                        if (x + (y * 10) < target.Length) {
                            if (target[x + (y * 10)] == ' ' && streak) {
                                TalismanHintCon.Print(x, hintY, group.ToString(), x % 2 == 0 ? Color.DarkSlateGray : Color.DarkGray);
                                hintY -= 2;
                                group = 0;
                                streak = false;
                            } else if (target[x + (y * 10)] == 'x') {
                                group++;
                                streak = true;
                            }
                        }
                    }

                    if (hintY == 4) { TalismanHintCon.Print(x, hintY, group.ToString(), x % 2 == 0 ? Color.DarkSlateGray : Color.DarkGray); }
                }

                for (int y = 0; y < 10; y++) { // for each row
                    int group = 0;
                    int hintX = 2;
                    bool streak = false; 

                    for (int x = 9; x >= 0; x--) {
                        if (x + (y * 10) < target.Length) {
                            if (target[x + (y * 10)] == ' ' && streak) {
                                Talisman.Print(pX - hintX, pY + y, group.ToString(), y % 2 == 0 ? Color.DarkSlateGray : Color.DarkGray);
                                hintX += 2;
                                group = 0;
                                streak = false;
                            } else if (target[x + (y * 10)] == 'x') {
                                group++;
                                streak = true;
                            }
                        }
                    }

                    if (hintX == 2) { Talisman.Print(pX - hintX, pY + y, group.ToString(), y % 2 == 0 ? Color.DarkSlateGray : Color.DarkGray); }
                }
            }  

            
            Helper.DrawBox(TalismanCon, 0, 0, 10, 10); 

            if (TalismanDrawing.Length < 100) { TalismanDrawing = TalismanDrawing.PadRight(100); }

            List<char> splitDrawing = TalismanDrawing.ToList();
            Color col = Color.White;
            Color dark = new Color(40, 40, 40);

            if (TalismanInk != null && TalismanInk.GetRef() is Item ink) { col = ink.GetColor(); } 

            for (int i = 0; i < splitDrawing.Count; i++) {  
                TalismanCon.Print(1 + (i % 10), 1 + (i / 10), new ColoredString(splitDrawing[i] == ' ' ? "-" : splitDrawing[i] == 'o' ? "x" : 254.AsString(), splitDrawing[i] != ' ' ? col : dark, Color.Black)); 
            } 

            if (mousePos.X > 0 && mousePos.X < 11 && mousePos.Y > 0 && mousePos.Y < 11) {
                Point off = mousePos - new Point(1, 1);
                int idx = off.ToIndex(10);
                if (state.Mouse.LeftButtonDown) { 
                    if (idx >= 0 && idx < 100) { splitDrawing[idx] = 'x'; TalismanDrawing = new(splitDrawing.ToArray()); }
                } else if (state.Mouse.RightButtonDown) { 
                    if (idx >= 0 && idx < 100) { 
                        if (!Helper.EitherShift()) { splitDrawing[idx] = ' '; }
                        else { splitDrawing[idx] = 'o'; }
                        
                        TalismanDrawing = new(splitDrawing.ToArray()); 
                    }
                }
            } 

            
            int spots = splitDrawing.Where(o => o == 'x').ToList().Count;
            
            if (TalismanInk != null && TalismanInk.GetRef() is Item inkDisp) { 
                Talisman.Print(33, 1, new ColoredString("Ink: " + spots + "x ") + inkDisp.GetNameCS() + " " + Helper.Checkmark(TalismanInk.Quantity >= spots && inkDisp.EquipLevel <= GameLoop.WTN.player.GetEffectiveSkillLevel("Crafting")));
            } else { 
                Talisman.Print(33, 1, new ColoredString("Ink: (none selected)", Color.DarkSlateGray, Color.Black));
            }

            if (TalismanPaper != null && TalismanPaper.GetRef() is Item paperDisp) { 
                Talisman.Print(33, 2, new ColoredString("Paper: ") + paperDisp.GetNameCS() + " " + Helper.Checkmark(paperDisp.EquipLevel <= GameLoop.WTN.player.GetEffectiveSkillLevel("Crafting")));
            } else { 
                Talisman.Print(33, 2, new ColoredString("Paper: (none selected)", Color.DarkSlateGray, Color.Black));
            }


            /* Talisman.PrintClickable(33, 6, "Save to File", () => {
                Helper.SerializeToFile(TalismanDrawing, "./" + TalismanGuide + ".json");
            }); */

            if (TalismanInk != null) {
                if (TalismanPaper != null) {
                    if (TalismanInk.Quantity >= spots) {
                        int craftLevel = GameLoop.WTN.player.GetEffectiveSkillLevel("Crafting");
                        if (TalismanInk.GetRef() is Item inkFin) {
                            if (inkFin.EquipLevel <= craftLevel) {
                                if (TalismanPaper.GetRef() is Item paperFin) {
                                    if (TalismanPaper.Quantity > 0) {
                                        if (paperFin.EquipLevel <= craftLevel) { 
                                            int inkTier = (inkFin.EquipLevel / 10) + 1;
                                            int paperTier = (paperFin.EquipLevel / 10) + 1;
                                            int multi = (inkFin.ID.Contains(TalismanGuide) ? 5 : inkFin.ID.Contains("Imbued") ? 2 : 1);
                                            int outQty = inkTier * paperTier * multi;

                                            Talisman.PrintClickable(33, 4, new ColoredString("Finalize Talisman (+" + outQty + ")", Color.Lime, Color.Black), () => { 
                                                // They have paper and ink plus the levels to use them, check if the drawing sufficiently matches a talisman and calculate the quantity to give, then give
                                                if (GameLoop.WTN.TalismanLibrary.TryGetValue(TalismanGuide, out string? talismanText) && talismanText != null && GameLoop.WTN.ResolveItem("talisman" + TalismanGuide) is Item tali && tali != null) {
                                                    int matchCount = 0;
                                                    int totalCount = 0;

                                                    List<char> talismanTarget = talismanText.ToList();
                                                    
                                                    for (int i = 0; i < splitDrawing.Count && i < talismanTarget.Count; i++) {
                                                        if (talismanTarget[i] == 'x') {
                                                            totalCount++;
                                                            if (splitDrawing[i] == 'x') {
                                                                matchCount++;
                                                            }
                                                        }
                                                    }

                                                    GameLoop.WTN.player.ConsumeItems([TalismanInk.ID + "," + spots, TalismanPaper.ID + ",1"]); 

                                                    if (matchCount > totalCount * 0.9) { // If they match 90% or more of tiles
                                                        GameLoop.WTN.player.TryPickup(tali, outQty);
                                                        GameLoop.WTN.Log.AddMessage("You imbue a spark of magical energy into the paper and ink, and they become talismans.", Color.Turquoise);
                                                    } else {
                                                        GameLoop.WTN.Log.AddMessage("Drawing did not match the guide well enough, and the materials went to waste. (" + ((matchCount / (double) totalCount) * 100) + "% match)",  Color.Crimson);
                                                    } 
                                                }
                                            });
                                        } else {
                                            Talisman.Print(33, 4, new ColoredString("Need " + paperFin.EquipLevel + " Crafting to use this paper (have " + craftLevel + ")", Color.Crimson, Color.Black));
                                        }
                                    } else {
                                        Talisman.Print(33, 4, new ColoredString("Need at least one sheet of paper", Color.Crimson, Color.Black));
                                    }
                                }
                            } else {
                                Talisman.Print(33, 4, new ColoredString("Need " + inkFin.EquipLevel + " Crafting to use this ink (have " + craftLevel + ")", Color.Crimson, Color.Black));
                            }
                        }  
                    } else {
                        Talisman.Print(33, 4, new ColoredString("Not enough of that kind of ink (need " + spots + ")", Color.Crimson, Color.Black));
                    }
                } else {
                    Talisman.Print(33, 4, new ColoredString("No paper selected", Color.Crimson, Color.Black));
                }
            } else {
                Talisman.Print(33, 4, new ColoredString("No ink selected", Color.Crimson, Color.Black));
            }

            Talisman.PrintClickable(99, 0, new ColoredString("X", Color.Crimson, Color.Black), () => {  Talisman.IsVisible = false;  });
        }
        
    }
}
