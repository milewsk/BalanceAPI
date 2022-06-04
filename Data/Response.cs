using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Data
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }

        public object ReturnData { get; set; }

        public Response(string message, int status)
        {
            Message = message;
            Status = status;

        }
        public Response(string message, int status, object data)
        {
            Message = message;
            Status = status;
            ReturnData = data;
        }
    }
}
