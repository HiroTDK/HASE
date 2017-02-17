using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASE
{
	class FileNARC
	{
		public FileNARC(byte[] file, uint start)
		{
			using (MemoryStream stream = new MemoryStream(file))
			{
				using (BinaryReader reader = new BinaryReader(stream))
				{
					reader.BaseStream.Position = start + 8;
					FileSize = reader.ReadUInt32();
					FATBOffset = Convert.ToUInt16(reader.ReadUInt16() + start);

					reader.BaseStream.Position = start + FATBOffset + 4;
					FATBSize = reader.ReadUInt32();
					FNTBOffset = start + FATBOffset + FATBSize;

					reader.BaseStream.Position = start + FNTBOffset + 4;
					FNTBSize = reader.ReadUInt32();
					FIMGOffset = start + FNTBOffset + FNTBSize;

					reader.BaseStream.Position = start + FNTBOffset + 4;
				}
			}
		}

		// Header Data
		uint FileSize;

		ushort FATBOffset;
		uint FATBSize;

		uint FNTBOffset;
		uint FNTBSize;

		uint FIMGOffset;                                                                      
		uint FIMGSize;

		// File Tables
		NDSFAT FATB;
		NDSFNT FNTB;
	}
}