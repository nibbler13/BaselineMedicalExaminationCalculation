namespace BaselineMedicalExaminationCalculation {
	partial class FormCalculating {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.buttonClose = new System.Windows.Forms.Button();
			this.textBoxProcess = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonClose.Enabled = false;
			this.buttonClose.Location = new System.Drawing.Point(205, 531);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
			// 
			// textBoxProcess
			// 
			this.textBoxProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxProcess.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxProcess.Location = new System.Drawing.Point(13, 13);
			this.textBoxProcess.Multiline = true;
			this.textBoxProcess.Name = "textBoxProcess";
			this.textBoxProcess.ReadOnly = true;
			this.textBoxProcess.Size = new System.Drawing.Size(459, 483);
			this.textBoxProcess.TabIndex = 2;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(13, 502);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(459, 23);
			this.progressBar.TabIndex = 3;
			// 
			// FormCalculating
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 566);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.textBoxProcess);
			this.Controls.Add(this.buttonClose);
			this.Name = "FormCalculating";
			this.Text = "Процесс выполнения";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.TextBox textBoxProcess;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}