using System.Media;
using System.IO;

namespace CyberSecurityAwarenessBotGUI.Services
{
    public class AudioPlayer
    {
        private readonly string _audioFilePath;

        public AudioPlayer(string audioFilePath)
        {
            _audioFilePath = audioFilePath;
        }

        public void PlayGreeting()
        {
            if (File.Exists(_audioFilePath))
            {
                using (SoundPlayer player = new SoundPlayer(_audioFilePath))
                {
                    player.Play();
                }
            }
            else
            {
                // Log or handle the error if the audio file is not found
                System.Diagnostics.Debug.WriteLine($"Audio file not found: {_audioFilePath}");
            }
        }
    }
}