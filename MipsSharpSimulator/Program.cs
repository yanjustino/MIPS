using System;
using System.Threading;

namespace MipsSharpSimulator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args [0] == null)
				throw new Exception ("informe o tipo do serviço -m para Master ou -s para Slave");
			if (args [1] == null)
				throw new Exception ("informe a porta");

			var server = new ServerSocket ();
			Interpreter interpreter = null;

			if (args [0] == "-m") {
				Console.WriteLine ("Preparando Interpretador Master");
				interpreter = new Interpreter ("master.asm");
			} else if (args [0] == "-s") {
				Console.WriteLine ("Preparando Interpretador Slave");
				interpreter = new Interpreter ("slave.asm");
			}

			Thread threadServer = new Thread (() => {
				server.Start (Convert.ToInt32 (args [1]));
			});

			threadServer.Start ();

			Thread.Sleep (1000);

			Thread threadInterpreter = new Thread (() => {
				interpreter.Start ();
			});

			threadInterpreter.Start ();

			RegisterRepository.Current.PrintValue ();

			Console.Read ();
		}
	}
}
