using HASE.HASE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASE
{
	class FileScanner
	{
		public FileScanner(string ROM, string path, bool debug)
		{
			// Throw the entire file into an array.
			byte[] bytes = File.ReadAllBytes(ROM);
			debug = false;


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
						Header            
			\*--------------------------*/

			NDSHeader header;

			using (MemoryStream memoryStream = new MemoryStream(bytes, 0, 16384))
			{
				header = new NDSHeader(memoryStream, debug);
			}


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			         File Tables         
			\*--------------------------*/

			NDSFAT fat;
			NDSFNT fnt;

			using (MemoryStream memoryStream = new MemoryStream(bytes, Convert.ToInt32(header.FATOffset), Convert.ToInt32(header.FATLength)))
			{
				fat = new NDSFAT(memoryStream, debug);
			}

			using (MemoryStream memoryStream = new MemoryStream(bytes, Convert.ToInt32(header.FNTOffset), Convert.ToInt32(header.FNTLength)))
			{
				fnt = new NDSFNT(memoryStream, "File System", Convert.ToInt32(fat.FileCount), debug);
			}


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			           Overlays           
			\*--------------------------*/
			
			Folders.Add(new NDSFolder("", "Overlays", 0));
		
			for (int i = 0; i < fnt.FirstFile; i++)
			{
				fnt.Files[i].path = "\\Overlays\\";
				fnt.Files[i].name = "Overlay " + i + ".bin";
			}


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			          Get Files          
			\*--------------------------*/

			List<NDSFile> narcs = new List<NDSFile>();

			foreach (NDSFolder f in fnt.Folders)
			{
				Folders.Add(f);
			}

			for (int i = 0; i < fat.FileCount; i++)
			{
				NDSFile f = fnt.Files[i];
				f.SetOffsets(fat.FileStart[i], fat.FileEnd[i]);
				f.GetExtension(bytes);
				if (f.extension == ".narc")
				{
					narcs.Add(f);
				}
				else
				{
					Files.Add(f);
				}
			}

			fat.Dispose();
			fnt.Dispose();
			

			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			          NARC Files         
			\*--------------------------*/
			
			foreach (NDSFile f in narcs)
			{
				NDSNARC narcFile = new NDSNARC(bytes, f, debug);
				if (narcFile.isValid)
				{
					Folders.Add(new NDSFolder(f.path, f.name + ".narc", f.parent));
					Folders.AddRange(narcFile.fnt.Folders.ToList());
					Files.AddRange(narcFile.fnt.Files.ToList());
				}
				else
				{
					Files.Add(f);
				}
			}


			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			         Output Files       
			\*--------------------------*/

			foreach (NDSFolder folder in Folders)
			{
			//	System.Console.WriteLine(path + folder.path + folder.name);
				Directory.CreateDirectory(path + folder.path + folder.name);
			}

			foreach (NDSFile file in Files)
			{
				file.GetExtension(bytes);
				//System.Console.WriteLine(path + file.path + file.name + file.extension);
				using (BinaryWriter writer = new BinaryWriter(File.Open(path + file.path + file.name + file.extension, FileMode.Create)))
				{
					writer.Write(bytes, file.offset, file.length);
				}
			}

			DialogResult result = CustomMessageBox.Show(
				 "Finished",
				 "All files have been unpacked",
				 "The ROM was successfully unpacked. Proceed to\n\n"
				 + path + "\n\nnto view your unpacked files.",
				 475, 300,
				 new List<string>(),
				 new List<DialogResult>());
			

			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			             ARM7             
			\*--------------------------*/
			
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

			using (BinaryWriter writer = new BinaryWriter(File.Open(path + "\\Banner.banner", FileMode.Create)))
			{
				writer.Write(bytes, Convert.ToInt32(header.IconOffset), Convert.ToInt32(header.HeaderSize));
			}
		}

		public List<NDSFolder> Folders = new List<NDSFolder>();
		public List<NDSFile> Files = new List<NDSFile>();
	}
}
