using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services.Interfaces;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopService shopService;
        public ShopController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        // GET: api/shop/books
        [HttpGet("books")]
        public IActionResult FindAllBook()
        {
            try
            {
                var data = shopService.FindAllBook();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }

        // POST: api/shop/favorite
        [HttpPost("favorite")]
        public IActionResult FavoriteBook([FromBody] UserBook userBook)
        {
            try
            {
                var data = shopService.favoriteBook(userBook.userId, userBook.bookId);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }
    }
}
