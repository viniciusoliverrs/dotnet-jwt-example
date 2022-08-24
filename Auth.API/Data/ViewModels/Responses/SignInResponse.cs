using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Data.ViewModels.Responses
{
    public class SignInResponse
    {
        public string Token { get; set; }
        public SignInResponse(string token)
        {
            Token = token;
        }
    }
}