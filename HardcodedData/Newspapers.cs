using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class Newspapers {
        public static void InitNewspapers(Dictionary<string, Newspaper> NewsLib) {
            List<Newspaper> toAdd = new();

            // Recurring sheet/section notes
            // Sheet 1: Biggest headline in the patch in the middle, like that a new world has opened. Other large changes/additions in side columns  
            // Sheet 2: Local news (Smaller content additions for each world (like new locations opening up in them))
            // Sheet 3: Opinion/Commentary (advice columns and such written by NPCs and answered by an NPC at the paper)
            // Sheet 4: Lifestyle (Report some fictional sports stats maybe, review any new in-world media (ingame books, games, etc), a food section showing a recipe)
            // Sheet 5: Classifieds (list some currently available job minigames, advertise a few shops, some quest start hints)
            // Sheet 6: Entertainment (comic strip(s), crossword, sudoku, horoscopes)
            // Sheet 7: Letters to the Editor (Spotlighted steam reviews, in first issue maybe note that reviews may be highlighted if you begin in a certain way and keep it in-character)

            toAdd.Add(new Newspaper("The Daily Sprout", "exampleDontUse", "Issue #0 (10-30-2026)", [
                new NewspaperSheet([ // Front page
                    new NewspaperColumn(25, [
                        new NewspaperSection("Other large change/story")
                    ]),
                    new NewspaperColumn(56, [ 
                        new NewspaperSection("Biggest main headline / story")
                    ]),
                    new NewspaperColumn(25, [ 
                        new NewspaperSection("Other large change/story")
                    ])
                ]),
                new NewspaperSheet([ // Local news
                    new NewspaperColumn(36, [
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(38, [ 
                        new NewspaperSection("Big main headline / story")
                    ]),
                    new NewspaperColumn(36, [ 
                        new NewspaperSection("Lesser story")
                    ])
                ]),
                new NewspaperSheet([ // Opinion/Commentary
                    new NewspaperColumn(36, [
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(38, [ 
                        new NewspaperSection("Big main headline / story")
                    ]),
                    new NewspaperColumn(36, [ 
                        new NewspaperSection("Lesser story")
                    ])
                ]),
                new NewspaperSheet([ // Lifestyle
                    new NewspaperColumn(36, [
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(38, [ 
                        new NewspaperSection("Big main headline / story")
                    ]),
                    new NewspaperColumn(36, [ 
                        new NewspaperSection("Lesser story")
                    ])
                ]),
                new NewspaperSheet([ // Classifieds
                    new NewspaperColumn(21, [
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(21, [ 
                        new NewspaperSection("Lesser store"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(24, [ 
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(21, [ 
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(21, [ 
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story"),
                        new NewspaperSection("Lesser story")
                    ])
                ]),
                new NewspaperSheet([ // Entertainment
                    new NewspaperColumn(36, [
                        new NewspaperSection("Lesser story")
                    ]),
                    new NewspaperColumn(38, [ 
                        new NewspaperSection("Big main headline / story")
                    ]),
                    new NewspaperColumn(36, [ 
                        new NewspaperSection("Lesser story")
                    ]),
                ])
            ]));

            toAdd.Add(new Newspaper("The Daily Sprout", "patchNotes0", "Issue #0 (10-30-2026)", [
                new NewspaperSheet([ // 
                    new NewspaperColumn(40, [
                        new NewspaperSection("Prim's Primers /n /n /n Your guide to the multiverse!")
                    ]),
                    new NewspaperColumn(40, [

                    ]),
                    new NewspaperColumn(40, [

                    ])
                ])
            ]));

            /*
            toAdd.Add(new(, "patchNotes0", 2, new() {
                new("", "Prim's Primers /n /n /n Your guide to the multiverse!"),
                new("", "Sneed's Feed and Seed /n /n Need feed? /n Get seed!"),
                new("", "Crossroads Inn /n /n Grab a drink where all paths meet!"), 
                new("Worldtree Welcomes You!", "New people from the multiverse appear on the Worldtree each day as more worlds become interconnected by its' branches. /n /n We at the Daily Sprout are happy to welcome our latest neighbors, the residents of Everafter! A land of whimsy and fairytales made real. Give it a visit when you have time!"),
                new("", "Cult of the Tree recieves official recognition and allowed to open a temple in the Nexus."),
                new("", "Cozener's Casino reports high profits in opening week as gamblers from across the multiverse flock to their tables."),
            }));
            */

            for (int i = 0; i < toAdd.Count; i++) {
                NewsLib.Add(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
