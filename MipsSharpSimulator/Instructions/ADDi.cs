using System;

namespace MipsSharpSimulator
{
	public class ADDi: Instruction
	{
		public ADDi (string label, string line) : base (label, line)
		{
		}

		public override void Process ()
		{
			var s2 = RegisterRepository.Current.Get (this.Parameters [2]);
			var s3 = this.Parameters [3];
			var s1 = Convert.ToInt32 (s2) + Convert.ToInt32 (s3);
			Resultado = s1;

			RegisterRepository.Current.Add (this.Parameters [1], s1.ToString ());
		}
	}
}

