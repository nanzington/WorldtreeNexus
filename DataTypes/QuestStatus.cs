using System;
using System.Collections.Generic;
using System.Text;

namespace WorldtreeNexus.DataTypes {
    public class QuestStatus {
        public string QuestID = "";
        public int CurrentStage = -1;
        public int NumTracker = 0; // If you have to do a thing multiple times, like kill a monster, gather an item, etc
          
        public QuestStatus(string id, int stage) {
            QuestID = id;
            CurrentStage = stage;
        }
    }
}
