using System;

namespace MipsSharpSimulator
{
	public class LA : Instruction
	{
		public LA (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			var dados = DataSegmentRepository.Current.GetInitialAddress (Parameters [2]);

			RegisterRepository.Current.Add (this.Parameters [1], dados.ToString());
		}
	}
}

