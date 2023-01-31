using System;
using System.Collections.Generic;

namespace Goja.Content
{
	/// <summary>
	/// Contains files loaded by ContentManager
	/// </summary>
	public class ContentFilesContainer
	{
		private Dictionary<string, object> _files = new Dictionary<string, object>();
		
		public ContentFilesContainer()
		{
		}
		
		public IEnumerable<object> Files
		{
			get { return _files.Values; }
		}
		
		public object Load(string name)
		{
			object obj = default(object);
			if(name != null)
				_files.TryGetValue(name, out obj);
			return obj;
		}
		
		public void UnloadAll()
		{
			_files.Clear();
		}
		
		public bool Contains(string contentFileName)
		{
			if(contentFileName != null)
				return _files.ContainsKey(contentFileName);
			return false;
		}
		public bool Contains(object contentFileData)
		{
			if(contentFileData != null)
				return _files.ContainsValue(contentFileData);
			return false;
		}
		
		public void Add(string contentFileName, object contentFile)
		{
			_files.Add(contentFileName,contentFile);
		}
	}
}
