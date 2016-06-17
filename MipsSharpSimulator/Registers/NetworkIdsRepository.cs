using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MipsSharpSimulator
{
	public class NetworkIdsRepository
	{
		private Dictionary<int, string> _registers;

		private static NetworkIdsRepository _current;
		public static NetworkIdsRepository Current
		{
			get
			{
				_current = _current ?? new NetworkIdsRepository ();
				return _current;
			}
		}

		public NetworkIdsRepository ()
		{
			_registers = new Dictionary<int, string> ();

			var lines = File.ReadAllLines ("config.ini");

			foreach (var item in lines) {
				var addressIp = item.Split ('=');
				_registers.Add (Convert.ToInt32(addressIp[0]), addressIp[1]);
			}
		}

		public string Get(int index)
		{
			return _registers [index];
		}
	}
}

