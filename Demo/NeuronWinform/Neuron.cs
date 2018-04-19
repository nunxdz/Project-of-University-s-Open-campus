using Gestures.HMMs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NeuronWinform
{
    public class Neuron
    {
        public MainWindow mainwindow;

        int _frameCount;
        SocketStatusChanged _SocketStatusChanged;
        FrameDataReceived _CalcDataReceived;

        CalcDataHeader _calcHeader;
        private float[] _valuesBufferCalc = new float[338];

        public IntPtr sockTCPRef = IntPtr.Zero;
        public IntPtr sockUDPRef = IntPtr.Zero;

        //public int[] useBone = { 0 };
        public int[] useBoneCal = { 0, 18, 15, 11, 12, 13, 14, 7, 8, 9, 10 };
        public List<DataModel> DataList = new List<DataModel>();

        Hashtable table = new Hashtable();

        public bool isReadySavetoDB = false;

        public event EventHandler<Event> RaiseCustomEvent;
        protected virtual void OnRaiseCustomEvent(Event e)
        {
            EventHandler<Event> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Load()
        {
            _CalcDataReceived = new FrameDataReceived(calcDataReceived);
            NeuronDataReader.BRRegisterCalculationDataCallback(IntPtr.Zero, _CalcDataReceived);

            _SocketStatusChanged = new SocketStatusChanged(socketStatusChanged);
            NeuronDataReader.BRRegisterSocketStatusCallback(IntPtr.Zero, _SocketStatusChanged);
        }

        public void Close()
        {
            if (sockTCPRef != IntPtr.Zero)
            {
                NeuronDataReader.BRCloseSocket(sockTCPRef);
                sockTCPRef = IntPtr.Zero;
            }

            if (sockUDPRef != IntPtr.Zero)
            {
                NeuronDataReader.BRCloseSocket(sockUDPRef);
                sockUDPRef = IntPtr.Zero;
            }
        }

        public bool isCountable = true;
        public bool isTimingDecision = false;
        string tempGesture = null;
        string gestureMean = "";
        private void UpdateCalcDataUI(float[] calcData)
        {
            DataModel model;
            if (isStart)
            {
                initialDataModel(calcData);
            }
            if (mainwindow.CurrentState == 0 && !isTimingDecision) // Save Gesture
            {
                if (_frameCount >= 120) _frameCount = 0;
                if (isCountable) _frameCount++;
                if (_frameCount == 120)
                {
                    isCountable = false;
                    mainwindow.panelUserLabeling.Visible = true;
                }

                for (int i = 0; i < useBoneCal.Length; i++)
                {
                    model = (DataModel)table[useBoneCal[i]];

                    model.Px = (calcData[model.BoneID * 16 + 1] * 500) + (mainwindow.myCanvas.Width / 2);
                    model.Py = (calcData[model.BoneID * 16 + 2] * 500) + (mainwindow.myCanvas.Height / 2) + 250;

                    table[useBoneCal[i]] = model;

                    if (isCountable)
                        mainwindow.myCanvas.sequence.Add(new Point(Convert.ToInt32(model.Px), Convert.ToInt32(model.Py)));
                }

                OnRaiseCustomEvent(new Event(table));
            }
            else if (mainwindow.CurrentState == 1 && mainwindow.database.Classes.Count > 0 && !isTimingDecision) // Recog Gesture
            {
                mainwindow.nameProgramPanel.Visible = false;
                if (_frameCount >= 120) _frameCount = 0;
                if (isCountable) _frameCount++;
                if (_frameCount == 120)
                {
                    isCountable = false;
                    mainwindow.panelClassification.Visible = true;

                    double[][] input = Sequence.Preprocess(mainwindow.myCanvas.GetSequence());
                    if (mainwindow.myHMM == null) return;
                    int index = (mainwindow.myHMM.hcrf != null) ?
                                mainwindow.myHMM.hcrf.Compute(input) : mainwindow.myHMM.hmm.Compute(input);
                    mainwindow.myCanvas.sequence.Clear();
                    string label = mainwindow.database.Classes[index];
                    mainwindow.recognizeAslabel.Text = label;
                    if (label != "No" && label != "Yes" && label != "None")
                    {
                        gestureMean = label;
                        mainwindow.SetTextLabel(mainwindow.lbHaveYouDrawn, String.Format("Do you want to open *{0}* program right?", label));
                    }

                    isTimingDecision = true;
                    isCountable = true;
                    _frameCount = 0;
                }

                for (int i = 0; i < useBoneCal.Length; i++)
                {
                    model = (DataModel)table[useBoneCal[i]];

                    model.Px = (calcData[model.BoneID * 16 + 1] * 500) + (mainwindow.myCanvas.Width / 2);
                    model.Py = (calcData[model.BoneID * 16 + 2] * 500) + (mainwindow.myCanvas.Height / 2) + 250;

                    table[useBoneCal[i]] = model;

                    if (isCountable)
                        mainwindow.myCanvas.sequence.Add(new Point(Convert.ToInt32(model.Px), Convert.ToInt32(model.Py)));
                }

                OnRaiseCustomEvent(new Event(table));
            }
            else if(mainwindow.CurrentState == 1 && isTimingDecision)
            {
                mainwindow.nameProgramPanel.Visible = false;
                if (_frameCount >= 120) _frameCount = 0;
                if (isCountable) _frameCount++;
                if (_frameCount == 120)
                {
                    isCountable = false;
                    mainwindow.panelClassification.Visible = true;

                    double[][] input = Sequence.Preprocess(mainwindow.myCanvas.GetSequence());
                    if (mainwindow.myHMM == null) return;
                    int index = (mainwindow.myHMM.hcrf != null) ?
                                mainwindow.myHMM.hcrf.Compute(input) : mainwindow.myHMM.hmm.Compute(input);
                    mainwindow.myCanvas.sequence.Clear();
                    string label = mainwindow.database.Classes[index];
                    //mainwindow.recognizeAslabel.Text = label;
                    if (label == "Yes")
                    {
                        if (gestureMean != "")
                        {
                            mainwindow.nameProgramPanel.Visible = true;
                            mainwindow.nameProgramlabel.Text = "[" + gestureMean + "] Opening...";
                            mainwindow.OpenProgram(gestureMean);
                            gestureMean = "";
                            mainwindow.panelClassification.Visible = false;

                            isCountable = true;
                            isTimingDecision = false;
                        }
                        else
                        {
                            mainwindow.panelClassification.Visible = false;
                            isCountable = true;
                            isTimingDecision = false;
                        }
                    }
                    else if(label == "No")
                    {
                        mainwindow.panelClassification.Visible = false;
                        isCountable = true;
                        isTimingDecision = false;
                    }
                    else
                    {
                        //if(tempGesture == gestureMean)
                            isCountable = true;
                        //mainwindow.SetTextLabel(mainwindow.lbHaveYouDrawn, String.Format("Do you want to open *{0}* program right?", label));

                    }
                }

                for (int i = 0; i < useBoneCal.Length; i++)
                {
                    model = (DataModel)table[useBoneCal[i]];

                    model.Px = (calcData[model.BoneID * 16 + 1] * 500) + (mainwindow.myCanvas.Width / 2);
                    model.Py = (calcData[model.BoneID * 16 + 2] * 500) + (mainwindow.myCanvas.Height / 2) + 250;

                    table[useBoneCal[i]] = model;

                    if (isCountable)
                        mainwindow.myCanvas.sequence.Add(new Point(Convert.ToInt32(model.Px), Convert.ToInt32(model.Py)));
                }

                OnRaiseCustomEvent(new Event(table));
            }
        }

        bool isStart = true;
        private void initialDataModel(float[] bvhData)
        {
            DataModel model;
            for (int i = 0; i < useBoneCal.Length; i++)
            {
                model = new DataModel();
                model.Index = i;
                model.BoneID = useBoneCal[i];

                model.Sx = (((bvhData[model.BoneID * 6 + 0]) * 10)) + 400;

                if (bvhData[model.BoneID * 6 + 1] > 0)
                    model.Sy = 350 - ((bvhData[model.BoneID * 6 + 1]) * 10);
                else
                    model.Sy = ((bvhData[model.BoneID * 6 + 1]) * 10) + 350;

                model.Sz = (bvhData[model.BoneID * 6 + 2]) + 400;
                table.Add(useBoneCal[i], model);

                DataList.Add(model);
            }
            isStart = false;
        }

        private void calcDataReceived(IntPtr customObject, IntPtr sockRef, IntPtr header, IntPtr data)
        {
            _calcHeader = (CalcDataHeader)Marshal.PtrToStructure(header, typeof(CalcDataHeader));
            // Change the buffer length if necessary
            if (_calcHeader.DataCount != _valuesBufferCalc.Length)
            {
                _valuesBufferCalc = new float[_calcHeader.DataCount];
            }

            Marshal.Copy(data, _valuesBufferCalc, 0, (int)_calcHeader.DataCount);

            if (sockRef == this.sockTCPRef)
            {
                if (mainwindow.InvokeRequired)
                {
                    try
                    {
                        a = mainwindow.BeginInvoke((MethodInvoker)delegate
                        {
                            UpdateCalcDataUI(_valuesBufferCalc);
                        });
                        mainwindow.EndInvoke(a);
                    }
                    catch (InvalidOperationException ex)    // pump died before we were processed
                    {
                        if (mainwindow.IsHandleCreated) throw;    // not the droids we are looking for
                    }
                }
                else
                {
                    UpdateCalcDataUI(_valuesBufferCalc);
                }
            }
        }

        public delegate void InvokeDelegate(float[] bvhData, bool withDisp);
        IAsyncResult a;

        private void socketStatusChanged(IntPtr customObject, IntPtr sockRef, SocketStatus status, [MarshalAs(UnmanagedType.LPStr)]string msg)
        {
            mainwindow.Invoke(new Action(delegate()
            {
                //txtSockLog.Text = msg;
            }));
        }
        
        public void btnConnect_Click(object sender, EventArgs e)
        {
            if (NeuronDataReader.BRGetSocketStatus(sockTCPRef) == SocketStatus.CS_Running)
            {
                NeuronDataReader.BRCloseSocket(sockTCPRef);
                sockTCPRef = IntPtr.Zero;

                mainwindow.btnConnect.Text = "Connect";
               
                _frameCount = 0;
                isCountable = true;
                mainwindow.panelClassification.Visible = false;
                mainwindow.panelUserLabeling.Visible = false;
                isTimingDecision = false;
            }
            else
            {
                sockTCPRef = NeuronDataReader.BRConnectTo(mainwindow.txtIP.Text, int.Parse(mainwindow.txtPort.Text));
                if (sockTCPRef == IntPtr.Zero)
                {
                    string msg = NeuronDataReader.strBRGetLastErrorMessage();
                    MessageBox.Show(msg, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mainwindow.btnConnect.Text = "Disconnect";

                _frameCount = 0;
                isCountable = true;
                mainwindow.panelClassification.Visible = false;
                mainwindow.panelUserLabeling.Visible = false;
                isTimingDecision = false;
            }
        }

    }
}
