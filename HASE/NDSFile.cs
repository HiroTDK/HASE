using HASE.HASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASE
{

	/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			   Folders        
	\*--------------------------*/

	public class NDSFolder : BaseClass
	{
		public NDSFolder(string p, string n, int i)
		{
			path = p;
			name = n;
			parent = i;

			if (p.Length < 1 || p.LastIndexOf("\\") != p.Length - 1)
			{
				path += "\\";
			}
		}

		public string name;
		public string path;
		public int parent;
		public List<int> folders = new List<int>();
		public List<int> files = new List<int>();
	}


	/*¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯*\
			    Files        
	\*--------------------------*/
	
	public class NDSFile : BaseClass
	{
		public NDSFile(string p, string n, int i)
		{
			path = p;
			name = n;
			parent = i;

			if (p.Length < 1 || p.LastIndexOf("\\") != p.Length - 1)
			{
				path += "\\";
			}
		}

		public void SetOffsets(uint start, uint end)
		{
			offset = Convert.ToInt32(start);
			length = Convert.ToInt32(end - start);
		}

		public void GetExtension(byte[] bytes)
		{

			byte[] firstFour = new byte[4];
			Buffer.BlockCopy(bytes, offset, firstFour, 0, 4);

			extension = "";

			switch (System.Text.Encoding.UTF8.GetString(firstFour))
			{
				// Archives
				case "NARC":
					extension = ".narc";
					break;
				case "SDAT":
					extension = ".sdat";
					break;

				// Graphics
				case "RLCN":
					extension = ".nclr";
					break;
				case "RGCN":
					extension = ".ncgr";
					break;
				case "RCSN":
					extension = ".nscr";
					break;
				case "RNAN":
					extension = ".nanr";
					break;
				case "RECN":
					extension = ".ncer";
					break;
				case "RCMN":
					extension = ".nmcr";
					break;
				case " APS":
					extension = ".spa";
					break;

				// Models
				case "BMD0":
					extension = ".nsbmd";
					break;
				case "BTX0":
					extension = ".nsbtx";
					break;
				case "BCA0":
					extension = ".nsbca";
					break;
				case "BVA0":
					extension = ".nsbva";
					break;
				case "BMA0":
					extension = ".nsbma";
					break;
				case "BTP0":
					extension = ".nsbtp";
					break;
				case "BTA0":
					extension = ".nsbta";
					break;

				// Others
				case "MESG":
					extension = ".mesg";
					break;

				// Malformed Header in HG/SS
				case "RPCN":
					extension = ".nclr";
					break;
			}
			// Test for text files by searching for the "EOF" string near the end of the file.
			byte[] EOF = new byte[7];
			Buffer.BlockCopy(bytes, (offset + length - 7), EOF, 0, 7);
			if (System.Text.Encoding.UTF8.GetString(EOF).Contains("EOF"))
			{
				extension = ".txt";
			}

			if (extension.Length > 0 && name.Length > extension.Length)
			{
				int nLength = name.Length - extension.Length;
				string nSub = name.Substring(nLength);

				if (nSub == extension || nSub == extension.ToUpper())
				{
					name = name.Remove(nLength);
				}
			}
		}

		public string path;
		public string name;
		public string extension;
		public int parent;
		public int offset;
		public int length;
	}
}
