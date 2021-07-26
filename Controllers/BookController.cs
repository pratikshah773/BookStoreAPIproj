using BookStoreAPIproj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPIproj.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookModelRepository _bookModelRepository;

        public BookController(IBookModelRepository bookModel)
        {
            _bookModelRepository = bookModel;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var Books = await _bookModelRepository.GetallBooksasync();

            if (Books == null)
            {
                return NotFound();
            }

            return Ok(Books);

        }

        [HttpGet]
        [Route("{ID}")]  /*Appending to base route [Route("[controller]/[action]")]  match will be http ://port/Books/GetBookBYID/1    */
        // [  [Route("~Get book/{ID}")]]  over-riding base controller level route " [Route("[controller]/[action]")]  and this base route  will not work now " 
        public async Task<IActionResult> GetBookByID([FromRoute] int ID)
        {
            var Books = await _bookModelRepository.GetallBookByIdsasync(ID);

            if (Books == null)
            {
                return NotFound();
            }

            return Ok(Books);

        }


        //Add new book

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookModel book)
        {
            try
            {
                var NewlyCreatedBook = await _bookModelRepository.AddBookasync(book);   //returns the updated BookModel Table from DB

                if (NewlyCreatedBook == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetBookByID), new { ID = NewlyCreatedBook.BookID }, NewlyCreatedBook);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error While receiving from database");
            }
        }


        //Update a book


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel book, [FromRoute] int id)
        {
            try
            {
                var NewlyCreatedBook = await _bookModelRepository.UpdateBookasync(id, book);   //returns the newly updated BookModel from DB

                if (NewlyCreatedBook == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetBookByID), new { ID = NewlyCreatedBook.BookID }, NewlyCreatedBook);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error While receiving from database");
            }

        }

             


        
    }
}
