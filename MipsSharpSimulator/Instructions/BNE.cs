using System;
using System.Collections.Generic;

namespace MipsSharpSimulator
{

	public class BNE : Instruction
	{
		public BNE (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			var s1 = RegisterRepository.Current.Get (Parameters [1]);
			var s2 = RegisterRepository.Current.Get (Parameters [2]);

			if (s1 != s2){
				var instructions = InstructionRepository.Current.Get (Parameters [3]);
				Process (instructions);
			}
		}

		private void Process(List<Instruction> instructions)
		{
			foreach (var item in instructions) {
				item.Process ();
			}
		}
	}
}

