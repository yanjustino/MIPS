using System;
using System.Linq;

namespace MipsSharpSimulator
{
	public class InstructionFactory
	{
		public static Instruction Create (string label, string line)
		{
			var valor = line.Replace (label + ":", "").Trim ();
			var split = valor.Split (' ');

			switch (split [0].ToLower ()) {
			case "add":
				return new ADD (label, valor);
			case "addi":
				return new ADDi (label, valor);
			case "li":
				return new LI (label, valor);
			case "la":
				return new LA (label, valor);
			case "mul":
				return new MUL (label, valor);
			case "mult":
				return new MULT (label, valor);
			case "sub":
				return new SUB (label, valor);
			case "lw":
				return new LW (label, valor);
			case "sw":
				return new SW (label, valor);
			case "bne":
				return new BNE (label, valor);
			case "beq":
				return new BEQ (label, valor);
			case "snd":
				return new SND (label, valor);
			case "rcv":
				return new RCV (label, valor);
			default:
				return null;
			}
		}
	}
}

