using IrrKlang;

namespace Goja.Audio
{
    public class SoundEffect
    {
        private ISoundSource _source = null;
        private ISound _sound = null;

        public bool Paused
        {
            get
            {
                return _sound.Paused;
            }
            set
            {
                _sound.Paused = value;
            }
        }

        public float Volume
        {
            get
            {
                return _sound.Volume * 100;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new System.ArgumentOutOfRangeException("value");
                _sound.Volume = value / 100;
            }
        }
        internal SoundEffect(byte[] stream)
        {
            _source = AudioShared.Engine.AddSoundSourceFromMemory(stream, "mp3");
            Play();
            Stop();
        }

        public uint Length
        {
            get
            {
                return _sound.PlayLength;
            }
        }

        public void Stop()
        {
            _sound.Stop();
            Paused = true;
        }

        public void Play()
        {
            _sound = AudioShared.Engine.Play2D(_source, false, true, false);
            _sound.Paused = false;
        }
    }
}