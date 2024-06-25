using Book.Models;

namespace Book.Repository
{
    public interface IBookRepository
    {
        Task<List<Models.Book>> GetAll();
        Models.Book GetById(int bookId);
        void AddBook(Models.Book book);
        void EditBook(Models.Book book , int bookId);
        void DeleteBook(int bookId);

        bool BookExists(int bookId);

        void Save();

    }
}
