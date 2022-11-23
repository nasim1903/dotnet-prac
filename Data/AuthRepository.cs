using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_prac.Data
{
    public class AuthRepository : iAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if(await UserExist(user.UserName)){
                response.success = false;
                response.Message = "This user already exists";
            }

            CreateHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.id;
            return response;
        }

        public async Task<bool> UserExist(string username)
        {
            if(await _context.Users.AnyAsync(c => c.UserName.ToLower() == username.ToLower())){
                return true;
            }
            return false;
        }
        private void CreateHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}