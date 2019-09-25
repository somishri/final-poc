using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Domain.Repositories.Interfaces
{
    public interface IloginRepository
    {
        int Login(LoginViewModel login);
    }
}
