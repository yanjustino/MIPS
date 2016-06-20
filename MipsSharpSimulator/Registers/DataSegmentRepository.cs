using System;
using System.Linq;
using System.Collections.Generic;

namespace MipsSharpSimulator
{
	public class DataSegmentWord
	{
		public string Label { get; set; }
		public int Address { get; set; }
		public Dictionary<int, int> Values { get; set; }
		public int LastAddress { get; set; }

		public DataSegmentWord (string label, int address, List<string> values)
		{
			Label = label;
			Address = address;
			Values = new Dictionary<int, int>();

			foreach (var item in values) {
				Values.Add (address, Convert.ToInt32 (item));
				address += 4;
			}

			LastAddress = address;
		}

		public bool Contains(int index){
			return Values.ContainsKey (index);
		}

		public int Get(int index){
			if (Values.ContainsKey (index))
				return Values [index];
			return 0;
		}

		public void Set (int address, int value)
		{
			Values [address] = value;
		}

		public List<int> GetBytes (int size)
		{
			var result = new List<int> ();

			for (int i = 0; i < size; i += 4) {
				result.Add (Get (Address + i));
			}

			return result;
		}

		public void SetByte (int address, List<int> values, int size)
		{
			var total = 0;

			foreach (var item in values) {
				if (total == size) break;
				Set (address + total, Convert.ToInt32 (item));
				total += 4;
			}
		}
	}

	public class DataSegmentRepository
	{
		private int BYTE_ADDRESS = 0;

		private List<DataSegmentWord> _words = new List<DataSegmentWord>();

		private static DataSegmentRepository _current;

		public static DataSegmentRepository Current {
			get {
				_current = _current ?? new DataSegmentRepository ();
				return _current;
			}
		}

		public int? GetAddress (int index)
		{
			return _words.FirstOrDefault (x => x.Contains (index))?.Get (index);
		}

		public List<int> GetBytes (int size, int address)
		{
			return _words.Where (x => x.Contains(address))?
				.FirstOrDefault ()
				.GetBytes (size);
		}

		public int? GetInitialAddress (string label)
		{
			return _words.FirstOrDefault (x => x.Label == label)?.Address;
		}

		public void Set (int address, int value)
		{
			_words.FirstOrDefault (x => x.Contains(address)).Set(address, value);
		}

		public void SetByte (int address, string value, int size)
		{
			var matriz = value.Replace (" ", "").Split (',');	
			var values = new List<int> ();

			foreach (var item in matriz) {
				if (string.IsNullOrEmpty (item))
					continue;
				values.Add (Convert.ToInt32(item));
			}

			_words.FirstOrDefault (x =>  x.Contains(address))
				.SetByte (address, values, size);
		}

		public void Add (string label, string word)
		{
			var matriz = word.Replace (" ", "").Split (',');
			var address = _words.Count == 0 ? BYTE_ADDRESS : _words.Max(x=> x.LastAddress) + 4;

			_words.Add(new DataSegmentWord(label, address, matriz.ToList()));
		}

		public void Print ()
		{
			foreach (var item in _words) {
				Console.WriteLine("{0}", item.Label, item.Address);

				var v = from a in item.Values
				        select new 
						{
							r = a.Value
						};

				Console.WriteLine (string.Join(",", v.Select(x => x.r)));
			}
		}
	}
}

