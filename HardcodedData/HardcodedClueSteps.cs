using WorldtreeNexus.DataTypes;

namespace WorldtreeNexus.Hardcodes {
    public static class HardcodedClueSteps {
        public static void InitClues(Dictionary<string, ClueStep> clueLib) {
            List<ClueStep> toAdd = new();

            // Tutorial Steps, all take place on Tutorial Island
            toAdd.Add(new ClueStep("T_SpeakWizard", "Tutorial", "Speak", "TI_WizardHut", "What do you think he's smoking in that pipe?", "tiWizardAtrel"));
            toAdd.Add(new ClueStep("T_SpeakFarmingTutor", "Tutorial", "Speak", "TI_Main", "How honest can the work really be with only three plots of land?", "guyFarming"));
            toAdd.Add(new ClueStep("T_DigCuy", "Tutorial", "Dig", "TI_Cuy", "Dig somewhere allegedly being 'supervised'."));
            toAdd.Add(new ClueStep("T_DigStart", "Tutorial", "Dig", "TI_StartHut", "Dig where it all began."));
            toAdd.Add(new ClueStep("T_EmoteBank", "Tutorial", "Emote", "TI_Bank", "Cry in the bank. Equip a copper helm, leather chaps, and a poplar shortbow.", "Cry", "helmCopper", "chapsLeather", "shortbowPoplar"));
            toAdd.Add(new ClueStep("T_EmoteTemple", "Tutorial", "Emote", "TI_Temple", "Yawn in the temple. Equip a leather coif, copper platebody, and copper dagger.", "Yawn", "coifLeather", "platebodyCopper", "daggerCopper"));
            toAdd.Add(new ClueStep("T_AnagramCombatGuy", "Tutorial", "Anagram", "TI_Cuy", "The anagram reveals who to speak to next: BAM! GOT CUY", "guyCombat"));
            toAdd.Add(new ClueStep("T_AnagramTutorialGuy", "Tutorial", "Anagram", "TI_StartHut", "The anagram reveals who to speak to next: TRY A GUI, LOUT", "guyTutorial"));
            toAdd.Add(new ClueStep("T_GatherCrates", "Tutorial", "Gather", "TI_GeneralStore", "Am I allowed to rummage through these? I guess there's no employee around to stop me!", "clueCrates"));
            toAdd.Add(new ClueStep("T_GatherMinnow", "Tutorial", "Gather", "TI_Docks", "Look for a really strange minnow.", "fishPondShallow"));

            // Beginner Steps, all take place in the Worldtree Nexus
            toAdd.Add(new ClueStep("B_SpeakWizard", "Beginner", "Speak", "TI_WizardHut", "What do you think he's smoking in that pipe?", "tiWizardAtrel"));
            
            // Easy Steps
            toAdd.Add(new ClueStep("E_SpeakWizard", "Easy", "Speak", "TI_WizardHut", "What do you think he's smoking in that pipe?", "tiWizardAtrel"));
            
            // Medium Steps
            toAdd.Add(new ClueStep("M_SpeakWizard", "Medium", "Speak", "TI_WizardHut", "What do you think he's smoking in that pipe?", "tiWizardAtrel"));
            

            for (int i = 0; i < toAdd.Count; i++) {
                clueLib.TryAdd(toAdd[i].ID, toAdd[i]);
            }
        }
    }
}
