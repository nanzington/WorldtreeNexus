namespace WorldtreeNexus.DataTypes {
    public class DialogueChoice {
        public string Text = "";
        public int LeadsToStage = 0;

        public bool SilentChange = false; // For returning back to earlier dialogue without repeating it
         
        public List<Requirement>? ClickReqs = null;
        public bool ShowAnyways = false;

        public string TeleportTo = "";
        public bool SetSpawnToo = false;

        public List<string> Cutscenes = new();


        public DialogueChoice(string t, int stage, List<Requirement>? reqs = null, bool showAnyways = false, string tele = "", bool spawn = false, bool silent = false) {
            Text = t;
            LeadsToStage = stage;
             
            TeleportTo = tele;
            SetSpawnToo = spawn;

            ClickReqs = reqs;
            ShowAnyways = showAnyways; 

            SilentChange = silent;
        }

        public bool CanClick() {
            if (ClickReqs != null && ClickReqs.Count > 0) {
                for (int i = 0; i < ClickReqs.Count; i++) {
                    if (!ClickReqs[i].CheckRequirement(GameLoop.WTN.player, true, true)) {
                        return false;
                    }
                } 
            }

            return true;
        }

        public void ConsumeItemsIfNeeded(Player p) {
            if (ClickReqs != null && ClickReqs.Count > 0) {
                for (int i = 0; i < ClickReqs.Count; i++) {
                    if (ClickReqs[i].RequirementType == "Item") {
                        if (ClickReqs[i].MiscString == "Gold" && ClickReqs[i].ConsumeItem) {
                            p.TakeGold(ClickReqs[i].MiscInt);
                        } else {
                            if (ClickReqs[i].ConsumeItem){
                                p.ConsumeItems(new() { ClickReqs[i].MiscString + "," + ClickReqs[i].MiscInt}, true, true);
                            }
                        }
                    }
                }
            }
        }
    }
}
