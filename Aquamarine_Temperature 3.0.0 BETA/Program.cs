using System;
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
					Price.Sort();
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

			public enum DoSums
			{
				Afund,Mfund,Ainc,Minc
			};
			public static DoSums Make_DoSums (int it)
			{
				DoSums ret = new DoSums { };
				switch (it)
				{
					case 1:ret = DoSums.Afund;break;
					case 2:ret = DoSums.Mfund;break;
					case 3:ret = DoSums.Ainc;break;
					case 4:ret = DoSums.Minc;break;
					default: break;
				}
				return ret;
			}
			public static string ToString(DoSums it)
			{
				switch (it)
				{
					case DoSums.Afund:return "+Fund";
					case DoSums.Mfund:return "-Fund";
					case DoSums.Ainc:return "+Income";
					case DoSums.Minc:return "-Income";
					default: break;
				}return "";
			}
			public class Rec
			{
				public Templates.Collections.Date date;
				public DoSums type;  //+fund -fund +inc -inc
				public int val; 
				public string String(char it = ' ')
				{
					string a = type.ToString();
					/*switch (type)
					{
						case 1: a = "+fund";break;
						case 2: a = "-fund";break;
						case 3: a = "+income";break;
						case 4: a = "-income";break;
						default: a = "";break;
					}*/
					return date.String() + it + a + it + val.ToString();
				}
			}
			public static Rec Make_Rec(Templates.Collections.Date date,DoSums type,int val)
			{
				Rec ret = new Rec { };
				ret.date = date; ret.type = type;ret.val = val;
				return ret;
			}
			public class Investor
			{
				public string name;
				public int fund, income;
				public List<Rec> rec;
			}
			public static Investor Make_Investor(string name)
			{
				Investor ret = new Investor { };
				ret.rec = new List<Rec> { };ret.name = name;
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
		public static class AT
		{
			public static void Solve(string[] args)
			{
				if (args.Length <= 1) {
					Console.WriteLine("Command syntax is incorrect"); return;
				}
				switch (args[1])
				{
					case "-h": FileManager.ShowFile(@".\docs\Aquamarine_Temperature_hp.file"); break;
					case "--help": FileManager.ShowFile(@".\docs\Aquamarine_Temperature_hp.file"); break;
					default:
						Console.WriteLine("Command syntax is incorrect"); return;
				}

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
			}	//UF
			static void Query()
			{
				Console.WriteLine("There are {0} records in total", trans.Count);
				Console.WriteLine("\n#\tDate\tItem\tI/O\tPrice\tProfit");
				int i = 0;
				foreach (var it in trans)
					Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}", ++i, it.date.String(), it.Item, it.IO ? "IN" : "OUT", it.price, it.totProfit);
			}
			static void Delete()
			{
				Query();
				try
				{
					trans.RemoveAt(Convert.ToInt32(Tool.Read("The serial number of the trace that needs to be deleted >")));
				} catch { Console.WriteLine("Unknown Error");return; } 
				finally { Console.WriteLine("Finished"); }
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
					case "-d": Delete();break;
					case "--delete": Delete();break;
					case "-q": Query();break;
					case "--query": Query();break;
					default:
						Console.WriteLine("Command syntax is incorrect"); return;
				}
			}
		}
		public static class MITMF
		{
			public static int AvaFund, TotIncome, TotFund;
			public static List<Objs.Trace.Investor> investor;
			static int GetPos(string name)
			{
				for (int i = 0; i < investor.Count; i++)
					if (investor[i].name == name) return i;
				return -1;
			}

			static void Attend()
			{
				string name = Tool.Read("Name >");
				if (GetPos(name) != -1) { Console.WriteLine("ERROR : Name conflict");return; }
				investor.Add(Objs.Trace.Make_Investor(name));
				Console.WriteLine("Finished");
			}
			static void Insert()
			{
				string name = Tool.Read("Target Client >");
				int pos = GetPos(name);
				if (pos == -1) { Console.WriteLine("ERROR : Target does not exist");return; }
				Console.WriteLine("Options : \n1\t+Fund\n2\t-Fund\n3\t+Income\n4\t-Income");
				int opt = Convert.ToInt32(Tool.Read("Option >"));
				if (!(opt <= 1 && opt <= 4)) { Console.WriteLine("ERROR : Unkonwn Option");return; }
				Templates.Collections.Date date = Templates.Collections.Make_Date(Tool.Read("Date >"));
				int val = Convert.ToInt32(Tool.Read("Value >"));
				investor[pos].rec.Add(Objs.Trace.Make_Rec(date, Objs.Trace.Make_DoSums(opt), val));

				switch (opt)
				{
					case 1: AvaFund += val;TotFund += val;investor[pos].fund += val; break;
					case 2: AvaFund -= val;TotFund -= val;investor[pos].fund -= val; break;
					case 3: TotIncome += val;investor[pos].income += val;break;
					case 4: TotIncome -= val;investor[pos].income -= val;break;
					default: break;
				}
				Console.WriteLine("Finished!");
			}
			static void Record()
			{
				
			}
			static void Query()
			{
				Console.WriteLine("Avalible Fund\tTotal Fund\tTotal Income");
				Console.WriteLine("{0}\t\t{1}\t\t{2}\n", AvaFund, TotFund, TotIncome);
				Console.WriteLine("{0} Investor(s) in total", investor.Count);
				Console.WriteLine("#\tname\tFund\tIncome");
				int i = 0;
				foreach (var it in investor)
					Console.WriteLine("{0}\t{1}\t{2}\t{3}", (++i).ToString(), it.name, it.fund, it.income);
			}
			public static void Solve(string[] args)
			{
				if (args.Length <= 1) {
					Console.WriteLine("Command syntax is incorrect"); return;
				}
				switch (args[1])
				{
					case "-h": FileManager.ShowFile(@".\docs\mitmf_hp.file"); break;
					case "--help": FileManager.ShowFile(@".\docs\mitmf_hp.file"); break;
					case "-a": Attend();break;
					case "--attend": Attend();break;
					case "-i": Insert();break;
					case "--insert": Insert();break;
					case "-q": Query();break;
					case "--query": Query();break;
					case "-r": Record();break;
					case "--record": Record();break;
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
			ToolKit.MITMF.investor = new List<Objs.Trace.Investor> { };
		}

		public static void Solve(string arg)
		{
			arg = arg.ToLower();
			string[] div = arg.Split(' ');
			if (div.Length <= 0) return;
			switch (div[0])
			{
				case "cls": Console.Clear(); return;
				case "exit": Environment.Exit(0); break;
				case "at": ToolKit.AT.Solve(div);break;
					
					//Tools
				case "warh":
					ToolKit.WARH.Solve(div);
					break;
				case "fimng":
					ToolKit.FIMNG.Solve(div);
					break;
				case "mitmf":
					ToolKit.MITMF.Solve(div);
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
