using SadConsole.Input; 
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.Managers;
using Key = SadConsole.Input.Keys;

namespace WorldtreeNexus.UI {
    public static class UI_LocNPCs {  
        public static Rectangle ActivityRect = new Rectangle(new Point(111, 10), new Point(147, 34));
        public static int ActivityItemTop = 0; 
         
        public static int CurrDialogueStage = -1;
        public static NPC? ConversationPartner = null;

        public static void DrawNPCs(Location curr, Player player, UI_EmbeddedMini mini, int resourceX, int resourceY, MessageLog Log) { 
            Point mousePos = new MouseScreenObjectState(mini.Con, GameHost.Instance.Mouse).CellPosition;

            mini.Con.Print(resourceX + 2, resourceY++, "NPCs Here");
            int startY = resourceY;

            for (int i = 0; i < curr.NPCsHere.Count; i++) {
                if (GameLoop.WTN.NPCLibrary.TryGetValue(curr.NPCsHere[i], out NPC? thisOne) && thisOne != null) {  
                    if (thisOne.ReqsToSee != null && thisOne.ReqsToSee.Count > 0) {
                        bool reqsMet = true;
                        foreach (var req in thisOne.ReqsToSee) {
                            if (!req.CheckRequirement(player, true, true)) {
                                reqsMet = false;
                            }
                        }

                        if (!reqsMet) {
                            continue;
                        }
                    }

                    mini.Con.PrintClickable(resourceX + 2, resourceY, "| " + thisOne.Name, () => { 
                        if (!ClueLogic.GenericStep(player, Log, "Speak", thisOne.ID) && !ClueLogic.GenericStep(player, Log, "Anagram", thisOne.ID)) {
                            CurrDialogueStage = 0;
                            ConversationPartner = thisOne;

                            if (ConversationPartner.Dialogue.ContainsKey(CurrDialogueStage)) {
                                string altSpeaker = ConversationPartner.Dialogue[CurrDialogueStage].AltSpeaker;
                                if (altSpeaker == "") {
                                    foreach (var text in ConversationPartner.Dialogue[CurrDialogueStage].Text) {
                                        if (text.CheckReq()) {
                                            if (text.Text != "")
                                                Log.AddMessage(new ColoredString(ConversationPartner.Name + ": ", Color.Yellow, Color.Black) + new ColoredString(text.Text.Replace("@", player.Name)));
                                            break;
                                        }
                                    } 
                                } else {
                                    if (altSpeaker == "-") { 
                                        foreach (var text in ConversationPartner.Dialogue[CurrDialogueStage].Text) {
                                            if (text.CheckReq()) { 
                                                if (text.Text != "")
                                                    Log.AddMessage(text.Text.Replace("@", player.Name));
                                                break;
                                            }
                                        }
                                    } else { 
                                        foreach (var text in ConversationPartner.Dialogue[CurrDialogueStage].Text) {
                                            if (text.CheckReq()) { 
                                                if (text.Text != "")
                                                    Log.AddMessage(new ColoredString(altSpeaker + ": ", Color.Yellow, Color.Black) + new ColoredString(text.Text.Replace("@", player.Name)));
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            GameLoop.WTN.SelectedMenu = "Chat";
                        }
                    });

                    int extraButtons = 146;
                    if (thisOne.PickpocketLevel > 0) {
                        mini.Con.PrintClickable(extraButtons, resourceY, "P", () => {
                            thisOne.TryPickpocket(player, SidebarManager.RecentlyTrainedSkills, GameLoop.WTN.ItemLibrary, Log);
                        });

                        extraButtons -= 2;
                    }
                                
                    resourceY++; 
                }
            } 

            if (resourceY == startY) {
                mini.Con.Print(resourceX + 2, resourceY, "|");
                mini.Con.Print(resourceX + 4, resourceY++, "(no NPCs here)", Color.DarkSlateGray);
            }
        }
    }
}
