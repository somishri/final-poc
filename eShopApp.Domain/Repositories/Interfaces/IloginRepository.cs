using eShopApp.Models;

namespace eShopApp.Domain.Repositories.Interfaces
{
    public interface IloginRepository
    {
        string[] Login(LoginViewModel login);
    }
}
