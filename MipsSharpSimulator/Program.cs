using System;
using System.Threading;

namespace MipsSharpSimulator
{
	public class Program
	{
		public static string Environment = "MASTER";

		public static void Main (string[] args)
		{
			ValidateArgs (args);

			var interpreter = InitializeInterpreter (args);

			StartSocketServices (args, interpreter);

			RegisterRepository.Current.PrintValue ();

			Console.Read ();
		}

		static void StartSocketServices (string[] args, Interpreter interpreter)
		{
			var server = new ServerSocket ();

			Thread serverProcess = new Thread (() =>  {
				server.Start (Convert.ToInt32 (args [1]));
			});

			serverProcess.Start ();

			Thread.Sleep (1000);

			Thread interpreterProcess = new Thread (() =>  {
				interpreter.Start ();
			});

			interpreterProcess.Start ();
		}

		static Interpreter InitializeInterpreter (string[] args)
		{
			Interpreter interpreter = null;
			if (args [0] == "-m") {
				Environment = "MASTER";
				Console.WriteLine ("Preparando Interpretador Master");
				interpreter = new Interpreter ("master.asm");
			}
			else if (args [0] == "-s") {
				Environment = "SLAVE";
				Console.WriteLine ("Preparando Interpretador Slave");
				interpreter = new Interpreter ("slave.asm");
			}
			return interpreter;
		}

		static void ValidateArgs (string[] args)
		{
			if (args [0] == null)
				throw new Exception ("informe o tipo do serviço -m para Master ou -s para Slave");
			if (args [1] == null)
				throw new Exception ("informe a porta");
		}
	}
}
