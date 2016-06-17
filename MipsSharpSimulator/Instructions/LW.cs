using System;

namespace MipsSharpSimulator
{
	public class LW : Instruction
	{
		public LW (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			var index = Convert.ToInt32(this.Parameters [2].Substring (0, 1));
			var regis = this.Parameters [2].Remove (0, 1).Replace ("(", "").Replace (")", "");

			var address = index + Convert.ToInt32(RegisterRepository.Current.Get (regis));
			var value = DataSegmentRepository.Current.Get (address);

			RegisterRepository.Current.Add (Parameters[1], value.ToString());
		}
	}
}

