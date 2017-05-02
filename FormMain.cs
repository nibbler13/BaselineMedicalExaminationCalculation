using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace BaselineMedicalExaminationCalculation {
    public partial class FormMain : Form {

		public FormMain() {
            InitializeComponent();

			dataGridViewFileContent.DragDrop += Control_DragDrop;
			textBoxFilePath.DragDrop += Control_DragDrop;
        }

		private void Control_DragDrop(object sender, DragEventArgs e) {
			Console.WriteLine(e.Data.GetData(DataFormats.FileDrop));
		}

		private void ButtonSelectFile_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
			dialog.Multiselect = false;
            dialog.Filter = "CSV (разделители - запятые) (*.csv)|*.csv";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK) {
				if (FileParser.IsFileExistAndNotEmpty(dialog.FileName)) {
					textBoxFilePath.Text = dialog.FileName;
					SetControlsState();
				} else {
					MessageBox.Show(
						"Выбранный файл не существует или имеет нулевой размер", 
						dialog.FileName, 
						MessageBoxButtons.OK, 
						MessageBoxIcon.Error);
				}
			}
        }

		private void ButtonInfo_Click(object sender, EventArgs e) {
			MessageBox.Show("Help", "123", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void SetControlsState() {
			foreach (Control control in this.Controls) {
				if (control.GetType() == typeof(GroupBox))
					foreach (Control innerControl in control.Controls) {
						innerControl.Enabled = true;
						if (innerControl is TextBox &&
							innerControl.Name != textBoxFilePath.Name) {
							innerControl.Text = "";
							innerControl.TextChanged += InnerControl_TextChanged;
							innerControl.KeyPress += InnerControl_KeyPress;
						} else if (innerControl is CheckBox) {
							(innerControl as CheckBox).CheckedChanged += InnerControl_CheckedChanged;
						} else if (innerControl is RadioButton) {
							(innerControl as RadioButton).CheckedChanged += InnerControl_CheckedChanged;
						}
					}
			}

			radioButtonPatientQuantityAuto.Checked = true;
			textBoxPatientQuantity.Enabled = false;
			checkBoxCalculateTypePeriodical.Checked = true;
			checkBoxCalculateTypePreliminary.Checked = false;

			checkBoxCalculateTypePeriodical.Enabled = false;
			checkBoxCalculateTypePreliminary.Enabled = false;

			Thread thread = new Thread(UpdateListView);
			thread.Start();
		}

		private void InnerControl_CheckedChanged(object sender, EventArgs e) {
			UpdateCalculateButtonState();
		}

		private void InnerControl_KeyPress(object sender, KeyPressEventArgs e) {
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void InnerControl_TextChanged(object sender, EventArgs e) {
			UpdateCalculateButtonState();
		}

		private void UpdateCalculateButtonState() {
			bool IsSectionPatientsQuantityCorrect =
				radioButtonPatientQuantityManual.Checked ?
				!string.IsNullOrEmpty(textBoxPatientQuantity.Text) :
				true;
			if (!IsSectionPatientsQuantityCorrect)
				labelHint.Text = "Укажите количество пациентов для расчета";

			bool IsSectionKeyValuesCorrect =
				!string.IsNullOrEmpty(textBoxRowFirstLine.Text) &&
				!string.IsNullOrEmpty(textBoxColumnKeyValue.Text) &&
				!string.IsNullOrEmpty(textBoxColumnHazardItems.Text);
			if (!IsSectionKeyValuesCorrect)
				labelHint.Text = "Укажите расположение ключевых значений в исходных данных";

			bool IsSectionCalculationOptionCorrect = 
				checkBoxCalculateTypePeriodical.Checked ||
				checkBoxCalculateTypePreliminary.Checked;
			if (!IsSectionCalculationOptionCorrect)
				labelHint.Text = "Выберите вариант расчета стоимости";

			buttonCalculate.Enabled =
				IsSectionPatientsQuantityCorrect &&
				IsSectionKeyValuesCorrect &&
				IsSectionCalculationOptionCorrect;
			labelHint.Visible = !buttonCalculate.Enabled;
		}

		private void UpdateListView() {
			List<String[]> data = FileParser.GetCsvFileContent(textBoxFilePath.Text);
			if (data.Count == 0) {
				MessageBox.Show(
					"Файл не содержит данных",
					textBoxFilePath.Text,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			dataGridViewFileContent.BeginInvoke((MethodInvoker)delegate () {
				dataGridViewFileContent.SuspendLayout();
				dataGridViewFileContent.Rows.Clear();

				dataGridViewFileContent.ColumnCount = data[0].Length;
				for (int i = 0; i < dataGridViewFileContent.ColumnCount; i++) {
					dataGridViewFileContent.Columns[i].Name = (i + 1).ToString();
					dataGridViewFileContent.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}

				for (int i = 0; i < data.Count; i++) {
					dataGridViewFileContent.Rows.Add(data[i]);
					dataGridViewFileContent.Rows[i].HeaderCell.Value = (i + 1).ToString();
				}
				
				dataGridViewFileContent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
				dataGridViewFileContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				dataGridViewFileContent.ResumeLayout();

				UpdateCalculateButtonState();
			});
		}

		private void RadioButtonPatientQuantityManual_CheckedChanged(object sender, EventArgs e) {
			textBoxPatientQuantity.Enabled = radioButtonPatientQuantityManual.Checked;
		}

		private void ButtonCalculate_Click(object sender, EventArgs e) {
			FileParser fileParser = new FileParser(
				textBoxFilePath.Text,
				radioButtonPatientQuantityAuto.Checked,
				textBoxPatientQuantity.Text,
				textBoxRowFirstLine.Text,
				textBoxColumnKeyValue.Text,
				textBoxColumnHazardItems.Text,
				textBoxColumnMan.Text,
				textBoxColumnWoman.Text,
				textBoxColumnWomanOld.Text,
				checkBoxCalculateTypePeriodical.Checked,
				checkBoxCalculateTypePreliminary.Checked);

			FormCalculating formCalculating = new FormCalculating(fileParser);
			formCalculating.ShowDialog();
		}
	}
}
