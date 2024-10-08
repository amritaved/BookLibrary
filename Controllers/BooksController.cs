using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    /// <summary>
    /// Controller for managing Books.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// GET: api/Books : Get all Books.
        /// </summary>
        /// <returns>List of Books.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _repository.GetAllBooks();
            return Ok(books);
        }

        /// <summary>
        /// GET: api/Books/1 : Get a specific Book by ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <returns>Book details if found, otherwise returns NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// POST: api/Books : Create a new Book.
        /// </summary>
        /// <param name="book">Book details for creation.</param>
        /// <returns>Created Book details.</returns>
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _repository.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        /// <summary>
        /// PUT: api/Books/1 : Update an existing Book.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <param name="book">Updated Book details.</param>
        /// <returns>NoContent if successful, BadRequest if the Book is not found.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            await _repository.UpdateBook(book);
            return NoContent();
        }

        /// <summary>
        /// DELETE: api/Books/1 : Delete a Book by ID.
        /// </summary>
        /// <param name="id">Book ID.</param>
        /// <returns>NoContent if successful</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _repository.DeleteBook(id);
            return NoContent();
        }
    }
}
