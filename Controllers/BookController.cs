using FirstProject.Model;
using FirstProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController: ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete != null)
                await _bookRepository.Delete(bookToDelete.Id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> PutBook(int id, [FromBody] Book book)
        {
            if(book.Id == id)
                await _bookRepository.Update(book);
            return Ok();
        }

    }
}
