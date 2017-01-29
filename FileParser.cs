using System;
using System.IO;
using System.Collections.Generic;

namespace BaselineMedicalExaminationCalculation {
	class FileParser {
		public static bool IsFileExistAndNotEmpty(string filePath) {
			if (File.Exists(filePath)) {
				FileInfo info = new FileInfo(filePath);
				if (info.Length != 0) return true;
			}
			return false;
		}

		public static List<String[]> GetFileContent(string filePath) {
			List<String[]> returnValue = new List<string[]>();

			if (!IsFileExistAndNotEmpty(filePath)) return returnValue;

			try {
				using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.GetEncoding("windows-1251"))) {
					while (!reader.EndOfStream) {
						string[] line = reader.ReadLine().Split(';', (char)StringSplitOptions.RemoveEmptyEntries);
						if (line.Length > 0)
							returnValue.Add(line);
					}
				}
			} catch (Exception e) {
				Console.WriteLine(e.Message + " @ " + e.StackTrace);
				return new List<string[]>();
			}
			

			return returnValue;
		}
	}
}
