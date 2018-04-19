using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Distributions.Multivariate;
using Accord.Statistics.Models.Fields;
using Accord.Statistics.Models.Fields.Functions;
using Accord.Statistics.Models.Fields.Learning;
using Accord.Statistics.Models.Markov;
using Accord.Statistics.Models.Markov.Learning;
using Accord.Statistics.Models.Markov.Topology;
using Gestures.HMMs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuronWinform
{
    public partial class MainWindow : Form
    {
        public Neuron n;
        public HMM myHMM;
        public Database database;
        
        public MainWindow()
        {
            InitializeComponent();

            n = new Neuron();
            n.mainwindow = this;
            myCanvas.Neuron = n;

            myHMM = new HMM();
            myHMM.mainwindow = this;

            database = new Database();
            gridSamples.AutoGenerateColumns = false;
            cbClasses.DataSource = database.Classes;
            gridSamples.DataSource = database.Samples;

            openDataDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Resources");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            n.Load();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            n.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            n.btnConnect_Click(sender, e);
        }

        private void btnLearnHMM_Click(object sender, EventArgs e)
        {
            if (gridSamples.Rows.Count == 0)
            {
                MessageBox.Show("Please load or insert some data first.");
                return;
            }

            myHMM.LearnHMM();
        }

        private void btnLearnHCRF_Click(object sender, EventArgs e)
        {
            if (gridSamples.Rows.Count == 0)
            {
                MessageBox.Show("Please load or insert some data first.");
                return;
            }

            myHMM.LeardHCRF();

            foreach (DataGridViewRow row in gridSamples.Rows)
            {
                var sample = row.DataBoundItem as Sequence;
                row.DefaultCellStyle.BackColor = (sample.RecognizedAs == sample.Output) ?
                    Color.LightGreen : Color.White;
            }
        }

        private void btnFile_MouseDown(object sender, MouseEventArgs e)
        {
            menuFile.Show(button4, button4.PointToClient(Cursor.Position));
        }

        private void openDataStripMenuItem_Click(object sender, EventArgs e)
        {
            openDataDialog.ShowDialog();
        }

        private void saveDataStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDataDialog.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            myHMM.hmm = null;
            myHMM.hcrf = null;

            using (var stream = openDataDialog.OpenFile())
                database.Load(stream);

            btnLearnHMM.Enabled = true;

            panelClassification.Visible = false;
            panelUserLabeling.Visible = false;
            //if (n.sockTCPRef != IntPtr.Zero && btnConnect.Text == "Disconnect")
            //    SetEnebleButton(startTimeOut, true);
        }

        private void saveDataDialog_FileOk(object sender, CancelEventArgs e)
        {
            using (var stream = saveDataDialog.OpenFile())
                database.Save(stream);
        }

        private System.Timers.Timer aTimer;
        private int counter = 3;  

        public void OpenProgram(string label)
        {
            if (label == "Notepad")
            {
                Process myProcess = Process.Start("Notepad");
            }
            else if (label == "Calculator")
            {
                Process myProcess = Process.Start("calc");
            }
            else if (label == "Paint")
            {
                Process myProcess = Process.Start("mspaint");
            }
        }

        private void btnInsertGesture_Click(object sender, EventArgs e)
        {
            addGesture();
        }

        private void addGesture()
        {
            string selectedItem = cbClasses.SelectedItem as String;
            string classLabel = String.IsNullOrEmpty(selectedItem) ?
                cbClasses.Text : selectedItem;

            if (database.Add(myCanvas.GetSequence(), classLabel) != null)
            {
                myCanvas.Clear();

                if (database.Classes.Count >= 2 &&
                    database.SamplesPerClass() >= 3)
                    btnLearnHMM.Enabled = true;

                panelUserLabeling.Visible = false;
                panelClassification.Visible = false;
            }
            n.isCountable = true;
        }

        private void noGestureBtt_Click(object sender, EventArgs e)
        {
            panelClassification.Visible = false;
            panelUserLabeling.Visible = true;
            //n.isCountable = true;
            addGesture();
        }

        private void yesGestureBtt_Click(object sender, EventArgs e)
        {
            double[][] input = Sequence.Preprocess(myCanvas.GetSequence());
            int index = (myHMM.hcrf != null) ?
                        myHMM.hcrf.Compute(input) : myHMM.hmm.Compute(input);

            string label = database.Classes[index];

            if (label == "notepad")
            {
                Process myProcess = Process.Start("Notepad");
            }
            else if (label == "calculator")
            {
                Process myProcess = Process.Start("calc");
            }
            else if (label == "paint")
            {
                Process myProcess = Process.Start("mspaint");
            }

            //addGesture();
        }
        delegate void SetTextCallback(Label l,string text);
        public void SetTextLabel(Label l, string text)
        {
            if (l.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextLabel);
                this.Invoke(d, new object[] { l,text });
            }
            else
            {
                l.Text = text;
            }
        }

        delegate void SetVisiblePanelCallback(Panel p,bool isVisible);
        private void SetVisiblePanel(Panel p,bool isVisible)
        {
            if (p.InvokeRequired)
            {
                SetVisiblePanelCallback d = new SetVisiblePanelCallback(SetVisiblePanel);
                this.Invoke(d, new object[] { p, isVisible });
            }
            else
            {
                p.Visible = isVisible;
            }
        }

        delegate void SetVisibleLabelCallback(Label l, bool isVisible);
        private void SetVisibleLabel(Label l, bool isVisible)
        {
            if (l.InvokeRequired)
            {
                SetVisibleLabelCallback d = new SetVisibleLabelCallback(SetVisibleLabel);
                this.Invoke(d, new object[] { l, isVisible });
            }
            else
            {
                l.Visible = isVisible;
            }
        }

        delegate void SetItemComboboxCallback(ComboBox c, string text);
        private void SetItemCombobox(ComboBox c, string text)
        {
            if (c.InvokeRequired)
            {
                SetItemComboboxCallback d = new SetItemComboboxCallback(SetItemCombobox);
                this.Invoke(d, new object[] { c, text });
            }
            else
            {
                c.SelectedItem = text;
            }
        }
        delegate void SetEnebleButtonCallback(Button b, bool isVisible);
        private void SetEnebleButton(Button b, bool isVisible)
        {
            if (b.InvokeRequired)
            {
                SetEnebleButtonCallback d = new SetEnebleButtonCallback(SetEnebleButton);
                this.Invoke(d, new object[] { b, isVisible });
            }
            else
            {
                b.Enabled = isVisible;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            myCanvas.Clear();
            panelUserLabeling.Visible = false;
            panelClassification.Visible = false;
            n.isCountable = true;
        }

        public int CurrentState = 0; //0 = Save , 1 = Recognize
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CurrentState = 0;
            n.isCountable = true;
            panelClassification.Visible = false;
            panelUserLabeling.Visible = false;
            n.isTimingDecision = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CurrentState = 1; 
            n.isCountable = true;
            panelClassification.Visible = false;
            panelUserLabeling.Visible = false;
            n.isTimingDecision = false; n.isTimingDecision = false;
        }
    }
}
