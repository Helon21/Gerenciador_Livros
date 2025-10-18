using SecondAPI.Model;

namespace SecondAPI.service;

public interface IBooksService
{
    Task<IEnumerable<Books>> GetAllBooksAsync();
    Task<Books?> GetBookByIdAsync(int id);
    Task<Books> CreateBookAsync(Books newBook);
    Task<bool> UpdateBookAsync(int id, Books updatedBook);
    Task<bool> DeleteBookAsync(int id);
}