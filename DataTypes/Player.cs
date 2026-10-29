using GoRogue.DiceNotation.Terms;
using Newtonsoft.Json; 
using WorldtreeNexus.Managers;

namespace WorldtreeNexus.DataTypes {
    public class Player {
        public string Name = "Player"; 
        public string NavLoc = "TI_StartHut";
        public string NavRespawn = "TI_Temple";

        public Clock Clock = new();

        public int CurrentHP = 0;
        public int CurrentMP = 0;
        public int CurrentPrayer = 0;
        public int HeldGold = 0;

        public int OffenseExpSplit = 2;
        public int DefenseExpSplit = 2;

        public string ElementalAttunement = "Earth";

        // Difficulty Settings

        public int TradeHallLimit = 1; // 0 = full, 1 = limited/bronze, 2 = none/iron
        public int DeathMode = 1; // 0 = no death penalty, 1 = drop items, 2 = reset character
        public bool NightmareMode = false; // if true, any damage taken will kill the player 

        public int ExpMultiplier = 1; // Multiply all gained exp by this amount
        public int PayToWin = 0; // If 0, experience is earned normally. Otherwise this is the cost in GP to get 1 exp (before the above multiplier is applied).
        public bool OnlyPayToWin = false; // If true and PayToWin isn't 0, exp can ONLY be bought, not earned

        public int DropMultiplier = 1; // Multiply all drop chance by this, high values may result in an issue
        public int DropModifier = 0; // 0 = Normal, 1 = Dry Protection, 2 = No RNG Drops

        public List<string> PermittedRegions = new(); // If empty all regions allowed, otherwise you can only go to maps in a region in this list

        public bool LocationLock = false; // If true, can only go to locations in the following list, and successfully going to a location not in it costs a LocationPoint
        public Dictionary<string, LocationCompletion> UnlockedLocations = new(); // 
        public int LocationPoints = 0; // Incremented each time you finish all tasks in a location
        public List<string> CompletedFeats = new();

        public int KillLimit = -1; // -1 = uncapped, otherwise after this many kills each unique monster name it will stop giving exp/drops
        public Dictionary<string, int> KillTracker = new(); // Log monsters by name and KC here

        public Dictionary<string, string> ItemIDRemaps = new(); // For randomizer
        public Dictionary<string, string> LocationIDRemaps = new(); // For randomizer
        public Dictionary<string, string> GatheringSpotRemapes = new(); // For randomizer

        public int RandomItems = 0; // 0 = not random, 1 = no logic rando set, 2 = no logic rando changing
        public int RandomLocs = 0; // 0 = not random, 1 = no logic rando
        public int RandomGathering = 0; // 0 = no random, 1 = no logic rando

        public int InventoryLimit = 20;
        public bool CanUseShops = true;
        public bool ShopsAlwaysFullPrice = false;
        public bool CanUseBanks = true;
        public int FarmGrowthIncrement = 60;

        // Quality of Life options
        public bool CoinPouch = true; // aka HeldGold allowed to be used, or force player to use the coins item
        public bool CoinPouchDeath = false; // Drops the contents of your coin pouch when you die

        // End of Difficulty Settings



        
        public List<ItemWrapper> Inventory = new();
        public Dictionary<string, ItemWrapper> Equipment = new(); 
        public Dictionary<string, Skill> Skills = new(); 
        public Dictionary<string, CollectionLogEntry> CollectionLog = new();
        public Dictionary<string, CollectionLogEntry> CollectionLogClues = new();
        public Dictionary<string, CollectionLogEntry> CollectionLogBoss = new();
        public List<ItemWrapper> BankedItems = new(); 
        public List<string> ItemsEverObtained = new(); 

        public string MagicBook = "Standard"; 

        public List<PotionStat> ActivePotions = new(); 
        public List<string> ActivePrayers = new();

        public Dictionary<string, FarmingPatch> FarmingPatches = new();

        public Dictionary<string, QuestStatus> QuestLog = new();

        public string CurrentClueTutorial = "";
        public int StepsDoneTutorial = 0;
        public string CurrentClueBeginner = "";
        public int StepsDoneBeginner = 0;
        public string CurrentClueEasy = "";
        public int StepsDoneEasy = 0;
        public string CurrentClueMedium = "";
        public int StepsDoneMedium = 0;
        public string CurrentClueHard = "";
        public int StepsDoneHard = 0;
        public string CurrentClueElite = "";
        public int StepsDoneElite = 0;
        public string CurrentClueMaster = "";
        public int StepsDoneMaster = 0; 

        public int SecondsPlayed = 0;
        public int PoisonStatus = 0;  
         

        public Dictionary<string, int> WorldState = new();

        public bool AllSongsUnlocked = false;
        public List<string> BlockedSongs = new();
        public string MusicMode = "Auto";
        public List<string> UnlockedSongs = new();

        public List<THTransaction> ActiveTH = new();

        public List<M_CozyCottagesHotspot> CozyContractSpots = new(); // The contract spots
        public string CozyDestID = ""; // The map they have to go to
        public int CozyPointTotal = 0; // For resolving exp reward after a contract
        public int CozyRewardPoints = 0; // For reward shop

        public Dictionary<string, PlayerOwnedHome> Homes = new();

        public int TimeLastRested = 0;
        public int CurrentRestedBuff = 0; 

        public int LeftIncense = 0;
        public int RightIncense = 0;
        
        public bool UsingSpell = false;
        public SpellCombat CombatCasting = null;
        public SpellCombat CombatViewing = new();
        public SpellCombat CombatSpell1 = null;
        public SpellCombat CombatSpell2 = null;
        public SpellCombat CombatSpell3 = null;
        public SpellCombat CombatSpell4 = null;
        public SpellCombat CombatSpell5 = null;

        [JsonIgnore]
        public List<HunterCreature> SpawnedCreatures = new();

        public int GetCombatLevel() {
            int atk = Skills["Attack"].Level;
            int str = Skills["Strength"].Level;
            int def = Skills["Defense"].Level;
            int con = Skills["Hitpoints"].Level;
            int ran = Skills["Ranged"].Level;
            int mag = Skills["Magic"].Level; 
            
            return Math.Clamp((atk + str + def + con + ran + mag) / 4, 1, 999);
        }

        public string GetDamageDice(bool spellBuilder = false) {
            double max = SimplerDamageDice(spellBuilder);
            if (IsMaging() || spellBuilder) {
                if (spellBuilder && CombatViewing != null) {  
                    if (CombatViewing.Speed == 1.5) { max = Math.Clamp(Math.Ceiling(max * 1.5), max + 2, int.MaxValue); }
                    if (CombatViewing.Speed == 1.25) { max = Math.Clamp(Math.Ceiling(max * 1.25), max + 1, int.MaxValue); }
                    if (CombatViewing.Speed == 0.75) { max = Math.Clamp(Math.Ceiling(max * 0.75), 1, Math.Clamp(max - 1, 1, max)); }
                    if (CombatViewing.Speed == 0.5) { max = Math.Clamp(Math.Ceiling(max * 0.5), 1, Math.Clamp(max - 2, 1, max)); } 
                    if (CombatViewing.Empowered) { max = Math.Clamp(Math.Ceiling(max * 1.25), max + 1, int.MaxValue); }

                    return "1d" + (int) max;
                }

                if (CombatCasting != null) {   
                    if (CombatCasting.Speed == 1.5) { Math.Clamp(Math.Ceiling(max * 1.25), max + 2, int.MaxValue); }
                    if (CombatCasting.Speed == 1.25) { Math.Clamp(Math.Ceiling(max * 1.25), max + 1, int.MaxValue); }
                    if (CombatCasting.Speed == 0.75) { max = Math.Clamp(Math.Ceiling(max * 0.75), 1, Math.Clamp(max - 1, 1, max)); }
                    if (CombatCasting.Speed == 0.5) { max = Math.Clamp(Math.Ceiling(max * 0.5), 1, Math.Clamp(max - 2, 1, max)); } 
                    if (CombatCasting.Empowered) { Math.Clamp(Math.Ceiling(max * 1.25), max + 1, int.MaxValue); }

                    return "1d" + (int) max;
                }
            }
            return "1d" + max; 
        }

        public int MaxDamage(bool spellBuilder = false) {
            string dmgDice = GetDamageDice(spellBuilder);
            //if (dmgDice.Contains("("))
            //    return GoRogue.DiceNotation.Dice.Roll("(" + dmgDice.Substring(3)); 
            return GoRogue.DiceNotation.Dice.Roll(dmgDice.Replace("1d", ""));
        }

        public double SimplerDamageDice(bool spellBuilder) {
            double weaponTier = 0.5;
            bool maging = IsMaging() || spellBuilder;

            string style = "Melee";

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? eqpWrap) && eqpWrap.GetRef() is Item eqp) {
                weaponTier = eqp.EquipTier;

                if (eqp.EquipSkill == "Ranged") {
                    style = "Ranged";
                    if (eqp.EquipAmmo == "RangedStandard" || eqp.EquipAmmo == "RangedHeavy") { // Only other option currently is Self, where we don't need to change weaponTier
                        if (Equipment.TryGetValue("Ammo", out ItemWrapper? ammoWrap) && ammoWrap.GetRef() is Item ammo) {
                            if (ammo.EquipLevel <= eqp.EquipLevel) {
                                weaponTier = ammo.EquipTier;
                            } else {
                                weaponTier = eqp.EquipTier;
                            }
                        } else {
                            weaponTier = 0;
                        }
                    } 
                }

                if (maging) {
                    if (eqp.EquipSkill != "Magic") { 
                        weaponTier = 0; 
                    } else {
                        if (spellBuilder) {
                            if (CombatViewing != null) {
                                if (weaponTier > CombatViewing.Tier) {
                                    weaponTier = Math.Min(CombatViewing.Tier, weaponTier);
                                }
                            }
                        }
                        else {
                            if (CombatCasting != null) {
                                if (weaponTier > CombatCasting.Tier) {
                                    weaponTier = Math.Min(CombatCasting.Tier, weaponTier);
                                }
                            } else {
                                weaponTier = 0;
                            }
                        }
                    }
                } else {
                    if (eqp.EquipSkill == "Magic") {
                        weaponTier = 0;
                    }
                }
            }
            double strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Strength") / 5f) + 1, 1, 30); 

            if (maging && CombatCasting != null) { 
                style = "Magic";
                //strength = (CombatCasting.Tier + 1);
                strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Magic") / 5f) + 1, 1, 30);
            }

            if (style == "Ranged") {
                strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Ranged") / 5f) + 1, 1, 30); 
            }

            double partialBoost = 0;
            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item item) {
                    if (item.MiscString == "OmniBoost" || item.MiscString == "OffenseBoost") {
                        strength += item.EquipTier;
                    }

                    if (item.MiscString == "PowerMelee" && style == "Melee") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if (item.MiscString == "PowerRange" && style == "Ranged") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if (item.MiscString == "PowerMagic" && style == "Magic") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if ((item.MiscString == "OffenseBoostMelee" && style == "Melee") || (item.MiscString == "Defender" && style == "Melee")) {
                        partialBoost += item.EquipTier;
                    }
                    
                    if (item.MiscString == "OffenseBoostRange" && style == "Ranged") {
                        partialBoost += item.EquipTier;
                    }

                    if (item.MiscString == "OffenseBoostMagic" && style == "Magic") {
                        partialBoost += item.EquipTier;
                    }
                } 
            }

            strength += (int) Math.Floor(partialBoost);

            // TODO: think of something better than this 
            return Math.Clamp(Math.Floor(weaponTier * 2), 1, 22) + strength;
            //return ((int) Math.Floor(weaponTier)) + "d" + ((int) Math.Floor(strength));
        }

        public string SimpleDamageDice(bool spellBuilder) {
            double weaponTier = 0.5;
            bool maging = IsMaging() || spellBuilder;

            string style = "Melee";

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? eqpWrap) && eqpWrap.GetRef() is Item eqp) {
                weaponTier = eqp.EquipTier;

                if (eqp.EquipSkill == "Ranged") {
                    style = "Ranged";
                    if (eqp.EquipAmmo == "RangedStandard" || eqp.EquipAmmo == "RangedHeavy") { // Only other option currently is Self, where we don't need to change weaponTier
                        if (Equipment.TryGetValue("Ammo", out ItemWrapper? ammoWrap) && ammoWrap.GetRef() is Item ammo) {
                            if (ammo.EquipLevel <= eqp.EquipLevel) {
                                weaponTier = ammo.EquipTier;
                            } else {
                                weaponTier = eqp.EquipTier;
                            }
                        } else {
                            weaponTier = 0;
                        }
                    } 
                }

                if (maging) {
                    if (eqp.EquipSkill != "Magic") { 
                        weaponTier = 0; 
                    } else {
                        if (spellBuilder) {
                            if (CombatViewing != null) {
                                if (weaponTier > CombatViewing.Tier) {
                                    weaponTier = Math.Min(CombatViewing.Tier, weaponTier);
                                }
                            }
                        }
                        else {
                            if (CombatCasting != null) {
                                if (weaponTier > CombatCasting.Tier) {
                                    weaponTier = Math.Min(CombatCasting.Tier, weaponTier);
                                }
                            } else {
                                weaponTier = 0;
                            }
                        }
                    }
                } else {
                    if (eqp.EquipSkill == "Magic") {
                        weaponTier = 0;
                    }
                }
            }
            double strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Strength") / 5f) + 1, 1, 30); 

            if (maging && CombatCasting != null) { 
                style = "Magic";
                //strength = (CombatCasting.Tier + 1);
                strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Magic") / 5f) + 1, 1, 30);
            }

            if (style == "Ranged") {
                strength = (int)Math.Clamp(Math.Floor(GetEffectiveSkillLevel("Ranged") / 5f) + 1, 1, 30); 
            }

            double partialBoost = 0;
            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item item) {
                    if (item.MiscString == "OmniBoost" || item.MiscString == "OffenseBoost") {
                        strength += item.EquipTier;
                    }

                    if (item.MiscString == "PowerMelee" && style == "Melee") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if (item.MiscString == "PowerRange" && style == "Ranged") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if (item.MiscString == "PowerMagic" && style == "Magic") {
                        partialBoost += item.EquipTier / 5.0;
                    }

                    if ((item.MiscString == "OffenseBoostMelee" && style == "Melee") || (item.MiscString == "Defender" && style == "Melee")) {
                        partialBoost += item.EquipTier;
                    }
                    
                    if (item.MiscString == "OffenseBoostRange" && style == "Ranged") {
                        partialBoost += item.EquipTier;
                    }

                    if (item.MiscString == "OffenseBoostMagic" && style == "Magic") {
                        partialBoost += item.EquipTier;
                    }
                } 
            }

            strength += (int) Math.Floor(partialBoost);

            // TODO: think of something better than this 
            return "1d" + ((int) Math.Clamp(Math.Floor(weaponTier * 2), 1, 22)) + "+" + strength;
            //return ((int) Math.Floor(weaponTier)) + "d" + ((int) Math.Floor(strength));
        }

        public string GetDamageType() {
            if (IsMaging() && CombatCasting != null) {
                return CombatCasting.DamageType;
            }

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrapper) && wepWrapper.GetRef() is Item wep)
                return wep.EquipDamageType;
            return "Crush";
        }

        public string GetDamageElement() {
            if (IsMaging() && CombatCasting != null) {
                return CombatCasting.Element;
            }

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrapper) && wepWrapper.GetRef() is Item wep)
                return wep.EquipElement;
            return ElementalAttunement;
        }

        public string GetSecondaryDamageType() {
            if (Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrapper) && wepWrapper.GetRef() is Item wep)
                return wep.EquipSecondaryDamage;
            return "";
        }

        public int GetAttackSpeed() {
            if (IsMaging() && CombatCasting != null) { 
                return (int) (CombatCasting.Speed * 2000);
            }

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrapper) && wepWrapper.GetRef() is Item wep)
                return (int) (wep.AttackSpeed * 2000);
            return 2000;
        }

        public bool TryPickup(ItemWrapper wrap, int qty, bool noted = false, bool shop = false, bool fromGround = false) {
            bool alreadyOwned = false;
            if (wrap.GetRef() is Item item && item.OnlyOneOwnable) {
                if (Helper.Requirement("ItemOwned", 1, wrap.ID)) {
                    GameLoop.WTN.Log.AddMessage("You already own one of those (in inventory, bank, or equipped) and can't pick up another.", Color.Crimson);
                    alreadyOwned = true;
                }
            }

            if (GameLoop.WTN.Atlas.TryGetValue(NavLoc, out Location? curr)) {
                ItemWrapper clone = new(wrap) { Quantity = qty };
                if (!alreadyOwned) {
                    if (!ItemsEverObtained.Contains(wrap.ID)) { ItemsEverObtained.Add(wrap.ID); }

                    for (int i = 0; i < Inventory.Count; i++) { 
                        if (Inventory[i].ID == wrap.ID && (Inventory[i].GetRef() is Item inv && (inv.Stackable || (noted && Inventory[i].Noted)))) {  
                            Inventory[i].Quantity += qty; 
                            if (!shop)
                                wrap.Quantity -= qty;
                            return true; 
                        }
                    } 
             
                    if (Inventory.Count < InventoryLimit) {
                        if (wrap.GetRef() is Item pickup && (pickup.Stackable || (pickup.Noteable && noted))) { 
                            if (noted)
                                clone.Noted = true;

                            clone.Quantity = qty;
                            if (!shop)
                                wrap.Quantity -= qty; 

                            Inventory.Add(clone);
                        } else {
                            for (int i = 0; i < qty; i++) { 
                                ItemWrapper secondClone = new(clone);
                                secondClone.Quantity = 1;
                                clone.Quantity--;
                                if (!shop)
                                    wrap.Quantity--;

                                if (Inventory.Count < InventoryLimit)
                                    Inventory.Add(secondClone);
                                else {
                                    if (curr.IsBank && CanUseBanks) {
                                        BankItem(secondClone);
                                        return true;
                                    } else {
                                        GameLoop.WTN.TryPlaceItem(NavLoc, secondClone);
                                        return true;
                                    }
                                }
                            }
                        }
                        return true;
                    } 
                }

                if (fromGround) {
                    if (!alreadyOwned) {
                        GameLoop.WTN.Log.AddMessage("Your inventory is too full to pick up anything else right now.", Color.Crimson);
                    }

                    return false;
                }
                 
                if (curr.IsBank && CanUseBanks && !alreadyOwned) {
                    BankItem(clone); 
                    return true;
                }

                for (int i = 0; i < curr.ItemsHere.Count; i++) {
                    if (curr.ItemsHere[i].ID == wrap.ID && wrap.Noted == curr.ItemsHere[i].Noted && curr.ItemsHere[i].UseInt4 == wrap.Charges
                        && (curr.ItemsHere[i].Alchemy == null || wrap.Alchemy == null || (curr.ItemsHere[i].Alchemy.CheckMatch(wrap.Alchemy)))) {
                        curr.ItemsHere[i].Quantity += qty; 
                        return true; 
                    }
                }

                if (clone.GetRef() is Item drop)
                    curr.ItemsHere.Add(drop);
                return true;
            }

            return false;
        }


        public bool TryPickup(Item item, int qty, bool noted = false, bool shop = false, bool fromGround = false) {  
            bool alreadyOwned = false;
            if (item.OnlyOneOwnable) {
                if (Helper.Requirement("ItemOwned", 1, item.ID)) {
                    GameLoop.WTN.Log.AddMessage("You already own one of those (in inventory, bank, or equipped) and can't pick up another.", Color.Crimson);
                    alreadyOwned = true;
                }
            }

            if (GameLoop.WTN.Atlas.TryGetValue(NavLoc, out Location? curr)) { 
                Item clone = new(item) { Quantity = qty };

                if (!alreadyOwned) { 
                    if (!ItemsEverObtained.Contains(item.ID)) { ItemsEverObtained.Add(item.ID); }

                    for (int i = 0; i < Inventory.Count; i++) { 
                        if (Inventory[i].GetRef() is Item wrap && wrap.ID == item.ID && (wrap.Stackable || (noted && Inventory[i].Noted))) {
                            Inventory[i].Quantity += qty;
                            if (!shop)
                                item.Quantity -= qty;
                            return true; 
                        }
                    }
             
                    if (Inventory.Count < InventoryLimit) {
                        if (item.Stackable || (item.Noteable && noted)) { 
                            if (noted)
                                clone.Noted = true;
                            if (!shop)
                                item.Quantity -= qty;
                            Inventory.Add(new(clone));
                        } else {
                            for (int i = 0; i < qty; i++) { 
                                Item secondClone = new(clone) { Quantity = 1 }; 
                                clone.Quantity--;
                                if (!shop)
                                    item.Quantity--;

                                if (Inventory.Count < InventoryLimit)
                                    Inventory.Add(new(secondClone));
                                else {
                                    if (curr.IsBank && CanUseBanks) {
                                        BankItem(new(secondClone));
                                        return true;
                                    } else {
                                        GameLoop.WTN.TryPlaceItem(NavLoc, new(secondClone));
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    } 
                }

                if (fromGround) {
                    GameLoop.WTN.Log.AddMessage("Your inventory is too full to pick up anything else right now.", Color.Crimson);
                    return false;
                }
                 
                if (curr.IsBank && CanUseBanks && !alreadyOwned) {
                    BankItem(new(clone)); 
                    return true;
                }

                for (int i = 0; i < curr.ItemsHere.Count; i++) {
                    if (curr.ItemsHere[i].ID == item.ID && item.Noted == curr.ItemsHere[i].Noted && curr.ItemsHere[i].UseInt4 == item.UseInt4 
                        && (curr.ItemsHere[i].Alchemy == null || item.Alchemy == null || (curr.ItemsHere[i].Alchemy.CheckMatch(item.Alchemy)))) {
                        curr.ItemsHere[i].Quantity += qty; 
                        return true; 
                    }
                }

                curr.ItemsHere.Add(clone);
                return true;
            }

            return false;
        }

        public void BankItem(ItemWrapper item) {  
            for (int j = 0; j < BankedItems.Count; j++) {
                if (BankedItems[j].ID == item.ID && BankedItems[j].Charges == item.Charges
                    && (BankedItems[j].Alchemy == null || item.Alchemy == null || (BankedItems[j].Alchemy.CheckMatch(item.Alchemy)))) {
                    BankedItems[j].Quantity += item.Quantity; 
                    return; 
                }
            }

            item.Noted = false;
            BankedItems.Add(item);
        }

        public bool TryDrop(int i, int qtyOverride = -1) {
            if (GameLoop.WTN.Atlas.TryGetValue(NavLoc, out Location? curr) && curr != null) {
                int qty = 1;
                                
                if (Helper.EitherShift())
                    qty *= 5;
                if (Helper.EitherControl())
                    qty *= 10;

                if (qtyOverride != -1)
                    qty = qtyOverride;

                if (qty > Inventory[i].Quantity || Helper.EitherAlt())
                    qty = Inventory[i].Quantity; 

                if (Inventory[i].GetRef() is Item toDrop) {
                    if (curr.IsBank && CanUseBanks) {
                        ItemWrapper clone = new(Inventory[i]);
                        clone.Quantity = qty; 
                        BankItem(clone);

                        Inventory[i].Quantity -= qty; 
                    }
                    else {
                        if (curr.ShopItemsHere.Count == 0 || !CanUseShops) {
                            if (toDrop.DestroyOnDrop) {
                                if (Inventory[i].ID == "clueScrollTutorial") {
                                    CurrentClueTutorial = "";
                                } else if (Inventory[i].ID == "clueScrollBeginner") {
                                    CurrentClueBeginner = "";
                                } else if (Inventory[i].ID == "clueScrollEasy") {
                                    CurrentClueEasy = "";
                                } else if (Inventory[i].ID == "clueScrollMedium") {
                                    CurrentClueMedium = "";
                                } else if (Inventory[i].ID == "clueScrollHard") {
                                    CurrentClueHard = "";
                                } else if (Inventory[i].ID == "clueScrollElite") {
                                    CurrentClueElite = "";
                                } else if (Inventory[i].ID == "clueScrollMaster") {
                                    CurrentClueMaster = "";
                                }

                                Inventory.RemoveAt(i);
                                return true;
                            } else {
                                bool found = false;
                                for (int j = 0; j < curr.ItemsHere.Count; j++) {
                                    if (curr.ItemsHere[j].ID == Inventory[i].ID && curr.ItemsHere[j].Noted == Inventory[i].Noted && curr.ItemsHere[j].UseInt4 == Inventory[i].Charges
                                        && (curr.ItemsHere[j].Alchemy == null || Inventory[i].Alchemy == null || (curr.ItemsHere[j].Alchemy.CheckMatch(Inventory[i].Alchemy)))) {
                                        curr.ItemsHere[j].Quantity += qty;
                                        Inventory[i].Quantity -= qty;
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found) {
                                    Item clone = new(toDrop);
                                    clone.Quantity = qty;

                                    if (Inventory[i].Containing.Count > 0) {
                                        foreach (var con in Inventory[i].Containing) {
                                            clone.Containing.Add(new(con));
                                        }
                                    }

                                    curr.ItemsHere.Add(clone);
                                    Inventory[i].Quantity -= qty;
                                }
                            }
                        }
                        else {
                            if (Inventory[i].Containing.Count > 0) {
                                GameLoop.WTN.Log.AddMessage("You probably don't want to sell that, and should remove all items from it first if you do.", Color.Crimson);
                            } else {
                                if (Inventory[i].ID == "coins") { 
                                    GameLoop.WTN.Log.AddMessage("It is inadvisable to sell coins, as you're unlikely to get the better end of that deal.", Color.Crimson);
                                } else {
                                    int sellValue = toDrop.Value;

                                    if (Inventory[i].Charges != 0 && toDrop.UseString == "Potion") {
                                        sellValue *= Inventory[i].Charges;
                                    } 

                                    if (curr.ShopPriceMultiplier < 1.0) {
                                        sellValue = (int) (sellValue * curr.ShopPriceMultiplier);
                                    }
                                        
                                    if (!ShopsAlwaysFullPrice && !curr.ShopItemsHere.Contains(Inventory[i].ID)) {
                                        sellValue = (int) (Math.Floor(sellValue / 2.0));
                                    }

                                    GiveGold(sellValue * qty);
                                    Inventory[i].Quantity -= qty;
                                }
                            }
                        }
                    }
                }

                if (Inventory[i].Quantity <= 0) {
                    Inventory.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }


        public void TryGrantExp(string which, int amountIn, MessageLog log, List<Skill> RecentSkills, bool buying = false) {
            int amount = amountIn;

            foreach (var pot in ActivePotions) {
                if (pot.Stat == "Experience") {
                    amount = amount + ((int) Math.Ceiling(amount * (pot.Change / 100.0)));
                }
            }


            if (Skills.ContainsKey(which)) { 
                int oldLevel = Skills[which].Level; 

                if (OnlyPayToWin && !buying)
                    return;

                if (PayToWin > 0 && buying) { 

                    if (GoldTotal() >= (PayToWin * amount)) {
                        TakeGold(PayToWin * amount); 
                        log.AddMessage(new ColoredString("Paid " + String.Format($"{PayToWin * amount:n0}") + " for " + (amount * ExpMultiplier) + " " + which + " experience.", Color.Goldenrod, Color.Black));
                    } else {
                        log.AddMessage(new ColoredString("Sorry, " + Name + "! I can't give credit. Come back when you're a little... mmmm... richer! (Need " + String.Format($"{PayToWin * amount:n0}") + "gp)", Color.Crimson, Color.Black));
                        return;
                    }
                }
                 
                Skills[which].GrantExp(amount * ExpMultiplier, log, RecentSkills);

                if (which == "Hitpoints" && oldLevel != Skills[which].Level) {
                    CurrentHP += (Skills[which].Level - oldLevel);
                }
                    
                if (!WorldState.ContainsKey("SkillPet" + which)) {
                    if (GameLoop.rand.Next(50000000) < amount * ExpMultiplier) { 
                        if (GameLoop.WTN.ResolveItem("petSkill" + which) is Item skillPet) {
                            TryPickup(skillPet, 1);
                            GameLoop.WTN.Log.AddMessage("You get the funny feeling you're being followed...", Color.Yellow);
                            GameLoop.WTN.Log.AddMessage("You found the " + which + " skilling pet, " + skillPet.Name + "!", Color.Lime);
                            WorldState.Add("SkillPet" + which, 1);
                        }  
                    }
                } 
            } 
        } 

        public bool TakeDamage(int amt, MessageLog log) {  
            CurrentHP -= amt;

            if (CurrentHP > 0) {
                int maxHP = GetEffectiveSkillLevel("Hitpoints");
                
                if (CurrentHP <  maxHP * 0.2) {
                    if (Equipment.TryGetValue("Amulet", out ItemWrapper? eqp) && eqp != null && eqp.ID == "necklacePhoenix") { 
                        CurrentHP = (int) Math.Clamp(CurrentHP + (maxHP * 0.3), CurrentHP, maxHP);
                         
                        log.AddMessage(new ColoredString("Your phoenix necklace restores you from low health, then shatters.", Color.White, Color.Black));
                        Equipment.Remove("Amulet"); 
                    }  
                }

                if (CurrentHP <  maxHP * 0.1) {
                    if (Equipment.TryGetValue("Ring", out ItemWrapper? eqp) && eqp != null && eqp.ID == "ringLife") {  
                        NavLoc = NavRespawn; 
                        log.AddMessage(new ColoredString("Your ring of life teleports you away from danger, then shatters.", Color.White, Color.Black));
                        Equipment.Remove("Ring"); 
                    }  
                }
            }

            if (CurrentHP <= 0 || (NightmareMode && amt > 0)) {
                Die(log);
                return true;
            }

            return false;
        }

        public void Die(MessageLog log) {
            if (DeathMode == 1) { // Drop all items
                if (GameLoop.WTN.Atlas.TryGetValue(NavLoc, out Location? deathSpot)) {
                    if (deathSpot != null) {
                        for (int i = Inventory.Count - 1; i >= 0; i--) {
                            TryDrop(i, Inventory[i].Quantity);
                        }
                        
                        foreach (var kv in Equipment) { 
                            GameLoop.WTN.TryPlaceItem(NavLoc, kv.Value); 
                        } 
                        Equipment.Clear();

                        if (HeldGold > 0 && CoinPouchDeath) {
                            if (GameLoop.WTN.ResolveItem("coins") is Item coin) {
                                coin.Quantity = HeldGold;
                                GameLoop.WTN.TryPlaceItem(NavLoc, new(coin));
                                HeldGold = 0;
                            }
                        }
                    }
                }
            }

            log.AddMessage(new ColoredString("Oh no, you died!", Color.Crimson, Color.Black));

            if (DeathMode == 2) { // Reset character and whole world so you can't cheese it by dropping items before dying then picking them up
                GameLoop.WTN.RebuildLibraries();
                GameLoop.WTN.SoftResetPlayer();
            } 

            NavLoc = NavRespawn;
            CurrentHP = Skills["Hitpoints"].Level;
            PoisonStatus = 0;
        }



        public void AddFeat(string feat) {
            if (LocationLock) {
                if (!CompletedFeats.Contains(feat)) {
                    CompletedFeats.Add(feat);

                    foreach (var kv in UnlockedLocations) {
                        if (!kv.Value.Completed) {
                            kv.Value.CheckCompletion(this);
                        }
                    }
                }
            }
        }   

        public int GetEffectiveSkillLevel(string which) {
            if (Skills.TryGetValue(which, out Skill? s)) {
                if (s != null) {
                    double level = s.Level;

                    foreach (var pot in ActivePotions) {
                        if (pot.Stat == which) {
                            level += pot.Change;
                        }
                    } 

                    foreach (var kv in Equipment) {
                        if (kv.Value.GetRef() is Item eqp) {
                            if (eqp.MiscString == which + "Boost") {
                                level += eqp.EquipTier;
                            }
                        }
                    } 

                    foreach (var pray in GameLoop.WTN.PrayerLibrary) {
                        if (ActivePrayers.Contains(pray.Value.Name)) {
                            if (pray.Value.SkillBuffed == which) {
                                double buff = pray.Value.AmountBuffed / 100.0;
                                level = (int) Math.Ceiling(Math.Clamp(level * buff, level + 1, int.MaxValue));
                            }
                        }
                    }

                    return (int) Math.Floor(level);
                }
            }

            return 0;  
        }  

        public int GetSkillCheck(string which) {
            if (Skills.ContainsKey(which)) {
                int stat = GetEffectiveSkillLevel(which);
                return stat < 3 ? 10 + stat : 12 + (((stat - 2) / 2) / 4);
            }

            return 10;
        }

        public bool CanCraft(CraftRecipe craft) {
            if (!Skills.ContainsKey(craft.Skill))
                return false;
            if (Skills[craft.Skill].Level < craft.Level)
                return false;
            if (!GameLoop.WTN.ItemLibrary.ContainsKey(craft.OutputItem))
                return false;

            foreach (var req in craft.Reqs) {
                if (!req.CheckRequirement(this, false, true)) {
                    return false;
                }
            }

            if (craft.ExtraTool != "") {
                bool hasTool = false;
                for (int i = 0; i < Inventory.Count; i++) {
                    if (Inventory[i].ID == craft.ExtraTool && !Inventory[i].Noted) {
                        hasTool = true;
                        break;
                    }
                }

                if (!hasTool)
                    return false;
            }


            return HasAllItems(craft.NeededItems, false, true);
        }

        public void TryCraft(CraftRecipe craft) {
            if (!CanCraft(craft))
                return;

            ConsumeItems(craft.NeededItems); 

            Item item = new(GameLoop.WTN.ItemLibrary[craft.OutputItem]);
            if (item.Stackable) {
                for (int i = 0; i < craft.OutputQty; i++) {
                    Item clone = new(item);
                    TryPickup(clone, 1);
                }
            } else {
                item.Quantity = craft.OutputQty; 
                TryPickup(item, item.Quantity);
            }
            TryGrantExp(craft.Skill, craft.ExpGranted, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
        }

        public bool HasAllItems(List<string> items, bool notedOkay = false, bool equippedOkay = false, bool ONLYequipped = false) { 
            foreach (var itemString in items) {
                string item = itemString;
                int qty = 1;
                int countHeld = 0;

                if (itemString.Contains(",")) {
                    string[] split = itemString.Split(",");
                    
                    if (int.TryParse(split[1], out int parseQty)) {
                        qty = parseQty;
                    }

                    item = split[0];
                }

                if (item == "Gold") {
                    if (GoldTotal() < qty) {
                        return false;
                    }
                    continue;
                }

                if (!ONLYequipped) {
                    // Check for items that count as the item but aren't the item (for example, elemental staves)
                    for (int i = 0; i < Inventory.Count; i++) {
                        if (Inventory[i].GetRef() is Item comp && comp.CountsAsIDs.Contains(item) && !comp.MustBeEquipped) {
                            if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                                if (Inventory[i].Charges == -1) {
                                    countHeld = qty;
                                } else { 
                                    if (comp.Stackable) { 
                                        countHeld += Inventory[i].Quantity;
                                    } else {
                                        countHeld += Inventory[i].Charges;
                                    }
                                } 
                            }
                        }

                        for (int con = 0; con < Inventory[i].Containing.Count; con++) {
                            if (Inventory[i].Containing[con].GetRef() is Item conInv && conInv.CountsAsIDs.Contains(item)) {
                                if (Inventory[i].Containing[con].Charges == -1) {
                                    countHeld = qty;
                                } else {
                                    if (conInv.Stackable) {
                                        countHeld += Inventory[i].Containing[con].Quantity;
                                    } else {
                                        countHeld += Inventory[i].Containing[con].Charges;
                                    }
                                }
                            }
                        }
                    }
                }

                if (equippedOkay) {
                    foreach (var kv in Equipment) {
                        if (kv.Value.GetRef() is Item eqp && eqp.CountsAsIDs.Contains(item)) {
                            if (kv.Value.Charges == -1) {
                                countHeld = qty;
                            } else {
                                if (eqp.Stackable) {
                                    countHeld += kv.Value.Quantity;
                                } else {
                                    countHeld += kv.Value.Charges;
                                }
                            }
                        }

                        for (int con = 0; con < kv.Value.Containing.Count; con++) {
                            if (kv.Value.Containing[con].GetRef() is Item conEqp && conEqp.CountsAsIDs.Contains(item)) {
                                if (kv.Value.Containing[con].Charges == -1) {
                                    countHeld = qty;
                                } else {
                                    if (conEqp.Stackable) {
                                        countHeld += kv.Value.Containing[con].Quantity;
                                    } else {
                                        countHeld += kv.Value.Containing[con].Charges;
                                    }
                                }
                            }
                        }
                    }
                } 


                if (!ONLYequipped) {
                    // Check for actual copies of the item
                    for (int i = 0; i < Inventory.Count; i++) {
                        if (Inventory[i].ID == item) {
                            if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) { 
                                countHeld += Inventory[i].Quantity;
                            }
                        }

                        for (int con = 0; con < Inventory[i].Containing.Count; con++) {
                            if (Inventory[i].Containing[con].ID == item) { 
                                countHeld += Inventory[i].Containing[con].Quantity; 
                            }
                        }
                    }
                }

                if (equippedOkay) {
                    foreach (var kv in Equipment) {
                        if (kv.Value.ID == item) {
                            countHeld += kv.Value.Quantity;
                        }

                        for (int con = 0; con < kv.Value.Containing.Count; con++) {
                            if (kv.Value.Containing[con].GetRef() is Item conEqp && conEqp.ID == item) { 
                                countHeld += kv.Value.Containing[con].Quantity; 
                            }
                        }
                    }
                }

                if (countHeld < qty)
                    return false;
            }

            return true;
        }

        public void ConsumeItems(List<string> items, bool notedOkay = false, bool equippedOkay = false) {
            Dictionary<string, int> CountsLeft = new();
            foreach (var itemString in items) {
                string item = itemString;
                int qty = 1;
                int countNeeded = 0;

                if (itemString.Contains(",")) {
                    string[] split = itemString.Split(",");
                    
                    if (int.TryParse(split[1], out int parseQty)) {
                        qty = parseQty;
                    }

                    item = split[0];
                }

                countNeeded = qty;

                if (item == "Gold") {
                    TakeGold(qty);
                    continue;
                }

                CountsLeft.Add(item, countNeeded);
            } 

            List<string> EquipClear = new();

            // Check for items that count as the item but aren't the item (for example, elemental staves) and have infinite charge
            for (int i = 0; i < Inventory.Count; i++) {
                if (Inventory[i].GetRef() is Item comp && !comp.MustBeEquipped) {
                    for (int j = 0; j < comp.CountsAsIDs.Count; j++) {
                        if (CountsLeft.ContainsKey(comp.CountsAsIDs[j])) {
                            if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                                if (Inventory[i].Charges == -1) {
                                    CountsLeft[comp.CountsAsIDs[j]] = 0;
                                }
                            }
                        }
                    }

                    if (CountsLeft.ContainsKey(Inventory[i].ID)) {
                        if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                            if (Inventory[i].Charges == -1) {
                                CountsLeft[Inventory[i].ID] = 0;
                            }
                        }
                    }
                }

                for (int con = 0; con < Inventory[i].Containing.Count; con++) { // Can any applicable item even be stored in a container? I have no idea
                    if (CountsLeft.ContainsKey(Inventory[i].Containing[con].ID)) {
                        if (!Inventory[i].Containing[con].Noted || (Inventory[i].Containing[con].Noted && notedOkay)) {
                            if (Inventory[i].Containing[con].Charges == -1) {
                                CountsLeft[Inventory[i].Containing[con].ID] = 0;
                            }
                        }
                    } 
                }
            }  

            if (equippedOkay) {
                foreach (var kv in Equipment) {
                    if (kv.Value.GetRef() is Item eqp) {
                        for (int j = 0; j < eqp.CountsAsIDs.Count; j++) {
                            if (CountsLeft.ContainsKey(eqp.CountsAsIDs[j])) {
                                if (!kv.Value.Noted || (kv.Value.Noted && notedOkay)) {
                                    if (kv.Value.Charges == -1) {
                                        CountsLeft[eqp.CountsAsIDs[j]] = 0;
                                    }
                                }
                            }
                        }

                        if (CountsLeft.ContainsKey(kv.Value.ID)) {
                            if (!kv.Value.Noted || (kv.Value.Noted && notedOkay)) {
                                if (kv.Value.Charges == -1) {
                                    CountsLeft[kv.Value.ID] = 0;
                                }
                            }
                        }
                    }

                    for (int con = 0; con < kv.Value.Containing.Count; con++) { // Can any applicable item even be stored in a container? I have no idea
                        if (CountsLeft.ContainsKey(kv.Value.Containing[con].ID)) {
                            if (!kv.Value.Containing[con].Noted || (kv.Value.Containing[con].Noted && notedOkay)) {
                                if (kv.Value.Containing[con].Charges == -1) {
                                    CountsLeft[kv.Value.Containing[con].ID] = 0;
                                }
                            }
                        } 
                    }
                }
            } 

            // Check for items that count as the item but aren't the item (for example, elemental staves)
            for (int i = Inventory.Count - 1; i >= 0; i--) {
                if (Inventory[i].GetRef() is Item comp && !comp.MustBeEquipped) {
                    int highestUsed = 0;
                    for (int j = 0; j < comp.CountsAsIDs.Count; j++) {
                        if (CountsLeft.ContainsKey(comp.CountsAsIDs[j])) {
                            if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                                if (Inventory[i].Charges == -1) {
                                    CountsLeft[comp.CountsAsIDs[j]] = 0;
                                } else {
                                    if (comp.Stackable) {
                                        if (Inventory[i].Quantity > CountsLeft[comp.CountsAsIDs[j]]) {
                                            highestUsed = Math.Max(highestUsed, CountsLeft[comp.CountsAsIDs[j]]);
                                            CountsLeft[comp.CountsAsIDs[j]] = 0; 
                                        } else {
                                            CountsLeft[comp.CountsAsIDs[j]] -= Inventory[i].Quantity;
                                            highestUsed = Math.Max(highestUsed, Inventory[i].Quantity); 
                                        }
                                    } else {
                                        if (Inventory[i].Charges > CountsLeft[comp.CountsAsIDs[j]]) {
                                            highestUsed = Math.Max(highestUsed, CountsLeft[comp.CountsAsIDs[j]]);
                                            CountsLeft[comp.CountsAsIDs[j]] = 0; 
                                        } else {
                                            CountsLeft[comp.CountsAsIDs[j]] -= Inventory[i].Charges;
                                            highestUsed = Math.Max(highestUsed, Inventory[i].Charges);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (highestUsed > 0) {
                        if (comp.Stackable) {
                            Inventory[i].Quantity -= highestUsed;
                            if (Inventory[i].Quantity <= 0) {
                                Inventory.RemoveAt(i); 
                                continue;
                            }
                        } else {
                            Inventory[i].Charges -= highestUsed;
                            if (Inventory[i].Charges <= 0 && comp.ShattersAtZeroCharges) {
                                Inventory.RemoveAt(i); 
                                continue;
                            } 
                        }
                    }

                    if (CountsLeft.ContainsKey(Inventory[i].ID)) {
                        if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                            if (Inventory[i].Charges == -1) {
                                CountsLeft[Inventory[i].ID] = 0;
                            } else {
                                if (comp.Stackable) {
                                    if (Inventory[i].Quantity > CountsLeft[Inventory[i].ID]) {
                                        Inventory[i].Quantity -= CountsLeft[Inventory[i].ID];
                                        CountsLeft[Inventory[i].ID] = 0; 
                                    } else {
                                        CountsLeft[Inventory[i].ID] -= Inventory[i].Quantity;
                                        Inventory[i].Quantity = 0;
                                        Inventory.RemoveAt(i);
                                        continue; 
                                    }
                                } else {
                                    if (Inventory[i].Charges > CountsLeft[Inventory[i].ID]) {
                                        Inventory[i].Charges -= CountsLeft[Inventory[i].ID];
                                        CountsLeft[Inventory[i].ID] = 0; 
                                    } else {
                                        CountsLeft[Inventory[i].ID] -= Inventory[i].Charges;
                                        Inventory[i].Charges = 0;
                                    }
                                }
                            }
                        }
                    }
                }

                if (Inventory[i].Containing.Count > 0) {
                    for (int condex = Inventory[i].Containing.Count - 1; condex >= 0; condex--) {
                        ItemWrapper con = Inventory[i].Containing[condex];
                        if (CountsLeft.ContainsKey(con.ID) && con.GetRef() is Item comp2) {
                            if (!con.Noted || (con.Noted && notedOkay)) {
                                if (con.Charges == -1) {
                                    CountsLeft[con.ID] = 0;
                                } else {
                                    if (comp2.Stackable) {
                                        if (con.Quantity > CountsLeft[con.ID]) {
                                            con.Quantity -= CountsLeft[con.ID];
                                            CountsLeft[con.ID] = 0; 
                                        } else {
                                            CountsLeft[con.ID] -= con.Quantity;
                                            con.Quantity = 0;
                                            Inventory[i].Containing.RemoveAt(condex);
                                            continue; 
                                        }
                                    } else {
                                        if (con.Charges > CountsLeft[con.ID]) {
                                            con.Charges -= CountsLeft[con.ID];
                                            CountsLeft[con.ID] = 0; 
                                        } else {
                                            CountsLeft[con.ID] -= con.Charges;
                                            con.Charges = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }  

            if (equippedOkay) {
                foreach (var kv in Equipment) {
                    if (kv.Value.GetRef() is Item eqp) {
                        int highestUsed = 0;

                        for (int j = 0; j < eqp.CountsAsIDs.Count; j++) {
                            if (CountsLeft.ContainsKey(eqp.CountsAsIDs[j])) {
                                if (!kv.Value.Noted || (kv.Value.Noted && notedOkay)) {
                                    if (kv.Value.Charges == -1) {
                                        CountsLeft[eqp.CountsAsIDs[j]] = 0;
                                    } else {
                                        if (eqp.Stackable) {
                                            if (kv.Value.Quantity > CountsLeft[eqp.CountsAsIDs[j]]) {
                                                highestUsed = Math.Max(highestUsed, CountsLeft[eqp.CountsAsIDs[j]]);
                                                CountsLeft[eqp.CountsAsIDs[j]] = 0; 
                                            } else {
                                                CountsLeft[eqp.CountsAsIDs[j]] -= kv.Value.Quantity;
                                                highestUsed = Math.Max(highestUsed, kv.Value.Quantity);
                                                EquipClear.Add(kv.Key);
                                            }
                                        } else {
                                            if (kv.Value.Charges > CountsLeft[eqp.CountsAsIDs[j]]) {
                                                highestUsed = Math.Max(highestUsed, CountsLeft[eqp.CountsAsIDs[j]]);
                                                CountsLeft[eqp.CountsAsIDs[j]] = 0; 
                                            } else {
                                                CountsLeft[eqp.CountsAsIDs[j]] -= kv.Value.Charges;
                                                highestUsed = Math.Max(highestUsed, kv.Value.Charges);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (highestUsed > 0) {
                            if (eqp.Stackable) {
                                kv.Value.Quantity -= highestUsed;
                                if (kv.Value.Quantity <= 0) {
                                    EquipClear.Add(kv.Key);
                                }
                            } else {
                                kv.Value.Charges -= highestUsed;
                                if (kv.Value.Charges <= 0 && eqp.ShattersAtZeroCharges) {
                                    EquipClear.Add(kv.Key);
                                } 
                            }
                        }

                        if (CountsLeft.ContainsKey(kv.Value.ID)) {
                            if (!kv.Value.Noted || (kv.Value.Noted && notedOkay)) {
                                if (kv.Value.Charges == -1) {
                                    CountsLeft[kv.Value.ID] = 0;
                                } else {
                                    if (eqp.Stackable) {
                                        if (kv.Value.Quantity > CountsLeft[kv.Value.ID]) {
                                            kv.Value.Quantity -= CountsLeft[kv.Value.ID];
                                            CountsLeft[kv.Value.ID] = 0; 
                                        } else {
                                            CountsLeft[kv.Value.ID] -= kv.Value.Quantity;
                                            kv.Value.Quantity = 0;
                                            EquipClear.Add(kv.Key);
                                        }
                                    } else {
                                        if (kv.Value.Charges > CountsLeft[kv.Value.ID]) {
                                            kv.Value.Charges -= CountsLeft[kv.Value.ID];
                                            CountsLeft[kv.Value.ID] = 0; 
                                        } else {
                                            CountsLeft[kv.Value.ID] -= kv.Value.Charges;
                                            kv.Value.Charges = 0;

                                            if (eqp.ShattersAtZeroCharges)
                                                EquipClear.Add(kv.Key);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    if (kv.Value.Containing.Count > 0) {
                        for (int condex = kv.Value.Containing.Count - 1; condex >= 0; condex--) {
                            ItemWrapper con = kv.Value.Containing[condex];
                            if (CountsLeft.ContainsKey(con.ID) && con.GetRef() is Item comp2) {
                                if (!con.Noted || (con.Noted && notedOkay)) {
                                    if (con.Charges == -1) {
                                        CountsLeft[con.ID] = 0;
                                    } else {
                                        if (comp2.Stackable) {
                                            if (con.Quantity > CountsLeft[con.ID]) {
                                                con.Quantity -= CountsLeft[con.ID];
                                                CountsLeft[con.ID] = 0; 
                                            } else {
                                                CountsLeft[con.ID] -= con.Quantity;
                                                con.Quantity = 0;
                                                kv.Value.Containing.RemoveAt(condex); 
                                                continue;
                                            }
                                        } else {
                                            if (con.Charges > CountsLeft[con.ID]) {
                                                con.Charges -= CountsLeft[con.ID];
                                                CountsLeft[con.ID] = 0; 
                                            } else {
                                                CountsLeft[con.ID] -= con.Charges;
                                                con.Charges = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Check for the actual item matches
            for (int i = Inventory.Count - 1; i >= 0; i--) {
                if (CountsLeft.ContainsKey(Inventory[i].ID)) {
                    if (!Inventory[i].Noted || (Inventory[i].Noted && notedOkay)) {
                        if (CountsLeft[Inventory[i].ID] > Inventory[i].Quantity) {
                            CountsLeft[Inventory[i].ID] -= Inventory[i].Quantity;
                            Inventory.RemoveAt(i); 
                            continue;
                        } else { 
                            Inventory[i].Quantity -= CountsLeft[Inventory[i].ID];
                            CountsLeft[Inventory[i].ID] = 0;

                            if (Inventory[i].Quantity <= 0) {
                                Inventory.RemoveAt(i); 
                                continue;
                            }
                        }
                    }
                }

                if (Inventory[i].Containing.Count > 0) {
                    for (int condex = Inventory[i].Containing.Count - 1; condex >= 0; condex--) {
                        ItemWrapper con = Inventory[i].Containing[condex];

                        if (CountsLeft.ContainsKey(con.ID)) {
                            if (!con.Noted || (con.Noted && notedOkay)) {
                                if (CountsLeft[con.ID] > con.Quantity) {
                                    CountsLeft[con.ID] -= con.Quantity;
                                    Inventory[i].Containing.RemoveAt(condex);
                                    continue;
                                } else {
                                    con.Quantity -= CountsLeft[con.ID];
                                    CountsLeft[con.ID] = 0;

                                    if (con.Quantity <= 0) {
                                        Inventory[i].Containing.RemoveAt(condex);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            } 

            if (equippedOkay) {
                foreach (var kv in Equipment) {
                    if (CountsLeft.ContainsKey(kv.Value.ID)) {
                        if (CountsLeft[kv.Value.ID] > kv.Value.Quantity) {
                            CountsLeft[kv.Value.ID] -= kv.Value.Quantity;
                            EquipClear.Add(kv.Key);
                        } else {
                            kv.Value.Quantity -= CountsLeft[kv.Value.ID];
                            CountsLeft[kv.Value.ID] = 0;

                            if (kv.Value.Quantity <= 0) {
                                EquipClear.Add(kv.Key);
                            }
                        } 
                    }

                    if (kv.Value.Containing.Count > 0) {
                        for (int condex = kv.Value.Containing.Count - 1; condex >= 0; condex--) {
                            ItemWrapper con = kv.Value.Containing[condex];

                            if (CountsLeft.ContainsKey(con.ID)) {
                                if (!con.Noted || (con.Noted && notedOkay)) {
                                    if (CountsLeft[con.ID] > con.Quantity) {
                                        CountsLeft[con.ID] -= con.Quantity;
                                        kv.Value.Containing.RemoveAt(condex);
                                    } else {
                                        con.Quantity -= CountsLeft[con.ID];
                                        CountsLeft[con.ID] = 0;

                                        if (con.Quantity <= 0) {
                                            kv.Value.Containing.RemoveAt(condex);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (var kv in EquipClear) {
                Equipment.Remove(kv);
            } 
        }


        public int TotalArmorValue(string against) {
            double count = 0;

            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item eqp) {
                    double num = eqp.EquipTier;
                    if (eqp.EquipSkill == "Defense" || eqp.MiscString == "DefenseAll") {
                        if (eqp.MiscString == "DefenseMelee" || eqp.MiscString == "PowerMelee") {
                            if (against == "Ranged") {
                                num *= 2;
                            }
                            if (against == "Magic") {
                                num = (int)Math.Floor(num / 2.0);
                            }

                            if (eqp.MiscString == "PowerMelee") {
                                num = Math.Floor(num * 0.8);
                            }
                        }

                        if (eqp.MiscString == "Defender") {
                            if (against == "Melee") {
                                num = (int)Math.Floor(num / 2.0);
                            }
                            if (against == "Magic") {
                                num = (int)Math.Floor(num / 4.0);
                            }
                        }

                        if (eqp.MiscString == "DefenseMagic" || eqp.MiscString == "PowerMagic") {
                            if (against == "Melee") {
                                num *= 2;
                            }
                            if (against == "Ranged") {
                                num = Math.Floor(num / 2.0);
                            }

                            if (eqp.MiscString == "PowerMagic") {
                                num = Math.Floor(num * 0.8);
                            }
                        }

                        if (eqp.MiscString == "DefenseRange" || eqp.MiscString == "PowerRange") {
                            if (against == "Magic") {
                                num *= 2;
                            }
                            if (against == "Melee") {
                                num = Math.Floor(num / 2.0);
                            }

                            if (eqp.MiscString == "PowerRange") {
                                num = Math.Floor(num * 0.8);
                            }
                        }

                        count += num;
                    }
                }
            }

            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item eqp && eqp.MiscString == "OmniBoost") {
                    count += eqp.EquipTier;
                }
            }

            count /= 5.0;



            return (int) Math.Ceiling(count);
        }


        public bool IsMaging() {
            if (CombatCasting == null)
                return false;
            if (!Skills.ContainsKey("Magic"))
                return false;

            int spellLevel = CombatCasting.Tier == 1 ? 1 : CombatCasting.Tier * 10;
            if (spellLevel > GetEffectiveSkillLevel("Magic"))
                return false;

            if (!HasAllItems(CombatCasting.Talismans(), false, true))
                return false;

            return true;
        }

        public string CanCast(SpellCombat spell) {
            int level = spell.Tier == 1 ? 1 : spell.Tier * 10;
            if (!Skills.ContainsKey("Magic"))
                return "Malformed skill list, Magic entry not found."; 
            if (level > Skills["Magic"].Level)
                return "Need " + level + " Magic to cast, only have " + Skills["Magic"].Level + ".";

            List<string> tali = spell.Talismans();
            if (!HasAllItems(spell.Talismans(), false, true)) {
                string items = "";

                for (int i = 0; i < tali.Count; i++) {
                    string[] rune = tali[i].Split(",");
                    int qty = 0;

                    if (int.TryParse(rune[1], out qty)) {
                        if (i != 0)
                            items += ", ";
                        items += qty + "x " + GameLoop.WTN.ResolveItemName(rune[0]); 
                    } 
                }

                return "Missing talismans, need " + items + ".";
            }

            return "";
        }

        public string CanCast(Spell spell) {
            if (!Skills.ContainsKey("Magic"))
                return "Malformed skill list, Magic entry not found.";
            if (spell.Book != MagicBook)
                return "Incorrect spellbook active.";
            if (spell.Level > Skills["Magic"].Level)
                return "Need " + spell.Level + " Magic to cast that spell, only have " + Skills["Magic"].Level + ".";
            if (!HasAllItems(spell.Runes, false, true) && !HasAllItems(["tab" + spell.ID])) {
                string items = "";

                for (int i = 0; i < spell.Runes.Count; i++) {
                    string[] rune = spell.Runes[i].Split(",");
                    int qty = 0;

                    if (int.TryParse(rune[1], out qty)) {
                        if (i != 0)
                            items += ", ";
                        items += qty + "x " + GameLoop.WTN.ResolveItemName(rune[0]); 
                    } 
                }

                return "Missing runes, need " + items + ".";
            }

            if (spell.TimeLastCast != 0 && spell.TimeLastCast + spell.CooldownInMS > Helper.Time()) {
                int timeLeft = (int) (((spell.TimeLastCast + spell.CooldownInMS) - Helper.Time()) / 1000);
                if (timeLeft > 60) {
                    int minutes = timeLeft / 60;
                    int seconds = timeLeft % 60;
                    return "On cooldown, " + minutes + "m " + seconds + "s remaining.";
                } else {
                    return "On cooldown, " + timeLeft + " seconds remaining.";
                }
            }

            for (int i = 0; i < spell.ToCast.Count; i++) {
                if (!spell.ToCast[i].CheckRequirement(this, false)) {
                    return "Missing Requirement: " + spell.ToCast[i].GetSummary();
                }
            }

            return "";
        }

        public void TryAddPotionEffect(string stat, int change) {
            bool found = false;
            for (int j = 0; j < ActivePotions.Count; j++) {
                if (ActivePotions[j].Stat == stat) {
                    if (ActivePotions[j].Change < 0) {
                        ActivePotions[j].Change += change;
                        found = true;
                    } else {
                        if (ActivePotions[j].Change < change) {
                            ActivePotions[j].Change = change;
                            found = true;
                        }
                    }
                }
            }
            if (!found)
                ActivePotions.Add(new(stat, change));
        }

        public int PotionStatus(string stat) {
            foreach (var pot in ActivePotions) {
                if (pot.Stat == stat) {
                    return pot.Change;
                }
            }

            return 0;
        }

        public bool HasLightSource() {
            foreach (var kv in Inventory) {
                if (kv.GetRef() is Item item) {
                    if (item.ProvidesLight) { return true; }
                }
            }

            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item eqp) {
                    if (eqp.ProvidesLight) { return true; }
                }
            }

            return false;
        }

        public bool HasOpenFlame() {
            foreach (var kv in Inventory) {
                if (kv.GetRef() is Item item) {
                    if (item.ExposedFlame) { return true; }
                }
            }

            foreach (var kv in Equipment) {
                if (kv.Value.GetRef() is Item eqp) {
                    if (eqp.ExposedFlame) { return true; }
                }
            }

            return false;
        }

        public void ExtinguishLights(bool coveredToo) {
            foreach (var kv in Inventory) {
                if (kv.GetRef() is Item item) {
                    if (item.Name.Contains("(lit)") && (item.ExposedFlame || (!item.ExposedFlame && coveredToo)) && item.UseString != "" && GameLoop.WTN.ItemLibrary.ContainsKey(item.UseString2)) {
                        kv.ID = item.UseString2;
                        GameLoop.WTN.Log.AddMessage("Your " + GameLoop.WTN.ResolveItemName(kv.ID) + " is extinguished!");
                    }
                }
            }
        }

        public void TakeGold(int amount) {
            int qtyLeft = amount;
            if (CoinPouch && HeldGold >= qtyLeft) { HeldGold -= qtyLeft; qtyLeft = 0; } 
            if (qtyLeft > 0 && CoinPouch) { qtyLeft -= HeldGold; HeldGold = 0; } 
            if (qtyLeft > 0) { ConsumeItems(["coins," + qtyLeft]); }
        }

        public void GiveGold(int amount) {
            if (CoinPouch) { HeldGold += amount; }
            else {
                if (GameLoop.WTN.ResolveItem("coins") is Item coin) {
                    TryPickup(new Item(coin), amount);
                }
            }
        }

        public int GoldTotal() {
            int total = 0;

            if (CoinPouch) { total += HeldGold; }

            foreach (var kv in Inventory) {
                if (kv.ID == "coins") { total += kv.Quantity; }
                if (kv.Containing.Count > 0) {
                    foreach (var con in kv.Containing) {
                        if (con.ID == "coins") { total += con.Quantity; }
                    }
                }
            }

            foreach (var kv in Equipment) {
                if (kv.Value.ID == "coins") { total += kv.Value.Quantity; }
                if (kv.Value.Containing.Count > 0) {
                    foreach (var con in kv.Value.Containing) {
                        if (con.ID == "coins") { total += con.Quantity; }
                    }
                }
            }

            return total;
        }

        public void TrySetQuest(string ID, int stage) {
            if (GameLoop.WTN.QuestLibrary.TryGetValue(ID, out Quest? quest)) {
                if (QuestLog.TryGetValue(ID, out QuestStatus? status)) {
                    if (status.CurrentStage < stage) {
                        status.CurrentStage = stage;
                        if (status.CurrentStage == quest.CompleteStage) { 
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You have completed " + quest.Name + "!", Color.Lime, Color.Black));
                            quest.ProcessRewards(this);
                        }

                        if (status.CurrentStage == 0) {
                            GameLoop.WTN.Log.AddMessage(new ColoredString("You have started the quest: " + quest.Name + ".", Color.Yellow, Color.Black));
                        }
                    }
                }
            }
        }  

        public void TryProgressQuest(string method, string thing) {
            foreach (var quest in GameLoop.WTN.QuestLibrary) {
                if (QuestLog.TryGetValue(quest.Key, out QuestStatus? status)) {
                    if (status.CurrentStage != quest.Value.CompleteStage && quest.Value.Stages.ContainsKey(status.CurrentStage)) {
                        if (quest.Value.Stages[status.CurrentStage].ProgressType == method && quest.Value.Stages[status.CurrentStage].MiscString == thing) {
                            status.NumTracker++;

                            if (status.NumTracker >= quest.Value.Stages[status.CurrentStage].MiscInt) {
                                status.CurrentStage = quest.Value.Stages[status.CurrentStage].LeadsToStage;
                                status.NumTracker = 0; 

                                if (status.CurrentStage == quest.Value.CompleteStage) {
                                    GameLoop.WTN.Log.AddMessage(new ColoredString("You have completed " + quest.Value.Name + "!", Color.Lime, Color.Black));
                                    quest.Value.ProcessRewards(GameLoop.WTN.player);
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool QuestCompleted(string id) {
            if (GameLoop.WTN.QuestLibrary.TryGetValue(id, out Quest? quest)) {
                if (QuestLog.TryGetValue(id, out QuestStatus? status)) {
                    if (status.CurrentStage == quest.CompleteStage) {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetQuestPoints(bool total = false) { 
            int questPoints = 0;
            int totalPossibleQP = 0; 

            foreach (var kv in GameLoop.WTN.QuestLibrary) {
                totalPossibleQP += kv.Value.QuestPoints;
                if (kv.Value.CurrentStage() == kv.Value.CompleteStage)
                    questPoints += kv.Value.QuestPoints;
            }

            return total ? totalPossibleQP : questPoints;
        }

        public string GetRegion() {
            if (GameLoop.WTN.Atlas.TryGetValue(NavLoc, out Location? curr) && curr != null) {
                return curr.Region;
            }

            return "ERROR";
        }

        public int GetSkillTier(string skill, bool effective = false) {
            if (effective) {
                int eff = GetEffectiveSkillLevel(skill);

                return (int) (Math.Floor(eff / 10.0) + 1);
            } else if (Skills.ContainsKey(skill)) {
                return (int) (Math.Floor(Skills[skill].Level / 10.0) + 1);
            }

            return 1;
        }

        public int ItemHeldCount(string id, bool noted, bool equipped, bool onlyEquipped) {
            int held = 0;

            if (!onlyEquipped) {
                foreach (var kv in Inventory) {
                    if (kv.ID == id && (!kv.Noted || noted)) {
                        held += kv.Quantity;
                    }
                }
            }

            if (equipped) {
                foreach (var kv in Equipment) {
                    if (kv.Value.ID == id) {
                        held += kv.Value.Quantity;
                    }
                }
            }

            return held;
        }
        

        public int GetMaxPrayer() {
            return 10 * GetEffectiveSkillLevel("Prayer");
        }

        public int GetPrayerBonus() {
            double bonus = 0;

            foreach (var eqpWrap in Equipment) {
                if (eqpWrap.Value.GetRef() is Item eqp) {
                    if (eqp.MiscString == "PrayerBonus") {
                        bonus += eqp.EquipTier;
                    }
                }
            }

            return (int) Math.Ceiling(bonus);
        }

        public CombatSim GetSimBlock(string attackType) {
            return new CombatSim(GetEffectiveSkillLevel("Hitpoints"), GetEffectiveSkillLevel("Attack"), GetEffectiveSkillLevel("Defense"), MaxDamage(), GetDamageType(), GetDamageElement(), GetAttackSpeed(), TotalArmorValue(attackType), "", ElementalAttunement);
        }

        public bool Safespotting(string dmgType, bool inaccessible = false) {
            if (dmgType != "Melee") { return false; }

            if (Equipment.TryGetValue("Weapon", out ItemWrapper? weaponWrap) && weaponWrap.GetRef() is Item wep2) {
                if (wep2.EquipSkill == "Ranged") { return true; }
            }

            if (IsMaging()) { return true; } 
            if (inaccessible) { return true; }

            return false;
        }

        public void GainCombatExp(int dmg, bool reachedKillLimit = false, bool usedAmmo = false) {
            if (IsMaging() && CombatCasting != null && !reachedKillLimit) {  
                TryGrantExp("Magic", (dmg * 4), GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);

                string cast = CanCast(CombatCasting);
                if (cast != "") { 
                    GameLoop.WTN.Log.AddMessage(new ColoredString("Cannot cast spell anymore: " + cast, Color.Crimson, Color.Black)); 
                    CombatCasting = null;
                }
            } else if (usedAmmo && !reachedKillLimit) { 
                TryGrantExp("Ranged", dmg * 4, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
            } else {
                if (OffenseExpSplit > 0 && !reachedKillLimit)
                    TryGrantExp("Attack", dmg * OffenseExpSplit, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);

                if (OffenseExpSplit < 4 && !reachedKillLimit)
                    TryGrantExp("Strength", dmg * (4 - OffenseExpSplit), GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
            }

            if (DefenseExpSplit > 0 && !reachedKillLimit)
                TryGrantExp("Defense", dmg * DefenseExpSplit, GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);

            if (DefenseExpSplit < 4 && !reachedKillLimit)
                TryGrantExp("Hitpoints", dmg * (4 - DefenseExpSplit), GameLoop.WTN.Log, SidebarManager.RecentlyTrainedSkills);
        }

        public int UseRangedAmmo(bool inaccessible = false) { // 1 = has ammo and used some, -1 = needs ammo but didn't have, 0 = no ammo required so probably not ranged
            if (Equipment.TryGetValue("Weapon", out ItemWrapper? wepWrap) && wepWrap != null && wepWrap.GetRef() is Item weapon) {
                if (weapon.EquipAmmo == "Self") {
                    wepWrap.Quantity -= 1;
                    Item droppedAmmo = new(weapon) { Quantity = 1 }; 
                    if (GameLoop.rand.Next(4) != 0)
                        GameLoop.WTN.TryPlaceItem(NavLoc, new(droppedAmmo, inaccessible));
                    return 1;
                } else if (weapon.EquipAmmo == "Chargebow") {
                    return 1;
                } else if (weapon.EquipAmmo == "RangedStandard") {
                    if (Equipment.TryGetValue("Ammo", out ItemWrapper? arrowWrap) && arrowWrap.GetRef() is Item arrow && arrow.EquipDamageType == "RangedStandard") {
                        arrowWrap.Quantity -= 1;
                        Item droppedAmmo = new(arrow) { Quantity = 1 }; 
                        if (GameLoop.rand.Next(4) != 0)
                            GameLoop.WTN.TryPlaceItem(NavLoc, new(droppedAmmo, inaccessible));
                        return 1;
                    } else {
                        return -1;
                    }
                } else if (weapon.EquipAmmo == "RangedHeavy") {
                    if (Equipment.TryGetValue("Ammo", out ItemWrapper? boltWrap) && boltWrap.GetRef() is Item bolt && bolt.EquipDamageType == "RangedHeavy") {
                        boltWrap.Quantity -= 1;
                        Item droppedAmmo = new(bolt) { Quantity = 1 }; 
                        if (GameLoop.rand.Next(4) != 0)
                            GameLoop.WTN.TryPlaceItem(NavLoc, new(droppedAmmo, inaccessible));
                        return 1;
                    } else {
                        return -1;
                    }
                }
            }

            return 0;
        }
    }
}
