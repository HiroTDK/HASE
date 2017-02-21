using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HASE.HASE;

namespace HASE
{
	class NDSNARC : BaseClass
	{
		public bool isValid = false;

		public NDSFAT fat;
		public NDSFNT fnt;

		public NDSNARC(byte[] bytes, NDSFile file, bool debug)
		{
			string signature;
			uint fSize;
			ushort hSize;
			uint aSize;
			uint nSize;
			uint iSize;

			int aOffset;
			int nOffset;
			int iOffset;

			using (MemoryStream stream = new MemoryStream(bytes, file.offset, file.length))
			{
				using (BinaryReader reader = new BinaryReader(stream))
				{
					signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					ushort order = reader.ReadUInt16();
					ushort version = reader.ReadUInt16();
					fSize = reader.ReadUInt32();
					hSize = reader.ReadUInt16();
					ushort blocks = reader.ReadUInt16();
					
					if (signature != "NARC" ||
						order != 65534 ||
						version != 256 ||
						fSize != stream.Length ||
						hSize != 16 ||
						blocks != 3 &&
						debug)
					{
						System.Console.WriteLine(file.name + " isn't a NARC or has a malformed header.\n" +
							"Signture: " + signature + " | NARC\n" +
							"Byte Order: " + order + " | 65534\n" +
							"Version: " + version + " | 256\n" +
							"File Size: " + fSize + " | " + stream.Length + "\n" +
							"Header Size: " + hSize + " | 16\n" +
							"blocks: " + blocks + " | 3");
						return;
					}

					signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					aSize = reader.ReadUInt32();
					ushort count = reader.ReadUInt16();
					ushort reserved = reader.ReadUInt16();

					if (signature != "BTAF" ||
						aSize != ((count * 8) + 12) ||
						reserved != 0 &&
						debug)
					{
						System.Console.WriteLine(file.name + " has a malformed BTAF header.\n" +
							"Signture: " + signature + " | BTAF\n" +
							"File Count: " + count + "\n" +
							"Size: " + aSize + " | " + ((count * 8) + 12) + "\n" +
							"Reserved: " + reserved + " | 0\n");
						return;
					}

					reader.BaseStream.Position += aSize - 12;

					signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					nSize = reader.ReadUInt32();

					if (signature != "BTNF" && debug)
					{
						System.Console.WriteLine(file.name + " has a malformed BTNF header.\n" +
							"Signture: " + signature + " | BTNF\n" +
							"Size: " + nSize + "\n");
						return;
					}

					reader.BaseStream.Position += nSize - 8;

					signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					iSize = reader.ReadUInt32();

					int tSize = Convert.ToInt32(hSize + aSize + nSize + iSize);

					if (signature != "GMIF" && debug)
					{
						System.Console.WriteLine(file.name + " has a malformed GMIF header.\n" +
							"Signture: " + signature + " | GMIF\n" +
							"Size: " + iSize + "\n");
						return;
					}

					if (tSize != fSize && debug)
					{
						System.Console.WriteLine(file.name + " total defined size doesn't equal file size." +
							"Total Defined Size: " + tSize + " | " + fSize + "\n");
						return;
					}
				}
			}

			aOffset = file.offset + 28;
			aSize -= 12;
			nOffset = Convert.ToInt32(aOffset + aSize + 8);
			nSize -= 8;
			iOffset = Convert.ToInt32(nOffset + nSize + 8);
			iSize -= 8;

			using (MemoryStream memoryStream = new MemoryStream(bytes, aOffset, Convert.ToInt32(aSize)))
			{
				fat = new NDSFAT(memoryStream, debug);
			}

			using (MemoryStream memoryStream = new MemoryStream(bytes, nOffset, Convert.ToInt32(nSize)))
			{
				fnt = new NDSFNT(memoryStream, (file.path + file.name + file.extension), Convert.ToInt32(fat.FileCount), debug);
			}

			for (int i = 0; i < fat.FileCount; i++)
			{
				NDSFile f = fnt.Files[i];
				f.SetOffsets(Convert.ToUInt32(fat.FileStart[i] + iOffset), Convert.ToUInt32(fat.FileEnd[i] + iOffset));
				f.GetExtension(bytes);
				if (f.extension == ".narc" && debug)
				{
					System.Console.WriteLine("Why would you put an archive inside of an archive?\n" + 
						"Yeah, I won't be unpacking that.\n" +
						"You want a recursive unpacker? Pfffft!");
				}
			}

			isValid = true;
		}
	}
}
