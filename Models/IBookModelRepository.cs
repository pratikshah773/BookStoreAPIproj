using BookStoreAPIproj.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPIproj.Models
{
    public interface IBookModelRepository
    {

        public Task<List<BookModel>> GetallBooksasync();
        public Task<BookModel> GetallBookByIdsasync(int id);


    }
}