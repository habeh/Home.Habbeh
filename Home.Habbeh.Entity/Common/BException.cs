using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity.Common
{
    public class HabbeException : ApplicationException
    {
        private string message;
        public HabbeException(string message)
            : base(message)
        {
            this.message = message;
        }

        public new string ToString()
        {
            return message;
        }

        public override string StackTrace
        {
            get
            {
                return "";
            }
        }
        public override string Message
        {
            get
            {
                return "";
            }
        }
    }
}
