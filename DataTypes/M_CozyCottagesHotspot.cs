using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class M_CozyCottagesHotspot {
        public string Name = "";
        public string ID = "";

        public bool Repaired = false;
        public int PlanksNeeded = 0; // Also implicitly requires 2x this many nails of the same tier
        public int BarsNeeded = 0;
        public int FabricNeeded = 0; // Come up with some scheme of tiered fabrics, maybe the things to craft mage armor like spidersilk and batwing etc. For now just requires bolts of cloth
        public int CandlesNeeded = 0; // Maybe tier this somehow too, for now just always default to normal white candles
        
        [JsonConstructor]
        public M_CozyCottagesHotspot() { }

        public M_CozyCottagesHotspot(string id, string name, int planks, int bars, int fabric, int candles) {
            Name = name;
            ID = id;
            
            PlanksNeeded = planks;
            BarsNeeded = bars;
            FabricNeeded = fabric;
            CandlesNeeded = candles;
        }

        public M_CozyCottagesHotspot(M_CozyCottagesHotspot other) {
            Name = other.Name;
            ID = other.ID;
            
            PlanksNeeded = other.PlanksNeeded;
            BarsNeeded = other.BarsNeeded;
            FabricNeeded = other.FabricNeeded;
            CandlesNeeded = other.CandlesNeeded;
        }


        // 1 - Poplar plank, copper nails, copper bar
        // 10 - Elm plank, bronze nails, bronze bar
        // 20 - Walnut plank, iron nails, iron bar
        // 30 - Holly plank, silver nails, silver bar
        // 40 - Acacia plank, gold nails, gold bar
        // 50 - Birch plank, platinum nails, platinum bar
        // 60 - Hickory plank, steel nails, steel bar
        // 70 - Bloodwood plank, cobalt nails, cobalt bar
        // 80 - Camatillo plank, tungsten nails, tungsten bar
        // 90 - Katalox plank, titanium nails, titanium bar

        // Exp drops: Total hotspot points, divide by 5 to get average points per hotspot, divide by 10 to get average tier, floor, add 1, multiply by 450 exp.
        // Thus doing all level 1 materials gives you 5 / 5 = 1 / 10 = 0.1, floor = 0 + 1 base = 1 * 450 = 450 exp, approximately 0.49 gp/exp if buying ingredients at market value
        // All level 20 materials gives you 100 / 5 = 20 / 10 = 2, floor = 2 + 1 base = 3 * 300 = 1350 exp, approximately 2.11 gp/exp if buying ingredients at market value
        // All level 90 materials gives you 450 / 5 = 90 / 10 = 9, floor = 9 + 1 base = 10 * 300 = 4500 exp, for approximately 4.62 gp/exp if buying ingredients at market value

        public List<string> NeededItems(int tier) {
            List<string> mats = new(); 

            List<string> planks = [ "plankPoplar", "plankElm", "plankWalnut", "plankHolly", "plankAcacia", "plankBirch", "plankHickory", "plankBloodwood", "plankCamatillo", "plankKatalox" ];
            List<string> bars = [ "barCopper", "barBronze", "barIron", "barSilver", "barGold", "barPlatinum", "barSteel", "barCobalt", "barTungsten", "barTitanium" ];
            List<string> nails = [ "nailsCopper", "nailsBronze", "nailsIron", "nailsSilver", "nailsGold", "nailsPlatinum", "nailsSteel", "nailsCobalt", "nailsTungsten", "nailsTitanium" ];

            tier = Math.Clamp(tier, 0, planks.Count - 1);

            if (PlanksNeeded > 0) { mats.Add(planks[tier] + "," + PlanksNeeded); }
            if (PlanksNeeded > 0) { mats.Add(nails[tier] + "," + (PlanksNeeded * 2)); }
            if (BarsNeeded > 0) { mats.Add(bars[tier] + "," + BarsNeeded); }
            if (FabricNeeded > 0) { mats.Add("clothBolt," + FabricNeeded); }
            if (CandlesNeeded > 0) { mats.Add("candle," + CandlesNeeded); }

            return mats;
        }
    }
}
