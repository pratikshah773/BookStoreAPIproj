using BookStoreAPIproj.Models;
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
    }
}
