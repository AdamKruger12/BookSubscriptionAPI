using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Handles operations related to books.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    /// <summary>
    /// Initializes a new instance of the <see cref="BooksController"/> class.
    /// </summary>
    /// <param name="bookService"></param>
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>A list of books.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    /// <summary>
    /// Adds a new book.
    /// </summary>
    /// <param name="bookDto">The book details.</param>
    /// <returns>The created book.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
    {
        var book = await _bookService.AddBookAsync(bookDto);
        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }

    /// <summary>
    /// Deletes a book by ID.
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <returns>No content.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(string id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
