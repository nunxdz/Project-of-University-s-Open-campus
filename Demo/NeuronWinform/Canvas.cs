using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace NeuronWinform
{
    public partial class Canvas : UserControl
    {
        public List<Point> sequence;

        private List<DataModel> list = new List<DataModel>();
        Hashtable table = new Hashtable();
        private DataModel model = new DataModel();

        private Neuron neuron;
        public Neuron Neuron
        {
            get { return neuron; }
            set 
            { 
                neuron = value; 
                if(neuron != null)
                    neuron.RaiseCustomEvent += HandleCustomEvent;
            }
        }

        public Canvas()
        {
            InitializeComponent();

            sequence = new List<Point>();
            this.DoubleBuffered = true;

            if (neuron != null)
                neuron.RaiseCustomEvent += HandleCustomEvent;
        }

        void HandleCustomEvent(object sender, Event e)
        {
            list = e.Msg;
            table = e.Hash;
            this.Refresh();
        }

        public Point[] GetSequence()
        {
            return sequence.ToArray();
        }


        public void Clear()
        {
            sequence.Clear();
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (table.Count == 0) return;

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

            Pen mypen = new Pen(System.Drawing.Color.Black);

            int width = 5, height = 5;

            #region  Calculate DATA
            /* for calculate DATA*/
            //Rectangle myRectangle0 = new Rectangle();
            //model = (DataModel)table[0];
            //myRectangle0.X = Convert.ToInt32(model.Px);
            //myRectangle0.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);


            //Rectangle myRectangle1 = new Rectangle();
            //model = (DataModel)table[19];
            //myRectangle1.X = Convert.ToInt32(model.Px);
            //myRectangle1.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle0.X, myRectangle0.Y, myRectangle1.X, myRectangle1.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle2 = new Rectangle();
            //model = (DataModel)table[15];
            //myRectangle2.X = Convert.ToInt32(model.Px);
            //myRectangle2.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle2.X, myRectangle2.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle3 = new Rectangle();
            //model = (DataModel)table[11];
            //myRectangle3.X = Convert.ToInt32(model.Px);
            //myRectangle3.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle3.X, myRectangle3.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle4 = new Rectangle();
            //model = (DataModel)table[12];
            //myRectangle4.X = Convert.ToInt32(model.Px);
            //myRectangle4.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle3.X, myRectangle3.Y, myRectangle4.X, myRectangle4.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle5 = new Rectangle();
            //model = (DataModel)table[13];
            //myRectangle5.X = Convert.ToInt32(model.Px);
            //myRectangle5.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle4.X, myRectangle4.Y, myRectangle5.X, myRectangle5.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle6 = new Rectangle();
            //model = (DataModel)table[14];
            //myRectangle6.X = Convert.ToInt32(model.Px);
            //myRectangle6.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle5.X, myRectangle5.Y, myRectangle6.X, myRectangle6.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle7 = new Rectangle();
            //model = (DataModel)table[7];
            //myRectangle7.X = Convert.ToInt32(model.Px);
            //myRectangle7.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle7.X, myRectangle7.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle8 = new Rectangle();
            //model = (DataModel)table[8];
            //myRectangle8.X = Convert.ToInt32(model.Px);
            //myRectangle8.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle7.X, myRectangle7.Y, myRectangle8.X, myRectangle8.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle9 = new Rectangle();
            //model = (DataModel)table[9];
            //myRectangle9.X = Convert.ToInt32(model.Px);
            //myRectangle9.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle8.X, myRectangle8.Y, myRectangle9.X, myRectangle9.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle10 = new Rectangle();
            //model = (DataModel)table[10];
            //myRectangle10.X = Convert.ToInt32(model.Px);
            //myRectangle10.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle9.X, myRectangle9.Y, myRectangle10.X, myRectangle10.Y);//(pen,x1,y1,x2,y2)


            //Rectangle myRectangle0 = new Rectangle();
            //model = (DataModel)table[0];
            //myRectangle0.X = Convert.ToInt32(model.Px);
            //myRectangle0.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush,model.Px,model.Py,width,height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);


            //Rectangle myRectangle1 = new Rectangle();
            //model = (DataModel)table[12];
            //myRectangle1.X = Convert.ToInt32(model.Px);
            //myRectangle1.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle0.X, myRectangle0.Y, myRectangle1.X, myRectangle1.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle2 = new Rectangle();
            //model = (DataModel)table[13];
            //myRectangle2.X = Convert.ToInt32(model.Px);
            //myRectangle2.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle2.X, myRectangle2.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle3 = new Rectangle();
            //model = (DataModel)table[14];
            //myRectangle3.X = Convert.ToInt32(model.Px);
            //myRectangle3.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle3.X, myRectangle3.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle4 = new Rectangle();
            //model = (DataModel)table[15];
            //myRectangle4.X = Convert.ToInt32(model.Px);
            //myRectangle4.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle3.X, myRectangle3.Y, myRectangle4.X, myRectangle4.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle5 = new Rectangle();
            //model = (DataModel)table[16];
            //myRectangle5.X = Convert.ToInt32(model.Px);
            //myRectangle5.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle4.X, myRectangle4.Y, myRectangle5.X, myRectangle5.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle6 = new Rectangle();
            //model = (DataModel)table[17];
            //myRectangle6.X = Convert.ToInt32(model.Px);
            //myRectangle6.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle5.X, myRectangle5.Y, myRectangle6.X, myRectangle6.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle7 = new Rectangle();
            //model = (DataModel)table[37];
            //myRectangle7.X = Convert.ToInt32(model.Px);
            //myRectangle7.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle7.X, myRectangle7.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle8 = new Rectangle();
            //model = (DataModel)table[38];
            //myRectangle8.X = Convert.ToInt32(model.Px);
            //myRectangle8.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle7.X, myRectangle7.Y, myRectangle8.X, myRectangle8.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle9 = new Rectangle();
            //model = (DataModel)table[39];
            //myRectangle9.X = Convert.ToInt32(model.Px);
            //myRectangle9.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle8.X, myRectangle8.Y, myRectangle9.X, myRectangle9.Y);//(pen,x1,y1,x2,y2)

            //Rectangle myRectangle10 = new Rectangle();
            //model = (DataModel)table[40];
            //myRectangle10.X = Convert.ToInt32(model.Px);
            //myRectangle10.Y = Convert.ToInt32(model.Py);

            //e.Graphics.FillEllipse(myBrush, model.Px, model.Py, width, height);
            //e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, model.Px, model.Py);

            //e.Graphics.DrawLine(mypen, myRectangle9.X, myRectangle9.Y, myRectangle10.X, myRectangle10.Y);//(pen,x1,y1,x2,y2)
            #endregion

            Rectangle myRectangle0 = new Rectangle();
            model = (DataModel)table[0];
            myRectangle0.X = Convert.ToInt32(model.Px);
            myRectangle0.Y = Convert.ToInt32(model.Py);
            myRectangle0.Width = 5;
            myRectangle0.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle0);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle0.X, myRectangle0.Y);


            Rectangle myRectangle1 = new Rectangle();
            model = (DataModel)table[18];
            myRectangle1.X = Convert.ToInt32(model.Px);
            myRectangle1.Y = Convert.ToInt32(model.Py);
            myRectangle1.Width = 5;
            myRectangle1.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle1);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle1.X, myRectangle1.Y);
            e.Graphics.DrawLine(mypen, myRectangle0.X, myRectangle0.Y, myRectangle1.X, myRectangle1.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle2 = new Rectangle();
            model = (DataModel)table[15];
            myRectangle2.X = Convert.ToInt32(model.Px);
            myRectangle2.Y = Convert.ToInt32(model.Py);
            myRectangle2.Width = 5;
            myRectangle2.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle2);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle2.X, myRectangle2.Y);
            e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle2.X, myRectangle2.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle3 = new Rectangle();
            model = (DataModel)table[11];
            myRectangle3.X = Convert.ToInt32(model.Px);
            myRectangle3.Y = Convert.ToInt32(model.Py);
            myRectangle3.Width = 5;
            myRectangle3.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle3);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle3.X, myRectangle3.Y);
            e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle3.X, myRectangle3.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle4 = new Rectangle();
            model = (DataModel)table[12];
            myRectangle4.X = Convert.ToInt32(model.Px);
            myRectangle4.Y = Convert.ToInt32(model.Py);
            myRectangle4.Width = 5;
            myRectangle4.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle4);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle4.X, myRectangle4.Y);
            e.Graphics.DrawLine(mypen, myRectangle3.X, myRectangle3.Y, myRectangle4.X, myRectangle4.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle5 = new Rectangle();
            model = (DataModel)table[13];
            myRectangle5.X = Convert.ToInt32(model.Px);
            myRectangle5.Y = Convert.ToInt32(model.Py);
            myRectangle5.Width = 5;
            myRectangle5.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle5);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle5.X, myRectangle5.Y);
            e.Graphics.DrawLine(mypen, myRectangle4.X, myRectangle4.Y, myRectangle5.X, myRectangle5.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle6 = new Rectangle();
            model = (DataModel)table[14];
            myRectangle6.X = Convert.ToInt32(model.Px);
            myRectangle6.Y = Convert.ToInt32(model.Py);
            myRectangle6.Width = 5;
            myRectangle6.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle6);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle6.X, myRectangle6.Y);
            e.Graphics.DrawLine(mypen, myRectangle5.X, myRectangle5.Y, myRectangle6.X, myRectangle6.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle7 = new Rectangle();
            model = (DataModel)table[7];
            myRectangle7.X = Convert.ToInt32(model.Px);
            myRectangle7.Y = Convert.ToInt32(model.Py);
            myRectangle7.Width = 5;
            myRectangle7.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle7);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle7.X, myRectangle7.Y);
            e.Graphics.DrawLine(mypen, myRectangle1.X, myRectangle1.Y, myRectangle7.X, myRectangle7.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle8 = new Rectangle();
            model = (DataModel)table[8];
            myRectangle8.X = Convert.ToInt32(model.Px);
            myRectangle8.Y = Convert.ToInt32(model.Py);
            myRectangle8.Width = 5;
            myRectangle8.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle8);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle8.X, myRectangle8.Y);
            e.Graphics.DrawLine(mypen, myRectangle7.X, myRectangle7.Y, myRectangle8.X, myRectangle8.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle9 = new Rectangle();
            model = (DataModel)table[9];
            myRectangle9.X = Convert.ToInt32(model.Px);
            myRectangle9.Y = Convert.ToInt32(model.Py);
            myRectangle9.Width = 5;
            myRectangle9.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle9);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle9.X, myRectangle9.Y);
            e.Graphics.DrawLine(mypen, myRectangle8.X, myRectangle8.Y, myRectangle9.X, myRectangle9.Y);//(pen,x1,y1,x2,y2)

            Rectangle myRectangle10 = new Rectangle();
            model = (DataModel)table[10];
            myRectangle10.X = Convert.ToInt32(model.Px);
            myRectangle10.Y = Convert.ToInt32(model.Py);
            myRectangle10.Width = 5;
            myRectangle10.Height = 5;
            e.Graphics.FillEllipse(myBrush, myRectangle10);
            e.Graphics.DrawString(model.BoneID.ToString(), drawFont, drawBrush, myRectangle10.X, myRectangle10.Y);
            e.Graphics.DrawLine(mypen, myRectangle9.X, myRectangle9.Y, myRectangle10.X, myRectangle10.Y);//(pen,x1,y1,x2,y2)

            //if (Neuron.mainwindow.IsCapture)
            //{
            //    for (int i = 0; i < Neuron.useBoneCal.Length; i++)
            //    {
            //        model = (DataModel)table[Neuron.useBoneCal[i]];
            //        sequence.Add(new Point(Convert.ToInt32(model.Px), Convert.ToInt32(model.Py)));
            //    }
            //    Neuron.mainwindow.IsCapture = false;
            //}

            this.Invalidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

        }
    }
}
