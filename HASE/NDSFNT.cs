using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HASE
{
	public class NDSFNT : HASE.BaseClass
	{
		/// <summary>
		/// This is the file name table for NDS ROMs. This defines the folder
		/// structure and assigns files to the folders by their IDs.
		/// </summary>

		public NDSFNT(Stream table, string parentName, int fileCount, bool debug)
		{
			using (BinaryReader reader = new BinaryReader(table))
			{
				// Skip the first folder offset to get pertinent information first.
				reader.BaseStream.Position = 4;
				FirstFile = reader.ReadUInt16();
				FolderCount = reader.ReadUInt16();

				// Initialize the Folders list, setup the root folder, and give each folder a default name and path.
				Folders = new FNTFolder[FolderCount];
				Folders[0] = new FNTFolder();
				Folders[0].path = "\\" + parentName;
				Folders[0].name = parentName;
				for (int i = 1; i < FolderCount; i++)
				{
					Folders[i] = new FNTFolder();
					string digits = i.ToString("D" + FolderCount.ToString().Length);
					Folders[i].path = Folders[0].path + "\\" + digits;
					Folders[i].name = digits;
				}

				// Initialize the Files list and give each file a default name and path.
				Files = new FNTFile[fileCount];
				for (int i = 0; i < fileCount; i++)
				{
					Files[i] = new FNTFile();
					string digits = i.ToString("D" + fileCount.ToString().Length);
					Files[i].path = Folders[0].path + "\\" + digits;
					Files[i].name = digits;
				}
				
				// Initialize some arrays to keep track of offsets and first files for folders.
				uint[] offsets = new uint[FolderCount];
				ushort[] firstFiles = new ushort[FolderCount];
				
				// Run through the directory list, record the offsets and first files, and folder to parent's FNTFolder list.
				for (int i = 0; i < FolderCount; i++)
				{
					reader.BaseStream.Position = i * 8;
					offsets[i] = reader.ReadUInt32();
					firstFiles[i] = reader.ReadUInt16();

					// First directory doesn't have a parent.
					if (i > 0)
					{
						int parent = reader.ReadUInt16() - 61440;
						Folders[i].parent = parent;
						Folders[parent].folders.Add(i);
					}
				}

				for (int i = 0; i < FolderCount; i++)
				{
					reader.BaseStream.Position = offsets[i];
					int f = firstFiles[i];
					while (true)
					{
						byte entryName = reader.ReadByte();
						if (entryName == 0)
						{
							break;
						}

						if (entryName < 128)
						{
							byte[] nameArray = new byte[entryName];
							reader.Read(nameArray, 0, entryName);
							string name = System.Text.Encoding.UTF8.GetString(nameArray);
							Files[f] = new FNTFile();
							Files[f].path = Folders[i].path + "\\" + name;
							Files[f].name = name;
							Files[f].parent = i;
							Folders[i].files.Add(f);
							f++;
						}

						else
						{
							entryName -= 128;

							byte[] nameArray = new byte[entryName];
							reader.Read(nameArray, 0, entryName);
							string name = System.Text.Encoding.UTF8.GetString(nameArray);

							int subFolder = reader.ReadUInt16() - 61440;

							Folders[subFolder].path = Folders[i].path + "\\" + name;
							Folders[subFolder].name = name;
						}
					}
				}

				if (debug)
				{
					System.Console.WriteLine("File Name System\n" +
						"	Folders [" + FolderCount + "]");

					for (int i = 0; i < FolderCount; i++)
					{
						FNTFolder f = Folders[i];
						System.Console.WriteLine("		Folder: " + i + "\n" +
							"			Name: " + f.name + "\n" +
							"			Parent Folder: " + Folders[f.parent].name + "\n" +
							"			Path: " + f.path);
					}

					System.Console.WriteLine("	Files [" + fileCount + "]");

					for (int i = 0; i < fileCount; i++)
					{
						FNTFile f = Files[i];
						System.Console.WriteLine("		File: " + i + "\n" +
							"			Name: " + f.name + "\n" +
							"			Parent Folder: " + Files[f.parent].name + "\n" +
							"			Path: " + f.path);
					}
				}
			}
		}

		public ushort FolderCount;
		public ushort FirstFile;
		
		public FNTFolder[] Folders;
		public FNTFile[] Files;


	}

	public class FNTFolder
	{
		public string name;
		public string path;
		public int parent;
		public List<int> folders = new List<int>();
		public List<int> files = new List<int>();
	}

	public class FNTFile
	{
		public string name;
		public string path;
		public int parent;
	}
}