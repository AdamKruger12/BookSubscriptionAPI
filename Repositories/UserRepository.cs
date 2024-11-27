using BookSubscriptionApi.Data;
using BookSubscriptionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Provides methods for interacting with users in the database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the user is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while saving the user.</exception>
        public async Task AddAsync(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "User cannot be null.");
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("An error occurred while saving the user to the database.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the user.", ex);
            }
        }

        /// <summary>
        /// Retrieves a user from the database by their email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <returns>The user with the specified email.</returns>
        /// <exception cref="ArgumentException">Thrown when the email is null or empty.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the user is not found.</exception>
        /// <exception cref="Exception">Thrown for unexpected errors.</exception>
        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentException("Email cannot be null or empty.", nameof(email));
                }

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null)
                {
                    throw new KeyNotFoundException($"User with email '{email}' not found.");
                }

                return user;
            }
            catch (ArgumentException argEx)
            {
                throw new ArgumentException("Invalid input provided.", argEx);
            }
            catch (KeyNotFoundException keyEx)
            {
                throw new KeyNotFoundException("User not found.", keyEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the user by email.", ex);
            }
        }
    }
}
