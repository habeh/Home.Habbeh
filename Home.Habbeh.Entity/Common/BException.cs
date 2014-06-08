using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity.Common
{
    public class HabbeException : ApplicationException
    {
        public HabbeException(string message)
            : base(message)
        {

        }
    }
}
