using System;
using System.Linq;
using System.Collections.Generic;

namespace MipsSharpSimulator
{
	public class DataSegmentRepository
	{
		private int ADDRESS_BASE = 268500992;

		private Dictionary<int, int> _data = new Dictionary<int, int> ();
		private Dictionary<string, int> _labels = new Dictionary<string, int> ();

		private static DataSegmentRepository _current;

		public static DataSegmentRepository Current {
			get {
				_current = _current ?? new DataSegmentRepository ();
				return _current;
			}
		}

		public DataSegmentRepository ()
		{
		}

		public int? Get (int index)
		{
			if (_data.ContainsKey (index))
				return _data [index];
			return null;
		}

		public string GetBytes (int size, int address)
		{
			var result = new List<string> ();
			var index = address;

			for (int i = 0; i < size; i += 4) {
				result.Add (Get (index + i).ToString ());
			}

			return string.Join<string> (",", result);
		}

		public int Get (string label)
		{
			return _labels [label];
		}

		public void Set (int address, int value)
		{
			_data [address] = value;
		}

		public void SetByte (int address, string value, int size)
		{
			var matriz = value.Replace (" ", "").Split (',');	
			var total = 0;

			foreach (var item in matriz) {
				if (total == size)
					break;
				Set (address + total, Convert.ToInt32 (item));
				total += 4;
			}
		}

		public void Add (string label, string word)
		{
			var matriz = word.Replace (" ", "").Split (',');

			var address = _data.Count == 0 ? ADDRESS_BASE : _data.Last ().Key + 4;
			var addressLabel = address;
			var data = new List<int> ();


			foreach (var m in matriz) {
				_data [address] = Convert.ToInt32 (m);
				address += 4;
			}

			_labels.Add (label, addressLabel);
		}

		public void Print ()
		{
			foreach (var item in _labels) {
				Console.WriteLine (item.Key + ": " + item.Value);

				for (int i = item.Value; i < item.Value + 144; i += 4) {
					Console.Write (Get (i) + ",");					
				}
			}
		}
	}
}

