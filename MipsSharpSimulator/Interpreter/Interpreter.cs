﻿using System;
using System.Collections.Generic;

namespace MipsSharpSimulator
{
	public class Interpreter
	{
		private string lastLabelFounded;
		private string filePath;

		public Interpreter (string file)
		{
			filePath = file;
		}

		public void Start()
		{
			Console.Write ("Interpretador iniciado");

			var lines = System.IO.File.ReadAllLines (filePath);

			foreach (var line in lines) {
				var valueLine = line.Trim ();

				if (string.IsNullOrEmpty (valueLine))
					continue;

				if (InBlackList(valueLine))
					continue;

				if (valueLine.Contains (".word")) {
					processWord (valueLine);
					continue;
				}

				if (valueLine.Contains (":"))
					processLabel (valueLine);

				var inst = InstructionFactory.Create (lastLabelFounded, valueLine);

				if (inst != null) {
					InstructionRepository.Current.Add (inst);
					inst.Process ();
				}
			}			
		}

		private void processLabel(string line)
		{
			lastLabelFounded = line.Split (':')[0].Trim ();
		}

		private void processWord (string line)
		{
			var split = line.Split (':');
			var param = split[1].Replace (".word", "").Trim ();

			DataSegmentRepository.Current.Add (split[0], param);
		}

		private bool InBlackList(string line){
			var blackList = new string[]{ "#", ".text", ".globl", ".data" };

			foreach (var item in blackList) {
				if (line.StartsWith (item))
					return true;
			}

			return false;
		}
	}
}

