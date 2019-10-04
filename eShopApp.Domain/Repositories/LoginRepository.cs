using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace eShopApp.Domain.Repositories
{
    public class LoginRepository : IloginRepository
    {
        private readonly ProductDbContext _productDb;
        public LoginRepository(ProductDbContext productDb)
        {
            _productDb = productDb;
        }

        public string[] Login(LoginViewModel login)
        {
            Customer customer = _productDb.Customers.SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (customer == null)
                return new string[] { };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                  {
                        new Claim("Id",customer.CusId.ToString()),

                        new Claim(ClaimTypes.Role,customer.role)
                  }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new string[] { token, customer.FirstName, customer.role, customer.CusId.ToString() };         
        }
    }
}
