using System;
using System.Linq;
using System.Collections.Generic;

namespace MipsSharpSimulator
{
	public class InstructionRepository
	{
		private List<Instruction> _instructions = new List<Instruction> ();

		public InstructionRepository ()
		{
		}

		private static InstructionRepository _current;
		public static InstructionRepository Current
		{
			get
			{
				_current = _current ?? new InstructionRepository ();
				return _current;
			}
		}

		public void Add(Instruction value)
		{
			_instructions.Add(value);
		}

		public List<Instruction> Get(string name)
		{
			return _instructions.Where(x => x.Label == name).ToList();
		}

		public void PrintValue()
		{
			foreach (var item in _instructions) {
				Console.WriteLine (item);
			}
		}
	}
}

