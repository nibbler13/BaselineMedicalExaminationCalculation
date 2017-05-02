using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineMedicalExaminationCalculation {
	public class BaselineExaminationPlan {
		private List<string[]> hazardItems;
		private List<string[]> serviceItems;
		private int quantityMan;
		private int quantityWoman;
		private int quantityWomanOld;

		public BaselineExaminationPlan() {
			hazardItems = new List<string[]>();
			quantityMan = 0;
			quantityWoman = 0;
			quantityWomanOld = 0;
		}

		public void AddHazard(string[] hazard) {
			foreach (string[] item in hazardItems)
				if (item.SequenceEqual(hazard))
					return;

			hazardItems.Add(hazard);
		}

		public void AddMan(int quantity) {
			quantityMan += quantity;
		}

		public int GetMan() {
			return quantityMan;
		}

		public void AddWoman(int quantity) {
			quantityWoman += quantity;
		}

		public int GetWoman() {
			return quantityWoman;
		}

		public void AddWomanOld(int quantity) {
			quantityWomanOld += quantity;
		}

		public int GetWomanOld() {
			return quantityWomanOld;
		}

		public List<string[]> GetHazardItems() {
			return hazardItems;
		}

		public override string ToString() {
			hazardItems = hazardItems
				.OrderBy(arr => arr[0])
				.ThenBy(arr => arr[1])
				.ToList();

			string result = "";
			foreach (string[] hazard in hazardItems)
				try {
					result += "Прил." + hazard[0] + " п." + hazard[1] + "\t";
				} catch (Exception e) {
					LoggingSystem.LogMessageToFile(e.Message + " " + e.StackTrace);
				}

			if (result.Length > 0)
				result = result.Substring(0, result.Length - 1);

			return result;
		}
	}
}
