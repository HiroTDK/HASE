using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HASE
{
	public class ROM : HASE.BaseClass
	{
		public ROM(string path, bool log, bool auto, bool silent)
		{
			this.pathROM = path;
			if (auto)
			{
				ReadROM(log, auto, silent);
			}
		}

		public string pathROM;
		
		public void ReadROM(bool log, bool auto, bool silent)
		{
			FileInfo fi = new FileInfo(pathROM);                                // Open info on the file.
			if (fi.Length < 136)                                                // Is file long enough to have header?
			{
				if (!silent)
				{
					DialogResult result = CustomMessageBox.Show(
					"File Size Error",
					"This file is too short.",
					"This file isn't long enough to define a header."
						+ " Header size is 4 bytes long and stored at byte 132 (0x84). This file is only "
						+ fi.Length + " (0x" + fi.Length.ToString("X") + ") bytes long.",
					365, 200,
					new List<string>(),
					new List<DialogResult>());
				}
				this.Dispose(true);
				return;
			}

			FileStream fs = new FileStream(pathROM, FileMode.Open);             // Open the file.
			byte[] bytes = new byte[4];                                         // New byte array for the header size.
			fs.Position = 132;                                                  // Header size offset.
			fs.Read(bytes, 0, 4);                                               // Read header size to byte array.
			int hSize = BitConverter.ToInt32(bytes, 0);                         // Convert the byte array to usable number.

			if(hSize != 16384)
			{
				if (!silent)
				{
					DialogResult result = CustomMessageBox.Show(
						"Header Size Error",
						"The header size is non-standard.",
						"The 4 bytes at 132 (0x84) indicate that the header size is "
						+ hSize + " (0x" + hSize.ToString("X") + ") bytes long."
						+ " All known headers are 16384 (0x4000) bytes long,"
						+ " The header size is either incorrect or the ROM is corrupted."
						+ " Would you like to proceed anyway?",
						365, 225,
						new List<string>() { "Yes", "No" },
						new List<DialogResult>() { DialogResult.Yes, DialogResult.No });

					if (result == DialogResult.No)
					{
						fs.Dispose();
						this.Dispose(true);
						return;
					}
				}
			}
			
			if (fi.Length < hSize)
			{
				if (!silent)
				{
					DialogResult result = CustomMessageBox.Show(
						"Header Size Error",
						"The file is too short.",
						"The header size defined at 132 (0x84) indicates a header size of "
						+ hSize + "(0x" + hSize.ToString("X") + ") bytes."
						+ "This file is only " + fi.Length + " (0x" + fi.Length.ToString("X") + ") bytes long.",
						365, 225,
						new List<string>() { },
						new List<DialogResult>() { });
				}
				fs.Dispose();
				this.Dispose(true);
				return;
			}
			
			byte[] hBytes = new byte[hSize];
			fs.Position = 0;
			fs.Read(hBytes, 0, hSize);
			NDSHeader header = new NDSHeader(hBytes, log, auto, silent);
		}
	}

	public class NDSHeader : HASE.BaseClass
	{
		// / <summary>
		// / This is the header data for NDS ROMs, excluding DSi enhanced ROMs.
		// / This file points to the information in the rest of the game, and
		// / gives the NDS a title, icon, code, et cetera to read before booting
		// / the ROM.
		// / </summary>

		// Header Byte Array
		public byte[] HeaderArray;  // This'll hold the header itself.

		// Begin Header Data
		string GameTitle;           // 0x0
		string GameCode;            // 0x0C
		string MakerCode;           // 0x10
		byte UnitCode;              // 0x12
		byte EncryptionSeed;        // 0x13
		byte DeviceCapaciy;         // 0x14
		byte RegionCode;            // 0x1D
		byte Version;               // 0x1E
		byte InternalFlags;         // 0x1F

		// ARM9
		uint ARM9Offset;            // 0x20
		uint ARM9Entry;             // 0x24
		uint ARM9Load;              // 0x28
		uint ARM9Length;            // 0x2C

		// ARM7
		uint ARM7Offset;            // 0x30
		uint ARM7Entry;             // 0x34
		uint ARM7Load;              // 0x38
		uint ARM7Length;            // 0x3C

		// File Name Table
		uint FNTOffset;             // 0x40
		uint FNTLength;             // 0x44

		// File Allocation Table
		uint FATOffset;             // 0x48
		uint FATLength;             // 0x4C

		// ARM9 Overlay
		uint ARM9OverlayOffset;     // 0x50
		uint ARM9OverlayLength;     // 0x54

		// ARM7 Overlay
		uint ARM7OverlayOffset;     // 0x58
		uint ARM7OverlayLength;     // 0x5C

		// Port Settings
		uint PortNormal;            // 0x60
		uint PortKEY1;              // 0x64

		// Icon/Title Offset
		uint IconOffset;            // 0x68

		// Secure Area
		ushort SecureChecksum;      // 0x6C
		ushort SecureDelay;         // 0x6E

		// ARM AutoLoad List
		uint ARM9AutoLoad;          // 0x70
		uint ARM7AutoLoad;          // 0x74

		// Secure Area Disable
		ulong SecureDisable;        // 0x78

		// ROM Size
		uint TotalSize;             // 0x80
		uint HeaderSize;            // 0x84

		// Nintendo Logo
		// Later...

		// Checksums
		ushort NintendoLogoCRC;     // 0x15C
		ushort HeaderCRC;           // 0x15E

		public NDSHeader(byte[] header, bool log, bool auto, bool silent)
		{
			HeaderArray = header;
			if (auto)
			{
				ReadHeader(log, auto, silent);
			}
		}

		public void ReadHeader(bool log, bool auto, bool silent)
		{
			// Start
			GameTitle = System.Text.Encoding.UTF8.GetString(HeaderArray, 0, 10);
			GameCode = System.Text.Encoding.UTF8.GetString(HeaderArray, 12, 4);
			MakerCode = System.Text.Encoding.UTF8.GetString(HeaderArray, 16, 2);
			UnitCode = HeaderArray[18];
			EncryptionSeed = HeaderArray[19];
			DeviceCapaciy = HeaderArray[20];
			RegionCode = HeaderArray[29];
			Version = HeaderArray[30];
			InternalFlags = HeaderArray[31];
		}

		public void OutputStuff()
		{
			Console.WriteLine("Game Title: " + GameTitle);
			Console.WriteLine("Game Code:  " + GameCode);
			Console.WriteLine("Maker Code: " + MakerCode);
			Console.WriteLine("Unit Code:  " + UnitCode);
		}
	}
}
