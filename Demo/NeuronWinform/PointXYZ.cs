using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NeuronWinform
{
    public class PointXYZ : INotifyPropertyChanged
    {
        private double px;
        public double Px
        {
            get { return px; }
            set { px = value; OnPropertyChanged("Px"); }
        }
        private double py;
        public double Py
        {
            get { return py; }
            set { py = value; OnPropertyChanged("Py"); }
        }
        private double pz;
        public double Pz
        {
            get { return pz; }
            set { pz = value; OnPropertyChanged("Pz"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
