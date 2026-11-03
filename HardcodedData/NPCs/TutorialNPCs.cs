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
                    new("What should I do now?", 100, [ new("QuestAt", -1, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 102, [ new("QuestAt", 0, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 103, [ new("QuestAt", 10, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 104, [ new("QuestAt", 20, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 105, [ new("QuestAt", 30, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 106, [ new("QuestAt", 40, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 107, [ new("QuestAt", 50, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 108, [ new("QuestAt", 60, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 109, [ new("QuestAt", 70, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 110, [ new("QuestAt", 80, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 111, [ new("QuestAt", 90, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 112, [ new("QuestAt", 100, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 113, [ new("QuestAt", 110, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 114, [ new("QuestAt", 120, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 115, [ new("QuestAt", 130, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 116, [ new("QuestAt", 140, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 117, [ new("QuestAt", 150, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 118, [ new("QuestAt", 160, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 119, [ new("QuestAt", 170, "TI_OnTheJobTraining")]),
                    new("What should I do now?", 120, [ new("QuestAt", 180, "TI_OnTheJobTraining")]),
                    byeThen 
                }) }, 
                { 1, new("You have entered the Worldtree Nexus, a series of interconnected worlds full of denizens, adventures, and sights to see!", new() { new("(NEXT)", 2), byeThen }) },
                { 2, new("More specifically you are currently on Tutorial Island. This connection between this world and the Worldtree is... tenuous.", new() { new("(NEXT)", 3), byeThen }) },
                { 3, new("Once you leave the island for the rest of the Worldtree, you will not be able to return here in this life.", new() { new("(NEXT)", 4), byeThen }) },
                { 4, new("In the meantime enjoy the relaxed pace of life here. Spend some time learning how things are done.", new() { new("(BACK)", 0, silent: true), byeThen }) },
                { 5, new("Oh my, what a question! This is quite a complex topic, so I'll break it up a bit. Which part would you like to talk about?", new() { new("Top Left", 10), new("Middle Left", 20), new("Top Right", 50), new("Middle Right", 60), new("Center", 75), new("Bottom", 85), byeThen }) },
                // Talk about top left of sidebar
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
                { 33, new("PRA, or Prayer, shows the list of Prayers you can activate for various bonuses at the cost of draining Prayer Points over time.", new() { new("(NEXT)", 34), byeThen }) },
                { 34, new("Every two seconds, you lose Prayer Points equal to your currently active number of Prayers. This interval can be slowed with the right equipment.", new() { new("(NEXT)", 35), byeThen }) },
                { 35, new("EMO, or Emotes, shows all of the emotes you can do. These serve little purpose, other than being the solution to some clue scroll puzzles.", new() { new("(NEXT)", 36), byeThen }) },
                { 36, new("QST, or Quests, shows all quests you have started or completed. The complete and quest point counters count all quests, even ones you haven't discovered yet, but you have to find quests before they will be listed.", new() { new("(NEXT)", 37), byeThen }) },
                { 37, new("While doing a quest, if you happen to get stuck, check the entry for it for guidance and a summary of events in the quest up to your current point. If you're still stuck, activate the quick guide mode to be told exactly what to do for a quest step.", new() { new("(NEXT)", 38), byeThen }) },
                { 38, new("LOG, or Log, allows you easy access to the collection log screen for clues, bosses, and monster drop tables. This menu itself shows your progress in each main tracked log, and the screen you can open by clicking on the lines will show exact drop rates for every item in the drop table.", new() { new("(NEXT)", 39), byeThen }) },
                { 39, new("POT, or Potions, shows you all currently active potion effects. Most potions decay by one point each minute and expire when they reach an effect of zero.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("Finally MUS, or Music, lists all songs and allows you to select which one is playing. Locked songs are darkened, the currently playing song is green, and the rest of the unlocked songs white.", new() { new("(NEXT)", 41), byeThen }) },
                { 41, new("Songs can be unlocked most commonly by visiting areas, but may also be unlocked through other actions like resource spots, quests, or NPC dialogue.", new() { new("(BACK)", 5, silent: true), byeThen }) },
                // Talk about top right area (location display)
                { 50, new("This area is somewhat simple to explain, fortunately. In the top right, the top box displays the name of your current location and the box under it shows the description.", new() { new("(NEXT)", 51), byeThen }) },
                { 51, new("The description may change based on different circumstances. For example if the location is dark and you have no light, the description is hidden entirely.", new() { new("(BACK)", 5, silent: true), byeThen }) },
                // Talk about middle right area (activity area)
                { 60, new("Perhaps the most important part of the interface! The middle right of your screen is the Activity area. It allows you to view and interact with things at your current location.", new() { new("(NEXT)", 61), byeThen }) },
                { 61, new("(I) shows items on the ground at your current location. If you're in a bank, it instead shows the items in your bank.", new() { new("(NEXT)", 62), byeThen }) },
                { 62, new("Items on the ground disappear when the game restarts, so make sure anything you want to keep is in your inventory or bank before closing!", new() { new("(NEXT)", 63), byeThen }) },
                { 63, new("(N) lists NPCs, or 'Non-player Characters'. Like me! You can click their names to speak to them, like you did to speak to me.", new() { new("(NEXT)", 64), byeThen }) },
                { 64, new("(P) lists Processing Stations. These typically take a single item and turn it into another single item. For example, raw meat into cooked meat.", new() { new("(NEXT)", 65), byeThen }) },
                { 65, new("(R) lists Resources, along with any generically interactable objects. Most commonly these are interacted with to receive an item or do an action.", new() { new("(NEXT)", 66), byeThen }) },
                { 66, new("One example is trees, which can be chopped with a hatchet to get logs. Resources that give items will usually have a cooldown, but can sometimes be gathered multiple times before going on cooldown.", new() { new("(NEXT)", 67), byeThen }) },
                { 67, new("(C) lists all dialogue options for the NPC you are speaking to, at the current point in the conversation. Like you've been doing with me!", new() { new("(NEXT)", 68), byeThen }) },
                { 68, new("(S) lists all shop items, if there are any, allowing you to purchase items for gold. Dropping items at a shop will sell them and give you gold.", new() { new("(NEXT)", 69), byeThen }) },
                { 69, new("Many parts of the UI - dropping items, picking up items, buying items, and so on, allow you to do more per click by holding SHIFT, CTRL or both.", new() { new("(NEXT)", 70), byeThen }) },
                { 70, new("SHIFT multiplies amount by 5, CTRL by 10, and thus together by 50 total. Some things allow you to hold SPACE for x1000, or ALT for maximum possible.", new() { new("(NEXT)", 71), byeThen }) },
                { 71, new("(F) lists farming patches and their current status. You can Activate (*) seeds in your inventory to plant them, if there is an empty matching farmplot.", new() { new("(NEXT)", 72), byeThen }) },
                { 72, new("(*) is the minigame menu. On Tutorial Island you'll mostly use it for Cozy Cottages, but most minigames will display info and controls there.", new() { new("(BACK)", 5, silent: true), byeThen }) },
                // Talk about center (connected locations and combat)
                { 75, new("The center area of the screen primarily shows Connected Locations. You can click these to move to other maps connected to your current map.", new() { new("(NEXT)", 76), byeThen }) },
                { 76, new("When there are attackable monsters they will be listed under the connections. The (SINGLE) makes you continue fighting the same monster each time it respawns.", new() { new("(NEXT)", 77), byeThen }) },
                { 77, new("(ORDER) will make you automatically switch to attacking the living monster highest in the list when your current target dies.", new() { new("(NEXT)", 78), byeThen }) },
                { 78, new("(RANDOM) causes you to automatically attack a random living target when your current target dies.", new() { new("(NEXT)", 79), byeThen }) },
                { 79, new("Each monster is listed by name, their level in brackets, and then their hitpoints. Additionally there is a button, Log, to open the collection log to that monster entry.", new() { new("(NEXT)", 80), byeThen }) },
                { 80, new("To the left of each monsters name is a red dagger. If you click this, it will tell you the (very rough) approximate odds that you will win if you fight the monster.", new() { new("(NEXT)", 81), byeThen }) },
                { 81, new("To attack the monster, simple click its name. Monsters hostile or attacking you will have a red name, your current target a yellow name, otherwise a white name.", new() { new("(BACK)", 5, silent: true), byeThen }) },

                // Talk about bottom (log, now playing / volume, and save button)
                { 85, new("The bottom area of the screen contains the log. It's where you've been reading this dialogue, and also where all game information is logged. Check it often!", new() { new("(NEXT)", 86), byeThen }) },
                { 86, new("Along the very bottom of the screen is the Now Playing note, currently likely playing Gymnopedie 1. To the right is the music volume control.", new() { new("(NEXT)", 87), byeThen }) },
                { 87, new("Finally: the SAVE button! You can click it at almost any time to manually save your progress. If you crash or close the game without saving, all progress since your last save will be lost. That said, an automatic save will happen every five minutes just in case you forget to manually save.", new() { new("(BACK)", 5, silent: true), byeThen }) },

                // On the Job Training quest dialogue
                { 100, new("Fantastic question! The answer, I suppose, is: anything you like! There are many things you can do here. That said, if you'd like to leave Tutorial Island there's a fairly straightforward task you must complete first.", new() { new("[Start: On The Job Training] What kind of task did you have in mind?", 101), byeThen }) },
                { 101, new("All you have to do is collect the eight items on this list. Over in your inventory click the * next to the list to Activate it, opening the 'book' interface. You can gather them in order you like, but your quest log can provide guidance. I'd recommend going and talking to Farming Guy at his farmstead first. If you ever get stuck or need help, feel free to come back and speak to me again.", new() { byeThen }, "TI_OnTheJobTraining", 0, [ "qListTutorial"]) },
                { 102, new("You should go talk to Farming Guy, on his farmstead here on the island, about how to farm.", new() { byeThen }) },
                { 103, new("I believe you got some potato seeds from Farming Guy, no? Go stand at the farmstead and click the * on them in your inventory to plant them.", new() { byeThen }) },
                { 104, new("You got those seeds planted? Excellent, why don't you go try out mining in the Cavern? My brother, Smithing Guy, can explain more. Try to make a few copper bars.", new() { byeThen }) },
                { 105, new("Ah, you made some copper bars! One major use of smithing is to create equipment for combat. Try smithing a bar into a sword at the Anvil in the Caverns.", new() { byeThen }) },
                { 106, new("You made the sword, nicely done. You can equip it by clicking the E button it has in your inventory. Do so, then enter the giant guinea pig cage in the Cavern and try to kill a couple. Combat Guy can explain that process a little more.", new() { byeThen }) },
                { 107, new("Hmmm... I think the next item on your list is an illusion talisman? Try speaking to my brother, Talisman Guy, about Alchemy and how to make talismans. He's at the Magical Altar.", new() { byeThen }) },
                { 108, new("I believe you need an attack potion next? You'll have to combine a clean neela with a cuy eye. You can pick neela on the Agility course in the Caverns, and of course cuy eyes from killing the giant guinea pigs. Combine them in a vial of water and then heat with your brazier.", new() { byeThen }) },
                { 109, new("Cleansed bones, eh? That one is pretty simple, just take a set of bones to the Temple and use the Holy Fountain. Father Guy can tell you more about Prayer while you're there.", new() { byeThen }) },
                { 110, new("Talk to Dodgy Ranger Guy at the Crossroads, he'll teach you about Thieving. You'll have to give pickpocketing him a go to move on.", new() { byeThen }) },
                { 111, new("You need to make a shortbow, so chop down a poplar tree and carve the log with a knife. Pick some flax and then spin it at a Spinning Wheel to get a bowstring, then combine them.", new() { byeThen }) },
                { 112, new("You'll have to do a couple Cozy Cottages contracts to get a teleport scroll. Speak to the Estate Agent in the Bank for more details, but in essence you have to get a contract from him, get materials to repair things, and then go to the contract destination and repair everything in the Minigame (*) menu.", new() { byeThen }) },
                { 113, new("I think your potatoes should be about done growing by now! Why don't you go harvest those?", new() { byeThen }) },
                { 114, new("Seems like you need to make some fries. Use a knife on a potato to slice it, then the knife on the slices to make sticks. Then deep fry them in the Kitchen.", new() { byeThen }) },
                { 115, new("You need the actual 'fish' part of fish and chips, so go to the Docks to learn about Fishing from Fishing Guy.", new() { byeThen }) },
                { 116, new("Can't very well fry up a whole fish scales and all! Use your knife to fillet the fish.", new() { byeThen }) },
                { 117, new("Go to the Kitchen to pick up a bowl and a bucket, then go to the farmstead. Pick up an egg and use it on the empty bowl, then pick some wheat and use the windmill to get flour. Combine the flour and egg to get batter, then use it on the pollock fillet to batter it. Finally deep fry it in the Kitchen!", new() { byeThen }) },
                { 118, new("Most important step here for fish and chips... use the fries on the fish sticks to combine them into a meal!", new() { byeThen }) },
                { 119, new("Looks like you're about done! Just take all the items you made on the list and turn them in to Wizard Atrel in his hut.", new() { byeThen }) },
                { 120, new("Well, anything you want, I suppose! You've finished the training so you're free to leave the island at any time, or you can stay here training further.", new() { byeThen }) }
            }));

            toAdd.Add(new("Farming Guy", "guyFarming", new() {
                { 0, new("You want to learn the art of farming? It ain't much, but it's honest work.", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("First you'll need to get your hands on some seeds. The nearby general store sells potato seeds, if you need a lot of 'em.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Next, find a place with farming patches. There are a few allotments here, suitable for potatoes and other basic produce.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Click the star next to your seed in your inventory to plant it, then come back later to harvest.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("If you can manage to get your hands on some compost you can get more produce out of your seeds.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("That's all there is to it! Why don't I give you a few seeds to try it out for yourself?", new() { byeThen }, "TI_OnTheJobTraining", 10, items: [ "seedPotato,3" ])}
            }));

            toAdd.Add(new("Father Guy", "guyFather", new() {
                { 0, new("Welcome, child. Blessings of the Worldtree upon you. Are you here to learn about the Prayer skill?", new() { new("Yes, please tell me about Prayer.", 1), byeThen }) },
                { 1, new("Wonderful! You may see your current Prayer points on the left of your screen near the top, in blue.", new() { new("(NEXT)", 2), byeThen }) },
                { 2, new("Your point total is equal to ten times your Prayer level, and drains points equal to number of active Prayers every two seconds.", new() { new("(NEXT)", 3), byeThen }) },
                { 3, new("These points may be refilled by praying at an altar, usually found in temples scattered about the world.", new() { new("(NEXT)", 4), byeThen }) },
                { 4, new("The main way to raise your Prayer level is by burying bones dropped by slain foes, by Activating (*) them in your inventory.", new() { new("(NEXT)", 5), byeThen }) },
                { 5, new("Bones can be cleansed at a Holy Fountain, found in temples, to get more experience.", new() { new("(NEXT)", 6), byeThen }) },
                { 6, new("You can also anoint bones with oils made through Alchemy and blessed at an altar for even more experience, though the bones must then be burnt rather than buried.", new() { new("(NEXT)", 7), byeThen }) },
                { 7, new("That's all there is to it! Why don't you try bringing some bones here to cleanse them?", new() { byeThen }) }
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
                { 0, new("To begin smithing, first collect the ores you wish to use. Start by mining some copper over there.", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("Next, go to the (P)rocessing tab and use a Furnace to smelt the ores. Some, like bronze, may require mixing multiple other things together first.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Next, click the Anvil station to open the crafting menu.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Items you can craft are listed in white, while items you can't are red. Click any white item to craft it.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("If you click a red entry it will tell you why you can't currently craft it, typically lacking a level, tool, or materials.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("That's all there is to it! There are all kinds of things you can smith, and you'll unlock more materials as you grow more skilled.", new() { byeThen }) }
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

            toAdd.Add(new("Dodgy Ranger Guy", "guyDodgyRanger", new() {
                { 0, new("What, me? Wasn't doin' nothin'. Who's askin'? Oh, you're not the fuzz. Whaddaya want kid?", new() { 
                    new("Can you teach me about thieving?", 5), 
                    new("Can you teach me about agility?", 10), 
                    new("Can you teach me about woodcutting?", 15), 
                    new("Can you teach me about fletching?", 20), 
                    new("Can you teach me about ranged combat?", 25), 
                    byeThen 
                }) },
                { 5, new("Two main ways to thieve, my sticky fingered friend. First is pickpocketing. In the NPC menu, sometimes NPCs will have a P next to their name.", new() { new("(NEXT)", 6), byeThen }) },
                { 6, new("Just click it to try to pickpocket them. Go ahead and try it out on me, I'll pretend not to notice unless you mess it up.", new() { new("(NEXT)", 7), byeThen }) },
                { 7, new("The other way is to find market stalls, visible in the (R)esources menu, and swipe something while the merchant isn't looking. None of those here, though.", new() { new("(BACK)", 0, silent: true), byeThen }) }, 
                
                { 10, new("Agility is pretty useful, lets you use shortcuts to get around a bit quicker sometimes. You mostly train it by finding agility courses and then going through the obstacles in a loop. A bit of experience each obstacle, a bit more experience when you finish a lap.", new() { new("(BACK)", 0, silent: true), byeThen }) },
                
                { 15, new("Pretty simple. Get a hatchet, find a tree in the (R)esources menu, click it to chop it down. Usually gives log you can fletch or burn.", new() { new("(BACK)", 0, silent: true), byeThen }) },
                
                { 20, new("Fletching is the art of carving wood into things. Bows, arrows, planks, fishing rods, wands. All kinds of things.", new() { new("(NEXT)", 21), byeThen }) },
                { 21, new("Just grab a knife, grab some logs, then Activate (*) the knife to open the fletching menu. Select what you want to craft and it'll craft.", new() { new("(BACK)", 0, silent: true), byeThen }) },
                
                { 25, new("Ranged is very useful for staying away from baddies. Monsters that only have a melee attack can't hit you while you use ranged or magic.", new() { new("(NEXT)", 26), byeThen }) },
                { 26, new("For ranged you'll need a bow and arrows, a crossbow and bolts, or knives. You might find other niche weapons but those are the main types.", new() { new("(NEXT)", 27), byeThen }) },
                { 27, new("To make a bow you can fletch logs into an unstrung bow, then add a bowstring. Get one of those by spinning flax at a spinning wheel.", new() { new("(NEXT)", 28), byeThen }) },
                { 28, new("Arrows you have to fletch shafts out of logs, add feathers to the shafts, then add arrowheads to the headless shafts.", new() { new("(NEXT)", 29), byeThen }) },
                { 29, new("Crossbow is a mite more complicated. Fletch a stock from a log, then use it on crossbow limbs from the same tier of metal. Burn a piece of meat, then use it on a range again to get sinew. Spin the sinew at a wheel and then string the crossbow with it.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Bolts are a little simpler to make than arrows. Just smith the featherless bolts out of metal, then attach feathers.", new() { new("(NEXT)", 31), byeThen }) },
                { 31, new("Knives are the simplest of the lot. Just smith them out of metal and you're done.", new() { new("(BACK)", 0, silent: true), byeThen }) },
            }, 1, 20) { PickpocketLoot = [ new("coinPouchSmall", 1, 1, 1, 1)]});

            toAdd.Add(new("Talisman Guy", "guyTalisman", new() {
                { 0, new("Greetings! Have you any interest in learning the art of talisman drawing?", new() { new("Sure!", 1), byeThen }) },
                { 1, new("Excellent! In essence the art is quite simple: acquire some ink and paper, then draw with the ink on the paper! Any questions?", new() { new("How do I get ink?", 2), new("How do I get paper?", 20), new("How do I draw?", 30), byeThen }) },
                
                // Explain ink section
                { 2, new("Great question! You create ink using Alchemy. For novice ink you'll want to to combine a clean midori with ground-up bones in a vial of water, then heat with a brazier. If you haven't got a brazier or a pestle and mortar let me know, I think I've got some spare.", new() { 
                    new("Could I have a pestle and mortar?", 3, [ new("NotItem", 1, "pestleMortar") ], true), 
                    new("Could I have a brazier?", 4, [ new("NotItem", 1, "alchemyBrazier") ], true), 
                    new("Can you explain Alchemy more?", 5), 
                    new("Where can I get clean midori?", 12), 
                    new("Where can I get ground bones?", 13), 
                    new("How can I make an attack potion?", 40), 
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
                { 12, new("Hmmm... I seem to recall hearing there are some herb bushes in the old Agility Course, but I haven't seen them myself to know for sure.", new() { new("(BACK)", 2, silent: true), byeThen }) },
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
                { 34, new("I have heard this style of puzzle is often called 'picross', 'nonogram', 'griddlers', or 'hanjie'. You may be able to find more help and information by using those names.", new() { new("(BACK)", 1, silent: true), byeThen }) },

                { 40, new("I've always had a bit of trouble remembering recipes. I had the attack potion recipe written down, but I can't seem to find it.", new() { new("(NEXT)", 41), byeThen }) },
                { 41, new("I know I had it when I was going to investigate the rumor of herb bushes in the old Agility course... I tried to navigate the course but, well, I've got nimble fingers, not nimble legs.", new() { new("(NEXT)", 42), byeThen }) },
                { 42, new("The zombies there gave me such a fright, I must have dropped the recipe in my scramble to escape!", new() { new("(BACK)", 2, silent: true), byeThen }) }

            }));

            toAdd.Add(new("Wizard Atrel", "tiWizardAtrel", new() {
                { 0, new("A visitor! Always a pleasant surprise. The name is Atrel, adventurer.", new() {
                    new("What, not 'Wizard Guy'?", 3),
                    new("I have gathered all the items on the list!", 10, [ new("QuestBelow", 180, "TI_OnTheJobTraining") ], true),
                    new("I would like to leave this island.", 1, [ new("QuestAt", 180, "TI_OnTheJobTraining") ]),
                    new("I did everything here!", 2, [ 
                        new("Skill", 10, "All"),
                        new("CollectionLogComplete", 0, "bossZombie"),
                        new("CollectionLogComplete", 0, "Tutorial clue"),
                        new("QuestAt", 180, "TI_OnTheJobTraining")
                    ], true),
                    byeThen
                }) },
                { 1, new("Are you sure you wish to leave? You will not be able to return to this place.", new() { new("(TELEPORT)", -1, tele: "WTN_Plaza", spawn: true), byeThen }) },
                { 2, new("Have you now? Well it looks like you have! Quite an achievement! Take this cape and my sincere congratulations.", new() { byeThen }, items: ["capeCompTI,1"]) },
                { 3, new("Ah, met the 'brothers' have you? No, I am simply Atrel, nothing more and nothing less.", new() { new("What do you mean 'brothers'?", 4), byeThen }) },
                { 4, new("Well they claim to be brothers, and they do look identical, but I can't say I've ever seen any two of them together.", new() { byeThen }) },
                { 10, new("Really? Excellently done! Let's see them, then.", new() { 
                    new("Actually I don't seem to have them with me...", 11),
                    new("Here you go!", 12, [ 
                        new("Item", 1, "barCopper", true), new("Item", 1, "talismanIllusion", true), new("Item", 1, "potionAttack", true), new("Item", 1, "bonesRegularCleansed", true),
                        new("Item", 1, "coinPouchSmall", true), new("Item", 1, "teleportCozyCottages", true), new("Item", 1, "shortbowPoplar", true), new("Item", 1, "mealFishChips", true)
                    ], true),
                    byeThen 
                }) },
                { 11, new("...Perhaps my praise was too hasty. Come back with the items if you wish to finish the quest.", new() { byeThen }) },
                { 12, new("That seems to be all of it! Congratulations. Here's a bit of coin for your trouble. Let me know when you'd like to leave for the Worldtree Nexus.", new() { new("I would like to leave now.", 1), byeThen }, "TI_OnTheJobTraining", 180) },
            }));

            toAdd.Add(new("Treasure Guy", "guyTreasure", new() { 
                { 0, new("Ahoy! Come to learn about the noble pursuit of treasure hunting?", new() { new("Sure!", 1), byeThen }) },
                { 1, new("The process is fairly simple: find clue scrolls, Activate (*) them to read the clue, then solve it!", new() { new("(NEXT)", 2), byeThen }) },
                { 2, new("Clues can take a few forms. You might have to dig at a map, speak to someone, turn in an item to someone, or more.", new() { new("(NEXT)", 3), byeThen }) },
                { 3, new("Speaking 'cryptic' clues have a vague hint about who you have to speak to, for the next clue.", new() { new("(NEXT)", 4), byeThen }) },
                { 4, new("Digging 'cryptic' clues have a vague hint about where you need to dig. Find the map that the clue describes, then use a shovel there.", new() { new("(NEXT)", 5), byeThen }) },
                { 5, new("Emote clues will give you an emote, up to three pieces of equipment, and a location. Equip the items, go to the location, then use the emote.", new() { new("(NEXT)", 6), byeThen }) },
                { 6, new("Digging 'cryptic' clues have a vague hint about where you need to dig. Find the map that the clue describes, then use a shovel there.", new() { new("(NEXT)", 5), byeThen }) },
                { 20, new("They're split into tiers based on level of difficulty. Tutorial, Beginner, Easy, Medium, Hard, Elite, and Master.", new() { new("(NEXT)", 21), byeThen }) },
                { 21, new("The only clues you can do here are Tutorial clues, which can't be completed anywhere else in the multiverse. So if you want to collect all the treasure from it, don't leave until you're done!", new() { new("(NEXT)", 22), byeThen }) },
                { 22, new("Similarly, Beginner clues can all be completed without leaving the Worldtree Nexus.", new() { new("(NEXT)", 23), byeThen }) },
                { 23, new("The rest of the clues, you'll have to put your thinking cap on and scour the multiverse! But the rewards can be worth it.", new() { new("(NEXT)", 24), byeThen }) },
                { 24, new("Now supposing you'd like to give it a go, consider this your first treasure hunt:", new() { new("(NEXT)", 25), byeThen }) },
                { 25, new("Somewhere on this island I have buried a stash of tutorial clue scrolls. Grab a shovel and try to find them!", new() { byeThen }) }
            }));
              
            for (int i = 0; i < toAdd.Count; i++) { 
                NPCLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
