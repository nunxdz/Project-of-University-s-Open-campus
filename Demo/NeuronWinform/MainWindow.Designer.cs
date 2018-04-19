using System.Windows.Forms;
namespace NeuronWinform
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLearnHMM = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gridSamples = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelUserLabeling = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.lbWhat = new System.Windows.Forms.Label();
            this.panelClassification = new System.Windows.Forms.Panel();
            this.noGestureBtt = new System.Windows.Forms.Button();
            this.nameProgramPanel = new System.Windows.Forms.Panel();
            this.nameProgramlabel = new System.Windows.Forms.Label();
            this.yesGestureBtt = new System.Windows.Forms.Button();
            this.lbHaveYouDrawn = new System.Windows.Forms.Label();
            this.menuFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openDataDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.recognizeAslabel = new System.Windows.Forms.Label();
            this.myCanvas = new NeuronWinform.Canvas();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSamples)).BeginInit();
            this.panelUserLabeling.SuspendLayout();
            this.panelClassification.SuspendLayout();
            this.nameProgramPanel.SuspendLayout();
            this.menuFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(824, 502);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP Illustration";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(102, 81);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(102, 56);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 19);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "7003";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(102, 31);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 19);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.22.22";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Port :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP :";
            // 
            // btnLearnHMM
            // 
            this.btnLearnHMM.Enabled = false;
            this.btnLearnHMM.Location = new System.Drawing.Point(9, 650);
            this.btnLearnHMM.Name = "btnLearnHMM";
            this.btnLearnHMM.Size = new System.Drawing.Size(116, 37);
            this.btnLearnHMM.TabIndex = 20;
            this.btnLearnHMM.Text = "Create a Hidden Markov Model Classifier";
            this.btnLearnHMM.UseVisualStyleBackColor = true;
            this.btnLearnHMM.Click += new System.EventHandler(this.btnLearnHMM_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(131, 650);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 38);
            this.button4.TabIndex = 22;
            this.button4.Text = "Database";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFile_MouseDown);
            // 
            // gridSamples
            // 
            this.gridSamples.AllowUserToAddRows = false;
            this.gridSamples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSamples.BackgroundColor = System.Drawing.Color.White;
            this.gridSamples.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSamples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colClassification});
            this.gridSamples.GridColor = System.Drawing.SystemColors.ControlLight;
            this.gridSamples.Location = new System.Drawing.Point(824, 12);
            this.gridSamples.Name = "gridSamples";
            this.gridSamples.Size = new System.Drawing.Size(204, 484);
            this.gridSamples.TabIndex = 34;
            // 
            // colImage
            // 
            this.colImage.DataPropertyName = "Bitmap";
            this.colImage.FillWeight = 30F;
            this.colImage.HeaderText = "Gesture";
            this.colImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            // 
            // colClassification
            // 
            this.colClassification.DataPropertyName = "OutputName";
            this.colClassification.FillWeight = 40F;
            this.colClassification.HeaderText = "Class";
            this.colClassification.Name = "colClassification";
            this.colClassification.ReadOnly = true;
            // 
            // panelUserLabeling
            // 
            this.panelUserLabeling.BackColor = System.Drawing.Color.White;
            this.panelUserLabeling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserLabeling.Controls.Add(this.btnClear);
            this.panelUserLabeling.Controls.Add(this.btnInsert);
            this.panelUserLabeling.Controls.Add(this.label7);
            this.panelUserLabeling.Controls.Add(this.cbClasses);
            this.panelUserLabeling.Controls.Add(this.lbWhat);
            this.panelUserLabeling.Location = new System.Drawing.Point(232, 539);
            this.panelUserLabeling.Name = "panelUserLabeling";
            this.panelUserLabeling.Size = new System.Drawing.Size(461, 74);
            this.panelUserLabeling.TabIndex = 35;
            this.panelUserLabeling.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(222, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(225, 21);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Forget my Gesture";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(222, 30);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(225, 35);
            this.btnInsert.TabIndex = 27;
            this.btnInsert.Text = "Insert my Gesture into the database!";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsertGesture_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Gesture";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // cbClasses
            // 
            this.cbClasses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbClasses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbClasses.Location = new System.Drawing.Point(81, 35);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(101, 20);
            this.cbClasses.TabIndex = 23;
            // 
            // lbWhat
            // 
            this.lbWhat.AutoSize = true;
            this.lbWhat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhat.Location = new System.Drawing.Point(8, 11);
            this.lbWhat.Name = "lbWhat";
            this.lbWhat.Size = new System.Drawing.Size(194, 27);
            this.lbWhat.TabIndex = 25;
            this.lbWhat.Text = "What have you Gesture?";
            this.lbWhat.UseCompatibleTextRendering = true;
            // 
            // panelClassification
            // 
            this.panelClassification.BackColor = System.Drawing.Color.White;
            this.panelClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClassification.Controls.Add(this.noGestureBtt);
            this.panelClassification.Controls.Add(this.nameProgramPanel);
            this.panelClassification.Controls.Add(this.yesGestureBtt);
            this.panelClassification.Controls.Add(this.lbHaveYouDrawn);
            this.panelClassification.Location = new System.Drawing.Point(232, 28);
            this.panelClassification.Name = "panelClassification";
            this.panelClassification.Size = new System.Drawing.Size(461, 74);
            this.panelClassification.TabIndex = 36;
            this.panelClassification.Visible = false;
            // 
            // noGestureBtt
            // 
            this.noGestureBtt.Location = new System.Drawing.Point(107, 43);
            this.noGestureBtt.Name = "noGestureBtt";
            this.noGestureBtt.Size = new System.Drawing.Size(75, 23);
            this.noGestureBtt.TabIndex = 26;
            this.noGestureBtt.Text = "No...";
            this.noGestureBtt.UseVisualStyleBackColor = true;
            this.noGestureBtt.Click += new System.EventHandler(this.noGestureBtt_Click);
            // 
            // nameProgramPanel
            // 
            this.nameProgramPanel.Controls.Add(this.nameProgramlabel);
            this.nameProgramPanel.Location = new System.Drawing.Point(120, 24);
            this.nameProgramPanel.Name = "nameProgramPanel";
            this.nameProgramPanel.Size = new System.Drawing.Size(251, 32);
            this.nameProgramPanel.TabIndex = 46;
            this.nameProgramPanel.Visible = false;
            // 
            // nameProgramlabel
            // 
            this.nameProgramlabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameProgramlabel.Location = new System.Drawing.Point(20, 2);
            this.nameProgramlabel.Name = "nameProgramlabel";
            this.nameProgramlabel.Size = new System.Drawing.Size(212, 25);
            this.nameProgramlabel.TabIndex = 26;
            this.nameProgramlabel.UseCompatibleTextRendering = true;
            // 
            // yesGestureBtt
            // 
            this.yesGestureBtt.Location = new System.Drawing.Point(26, 43);
            this.yesGestureBtt.Name = "yesGestureBtt";
            this.yesGestureBtt.Size = new System.Drawing.Size(75, 23);
            this.yesGestureBtt.TabIndex = 26;
            this.yesGestureBtt.Text = "Yes!";
            this.yesGestureBtt.UseVisualStyleBackColor = true;
            this.yesGestureBtt.Click += new System.EventHandler(this.yesGestureBtt_Click);
            // 
            // lbHaveYouDrawn
            // 
            this.lbHaveYouDrawn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHaveYouDrawn.Location = new System.Drawing.Point(8, 11);
            this.lbHaveYouDrawn.Name = "lbHaveYouDrawn";
            this.lbHaveYouDrawn.Size = new System.Drawing.Size(437, 25);
            this.lbHaveYouDrawn.TabIndex = 25;
            this.lbHaveYouDrawn.UseCompatibleTextRendering = true;
            // 
            // menuFile
            // 
            this.menuFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuFile.Name = "contextMenuStrip1";
            this.menuFile.Size = new System.Drawing.Size(105, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem1.Text = "Open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.openDataStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem2.Text = "Save";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.saveDataStripMenuItem_Click);
            // 
            // openDataDialog
            // 
            this.openDataDialog.FileName = "openFileDialog1";
            this.openDataDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveDataDialog
            // 
            this.saveDataDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDataDialog_FileOk);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(347, 660);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 16);
            this.radioButton2.TabIndex = 43;
            this.radioButton2.Text = "RecogGesture";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(253, 660);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 16);
            this.radioButton1.TabIndex = 42;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SaveGesture";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 660);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "RecognizeAs : ";
            // 
            // recognizeAslabel
            // 
            this.recognizeAslabel.AutoSize = true;
            this.recognizeAslabel.Location = new System.Drawing.Point(559, 660);
            this.recognizeAslabel.Name = "recognizeAslabel";
            this.recognizeAslabel.Size = new System.Drawing.Size(13, 12);
            this.recognizeAslabel.TabIndex = 45;
            this.recognizeAslabel.Text = "....";
            // 
            // myCanvas
            // 
            this.myCanvas.BackColor = System.Drawing.Color.White;
            this.myCanvas.Location = new System.Drawing.Point(8, 12);
            this.myCanvas.MinimumSize = new System.Drawing.Size(128, 128);
            this.myCanvas.Name = "myCanvas";
            this.myCanvas.Neuron = null;
            this.myCanvas.Size = new System.Drawing.Size(810, 622);
            this.myCanvas.TabIndex = 19;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.recognizeAslabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.panelClassification);
            this.Controls.Add(this.panelUserLabeling);
            this.Controls.Add(this.gridSamples);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLearnHMM);
            this.Controls.Add(this.myCanvas);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Gesture Recognition by HMM(Neuron Reader)_Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSamples)).EndInit();
            this.panelUserLabeling.ResumeLayout(false);
            this.panelUserLabeling.PerformLayout();
            this.panelClassification.ResumeLayout(false);
            this.nameProgramPanel.ResumeLayout(false);
            this.menuFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Canvas myCanvas;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnLearnHMM;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.DataGridView gridSamples;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassification;
        public System.Windows.Forms.Panel panelUserLabeling;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbClasses;
        private System.Windows.Forms.Label lbWhat;
        public System.Windows.Forms.Panel panelClassification;
        private System.Windows.Forms.Button noGestureBtt;
        private System.Windows.Forms.Button yesGestureBtt;
        public System.Windows.Forms.Label lbHaveYouDrawn;
        private System.Windows.Forms.ContextMenuStrip menuFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog openDataDialog;
        private System.Windows.Forms.SaveFileDialog saveDataDialog;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label3;
        public Label recognizeAslabel;
        public Panel nameProgramPanel;
        public Label nameProgramlabel;
    }
}

