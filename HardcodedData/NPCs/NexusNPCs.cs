using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class NexusNPCs {
        public static void InitNPCs(Dictionary<string, NPC> NPCLib) {
            DialogueChoice byeThen = new("Goodbye", -1); 
            List<NPC> toAdd = new();

            toAdd.Add(new("Prima", "wtnPrimaShop", new() {
                { 0, new("Oh! Hello there! Sorry, I was just planning out my next world guide. How can I help you?", [ new("What do you sell here?", 1), byeThen ]) },
                { 1, new("'Guide to the Multiverse and Beyond!'... Or at least that's the shop slogan, heh. I write and sell booklets about each world, so people can learn about them before going.", [ new("(NEXT)", 2), byeThen ]) },
                { 2, new("Some of the worlds the Worldtree becomes connected to are quite dangerous, and may even trap you there unless you use magic to teleport back out.", [ new("(NEXT)", 3), byeThen ]) },
                { 3, new("My guides simply attempt to classify the worlds and give some idea of some things you may find there.", [ byeThen ]) },
            }));
              
            for (int i = 0; i < toAdd.Count; i++) { 
                NPCLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
