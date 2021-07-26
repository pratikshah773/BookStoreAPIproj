using BookStoreAPIproj.Data;
using BookStoreAPIproj.Models;
using Microsoft.EntityFrameworkCore;
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



        //Get All Books 
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

        



        
        public  async  Task<BookModel> AddBookasync(BookModel book) 
        {


            var Book = new Books()
            {
                Name = book.Name,
                Description = book.Description,
                ID = book.BookID

            };

            

            _bookstoreContext.Add(Book);
             var id= await _bookstoreContext.SaveChangesAsync();
            book.BookID = id;
            return   book; // Returning book id after syncing with updated DB record 
            
                    
        
        }
        //public Task<BookModel> DeleteBookasync(int id) { };
        public async Task<BookModel> UpdateBookasync (int Id, BookModel book) 
        
       {
           var bookToUpdate= await _bookstoreContext.Books.FindAsync(Id);

            if (bookToUpdate != null) 
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.Description = book.Description;
                bookToUpdate.ID = Id;

                await _bookstoreContext.SaveChangesAsync();

            };
            book.BookID = Id;
                
             
            return book;

        }




    }
}