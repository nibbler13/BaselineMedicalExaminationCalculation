using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Linq;

namespace BaselineMedicalExaminationCalculation {
	public class FileParser {
		private string filePath;
		private bool patientQuantityAuto;
		private int patientQuantityManual;
		private int dataFirstRow;
		private int columnKeyValue;
		private int columnHazardItems;
		private int columnMan;
		private int columnWoman;
		private int columnWomanOld;
		private bool calculateTypePeriodical;
		private bool calculateTypePreliminary;

		private Dictionary<string, List<string[]>> plans;
		private Dictionary<string, BaselineExaminationPlan> uniquePlans;
		private Dictionary<string, List<string[]>> order302part1;
		private Dictionary<string, List<string[]>> order302part2;
		private Dictionary<string, List<string[]>> necesserilyServices;
		private Dictionary<string, List<string[]>> price;
		private Dictionary<string, List<string[]>> serviceMatching;

		private System.Windows.Forms.TextBox textBox;
		private ProgressBar progressBar;

		private const string errorTemplate = "===== ВНИМАНИЕ! ОШИБКА! =====";

		public FileParser(string filePath, bool patientQuantityAuto,
			string patientQuantityManual, string rowFirstLine, string columnKeyValue, string columnHazardItems,
			string columnMan, string columnWoman, string columnWomanOld, bool calculateTypePeriodical,
			bool calculateTypePreliminary) {
			this.filePath = filePath;
			this.patientQuantityAuto = patientQuantityAuto;
			this.patientQuantityManual = GetIntFromString(patientQuantityManual);
			this.dataFirstRow = GetIntFromString(rowFirstLine) - 1;
			this.columnKeyValue = GetIntFromString(columnKeyValue) - 1;
			this.columnHazardItems = GetIntFromString(columnHazardItems) - 1;
			this.columnMan = GetIntFromString(columnMan) - 1;
			this.columnWoman = GetIntFromString(columnWoman) - 1;
			this.columnWomanOld = GetIntFromString(columnWomanOld) - 1;
			this.calculateTypePeriodical = calculateTypePeriodical;
			this.calculateTypePreliminary = calculateTypePreliminary;
			textBox = null;
			progressBar = null;
		}

		private int GetIntFromString(string number) {
			int result = 0;
			int.TryParse(number, out result);
			return result;
		}

		public void CalculateCostOfExaminations(System.Windows.Forms.TextBox textBox, ProgressBar progressBar) {
			this.textBox = textBox;
			this.progressBar = progressBar;

			UpdateTextBox("Выбранный файл: " + filePath);
			UpdateProgressBar(0);
			UpdateTextBox("Чтение и анализ содержимого файла");
			
			plans = ReadBlocksByKeyValue(filePath, dataFirstRow, columnKeyValue, 
				new int[] { columnHazardItems, columnMan, columnWoman, columnWomanOld });
			if (plans.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Не удалось прочитать выбранный файл");
				return;
			}

			UpdateProgressBar(10);

			int patientQuantityCalculated = 0;
			uniquePlans = ParseBaselineExaminationBlocks(plans, out patientQuantityCalculated);
			if (uniquePlans.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine + "Не удалось получить список вредностей");
				return;
			}

			UpdateProgressBar(20);
			UpdateTextBox("Обнаружены следующие уникальные планы:", true);

			List<string> keys = new List<string>(uniquePlans.Keys);
			keys.Sort();
			foreach (string plan in keys)
				UpdateTextBox(plan);

			UpdateTextBox("Всего пациентов: " + patientQuantityCalculated, true);
			UpdateTextBox("Загрузка справочников:", true);

			string resourcesPath = Directory.GetCurrentDirectory() + "\\Resources\\";

			UpdateTextBox("Приказ 302, приложение 1");
			order302part1 = ReadBlocksByKeyValue(resourcesPath + "302part1_new.csv", 1, 0, new int[] { 1, 2 }, true);
			if (order302part1.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Приложение 1 не содержит данных");
				return;
			}

			UpdateProgressBar(30);
			UpdateTextBox("Приказ 302, приложение 2");
			order302part2 = ReadBlocksByKeyValue(resourcesPath + "302part2_new.csv", 1, 0, new int[] { 1, 2 }, true);
			if (order302part2.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Приложение 2 не содержит данных");
				return;
			}

			UpdateProgressBar(40);
			UpdateTextBox("Список обязательных услуг");
			necesserilyServices = ReadBlocksByKeyValue(resourcesPath + "necesserily.csv", 0, 0, new int[] { 1 });

			UpdateProgressBar(50);
			UpdateTextBox("Прайс");
			price = ReadBlocksByKeyValue(resourcesPath + "price_new.csv", 1, 0, new int[] { 1, 2 });
			if (price.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Прайс не содержит данных");
				return;
			}

			UpdateProgressBar(60);
			UpdateTextBox("Соответствие услуг из 302 приказа услугам из инфоклиники");
			serviceMatching = ReadBlocksByKeyValue(resourcesPath + "service_matching_new.csv", 1, 0, new int[] { 1, 2 });
			if (serviceMatching.Count == 0) {
				UpdateProgressBar(0);
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Соответствие услуг не содержит данных");
				return;
			}

			UpdateProgressBar(70);
			UpdateTextBox("Сопоставление услуг для наборов вредностей", true);
			Dictionary<string, List<PriceItem>> uniquePlansWithPriceItems = 
				AnalyzeBaselineExaminationPLans(patientQuantityCalculated);

			UpdateProgressBar(90);
			UpdateTextBox("Формирование итоговой таблицы Excel", true);
			
			bool excelGenerated = GenerateExcelTable(uniquePlansWithPriceItems);

			if (excelGenerated) {
				UpdateProgressBar(100);
				UpdateTextBox("Завершено успешно", true);
			} else {
				UpdateProgressBar(0);
				UpdateTextBox("Не удалось создать Excel файл");
			}
		}

		private bool GenerateExcelTable(Dictionary<string, List<PriceItem>> plans) {
			try {
				Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

				if (xlApp == null) {
					UpdateTextBox("Не удалось запустить MS Excel");
					return false;
				}

				xlApp.Visible = true;
			
				Workbook wb = xlApp.Workbooks.Add();
				Worksheet ws = (Worksheet)wb.ActiveSheet;

				if (ws == null) {
					UpdateTextBox("Не удалось создать Excel книгу");
					return false;
				}

				List<string> keys = plans.Keys.ToList();
				keys.Sort();

				foreach(string key in keys) {
					ws.Range["A1"].Value = key;
					ws.Range["D1"].Value = CalculatePlanCost(0, plans[key]);
					ws.Range["E1"].Value = CalculatePlanCost(1, plans[key]);
					ws.Range["F1"].Value = CalculatePlanCost(2, plans[key]);
					ws.Range["A2"].Value = "Название мероприятий";
					ws.Range["B2"].Value = "Код услуги";
					ws.Range["C2"].Value = "Название услуги";
					ws.Range["D2"].Value = "Мужчины";
					ws.Range["E2"].Value = "Женщины до 40 лет";
					ws.Range["F2"].Value = "Женщины после 40 лет";
					ws.Range["A1:F2"].Font.Bold = true;

					List<PriceItem> sortedPriceItemsMain = plans[key].OrderBy(p1 => p1.name).Where(p1 => !p1.isOptional).ToList();
					List<PriceItem> sortedPriceItemsOptional = plans[key].OrderBy(p1 => p1.name).Where(p1 => p1.isOptional).ToList();

					int row = 3;
					FillRangeWithItems(ws, sortedPriceItemsMain, ref row);

					row += 2;
					ws.Range["A" + row].Value = "Опциональные услуги";
					ws.Range["A" + row].Font.Bold = true;
					row++;

					FillRangeWithItems(ws, sortedPriceItemsOptional, ref row);

					ws.Columns[1].ColumnWidth = 40;
					ws.Columns[2].ColumnWidth = 10;
					ws.Columns[3].ColumnWidth = 90;
					ws.Columns[4].ColumnWidth = 10;
					ws.Columns[5].ColumnWidth = 20;
					ws.Columns[6].ColumnWidth = 20;

					wb.Worksheets.Add(After: ws);
					ws = (Worksheet)wb.ActiveSheet;
				}

				ws.Range["A1"].Value = "Состав плана";
				ws.Range["A1:A2"].Merge();
				ws.Range["B1"].Value = "Мужчины";
				ws.Range["B1:D1"].Merge();
				ws.Range["E1"].Value = "Женщины до 40 лет";
				ws.Range["E1:G1"].Merge();
				ws.Range["H1"].Value = "Женщины после 40 лет";
				ws.Range["H1:J1"].Merge();
				ws.Range["K1"].Value = "Расположение";
				ws.Range["K1:K2"].Merge();
				ws.Range["B2"].Value = "Цена";
				ws.Range["C2"].Value = "Кол-во";
				ws.Range["D2"].Value = "Итого";
				ws.Range["E2"].Value = "Цена";
				ws.Range["F2"].Value = "Кол-во";
				ws.Range["G2"].Value = "Итого";
				ws.Range["H2"].Value = "Цена";
				ws.Range["I2"].Value = "Кол-во";
				ws.Range["J2"].Value = "Итого";
				ws.Range["A1:K2"].Font.Bold = true;

				ws.Columns[1].ColumnWidth = 130;
				for (int i = 2; i < 11; i++) {
					ws.Columns[i].ColumnWidth = 7;
				}
				ws.Columns[11].ColumnWidth = 14;

				int line = 3;
				foreach (string key in keys) {
					ws.Range["A" + line].Value = key;

					int costMan = CalculatePlanCost(0, plans[key]);
					int quantityMan = uniquePlans[key].GetMan();
					int costManTotal = costMan * quantityMan;
					ws.Range["B" + line].Value = costMan;
					ws.Range["C" + line].Value = quantityMan;
					ws.Range["D" + line].Value = costManTotal;

					int costWoman = CalculatePlanCost(1, plans[key]);
					int quantityWoman = uniquePlans[key].GetWoman();
					int costWomanTotal = costWoman * quantityWoman;
					ws.Range["E" + line].Value = costWoman;
					ws.Range["F" + line].Value = quantityWoman;
					ws.Range["G" + line].Value = costWomanTotal;

					int costOld = CalculatePlanCost(2, plans[key]);
					int quantityOld = uniquePlans[key].GetWomanOld();
					int costOldTotal = costOld * quantityOld;
					ws.Range["H" + line].Value = costOld;
					ws.Range["I" + line].Value = quantityOld;
					ws.Range["J" + line].Value = costOldTotal;

					ws.Range["K" + line].Value = "Лист " + (line - 2);
					line++;
				}


				string pathToSave = Directory.GetCurrentDirectory() + "\\" + 
					"Расчет стоимости - " + Path.GetFileName(filePath) + " " + 
					DateTime.Now.ToLocalTime().ToString().Replace(":", ".") + ".xlsx";
				Console.WriteLine("---- " + pathToSave);
				wb.SaveAs(pathToSave);

				UpdateTextBox("Результат расчета сохранен в файл: " + pathToSave);

				return true;
			} catch (Exception e) {
				UpdateTextBox(errorTemplate + Environment.NewLine +
					"Возникла ошибка: " + e.Message + " " + e.StackTrace);
			}

			return false;
		}

		// type 0 - man, 1 - woman, 2 - old
		private int CalculatePlanCost(int type, List<PriceItem> items) {
			int cost = 0;

			foreach(PriceItem item in items) {
				if (item.isOptional)
					continue;

				if (type == 0)
					if (item.isWomanOnly || item.isOldOnly)
						continue;

				if (type == 1)
					if (item.isManOnly || item.isOldOnly)
						continue;

				if (type == 2)
					if (item.isManOnly)
						continue;

				cost += item.cost;
			}

			return cost;
		}

		private void FillRangeWithItems(Worksheet ws, List<PriceItem> items, ref int row) {
			foreach (PriceItem priceItem in items) {
				ws.Range["A" + row].Value = priceItem.original;
				ws.Range["B" + row].Value = "'" + priceItem.code;
				ws.Range["C" + row].Value = priceItem.name;

				string costMan = "---";
				string costWoman = "---";
				string costOld = "---";

				if (!priceItem.isWomanOnly && !priceItem.isOldOnly)
					costMan = priceItem.cost.ToString();

				if (!priceItem.isManOnly && !priceItem.isOldOnly)
					costWoman = priceItem.cost.ToString();

				if (!priceItem.isManOnly)
					costOld = priceItem.cost.ToString();

				ws.Range["D" + row].Value = costMan;
				ws.Range["E" + row].Value = costWoman;
				ws.Range["F" + row].Value = costOld;

				row++;
			}
		}

		private Dictionary<string, List<PriceItem>> AnalyzeBaselineExaminationPLans(int patientQuantityCalculated) {
			Dictionary<string, List<PriceItem>> uniquePlansWithPriceItems = new Dictionary<string, List<PriceItem>>();

			foreach (KeyValuePair<string, BaselineExaminationPlan> plan in uniquePlans) {
				List<String[]> hazardItems = plan.Value.GetHazardItems();
				UpdateTextBox("Анализ группы вредностей: " + plan.Key);

				List<string> uniqueServices = GetUniqueServicesForHazardItems(hazardItems);
				if (uniqueServices.Count == 0) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось обнаружить список услуг для данного набора");
					continue;
				}

				AddNecesserilyServices(ref uniqueServices);

				Dictionary<string, string> uniqueServiceCodes = MakeServiceToCodesMatching(uniqueServices);
				if (uniqueServiceCodes.Count == 0) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось обнаружить список кодов для данного набора");
					continue;
				}

				//тельца Гейнца	851005	
				//При наличии этой услуги надо убрать общий анализ крови из обязательных услуг и заменить на этот код
				//эритроциты с базофильной зернистостью   851004
				//При наличии этой услуги надо убрать общий анализ крови из обязательных услуг и заменить на этот код
				//общий анализ крови 851000
				if (uniqueServiceCodes.Keys.Contains("851005") || 
					uniqueServiceCodes.Keys.Contains("851004"))
					if (uniqueServiceCodes.Keys.Contains("851000")) {
						UpdateTextBox("Удаление услуги общий анализ крови, присутствует услуга 'тельца Гейнца' " +
							"или 'эритроциты с базофильной зернистостью'");
						uniqueServiceCodes.Remove("851000");
					}

				int patientsQuantity;
				if (patientQuantityAuto) {
					patientsQuantity = patientQuantityCalculated;
				} else {
					patientsQuantity = patientQuantityManual;
				}

				int priceLevel;
				if (patientsQuantity > 0 && patientsQuantity <= 50) {
					priceLevel = 1;
				} else if (patientsQuantity > 50 && patientsQuantity <= 100) {
					priceLevel = 2;
				} else if (patientsQuantity > 100 && patientsQuantity <= 300) {
					priceLevel = 3;
				} else if (patientsQuantity > 300 && patientsQuantity < 500) {
					priceLevel = 4;
				} else {
					priceLevel = 5;
				}

				List<PriceItem> priceItems = MakeCodesToPriceMatching(uniqueServiceCodes, priceLevel);
				if (priceItems.Count == 0) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось обнаружить услуг из прайса для данного набора");
					continue;
				}

				uniquePlansWithPriceItems.Add(plan.Key, priceItems);
			}

			return uniquePlansWithPriceItems;
		}

		private List<PriceItem> MakeCodesToPriceMatching(Dictionary<string, string> codes, int priceLevel) {
			List<PriceItem> priceItems = new List<PriceItem>();

			foreach(KeyValuePair<string, string> code in codes) {
				PriceItem priceItem = new PriceItem();
				string keyToSearch = code.Key;

				if (keyToSearch.Contains("o")) {
					priceItem.isOptional = true;
					keyToSearch = keyToSearch.Replace("o", "");
				}

				if (keyToSearch.Contains("m")) {
					priceItem.isManOnly = true;
					keyToSearch = keyToSearch.Replace("m", "");
				}

				if (keyToSearch.Contains("w")) {
					priceItem.isWomanOnly = true;
					keyToSearch = keyToSearch.Replace("w", "");
				}

				if (keyToSearch.Contains("a")) {
					priceItem.isOldOnly = true;
					keyToSearch = keyToSearch.Replace("a", "");
				}

				if (keyToSearch.StartsWith("8"))
					keyToSearch += "." + priceLevel;

				if (!price.ContainsKey(keyToSearch)) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось найти услугу в прайсе для кода: " + keyToSearch);
					continue;
				}

				priceItem.code = keyToSearch;
				priceItem.original = code.Value;
				try {
					string[] priceLine = price[keyToSearch][0];
					priceItem.name = priceLine[0];
					priceItem.cost = GetIntFromString(priceLine[1]);
				} catch (Exception) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось разобрать строку прайса для кода: " + keyToSearch);
					continue;
				}

				priceItems.Add(priceItem);
			}

			return priceItems;
		}

		private Dictionary<string, string> MakeServiceToCodesMatching(List<string> services) {
			Dictionary<string, string> serviceCodes = new Dictionary<string, string>();

			foreach(string service in services) {
				bool isOptional = false;

				string keyToSearch = service;
				if (service.Contains("!")) {
					isOptional = true;
					keyToSearch = service.Replace("!", "");
				}

				if (!serviceMatching.ContainsKey(keyToSearch)) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Не удалось найти в списке сопоставления услугу: " + keyToSearch);
					continue;
				}

				List<string[]> serviceCode = serviceMatching[keyToSearch];

				foreach(string[] line in serviceCode) {
					string code = "";
					string comment = "";

					try {
						code = line[0];
						comment = line[1];
					} catch (Exception) {
						UpdateTextBox(errorTemplate + Environment.NewLine +
							"Не удалось разобрать строку: " + string.Join(".", line));
						continue;
					}

					if (string.IsNullOrEmpty(code)) {
						UpdateTextBox("Не задан список кодов для услуги: " + 
							service + " (" + comment + ")");
						continue;
					}

					//skipping if present main service
					if (serviceCodes.Keys.Contains(code))
						continue;

					code = isOptional ? "o" + code : code;

					//skipping if present optional service
					if (serviceCodes.Keys.Contains(code))
						continue;

					serviceCodes.Add(code, keyToSearch);
				}
			}

			return serviceCodes;
		}

		private void AddNecesserilyServices(ref List<string> services) {
			foreach(KeyValuePair<string, List<string[]>> necesserilyService in necesserilyServices) {
				if (services.Contains(necesserilyService.Key))
					continue;

				services.Add(necesserilyService.Key);
			}
		}

		private List<string> GetUniqueServicesForHazardItems(List<string[]> hazardItems) {
			List<string> uniqueServices = new List<string>();

			foreach (string[] hazard in hazardItems) {
				if (hazard.Length != 2) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Строка вредности не соответсвует нужной длине: " + string.Join(".", hazard));
					continue;
				}

				string order302PartNumber = hazard[0];
				Dictionary<string, List<string[]>> order302PartToSearch;

				if (order302PartNumber.Equals("1")) {
					order302PartToSearch = order302part1;
				} else if (order302PartNumber.Equals("2")) {
					order302PartToSearch = order302part2;
				} else {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Неверный номер пункта 302 приказа в строке: " + string.Join(",", hazard));
					continue;
				}

				string order302ParagraphNumber = hazard[1];
				if (!order302PartToSearch.ContainsKey(order302ParagraphNumber)) {
					UpdateTextBox(errorTemplate + Environment.NewLine +
						"Приложение " + order302PartNumber + " не содержит пункт " + order302ParagraphNumber);
					continue;
				}

				List<string[]> services = order302PartToSearch[order302ParagraphNumber];

				foreach (string[] line in services) {
					foreach (string service in line) {
						if (string.IsNullOrEmpty(service))
							continue;

						if (uniqueServices.Contains(service))
							continue;

						uniqueServices.Add(service);
					}
				}
			}

			return uniqueServices;
		}

		private Dictionary<string, BaselineExaminationPlan> ParseBaselineExaminationBlocks(
			Dictionary<string, List<string[]>> planBlocks, out int patientQuantityCalculated) {
			Dictionary<string, BaselineExaminationPlan> plans = new Dictionary<string, BaselineExaminationPlan>();
			patientQuantityCalculated = 0;

			foreach (KeyValuePair<string, List<string[]>> block in planBlocks) {
				BaselineExaminationPlan plan = new BaselineExaminationPlan();
				foreach(string[] line in block.Value) {
					string hazardItem = "";
					string manQuantity = "";
					string womanQuantity = "";
					string womanOldQuantity = "";

					try {
						hazardItem = line[0];
						manQuantity = line[1];
						womanQuantity = line[2];
						womanOldQuantity = line[3];
					} catch (Exception e) {
						UpdateTextBox(errorTemplate + Environment.NewLine +
							"Не удалось разобрать строку: " + string.Join(".", line) + Environment.NewLine +
							e.Message + " " + e.StackTrace);
					}

					if (!string.IsNullOrEmpty(hazardItem)) {
						try {
							string[] parsedHazard = ParseHazardString(hazardItem);
							plan.AddHazard(parsedHazard);
						} catch (Exception e) {
							UpdateTextBox(errorTemplate + Environment.NewLine +
								"Не удалось определить вредность для строки: " + hazardItem + Environment.NewLine +
								e.Message + " " + e.StackTrace);
						}
					}

					plan.AddMan(GetIntFromString(manQuantity));
					plan.AddWoman(GetIntFromString(womanQuantity));
					plan.AddWomanOld(GetIntFromString(womanOldQuantity));
				}
				
				string key = plan.ToString();
				if (string.IsNullOrEmpty(key))
					continue;

				int totalManQuantity = plan.GetMan();
				int totalWomanQuantity = plan.GetWoman();
				int totalWomanOldQuantity = plan.GetWomanOld();

				if (plans.ContainsKey(key)) {
					plans[key].AddMan(totalManQuantity);
					plans[key].AddWoman(totalWomanQuantity);
					plans[key].AddWomanOld(totalWomanOldQuantity);
				} else {
					plans.Add(key, plan);
				}

				if (patientQuantityAuto) {
					if (columnMan >= 0 &&
						columnWoman >= 0 &&
						columnWomanOld >= 0) {
						patientQuantityCalculated += totalManQuantity + totalWomanQuantity + totalWomanOldQuantity;
					} else {
						patientQuantityCalculated++;
					}
				}
			}

			return plans;
		}

		private Dictionary<string, List<string[]>> ReadBlocksByKeyValue(
			string path, int rowToStart, int keyColumn, int[] columnsToRead, bool isKeyValuesOnlyDigit = false) {
			Dictionary<string, List<string[]>> blocks = new Dictionary<string, List<string[]>>();

			List<string[]> fileContent = GetCsvFileContent(path);

			int fileRowsQuantity = fileContent.Count;
			if (fileRowsQuantity == 0) {
				UpdateTextBox(errorTemplate + Environment.NewLine + path + 
					Environment.NewLine + "Файл не существует или не содержит данных");
				return blocks;
			}
			
			int fileRowLength = fileContent[0].Length;
			string checkResult = CheckParameters(fileRowsQuantity, fileRowLength, rowToStart, keyColumn, columnsToRead);
			if (!string.IsNullOrEmpty(checkResult)) {
				UpdateTextBox(errorTemplate + Environment.NewLine + checkResult);
				return blocks;
			}

			Random random = new Random();
			
			for (int externalRow = rowToStart; externalRow < fileRowsQuantity; externalRow++) {
				List<string[]> currentBlock = new List<string[]>();
				string keyValue = "";

				for (int innerRow = externalRow; innerRow < fileContent.Count; innerRow++) {
					string[] currentLine = fileContent[innerRow];
					if (currentLine.Length == 0)
						continue;

					string keyValueInner = "";
					try {
						keyValueInner = currentLine[keyColumn].ToLower();
					} catch (Exception e) {
						UpdateTextBox(errorTemplate + Environment.NewLine +
							"Не удается разобрать строку " + (innerRow + 1) + ": " +
							string.Join(".", currentLine) + Environment.NewLine +
							e.Message + " " + e.StackTrace);
						continue;
					}

					if (innerRow == externalRow) {
						keyValue = keyValueInner;
					} else {
						//найден следующий блок
						if (!string.IsNullOrEmpty(keyValueInner)) {
							externalRow = innerRow - 1;
							break;
						}
					}
					
					string[] readedColumns = new string[columnsToRead.Length];
					try {
						for (int i = 0; i < columnsToRead.Length; i++) {
							int column = columnsToRead[i];
							if (column >= 0)
								readedColumns[i] = currentLine[columnsToRead[i]].ToLower();
						}
					} catch (Exception e) {
						UpdateTextBox(errorTemplate + Environment.NewLine +
							"Не удается разобрать строку " + (innerRow + 1) + ": " +
							string.Join(".", currentLine) + Environment.NewLine +
							e.Message + " " + e.StackTrace);
						continue;
					}

					currentBlock.Add(readedColumns);

					//last row in file
					if (innerRow == fileContent.Count - 1)
						externalRow = innerRow;
				}

				if (!string.IsNullOrEmpty(keyValue) && currentBlock.Count != 0) {
					if (isKeyValuesOnlyDigit) {
						List<string> key = ParseStringToDigitsOnly(keyValue);
						if (key.Count > 0)
							keyValue = key[0].ToLower();
					}

					string newKeyValue = keyValue;

					while (blocks.ContainsKey(newKeyValue))
						newKeyValue = keyValue + random.Next();

					blocks.Add(newKeyValue.ToLower(), currentBlock);
				}
			}

			return blocks;
		}

		//used in FormMain.cs
		public static bool IsFileExistAndNotEmpty(string filePath) {
			if (File.Exists(filePath)) {
				FileInfo info = new FileInfo(filePath);
				if (info.Length != 0) return true;
			}

			return false;
		}

		//used in FormMain.cs
		public static List<string[]> GetCsvFileContent(string filePath) {
			List<string[]> returnValue = new List<string[]>();

			if (!IsFileExistAndNotEmpty(filePath)) return returnValue;

			try {
				using (TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding("windows-1251"))) {
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(";");
					while (!parser.EndOfData) {
						string[] fields = parser.ReadFields();
						returnValue.Add(fields);
					}
				}
			} catch (Exception e) {
				LoggingSystem.LogMessageToFile(e.Message + " @ " + e.StackTrace);
			}

			return returnValue;
		}

		//throw exceptions
		private string[] ParseHazardString(string value) {
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("Указана пустая строка", new Exception());

			List<string> parsedDigits = ParseStringToDigitsOnly(value);

			if (parsedDigits.Count != 2)
				throw new ArgumentOutOfRangeException("Строка не содержит 2 числа", new Exception());
					
			string[] hazard = new string[2];

			try {
				for (int i = 0; i < 2; i++) {
					string current = parsedDigits[i];
					while (current.Contains(".."))
						current = current.Replace("..", ".");
					if (current.Substring(current.Length - 1, 1).Equals(".")) 
						current = current.Substring(0, current.Length - 1);

					parsedDigits[i] = current;
				}
			} catch (Exception e) {
				LoggingSystem.LogMessageToFile(e.Message + " " + e.StackTrace);
			}

			int hazard0 = GetIntFromString(parsedDigits[0]);
			int hazard1 = GetIntFromString(parsedDigits[1]);
			if ((hazard0 == 0 || hazard0 > 2) &&
				(hazard1 == 0 || hazard1 > 2))
				throw new ArgumentException("Номер приложения не соответствует приказу 302", new Exception());

			bool isFirstNumberIsAttachment = false;

			if (parsedDigits[1].Contains(".")) {
				isFirstNumberIsAttachment = true;
			} else {
				if (hazard0 == 2)
					isFirstNumberIsAttachment = true;
			}

			if (isFirstNumberIsAttachment) {
				hazard[0] = parsedDigits[0];
				hazard[1] = parsedDigits[1];
			} else {
				hazard[0] = parsedDigits[1];
				hazard[1] = parsedDigits[0];
			}

			//UpdateTextBox("\t\t" + value + " - " + hazard[0] + " - " + hazard[1]);

			return hazard;
		}

		private List<string> ParseStringToDigitsOnly(string value) {
			List<string> parsedDigits = new List<string>();

			string tmp = "";
			for (int i = 0; i < value.Length; i++) {
				int number = 0;
				bool needToAdd = false;
				if (int.TryParse(value[i].ToString(), out number) || value[i] == '.') {
					if (string.IsNullOrEmpty(tmp) && value[i] == '.')
						continue;

					tmp += value[i];
				} else {
					if (string.IsNullOrEmpty(tmp))
						continue;

					needToAdd = true;
				}

				if (needToAdd || i == value.Length - 1 && !string.IsNullOrEmpty(tmp)) {
					while (tmp.EndsWith("."))
						tmp = tmp.Remove(tmp.Length - 1, 1);

					parsedDigits.Add(tmp);
					tmp = "";
				}
			}

			return parsedDigits;
		}

		private string CheckParameters(
			int rowsQuantity, int columnQuantity, int rowToStart, int keyColumn, int[] columnsToRead) {
			string result = "";
			rowsQuantity--;
			columnQuantity--;

			if (rowToStart > rowsQuantity)
				result += "Указанный номер первой строки выходит за границы таблицы" + Environment.NewLine;

			if (keyColumn > columnQuantity)
				result += "Указанная колонка с ключевым значением выходит за границы таблицы" + Environment.NewLine;

			foreach (int column in columnsToRead)
				if (column > columnQuantity)
					result += "Указанная колонка со значением выходит за границы таблицы" + Environment.NewLine;
			
			return result;
		}

		private void UpdateTextBox(string message, bool newSection = false) {
			if (textBox == null) return;
			textBox.BeginInvoke((MethodInvoker)delegate {
				if (newSection)
					textBox.AppendText("-------------------------------" + Environment.NewLine);

				textBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + ": " + message + Environment.NewLine);
			});

			LoggingSystem.LogMessageToFile(message);
		}

		private void UpdateProgressBar(int percentage) {
			if (progressBar == null) return;
			progressBar.BeginInvoke((MethodInvoker)delegate {
				progressBar.Value = percentage;
			});
		}
	}
}
