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
				/*
				fnt.FolderCount++;
				string[] newFolders = new string[fnt.FolderCount];
				fnt.Folders.CopyTo(newFolders, 0);
				newFolders[fnt.FolderCount - 1] = "\\Overlays";
				fnt.Folders = newFolders;

				for (int i = 0; i < fnt.FirstFile; i++)
					fnt.Files[i] = "\\Overlays\\Overlay " + i + ".bin";
				*/
			}
		
				
			/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			         File Scanner         
			\*--------------------------*/
			/*

			Folders = new List<string>();
			
			foreach (string s in fnt.Folders)
			{
				Folders.Add(path + s);
			}

			Files = new List<NDSFile>();

			for (int i = 0; i < fat.FileCount; i++)
			{
				NDSFile file = new NDSFile(bytes, path + fnt.Files[i], Convert.ToInt32(fat.FileStart[i]), Convert.ToInt32(fat.FileEnd[i] - fat.FileStart[i]), debug);
				
				if (file.extension == ".narc")
				{

				}
				else
				{
					Files.Add(file);
				}
			}
			
			foreach (string folder in Folders)
			{
				if (!Directory.Exists(folder))
				{
					Directory.CreateDirectory(folder);
				}
			}

			foreach (NDSFile file in Files)
			{
				using (BinaryWriter writer = new BinaryWriter(File.Open(file.path + file.extension, FileMode.Create)))
				{
					writer.Write(bytes, file.start, file.length);
				}
			}
			*/
		}

		public List<string> Folders;
		public List<NDSFile> Files;
	}
}
