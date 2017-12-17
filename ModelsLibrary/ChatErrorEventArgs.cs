using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class ChatErrorEventArgs : EventArgs
    {
        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public ChatErrorEventArgs(string error)
        {
            _error = error;
        }//c-tor
    }//ChatErrorEventArgs
}
