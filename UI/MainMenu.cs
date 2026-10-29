using SadConsole.Input;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.Hardcodes;
using WorldtreeNexus.Managers;
using Key = SadConsole.Input.Keys;

namespace WorldtreeNexus.UI {
    public class MainMenu : MiniDream {
        public Stream menuXP;
        public SadRex.Image menuImage;

        public Console menuBackdrop;

        public string MenuMode = "Main";
        public string TypingBox = "";
        public int SkippingTutorialIsland = 0;

        public List<string> MusicCredits = [
            "sinneschlösen".Align(HorizontalAlignment.Left, 20) + "- Beam",
            "feedeorfano".Align(HorizontalAlignment.Left, 20) + "- Cukies Zelda",
            "tomhUK".Align(HorizontalAlignment.Left, 20) + "- Assembled with Chair",
            "Ada79452".Align(HorizontalAlignment.Left, 20) + "- Miss",
            "DSTechnician".Align(HorizontalAlignment.Left, 20) + "- Away",
            "sunsetflowerray".Align(HorizontalAlignment.Left, 20) + "- Clockwork",
            "EthemSaygi".Align(HorizontalAlignment.Left, 20) + "- Caravan Rest at Dawn",
            "Dummy_Daniel".Align(HorizontalAlignment.Left, 20) + "- Party at the Tavern",
            "Dummy_Daniel".Align(HorizontalAlignment.Left, 20) + "- Along the Road",
            "Dummy_Daniel".Align(HorizontalAlignment.Left, 20) + "- Hometown",
            "oldkech".Align(HorizontalAlignment.Left, 20) + "- Fur Elise",
            "(Anonymous Uploader)".Align(HorizontalAlignment.Left, 20) + "- Gymnopedie 1",
            "(Anonymous Uploader)".Align(HorizontalAlignment.Left, 20) + "- Dance of the Sugar Plum Fairy", 

        ]; 
        public int MusicCreditsTop = 0;

        public List<string> OtherCredits = [
            "JesterMouse - Romeo & Juliet"
        ]; 
        public int OtherCreditsTop = 0;


        public void Update(UI_EmbeddedMini mini) {
            if (ExtraWindows.Alchemy.IsVisible)
                ExtraWindows.AlchemyDraw();

            mini.Con.Clear();
            mini.SingleSquare.Clear();

            mini.Con.Print(131, 0, "VOLUME: ");
            mini.Con.PrintClickable(139, 0, new ColoredString("-", Color.White, Color.Transparent), () => {
                double qty = 0.01;
                if (Helper.EitherShift()) { qty *= 5.0; }
                if (Helper.EitherControl()) { qty *= 10.0; }
                
                GameLoop.GlobalOptions.MusicVolume = Math.Clamp(GameLoop.GlobalOptions.MusicVolume - qty, 0, GameLoop.GlobalOptions.MusicVolume);
                GameLoop.SaveGlobalPrefs();
            });

            mini.Con.Print(141, 0, $"{GameLoop.GlobalOptions.MusicVolume:0.00}".ToString());

            mini.Con.PrintClickable(146, 0, new ColoredString("+", Color.White, Color.Transparent), () => {
                double qty = 0.01;
                if (Helper.EitherShift()) { qty *= 5.0; }
                if (Helper.EitherControl()) { qty *= 10.0; }
                
                GameLoop.GlobalOptions.MusicVolume = Math.Clamp(GameLoop.GlobalOptions.MusicVolume + qty, GameLoop.GlobalOptions.MusicVolume, 1.0);
                GameLoop.SaveGlobalPrefs();
            });

            //Point mousePos = new MouseScreenObjectState(mini.Con, GameHost.Instance.Mouse).CellPosition;   


            int offX = 16;
            int offY = 2;


            // WORLDTREE 
             
            mini.SingleSquare.Print(offX, offY, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 4, offY, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 4, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 2, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 4, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX, offY + 3, "XX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 3, offY + 3, "XX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX, offY + 4, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 4, offY + 4, "X", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 6, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 10, offY, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 6, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 10, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 6, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 10, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 6, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 10, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 6, offY + 4, "XXXXX", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 12, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 16, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 2, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 15, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 4, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 16, offY + 4, "X", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 18, offY, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 1, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 18, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 3, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 18, offY + 4, "XXXXX", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 24, offY, "XXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 24, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 28, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 24, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 28, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 24, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 28, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 24, offY + 4, "XXXX", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 30, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 32, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 32, offY + 2, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 32, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 32, offY + 4, "X", Color.White, Color.Black);

            mini.SingleSquare.Print(offX + 36, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 40, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 2, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 39, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 4, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 40, offY + 4, "X", Color.White, Color.Black);

            mini.SingleSquare.Print(offX + 42, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 42, offY + 1, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 42, offY + 2, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 42, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 42, offY + 4, "XXXXX", Color.White, Color.Black);

            mini.SingleSquare.Print(offX + 48, offY, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 48, offY + 1, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 48, offY + 2, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 48, offY + 3, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 48, offY + 4, "XXXXX", Color.White, Color.Black);

            // NEXUS
            
            mini.SingleSquare.Print(offX + 12, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 16, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 7, "X", Color.White, Color.Black);  
            mini.SingleSquare.Print(offX + 13, offY + 7, "X", Color.White, Color.Black);  
            mini.SingleSquare.Print(offX + 16, offY + 7, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 12, offY + 8, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 14, offY + 8, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 16, offY + 8, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 12, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 15, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 16, offY + 9, "X", Color.White, Color.Black);  
            mini.SingleSquare.Print(offX + 12, offY + 10, "X", Color.White, Color.Black); 
            mini.SingleSquare.Print(offX + 16, offY + 10, "X", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 18, offY + 6, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 8, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 18, offY + 10, "XXXXX", Color.White, Color.Black);
             
            mini.SingleSquare.Print(offX + 24, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 28, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 25, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 27, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 26, offY + 8, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 25, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 27, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 24, offY + 10, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 28, offY + 10, "X", Color.White, Color.Black);

            mini.SingleSquare.Print(offX + 30, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 34, offY + 6, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 30, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 34, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 30, offY + 8, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 34, offY + 8, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 30, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 34, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 30, offY + 10, "XXXXX", Color.White, Color.Black);
            
            mini.SingleSquare.Print(offX + 36, offY + 6, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 7, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 8, "XXXXX", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 40, offY + 9, "X", Color.White, Color.Black);
            mini.SingleSquare.Print(offX + 36, offY + 10, "XXXXX", Color.White, Color.Black);
            

            mini.Con.Print(1, 45, "Links:", Color.White, Color.Black);
            mini.Con.PrintClickable(1, 47, new ColoredString("Join us on Discord!", Color.DodgerBlue, Color.Black), () => {
                Process.Start(new ProcessStartInfo("https://discord.gg/yJXRKTPnkc") { UseShellExecute = true });
            });

            if (MenuMode == "Main") {
                Helper.DrawBox(mini.Con, 63, 20, 20, 20, 255, 255, 255, 0, true);

                mini.Con.PrintClickable(68, 22, "New Character", () => { MenuMode = "Create"; });
                mini.Con.PrintClickable(70, 24, "Load Game", () => { MenuMode = "Load"; });
                mini.Con.DrawLine(new Point(64, 26), new Point(83, 26), 196, Color.White);
                mini.Con.PrintClickable(66, 28, "Alchemy Training", () => { 
                    ExtraWindows.Alchemy.IsVisible = true; 
                    ExtraWindows.AlchemyTraining = true; 
                    ExtraWindows.AlchemyTrain = new();
                    ExtraWindows.AlchemyTrainUndo = new();
                    ExtraWindows.AlchemyTrainSave = new();
                });
                mini.Con.PrintClickable(68, 38, "View Credits", () => { MenuMode = "Credits"; });
                mini.Con.PrintClickable(72, 40, "Exit", () => { Environment.Exit(0); });
            } else if (MenuMode == "Create") {  
                Helper.DrawBox(mini.Con, 20, 10, 105, 34, 255, 255, 255, 0, true);

                mini.Con.PrintStringField(38, 11, "Name: ", ref GameLoop.WTN.player.Name, ref TypingBox, "playerName");

                mini.Con.Print(92, 11, "Skip Tutorial Island: ");
                mini.Con.PrintClickable(98 + 16, 11, new ColoredString("No", SkippingTutorialIsland == 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { SkippingTutorialIsland = 0; });
                mini.Con.PrintClickable(98 + 19, 11, new ColoredString("Yes", SkippingTutorialIsland == 1 ? Color.White : Color.DarkSlateGray, Color.Black), () => { SkippingTutorialIsland = 1; });
                mini.Con.PrintClickable(98 + 23, 11, new ColoredString("Cape", SkippingTutorialIsland == 2 ? Color.AnsiGreen : Color.DarkSlateGray, Color.Black), () => { SkippingTutorialIsland = 2; }); 

                mini.Con.Print(92, 12, "  All Music Unlocked: ");
                mini.Con.PrintClickable(98 + 16, 12, new ColoredString("No", !GameLoop.WTN.player.AllSongsUnlocked ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.AllSongsUnlocked = false; });
                mini.Con.PrintClickable(98 + 19, 12, new ColoredString("Yes", GameLoop.WTN.player.AllSongsUnlocked ? Color.Green : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.AllSongsUnlocked = true; });
                

                int printY = 13;

                mini.Con.Print(28, printY, "Trade Hall:");
                mini.Con.PrintClickable(44, printY, new ColoredString("Full", GameLoop.WTN.player.TradeHallLimit == 0 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.TradeHallLimit = 0; });
                mini.Con.PrintClickable(49, printY, new ColoredString("Bronze", GameLoop.WTN.player.TradeHallLimit == 1 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.TradeHallLimit = 1; });
                mini.Con.PrintClickable(56, printY, new ColoredString("None", GameLoop.WTN.player.TradeHallLimit == 2 ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.TradeHallLimit = 2; });

                printY++;

                mini.Con.Print(29, printY, "Death Penalty:");
                mini.Con.PrintClickable(44, printY, new ColoredString("None", GameLoop.WTN.player.DeathMode == 0 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DeathMode = 0; });
                mini.Con.PrintClickable(49, printY, new ColoredString("Drop Inv", GameLoop.WTN.player.DeathMode == 1 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DeathMode = 1; });
                mini.Con.PrintClickable(58, printY, new ColoredString("Permadeath", GameLoop.WTN.player.DeathMode == 2 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DeathMode = 2; });

                printY++;

                mini.Con.Print(27, printY, "Instadeath Mode: "); 
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("Off", !GameLoop.WTN.player.NightmareMode ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.NightmareMode = false; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("On", GameLoop.WTN.player.NightmareMode ? (Helper.Time() % 10 < 5 ? Color.Red : Color.White) : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.NightmareMode = true; });

                printY++;

                mini.Con.Print(28, printY, "Exp Multiplier:");
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("0", GameLoop.WTN.player.ExpMultiplier == 0 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.ExpMultiplier = 0; });
                mini.Con.PrintClickable(28 + 18, printY, new ColoredString("1", GameLoop.WTN.player.ExpMultiplier == 1 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.ExpMultiplier = 1; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("2", GameLoop.WTN.player.ExpMultiplier == 2 ? Color.ForestGreen : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.ExpMultiplier = 2; });
                mini.Con.PrintClickable(28 + 22, printY, new ColoredString("5", GameLoop.WTN.player.ExpMultiplier == 5 ? Color.AnsiGreen : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.ExpMultiplier = 5; });
                mini.Con.PrintClickable(28 + 24, printY, new ColoredString("10", GameLoop.WTN.player.ExpMultiplier == 10 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.ExpMultiplier = 10; });

                printY++;

                mini.Con.Print(27, printY, "     Coin Pouch: "); 
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("Off", !GameLoop.WTN.player.CoinPouch ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CoinPouch = false; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("On", GameLoop.WTN.player.CoinPouch ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CoinPouch = true; });
                if (GameLoop.WTN.player.CoinPouch)
                    mini.Con.PrintClickable(28 + 23, printY, new ColoredString(GameLoop.WTN.player.CoinPouchDeath ? "Drop on Death" : "Keep on Death", GameLoop.WTN.player.CoinPouchDeath ? Color.Crimson : Color.White, Color.Black), () => { GameLoop.WTN.player.CoinPouchDeath = !GameLoop.WTN.player.CoinPouchDeath; });

                printY++;

                mini.Con.Print(27, printY, "GP to Buy 1 EXP:");
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("0", GameLoop.WTN.player.PayToWin == 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 0; });
                mini.Con.PrintClickable(28 + 18, printY, new ColoredString("1", GameLoop.WTN.player.PayToWin == 1 ? Color.DarkRed : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 1; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("2", GameLoop.WTN.player.PayToWin == 2 ? Color.AnsiRed : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 2; });
                mini.Con.PrintClickable(28 + 22, printY, new ColoredString("5", GameLoop.WTN.player.PayToWin == 5 ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 5; });
                mini.Con.PrintClickable(28 + 24, printY, new ColoredString("10", GameLoop.WTN.player.PayToWin == 10 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 10; });
                mini.Con.PrintClickable(28 + 27, printY, new ColoredString("100", GameLoop.WTN.player.PayToWin == 100 ? (Helper.Time() % 10 < 5 ? Color.Red : Color.White) : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 100; });
                mini.Con.PrintClickable(28 + 31, printY, new ColoredString("1000", GameLoop.WTN.player.PayToWin == 1000 ? Color.AnsiBlackBright : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.PayToWin = 1000; });

                printY++;

                mini.Con.PrintClickableBool(27, printY, "Only Pay to Win: ", ref GameLoop.WTN.player.OnlyPayToWin);
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("OFF", !GameLoop.WTN.player.OnlyPayToWin ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.OnlyPayToWin = false; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("ON", GameLoop.WTN.player.OnlyPayToWin ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.OnlyPayToWin = true; });

                printY++;

                mini.Con.Print(27, printY, "Drop Multiplier:");
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("0", GameLoop.WTN.player.DropMultiplier == 0 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropMultiplier = 0; });
                mini.Con.PrintClickable(28 + 18, printY, new ColoredString("1", GameLoop.WTN.player.DropMultiplier == 1 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropMultiplier = 1; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("2", GameLoop.WTN.player.DropMultiplier == 2 ? Color.ForestGreen : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropMultiplier = 2; });
                mini.Con.PrintClickable(28 + 22, printY, new ColoredString("5", GameLoop.WTN.player.DropMultiplier == 5 ? Color.AnsiGreen : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropMultiplier = 5; });
                mini.Con.PrintClickable(28 + 24, printY, new ColoredString("10", GameLoop.WTN.player.DropMultiplier == 10 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropMultiplier = 10; });
                
                mini.Con.PrintClickable(28 + 27, printY, new ColoredString("Dry Protection", GameLoop.WTN.player.DropModifier == 1 ? Color.Green : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropModifier = GameLoop.WTN.player.DropModifier == 1 ? 0 : 1; });
                mini.Con.PrintClickable(28 + 42, printY, new ColoredString("No RNG Drops", GameLoop.WTN.player.DropModifier == 2 ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.DropModifier = GameLoop.WTN.player.DropModifier == 2 ? 0 : 2; });

                printY++;

                mini.Con.PrintScrollableInteger(21, printY, "Max Kills Per Monster: ", ref GameLoop.WTN.player.KillLimit, false, -1);
                 
                printY++;

                if (GameLoop.WTN.player.InventoryLimit == 20)
                    mini.Con.PrintScrollableInteger(27, printY, "Inventory Slots: ", ref GameLoop.WTN.player.InventoryLimit, false, 1, 20);
                else
                    mini.Con.PrintScrollableInteger(27, printY, "Inventory Slots: ", ref GameLoop.WTN.player.InventoryLimit, false, 1, 20, r: 155 + (20 - GameLoop.WTN.player.InventoryLimit) * 5, g: 0, b: 0);

                printY++;

                mini.Con.PrintClickableBool(29, printY, "Can Use Banks: ", ref GameLoop.WTN.player.CanUseBanks);
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("Yes", GameLoop.WTN.player.CanUseBanks ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CanUseBanks = true; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("No", !GameLoop.WTN.player.CanUseBanks ? Color.AnsiRed : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CanUseBanks = false; });
                 
                printY++;

                mini.Con.PrintClickableBool(29, printY, "Can Use Shops: ", ref GameLoop.WTN.player.CanUseShops);
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("Yes", GameLoop.WTN.player.CanUseShops ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CanUseShops = true; });
                mini.Con.PrintClickable(28 + 20, printY, new ColoredString("No", !GameLoop.WTN.player.CanUseShops ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.CanUseShops = false; });
                mini.Con.PrintClickable(28 + 23, printY, new ColoredString(GameLoop.WTN.player.ShopsAlwaysFullPrice ? "Buys @ 100%" : "Buys @ 50%", GameLoop.WTN.player.ShopsAlwaysFullPrice ? Color.Lime : Color.White, Color.Black), () => { GameLoop.WTN.player.ShopsAlwaysFullPrice = !GameLoop.WTN.player.ShopsAlwaysFullPrice; });

                printY++;

                mini.Con.Print(26, printY, "Farm Growth Time: ");
                mini.Con.PrintClickable(28 + 16, printY, new ColoredString("Slow", GameLoop.WTN.player.FarmGrowthIncrement == 1 ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.FarmGrowthIncrement = 1; });
                mini.Con.PrintClickable(28 + 21, printY, new ColoredString("Normal", GameLoop.WTN.player.FarmGrowthIncrement == 60 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.FarmGrowthIncrement = 60; });
                mini.Con.PrintClickable(28 + 28, printY, new ColoredString("Fast", GameLoop.WTN.player.FarmGrowthIncrement == 1000 ? Color.AnsiGreen : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.FarmGrowthIncrement = 1000; });
                mini.Con.PrintClickable(28 + 33, printY, new ColoredString("Instant", GameLoop.WTN.player.FarmGrowthIncrement == 10000 ? Color.Lime : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.FarmGrowthIncrement = 10000; });

                printY++; 
                 

                /*
                mini.Con.Print(27, printY, "Item Randomizer:");
                mini.Con.PrintClickable(44, printY, new ColoredString("Off", GameLoop.WTN.player.RandomItems == 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomItems = 0; });
                mini.Con.PrintClickable(48, printY, new ColoredString("No Logic", GameLoop.WTN.player.RandomItems == 1 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomItems = 1; });
                mini.Con.PrintClickable(57, printY, new ColoredString("No Logic+", GameLoop.WTN.player.RandomItems == 2 ? Color.Crimson : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomItems = 2; });

                printY++;

                mini.Con.Print(23, printY, "Location Randomizer:");
                mini.Con.PrintClickable(44, printY, new ColoredString("Off", GameLoop.WTN.player.RandomLocs == 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomLocs = 0; });
                mini.Con.PrintClickable(48, printY, new ColoredString("No Logic", GameLoop.WTN.player.RandomLocs == 1 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomLocs = 1; });

                printY++;

                mini.Con.Print(22, printY, "Gathering Randomizer:");
                mini.Con.PrintClickable(44, printY, new ColoredString("Off", GameLoop.WTN.player.RandomGathering == 0 ? Color.White : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomGathering = 0; });
                mini.Con.PrintClickable(48, printY, new ColoredString("No Logic", GameLoop.WTN.player.RandomGathering == 1 ? Color.Red : Color.DarkSlateGray, Color.Black), () => { GameLoop.WTN.player.RandomGathering = 1; });

                printY++;
                */


                mini.Con.Print(22, 40, "White options are considered the default method of play.", Color.White);
                mini.Con.Print(22, 41, "Green options are considered to make the game easier, brighter means even easier.", Color.Lime);
                mini.Con.Print(22, 42, "Red options are considered to make the game harder, and may make the game impossible.", Color.Crimson); 

                mini.Con.PrintClickable(22, 44, "<- Nevermind", () => { MenuMode = "Main"; });

                if (GameLoop.WTN.player.Name != "") {
                    mini.Con.PrintClickable(107, 44, "Begin Adventure ->", () => { 
                        GameLoop.WTN.ManualSave(false); 
                        SwapToGame(false);
                    });
                } else {
                    mini.Con.Print(107, 44, "A Hero Needs a Name");
                }
            } else if (MenuMode == "Load") { 
                Helper.DrawBox(mini.Con, 63, 20, 20, 20, 255, 255, 255, 0, true);

                List<string> saves = new();

                if (!Directory.Exists("./saves/"))
                    Directory.CreateDirectory("./saves/"); 

                saves = Directory.GetFiles("./saves/").ToList();

                for (int i = 0; i < saves.Count; i++) {
                    saves[i] = saves[i].Substring(8)[..^5];
                }


                mini.Con.Print(65, 21, "Choose a Character");
                mini.Con.Print(64, 22, "--------------------");

                for (int i = 0; i < 16; i++) {
                    if (saves.Count > i) {
                        mini.Con.PrintClickable(65, 23 + i, saves[i].Align(HorizontalAlignment.Center, 18), () => {
                            Player p = Helper.DeserializeFromFile<Player>("./saves/" + saves[i] + ".json");
                            GameLoop.WTN.player = p;

                            PerformUpdateMaintenance();

                            SwapToGame(true);
                        });
                    } else {
                        mini.Con.Print(65, 23 + i, "(Empty Save Slot)", Color.DarkSlateGray);
                    }
                }


                mini.Con.Print(64, 39, "--------------------");
                mini.Con.PrintClickable(68, 40, "Back to Menu", () => { MenuMode = "Main"; });
            } else if (MenuMode == "Credits") { 
                Point mousePos = new MouseScreenObjectState(mini.Con, GameHost.Instance.Mouse).CellPosition;
                Helper.DrawBox(mini.Con, 20, 10, 105, 34, 255, 255, 255, 0, true);

                mini.Con.DrawLine(new Point(73, 11), new Point(73, 42), 179, Color.White); 

                // Music
                int showMusic = 20; 
                if (MusicCredits.Count > showMusic) {
                    if (Helper.ScrolledDown() && mousePos.X < 73) { MusicCreditsTop = Helper.QuantitySelector(MusicCreditsTop, MusicCredits.Count - showMusic); }
                    if (Helper.ScrolledUp() && mousePos.X < 73) { MusicCreditsTop = Helper.QuantitySelector(MusicCreditsTop, MusicCredits.Count - showMusic, true); }
                } else {
                    MusicCreditsTop = 0;
                }
                
                mini.Con.Print(21, 11, "Music Credits".Align(HorizontalAlignment.Center, 52));
                mini.Con.DrawLine(new Point(21, 12), new Point(125, 12), 196, Color.White);

                for (int mus = MusicCreditsTop; mus < MusicCredits.Count && mus < MusicCreditsTop + showMusic; mus++) {
                    mini.Con.Print(22, 13 + (mus - MusicCreditsTop), MusicCredits[mus]);
                }
                
                // Other Credits
                int showOther = 20; 
                if (OtherCredits.Count > showOther) {
                    if (Helper.ScrolledDown() && mousePos.X > 73) { OtherCreditsTop = Helper.QuantitySelector(OtherCreditsTop, OtherCredits.Count - showOther); }
                    if (Helper.ScrolledUp() && mousePos.X > 73) { OtherCreditsTop = Helper.QuantitySelector(OtherCreditsTop, OtherCredits.Count - showOther, true); }
                } else {
                    OtherCreditsTop = 0;
                }
                
                mini.Con.Print(74, 11, "Other Credits".Align(HorizontalAlignment.Center, 52));  

                for (int mus = OtherCreditsTop; mus < OtherCredits.Count && mus < OtherCreditsTop + showOther; mus++) {
                    mini.Con.Print(75, 13 + (mus - OtherCreditsTop), OtherCredits[mus]);
                }



                
                mini.Con.DrawLine(new Point(21, 43), new Point(125, 43), 196, Color.White);
                mini.Con.PrintClickable(22, 44, "<- Back to Menu", () => { MenuMode = "Main"; });
            }
        }

        public void Input(UI_EmbeddedMini mini) { } 
        public void Close(UI_EmbeddedMini mini) {  } 
        public void Reset() {  }


        public void SetupTheBG(UI_EmbeddedMini mini) {
            menuXP = new FileStream("./door.xp", FileMode.Open);
            menuImage = SadRex.Image.Load(menuXP);


            ColoredGlyph[] cells = new ColoredGlyph[86 * 48];

            for (int i = 0; i < menuImage.Layers[0].Cells.Count && i < 86 * 48; i++) {
                var cell = menuImage.Layers[0].Cells[i];
                Color convertedFG = new(cell.Foreground.R, cell.Foreground.G, cell.Foreground.B);
                Color convertedBG = new(cell.Background.R, cell.Background.G, cell.Background.B);

                cells[i] = new ColoredGlyph(Color.Transparent, convertedFG, menuImage.Layers[0].Cells[i].Character);
            }

            menuBackdrop = new Console(new CellSurface(86, 48, cells), GameLoop.SquareFont, new Point(12, 12));
            menuBackdrop.UsePixelPositioning = true;
            menuBackdrop.Position = new Point(9, 13); 

            mini.Win.Children.Insert(0, menuBackdrop);  

            menuXP.Close();
        }

        public void SwapToGame(bool loading) { 
            if (GameLoop.WTN.player.RandomItems != 0) {
                GameLoop.WTN.RemapItems(loading);
            }

            if (!loading && SkippingTutorialIsland > 0) {
                GameLoop.WTN.player.NavLoc = "WTN_Plaza";
                GameLoop.WTN.player.NavRespawn = "WTN_Plaza";
                
                if (GameLoop.WTN.player.QuestLog.TryGetValue("TII_OnTheJobTraining", out QuestStatus? training)) { 
                    training.CurrentStage = 90; 
                }

                if (!GameLoop.WTN.player.AllSongsUnlocked) {
                    GameLoop.WTN.player.UnlockedSongs.Add("Gymnopedie 1");
                }

                if (SkippingTutorialIsland == 2) {
                    if (GameLoop.WTN.ItemLibrary.TryGetValue("capeCompTI", out Item? cape)) {
                        foreach (var kv in GameLoop.WTN.player.Skills) {
                            kv.Value.Level = 9;
                            GameLoop.WTN.player.TryGrantExp(kv.Key, kv.Value.EXPNeeded(), null, null, GameLoop.WTN.player.OnlyPayToWin);
                        }

                        GameLoop.WTN.player.CollectionLogClues.TryAdd("casketTutorial", new("casketTutorial")); 
                        if (GameLoop.WTN.ItemLibrary.TryGetValue("casketTutorial", out Item? cask)) {
                            foreach (var kv in cask.DropTable) {
                                GameLoop.WTN.player.CollectionLogClues["casketTutorial"].DropsObtained.TryAdd(kv.ItemID, 1);
                            }
                        }

                        GameLoop.WTN.player.CollectionLogBoss.TryAdd("bossZombie", new("bossZombie")); 
                        if (GameLoop.WTN.BossLibrary.TryGetValue("bossZombie", out BossFight? boss)) {
                            foreach (var kv in boss.DropTable) {
                                GameLoop.WTN.player.CollectionLogBoss["bossZombie"].DropsObtained.TryAdd(kv.ItemID, 1);
                            }
                        }

                        GameLoop.WTN.player.TryPickup(cape, 1);

                        GameLoop.WTN.ManualSave(false);
                    }
                }
            }

            if (!loading && SkippingTutorialIsland == 0) {
                GameLoop.WTN.Log.AddMessage("Welcome, adventurer! To get started, click the (N)PC tab on the right side of your screen and click Tutorial Guy to speak to him.", Color.Yellow);
            }

            GameLoop.UIManager.mainMenu.Win.IsVisible = false;
            GameLoop.UIManager.WTNWrap.Win.IsVisible = true;
            MenuMode = "Main";
            GameLoop.WTN.TimeLastTicked = Helper.Time();

            GameLoop.SoundManager.CurrentSong = "";
            GameLoop.SoundManager.music.StopAllSounds();
            GameLoop.SoundManager.PickMusic();

            PerformUpdateMaintenance();

            if (GameLoop.WTN.player.ActiveTH.Where(o => o.Resolved).ToList().Count > 0) {
                GameLoop.WTN.Log.AddMessage("You have items waiting to be collected from the Trade Hall.");
            }
        }

        public void PerformUpdateMaintenance() {
            HardcodedFarmPatches.InitPatches(GameLoop.WTN.player.FarmingPatches);
            GameLoop.WTN.TryAddSkills(); 
            GameLoop.WTN.TryAddQuests(); 
            GameLoop.WTN.TrySetupLogs();
        }
    }
}
