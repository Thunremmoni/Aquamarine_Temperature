using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace AiR_1._1._0_BETA
{
	class Program
	{
		public class Date_y_m_d	//日期
		{
			public int year, month, day;
			public string String() {
				return this.year.ToString() + "-" + this.month.ToString() + "-" + this.day.ToString();
			}
			public Date_y_m_d Make(string inp)
			{
				Date_y_m_d ret = new Date_y_m_d { };
				string[] div = inp.Split('-');
				ret.year = Convert.ToInt32(div[0]);ret.month = Convert.ToInt32(div[1]);ret.day = Convert.ToInt32(div[2]);
				return ret;
			}
		}

		//Static Class
		static class API	//基础
		{
			public static readonly string Version = "1.1.0 BETA";
			public static readonly string Icon = "        ....        ........    ................\n        .]@^        ..../@`.    .,@@@@@@@@]`....\n        ,@@@. ..    .. .@@/.       =@^. ...@@^..\n        /^\\@^...    .. .....       =@^.....,@@..\n    ...,@.,@@. .    ....,]..       =@^.....=@@..\n    .../^..\\@^ .    ....\\@..       =@^..../@/...\n    ..=@...=@@..        @@.        =@/[[@@..\n    ..@@@@@@@@`.        @@.        =@^..,@@.\n    .=@.    =@\\.        @@.        =@^. .=@\\ ...\n    .@^.    .@@`        @@.        =@^. ..\\@^...\n....=@`.    .=@\\...... .@@.........=@^... .@@`..\n...,[[[`    ,[[[[....[[[[[[[[`....[[[[[.....[[[[\n";
			static void Help_show()	//show programs
			{
				Console.WriteLine("AiR Version " + Version + "\n");
				Console.WriteLine("\tESP\t{0}\n\t\t{1}\n", ESP.Overview, ESP.Features);
				Console.WriteLine("\tVMITP\t{0}\n\t\t{1}\n", VMITP.Overview, VMITP.Features);
			}
			public static void Solve(string[] command)
			{
				if (command.Length <= 1)
					Console.WriteLine("ERROR : Too Much Argument\n");
				else if (command[1] != "--help" && command[1] != "-h")
					Console.WriteLine("ERROR : Unknown Command\n");
				else Help_show();
			}
		}
		static class ESP	//痕迹
		{
			public static readonly string Version = "1.0";
			public static readonly string Overview = "Trading Information";
			public static readonly string Features = "Record incoming goods and customer purchase traces";

			public class Note_Trading	//交易痕迹
			{
				public Date_y_m_d date;
				public int ID, price, val, goodID;
				public bool sell;
				public string Note;
				public string String() {
					return (ID.ToString() + " " + date.String() + " " + price.ToString() + " " + val.ToString() + " " + goodID.ToString() + " " + (sell ? "1" : "0") + " " + Note);
				}
				public Note_Trading Make(string inp)
				{
					Note_Trading ret = new Note_Trading { };
					string[] div = inp.Split(' ');
					ret.ID = Convert.ToInt32(div[0]);
					ret.date = new Date_y_m_d { }; ret.date = ret.date.Make(div[1]);
					ret.price = Convert.ToInt32(div[3]);ret.val = Convert.ToInt32(div[4]);ret.goodID = Convert.ToInt32(div[2]);
					div[5] = div[5].ToLower();
					ret.sell = (div[5] == "1" || div[5] == "yes" || div[5] == "sell" || div[5] == "out") ? true : false;
					ret.Note = div[6];
					return ret;
				}
			}
			public static List<Note_Trading> trading_Info;

			public static void Solve(string[] command)
			{
				if (command[0] != "esp")
				{
					Console.WriteLine("ERROR : Unknown Command\n");
					return;
				} else if (command.Length <= 1)
				{
					Console.WriteLine("ERROR : Too Much Argument\n");
					return;
				}

				switch (command[1])
				{
					case "-h":
						Console.WriteLine("ESP Version " + Version);
						Console.WriteLine("\t" + Features + "\n");
						Console.WriteLine("\t--help\t-h\tShow Help and Commands\n");
						Console.WriteLine("\t--all\t-a\tShow All Infomation\n\t\t\tIncluding all historical transaction records\n");
						Console.WriteLine("\t--query\t-q\tQuery and sort records in different ways\n");
						Console.WriteLine("\t--enesp\t-e\tAdd a new trace to the record\n");
						break;
					case "-e":
						if (command.Length < 8) {
							Console.WriteLine("ERROR : Too Much Argument\n");
							return;
						}
						Note_Trading init = new Note_Trading { };
						string makeByThis = (trading_Info.Count == 0 ? "1" : (trading_Info[trading_Info.Count - 1].ID + 1).ToString()) + " ";
						for (int i = 2; i < 8; i++) makeByThis += command[i] + " ";
						init = init.Make(makeByThis);
						Console.WriteLine("New Trace Generated.");
						Console.WriteLine("ID\tDate\t\tProduct ID\tPrice\tQuantity\tI/O\tNote");
						Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t{6}", init.ID, init.date.String(), init.goodID, init.price, init.val, (init.sell ? "OUT" : "IN"), init.Note);
						Console.WriteLine("Add to Record?");
						if (MakeSure()) {
							trading_Info.Add(init);
							Console.WriteLine("Successful Added 1 Trace to the Record");
						} else PressKeyToContinue();
						Console.WriteLine();
						break;
					case "-q":
						Console.WriteLine("Found {0} Trace in Total", trading_Info.Count);
						Console.WriteLine("ID\tDate\t\tProduct ID\tPrice\tQuantity\tI/O\tNote");
						foreach (var it in trading_Info)
							Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t{6}", it.ID, it.date.String(), it.goodID, it.price, it.val, (it.sell ? "OUT" : "IN"), it.Note);
						Console.WriteLine();
						break;
					default:
						Console.WriteLine("ERROR : Unknown Command\n");
						return;
				}
			}
		}
		static class VMITP	//概况
		{
			public static readonly string Version = "1.0";
			public static readonly string Overview = "Virtual Legal Representative";
			public static readonly string Features = "Overview of company accounts and investor profiles";

			public static int Funds, PublicFunds, PrivateFunds, AvaliableProfit, UnavaliableProfit, TotalProfit;
			public static void Solve(string[] command)
			{
				if (command[0] != "vmitp") {
					Console.WriteLine("ERROR : Unknown Command\n");
					return;
				} else if (command.Length <= 1) {
					Console.WriteLine("ERROR : Too Much Argument\n");
					return;
				}

				switch (command[1])
				{
					case "-h":
						Console.WriteLine("VMITP Version " + Version);
						Console.WriteLine("\t" + Features + "\n");
						Console.WriteLine("\t--help\t-h\tShow Help and Commands\n");
						Console.WriteLine("\t--query\t-q\tFund details\n");
						break;
					case "-q":
						Console.WriteLine("Total Funds\tPublic Funds\tPrivate Funds\tAvaliable Profit\tUnavaliable Profit\tTotal Profit");
						Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t\t{4}\t\t\t{5}\n", Funds, PublicFunds, PrivateFunds, AvaliableProfit, UnavaliableProfit, TotalProfit);
						break;
					default:
						Console.WriteLine("ERROR : Unknown Command\n");
						return;
				}
			}
		}

		//MAIN
		static void Main(string[] args)
		{
			string[] div;

			//Activate
			const string DataFile = @".\database.dbf";
			Console.WriteLine("AiR Version " + API.Version);
			System.Threading.Thread.Sleep(1000);
			Console.WriteLine(API.Icon);

			//Open Files
			Console.WriteLine("Opening Files...\n");
			ESP.trading_Info = new List<ESP.Note_Trading> { };
			try
			{
				StreamReader readStream = new StreamReader(DataFile, Encoding.Default);
				Console.WriteLine(@"File 'database.dbf' has been successfully opened");
				bool esp_freshed = false, vmitp_freshed = false, mitc_freshed = false;
				while (true)
				{
					string directory = readStream.ReadLine();
					if (directory == null) break;
					switch (directory)
					{
						case "vmitp":
							vmitp_freshed = true;
							div = readStream.ReadLine().Split(' ');
							VMITP.Funds = Convert.ToInt32(div[0]); VMITP.PublicFunds = Convert.ToInt32(div[1]); VMITP.PrivateFunds = Convert.ToInt32(div[2]); VMITP.AvaliableProfit = Convert.ToInt32(div[3]); VMITP.UnavaliableProfit = Convert.ToInt32(div[4]); VMITP.TotalProfit = Convert.ToInt32(div[5]);
							Console.WriteLine("VMITP Successful loaded!");
							break;
						case "esp":
							esp_freshed = true;
							int cnt = Convert.ToInt32(readStream.ReadLine());
							ESP.Note_Trading init;
							for (int i = 0; i < cnt; i++)
							{
								init = new ESP.Note_Trading { };init = init.Make(readStream.ReadLine());
								ESP.trading_Info.Add(init);
							}
							Console.WriteLine("ESP Trading Info  Successful loaded\nSummary (+) {0} Trace Gengrated", cnt);
							break;
						default:
							Console.WriteLine("ERROR : File cannot be parsed, it may be corrupted");
							goto CORRUPTED;
					}
				}
			CORRUPTED:
				Console.WriteLine("INFO : Finished Generate");
				if (vmitp_freshed && esp_freshed && mitc_freshed) Console.WriteLine("INFO : All files loaded whitout any error");
				else
				{
					if (!vmitp_freshed) Console.WriteLine("ERROR : VMITF failed to up to date");
					if (!esp_freshed) Console.WriteLine("ERROR : ESP failed to up to date");
					if (!mitc_freshed) Console.WriteLine("ERROR : MITC failed to up to date");
					Console.WriteLine("WARNING : Will start with a blank sheet in some of the tools");
				}
				readStream.Close();
			} catch
			{
				Console.WriteLine("ERROR : Cannot Open file '{0}'\nERROR : Data cannot be loaded\nWARNING : Will start with a blank sheet\nWARNING : Progress has been killed beacuse there's too much ERRORs", DataFile);
				PressKeyToContinue();
			}

			//Run Command
			Console.WriteLine("\n");
			string input;
			while (true)
			{
				Console.Write(">$ ");
				input = Console.ReadLine();
				if (input == "") continue;
				div = input.Split(' ');
				for (int i = 0; i < div.Length; i++) div[i] = div[i].ToLower();

				Console.Write("\n");
				switch (div[0])
				{
					case "clear":
						Console.Clear();
						break;
					case "air":
						API.Solve(div);
						break;
					case "exit":
						goto EXITPROGRAM;
					case "vmitp":
						VMITP.Solve(div);
						break;
					case "esp":
						ESP.Solve(div);
						break;

					default:
						Console.WriteLine("ERROR : Unknown Command\n");
						break;
				}
			}

		EXITPROGRAM:
			Console.WriteLine("Saving work information and records data...");
			FileStream fs_out = new FileStream(DataFile, FileMode.Create);
			StreamWriter sw_out = new StreamWriter(fs_out);

			sw_out.WriteLine("vmitp");
			sw_out.WriteLine("{0} {1} {2} {3} {4} {5}", VMITP.Funds, VMITP.PublicFunds, VMITP.PrivateFunds, VMITP.AvaliableProfit, VMITP.UnavaliableProfit, VMITP.TotalProfit);
			Console.WriteLine("VMITP Gengrate Finished");

			sw_out.WriteLine("esp\n" + ESP.trading_Info.Count.ToString());
			foreach (var it in ESP.trading_Info)
				//sw_out.WriteLine("{0} {1} {2} {3} {4} {5} {6}", it.ID, it.date.ToString(), it.goodID, it.price, it.val, (it.sell ? "1" : "0"), it.Note);
				sw_out.WriteLine(it.String());
			Console.WriteLine("ESP Gengrate Finished");

			//sw_out.WriteLine("mitc\n");
			Console.WriteLine("MITC Gengrate Finished");

			sw_out.Flush();sw_out.Close();fs_out.Close();
			Console.WriteLine("Finished!");
			return;
		}

		static bool MakeSure()
		{
			Console.Write("You are working on a risky operation that will modify the record directly and is difficult to revoke.\nAre you sure to continue? (y/n) > ");
			string inp = Console.ReadLine().ToLower();
			if (inp == "y" || inp == "yes" || inp == "ok") return true;
			else return false;
		}
		static void PressKeyToContinue()
		{
			Console.Write("Press any key to continue."); Console.ReadKey();
		}
	}
}