using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class FindApi
    {
    }
	enum FileTypeEnum
	{
		Xml = 0,
		Xlsx = 1
	}

	abstract class DirectoryObject
	{
		public string Name;
		public string Path;
		public double Size;
	}

	class Folder : DirectoryObject
	{
		public File[] Files;
		public Folder[] Folders;
		public bool IsEmpty;
	}

	class File : DirectoryObject
	{
		public FileTypeEnum Type;
	}

	// Place all filter calls in this class and route to appropriate method depending on 
	class Filters
	{
		List<File> output = new List<File>();
		public File[] Filter(Folder root, double size)
		{
			foreach (File file in root.Files)
			{
				if (file.Size >= size) output.Add(file);
			}
			foreach (Folder folder in root.Folders)
			{
				if (!folder.IsEmpty) Filter(folder, size);
			}
			return output.ToArray();
		}
		public File[] Filter(Folder root, FileTypeEnum type)
		{
			foreach (File file in root.Files)
			{
				if (file.Type == type)
				{
					output.Add(file);
				}
			}
			foreach (Folder folder in root.Folders)
			{
				if (!folder.IsEmpty)
				{
					Filter(folder, type);
				}
			}
			return output.ToArray();
		}

		public File[] Filter(Folder root, HashSet<FileTypeEnum> types)
		{
			foreach (File file in root.Files)
			{
				if (types.Contains(file.Type))
				{
					output.Add(file);
				}
			}
			foreach (Folder folder in root.Folders)
			{
				if (!folder.IsEmpty)
				{
					Filter(folder, types);
				}
			}
			return output.ToArray();
		}
	}
}
