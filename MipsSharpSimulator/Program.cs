using System;
using System.Threading;

namespace MipsSharpSimulator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args[0] == null)
				throw new Exception("informe o tipo do serviço -m para Master ou -s para Slave");
			if (args[1] == null)
				throw new Exception("informe a porta");

			var server = new ServerSocket ();
			Interpreter interpreter = null;

			if (args [0] == "-m")
				interpreter = new Interpreter ("master.asm");
			else if (args [0] == "-s")
				interpreter = new Interpreter ("slave.asm");

			Thread threadServer = new Thread (() => {
				server.Start (Convert.ToInt32 (args [1]));
			});

			threadServer.Start ();

			while (true) {
				if (threadServer.ThreadState == ThreadState.Running) {
					Thread threadInterpreter = new Thread (() => {
						interpreter.Start ();
					});
					threadInterpreter.Start ();
					break;
				}
			}

			Console.Read ();
		}
	}
}
