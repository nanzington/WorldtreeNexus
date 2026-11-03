using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedNPCs {
        public static void InitNPCs(Dictionary<string, NPC> NPCLib) {
            DialogueChoice byeThen = new("Goodbye", -1);

            List<NPC> toAdd = new();
            
            toAdd.Add(new("Man", "man", new() { { 0, new("Lovely day for it!", new() { byeThen }) } }, 1, 10) { PickpocketLoot = new() { new("coinPouchSmall", 1, 1, 1, 1) } });
            toAdd.Add(new("Woman", "woman", new() { { 0, new("Lovely day for it!", new() { byeThen }) } }, 1, 10) { PickpocketLoot = new() { new("coinPouchSmall", 1, 1, 1, 1) } });
            toAdd.Add(new("Guard", "guard", new() { { 0, new("Keep it moving, adventurer.", new() { byeThen }) } }, 20, 20) { PickpocketLoot = new() { new("coinPouchMedium", 1, 1, 1, 1) } });
            

            toAdd.Add(new("Estate Agent", "estateAgent", new() { 
                { 0, new("Salutations! In the market for a house, or perhaps some work?", new() { 
                    new DialogueChoice("I'd like to buy a house.", 100, [ new("Region", 0, "Nexus")]), 
                    new DialogueChoice("What kind of work did you have in mind?", 1), // Go to Cozy Cottages menu
                    new DialogueChoice("I want to manage my homes.", 50, [ new("AnyPOH") ]),
                    byeThen 
                }) },
                // Cozy Cottages explanation
                { 1, new("Why, Cozy Cottages, of course!", new() { new("What's Cozy Cottages?", 2), new("Give me a contract!", 7), new("What was my contract again?", 8), new("Could I have a contract scroll?", 9), new("Could I look at the Reward Shop?", 25), byeThen }) },
                { 2, new("Quite simple, my friend! People's homes need repairs, and you could do it for them!", new() { new("Is there any kind of reward?", 3), new("What do I need?", 10), new("How do I do it?", 13), new("(BACK)", 1, silent: true), byeThen }) },
                { 3, new("Is the satisfaction of a job well done not reward enough?", new() { new("You know what, you're right!", 4), new("...No.", 5), byeThen }) },
                { 4, new("That's the spirit!", new() { new("(BACK)", 1, silent: true), byeThen }) },
                { 5, new("Well, you'll also get some Construction experience and credits to spend in the rewards shop. Enticed yet?", new() { new("(BACK)", 1, silent: true), new("...No.", 6), byeThen }) },
                { 6, new("Suit yourself. I'll be here if you change your mind.", new() { byeThen }) },
                { 7, new("Coming right up!", new() { byeThen }, acts: [ new("Minigame", "GetCozyContract", "", 0) ]) },
                { 8, new("You know, if you had a contract scroll you wouldn't need to ask! Now let me see...", new() { byeThen }, acts: [ new("Minigame", "ViewCozyContract", "", 0) ]) },
                { 9, new("Here you go, if you need another don't hestitate to ask!", new() { byeThen }, items: [ "cozyCottagesContract" ]) },
                { 10, new("You'll need a lot of planks and nails, the higher your Construction level the better materials you can use. Sometimes you'll also need metal bars, candles, or bolts of cloth. Also you'll always need a hammer and saw to do repairs. Can't very well fix a chair with your bare hands!", new() { new("Where can I get all that?", 11), new("(BACK)", 2, silent: true), byeThen }) },
                { 11, new("Planks, metal bars, and nails you can make yourself through Fletching or Smithing respectively, or you can make planks faster at a sawmill.", new() { new("(NEXT)", 12), byeThen }) },
                { 12, new("Bolts of cloth you can spin from balls of sheep wool, or possibly buy from shops. Candles, hammer, and saw you'll usually need to get from shops as well.", new() { new("(BACK)", 2, silent: true), byeThen }) },
                { 13, new("Take a contract, get an inventory full of materials plus your hammer and saw, then go to the customer's residence.", new() { new("(NEXT)", 14), byeThen }) },
                { 14, new("Open your minigame menu on the right (the * tab). You can set your materials used with the arrows at the top of the menu.", new() { new("(NEXT)", 15), byeThen }) },
                { 15, new("Things that need repairing will have a red x, and you can click the question mark to get a list of materials needed to repair that spot.", new() { new("(NEXT)", 16), byeThen }) },
                { 16, new("If you have everything to repair a spot, the name will be green. Otherwise it will be red, or if it's already repaired then white.", new() { new("(NEXT)", 17), byeThen }) },
                { 17, new("Simply click the green spots and the items to repair them will be taken, repairing it. Once all spots are repaired the contract will automatically complete.", new() { new("(BACK)", 2, silent: true), byeThen }) },
                
                { 25, new("Certainly! See anything that catches your eye?", new() { 
                    new("What are all these?", 40), 
                    new("- Cozy Cottages teleport (2)", 26, [ new("CozyCredits", 2) ], true), 
                    new("- Equippable Saw (500)", 27, [ new("CozyCredits", 500) ], true),
                    new("- Equippable Hammer (500)", 28, [ new("CozyCredits", 500) ], true),
                    new("- Plank Box (200)", 29, [ new("CozyCredits", 200) ], true),
                    new("(BACK)", 2, silent: true), 
                    byeThen 
                }, acts: [ new("Minigame", "CheckCozyCredits", "", 1) ]) },
                
                { 26, new("", new() { new("(BACK)", 25, silent: true), byeThen }, items: [ "teleportCozyCottages,1" ], acts: [ new("Minigame", "SpendCozyCredits", "Cozy Cottages teleport", 2) ]) },
                { 27, new("", new() { new("(BACK)", 25, silent: true), byeThen }, items: [ "hammerEquippable,1" ], acts: [ new("Minigame", "SpendCozyCredits", "John Henry's Hammer", 500) ]) },
                { 28, new("", new() { new("(BACK)", 25, silent: true), byeThen }, items: [ "sawEquippable,1" ], acts: [ new("Minigame", "SpendCozyCredits", "Lu Ban's Saw", 500) ]) },
                { 29, new("", new() { new("(BACK)", 25, silent: true), byeThen }, items: [ "boxPlank,1" ], acts: [ new("Minigame", "SpendCozyCredits", "Plank box", 200) ]) },
                
                { 40, new("In parentheses after each item is the cost in points.", new() { new("(NEXT)", 41), byeThen }) },
                { 41, new("Cozy Cottages teleport scrolls will teleport you to your active contract destination if you have one, or to the local Estate Agent if not.", new() { new("(NEXT)", 42), byeThen }) },
                { 42, new("The equippable saw can be equipped in your offhand, freeing up an inventory slot.", new() { new("(NEXT)", 43), byeThen }) },
                { 43, new("The equippable hammer can be equipped in your main hand, freeing up an inventory slot.", new() { new("(NEXT)", 44), byeThen }) },
                { 44, new("The plank box can hold up to 25 of each plank at once.", new() { new("(NEXT)", 45), byeThen }) },
                { 45, new("Take note that any planks in your box may be lost when upgrading them, and you can only own ", new() { new("(BACK)", 25, silent: true), byeThen }) },
                
                // Open the POH management menu
                { 50, new("You got it. Let me know if you need anything.", new() { new("(BACK)", 0, silent: true), byeThen }, acts: [ new("OpenUI", "ManagePOH", "", 0)]) },
                // Nexus house purchases
                { 100, new("Where did you have in mind for your new home?", new() {
                    new("The Plaza (2500 gp)", 101, [ new("Item", 10000, "Gold", true), new("POHNotOwned", 0, "WTN_Plaza")], true)
                }) },
                { 101, new("Great, here are the keys. Your new home is in the Plaza proper, right near the teleport matrix.", new() { new("(BACK)", 0, silent: true), byeThen }, acts: [ new("BoughtHouse", "WTN_Plaza", "WTN_PlazaPOH", 0)]) },
            }));


            for (int i = 0; i < toAdd.Count; i++) { 
                NPCLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
