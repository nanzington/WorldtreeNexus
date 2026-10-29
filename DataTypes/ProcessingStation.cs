using Newtonsoft.Json;
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class ProcessingStation {
        public string Name = ""; 

        public List<ProcessingRecipe> Recipes = new();

        public bool OpensUI = false;
        public bool DontIncludeInCounts = false;
        public int MaxLevel = 99; // Basically only going to be used to gate POH stations so that you can't do everything for very little investment in Construction
        public string AltUI = "";

        [JsonIgnore]
        public int TimeLeft = -1;

        [JsonIgnore]
        public double TimeMade = 0;

        [JsonIgnore]
        public string ItemOnExpire = "";

        [JsonIgnore]
        public string LastWorked = "";

        public ProcessingStation(string n, bool ui = false, bool dont = false, int maxLevel = 99, string alt = "") {
            Name = n;  
            OpensUI = ui;
            DontIncludeInCounts = dont;
            MaxLevel = maxLevel;
            AltUI = alt;
        }

        public bool TryProcessItem(Player p, MessageLog log, Dictionary<string, Item> ItemLibrary, List<Skill> RecentSkills) { 
            for (int i = 0; i < p.Inventory.Count; i++) {
                bool changedInv = false;
                for (int j = 0; j < Recipes.Count; j++) {
                    string comp = Recipes[j].InputID;
                    int qty = 1;

                    if (comp.Contains(',')) { 
                        string[] split = comp.Split(",");
                        comp = split[0];
                        if (split.Length > 1) {
                            int.TryParse(split[1], out qty);
                        }

                        if (qty == 0) { qty = 1; }
                    }

                    if (p.Inventory[i].ID == comp && !p.Inventory[i].Noted && p.HasAllItems([comp + "," + qty])) {
                        if (Recipes[j].SkillUsed != "") {
                            if (p.Skills.ContainsKey(Recipes[j].SkillUsed) && p.Skills[Recipes[j].SkillUsed].Level < Recipes[j].SkillLevel) {
                                log.AddMessage(new ColoredString("You get the feeling you should have " + Recipes[j].SkillLevel + " " + Recipes[j].SkillUsed + " to make " + GameLoop.WTN.ResolveItemName(Recipes[j].OutputID) + ".", Color.Crimson, Color.Black));
                                continue;
                            } 
                        } 

                        if (Recipes[j].SkillLevel > MaxLevel) {
                            log.AddMessage(new ColoredString(Name + " can only handle recipes up to level " + Recipes[j].SkillLevel + " " + Recipes[j].SkillUsed + ".", Color.Crimson, Color.Black));
                            continue;
                        }

                        if (Recipes[j].SecondaryIn != "" && !p.HasAllItems([Recipes[j].SecondaryIn + ",1" ])) {
                            continue;
                        } 

                        if (Recipes[j].TertiaryIn != "" && !p.HasAllItems([Recipes[j].TertiaryIn + ",1"], false, true)) {
                            continue;
                        }

                        if (LastWorked == "") {
                            LastWorked = p.Inventory[i].ID; 
                        } else {
                            if (LastWorked != p.Inventory[i].ID)
                                continue;
                        }

                        if (Recipes[j].SkillUsed == "Smithing" && Recipes[j].TertiaryIn != "") { // AKA: Smelting bars and they've got a ring of forging
                            if (!p.HasAllItems([Recipes[j].TertiaryIn+",1"], false, true, true)) {
                                return false;
                            }

                            
                            int invCount = p.Inventory.Count; 
                            p.ConsumeItems([comp + "," + qty]);
                            if (invCount != p.Inventory.Count) { changedInv = true; }

                            invCount = p.Inventory.Count;
                            if (Recipes[j].SecondaryIn != "") {
                                p.ConsumeItems([Recipes[j].SecondaryIn+",1"]);
                            }
                            if (invCount != p.Inventory.Count) {
                                changedInv = true;
                            }

                            int extra = 0;

                            if (ItemLibrary.ContainsKey(Recipes[j].OutputID)) {
                                Item item = new(ItemLibrary[Recipes[j].OutputID]);

                                if (Recipes[j].HighSkillExtraOutputs) {
                                    int skillDiff = p.Skills[Recipes[j].SkillUsed].Level - Recipes[j].SkillLevel;
                                    extra = (int) Math.Floor(skillDiff / 10.0);
                                    item.Quantity += extra;
                                }

                                p.TryPickup(item, item.Quantity);
                            }

                            if (Recipes[j].SecondaryOut != "") {
                                if (ItemLibrary.ContainsKey(Recipes[j].SecondaryOut)) {
                                    Item item = new(ItemLibrary[Recipes[j].SecondaryOut]); 

                                    p.TryPickup(item, item.Quantity);
                                }
                            }
                            string nameOre = GameLoop.WTN.ResolveItemName(Recipes[j].InputID).ToLower();
                            string nameBar = GameLoop.WTN.ResolveItemName(Recipes[j].OutputID).ToLower();
                            log.AddMessage("Your ring of forging allows you to smelt a" + (Helper.VowelStart(nameOre) ? "n " : " ") + nameOre + " directly into a" + (Helper.VowelStart(nameBar) ? "n " : " ") + nameBar + ".", Color.Crimson);

                            if (p.Equipment.TryGetValue("Ring", out ItemWrapper? eqp) && eqp != null && eqp.ID == "ringForging") {
                                eqp.Charges -= 1;  

                                if (eqp.Charges <= 0) { 
                                    log.AddMessage(new ColoredString("Your ring of forging runs out of charge and shatters.", Color.Crimson, Color.Black));
                                    p.Equipment.Remove("Ring");
                                }
                            }

                            p.TryGrantExp(Recipes[j].SkillUsed, Recipes[j].SkillEXP * (1 + extra), log, RecentSkills);
                            return true;
                        } else { 
                            int invCount = p.Inventory.Count; 
                            p.ConsumeItems([comp + "," + qty]);
                            if (invCount != p.Inventory.Count) { changedInv = true; }

                            invCount = p.Inventory.Count;
                            if (Recipes[j].SecondaryIn != "") {
                                p.ConsumeItems([Recipes[j].SecondaryIn]);
                            }
                            if (invCount != p.Inventory.Count) {
                                changedInv = true;
                            }

                            int extra = 0;

                            if (Recipes[j].FailOutput != "" && p.GetEffectiveSkillLevel(Recipes[j].SkillUsed) < Recipes[j].StopFailingLevel) {
                                int failRoll = GameLoop.rand.Next(100);  
                                // TODO: Make cooking gauntlets lower fail level after Family Crest is implemented

                                int skillForRoll = 50 + (p.GetEffectiveSkillLevel(Recipes[j].SkillUsed) - Recipes[j].SkillLevel);

                                if (failRoll <= skillForRoll || (p.Equipment.TryGetValue("Cape", out ItemWrapper? cape) && cape != null && cape.ID == "capeSkillCooking")) {
                                    if (ItemLibrary.ContainsKey(Recipes[j].OutputID)) {
                                        Item item = new(ItemLibrary[Recipes[j].OutputID]);
                                        item.Quantity = Recipes[j].OutputQtyBase;
                                        if (Recipes[j].NoteOutput) { item.Noted = true; }

                                        if (Recipes[j].HighSkillExtraOutputs) {
                                            int skillDiff = p.Skills[Recipes[j].SkillUsed].Level - Recipes[j].SkillLevel;
                                            extra = (int) Math.Floor(skillDiff / 10.0);
                                            item.Quantity += extra;
                                        }

                                        p.TryPickup(item, item.Quantity, item.Noted);
                                    }
                                
                                    p.TryGrantExp(Recipes[j].SkillUsed, Recipes[j].SkillEXP * (1 + extra), log, RecentSkills);
                                } else {
                                    if (ItemLibrary.ContainsKey(Recipes[j].FailOutput)) {
                                        Item item = new(ItemLibrary[Recipes[j].FailOutput]);
                                        item.Quantity = Recipes[j].OutputQtyBase;
                                        if (Recipes[j].NoteOutput) { item.Noted = true; }

                                        if (Recipes[j].HighSkillExtraOutputs) {
                                            int skillDiff = p.Skills[Recipes[j].SkillUsed].Level - Recipes[j].SkillLevel;
                                            extra = (int) Math.Floor(skillDiff / 10.0);
                                            item.Quantity += extra;
                                        }

                                        p.TryPickup(item, item.Quantity, item.Noted);
                                    }
                                
                                    p.TryGrantExp(Recipes[j].SkillUsed, 1 * (1 + extra), log, RecentSkills);
                                }
                            } else { 
                                if (ItemLibrary.ContainsKey(Recipes[j].OutputID)) {
                                    Item item = new(ItemLibrary[Recipes[j].OutputID]);
                                    item.Quantity = Recipes[j].OutputQtyBase;

                                    if (Recipes[j].NoteOutput) { item.Noted = true; }

                                    if (Recipes[j].HighSkillExtraOutputs) {
                                        int skillDiff = p.Skills[Recipes[j].SkillUsed].Level - Recipes[j].SkillLevel;
                                        extra = (int) Math.Floor(skillDiff / 10.0);
                                        item.Quantity += extra;
                                    }

                                    p.TryPickup(item, item.Quantity, item.Noted);
                                }
                                
                                p.TryGrantExp(Recipes[j].SkillUsed, Recipes[j].SkillEXP * (1 + extra), log, RecentSkills);
                            } 

                            if (Recipes[j].SecondaryOut != "") {
                                if (ItemLibrary.ContainsKey(Recipes[j].SecondaryOut)) {
                                    Item item = new(ItemLibrary[Recipes[j].SecondaryOut]); 

                                    p.TryPickup(item, item.Quantity);
                                }
                            }  

                            if (Recipes[j].Actions.Count > 0) {
                                foreach (var act in Recipes[j].Actions) {
                                    act.Execute();
                                }
                            }

                            return true;
                        }
                    } 
                    if (changedInv)
                        break;
                }
                if (changedInv)
                    break;
            }

            return false;
        }
    }
}
