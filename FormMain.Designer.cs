namespace BaselineMedicalExaminationCalculation
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.PictureBox pictureBox1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			System.Windows.Forms.PictureBox pictureBox2;
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.GroupBox groupBox4;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.GroupBox groupBox5;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			this.buttonInfo = new System.Windows.Forms.Button();
			this.textBoxFilePath = new System.Windows.Forms.TextBox();
			this.buttonSelectFile = new System.Windows.Forms.Button();
			this.textBoxPatientQuantity = new System.Windows.Forms.TextBox();
			this.radioButtonPatientQuantityManual = new System.Windows.Forms.RadioButton();
			this.radioButtonPatientQuantityAuto = new System.Windows.Forms.RadioButton();
			this.dataGridViewFileContent = new System.Windows.Forms.DataGridView();
			this.textBox = new System.Windows.Forms.TextBox();
			this.textBoxKeyValue = new System.Windows.Forms.TextBox();
			this.textBoxFirstLine = new System.Windows.Forms.TextBox();
			this.textBoxWomanOld = new System.Windows.Forms.TextBox();
			this.textBoxColumnWoman = new System.Windows.Forms.TextBox();
			this.textBoxColumnMan = new System.Windows.Forms.TextBox();
			this.checkBoxCalculateTypePreliminary = new System.Windows.Forms.CheckBox();
			this.checkBoxCalculateTypePeriodical = new System.Windows.Forms.CheckBox();
			this.buttonCalculate = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			groupBox5 = new System.Windows.Forms.GroupBox();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileContent)).BeginInit();
			groupBox4.SuspendLayout();
			groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			pictureBox1.Location = new System.Drawing.Point(0, 473);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(684, 10);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			pictureBox2.Location = new System.Drawing.Point(572, 367);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(100, 100);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupBox1.Controls.Add(this.buttonInfo);
			groupBox1.Controls.Add(this.textBoxFilePath);
			groupBox1.Controls.Add(this.buttonSelectFile);
			groupBox1.Location = new System.Drawing.Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(660, 49);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Файл для расчета";
			// 
			// buttonInfo
			// 
			this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonInfo.Location = new System.Drawing.Point(631, 16);
			this.buttonInfo.Name = "buttonInfo";
			this.buttonInfo.Size = new System.Drawing.Size(23, 23);
			this.buttonInfo.TabIndex = 6;
			this.buttonInfo.Text = "?";
			this.buttonInfo.UseVisualStyleBackColor = true;
			this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
			// 
			// textBoxFilePath
			// 
			this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilePath.Location = new System.Drawing.Point(6, 19);
			this.textBoxFilePath.Name = "textBoxFilePath";
			this.textBoxFilePath.ReadOnly = true;
			this.textBoxFilePath.Size = new System.Drawing.Size(538, 20);
			this.textBoxFilePath.TabIndex = 5;
			// 
			// buttonSelectFile
			// 
			this.buttonSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectFile.Location = new System.Drawing.Point(550, 17);
			this.buttonSelectFile.Name = "buttonSelectFile";
			this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
			this.buttonSelectFile.TabIndex = 3;
			this.buttonSelectFile.Text = "Выбрать";
			this.buttonSelectFile.UseVisualStyleBackColor = true;
			this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
			// 
			// groupBox2
			// 
			groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupBox2.Controls.Add(this.textBoxPatientQuantity);
			groupBox2.Controls.Add(this.radioButtonPatientQuantityManual);
			groupBox2.Controls.Add(this.radioButtonPatientQuantityAuto);
			groupBox2.Location = new System.Drawing.Point(12, 279);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(167, 69);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Количество пациентов";
			// 
			// textBoxPatientQuantity
			// 
			this.textBoxPatientQuantity.Enabled = false;
			this.textBoxPatientQuantity.Location = new System.Drawing.Point(119, 41);
			this.textBoxPatientQuantity.Name = "textBoxPatientQuantity";
			this.textBoxPatientQuantity.Size = new System.Drawing.Size(40, 20);
			this.textBoxPatientQuantity.TabIndex = 2;
			// 
			// radioButtonPatientQuantityManual
			// 
			this.radioButtonPatientQuantityManual.AutoSize = true;
			this.radioButtonPatientQuantityManual.Enabled = false;
			this.radioButtonPatientQuantityManual.Location = new System.Drawing.Point(5, 42);
			this.radioButtonPatientQuantityManual.Name = "radioButtonPatientQuantityManual";
			this.radioButtonPatientQuantityManual.Size = new System.Drawing.Size(108, 17);
			this.radioButtonPatientQuantityManual.TabIndex = 1;
			this.radioButtonPatientQuantityManual.Text = "Задать вручную:";
			this.radioButtonPatientQuantityManual.UseVisualStyleBackColor = true;
			this.radioButtonPatientQuantityManual.CheckedChanged += new System.EventHandler(this.radioButtonPatientQuantityManual_CheckedChanged);
			// 
			// radioButtonPatientQuantityAuto
			// 
			this.radioButtonPatientQuantityAuto.AutoSize = true;
			this.radioButtonPatientQuantityAuto.Checked = true;
			this.radioButtonPatientQuantityAuto.Enabled = false;
			this.radioButtonPatientQuantityAuto.Location = new System.Drawing.Point(6, 20);
			this.radioButtonPatientQuantityAuto.Name = "radioButtonPatientQuantityAuto";
			this.radioButtonPatientQuantityAuto.Size = new System.Drawing.Size(146, 17);
			this.radioButtonPatientQuantityAuto.TabIndex = 0;
			this.radioButtonPatientQuantityAuto.TabStop = true;
			this.radioButtonPatientQuantityAuto.Text = "Автоматический расчет";
			this.radioButtonPatientQuantityAuto.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupBox3.Controls.Add(this.dataGridViewFileContent);
			groupBox3.Location = new System.Drawing.Point(12, 77);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(660, 196);
			groupBox3.TabIndex = 8;
			groupBox3.TabStop = false;
			groupBox3.Text = "Содержимое";
			// 
			// dataGridViewFileContent
			// 
			this.dataGridViewFileContent.AllowUserToAddRows = false;
			this.dataGridViewFileContent.AllowUserToDeleteRows = false;
			this.dataGridViewFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewFileContent.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridViewFileContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridViewFileContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFileContent.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewFileContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewFileContent.GridColor = System.Drawing.SystemColors.ControlLight;
			this.dataGridViewFileContent.Location = new System.Drawing.Point(6, 19);
			this.dataGridViewFileContent.MultiSelect = false;
			this.dataGridViewFileContent.Name = "dataGridViewFileContent";
			this.dataGridViewFileContent.ShowEditingIcon = false;
			this.dataGridViewFileContent.Size = new System.Drawing.Size(648, 171);
			this.dataGridViewFileContent.TabIndex = 15;
			// 
			// groupBox4
			// 
			groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupBox4.Controls.Add(this.textBox);
			groupBox4.Controls.Add(label6);
			groupBox4.Controls.Add(this.textBoxKeyValue);
			groupBox4.Controls.Add(this.textBoxFirstLine);
			groupBox4.Controls.Add(label5);
			groupBox4.Controls.Add(label4);
			groupBox4.Controls.Add(this.textBoxWomanOld);
			groupBox4.Controls.Add(label3);
			groupBox4.Controls.Add(this.textBoxColumnWoman);
			groupBox4.Controls.Add(label2);
			groupBox4.Controls.Add(this.textBoxColumnMan);
			groupBox4.Controls.Add(label1);
			groupBox4.Location = new System.Drawing.Point(185, 279);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(318, 90);
			groupBox4.TabIndex = 10;
			groupBox4.TabStop = false;
			groupBox4.Text = "Расположение ключевых значений";
			// 
			// textBox
			// 
			this.textBox.Enabled = false;
			this.textBox.Location = new System.Drawing.Point(138, 62);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(40, 20);
			this.textBox.TabIndex = 11;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(28, 66);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(104, 13);
			label6.TabIndex = 10;
			label6.Text = "Пункты вредности:";
			// 
			// textBoxKeyValue
			// 
			this.textBoxKeyValue.Enabled = false;
			this.textBoxKeyValue.Location = new System.Drawing.Point(138, 40);
			this.textBoxKeyValue.Name = "textBoxKeyValue";
			this.textBoxKeyValue.Size = new System.Drawing.Size(40, 20);
			this.textBoxKeyValue.TabIndex = 9;
			// 
			// textBoxFirstLine
			// 
			this.textBoxFirstLine.Enabled = false;
			this.textBoxFirstLine.Location = new System.Drawing.Point(138, 18);
			this.textBoxFirstLine.Name = "textBoxFirstLine";
			this.textBoxFirstLine.Size = new System.Drawing.Size(40, 20);
			this.textBoxFirstLine.TabIndex = 8;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(26, 44);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(106, 13);
			label5.TabIndex = 7;
			label5.Text = "Должность / ФИО:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(6, 22);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(126, 13);
			label4.TabIndex = 6;
			label4.Text = "Первая строка данных:";
			// 
			// textBoxWomanOld
			// 
			this.textBoxWomanOld.Enabled = false;
			this.textBoxWomanOld.Location = new System.Drawing.Point(272, 63);
			this.textBoxWomanOld.Name = "textBoxWomanOld";
			this.textBoxWomanOld.Size = new System.Drawing.Size(40, 20);
			this.textBoxWomanOld.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(189, 66);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(77, 13);
			label3.TabIndex = 4;
			label3.Text = "После 40 лет:";
			// 
			// textBoxColumnWoman
			// 
			this.textBoxColumnWoman.Enabled = false;
			this.textBoxColumnWoman.Location = new System.Drawing.Point(272, 39);
			this.textBoxColumnWoman.Name = "textBoxColumnWoman";
			this.textBoxColumnWoman.Size = new System.Drawing.Size(40, 20);
			this.textBoxColumnWoman.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(204, 42);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(62, 13);
			label2.TabIndex = 2;
			label2.Text = "Женщины:";
			// 
			// textBoxColumnMan
			// 
			this.textBoxColumnMan.Enabled = false;
			this.textBoxColumnMan.Location = new System.Drawing.Point(272, 15);
			this.textBoxColumnMan.Name = "textBoxColumnMan";
			this.textBoxColumnMan.Size = new System.Drawing.Size(40, 20);
			this.textBoxColumnMan.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(209, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(57, 13);
			label1.TabIndex = 0;
			label1.Text = "Мужчины:";
			// 
			// groupBox5
			// 
			groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupBox5.Controls.Add(this.checkBoxCalculateTypePreliminary);
			groupBox5.Controls.Add(this.checkBoxCalculateTypePeriodical);
			groupBox5.Location = new System.Drawing.Point(509, 279);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(163, 79);
			groupBox5.TabIndex = 12;
			groupBox5.TabStop = false;
			groupBox5.Text = "Варианты расчета";
			// 
			// checkBoxCalculateTypePreliminary
			// 
			this.checkBoxCalculateTypePreliminary.AutoSize = true;
			this.checkBoxCalculateTypePreliminary.Enabled = false;
			this.checkBoxCalculateTypePreliminary.Location = new System.Drawing.Point(7, 43);
			this.checkBoxCalculateTypePreliminary.Name = "checkBoxCalculateTypePreliminary";
			this.checkBoxCalculateTypePreliminary.Size = new System.Drawing.Size(119, 17);
			this.checkBoxCalculateTypePreliminary.TabIndex = 1;
			this.checkBoxCalculateTypePreliminary.Text = "Предварительный";
			this.checkBoxCalculateTypePreliminary.UseVisualStyleBackColor = true;
			// 
			// checkBoxCalculateTypePeriodical
			// 
			this.checkBoxCalculateTypePeriodical.AutoSize = true;
			this.checkBoxCalculateTypePeriodical.Checked = true;
			this.checkBoxCalculateTypePeriodical.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxCalculateTypePeriodical.Enabled = false;
			this.checkBoxCalculateTypePeriodical.Location = new System.Drawing.Point(7, 21);
			this.checkBoxCalculateTypePeriodical.Name = "checkBoxCalculateTypePeriodical";
			this.checkBoxCalculateTypePeriodical.Size = new System.Drawing.Size(105, 17);
			this.checkBoxCalculateTypePeriodical.TabIndex = 0;
			this.checkBoxCalculateTypePeriodical.Text = "Периодический";
			this.checkBoxCalculateTypePeriodical.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			label7.AutoSize = true;
			label7.ForeColor = System.Drawing.SystemColors.ControlDark;
			label7.Location = new System.Drawing.Point(9, 441);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(110, 13);
			label7.TabIndex = 13;
			label7.Text = "Прайс от 01.01.2017";
			// 
			// label8
			// 
			label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			label8.AutoSize = true;
			label8.ForeColor = System.Drawing.SystemColors.ControlDark;
			label8.Location = new System.Drawing.Point(9, 454);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(143, 13);
			label8.TabIndex = 14;
			label8.Text = "Приказ 302н от 12.04.2011";
			// 
			// buttonCalculate
			// 
			this.buttonCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonCalculate.Enabled = false;
			this.buttonCalculate.Location = new System.Drawing.Point(287, 405);
			this.buttonCalculate.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
			this.buttonCalculate.Name = "buttonCalculate";
			this.buttonCalculate.Size = new System.Drawing.Size(110, 23);
			this.buttonCalculate.TabIndex = 11;
			this.buttonCalculate.Text = "Выполнить расчет";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 483);
			this.Controls.Add(label8);
			this.Controls.Add(label7);
			this.Controls.Add(groupBox5);
			this.Controls.Add(this.buttonCalculate);
			this.Controls.Add(groupBox4);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox2);
			this.Controls.Add(groupBox1);
			this.Controls.Add(pictureBox2);
			this.Controls.Add(pictureBox1);
			this.MinimumSize = new System.Drawing.Size(700, 521);
			this.Name = "FormMain";
			this.Text = "Расчет стоимости профосмотров по 302 приказу";
			((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileContent)).EndInit();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonPatientQuantityManual;
        private System.Windows.Forms.RadioButton radioButtonPatientQuantityAuto;
        private System.Windows.Forms.CheckBox checkBoxCalculateTypePreliminary;
        private System.Windows.Forms.CheckBox checkBoxCalculateTypePeriodical;
		private System.Windows.Forms.TextBox textBoxPatientQuantity;
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.TextBox textBoxWomanOld;
		private System.Windows.Forms.TextBox textBoxColumnWoman;
		private System.Windows.Forms.TextBox textBoxColumnMan;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.TextBox textBoxKeyValue;
		private System.Windows.Forms.TextBox textBoxFirstLine;
		private System.Windows.Forms.Button buttonSelectFile;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.Button buttonInfo;
		private System.Windows.Forms.DataGridView dataGridViewFileContent;
	}
}

