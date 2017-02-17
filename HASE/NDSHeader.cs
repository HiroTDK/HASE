using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HASE
{
	public class NDSHeader : HASE.BaseClass
	{
		/// <summary>
		/// This is the header data for NDS ROMs, excluding DSi enhanced ROMs.
		/// This file points to the information in the rest of the game, and
		/// gives the NDS a title, icon, code, et cetera to read before booting
		/// the ROM.
		/// </summary>

		public NDSHeader(Stream stream, bool debug)
		{
			if(stream.Length != 16384)
			{
				return;
			}

			using (BinaryReader reader = new BinaryReader(stream))
			{
				GameTitle = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(10));
				reader.BaseStream.Position = 12;
				GameCode = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(4));
				MakerCode = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(2));
				UnitCode = reader.ReadByte();
				EncryptionSeed = reader.ReadByte();
				DeviceCapaciy = reader.ReadByte();
				reader.BaseStream.Position = 29;
				RegionCode = reader.ReadByte();
				Version = reader.ReadByte();
				InternalFlags = reader.ReadByte();
				if (debug)
				{
					System.Console.WriteLine("Header");

					System.Console.WriteLine("	GameTitle: " + GameTitle);
					System.Console.WriteLine("	GameCode: " + GameCode);
					System.Console.WriteLine("	MakerCode: " + MakerCode);
					System.Console.WriteLine("	UnitCode: " + UnitCode);
					System.Console.WriteLine("	EncryptionSeed: " + EncryptionSeed);
					System.Console.WriteLine("	DeviceCapaciy: " + DeviceCapaciy);
					System.Console.WriteLine("	RegionCode: " + RegionCode);
					System.Console.WriteLine("	Version: " + Version);
					System.Console.WriteLine("	InternalFlags: " + InternalFlags);
				}


				ARM9Offset = reader.ReadUInt32();
				ARM9Entry = reader.ReadUInt32();
				ARM9Load = reader.ReadUInt32();
				ARM9Length = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	ARM9Offset: " + ARM9Offset);
					System.Console.WriteLine("	ARM9Entry: " + ARM9Entry);
					System.Console.WriteLine("	ARM9Load: " + ARM9Load);
					System.Console.WriteLine("	ARM9Length: " + ARM9Length);
				}

				ARM7Offset = reader.ReadUInt32();
				ARM7Entry = reader.ReadUInt32();
				ARM7Load = reader.ReadUInt32();
				ARM7Length = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	ARM7Offset: " + ARM7Offset);
					System.Console.WriteLine("	ARM7Entry: " + ARM7Entry);
					System.Console.WriteLine("	ARM7Load: " + ARM7Load);
					System.Console.WriteLine("	ARM7Length: " + ARM7Length);
				}


				FNTOffset = reader.ReadUInt32();
				FNTLength = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	FNTOffset: " + FNTOffset);
					System.Console.WriteLine("	FNTLength: " + FNTLength);
				}


				FATOffset = reader.ReadUInt32();
				FATLength = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	FATOffset: " + FATOffset);
					System.Console.WriteLine("	FATLength: " + FATLength);
				}


				ARM9OverlayOffset = reader.ReadUInt32();
				ARM9OverlayLength = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	ARM9OverlayOffset: " + ARM9OverlayOffset);
					System.Console.WriteLine("	ARM9OverlayLength: " + ARM9OverlayLength);
				}


				ARM7OverlayOffset = reader.ReadUInt32();
				ARM7OverlayLength = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	ARM7OverlayOffset: " + ARM7OverlayOffset);
					System.Console.WriteLine("	ARM7OverlayLength: " + ARM7OverlayLength);
				}


				PortNormal = reader.ReadUInt32();
				PortKEY1 = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	PortNormal: " + PortNormal);
					System.Console.WriteLine("	PortKEY1: " + PortKEY1);
				}


				IconOffset = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	IconOffset: " + IconOffset);
				}


				SecureChecksum = reader.ReadUInt16();
				PortKEY1 = reader.ReadUInt16();
				if (debug)
				{
					System.Console.WriteLine("	SecureChecksum: " + SecureChecksum);
					System.Console.WriteLine("	SecureDelay: " + SecureDelay);
				}


				ARM9AutoLoad = reader.ReadUInt32();
				ARM7AutoLoad = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	ARM9AutoLoad: " + ARM9AutoLoad);
					System.Console.WriteLine("	ARM7AutoLoad: " + ARM7AutoLoad);
				}


				SecureDisable = reader.ReadUInt64();
				if (debug)
				{
					System.Console.WriteLine("	SecureDisable: " + SecureDisable);
				}


				TotalSize = reader.ReadUInt32();
				HeaderSize = reader.ReadUInt32();
				if (debug)
				{
					System.Console.WriteLine("	TotalSize: " + TotalSize);
					System.Console.WriteLine("	HeaderSize: " + HeaderSize);
					System.Console.WriteLine();
				}

			}
		}


		// Header Byte Array
		public byte[] HeaderArray;  // This'll hold the header itself.

		// Begin Header Data
		public string GameTitle;           // 0x0
		public string GameCode;            // 0x0C
		public string MakerCode;           // 0x10
		public byte UnitCode;              // 0x12
		public byte EncryptionSeed;        // 0x13
		public byte DeviceCapaciy;         // 0x14
		public byte RegionCode;            // 0x1D
		public byte Version;               // 0x1E
		public byte InternalFlags;         // 0x1F

		// ARM9
		public uint ARM9Offset;            // 0x20
		public uint ARM9Entry;             // 0x24
		public uint ARM9Load;              // 0x28
		public uint ARM9Length;            // 0x2C

		// ARM7
		public uint ARM7Offset;            // 0x30
		public uint ARM7Entry;             // 0x34
		public uint ARM7Load;              // 0x38
		public uint ARM7Length;            // 0x3C

		// File Name Table
		public uint FNTOffset;             // 0x40
		public uint FNTLength;             // 0x44

		// File Allocation Table
		public uint FATOffset;             // 0x48
		public uint FATLength;             // 0x4C

		// ARM9 Overlay
		public uint ARM9OverlayOffset;     // 0x50
		public uint ARM9OverlayLength;     // 0x54

		// ARM7 Overlay
		public uint ARM7OverlayOffset;     // 0x58
		public uint ARM7OverlayLength;     // 0x5C

		// Port Settings
		public uint PortNormal;            // 0x60
		public uint PortKEY1;              // 0x64

		// Icon/Title Offset
		public uint IconOffset;            // 0x68

		// Secure Area
		public ushort SecureChecksum;      // 0x6C
		public ushort SecureDelay;         // 0x6E

		// ARM AutoLoad List
		public uint ARM9AutoLoad;          // 0x70
		public uint ARM7AutoLoad;          // 0x74

		// Secure Area Disable
		public ulong SecureDisable;        // 0x78

		// ROM Size
		public uint TotalSize;             // 0x80
		public uint HeaderSize;            // 0x84

		// Nintendo Logo
		// Later...

		// Checksums
		public ushort NintendoLogoCRC;     // 0x15C
		public ushort HeaderCRC;           // 0x15E
	}
}
