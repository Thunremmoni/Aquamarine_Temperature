﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Aquamarine_Temperature
{
	namespace Templates //模板
	{
		public class Collections
		{
			public class Pair<Type>
			{
				public Type first, second;
				string String()
				{
					return first.ToString() + " " + second.ToString();
				}
			}
			public static Pair<T> Make_Pair<T>(T a, T b)
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
			public static Date Make_Date(int y, int m, int d)
			{
				Date ret = new Date { };
				ret.year = y; ret.month = m; ret.day = d;
				return ret;
			}
			public static Date Make_Date(string it)
			{
				Date ret = new Date { };
				string[] div = it.Split('-');
				if (div.Length < 3) div = it.Split(' ');
				if (div.Length < 3) throw new ERROR("Did not give enough information or the format is wrong");
				ret.year = Convert.ToInt32(div[0]); ret.month = Convert.ToInt32(div[1]); ret.day = Convert.ToInt32(div[2]);
				return ret;
			}
			public static Date Make_Date(string[] div, int pos = 0)
			{
				Date ret = new Date { };
				try
				{
					ret.year = Convert.ToInt32(div[pos]);
					ret.month = Convert.ToInt32(div[pos + 1]);
					ret.day = Convert.ToInt32(div[pos + 2]);
				} catch { }
				return ret;
			}
			public static Date Make_Date(DateTime it)
			{
				Date ret = new Date { };
				ret.year = it.Year; ret.month = it.Month; ret.day = it.Day;
				return ret;
			}
		}
		public class ERROR : ApplicationException
		{
			public ERROR(string message) : base(message) { }
		}
	}
	namespace Objs  //对象
	{
		public static class Trace
		{
			public class Good
			{
				public string name;
				public int inStoreHouse;
				public List<int> Price;
				public string String()
				{
					return name + " " + inStoreHouse.ToString();
				}
				public bool Avaliable(int Quantity = 1)
				{
					return inStoreHouse >= Quantity;
				}
				public void Refresh()
				{
					Price.Sort(); Price.Reverse();
				}
			}    //货物
			public static Good Make_Good(string name, int nums)
			{
				Good ret = new Good { };
				ret.name = name; ret.inStoreHouse = nums;
				ret.Price = new List<int> { };
				return ret;
			}
			public static Good Make_Good(string it)
			{
				Good ret = new Good { };
				ret.Price = new List<int> { };
				string[] div = it.Split(' ');
				try { ret.name = div[0]; ret.inStoreHouse = Convert.ToInt32(div[1]); } catch { }
				return ret;
			}
			public static Good Make_Good(string[] div, int pos = 0)
			{
				Good ret = new Good { };
				ret.Price = new List<int> { };
				try { ret.name = div[pos]; ret.inStoreHouse = Convert.ToInt32(div[1]); } catch { }
				return ret;
			}

			public class Trans
			{
				public Templates.Collections.Date date;
				public string Item;
				public bool IO;
				public int price;
				public int totProfit;
				public string String()
				{
					return date.ToString() + " " + Item.ToString() + " " + IO.ToString() + " " + price.ToString() + " " + totProfit.ToString();
				}
			}
			public static Trans Make_Trans()
			{
				Trans ret = new Trans { };
				ret.date = new Templates.Collections.Date { };
				return ret;
			}
		}
	}
	namespace ToolKit
	{
		public static class FileManager
		{
			public static bool DeleteFile(string path)  //删除文件/文件夹
			{
				try
				{
					if (File.GetAttributes(path) == FileAttributes.Directory)
						Directory.Delete(path);
					else DeleteFile(path);
				} catch { return false; }
				return true;
			}
			public static bool CopyTo(string path, string targetPath)   //克隆文件
			{
				try
				{
					FileInfo file = new FileInfo(path);
					file.CopyTo(targetPath, true);
				} catch { return false; }
				return true;
			}
			public static void OpenFile(string path)
			{
				Console.WriteLine("Start reading data from " + path);
				try
				{
					StreamReader readStream = new StreamReader(path, Encoding.Default);
					string read;
					while ((read = readStream.ReadLine()) != null)
						switch (read)
						{
							default:
								Console.WriteLine("WARNING : Unknow data tag " + read);
								break;
						}
					Console.WriteLine("Finished!");
				} catch
				{
					Console.WriteLine("ERROR : An error occurred during reading. Target file failed to read successfully!");
				}
			}		//Unfinish
			public static void SaveFileAs(string path)
			{
				FileStream fs = new FileStream(path, FileMode.Create); StreamWriter writeStream = new StreamWriter(fs);

				writeStream.Flush(); writeStream.Close(); fs.Close();
			}   //Unfinish
			public static void ShowFile(string path)
			{
				try
				{
					StreamReader readStream = new StreamReader(path, Encoding.Default);
					string show;
					while ((show = readStream.ReadLine()) != null)
						Console.WriteLine(show);
				} catch { Console.WriteLine("Unknown Error"); }
			}
		}
		public static class WARH
		{
			public static List<Objs.Trace.Good> goods;
			static bool find(string name)
			{
				foreach(var it in goods) if (it.name == name) return true;
				return false;
			}
			static int GetIndex(string name)
			{
				for (int i = 0; i < goods.Count; i++) if (goods[i].name == name) return i;
				return -1;
			}

			static void AddTrace()
			{
				Console.WriteLine("A new item will be added");
				Console.Write("Name: >");
				string initName = Console.ReadLine();
				if (find(initName)) { Console.WriteLine("ERROR : Item already exists");return; }
				Console.Write("Quantity: >");
				string initQuantity = Console.ReadLine();
				if (Tool.Inquiry())
				{
					goods.Add(Objs.Trace.Make_Good(initName, Convert.ToInt32(initQuantity)));
					Console.WriteLine("Finished!");
				}
			}
			static void Query()
			{
				if (goods.Count <= 0) { Console.WriteLine("Warehouse is Empty!");return; }
				Console.WriteLine(goods.Count.ToString() + " items in total\n");
				Console.WriteLine("Name\tQuantity");
				foreach (var it in goods) Console.WriteLine("{0}\t{1}", it.name, it.inStoreHouse);
			}
			static void Delta()
			{
				Console.Write("Name >");
				string initName = Console.ReadLine();
				if (!find(initName)) { Console.WriteLine("ERROR : Item doesn't exist");return; }
				Console.Write("Delta >");
				string initCg = Console.ReadLine();
				foreach (var it in goods) if (it.name == initName)
					{
						it.inStoreHouse += Convert.ToInt32(initCg);
						Console.WriteLine("Finished!");
						return;
					}
			}
			static void Delete()
			{
				string target = Tool.Read("Name >");
				if (!find(target)) Console.WriteLine("ERROR : Item does not exist!");
				else
				{
					goods.RemoveAt(GetIndex(target));
					Console.WriteLine("Finished!");
				}
			}
			public static void Solve(string[] args)
			{
				if (args.Length <= 1) {
					Console.WriteLine("Command syntax is incorrect"); return;
				}
				switch (args[1])
				{
					case "-h": FileManager.ShowFile(@".\docs\warh_hp.file");break;
					case "--help": FileManager.ShowFile(@".\docs\warh_hp.file"); break;
					case "-i": AddTrace();break;
					case "--insert": AddTrace();break;
					case "-q": Query();break;
					case "--query": Query();break;
					case "-c": Delta();break;
					case "-d": Delete();break;
					case "--delete": Delete();break;
					default:
						Console.WriteLine("Command syntax is incorrect"); return;
				}
			}
		}
		public static class FIMNG
		{
			public static List<Objs.Trace.Trans> trans;

			static void Attend()
			{
				string answ;
				Objs.Trace.Trans add = Objs.Trace.Make_Trans();
				try
				{
					answ = Tool.Read("Date >"); add.date = Templates.Collections.Make_Date(answ);
				}catch(Templates.ERROR er) { Console.WriteLine(er.Message);return; }
				answ = Tool.Read("Item >");add.Item = answ;
				answ = Tool.Read(@"I/O >");add.IO = answ == "i";
				answ = Tool.Read("Price >");add.price = Convert.ToInt32(answ);

				trans.Add(add);
				Console.WriteLine("Finish!");
			}
			public static void Solve(string[] args)
			{
				if (args.Length <= 1)
				{
					Console.WriteLine("Command syntax is incorrect"); return;
				}
				switch (args[1])
				{
					case "-h": FileManager.ShowFile(@".\docs\fimng_hp.file"); break;
					case "--help": FileManager.ShowFile(@".\docs\fimng_hp.file"); break;
					case "-a": Attend();break;
					case "--attend": Attend();break;
					default:
						Console.WriteLine("Command syntax is incorrect"); return;
				}
			}
		}
	}
	public static class Tool
	{
		public static string Merge(string[] args, char div)
		{
			string ret = args[0];
			for (int i = 1; i < args.Length; i++) ret += div + args[i];
			return ret;
		}
		public static string Merge(string[] args, int begin, int end, char div)
		{
			string ret = args[begin];
			for (int i = begin + 1; i < end; i++) ret += div + args[i];
			return ret;
		}
		public static bool Inquiry()
		{
			Console.Write("Are you sure you want to do this?(y,n) >");
			string a = Console.ReadLine(); a = a.ToLower();
			return a[0] == 'y';
		}
		public static string Read(string query)
		{
			Console.Write(query);
			return Console.ReadLine();
		}
	}


	class Program
	{
		public static void Activate()
		{
			Console.WriteLine("Aquamarine_Temperature [Version : 3.0.0 BETA]\n");
			ToolKit.WARH.goods = new List<Objs.Trace.Good> { };
			ToolKit.FIMNG.trans = new List<Objs.Trace.Trans> { };
		}

		public static void Solve(string arg)
		{
			arg = arg.ToLower();
			string[] div = arg.Split(' ');
			if (div.Length <= 0) return;
			switch (div[0])
			{
				case "cls":
					Console.Clear();
					return;
				case "exit":
					Environment.Exit(0);
					break;
				case "warh":
					ToolKit.WARH.Solve(div);
					break;

				default:
					Console.WriteLine("'{0}' is not an internal or external command.", div[0]);
					break;
			}
			Console.WriteLine();
		}

		static void Main(string[] args)
		{
			Activate();
			while (true)
			{
				Console.Write(@"$> ");
				string inp = Console.ReadLine();
				Solve(inp);
			}
		}
	}
}
