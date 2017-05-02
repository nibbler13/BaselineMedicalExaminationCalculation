using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineMedicalExaminationCalculation {
	public class PriceItem {
		public string original { get; set; }
		public string code { get; set; }
		public string name { get; set; }
		public int cost { get; set; }
		public bool isOptional { get; set; }
		public bool isManOnly { get; set; }
		public bool isWomanOnly { get; set; }
		public bool isOldOnly { get; set; }

		public PriceItem() {
			original = "";
			code = "";
			name = "";
			cost = 0;
			isOptional = false;
			isManOnly = false;
			isWomanOnly = false;
			isOldOnly = false;
		}
	}
}
