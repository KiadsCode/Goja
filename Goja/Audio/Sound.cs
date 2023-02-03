using System.IO;
using IrrKlang;
using OpenTK.Audio.OpenAL;

namespace Goja.Audio
{
    public class Sound
    {
        private ISoundSource _source = null;
        private ISound _sound = null;


        bool InitializeOpenAL()
        {
            var alId = 0;
            AL.GetSource(1, ALGetSourcei.Buffer, out alId);

            return false;
        }

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

        public Sound(UnmanagedMemoryStream stream)
        {
            byte[] data = Goja.Utils.Convert.ToByteArray(stream);
            _source = AudioShared.Engine.AddSoundSourceFromMemory(data, "mp3");
        }
        public Sound(MemoryStream stream)
        {
            byte[] data = Goja.Utils.Convert.ToByteArray(stream);
            _source = AudioShared.Engine.AddSoundSourceFromMemory(data, "mp3");
        }
        public Sound(byte[] stream)
        {
            _source = AudioShared.Engine.AddSoundSourceFromMemory(stream, "mp3");
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