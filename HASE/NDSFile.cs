using HASE.HASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASE
{
	class NDSFile : BaseClass
	{
		public string path;
		public string extension;
		public int start;
		public int length;

		public NDSFile(byte[] b, string p, int s, int l, bool debug)
		{
			path = p;
			start = s;
			length = l;
			extension = GetExtension(b);
			
			if (extension.Length > 0)
			{
				int pLength = path.Length - extension.Length;
				string pSub = path.Substring(pLength);

				if (pSub == extension || pSub == extension.ToUpper())
				{
					System.Console.WriteLine(pSub);
					path = path.Remove(pLength);
				}
			}
		}

		public string GetExtension(byte[] bytes)
		{

			byte[] firstFour = new byte[4];
			Buffer.BlockCopy(bytes, start, firstFour, 0, 4);

			switch (System.Text.Encoding.UTF8.GetString(firstFour))
			{
				// Archives
				case "NARC":
					return ".narc";
				case "SDAT":
					return ".sdat";

				// Graphics
				case "RLCN":
					return ".nclr";
				case "RGCN":
					return ".ncgr";
				case "RCSN":
					return ".nscr";
				case "RNAN":
					return ".nanr";
				case "RECN":
					return ".ncer";
				case "RCMN":
					return ".nmcr";
				case " APS":
					return ".spa";

				// Models
				case "BMD0":
					return ".nsbmd";
				case "BTX0":
					return ".nsbtx";
				case "BCA0":
					return ".nsbca";
				case "BVA0":
					return ".nsbva";
				case "BMA0":
					return ".nsbma";
				case "BTP0":
					return ".nsbtp";
				case "BTA0":
					return ".nsbta";

				// Others
				case "MESG":
					return ".mesg";

				// Malformed Header in HG/SS
				case "RPCN":
					return ".nclr";
			}

			byte[] EOF = new byte[7];
			Buffer.BlockCopy(bytes, (start + length - 7), EOF, 0, 7);
			if (System.Text.Encoding.UTF8.GetString(EOF).Contains("EOF"))
			{
				return ".txt";
			}

			return "";
		}
	}
}
