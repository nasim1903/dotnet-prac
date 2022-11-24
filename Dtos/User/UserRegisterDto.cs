using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_prac.Dtos.User
{
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}