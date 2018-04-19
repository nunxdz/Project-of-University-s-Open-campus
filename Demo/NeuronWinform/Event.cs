using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuronWinform
{
    public class Event : EventArgs
    {
        public Event(List<DataModel> d)
        {
            Msg = d;
        }
        public Event(Hashtable h)
        {
            Hash = h;
        }
        private List<DataModel> msg;
        public List<DataModel> Msg
        {
          get { return msg; }
          set { msg = value; }
        }

        private Hashtable hash;
        public Hashtable Hash
        {
            get { return hash; }
            set { hash = value; }
        }
    }
}
