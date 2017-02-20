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
		public NDSNARC(byte[] bytes, NDSFile file)
		{
			using (MemoryStream stream = new MemoryStream(bytes, file.offset, file.length))
			{
				using (BinaryReader reader = new BinaryReader(stream))
				{
					string signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					ushort order = reader.ReadUInt16();
					ushort version = reader.ReadUInt16();
					uint size = reader.ReadUInt32();
					ushort header = reader.ReadUInt16();
					ushort count = reader.ReadUInt16();
					
					if (signature != "NARC" ||
						order != 65534 ||
						version != 256 ||
						size != stream.Length ||
						header != 16 ||
						count != 3)
					{
						System.Console.WriteLine(file.name + " isn't a NARC or has a malformed header.\n" +
							"Signture: " + signature + " | NARC\n" +
							"Byte Order: " + order + " | 65534\n" +
							"Version: " + version + " | 256\n" +
							"File Size: " + size + " | " + stream.Length + "\n" +
							"Header Size: " + header + " | 16\n" +
							"blocks: " + count + " | 3");
						return;
					}

					signature = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
					size = reader.ReadUInt32();
					count = reader.ReadUInt16();
					header = reader.ReadUInt16();

					if (signature != "BTAF" ||
						size != ((count * 8) + 12) ||
						header != 0)
					{
						System.Console.WriteLine(file.name + " has a malformed BTAF header.\n" +
							"Signture: " + signature + " | BTAF\n" +
							"File Count: " + count + "\n" +
							"Size: " + size + " | " + ((count * 8) + 12) + "\n" +
							"Reserved: " + header + " | 0\n");
						return;
					}
					

				}
			}
			

			using (MemoryStream stream = new MemoryStream(bytes, file.offset, file.length))
			{
				
			}
		}

		bool isValid = false;
	}
}
