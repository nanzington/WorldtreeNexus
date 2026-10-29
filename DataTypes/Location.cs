using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class Location {
        public string DisplayName = "";
        public string ID = "";
        public string Region = ""; 

        public List<DescriptionBlock> DescriptionBlocks = new();
        public bool IsBank = false;

        public string DigItem = "";
        public int DigCooldown = 5;
        
        [JsonIgnore]
        public double LastDigTime = 0;

        public bool Dark = false;
        public string Hazard = "";

        public int MazeTile = -1;
        public string MazeMap = "";
        public bool MazeLandmark = false;

        public string MinigameID = "";

        public List<Connection> ConnectedLocations = new();

        public List<string> GatheringSpots = new();
        public List<GatheringTile> LocalGathers = new();

        public List<string> ProcessingStations = new();
        public List<ProcessingStation> TempStations = new();

        public List<ItemSpot> ItemSpawns = new();

        public List<Item> ItemsHere = new();

        public List<string> AreaMonsters = new();
        public List<AreaMonster> MonstersHere = new();
        public string BossHere = "";

        public List<string> NPCsHere = new();

        public List<string> ShopItemsHere = new();
        public double ShopPriceMultiplier = 1.0;

        public List<string> FarmingPatchesHere = new(); 

        public string CozyTown = "";
        public List<string> CCHotspots = new();
        public string PlayerHomeHere = "";

        public string SongHere = "";

        [JsonIgnore]
        public Dictionary<int, string> TrapsDown = new();

        public Location(string id, string name, string region) {
            ID = id;
            DisplayName = name;
            Region = region;
        }


        public void HotColdSearch(List<HotColdResult> results, int depth, string target) {
            if (ID == target)
                results.Add(new(ID, depth));

            for (int i = 0; i < results.Count; i++) {
                if (results[i].MapID == target && depth > results[i].Depth) {
                    return;
                }
            }

            if (depth < 10 && ID != target) {
                foreach (var kv in ConnectedLocations) {
                    if (GameLoop.WTN.Atlas.TryGetValue(kv.Destination, out Location? dest)) { dest.HotColdSearch(results, depth + 1, target); }
                    if (kv.CheckFailDest != "" && GameLoop.WTN.Atlas.TryGetValue(kv.CheckFailDest, out Location? failDest)) { failDest.HotColdSearch(results, depth + 1, target); }
                }
            }
        }
    }
}
