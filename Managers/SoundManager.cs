using WorldtreeNexus.UI;
using IrrKlang;
using static WorldtreeNexus.Music;
using System.Resources;
using System.Globalization;
using System.Collections;
using MeltySynth; 

namespace WorldtreeNexus.Managers {
    public class SoundManager {        
        public ISoundEngine engine = new();
        public ISoundEngine music = new();

        public Dictionary<string, ISound> PlayingSounds = new();
        public string CurrentSong = "None";
        public bool MusicEnabled = true; 
        public bool Looping = false;

        public Dictionary<string, ISoundSource> Songs = new(); 
        
        public SoundManager() {
            engine.SoundVolume = 0.05f;
            music.SoundVolume = 0.05f; 
        }

        public void LoadMusic() {
            ResourceManager Resources = new ResourceManager(typeof(Music));
            ResourceSet? resSongs = Resources.GetResourceSet(CultureInfo.InvariantCulture, true, true);
            
            if (resSongs != null) {
                foreach (DictionaryEntry entry in resSongs) {
                    if (entry.Key != null && entry.Value != null) {

                        UnmanagedMemoryStream data = (UnmanagedMemoryStream) entry.Value;
                        byte[] byteArr = new byte[data.Length];
                        data.ReadExactly(byteArr, 0, byteArr.Length);

                        Songs.Add(entry.Key.ToString(), music.AddSoundSourceFromMemory(byteArr, entry.Key.ToString())); 
                    }
                }
            }
        }


        public void PlaySound(string name) { 
            if (Songs.ContainsKey(name)) {
                var test = music.Play2D(Songs[name], false, false, false);
                if (!PlayingSounds.ContainsKey(name))
                    PlayingSounds.Add(name, test);
            }
        }

        public void StopSound(string name) {
            if (PlayingSounds.ContainsKey(name)) {
                PlayingSounds[name].Stop();
                PlayingSounds.Remove(name);
            }
        }

        public void UpdateSounds() {
            if (GameLoop.GlobalOptions != null) {
                music.SoundVolume = (float) GameLoop.GlobalOptions.MusicVolume;
            }

            foreach (KeyValuePair<string, ISound> kv in PlayingSounds) {
                if (kv.Value.Finished)
                    PlayingSounds.Remove(kv.Key);
            }

            if (PlayingSounds.Count == 0 && MusicEnabled) {
                PickMusic();
            }
        }


        public void PickMusic(string forced = "", bool menu = false) { 
            string NewSong = CurrentSong;
            if (MusicEnabled) {
                List<KeyValuePair<string, ISoundSource>> unlocked = Songs.Where(o => GameLoop.WTN.player.UnlockedSongs.Contains(o.Key) || GameLoop.WTN.player.AllSongsUnlocked || menu).ToList();
                
                if (GameLoop.WTN.player.AllSongsUnlocked) {
                    while (NewSong == CurrentSong && Songs.Count > 1 && forced == "" && !(Looping || GameLoop.WTN.player.MusicMode == "Auto")) {
                        NewSong = Songs.Keys.ToList()[GameLoop.rand.Next(Songs.Keys.Count)];
                    }
                } else { 
                    while (NewSong == CurrentSong && unlocked.Count > 1 && forced == "" && !(Looping || GameLoop.WTN.player.MusicMode == "Auto")) {
                        NewSong = unlocked[GameLoop.rand.Next(unlocked.Count)].Key;
                    }
                }

                if (forced != "") {
                    NewSong = forced; 
                }
                
                if (Songs.ContainsKey(NewSong)) {
                    var test = music.Play2D(Songs[NewSong], false, false, false);
                    if (!PlayingSounds.ContainsKey(NewSong)) {
                        PlayingSounds.Add(NewSong, test);
                        CurrentSong = NewSong;

                        if (SidebarManager.SidebarMenu == "Music") { 
                            int scrollTop = 0;
                            List<KeyValuePair<string, IrrKlang.ISoundSource>> songs = Songs.OrderBy(o => o.Key).ToList();

                            for (int i = 0; i < songs.Count; i++) {
                                if (CurrentSong == songs[i].Key) {
                                    scrollTop = i - 9;
                                }
                            }

                            SidebarManager.SidebarScrollTop = Math.Clamp(scrollTop, 0, songs.Count - 18);
                        }
                    }
                }
            }
            else {
                music.StopAllSounds();
                CurrentSong = "None";
            }
        }
    }
}
