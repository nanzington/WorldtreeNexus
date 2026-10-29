using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class TutorialNPCs {
        public static void InitNPCs(Dictionary<string, NPC> NPCLib) {
            DialogueChoice byeThen = new("Goodbye", -1); 
            List<NPC> toAdd = new();

            toAdd.Add(new("Tutorial Guy", "guyTutorial", new() {
                { 0, new("Why, hello there! First time around these parts? Or perhaps a returning visitor? Either way, feel free to ask some questions.", new() { 
                    new("Where am I?", 1),
                    new("What do all these buttons do?", 5),
                    byeThen 
                }) }, 
                { 1, new("You have entered the Worldtree Nexus, a series of interconnected worlds full of denizens, adventures, and sights to see!", new() { new("(NEXT)", 2), byeThen }) },
                { 2, new("More specifically you are currently on Tutorial Island. This connection between this world and the Worldtree is... tenuous.", new() { new("(NEXT)", 3), byeThen }) },
                { 3, new("Once you leave the island for the rest of the Worldtree, you will not be able to return here in this life.", new() { new("(NEXT)", 4), byeThen }) },
                { 4, new("In the meantime enjoy the relaxed pace of life here. Spend some time learning how things are done.", new() { new("(BACK)", 0, silent: true), byeThen }) },
                { 5, new("Oh my, what a question! This is quite a complex topic, so I'll break it up a bit. Which part would you like to talk about?", new() { new("Top Left", 10), new("Middle Left", 20), new("Top Right", 0), new("Middle Right", 0), new("Center", 0), new("Bottom", 0), byeThen }) },
                // Talk about upper left of sidebar
                { 10, new("The top left box shows some important information constantly. At the top in white is the date and time. Click it to toggle 12 hour time.", new() { new("(NEXT)", 11), byeThen }) },
                { 11, new("Under that in red is your current and maximum hitpoints. If you drop to zero, you'll die and respawn back at the Worldtree Plaza.", new() { new("(NEXT)", 12), byeThen }) },
                { 12, new("Next in blue is your current prayer points. Your max points are equal to your Prayer level multiplied by ten.", new() { new("(NEXT)", 13), byeThen }) },
                { 13, new("Below that in yellow is your combat stats. Your combat level mostly just stops some monsters from being aggressive.", new() { new("(NEXT)", 14), byeThen }) },
                { 14, new("Max hit is determined by your weapon, spell, or ammo tier and related skill levels. Combat Guy can tell you more about that.", new() { new("(NEXT)", 15), byeThen }) },
                { 15, new("Finally the DR numbers are your Damage Reduction. Wear better armor, take less damage. Again, Combat Guy in the Cavern.", new() { new("(NEXT)", 16), byeThen }) },
                { 16, new("Farther down and not currently visible is a display of what combat spell you're casting, and then your gold pouch at the bottom.", new() { new("(NEXT)", 17), byeThen }) },
                { 17, new("The last thing of interest in this area is the Recently Trained Skills log, which shows the skills you have recently trained.", new() { new("(BACK)", 5, silent: true), byeThen }) },
                // Talk about middle left of sidebar
                { 20, new("The middle-left area of the window is your sidebar menu, split into tabs based on function. You can click a tab to switch to it.", new() { new("(NEXT)", 21), byeThen }) },
                { 21, new("INV, or Inventory, shows the items you are currently carrying with you. They are listed by name, with buttons at the end of each line.", new() { new("(NEXT)", 22), byeThen }) },
                { 22, new("E equips an item, if applicable. U allows you to use one item on another to try to combine them. > lets you swap two items to organize. The *, if it appears, allows you to activate an item for some kind of effect that varies based on the item.", new() { new("(NEXT)", 23), byeThen }) },
                { 23, new("? lets you examine an item to get some information about it, and X drops the item. If at a bank the item is stored, otherwise it falls to the ground. Unbanked items on the ground are permanently lost when the game is restarted!", new() { new("(NEXT)", 24), byeThen }) },
                { 24, new("EQP, or Equipment, shows items you are currently wearing and allows you to unequip them via clicking the equipped item.", new() { new("(NEXT)", 25), byeThen }) },
                { 25, new("Additionally your combat experience split is here. For every point of damage you deal, you gain 4 offense experience and 4 defense experience.", new() { new("(NEXT)", 26), byeThen }) },
                { 26, new("The offense experience is split as desired between Attack and Strength if Melee, while you get the full 4 to Ranged or Magic if using those.", new() { new("(NEXT)", 27), byeThen }) },
                { 27, new("The defense experience is split between Defense and Hitpoints, and gained regardless of style used to attack.", new() { new("(NEXT)", 28), byeThen }) },
                { 28, new("SKL, or Skills, displays your current level with each skill along with your experience total, and the experience needed to level it up.", new() { new("(NEXT)", 29), byeThen }) },
                { 29, new("You may click the skill names to open the Compendium to the skills page, which attempts to show all uses for the skill sorted by level.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("MAG, or Magic, shows all spells in your currently active spellbook. Each displays the level required and has a ? to get more information.", new() { new("(NEXT)", 31), byeThen }) },
                { 31, new("Spells are split into Combat, Teleports, and Utility. Combat spells are selected and then autocast when you fight monsters.", new() { new("(NEXT)", 32), byeThen }) },
                { 32, new("Teleport spells move you to the specified destination, and Utility spells generally assist with skilling in some way.", new() { new("(NEXT)", 33), byeThen }) },
                { 33, new("PRA, or Prayer, shows the list of Prayers you can activate for various bonuses at the cost of draining Prayer Points over time.", new() { new("(BACK)", 5, silent: true), byeThen }) }
            }));

            toAdd.Add(new("Father Guy", "guyFather", new() {
                { 0, new("Welcome, child. Blessings of the Worldtree upon you.", new() { byeThen }) }
            }));

            toAdd.Add(new("Fishing Guy", "guyFishing", new() {
                { 0, new("Just click tha spot you want to fish at ta fish. 'That's all there is to it!', now leave me be. There's fishin' ta be done.", new() { new("Could I have a rod?", 1), byeThen }) }, 
                { 1, new("(The old man grumbles about kids these days but hands over a poplar fishing rod. Wait, is that a fake beard? It looked like it slipped for a second...)", new() { byeThen }, items: ["rodPoplar"], altSpeaker: "-") }
            }));

            toAdd.Add(new("Banking Guy", "guyBanking", new() {
                { 0, new("Welcome to the First National Bank of Tutorial Island! How can I help you today?", new() {
                        new("How do I use the bank?", 1),
                        byeThen
                }) },
                { 1, new("If you are permitted to use banks, simply drop items in a bank and we'll put them into your vault.", new() { new("(NEXT)", 2), byeThen }) },
                { 2, new("Items in your bank can be accessed at any bank location in the Items menu. That's all there is to it!", new() { byeThen }) },
            })); 

            toAdd.Add(new("Smithing Guy", "guySmithing", new() {
                { 0, new("To begin smithing, first collect the ores you wish to use. Start with some copper.", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("Next, in your inventory, click the U on either ore, then click the U on the other ore to mix them.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Now change the dialogue on the right to Processing Stations, and click Furnace to smelt them.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Next, click the Anvil processing station to open the crafting menu.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("Items you can craft will be listed in white, while items you can't are red. Click on any white item to craft it.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("That's all there is to it! There are all kinds of things you can smith, and you'll unlock more materials as you grow more skilled.", new() { byeThen }, items: ["pickaxeCopper", "hammer"]) }
            }));

            toAdd.Add(new("Combat Guy", "guyCombat", new() {
                { 0, new("What, a weakling like you wants to learn to fight? Ya see somethin' new every day. Well, if you're sure...", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("You can hop in the cave and start punching guinea pigs if you're brave, but someone as scrawny as you needs a weapon.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Go talk to the Smithing Tutor and learn to make a copper sword. Once you've got it equipped, step into the cage.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("These little guys are harmless until you start fighting them, but most enemies won't wait for you to strike first.", new() { new ("(NEXT)", 40), byeThen }) },
                { 40, new("You can click on a monsters name to target it. If you are on Single mode you will only fight that monster while it is alive.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("Order mode will kill them in order from top to bottom, and Random will select a random living enemy when your current enemy dies.", new() { new("(NEXT)", 60), byeThen }) },
                { 60, new("Last thing you need to know, you can eat food to restore your health. Take some shrimps or cuy meat to a range or fire to cook it.", new() { new("(NEXT)", 70), byeThen }) },
                { 70, new("That's all there is to it! Now get out there and kill, kill, kill!", new() { byeThen }) }
            }));

            toAdd.Add(new("Cooking Guy", "guyCooking", new() {
                { 0, new("You want to learn cooking, eh? Well luckily it's dead simple.", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("First, have an uncooked item in your bag like some raw cuy meat or raw fish.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Next switch to the (P)rocessing tab in your activity area, and click 'Range' once for each uncooked item, or the infinity symbol to cook all of an item at once.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("You can also use this process to fill buckets with water at the 'Sink'. Many recipes can be done like this.", new() { new("(NEXT)", 40), byeThen }) }, 
                { 40, new("That's all there is to it! Enjoy your cooked food, it'll heal a few Hitpoints when you eat it.", new() { byeThen }) }
            }));

            toAdd.Add(new("Farming Guy", "guyFarming", new() {
                { 0, new("You want to learn the art of farming? It ain't much, but it's honest work.", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("First you'll need to get your hands on some seeds. The nearby general store sells potato seeds, if you need a lot of 'em.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Next, find a place with farming patches. There are a few allotments here, suitable for potatoes and other basic produce.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Click the star next to your seed in your inventory to plant it, then come back later to harvest.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("If you can manage to get your hands on some compost you can get more produce out of your seeds.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("That's all there is to it! Why don't I give you a few seeds to try it out for yourself?", new() { byeThen }, items: [ "seedPotato,3" ])}
            }));

            toAdd.Add(new("Talisman Guy", "guyTalisman", new() {
                { 0, new("Greetings! Have you any interest in learning the art of talisman drawing?", new() { new("Sure!", 1), byeThen }) }, // TODO: Option to skip quest step and just receive a stack of like 50 metal and destruction talismans
                { 1, new("Excellent! In essence the art is quite simple: acquire some ink and paper, then draw with the ink on the paper! Any questions?", new() { new("How do I get ink?", 2), new("How do I get paper?", 20), new("How do I draw?", 30), byeThen }) },
                
                // Explain ink section
                { 2, new("Great question! You create ink using Alchemy. For novice ink you'll want to to combine a clean midori with ground-up bones in a vial of water, then dilute it with another vial of water before heating with a brazier. If you haven't got a brazier or a pestle and mortar let me know, I think I've got some spare.", new() { 
                    new("Could I have a pestle and mortar?", 3, [ new("NotItem", 1, "pestleMortar") ], true), 
                    new("Could I have a brazier?", 4, [ new("NotItem", 1, "alchemyBrazier") ], true), 
                    new("Can you explain Alchemy more?", 5), 
                    new("Where can I get clean midori?", 12), 
                    new("Where can I get ground bones?", 13), 
                    new("(BACK)", 1, silent: true), 
                    byeThen 
                }) }, 
                { 3, new("Naturally! To use it, simply click the (U) on it in your inventory, then the (U) on the item you wish to grind up.", new() { new("(BACK)", 2, silent: true), byeThen }, items: [ "pestleMortar,1"] ) },
                { 4, new("Of course! To use it, simply click the (U) on it in your inventory, then the (U) on the mixture you wish to heat.", new() { new("(BACK)", 2, silent: true), byeThen }, items: [ "alchemyBrazier,1"] ) },
                
                // // Explain Alchemy
                { 5, new("Certainly! Alchemy is a complex art, but I will do my best to summarize the process for you. You need at least, or sometimes at most, four things to do Alchemy.", new() { new("(NEXT)", 6), new("(BACK)", 2, silent: true), byeThen }) },
                { 6, new("They are: a vial of water, two ingredients which may be the same ingredient twice, and an alchemist's brazier.", new() { new("(NEXT)", 7), new("(BACK)", 2, silent: true), byeThen }) },
                { 7, new("Each ingredient has a set of four values: red, black, yellow, white. Each potion also has a set of four values to create it.", new() { new("(NEXT)", 8), new("(BACK)", 2, silent: true), byeThen }) },
                { 8, new("Alchemy is the art of adding ingredients to a vial of water to create mixtures, then adding more ingredients or using tools to make it match a potion recipe.", new() { new("(NEXT)", 9), new("(BACK)", 2, silent: true), byeThen }) },
                { 9, new("There's a limit to how many ingredients and tools you can use at once, of course, but as you become more skilled in Alchemy that limit will rise.", new() { new("(NEXT)", 10), new("(BACK)", 2, silent: true), byeThen }) },
                { 10, new("So to sum it up further: use ingredients on a vial of water, then when you think it matches a potion recipe, use the mixture on a brazier. Here, this might be of use to you!", new() { new("(NEXT)", 11), new("(BACK)", 2, silent: true), byeThen }, items: [ "alchemyBooklet,1" ]) },
                { 11, new("Finally, you can imbue inks at altars like the one here. This altar creates generically imbued ink which gives you twice the talismans of regular ink, or if you can find altars for specific energies then matching the imbuement to the talisman give you five times as many!", new() { new("(BACK)", 2, silent: true), byeThen }) },
                
                // // Explain where to get midori and bones 
                { 12, new("Hmmm... I seem to recall hearing there are some midori bushes on the island somewhere, but I haven't seen them around. Somewhere off the beaten path, perhaps.", new() { new("(BACK)", 2, silent: true), byeThen }) },
                { 13, new("...Really? Many living things have bones, and leave them behind when killed. If you don't want to get your hands dirty you'll have to find them some other way.", new() { new("(BACK)", 2, silent: true), byeThen }) },

                // Explain paper section
                { 20, new("Fantastic question! There are three... well, four, I suppose, methods to acquire paper of varying difficulty. Which would you like to hear?", new() { 
                    new("The proper method", 24),
                    new("The simple method", 21),
                    new("The easy method", 22),
                    new("The easier method", 23),
                    new("(BACK)", 1, silent: true), 
                    byeThen 
                }) },
                { 21, new("The simple method is to chop logs, use them on a pestle and mortar to get wood pulp, then either shape it by Activating (*) it, or (U)sing it on a paper mould.", new() { new("(BACK)", 20, silent: true), byeThen }) },
                { 22, new("The easy method is to chop logs, then take them to a papermill and pay to have them turned into paper. Won't find a papermill here on the island though.", new() { new("(BACK)", 20, silent: true), byeThen }) },
                { 23, new("The easier method is to simply find a shop that sells paper and buy it directly. Expensive but fast, though you may have a hard time finding high tier paper that way. As it happens, I sell poplar paper and novice ink if you don't want to make them yourself.", new() { new("(BACK)", 20, silent: true), byeThen }) },
                { 24, new("The proper method is a little complicated. You need to fletch a log into chips, add it to a pot of lye, heat it into pulp, then shape the pulp into sheets of paper.", new() { new("(NEXT)", 25), new("(BACK)", 20, silent: true), byeThen }) },
                { 25, new("That's a bit much to remember, so here's a pamphlet with the steps. Also, have a paper mould so you can get the most out of your work!", new() { new("(BACK)", 20, silent: true), byeThen }, items: [ "bookPapermaker,1", "mouldPaper,1"]) },

                // Explain drawing section
                { 30, new("Ah, my favorite part! Once you have suitable ink and paper in your inventory that you can use with your Crafting level, Activate (*) the ink to open the drawing menu.", new() { new("(NEXT)", 31), new("(BACK)", 1, silent: true), byeThen }) },
                { 31, new("On the left of the window is a listing of all ink and paper in your inventory, which you can click to select for use.", new() { new("(NEXT)", 32), new("(BACK)", 1, silent: true), byeThen }) },
                { 32, new("On the right side of the window you can select what kind of talisman you're trying to make. This will set the puzzle hints to lead you to the right talisman.", new() { new("(NEXT)", 33), new("(BACK)", 1, silent: true), byeThen }) },
                { 33, new("From there, click on squares to fill them with ink. Use the guide numbers to figure out how many squares should be inked in each column and row.", new() { new("(NEXT)", 34), new("(BACK)", 1, silent: true), byeThen }) },
                { 34, new("I have heard this style of puzzle is often called 'picross', 'nonogram', 'griddlers', or 'hanjie'. You may be able to find more help and information by using those names.", new() { new("(BACK)", 1, silent: true), byeThen }) }

            }));

            toAdd.Add(new("Wizard Atrel", "tiWizardAtrel", new() {
                { 0, new("A visitor! Always a pleasant surprise. The name is Atrel, adventurer.", new() {
                    new("What, not 'Wizard Guy'?", 3),
                    new("I am done with the tutorial.", 1, [ new("QuestAt", 90, "TI_HauntedIsland") ], true),
                    new("I did everything here!", 2, [ 
                        new("Skill", 10, "All"),
                        new("CollectionLogComplete", 0, "bossZombie"),
                        new("CollectionLogComplete", 0, "Tutorial clue"),
                        new("QuestAt", 90, "TI_HauntedIsland")
                    ], true),
                    byeThen
                }) },
                { 1, new("Are you sure you wish to leave? You will not be able to return to this place.", new() { new("(TELEPORT)", -1, tele: "WTN_Plaza", spawn: true), byeThen }) },
                { 2, new("Have you now? Well it looks like you have! Quite an achievement! Take this cape and my sincere congratulations.", new() { byeThen }, items: ["capeCompTI,1"]) },
                { 3, new("Ah, met the 'brothers' have you? No, I am simply Atrel, nothing more and nothing less.", new() { new("What do you mean 'brothers'?", 4), byeThen }) },
                { 4, new("Well they claim to be brothers, and they do look identical, but I can't say I've ever seen any two of them together.", new() { byeThen }) }
            }));

            toAdd.Add(new("Drunken pirate", "tiDrunkPirate", new() { { 0, new("Buried me scroll around here some- *hic* somewhere...", new() { byeThen }) } }));
              
            for (int i = 0; i < toAdd.Count; i++) { 
                NPCLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
