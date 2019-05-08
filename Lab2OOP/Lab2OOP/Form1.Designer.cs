namespace Lab2OOP
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
            this.ChooseDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butEd = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.comboBoxChooseSer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ChooseDevice
            // 
            this.ChooseDevice.DropDownHeight = 120;
            this.ChooseDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseDevice.FormattingEnabled = true;
            this.ChooseDevice.IntegralHeight = false;
            this.ChooseDevice.Location = new System.Drawing.Point(214, 12);
            this.ChooseDevice.Name = "ChooseDevice";
            this.ChooseDevice.Size = new System.Drawing.Size(317, 30);
            this.ChooseDevice.TabIndex = 1;
            this.ChooseDevice.SelectedIndexChanged += new System.EventHandler(this.ChooceDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(240)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose class of object to create:";
            // 
            // butEd
            // 
            this.butEd.Enabled = false;
            this.butEd.Location = new System.Drawing.Point(554, 6);
            this.butEd.Name = "butEd";
            this.butEd.Size = new System.Drawing.Size(274, 41);
            this.butEd.TabIndex = 5;
            this.butEd.Text = "Edit object";
            this.butEd.UseVisualStyleBackColor = true;
            this.butEd.Click += new System.EventHandler(this.butEd_Click);
            // 
            // butDel
            // 
            this.butDel.Enabled = false;
            this.butDel.Location = new System.Drawing.Point(834, 6);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(261, 41);
            this.butDel.TabIndex = 6;
            this.butDel.Text = "Delete object";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(2, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1126, 488);
            this.listBox1.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(554, 77);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(274, 41);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(834, 77);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(261, 41);
            this.buttonOpen.TabIndex = 9;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // comboBoxChooseSer
            // 
            this.comboBoxChooseSer.DropDownHeight = 120;
            this.comboBoxChooseSer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseSer.FormattingEnabled = true;
            this.comboBoxChooseSer.IntegralHeight = false;
            this.comboBoxChooseSer.Location = new System.Drawing.Point(214, 83);
            this.comboBoxChooseSer.Name = "comboBoxChooseSer";
            this.comboBoxChooseSer.Size = new System.Drawing.Size(317, 30);
            this.comboBoxChooseSer.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(240)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Choose serializer:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1131, 664);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxChooseSer);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butEd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseDevice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(240)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ChooseDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butEd;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.ComboBox comboBoxChooseSer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

