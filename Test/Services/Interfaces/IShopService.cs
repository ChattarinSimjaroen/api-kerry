using Test.Models;

namespace Test.Services.Interfaces
{
    public interface IShopService
    {
        List<BookModel> FindAllBook();

        bool favoriteBook(int userId, int bookId);

    }
}
