using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsPets {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
            
            // Boss pets
            itemsToAdd.Add(new Item("Baby zombie plush", "Despite being a zombie, kinda cute? It even has a little chicken that it's riding on.", "petBabyZombie", 34, 140, 34, 1000, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "The baby zombie gurgles a bit.", "The zombie's chicken clucks loudly.", "The baby zombie runs in a small circle quickly.", "CHICKEN JOCKEY!" ]
            });

            // Skill pets 
            //itemsToAdd.Add(new Item("", "", "petSkillTemplate", Color.BurlyWood, 0, trade: false) {
            //    EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            //});

            itemsToAdd.Add(new Item("", "", "petSkillAgility", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("Mixie", "A sentient floating vial of questionable bubbling liquid.", "petSkillAlchemy", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Mixie's liquid turns red and bubbles ominously.", "Mixie's liquid didn't match a potion recipe and now she has to start over.", "Mixie says, 'don't drink random potions!'", "Mixie says, 'baingani and minnow scales!'" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillAttack", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillConstruction", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillCooking", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillCrafting", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillDefense", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillHitpoints", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillFarming", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillFishing", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillFletching", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillMagic", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillMining", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillPrayer", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillRanged", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillSmithing", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillStrength", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("", "", "petSkillThieving", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "", "", "", "" ]
            });

            itemsToAdd.Add(new Item("Hatchet-chan", "A floating steel axe with big anime eyes. She is very kawaii desu ne.", "petSkillWoodcutting", ColorLib.Steel, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Hatchet-chan squeals in delight. It is very grating.", "Hatchet-chan's heart goes doaki-doaki.", "Hatchet-chan pretends to ignore you while actually desiring your attention.", "Hatchet-chan says, 'don't swing me so hard, balsa!'" ]
            });


            // Regular cats
            itemsToAdd.Add(new Item("Kitten (black)", "A friendly little pet.", "kittenBlack", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (gray)", "A friendly little pet.", "kittenGray", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (white)", "A friendly little pet.", "kittenWhite", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (orange)", "A friendly little pet.", "kittenOrange", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (brown)", "A friendly little pet.", "kittenBrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten", "A friendly little pet.", "kittenCalico", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (black)", "A fully grown feline.", "catBlack", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (gray)", "A fully grown feline.", "catGray", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (white)", "A fully grown feline.", "catWhite", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (orange)", "A fully grown feline.", "catOrange", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (brown)", "A fully grown feline.", "catBrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat", "A fully grown feline.", "catCalico", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            });

            itemsToAdd.Add(new Item("Overgrown cat (black)", "A friendly not-so little pet.", "catBlackOvergrown", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (gray)", "A friendly not-so little pet.", "catGrayOvergrown", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (white)", "A friendly not-so little pet.", "catWhiteOvergrown", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (orange)", "A friendly not-so little pet.", "catOrangeOvergrown", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (brown)", "A friendly not-so little pet.", "catBrownOvergrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat", "A friendly not-so little pet.", "catCalicoOvergrown", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = [ "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."],
                UseString = "CatMenu", ConsumedOnUse = false
            });

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
