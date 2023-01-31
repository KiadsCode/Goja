using System;
using System.IO;
using GojaCPP;

namespace Goja.Utils
{
	public static class Convert
    {
		public static Vector2 ToGLVector2(Vector2 a, float gameWidth, float gameHeight)
		{
			return new Vector2(a.X / gameWidth, a.Y / gameHeight);
		}

        public static byte[] ToByteArray(UnmanagedMemoryStream stream)
        {
            MemoryStream mem = new MemoryStream();
            stream.CopyTo(mem);
            byte[] data = mem.ToArray();
            return data;
        }
        public static byte[] ToByteArray(MemoryStream stream)
        {
            byte[] data = stream.ToArray();
            return data;
        }
        public static Vector2 ToVector2(VECTOR2F obj)
		{
			return new Vector2(obj.X, obj.Y);
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
