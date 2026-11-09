using Steamworks;
using Steamworks.Data;

namespace WorldtreeNexus.Managers {
    public static class SteamManager {
        public static bool SteamInitialized = true;

        public static void InitSteamClient() {
            try {
                SteamClient.Init(5557650);
            } catch (Exception e) {
                SteamInitialized = false;
            }
        }


        public static bool TryUnlockAchievement(string ID) {
            if (SteamInitialized) {
                var achieve = new Achievement(ID); 
                if (!achieve.State) {
                    return achieve.Trigger();
                }
            }

            return false;
        }
    }
}
