using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	namespace Templates	//模板
	{
		class Collections
		{
			public class Pair<Type>
			{
				public Type first, second;
			}
			static Pair<T> Make_Pair<T>(T a, T b)
			{
				Pair<T> ret = new Pair<T> { };
				ret.first = a; ret.second = b;
				return ret;
			}

			//表示一个日期
			//格式 : yyyy-mm-dd
			public class Date : IComparable
			{
				public int year, month, day;
				public int CompareTo(object obj)
				{
					Date comp = obj as Date;
					if (year == comp.year && month == comp.month && day == comp.day) return 0;
					else if (year != comp.year) return year < comp.year ? -1 : 1;
					else if (month != comp.month) return month < comp.month ? -1 : 1;
					else return day < comp.day ? -1 : 1;
				}
				public string String()
				{
					return year.ToString() + "-" + month.ToString() + "-" + day.ToString();
				}
			}
			public static Date Make_Date(int y,int m,int d)
			{
				Date ret = new Date { };
				ret.year = y;ret.month = m;ret.day = d;
				return ret;
			}
			public static Date Make_Date(string it)
			{
				Date ret = new Date { };
				string[] div = it.Split('-');
				if (div.Length < 3) div = it.Split(' ');
				if (div.Length < 3) return ret;
				ret.year = Convert.ToInt32(div[0]);ret.month = Convert.ToInt32(div[1]);ret.day = Convert.ToInt32(div[2]);
				return ret;
			}
			public static Date Make_Date(string[] div, int pos = 0)
			{
				Date ret = new Date { };
				try {
					ret.year = Convert.ToInt32(div[pos]);
					ret.month = Convert.ToInt32(div[pos + 1]);
					ret.day = Convert.ToInt32(div[pos + 2]);
				} catch { }
				return ret;
			}
		}
	}
	namespace Objects	//对象
	{
		class Trace
		{
			public class Good
			{
				public string name;
				public int inStoreHouse;
				public string String()
				{
					return name + " " + inStoreHouse.ToString();
				}
			}	 //货物
			public Good Make_Good(string name,int nums)
			{
				Good ret = new Good { };
				ret.name = name;ret.inStoreHouse = nums;
				return ret;
			}
			public Good Make_Good(string it)
			{
				Good ret = new Good { };
				string[] div = it.Split(' ');
				try{ret.name = div[0]; ret.inStoreHouse = Convert.ToInt32(div[1]); } catch { }
				return ret;
			}
			public Good Make_Good(string[] div,int pos = 0)
			{
				Good ret = new Good { };
				try { ret.name = div[pos]; ret.inStoreHouse = Convert.ToInt32(div[1]); } catch { }
				return ret;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//string path = Console.ReadLine();
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

			Dictionary<int, int> map = new Dictionary<int, int> { { 1, 2 },{ 2, 3 },{ 100, 2 } };

		}
	}
}