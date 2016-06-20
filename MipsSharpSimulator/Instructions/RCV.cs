using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MipsSharpSimulator
{
	public class RCV : Instruction
	{
		public RCV (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			//RCV $1, $2, $3
			//Recebe do processador $1, $2 bytes e os armazena a partir do endereço de memória $3
			var valorIp = Convert.ToInt32(RegisterRepository.Current.Get (Parameters [1]));
			var ip = NetworkIdsRepository.Current.Get (valorIp);

			try {
				
				while (true) {
					
					if (SocketMessageRepository.Current.HasValue (ip.Ip)) {
						var value = SocketMessageRepository.Current.Get (ip.Ip);
						var size = Convert.ToInt32 (Parameters [2]);
						var address = Convert.ToInt32 (RegisterRepository.Current.Get (Parameters [3]));
						
						DataSegmentRepository.Current.SetByte (address, value, size);
						
						SocketMessageRepository.Current.Remove (ip.Ip);
						
						Console.WriteLine("recebendo os valores {0} para o ip {1}", value, ip);
						
						break;
					}
					
				}
			} 
			catch
			{
				Console.WriteLine ("******************************* ERRO *******************************");
				Console.WriteLine ("Erro ao receber do ip {0} o valor {1}", ip, SocketMessageRepository.Current.Get (ip.Ip));
				Console.WriteLine ("******************************* ERRO *******************************");
			}
		}
	}
}

