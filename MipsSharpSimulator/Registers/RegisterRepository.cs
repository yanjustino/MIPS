using System;
using System.Collections.Generic;
using System.Linq;

namespace MipsSharpSimulator
{
	public class RegisterRepository
	{
		private Dictionary<string, string> _registers;

		private static RegisterRepository _current;
		public static RegisterRepository Current
		{
			get
			{
				_current = _current ?? new RegisterRepository ();
				return _current;
			}
		}

		private RegisterRepository ()
		{
			_registers = new Dictionary<string, string> ();
		}

		public void Add(string register, string value)
		{
			_registers [register] = value;
		}

		public string Get(string register)
		{
			return _registers [register];
		}

		public void PrintValue()
		{
			foreach (var item in _registers) {
				Console.WriteLine (item.Key + " : " + item.Value);
			}
		}
	}
}

