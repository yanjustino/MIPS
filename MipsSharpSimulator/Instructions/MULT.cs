using System;

namespace MipsSharpSimulator
{
	public class MULT : Instruction
	{
		public MULT (string label, string line):base(label, line)
		{
		}

		public override void Process ()
		{
			// 0    1    2    3
			//mult $a2, $t2, $s3

			var s2 = RegisterRepository.Current.Get(this.Parameters [2]);
			var s3 = RegisterRepository.Current.Get(this.Parameters [3]);

			var s1 = Convert.ToInt32 (s2) * Convert.ToInt32 (s3);

			var x = DataSegmentRepository.Current.GetAddress (s1);

			RegisterRepository.Current.Add (this.Parameters [1], s1.ToString());

			Resultado = Convert.ToInt32(x);
		}
	}
}

