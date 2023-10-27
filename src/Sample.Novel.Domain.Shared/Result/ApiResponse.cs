using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Shared.Result
{
    public class ApiResponse
    {
        public StatusCode Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
        public bool Successful { get; set; }

        public static ApiResponse OK(object data)
        {
            return new ApiResponse { Status = StatusCode.Success, Msg = string.Empty, Successful = true, Data = data };
        }
        public static ApiResponse Error(string msg, StatusCode status= StatusCode.ThrowError)
        {
            return new ApiResponse { Status = status, Msg = msg };
        }

    }
}
