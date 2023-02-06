using System;
using System.Drawing;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace Goja.Graphics
{
    public class Texture2D
    {
        private Bitmap _bitmap;
        private int textureID;

        public Bitmap Bitmap
        {
            get
            {
                return _bitmap;
            }
        }

        public int TextureID
        {
            get
            {
                return textureID;
            }
        }

        internal Texture2D(Bitmap bitmap, int textureID)
        {
            _bitmap = bitmap;
            this.textureID = textureID;
        }

        public void Unload()
        {
            GL.DeleteTextures(1, ref textureID);
        }
        
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			Texture2D other = obj as Texture2D;
				if (other == null)
					return false;
						return object.Equals(this._bitmap, other._bitmap) && this.textureID == other.textureID;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (_bitmap != null)
					hashCode += 1000000007 * _bitmap.GetHashCode();
				hashCode += 1000000009 * textureID.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Texture2D lhs, Texture2D rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Texture2D lhs, Texture2D rhs) {
			return !(lhs == rhs);
		}

		#endregion
    }
}