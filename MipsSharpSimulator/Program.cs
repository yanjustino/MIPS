using System;
using System.Threading;

namespace MipsSharpSimulator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var server = new ServerSocket ();

			Interpreter interpreter = null;

			if (args[0] == "-m")
				interpreter = new Interpreter ("master.asm");
			else if (args[0] == "-s")
				interpreter = new Interpreter ("slave.asm");

			Thread threadServer = new Thread(()=>{
				server.Start (Convert.ToInt32(args[1]));
			});

			Thread threadInterpreter = new Thread(()=>{
				interpreter.Start();
			});

			threadServer.Start ();
			threadInterpreter.Start ();

			Console.Read ();
		}
	}
}
