using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPINet6.Model;
using MyWebAPINet6.Repositories;

namespace MyWebAPINet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductsController(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookAsync(id);
            return book == null? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(model);
                var book = await _bookRepo.GetBookAsync(newBookId);
                return book == null ? NotFound() : Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            
            await _bookRepo.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return Ok();
        }
    }
}
