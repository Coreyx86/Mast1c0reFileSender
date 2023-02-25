namespace Mast1c0reFileLoader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_saveSettings = new System.Windows.Forms.Button();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_fileStep = new System.Windows.Forms.Label();
            this.button_sendFile = new System.Windows.Forms.Button();
            this.button_clearFile = new System.Windows.Forms.Button();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.button_openFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_saveSettings);
            this.groupBox1.Controls.Add(this.numericUpDown_port);
            this.groupBox1.Controls.Add(this.textBox_ip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Settings";
            // 
            // button_saveSettings
            // 
            this.button_saveSettings.Location = new System.Drawing.Point(184, 16);
            this.button_saveSettings.Name = "button_saveSettings";
            this.button_saveSettings.Size = new System.Drawing.Size(109, 23);
            this.button_saveSettings.TabIndex = 4;
            this.button_saveSettings.Text = "Save Settings";
            this.button_saveSettings.UseVisualStyleBackColor = true;
            this.button_saveSettings.Click += new System.EventHandler(this.button_saveSettings_Click);
            // 
            // numericUpDown_port
            // 
            this.numericUpDown_port.Location = new System.Drawing.Point(77, 45);
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.numericUpDown_port.Size = new System.Drawing.Size(101, 23);
            this.numericUpDown_port.TabIndex = 3;
            this.numericUpDown_port.Value = new decimal(new int[] {
            9045,
            0,
            0,
            0});
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(77, 16);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(101, 23);
            this.textBox_ip.TabIndex = 2;
            this.textBox_ip.Text = "192.168.1.200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_fileStep);
            this.groupBox2.Controls.Add(this.button_sendFile);
            this.groupBox2.Controls.Add(this.button_clearFile);
            this.groupBox2.Controls.Add(this.textBox_filePath);
            this.groupBox2.Controls.Add(this.button_openFile);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Actions";
            // 
            // label_fileStep
            // 
            this.label_fileStep.AutoSize = true;
            this.label_fileStep.Location = new System.Drawing.Point(87, 55);
            this.label_fileStep.Name = "label_fileStep";
            this.label_fileStep.Size = new System.Drawing.Size(106, 15);
            this.label_fileStep.TabIndex = 4;
            this.label_fileStep.Text = "Open a file to send";
            // 
            // button_sendFile
            // 
            this.button_sendFile.Enabled = false;
            this.button_sendFile.Location = new System.Drawing.Point(209, 51);
            this.button_sendFile.Name = "button_sendFile";
            this.button_sendFile.Size = new System.Drawing.Size(75, 23);
            this.button_sendFile.TabIndex = 3;
            this.button_sendFile.Text = "Send";
            this.button_sendFile.UseVisualStyleBackColor = true;
            this.button_sendFile.Click += new System.EventHandler(this.button_sendFile_Click);
            // 
            // button_clearFile
            // 
            this.button_clearFile.Enabled = false;
            this.button_clearFile.Location = new System.Drawing.Point(6, 51);
            this.button_clearFile.Name = "button_clearFile";
            this.button_clearFile.Size = new System.Drawing.Size(75, 23);
            this.button_clearFile.TabIndex = 2;
            this.button_clearFile.Text = "Clear";
            this.button_clearFile.UseVisualStyleBackColor = true;
            this.button_clearFile.Click += new System.EventHandler(this.button_clearFile_Click);
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Enabled = false;
            this.textBox_filePath.Location = new System.Drawing.Point(87, 22);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.PlaceholderText = "Open a file to send...";
            this.textBox_filePath.ReadOnly = true;
            this.textBox_filePath.Size = new System.Drawing.Size(197, 23);
            this.textBox_filePath.TabIndex = 1;
            this.textBox_filePath.DoubleClick += new System.EventHandler(this.textBox_filePath_DoubleClick);
            // 
            // button_openFile
            // 
            this.button_openFile.Location = new System.Drawing.Point(6, 22);
            this.button_openFile.Name = "button_openFile";
            this.button_openFile.Size = new System.Drawing.Size(75, 23);
            this.button_openFile.TabIndex = 0;
            this.button_openFile.Text = "Open";
            this.button_openFile.UseVisualStyleBackColor = true;
            this.button_openFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created by @_mccaulay, ported by Coreyx86";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 185);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(321, 224);
            this.MinimumSize = new System.Drawing.Size(321, 224);
            this.Name = "Form1";
            this.Text = "Mast1c0re File Sender";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numericUpDown_port;
        private TextBox textBox_ip;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox textBox_filePath;
        private Button button_openFile;
        private Button button_sendFile;
        private Button button_clearFile;
        private Button button_saveSettings;
        private Label label3;
        private Label label_fileStep;
    }
}