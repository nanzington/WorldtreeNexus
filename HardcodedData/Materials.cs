using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.HardcodedData {
    public static class Materials {
        public static Dictionary<string, string> ElementalWeaknesses = new Dictionary<string, string>() {
            {"Metal", "Fire"}, {"Water", "Earth"}, {"Wood", "Metal"}, {"Fire", "Water"}, {"Earth", "Wood"}
        };

        public static Dictionary<string, string> ElementalStrengths = new Dictionary<string, string>() {
            {"Metal", "Earth"}, {"Water", "Metal"}, {"Wood", "Water"}, {"Fire", "Wood"}, {"Earth", "Fire"}
        };


        // Woods, these don't really use the exp for anything yet but it's not optional so they're just 1 for now
        public static List<string> WoodNames = [ "Poplar", "Elm", "Walnut", "Holly", "Acacia", "Birch", "Hickory", "Bloodwood", "Camatillo", "Katalox" ];
        public static MaterialDef Poplar =    new("Poplar",    ColorLib.Poplar,    tier: 1,  lv:  1, cost:    10, exp: 1, desc: "", extraMat: "Copper");
        public static MaterialDef Elm =       new("Elm",       ColorLib.Elm,       tier: 2,  lv: 10, cost:    30, exp: 1, desc: "", extraMat: "Bronze");
        public static MaterialDef Walnut =    new("Walnut",    ColorLib.Walnut,    tier: 3,  lv: 20, cost:    50, exp: 1, desc: "", extraMat: "Iron");
        public static MaterialDef Holly =     new("Holly",     ColorLib.Holly,     tier: 4,  lv: 30, cost:   100, exp: 1, desc: "", extraMat: "Silver");
        public static MaterialDef Acacia =    new("Acacia",    ColorLib.Acacia,    tier: 5,  lv: 40, cost:   300, exp: 1, desc: "", extraMat: "Gold");
        public static MaterialDef Birch =     new("Birch",     ColorLib.Birch,     tier: 6,  lv: 50, cost:   500, exp: 1, desc: "", extraMat: "Platinum");
        public static MaterialDef Hickory =   new("Hickory",   ColorLib.Hickory,   tier: 7,  lv: 60, cost:  1000, exp: 1, desc: "", extraMat: "Steel");
        public static MaterialDef Bloodwood = new("Bloodwood", ColorLib.Bloodwood, tier: 8,  lv: 70, cost:  3000, exp: 1, desc: "", extraMat: "Cobalt");
        public static MaterialDef Camatillo = new("Camatillo", ColorLib.Camatillo, tier: 9,  lv: 80, cost:  5000, exp: 1, desc: "", extraMat: "Tungsten");
        public static MaterialDef Katalox =   new("Katalox",   ColorLib.Katalox,   tier: 10, lv: 90, cost: 10000, exp: 1, desc: "", extraMat: "Titanium");
        public static List<MaterialDef> Woods = [ Poplar, Elm, Walnut, Holly, Acacia, Birch, Hickory, Bloodwood, Camatillo, Katalox ];

        // Metals
        public static List<string> MetalNames = [ "Copper", "Bronze", "Iron", "Silver", "Gold", "Platinum", "Steel", "Cobalt", "Tungsten", "Titanium" ];
        public static MaterialDef Tutorial = new("Tutorial", Color.SpringGreen, tier:  2, lv:  1, cost:   100, exp:   40, desc: "slight"); 
        public static MaterialDef Copper =   new("Copper",   ColorLib.Copper,   tier:  1, lv:  1, cost:    15, exp:   15, desc: "minimal"); 
        public static MaterialDef Bronze =   new("Bronze",   ColorLib.Bronze,   tier:  2, lv: 10, cost:    45, exp:   40, desc: "slight");  
        public static MaterialDef Iron =     new("Iron",     ColorLib.Iron,     tier:  3, lv: 20, cost:    90, exp:   75, desc: "adequate"); 
        public static MaterialDef Silver =   new("Silver",   ColorLib.Silver,   tier:  4, lv: 30, cost:   180, exp:  120, desc: "good");
        public static MaterialDef Gold =     new("Gold",     ColorLib.Gold,     tier:  5, lv: 40, cost:   360, exp:  170, desc: "great"); 
        public static MaterialDef Platinum = new("Platinum", ColorLib.Platinum, tier:  6, lv: 50, cost:   720, exp:  240, desc: "shining");  
        public static MaterialDef Steel =    new("Steel",    ColorLib.Steel,    tier:  7, lv: 60, cost:  1500, exp:  350, desc: "excellent"); 
        public static MaterialDef Cobalt =   new("Cobalt",   ColorLib.Cobalt,   tier:  8, lv: 70, cost:  3000, exp:  500, desc: "incredible"); 
        public static MaterialDef Tungsten = new("Tungsten", ColorLib.Tungsten, tier:  9, lv: 80, cost:  6000, exp:  750, desc: "amazing");
        public static MaterialDef Titanium = new("Titanium", ColorLib.Titanium, tier: 10, lv: 90, cost: 12000, exp: 1000, desc: "unbelievable");
        public static List<MaterialDef> Metals = [ Copper, Bronze, Iron, Silver, Gold, Platinum, Steel, Cobalt, Tungsten, Titanium ];

        // Jewels
        public static List<int> JewelCosts = [ 50, 100, 300, 500, 1_000, 3_000, 5_000, 10_000, 30_000, 50_000 ];
        public static List<string> JewelNames = [ "Quartz", "Garnet", "Emerald", "Sapphire", "Ruby", "Amethyst", "Morganite", "Heliodor", "Diamond", "Obsidian" ];
        public static MaterialDef Quartz =    new("Quartz",    Color.DarkGray,     tier:  1, lv:  1, cost:    50, exp:  10, desc: "clear", extraMat: "Copper");
        public static MaterialDef Garnet =    new("Garnet",    Color.Orange,       tier:  2, lv: 10, cost:   100, exp:  20, desc: "fiery", extraMat: "Bronze");
        public static MaterialDef Emerald =   new("Emerald",   Color.Lime,         tier:  3, lv: 20, cost:   300, exp:  30, desc: "vibrant", extraMat: "Iron");
        public static MaterialDef Sapphire =  new("Sapphire",  Color.DodgerBlue,   tier:  4, lv: 30, cost:   500, exp:  40, desc: "oceanic", extraMat: "Silver");
        public static MaterialDef Ruby =      new("Ruby",      Color.Crimson,      tier:  5, lv: 40, cost:  1000, exp:  50, desc: "bloody", extraMat: "Gold");
        public static MaterialDef Amethyst =  new("Amethyst",  Color.MediumPurple, tier:  6, lv: 50, cost:  3000, exp:  60, desc: "royal", extraMat: "Platinum");
        public static MaterialDef Morganite = new("Morganite", Color.HotPink,      tier:  7, lv: 60, cost:  5000, exp:  70, desc: "lovely", extraMat: "Steel");
        public static MaterialDef Heliodor =  new("Heliodor",  Color.Yellow,       tier:  8, lv: 70, cost: 10000, exp:  80, desc: "sunny", extraMat: "Cobalt");
        public static MaterialDef Diamond =   new("Diamond",   Color.White,        tier:  9, lv: 80, cost: 30000, exp:  90, desc: "elegant", extraMat: "Tungsten");
        public static MaterialDef Obsidian =  new("Obsidian",  Color.DimGray,      tier: 10, lv: 90, cost: 50000, exp: 100, desc: "ominous", extraMat: "Titanium");
        public static List<MaterialDef> Jewels = [ Quartz, Garnet, Emerald, Sapphire, Ruby, Amethyst, Morganite, Heliodor, Diamond, Obsidian ];


        // Fish - Exp generally (10 * tier) + 50%, only really used for cooking
        public static MaterialDef Minnow = new("Minnow", Color.SpringGreen, tier: 1, lv: 1, cost: 5, exp: 15, desc: "minnow", simple: "Minnow");
        public static MaterialDef Bluegill = new("Bluegill", Color.SeaGreen, tier: 1, lv: 5, cost: 10, exp: 23, desc: "bluegill", simple: "Bluegill");
        public static MaterialDef Pollock = new("Pollock", Color.DarkGray, tier: 1, lv: 1, cost: 5, exp: 15, "pollock", simple: "Pollock");
        public static MaterialDef Cod = new("Cod", ColorLib.PastelYellow, tier: 1, lv: 5, cost: 10, exp: 23, "cod", simple: "Cod");
        public static List<MaterialDef> Fish = [ Minnow, Bluegill, Pollock, Cod ];


        // Leathers
        public static MaterialDef Leather = new("Leather", new Color(205, 127, 50), tier: 1, lv: 1, cost: 20, exp: 15, desc: "minimal", simple: "leatherSoft");
        public static MaterialDef Hardleather = new("Hardleather", new(175, 97, 20), tier: 2, lv: 10, cost: 40, exp: 30, desc: "slight", simple: "leatherHard"); 
        public static MaterialDef Studded = new("Studded", new(175, 97, 20), tier: 3, lv: 20, cost: 110, exp: 45, desc: "adequate"); 
        public static List<MaterialDef> Leathers = [ Leather, Hardleather ];


        // Oils. Price and exp set by ingredients to make via alchemy (cost divided by 10). Exp only really used for when the oil is made, because bone exp is just multiplier by (tier * 10%)
        public static MaterialDef OilInitiate =   new("Initiate",   new Color(165, 125, 0), tier:  1, lv:   1, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilAcolyte =    new("Acolyte",    new Color(175, 135, 0), tier:  2, lv:  10, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilDevotee =    new("Devotee",    new Color(185, 145, 0), tier:  3, lv:  20, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilDisciple =   new("Disciple",   new Color(195, 155, 0), tier:  4, lv:  30, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilAdept =      new("Adept",      new Color(205, 165, 0), tier:  5, lv:  40, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilCleric =     new("Cleric",     new Color(215, 175, 0), tier:  6, lv:  50, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilPriest =     new("Priest",     new Color(225, 185, 0), tier:  7, lv:  60, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilBishop =     new("Bishop",     new Color(235, 195, 0), tier:  8, lv:  70, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilHierophant = new("Hierophant", new Color(245, 205, 0), tier:  9, lv:  80, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilExarch =     new("Exarch",     new Color(255, 215, 0), tier: 10, lv:  90, cost: 20, exp: 10, desc: "");
        public static MaterialDef OilGods =       new("Gods",       new Color(255, 255, 0), tier: 11, lv: 100, cost: 20, exp: 10, desc: ""); 
        public static List<MaterialDef> Oils = [ OilInitiate, OilAcolyte, OilDevotee, OilDisciple, OilAdept, OilCleric, OilPriest, OilBishop, OilHierophant, OilExarch, OilGods ];


        // Bones. Name is item name, SimpleName is ID, exp is Prayer exp when buried. Not really sure what purpose tier/level serves except as a guide for what should drop it
        // Cost approximately set to exp * (3 * tier)
        public static MaterialDef BonesRegular = new("Bones",     Color.AntiqueWhite, tier:   1, lv:   1, cost: 15, exp: 5, desc: "", simple: "bonesRegular");
        public static MaterialDef BonesBig =     new("Big bones", Color.AntiqueWhite, tier: 1.5, lv:   5, cost: 30, exp: 10, desc: "", simple: "bonesBig");
        public static List<MaterialDef> Bones = [ BonesRegular, BonesBig ];
    }
}
