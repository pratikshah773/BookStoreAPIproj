using BookStoreAPIproj.Data;
using BookStoreAPIproj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookStoreAPIproj.Repository
{
    public class BookRepository : IBookModelRepository
    {
        private readonly BookstoreContext _bookstoreContext;

        public BookRepository(BookstoreContext bookstoreContext)
        {
            _bookstoreContext = bookstoreContext;
        }

        public async  Task<BookModel> GetallBookByIdsasync(int Id)
        {
            var book =  await _bookstoreContext.Books.Where(x => x.ID == Id).FirstOrDefaultAsync();  /*.Select(x => new BookModel()*/


           var bookmodel = new BookModel
            {
                Name = book.Name,
                BookID = book.ID,
                Description = book.Description
                  
            };


            return  bookmodel;
          

        }

          public async Task<List<BookModel>> GetallBooksasync()
          {  
            /// we got Books data type from DB , now converting to BookModel Type to return to Controller
                var Books = await _bookstoreContext.Books.Select((x) => new BookModel()
                {
                    BookID = x.ID,
                    Name = x.Name,
                    Description = x.Description

                }).ToListAsync();

            return Books;

          }
        
    }
}