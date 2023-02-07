using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Goja.Audio;
using Goja.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Goja.Content
{
	public class ContentManager
	{
		public string[] ImageFormats
		{
			get
			{
				string[] data = new string[] 
				{
    				"png",
    				"bmp",
    				"jpg",
    				"jpeg"
				};
				return data;
			}
		}
		public string[] SoundFormats
		{
			get
			{
				string[] data = new string[] 
    			{
    				"mp3",
    				"ogg",
    				"wav"
    			};
				return data;
			}
		}
    	private ContentFilesContainer _contentFilesContainer = new ContentFilesContainer();
        private string _rootDirectory = string.Empty;

        public ContentManager(string rootDirectory)
        {
        	RootDirectory = rootDirectory;
        	_contentFilesContainer = new ContentFilesContainer();
        }
        
        public void Unload()
        {
        	_contentFilesContainer.UnloadAll();
        }
        
        public void PreLoad<T>(string assetName)
        {
            object obj = new object();
            string AssetPath = _rootDirectory + "\\" + assetName;
            
            if(!_contentFilesContainer.Contains(assetName))
            {
            	if(typeof(T) == typeof(Texture2D)) 
            	{
            		AssetPath = CorrectAssetPath(AssetPath, ImageFormats);
                    using (Stream stream = TitleContainer.OpenStream(AssetPath))
                    {
                        Texture2D texture = LoadTexture2D(stream);
                        obj = texture;
                        stream.Close();
                    }
                }
            	if(typeof(T) == typeof(WavSound))
            	{
            		AssetPath = CorrectAssetPath(AssetPath, SoundFormats);
            		using (Stream stream = TitleContainer.OpenStream(AssetPath))
            		{
            			obj = LoadWavSound(stream);
            			stream.Close();
            		}
            	}
            	_contentFilesContainer.Add(AssetPath, obj);
            }
            else
            	obj = _contentFilesContainer.Load(assetName);

            bool objIsntT = !(obj is T);
            if (objIsntT)
                throw new Exception("Argument isn\'t same type as asset");
        }

        public T Load<T>(string assetName)
        {
            T file = default(T);
            object obj = new object();
            string AssetPath = _rootDirectory + "\\" + assetName;
            
            if(!_contentFilesContainer.Contains(assetName))
            {
            	if(typeof(T) == typeof(Texture2D)) 
            	{
            		AssetPath = CorrectAssetPath(AssetPath, ImageFormats);
                    using (Stream stream = TitleContainer.OpenStream(AssetPath))
                    {
                        Texture2D texture = LoadTexture2D(stream);
                        obj = texture;
                        stream.Close();
                    }
                }
            	if(typeof(T) == typeof(WavSound))
            	{
            		AssetPath = CorrectAssetPath(AssetPath, SoundFormats);
            		using (Stream stream = TitleContainer.OpenStream(AssetPath))
            		{
            			obj = LoadWavSound(stream);
            			stream.Close();
            		}
            	}
            	_contentFilesContainer.Add(AssetPath, obj);
            }
            else
            	obj = _contentFilesContainer.Load(assetName);

            bool objIsntT = !(obj is T);
            if (objIsntT)
                throw new Exception("Argument isn\'t same type as asset");

            file = (T)obj;
            return file;
        }
        private string CorrectAssetPath(string assetPath, string[] fileFormats)
        {
            if (!File.Exists(assetPath))
            {
                for (int i = 0; i < fileFormats.Length; i++)
                {
                    if (File.Exists(assetPath + "." + fileFormats[i]))
                    {
                        assetPath = assetPath + "." + fileFormats[i];
                        break;
                    }
                }
            }

            return assetPath;
        }

		private object LoadWavSound(Stream stream)
		{
			WavSound snd = new WavSound(stream);
			object obj = snd;
			return obj;
		}

        private Texture2D LoadTexture2D(Stream stream)
        {
            Bitmap bitmap = new Bitmap(Image.FromStream(stream));
            int textureID;
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);
            Texture2D texture = new Texture2D(bitmap, textureID);
            return texture;
        }

        public string RootDirectory { get { return _rootDirectory; } set { _rootDirectory = value; } }
        
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			ContentManager other = obj as ContentManager;
				if (other == null)
					return false;
						return object.Equals(this._contentFilesContainer, other._contentFilesContainer) && this._rootDirectory == other._rootDirectory;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (_contentFilesContainer != null)
					hashCode += 1000000007 * _contentFilesContainer.GetHashCode();
				if (_rootDirectory != null)
					hashCode += 1000000009 * _rootDirectory.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(ContentManager lhs, ContentManager rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ContentManager lhs, ContentManager rhs) {
			return !(lhs == rhs);
		}

		#endregion
    }
}
