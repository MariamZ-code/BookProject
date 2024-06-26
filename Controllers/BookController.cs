using Book.Repository;
using BookProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Book.Models;

namespace BookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        #region GetAllBooks
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks(int startPage = 1, int pageSize = 10)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = await bookRepo.GetAll();

            var bookList = new List<GetBooks>();
            foreach (var book in books)
            {
                var bookDto = new GetBooks
                {
                    Id = book.Id,
                    Author = book.Author,
                    Description = book.Description,
                    Genre = book.Genre,
                    PublishedDate = book.PublishedDate,
                    Title = book.Title,
                };
                bookList.Add(bookDto);
            }

            var totalBook = bookList.Count();
            bookList = bookList.Skip((startPage - 1) * pageSize).Take(pageSize).ToList();
            var bookResult = new
            {

                TotalCount = totalBook,
                PageNumber = startPage,
                PageSize = pageSize,
                Requests = bookList,
            };

            return Ok(bookResult);

        }
        #endregion

        #region GetBookById
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookExists = bookRepo.BookExists(bookId);

            if (!bookExists)
                return NotFound(new MessageDto { Message = "Sorry , Book not found" });

            var book =  bookRepo.GetById(bookId);

            var bookDto = new GetBooks
            {
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                PublishedDate = book.PublishedDate,
                Title = book.Title,
            };

            return Ok(bookDto);

        }
        #endregion


        #region AddBook
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(Book.Models.Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            bookRepo.AddBook(book);
            bookRepo.Save();
            return Ok(new MessageDto { Message = "Added" });
        }
        #endregion

        #region EditBook
        [HttpPut("EditBook")]
        public async Task<IActionResult> EditBook(int Id , Book.Models.Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookExists = bookRepo.BookExists(Id);

            if (!bookExists)
                return NotFound(new MessageDto { Message = "Sorry , Book not found" });

            bookRepo.EditBook(book, Id);
            bookRepo.Save();

            return Ok(new MessageDto { Message = "Updated" });
        }
        #endregion

        #region DeleteBook

        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookExists = bookRepo.BookExists(bookId);

            if (!bookExists)
                return NotFound(new MessageDto { Message = "Sorry , Book not found" });

            bookRepo.DeleteBook(bookId);
            bookRepo.Save();

            return Ok(new MessageDto { Message="Deleted"});
        }
        #endregion

    }
}
