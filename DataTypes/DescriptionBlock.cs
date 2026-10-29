namespace WorldtreeNexus.DataTypes {
    public class DescriptionBlock {
        public string Description = "";
        public List<Requirement> Reqs = new();

        public DescriptionBlock(string text, List<Requirement>? reqs = null) {
            Description = text;

            if (reqs != null) {
                Reqs = reqs;
            }
        }

        public bool AllReqsMet() {
            bool allMet = true;

            foreach (var req in Reqs) {
                if (!req.CheckRequirement(GameLoop.WTN.player, false, true)) {
                    allMet = false;
                }
            }

            return allMet;
        }
    }
}
