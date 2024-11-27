using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;
using BookSubscriptionApi.Models;
using BookSubscriptionApi.Repositories;

namespace BookSubscriptionApi.Services
{
    /// <summary>
    /// Provides services related to book operations, including adding, deleting, and retrieving books.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository for accessing book data.</param>
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Adds a new book to the system.
        /// </summary>
        /// <param name="bookDto">The data transfer object containing the details of the book to add.</param>
        /// <returns>The added book.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the bookDto is null.</exception>
        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            if (bookDto == null)
            {
                throw new ArgumentNullException(nameof(bookDto), "Book DTO cannot be null.");
            }

            var book = new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author!,
                Genre = bookDto.Genre,
                DatePublished = bookDto.DatePublished,
                Description = bookDto.Description,
                Price = bookDto.Price,
                Category = bookDto.Category
            };

            return await _bookRepository.AddBook(book);
        }

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the book with the given ID is not found.</exception>
        public async Task DeleteBookAsync(string id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            await _bookRepository.DeleteBook(book);
        }

        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>A list of books.</returns>
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetBooks();
        }
    }
}
