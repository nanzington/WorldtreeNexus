namespace WorldtreeNexus.DataTypes {
    public class QuestStage {
        public string Description = "";
        public string QuickDesc = "";
        public int LeadsToStage = 0;

        public string ProgressType = "";
        public string MiscString = "";
        public int MiscInt = 0;


        public QuestStage(string desc, int toStage, string prog = "", string misc = "", int num = 0, string quickDesc = "") {
            Description = desc;
            QuickDesc = quickDesc;
            LeadsToStage = toStage;

            ProgressType = prog;
            MiscString = misc;
            MiscInt = num;
        } 
    }
}
