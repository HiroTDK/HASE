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

		public NDSFNT(Stream table, string parentName, uint fileCount, bool debug)
		{
			using (BinaryReader reader = new BinaryReader(table))
			{
				reader.BaseStream.Position = 4;
				FirstFile = reader.ReadUInt16();
				ushort folderCount = reader.ReadUInt16();
								
				Folders = new string[folderCount];
				Folders[0] = "\\" + parentName;

				Files = new string[fileCount];
				for (int i = 0; i < fileCount; i++)
				{
					string digits = "D" + fileCount.ToString().Length;
					Files[i] = i.ToString(digits);
				}
				
				uint[] offsets = new uint[folderCount];
				ushort[] firstFiles = new ushort[folderCount];
				
				for (int i = 0; i < folderCount; i++)
				{
					reader.BaseStream.Position = i * 8;
					offsets[i] = reader.ReadUInt32();
					firstFiles[i] = reader.ReadUInt16();
				}

				for (int i = 0; i < folderCount; i++)
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
							Files[f] = Folders[i] + "\\" + name;
							f++;
						}

						else
						{
							entryName -= 128;

							byte[] nameArray = new byte[entryName];
							reader.Read(nameArray, 0, entryName);
							string name = System.Text.Encoding.UTF8.GetString(nameArray);

							ushort subFolder = reader.ReadUInt16();
							subFolder -= 61440;

							Folders[subFolder] = Folders[i] + "\\" + name;
						}
					}
				}

				if (debug)
				{
					foreach (string folder in Folders)
					{
						System.Console.WriteLine(folder);
					}
				}
			}
		}
		
		public ushort FirstFile;

		public string[] Folders;
		public string[] Files;


	}
}