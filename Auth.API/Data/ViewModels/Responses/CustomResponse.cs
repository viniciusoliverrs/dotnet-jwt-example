using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Data.ViewModels.Responses
{
    public class CustomResponse
    {
        public string Message { get; set; }
        public dynamic? Data { get; set; }

        public CustomResponse(string message, dynamic? data=null)
        {
            Message = message;
            Data = data;
        }
    }
}