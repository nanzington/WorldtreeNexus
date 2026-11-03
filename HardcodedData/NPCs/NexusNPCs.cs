using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class NexusNPCs {
        public static void InitNPCs(Dictionary<string, NPC> NPCLib) {
            DialogueChoice byeThen = new("Goodbye", -1); 
            List<NPC> toAdd = new();

            toAdd.Add(new("Prima", "wtnPrimaShop", new() {
                { 0, new("Oh! Hello there! Sorry, I was just planning out my next world guide. How can I help you?", new() { new("(NEXT)", 10), byeThen }) },
                { 10, new("First you'll need to get your hands on some seeds. The nearby general store sells potato seeds, if you need a lot of 'em.", new() { new("(NEXT)", 20), byeThen }) },
                { 20, new("Next, find a place with farming patches. There are a few allotments here, suitable for potatoes and other basic produce.", new() { new("(NEXT)", 30), byeThen }) },
                { 30, new("Click the star next to your seed in your inventory to plant it, then come back later to harvest.", new() { new("(NEXT)", 40), byeThen }) },
                { 40, new("If you can manage to get your hands on some compost you can get more produce out of your seeds.", new() { new("(NEXT)", 50), byeThen }) },
                { 50, new("That's all there is to it! Why don't I give you a few seeds to try it out for yourself?", new() { byeThen }, "TI_OnTheJobTraining", 10, items: [ "seedPotato,3" ])}
            }));
              
            for (int i = 0; i < toAdd.Count; i++) { 
                NPCLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
