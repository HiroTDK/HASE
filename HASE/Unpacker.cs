using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASE
{
	class Unpacker : HASE.BaseClass
	{
		public Unpacker(string file, string path, bool debug)
		{
			if (!File.Exists(file))
			{
				if (debug)
				{
					DialogResult result = CustomMessageBox.Show(
						 "File Error",
						 "This file doesn't exist.",
						 "The file that you've specified doesn't exist or has changed locations."
						 + " Please check the path and file name for any errors and try again.",
						 365, 200,
						 new List<string>(),
						 new List<DialogResult>());
					this.Dispose(true);
					return;
				}
			}

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			
			Unpack(file, path, debug);
		}
		

		/**************************************************************************************************\



		\**************************************************************************************************/

		private void Unpack(string file, string path, bool debug)
		{
			new FileScanner(file, path, debug);
			
			/*
			// Throw the entire file into an array.
			byte[] bytes = File.ReadAllBytes(file);
			

			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
						Header            
			\*--------------------------/

			NDSHeader header;

			using (MemoryStream memoryStream = new MemoryStream(bytes, 0, 16384))
			{
				header = new NDSHeader(memoryStream, true);
			}

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\Header.bin", FileMode.Create)))
			{
				writer.Write(bytes, 0, Convert.ToInt32(header.HeaderSize));
			}


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			         File Tables         
			\*--------------------------/

			NDSFAT fat;
			NDSFNT fnt;

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\File Allocation Table.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.FATOffset), Convert.ToInt32(header.FATLength));
				fat = new NDSFAT(new MemoryStream(bytes, Convert.ToInt32(header.FATOffset), Convert.ToInt32(header.FATLength)), false);
			}

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\File Name Table.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.FNTOffset), Convert.ToInt32(header.FNTLength));
				fnt = new NDSFNT(new MemoryStream(bytes, Convert.ToInt32(header.FNTOffset), Convert.ToInt32(header.FNTLength)), fat.FileCount, false);
			}
			

			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			             ARM7             
			\*--------------------------/

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\ARM7.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.ARM7Offset), Convert.ToInt32(header.ARM7Length));
			}

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\ARM7 Overlay Table.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.ARM7OverlayOffset), Convert.ToInt32(header.ARM7OverlayLength));
			}

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\ARM9.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.ARM9Offset), Convert.ToInt32(header.ARM9Length));
			}

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\ARM9 Overlay Table.bin", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.ARM9OverlayOffset), Convert.ToInt32(header.ARM9OverlayLength));
			}
/*
			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\Banner.banner", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.IconOffset), Convert.ToInt32(header.HeaderSize));
			}
*/
		}
	}
}
