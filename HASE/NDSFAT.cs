using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HASE
{
	public class NDSFAT : HASE.BaseClass
	{
		/// <summary>
		/// This is the file allocation table for NDS ROMs. This table defines
		/// the starting and ending addresses of files stored in the ROM. They
		/// are identified in the order that they are defined, with the first
		/// file having and ID of 0000.
		/// </summary>

		public NDSFAT (Stream stream, bool debug)
		{
			FileCount = Convert.ToUInt32(stream.Length / 8);
			if (FileCount < 1)
			{
				return;
			}
			if (debug)
			{
				System.Console.WriteLine("File Allocation Table [" + FileCount + " Files]\n");
			}

			FileStart = new uint[FileCount];
			FileEnd = new uint[FileCount];

			using (BinaryReader reader = new BinaryReader(stream))
			{
				reader.BaseStream.Position = 0;
				for (uint i = 0; i < FileCount; i++)
				{
					FileStart[i] = reader.ReadUInt32();
					FileEnd[i] = reader.ReadUInt32();
					if (debug)
					{
						System.Console.WriteLine("	File: " + i + "\n"
							+ "		Length: " + (FileEnd[i] - FileStart[i]) + "\n"
							+ "		Start: " + FileStart[i] + " (0x" + FileStart[i].ToString("X") + ")\n"
							+ "		End: " + FileEnd[i] + " (0x" + FileEnd[i].ToString("X") + ")\n"
							);
					}
				}
			}
		}


		// File Count
		public uint FileCount;

		// Arrays of starting and ending addresses.
		public uint[] FileStart;
		public uint[] FileEnd;

	}
}