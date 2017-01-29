using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace BaselineMedicalExaminationCalculation {
    public partial class FormMain : Form {

		public FormMain() {
            InitializeComponent();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e) {
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

		private void buttonInfo_Click(object sender, EventArgs e) {
			MessageBox.Show("Help", "123", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void SetControlsState() {
			foreach (Control control in this.Controls) {
				if (control.GetType() == typeof(GroupBox))
					foreach (Control innerControl in control.Controls) {
						innerControl.Enabled = true;
						if (innerControl.GetType() == typeof(TextBox) &&
							innerControl.Name != textBoxFilePath.Name)
							innerControl.Text = "";
					}
			}

			radioButtonPatientQuantityAuto.Checked = true;
			textBoxPatientQuantity.Enabled = false;
			checkBoxCalculateTypePeriodical.Checked = true;
			checkBoxCalculateTypePreliminary.Checked = false;

			Thread thread = new Thread(UpdateListView);
			thread.Start();
		}

		private void UpdateListView() {
			Console.WriteLine("update list view");
			List<String[]> data = FileParser.GetFileContent(textBoxFilePath.Text);
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
			});
		}

		private void radioButtonPatientQuantityManual_CheckedChanged(object sender, EventArgs e) {
			textBoxPatientQuantity.Enabled = radioButtonPatientQuantityManual.Checked;
		}
	}
}
