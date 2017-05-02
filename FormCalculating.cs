using System;
using System.Threading;
using System.Windows.Forms;

namespace BaselineMedicalExaminationCalculation {
	public partial class FormCalculating : Form {
		FileParser fileParser;

		public FormCalculating(FileParser fileParser) {
			InitializeComponent();
			this.fileParser = fileParser;
			textBoxProcess.MaxLength = int.MaxValue;
			textBoxProcess.ScrollBars = ScrollBars.Vertical;
			//this.ControlBox = false;
			this.Shown += FormCalculating_Shown;
		}

		private void FormCalculating_Shown(object sender, EventArgs e) {
			Thread thread = new Thread(Calculate);
			thread.Start();
		}

		private void Calculate() {
			fileParser.CalculateCostOfExaminations(textBoxProcess, progressBar);
			buttonClose.BeginInvoke((MethodInvoker)delegate {
				buttonClose.Enabled = true;
			});
		}

		private void ButtonClose_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
