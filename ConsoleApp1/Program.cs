using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Console.ReadLine();
			//try
			//{
			//	StreamReader sr = new StreamReader(@".\" + path, Encoding.Default);
			//	string output;
			//	while ((output = sr.ReadLine()) != null)
			//		Console.WriteLine(output);
			//} catch {
			//	Console.WriteLine("ERROR : File Doesn't exist!!");
			//}
			//FileStream fs = new FileStream(path, FileMode.Create);
			//StreamWriter sw = new StreamWriter(fs);
			//for (int i = 0; i < 3; i++)
			//	sw.WriteLine(Console.ReadLine());
			//sw.Flush();sw.Close();fs.Close();
			Console.WriteLine("Format C:");
			if (MakeSure()) Console.WriteLine("You've thought this through");
			else Console.WriteLine("KILLED");
		}
		static bool MakeSure()
		{
			Console.Write("You are working on a risky operation that will modify the record directly and is difficult to revoke.\nAre you sure to continue? (y/n) > ");
			string inp = Console.ReadLine().ToLower();
			if (inp == "y" || inp == "yes" || inp == "ok")
				return true;
			else return false;
		}
	}
}