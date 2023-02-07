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
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			ContentFilesContainer other = obj as ContentFilesContainer;
				if (other == null)
					return false;
						return object.Equals(this._files, other._files);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (_files != null)
					hashCode += 1000000007 * _files.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(ContentFilesContainer lhs, ContentFilesContainer rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ContentFilesContainer lhs, ContentFilesContainer rhs) {
			return !(lhs == rhs);
		}

		#endregion
	}
}
