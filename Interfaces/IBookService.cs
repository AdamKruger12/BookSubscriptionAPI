using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Interfaces
{
    /// <summary>
    /// Defines the operations related to books.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="bookDto">The book details to be added.</param>
        /// <returns>The created book.</returns>
        Task<Book> AddBookAsync(BookDto bookDto);

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        Task DeleteBookAsync(string id);

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A list of all books.</returns>
        Task<List<Book>> GetBooksAsync();
    }
}
