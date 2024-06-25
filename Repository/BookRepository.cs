using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GetAll
        public async Task<List<Models.Book>> GetAll() => await dbContext.Books.AsNoTracking().ToListAsync();

        #endregion

        #region GetbyId
        public  Models.Book GetById(int bookId) => dbContext.Books.FirstOrDefault(b => b.Id == bookId);

        #endregion

        #region AddBook
        public async void AddBook(Models.Book book) => await dbContext.AddAsync(book);


        #endregion

        #region EditBook
        public async void EditBook(Models.Book book, int bookId)
        {
            var oldBook = GetById(bookId);
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.Author = book.Author;
            oldBook.Genre = book.Genre;
            oldBook.PublishedDate = book.PublishedDate;

        }
        #endregion

        #region DeleteBook
        public async void DeleteBook(int bookId)
        {
            var book = GetById(bookId);
            dbContext.Remove(book);
        }

        #endregion

        #region BookExists
        public bool BookExists(int bookId) =>
             dbContext.Books.Any(b => b.Id == bookId);

        #endregion

        #region Save
        public void Save() => dbContext.SaveChanges();  
        #endregion
    }
}
