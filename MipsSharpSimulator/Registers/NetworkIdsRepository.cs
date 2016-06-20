using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MipsSharpSimulator
{
	public class NetworkAddress
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public int Port { get; set; }

		public override string ToString ()
		{
			return string.Format ("{0}:{1}", Ip, Port);
		}
	}

	public class NetworkIdsRepository
	{
		private Dictionary<int, string> _registers;

		private List<NetworkAddress> _address;

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
			_address = new List<NetworkAddress> ();

			var file = Program.Environment == "MASTER" ? "master.config" : "slave.config";

			var lines = File.ReadAllLines (file);

			foreach (var item in lines) {
				var ip = item.Split (';');

				_address.Add (new NetworkAddress {
					Id = Convert.ToInt32 (ip [0]),
					Ip = ip [1],
					Port = Convert.ToInt32 (ip[2])
				});
			}
		}

		public NetworkAddress Get(int index)
		{
			return _address.Where (x => x.Id == index).FirstOrDefault ();
		}
	}
}

