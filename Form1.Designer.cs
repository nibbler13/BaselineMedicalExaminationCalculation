namespace BaselineMedicalExaminationCalculation
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.PictureBox pictureBox2;
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxPatientQuantity = new System.Windows.Forms.TextBox();
            this.radioButtonPatientQuantityManual = new System.Windows.Forms.RadioButton();
            this.radioButtonPatientQuantityAuto = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewFileContent = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxWomanOld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxColumnWoman = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxColumnMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxCalculateTypePreliminary = new System.Windows.Forms.CheckBox();
            this.checkBoxCalculateTypePeriodical = new System.Windows.Forms.CheckBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(579, 16);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Выбрать";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(6, 19);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(567, 20);
            this.textBoxFilePath.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFilePath);
            this.groupBox1.Controls.Add(this.buttonSelectFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл для расчета";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxPatientQuantity);
            this.groupBox2.Controls.Add(this.radioButtonPatientQuantityManual);
            this.groupBox2.Controls.Add(this.radioButtonPatientQuantityAuto);
            this.groupBox2.Location = new System.Drawing.Point(12, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Количество пациентов";
            // 
            // textBoxPatientQuantity
            // 
            this.textBoxPatientQuantity.Enabled = false;
            this.textBoxPatientQuantity.Location = new System.Drawing.Point(121, 41);
            this.textBoxPatientQuantity.Name = "textBoxPatientQuantity";
            this.textBoxPatientQuantity.Size = new System.Drawing.Size(73, 20);
            this.textBoxPatientQuantity.TabIndex = 2;
            // 
            // radioButtonPatientQuantityManual
            // 
            this.radioButtonPatientQuantityManual.AutoSize = true;
            this.radioButtonPatientQuantityManual.Location = new System.Drawing.Point(7, 42);
            this.radioButtonPatientQuantityManual.Name = "radioButtonPatientQuantityManual";
            this.radioButtonPatientQuantityManual.Size = new System.Drawing.Size(108, 17);
            this.radioButtonPatientQuantityManual.TabIndex = 1;
            this.radioButtonPatientQuantityManual.Text = "Задать вручную:";
            this.radioButtonPatientQuantityManual.UseVisualStyleBackColor = true;
            // 
            // radioButtonPatientQuantityAuto
            // 
            this.radioButtonPatientQuantityAuto.AutoSize = true;
            this.radioButtonPatientQuantityAuto.Checked = true;
            this.radioButtonPatientQuantityAuto.Location = new System.Drawing.Point(7, 18);
            this.radioButtonPatientQuantityAuto.Name = "radioButtonPatientQuantityAuto";
            this.radioButtonPatientQuantityAuto.Size = new System.Drawing.Size(146, 17);
            this.radioButtonPatientQuantityAuto.TabIndex = 0;
            this.radioButtonPatientQuantityAuto.TabStop = true;
            this.radioButtonPatientQuantityAuto.Text = "Автоматический расчет";
            this.radioButtonPatientQuantityAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewFileContent);
            this.groupBox3.Location = new System.Drawing.Point(12, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 193);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Содержимое файла";
            // 
            // listViewFileContent
            // 
            this.listViewFileContent.Location = new System.Drawing.Point(6, 19);
            this.listViewFileContent.Name = "listViewFileContent";
            this.listViewFileContent.Size = new System.Drawing.Size(648, 168);
            this.listViewFileContent.TabIndex = 0;
            this.listViewFileContent.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxWomanOld);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxColumnWoman);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxColumnMan);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(242, 265);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 96);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Номера столбцов";
            // 
            // textBoxWomanOld
            // 
            this.textBoxWomanOld.Location = new System.Drawing.Point(142, 67);
            this.textBoxWomanOld.Name = "textBoxWomanOld";
            this.textBoxWomanOld.Size = new System.Drawing.Size(52, 20);
            this.textBoxWomanOld.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Женщины после 40 лет:";
            // 
            // textBoxColumnWoman
            // 
            this.textBoxColumnWoman.Location = new System.Drawing.Point(142, 43);
            this.textBoxColumnWoman.Name = "textBoxColumnWoman";
            this.textBoxColumnWoman.Size = new System.Drawing.Size(52, 20);
            this.textBoxColumnWoman.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Женщины:";
            // 
            // textBoxColumnMan
            // 
            this.textBoxColumnMan.Location = new System.Drawing.Point(142, 19);
            this.textBoxColumnMan.Name = "textBoxColumnMan";
            this.textBoxColumnMan.Size = new System.Drawing.Size(52, 20);
            this.textBoxColumnMan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мужчины:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.AutoSize = true;
            this.buttonCalculate.Enabled = false;
            this.buttonCalculate.Location = new System.Drawing.Point(287, 405);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(110, 23);
            this.buttonCalculate.TabIndex = 11;
            this.buttonCalculate.Text = "Выполнить расчет";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxCalculateTypePreliminary);
            this.groupBox5.Controls.Add(this.checkBoxCalculateTypePeriodical);
            this.groupBox5.Location = new System.Drawing.Point(472, 265);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 67);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Варианты расчета";
            // 
            // checkBoxCalculateTypePreliminary
            // 
            this.checkBoxCalculateTypePreliminary.AutoSize = true;
            this.checkBoxCalculateTypePreliminary.Location = new System.Drawing.Point(7, 42);
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
            this.checkBoxCalculateTypePeriodical.Location = new System.Drawing.Point(7, 19);
            this.checkBoxCalculateTypePeriodical.Name = "checkBoxCalculateTypePeriodical";
            this.checkBoxCalculateTypePeriodical.Size = new System.Drawing.Size(105, 17);
            this.checkBoxCalculateTypePeriodical.TabIndex = 0;
            this.checkBoxCalculateTypePeriodical.Text = "Периодический";
            this.checkBoxCalculateTypePeriodical.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 483);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Расчет стоимости профосмотров по 302 приказу";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listViewFileContent;
        private System.Windows.Forms.TextBox textBoxPatientQuantity;
        private System.Windows.Forms.RadioButton radioButtonPatientQuantityManual;
        private System.Windows.Forms.RadioButton radioButtonPatientQuantityAuto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxWomanOld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxColumnWoman;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxColumnMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxCalculateTypePreliminary;
        private System.Windows.Forms.CheckBox checkBoxCalculateTypePeriodical;
    }
}

