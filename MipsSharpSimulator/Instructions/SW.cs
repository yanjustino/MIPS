using System;

namespace MipsSharpSimulator
{
	public class SW : Instruction
	{
		public SW (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			var index = Convert.ToInt32(this.Parameters [2].Substring (0, 1));
			var regis = this.Parameters [2].Remove (0, 1).Replace ("(", "").Replace (")", "");

			var address = index + Convert.ToInt32 (RegisterRepository.Current.Get (regis));
			var value = Convert.ToInt32 (RegisterRepository.Current.Get (Parameters [1]));

			DataSegmentRepository.Current.Set (address,  value);

			Console.WriteLine ("******* SW *******");
			Console.WriteLine (DataSegmentRepository.Current.Get(address));
			Console.WriteLine ("******* SW *******");
		}
	}
}

