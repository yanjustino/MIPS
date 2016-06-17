using System;

namespace MipsSharpSimulator
{
	public abstract class Instruction
	{
		public string Label { get; private set; }
		public string InstructionLine { get; private set; }
		public string[] Parameters { get; private set; }

		public Instruction (string label, string instruction)
		{
			this.Label = label;
			this.InstructionLine = instruction;
			this.Parameters = InstructionLine.Replace (",", "").Split (' ');
		}

		public abstract void Process ();
	}
}

