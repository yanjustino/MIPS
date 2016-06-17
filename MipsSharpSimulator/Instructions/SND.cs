using System;

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
			var size = Convert.ToInt32 (Parameters [2]);
			var address = Convert.ToInt32(RegisterRepository.Current.Get (Parameters [3]));

			var message = DataSegmentRepository.Current.GetBytes (size, address);

			var socket = new ClientSocket ();
			socket.Send (message);
		}
	}
}

