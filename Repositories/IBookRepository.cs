using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Defines the operations for interacting with books in the repository.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Adds a new book to the repository.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The added book.</returns>
        Task<Book> AddBook(Book book);

        /// <summary>
        /// Deletes a book from the repository.
        /// </summary>
        /// <param name="book">The book to delete.</param>
        Task DeleteBook(Book book);

        /// <summary>
        /// Retrieves a book from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID.</returns>
        Task<Book> GetBookByIdAsync(string id);

        /// <summary>
        /// Retrieves all books from the repository.
        /// </summary>
        /// <returns>A list of all books.</returns>
        Task<List<Book>> GetBooks();
    }
}
