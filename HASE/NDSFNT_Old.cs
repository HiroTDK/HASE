using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HASE
{
	public class NDSFNT_Old : HASE.BaseClass
	{
		/// <summary>
		/// This is the file name table for NDS ROMs. This defines the folder
		/// structure and assigns files to the folders by their IDs.
		/// </summary>

		public NDSFNT_Old(Stream stream, uint, bool debug)
		{
			using (BinaryReader reader = new BinaryReader(stream))
			{
				reader.BaseStream.Position = 4;
				ushort firstFile = reader.ReadUInt16();

				Files = new string[fat];
				for (int i = 0; i < firstFile; i++)
				{
					Files[i] = "\\Overlays\\Overlay " + i + ".bin";
				}

				ushort directories = reader.ReadUInt16();
				uint[] offsets = new uint[directories];
				ushort[] firstFiles = new ushort[directories];

				Folders = new string[directories + 1];
				Folders[0] = "\\File System";
				Folders[directories] = "\\Overlays";
				
				for (int i = 0; i < directories; i++)
				{
					reader.BaseStream.Position = i * 8;
					offsets[i] = reader.ReadUInt32();
					firstFiles[i] = reader.ReadUInt16();
				}
				
				for (int i = 0; i < directories; i++)
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
			}
		}
		
		public string[] Folders;
		public string[] Files;


	}
}




//638
//730

//274 904 no signal lane r2l
//905 l2r
//905r2l