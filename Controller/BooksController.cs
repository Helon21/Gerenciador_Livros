using Microsoft.AspNetCore.Mvc;
using SecondAPI.Model;
using SecondAPI.service;

namespace SecondAPI.Controller;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class BooksController(IBooksService booksService) : ControllerBase
{

    /// <summary>
    /// Busca todos os livros
    /// </summary>
    /// <returns>Os livros criados são retornados</returns>
    /// <response code="200">Retorna a lista de livros</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Books))]
    public async Task<ActionResult<IEnumerable<Books>>> GetAllBooks()
    {
        var books = await booksService.GetAllBooksAsync();
        return Ok(books);
    }

    /// <summary>
    /// Busca um livro pelo ID
    /// </summary>
    /// <param name="id">Id do livro a ser encontrado</param>
    /// <returns>Encontra o livro pelo ID</returns>
    /// <response code="200">Retorna o livro encontrado</response>
    /// <response code="404">Se o livro não for encontrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Books))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Books>> GetBookById(int id)
    {
        var book = await booksService.GetBookByIdAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    /// <summary>
    /// Cria um novo livro
    /// </summary>
    /// <param name="newBook">Objeto livro a ser criado, vindo do corpo da requisição</param>
    /// <returns>Retorna o livro a ser criado, encontrado pelo seu ID</returns>
    /// <response code="201">Retorna o livro criado</response>
    /// <response code="400">Se o livro for nulo</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Books))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Books>> CreateBook(Books newBook)
    {
        var createdBook = await booksService.CreateBookAsync(newBook);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    /// <summary>
    /// Atualiza um livro já existente através do ID
    /// </summary>
    /// <param name="id">Id do livro a ser procurado para ser atualizado</param>
    /// <param name="updatedBook">Objeto do livro a ser alterado, vindo do corpo da requisição</param>
    /// <response code="204">Se o livro for atualizado com sucesso</response>
    /// <response code="404">Se o livro não for encontrado</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook(int id, Books updatedBook)
    {
        var updateBook = await booksService.UpdateBookAsync(id, updatedBook);
        return updateBook ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deleta um livro existente através do ID
    /// </summary>
    /// <param name="id">Id do livro a ser procurado para remoção</param>
    /// <response code="204">Se o livro for deletado com sucesso</response>
    /// <response code="404">Se o livro não for encontrado</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleteBook = await booksService.DeleteBookAsync(id);
        return deleteBook ? NoContent() : NotFound();
    }
}