using System;
using System.IO;

namespace Goja.Utils
{
	public static class Convert
    {
		public static Vector2 ToGLVector2(Vector2 a, float gameWidth, float gameHeight)
		{
			return new Vector2(a.X / gameWidth, a.Y / gameHeight);
		}

        public static byte[] UnmanagedMemoryStreamToByteArray(UnmanagedMemoryStream stream)
        {
            MemoryStream mem = new MemoryStream();
            stream.CopyTo(mem);
            byte[] data = mem.ToArray();
            return data;
        }
        public static byte[] StreamToByteArray(Stream stream)
		{
        	MemoryStream mem = new MemoryStream();
        	stream.CopyTo(mem);
        	byte[] data = mem.ToArray();
        	return data;
    	}
        public static byte[] MemoryStreamToByteArray(MemoryStream stream)
        {
            byte[] data = stream.ToArray();
            return data;
        }

		public static Vector2 ToVector2(float[] obj)
		{
			try
			{
				return new Vector2(obj[0], obj[1]);
			}
			catch(IndexOutOfRangeException)
			{
				return Vector2.Zero;
			}
		}
	}
}