using Microsoft.EntityFrameworkCore;
using SecondAPI.Model;

namespace SecondAPI.service;

public class BooksService(ApplicationDbContext context) : IBooksService
{
    public async Task<IEnumerable<Books>> GetAllBooksAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Books?> GetBookByIdAsync(int id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task<Books> CreateBookAsync(Books newBook)
    {
        context.Books.Add(newBook);
        await context.SaveChangesAsync();
        return newBook;
    }

    public async Task<bool> UpdateBookAsync(int id, Books updatedBook)
    {
        var originalBook = await context.Books.FindAsync(id);

        if (originalBook is null)
        {
            return false;
        }

        originalBook.Title = updatedBook.Title;
        originalBook.Author = updatedBook.Author;
        originalBook.YearPublished = updatedBook.YearPublished;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var bookToDelete = await context.Books.FindAsync(id);

        if (bookToDelete is null)
        {
            return false;
        }

        context.Books.Remove(bookToDelete);
        await context.SaveChangesAsync();
        return true;
    }
}