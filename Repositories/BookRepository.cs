using BookSubscriptionApi.Data;
using BookSubscriptionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Provides methods to interact with the books in the database.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Configures a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The added book.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided book is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while adding the book.</exception>
        public async Task<Book> AddBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null.");
                }

                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return book;
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("An error occurred while adding the book to the database.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the book.", ex);
            }
        }

        /// <summary>
        /// Deletes a book from the database.
        /// </summary>
        /// <param name="book">The book to delete.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided book is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while deleting the book.</exception>
        public async Task DeleteBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book to delete cannot be null.");
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new InvalidOperationException("An error occurred while deleting the book. It might already be deleted.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the book.", ex);
            }
        }

        /// <summary>
        /// Retrieves a book from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the book with the specified ID is not found.</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs while retrieving the book.</exception>
        public async Task<Book> GetBookByIdAsync(string id)
        {
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

                if (book == null)
                {
                    throw new KeyNotFoundException($"Book with ID {id} not found.");
                }

                return book;
            }
            catch (KeyNotFoundException keyEx)
            {
                throw new KeyNotFoundException("Book not found.", keyEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the book by ID.", ex);
            }
        }

        /// <summary>
        /// Retrieves a list of all books in the database.
        /// </summary>
        /// <returns>A list of books.</returns>
        /// <exception cref="Exception">Thrown when an unexpected error occurs while retrieving the books.</exception>
        public async Task<List<Book>> GetBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the list of books.", ex);
            }
        }
    }
}
