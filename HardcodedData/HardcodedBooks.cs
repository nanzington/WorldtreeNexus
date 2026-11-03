using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class HardcodedBooks {
        public static void InitBooks(Dictionary<string, Book> BookLib) {
            List<Book> toAdd = new();

            toAdd.Add(new("Construction Guidebook", "bookConstructionGuide", 1, new() {
                new("Buying a House", "To buy a house, speak to any Estate Agent. They can typically be found in a large city in each region, such as Varrock, with one Agent per region. /n /n You can speak with an agent about purchasing a home in their region. This will cost a variable amount of gold, and the house will be located in the place they specify. You may buy any number of homes, but only have an amount equal to your construction tier active."),
                new("Material Tiers", "Materials used for construction are typically tiered, and things require materials based on the level needed to build them. /n /n  1 -  9: Poplar, Copper /n 10 - 19: Elm, Bronze /n 20 - 29: Walnut, Iron /n 30 - 39: Holly, Silver /n 40 - 49: Acacia, Gold /n 50 - 59: Birch, Platinum /n 60 - 69: Hickory, Steel /n 70 - 79: Bloodwood, Cobalt /n 80 - 89: Camatillo, Tungsten /n 90 - 99: Katalox, Titanium"),
                new("How to Build", "Take a saw, hammer, and some planks and nails to your new home. /n /n In the home, view the Minigame tab (*) on the right. You can click (BUILD) to enter or leave building mode. The Room Management option allows you to add or remove rooms, though you can only have rooms equal to your Construction tier in each house. The object menu lets you add and remove objects in the room you're standing in."),
                new("Buildable Objects", "In the Objects menu, there is a list of currently built objects and empty hotspots. /n /n With materials in hand, click an empty hotspot to view a list of things you can build there, then click what you would like to build. The ? allows you to view the requirements and materials to build each object. /n /n You will receive bonus experience for filling all hotspots."),
                new("Teleporting to Houses", "If you have at least 40 Magic and the appropriate runes, you can teleport to any owned house that is currently active and has a Teleportation Focus built in the Parlour or Portal Chamber. /n /n You may choose which houses are active by speaking to any Estate Agent."),
                new("Comfort Level", "Houses have a comfort level, typically raised by constructing objects that are purely decorative. The higher tier of materials used, the more comfort you it gives. /n /n Once you can build a bedroom, you can sleep in the bed every hour of play to become Well Rested for 30 minutes. This increases the benefit you gain from potions, giving a larger bonus if the house has high comfort."),
                new("Parlor", "A sitting room, primarily useful for raising the comfort level of the house as nearly all the buildable objects are decorative. /n /n A teleportation focus can also be built here, allowing you to teleport to the home."),
                new("Garden", "A small garden you can plant things in. /n /n You can 'build' bushes of plants such as blueberry to gather them in your home, trees that can be chopped for wood, and a single farm plot to plant seeds in. The plot hotspot can alternatively contain a sand pit or clay deposit to gather those resources."),
                new("Kitchen", "No home is complete without a kitchen! /n /n Allows you to cook food, having a hotspot for ranges and sinks. /n /n The larder and shelves also give you an unlimited supply of some specific items, higher tiers providing more items."),
                new("Dining Room", "A place for guests to eat. /n /n Mostly useful to boost comfort, as all items are decorative."),
                new("Workshop", "A place for artisanry. /n /n The hotspots allow you to customize the workshop to your liking to focus on the skills you prefer. This includes an anvil and furnace, a spinning wheel, a pottery wheel and kiln, and a few more options."),
                new("Bedroom", "A place for sleeping. /n /n As mentioned previously a bed allows you to become Well Rested based on the comfort of the house, otherwise the things in this room are decorative and simply increase comfort."),
                new("Study", "A sort of magical workshop / research room. /n /n A number of the facilities here are quite useful. Telescopes allow you to locate crashed stars to mine, crystal balls can change the element of elemental staves, and lecterns allow you to create spell tablets that replace the runes for their corresponding spell."),
                new("Portal Chamber", "A chamber with portals in it. Helpful, I know. /n /n You can build up to three portals in each Chamber, allowing you to teleport to any place a spell could teleport you without the need for runes. /n /n Each portal costs some materials for the frame, plus runes equivalent to 100 casts of the spell.")
            }));

            toAdd.Add(new("Sleeping Potion Ingredients", "potionSleepingList", 0, new() {
                new("!! ONLY FOR TRUE LOVE !!", "Ingredients for death sleeping draught: /n /n Nightshade Berries /n Vial of Water /n Wing of Rat /n Tail of Frog /n Ear of Snake /n Horn of Dog /n /n Use the berries on the vial, then activate the vial to mix everything else in at once."),
            }));

            toAdd.Add(new("Letter for Juliet", "letterRomeo", 0, new() {
                new("From Romeo", "My sweet dearest Juliet, /n /n     I am breathless without you. /n     Our families may feud, but my heart burns only of the passion for thee. /n     Every moment you are near me my soul is set alight. /n     Please, you must tell me how you feel by the morrow. /n     I cannot bear to live another day without knowing how you feel. /n /n Forever for you, Romeo."),
            }));

            toAdd.Add(new("Letter for Romeo", "letterJuliet", 0, new() {
                new("From Juliet", "My gentle Romeo, /n /n My heart burns there too. /n /n Meet me under my veranda in the moonlight, tonight. /n /n I will wait for thee. /n /n /n /n /n /n /n /n Your, Juliet."),
            }));

            toAdd.Add(new("Intro to Alchemy", "alchemyBooklet", 1, new() {
                new("Introduction", "Alchemy is a deep and complicated art. Potions should nearly all have a 'perfect' recipe - two ingredients combined in a vial then heated with no other tools necessary - to create them. /n /n That said, an array of tools exist that will allow the determined apothecary to find new paths to recipes. /n /n Possibly with cheaper ingredients or lower level requirements!"),
                new("Basic Concepts", "Anything that can be used as an ingredient has four values: Red, Black, Yellow, White. /n /n Every potion recipe has those same four values. /n /n Creating a potion is as simple as mixing ingredients and using tools until the mixture values match the values of a recipe. /n /n Note that some recipes may require specific ingredients or actions to succeed."),
                new("Limits of Alchemy", "Your 'Alchemy Tier' is equal to your Alchemy level, divided by 10, rounded down, plus one. In other words, tier 1 from level 1 to 9, tier 2 from 10 to 19, tier 3 from 20 to 29, up to tier 11 at level 100. /n /n Each mixture can contain at most (tier plus one) ingredients, and manipulated with (tier) actions from tools."),
                new("Tools I", "Brazier: Heats mixtures to finish them. The most important tool, as Alchemy cannot be done without it. /n /n Loupe: While in your inventory, allows you to see the RBYW values of any items with them. /n /n Pestle and Mortar: Grind some items into usable alchemical ingredients."),
                new("Tools II", "Retort: +1 Red, -1 Black /n /n Alembic: +1 Black, -1 Yellow /n /n Crucible: +1 Yellow, -1 White /n /n Aludel: +1 White, -1 Red /n /n Inverter: Invert polarity of all colors /n /n Water Vial / Mixture: Becomes a copy of the mixture. Both have each color set to the average of their combined value, rounded to zero. Water counts as 0 in all colors."),
                new("Tools III", "Calcinator: All colors move one step towards zero /n /n Swizzler: Average all colors, rounded towards zero, maintaining polarity, neutrals become positive /n /n Agitator: Shift colors one slot right (Red -> Black -> Yellow -> White -> Red) /n /n Deagitator: Shift colors one slot left (Red <- Black <- Yellow <- White <- Red)"),
                new("Low Level Herbs", "   Neela -5,  1, -6,  3. Lv1 /n " +
                                       "  Midori -4, -3,  3,  5. Lv1 /n /n " +
                                       "   Nimbu -2,  2,  6,  4. Lv10 /n " +
                                       "   Kiiro  2, -3, -5, -4. Lv10 /n /n " +
                                       "Baingani  4, -1,  6,  2. Lv20 /n " +
                                       "Murasaki -1, -3,  2, -7. Lv20 /n /n " +
                                       "     Lal  1, -3, -2,  6. Lv30 /n " +
                                       "  Mazent  2, -4, -3,  3. Lv30 /n /n " +
                                       "    Hara -1,  3,  3,  4. Lv40 /n " +
                                       " Kuriiro -3, -5, -2,  1. Lv40 /n /n " +
                                       "  Gulabi  4,  1,  2,  3. Lv50 /n " +
                                       "    Kusa -2,  2, -2,  4. Lv50"),
                 new("Wood Ashes",  "Poplar -4,  6, -6,  6. Lv1 /n " +
                                    "   Elm  0, -6, -8,  6. Lv10 /n  " +
                                    "Walnut 12,  0,  0, -6. Lv20 /n " +
                                    " Holly  2, -4,  8,  2. Lv30 /n " +
                                    "Acacia  0, -8,  4, -2. Lv40 /n " +
                                    " Birch -6,  2,  0,  4. Lv50 /n "),
                new("Other Ingredients - Level 1","  Eye of Cuy  4,  4, -8,  6 /n " +
                                                  "Ground Bones  6, -6,  6,  4 /n "),
            }));

            toAdd.Add(new("Recipe (Attack Potion)", "alchemyRecipeAttack", 0, new() {
                new("", "Acquire a vial of water, an eye of cuy, and a clean neela. /n /n Add the eye of cuy and the neela to the vial. /n /n Apply heat to create an attack potion."),
            }));

            toAdd.Add(new("Papermakers Pamphlet", "bookPapermaker", 0, new() {
                new("", "Acquire logs of the kind of paper you wish to make. /n /n Fletch them into wood chips with a knife. /n /n Burn any other log for wood ash, then add it to a pot of water to make lye. /n /n Add the wood chips to the pot of lye, then heat on a fire or range to get wood pulp. /n /n Use the pulp on a paper mould for two sheets of paper, or Activate (*) for one sheet."),
            }));

            toAdd.Add(new("List of Items", "qListTutorial", 1, new() {
                new("", "Collect the following items, then take them to Wizard Atrel in his hut to finish the quest. /n /n Copper bar /n Illusion talisman /n Attack potion /n Cleansed bones /n Small coin pouch /n Poplar shortbow /n Cozy Cottages teleport /n Fish and Chips"),
                new("", "/n /n /n /n /n Want additional assistance for how to get each item? /n /n Flip to the next page using the bottom at the bottom of this page!"),
                new("", "Copper bar /n /n Smelt a copper ore at a furnace to make copper bars. Copper ore can be mined in the Cavern, if you have a pickaxe. /n /n /n Illusion talisman /n /n Acquire novice ink and poplar paper, then activate the ink to draw on the paper. Speak to Talisman Guy for more information."),
                new("", "Attack potion /n /n Combine a clean neela with a cuy eye in a vial of water, then heat it with an alchemist's brazier. Speak to Talisman Guy for more information about Alchemy. /n /n /n Cleansed bones /n /n Get bones by killing anything but the rat in the starting hut (chicken may be easiest). Clean them with the Holy Fountain in the Temple."),
                new("", "Small coin pouch /n /n Successfully pickpocket Dodgy Ranger Guy by clicking the P to the right of his name in the NPC menu. /n /n /n Poplar shortbow /n /n Fletch a poplar log into a shortbow (u) with a knife, spin a piece of flax into a bowstring at a Spinning Wheel, then use the string on the unstrung bow."),
                new("", "Cozy Cottages teleport /n /n Complete two Cozy Cottages contracts, then buy in the Reward shop. Speak to the Estate Agent in the Bank to learn about how to do that."),
                new("", "Fish and Chips /n /n Grow a potato, cut it into slices with a knife and then the slices into sticks. /n /n Catch a pollock, fillet it with a knife, batter it with egg and flour, then deep fry the potato sticks and the battered pollock in the Kitchen. Use on eachother to combine into Fish and Chips."),
            }));

            toAdd.Add(new("The Daily Sprout - Issue #0 (10-30-2026)", "patchNotes0", 2, new() {
                new("", "Prim's Primers /n /n /n Your guide to the multiverse!"),
                new("", "Sneed's Feed and Seed /n /n Need feed? /n Get seed!"),
                new("", "Crossroads Inn /n /n Grab a drink where all paths meet!"), 
                new("Worldtree Welcomes You!", "New people from the multiverse appear on the Worldtree each day as more worlds become interconnected by its' branches. /n /n We at the Daily Sprout are happy to welcome our latest neighbors, the residents of Everafter! A land of whimsy and fairytales made real. Give it a visit when you have time!"),
                new("", "Cult of the Tree recieves official recognition and allowed to open a temple in the Nexus."),
                new("", "Cozener's Casino reports high profits in opening week as gamblers from across the multiverse flock to their tables."),
            }));

            for (int i = 0; i < toAdd.Count; i++) {
                BookLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
