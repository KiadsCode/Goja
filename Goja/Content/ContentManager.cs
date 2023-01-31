using Goja.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goja.Content
{
    public class ContentManager
    {
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

        public T Load<T>(string assetName)
        {
            T file = default(T);
            object obj = new object();
            
            if(!_contentFilesContainer.Contains(assetName))
            {
            	if(typeof(T) == typeof(Texture2D)) 
            	{
					Texture2D texture = new Texture2D();
					texture.Load(TitleContainer.OpenStream(assetName));
					obj = texture;
					_contentFilesContainer.Add(assetName, obj);
				}
            }
            else
            	obj = _contentFilesContainer.Load(assetName);

            bool objIsntT = (obj is T) == false;
            if (objIsntT)
                throw new Exception("Argument isn\'t same type as asset");

            file = (T)obj;
            return file;
        }

        public string RootDirectory { get { return _rootDirectory; } set { _rootDirectory = value; } }
    }
}
