using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}