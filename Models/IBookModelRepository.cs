using BookStoreAPIproj.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPIproj.Models
{
    public interface IBookModelRepository
    {

        public Task<List<BookModel>> GetallBooksasync();
        public Task<BookModel> GetallBookByIdsasync(int id);
        public Task<BookModel> AddBookasync(BookModel book);
        //public Task<BookModel> DeleteBookasync(int id);
        public Task<BookModel> UpdateBookasync(int id , BookModel book);





    }
}