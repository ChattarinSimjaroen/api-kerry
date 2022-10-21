using Test.Models;
using Test.Repositoris.Interfaces;
using Test.Services.Interfaces;

namespace Test.Services.Imprements
{
    public class ShopService : IShopService
    {
        private readonly IBaseRepository baseRepository;

        public ShopService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public bool favoriteBook(int userId, int bookId)
        {
            string queryString = $@"INSERT INTO [dbo].[User_Book_Mapping] ([User_ID], [Book_ID]) VALUES ({userId}, {bookId})";

            var result = baseRepository.ExecuteString<int>(queryString);

            if (result != 0)
                return true;
            else
                return false;
        }

        public List<BookModel> FindAllBook()
        {
            string sql2 = $@"SELECT b.Book_ID, b.Title, b.Price, b.SubTitle, b.Image, COUNT(ubm.Book_ID) as Favorite 
                             FROM [Kerry].[dbo].[Book] as b
                             LEFT JOIN User_Book_Mapping as ubm ON b.Book_ID = ubm.Book_ID
                             GROUP BY b.Book_ID, b.Title, b.Price, b.SubTitle, b.Image
                             ORDER BY b.Title ASC";

            var books = baseRepository.QueryString<BookModel>(sql2).ToList();

            return books;
        }
    }
}
