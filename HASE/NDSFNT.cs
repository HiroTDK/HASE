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
				Folders = new NDSFolder[FolderCount];
				Folders[0] = new NDSFolder("", parentName, 0);
				for (int i = 1; i < FolderCount; i++)
				{
					string digits = i.ToString("D" + FolderCount.ToString().Length);

					Folders[i] = new NDSFolder(Folders[0].name, digits, 0);
				}

				// Initialize the Files list and give each file a default name and path.
				Files = new NDSFile[fileCount];
				for (int i = 0; i < fileCount; i++)
				{
					string digits = i.ToString("D" + fileCount.ToString().Length);

					Files[i] = new NDSFile(Folders[0].name, digits, 0);
				}
				
				// Initialize some arrays to keep track of offsets and first files for folders.
				uint[] offsets = new uint[FolderCount];
				ushort[] firstFiles = new ushort[FolderCount];
				
				// Run through the directory list, record the offsets and first files, and folder to parent's NDSFolder list.
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

				// Now we run through the files and sub-directories list and assign names.
				for (int i = 0; i < FolderCount; i++)
				{
					reader.BaseStream.Position = offsets[i];
					int f = firstFiles[i];

					while (true)
					{
						// First byte detrmines length of entry.
						byte entryName = reader.ReadByte();

						// 00 indicates no more names in the list.
						if (entryName == 0)
						{
							break;
						}

						// The most significant bit in the byte indicates either a directory (1) or a file (0).
						// Since it's the most significant, that puts the dilimiter at 128 or 0x80.

						// Most significant bit being 0— the byte being less than 128— indicates a file.
						if (entryName < 128)
						{
							byte[] nameArray = new byte[entryName];
							reader.Read(nameArray, 0, entryName);
							string name = System.Text.Encoding.UTF8.GetString(nameArray);

							Files[f] = new NDSFile(Folders[i].path + Folders[i].name, name, i);
							Folders[i].files.Add(f);
							f++;
						}

						// Most significant bit being 1— the byte being at least 128— indicates a folder.
						else
						{
							entryName -= 128;

							byte[] nameArray = new byte[entryName];
							reader.Read(nameArray, 0, entryName);
							string name = System.Text.Encoding.UTF8.GetString(nameArray);

							int subFolder = reader.ReadUInt16() - 61440;

							Folders[subFolder] = new NDSFolder(Folders[i].path + Folders[i].name, name, i);
						}
					}
				}
				
				
				if (debug)
				{
					System.Console.WriteLine("File Name System\n" +
						"	Folders [" + FolderCount + "]");

					for (int i = 0; i < FolderCount; i++)
					{
						NDSFolder f = Folders[i];
						System.Console.WriteLine("		Folder: " + i + "\n" +
							"			Name: " + f.name + "\n" +
							"			Parent Folder: " + Folders[f.parent].name + "\n" +
							"			Path: " + f.path);
					}

					System.Console.WriteLine("	Files [" + fileCount + "]");

					for (int i = 0; i < fileCount; i++)
					{
						NDSFile f = Files[i];
						System.Console.WriteLine("		File: " + i + "\n" +
							"			Name: " + f.name + "\n" +
							"			Parent Folder: " + Folders[f.parent].name + "\n" +
							"			Path: " + f.path);
					}
				}
			}
		}

		public ushort FolderCount;
		public ushort FirstFile;
		
		public NDSFolder[] Folders;
		public NDSFile[] Files;
	}
}