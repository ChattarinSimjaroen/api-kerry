using Test.Models;

namespace Test.Services.Interfaces
{
    public interface IAccountService
    {
        ResponseUser LogIn(InputFromLogin inputFromLogin);
        bool Register(UserModel userModel);
    }
}
