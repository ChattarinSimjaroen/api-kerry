using System.Net;
using Test.Models;
using Test.Repositoris.Interfaces;
using Test.Services.Interfaces;

namespace Test.Services.Imprements
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository baseRepository;

        public AccountService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public ResponseUser LogIn(InputFromLogin inputFromLogin)
        {
            string queryString = $@"SELECT u.Email, u.Name, u.LastName FROM [dbo].[User] as u
                                    WHERE u.Email = '{inputFromLogin.email}' AND u.Password = '{inputFromLogin.password}'";

            var result = baseRepository.QueryString<UserModel>(queryString).FirstOrDefault();

            if (result != null)
            {
                var user = new ResponseUser();
                user.name = result.Name.Trim() + ' ' + result.LastName.Trim();
                user.email = result.Email.Trim();

                return user;
            }
            else
                return null;
        }

        public bool Register(UserModel userModel)
        {
            string queryString = $@"INSERT INTO [dbo].[User] ([Email], [Password], [Name], [LastName]) 
                                    VALUES ('{userModel.Email}', '{userModel.Password}', '{userModel.Name}', '{userModel.LastName}')";

            var result = baseRepository.ExecuteString<int>(queryString);

            if (result != 0)
                return true;
            else
                return false;
        }
    }
}
