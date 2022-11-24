using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_prac.Data;
using dotnet_prac.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_prac.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly iAuthRepository _authRepo;

        public AuthController(iAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> RegisterUser(UserRegisterDto request){
            var response = await _authRepo.Register(
                new User { UserName = request.UserName}, request.password
            );

            if(!response.success){
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<User>>> deleteUser(string username){
            var response = await _authRepo.DeleteUser(username);
            if(response.Data == null){
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}