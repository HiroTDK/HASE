using HASE.HASE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			
			Folders.Add(new NDSFolder("\\Overlays", "Overlays", 0));
		
			for (int i = 0; i < fnt.FirstFile; i++)
			{
				fnt.Files[i].path = "\\Overlays\\Overlay " + i + ".bin";
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
				NDSNARC narcFile = new NDSNARC(bytes, f);

				Folders.Add(new NDSFolder(f.path, f.name, f.parent));
			}





		}

		public List<NDSFolder> Folders = new List<NDSFolder>();
		public List<NDSFile> Files = new List<NDSFile>();
	}
}
