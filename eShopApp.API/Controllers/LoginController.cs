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
        private readonly IloginRepository _ilogin;
        public LoginController(IloginRepository ilogin)
        {
            _ilogin = ilogin;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel login)
        {
            var token = _ilogin.Login(login);
            return Ok(token);
        }
    }
}
