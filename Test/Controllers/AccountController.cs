using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services.Interfaces;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: api/shop/books
        [HttpPost("login")]
        public IActionResult Login([FromBody] InputFromLogin inputFromLogin)
        {
            try
            {
                var data = accountService.LogIn(inputFromLogin);

                if(data == null)
                {
                    throw new Exception("Email or Password incorect");
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // POST: api/shop/favorite
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel userModel)
        {
            try
            {
                var data = accountService.Register(userModel);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }
    }
}
