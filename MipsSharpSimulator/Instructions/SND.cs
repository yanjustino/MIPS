using System;
using System.Threading;

namespace MipsSharpSimulator
{
	public class SND : Instruction
	{
		public SND (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			var valorIp = Convert.ToInt32(RegisterRepository.Current.Get (Parameters [1]));
			var ip = NetworkIdsRepository.Current.Get (valorIp);

			try {
				
				var size = Convert.ToInt32 (Parameters [2]);
				var address = Convert.ToInt32(RegisterRepository.Current.Get (Parameters [3]));
				var message = string.Join(",", DataSegmentRepository.Current.GetBytes (size, address));
				
				var socket = new ClientSocket ();
				socket.Send (ip.ToString(), message);

				Console.WriteLine("enviando os valores {0} para o ip {1}", message, ip);

				Thread.Sleep (5000);
			} catch (Exception) {
				Console.WriteLine ("******************************* ERRO *******************************");
				Console.WriteLine ("Erro ao conectar-se ao ip {0}", ip);
				Console.WriteLine ("******************************* ERRO *******************************");
			}
		}
	}
}

