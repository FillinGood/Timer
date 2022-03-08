using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Timer;
public class MediaPlayer : IDisposable {
    private SoundPlayer Player { get; }
    private MemoryStream Sound { get; }
    private bool IsPlaying { get; set; }
    
    public MediaPlayer() {
        using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Timer.sound.wav");
        if(stream == null)
            throw new Exception("unable to load sound");
        Sound = new MemoryStream();
        stream.CopyTo(Sound);
        Player = new SoundPlayer(Sound);
    }

    public void Play() {
        if(IsPlaying) {
            Player.Stop();
        }
        IsPlaying = true;
        Sound.Seek(0, SeekOrigin.Begin);
        Player.Play();
    }

    public void Dispose() {
        Player.Stop();
        Player.Dispose();
        Sound.Dispose();
    }
}
