using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Defines the operations for interacting with users in the repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user associated with the provided email.</returns>
        Task<User> GetByEmailAsync(string email);

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add to the repository.</param>
        Task AddAsync(User user);
    }
}
