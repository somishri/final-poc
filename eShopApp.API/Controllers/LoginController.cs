using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eShopApp.Domain.Data;
using eShopApp.Domain.Repositories.Interfaces;
using eShopApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ProductDbContext _productDb;
       
        private readonly IloginRepository _ilogin;
        public LoginController(IloginRepository ilogin,ProductDbContext productDb)
        {
            _ilogin = ilogin;
            _productDb = productDb;
        }
       
     

      

        // POST: api/Login
        [HttpPost]
        public ActionResult Post([FromBody] LoginViewModel login)
        {
                int flag = _ilogin.Login(login);
                if(flag==1)
            {
                Customer customer = _productDb.Customers.Single(x => x.Email == login.Email);
                //Customer _customer = _productDb.Customers.Single(x => x.FirstName == login.FirstName);
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim("Id",customer.CusId.ToString()),
                        //new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                        new Claim(ClaimTypes.Role,customer.role)
                   }),
                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token,customer.FirstName,customer.role });
                
                
            }
                else
            {
                return null;
            }
           
        }

       
       
    }
}
