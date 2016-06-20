using System;
using System.Linq;
using System.Collections.Generic;

namespace MipsSharpSimulator
{
	public class SocketMessageRepository
	{
		private Dictionary<string,string> _recevieds;

		private static SocketMessageRepository _current;
		public static SocketMessageRepository Current
		{
			get
			{
				_current = _current ?? new SocketMessageRepository ();
				return _current;
			}
		}

		public SocketMessageRepository ()
		{
			_recevieds = new Dictionary<string, string> ();
		}

		public void Add(string ip, string value)
		{
			if (!_recevieds.ContainsKey (ip))
				_recevieds.Add (ip, value);
			_recevieds[ip] = value;
		}

		public bool HasValue(string ip)
		{
			return _recevieds.ContainsKey (ip);
		}

		public string Get(string ip)
		{
			if (!_recevieds.ContainsKey (ip))
				return string.Empty;
			return _recevieds [ip];
		}

		public void Remove(string ip)
		{
			_recevieds.Remove (ip);
		}
	}
}

