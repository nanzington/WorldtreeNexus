using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedItemsPets {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();
            
            // Boss pets
            itemsToAdd.Add(new Item("Baby zombie plush", "Despite being a zombie, kinda cute? It even has a little chicken that it's riding on.", "petBabyZombie", 34, 140, 34, 1000, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "The baby zombie gurgles a bit.", "The zombie's chicken clucks loudly.", "The baby zombie runs in a small circle quickly.", "CHICKEN JOCKEY!"}
            });

            // Skill pets 
            itemsToAdd.Add(new Item("Woody", "A small wooden golem with an unoriginal name.", "petSkillWoodcutting", Color.BurlyWood, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Woody tells a lie and his nose grows slightly longer.", "Woody tells a truth and his nose grows slightly shorter. You don't think it's supposed to work like that, but don't question it.", "Woody says, 'got wood?'.", "Woody says, 'what type of tree fits in your hand? A PALM tree!'."}
            });


            // Regular cats
            itemsToAdd.Add(new Item("Kitten (black)", "A friendly little pet.", "kittenBlack", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (gray)", "A friendly little pet.", "kittenGray", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (white)", "A friendly little pet.", "kittenWhite", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (orange)", "A friendly little pet.", "kittenOrange", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten (brown)", "A friendly little pet.", "kittenBrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Kitten", "A friendly little pet.", "kittenCalico", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your kitten purrs.", "Your kitten meows.", "Your kitten rolls around on the ground.", "Your kitten stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (black)", "A fully grown feline.", "catBlack", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (gray)", "A fully grown feline.", "catGray", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (white)", "A fully grown feline.", "catWhite", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (orange)", "A fully grown feline.", "catOrange", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat (brown)", "A fully grown feline.", "catBrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Cat", "A fully grown feline.", "catCalico", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your cat purrs.", "Your cat meows.", "Your cat rolls around on the ground.", "Your cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            });

            itemsToAdd.Add(new Item("Overgrown cat (black)", "A friendly not-so little pet.", "catBlackOvergrown", Color.DimGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (gray)", "A friendly not-so little pet.", "catGrayOvergrown", Color.DarkGray, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (white)", "A friendly not-so little pet.", "catWhiteOvergrown", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (orange)", "A friendly not-so little pet.", "catOrangeOvergrown", Color.Orange, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat (brown)", "A friendly not-so little pet.", "catBrownOvergrown", Color.SaddleBrown, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            }); 

            itemsToAdd.Add(new Item("Overgrown cat", "A friendly not-so little pet.", "catCalicoOvergrown", Color.White, 0, trade: false) {
                EquipSlot = "Pet",  Cosmetic = true, PetBlurbs = new() { "Your overgrown cat purrs.", "Your overgrown cat meows.", "Your overgrown cat rolls around on the ground.", "Your overgrown cat stares at a point in space intently."},
                UseString = "CatMenu", ConsumedOnUse = false
            });

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
