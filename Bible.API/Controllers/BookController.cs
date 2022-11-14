using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.BookServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class BookController : BaseController<IBookService>
    {
        public BookController(IBookService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            var books = await _service.GetAllAsync();
            return GetResponse(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return GetResponse(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookQuery book)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(book, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("book not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(BookQuery book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(book);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            int result = await _service.DeleteAsync(id);
            if (result == 0)
            {
                return GetResponseError("Delete failed");
            }
            return GetResponse(result);
        }
    }
}
