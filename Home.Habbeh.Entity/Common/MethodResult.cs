using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity.Common
{
    public class MethodResult
    {
        public MethodResult()
        {

        }
        public MethodResult(bool hasError, string msg, object data)
        {
            HasError = hasError;
            Message = msg;
            Data = data;
        }
        public bool HasError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class MethodResult<T>
    {
        public MethodResult()
        {

        }

        public MethodResult(bool hasError, string msg, List<T> data)
        {
            HasError = hasError;
            Message = msg;
            Data = data;
        }
        public bool HasError { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
