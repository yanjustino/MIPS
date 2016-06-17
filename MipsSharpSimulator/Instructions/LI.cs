using System;

namespace MipsSharpSimulator
{
	public class LI : Instruction
	{
		public LI (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			RegisterRepository.Current.Add (this.Parameters [1], this.Parameters [2]);
		}
	}
}

