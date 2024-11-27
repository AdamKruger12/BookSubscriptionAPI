using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Interfaces
{
    /// <summary>
    /// Defines methods for generating JWT tokens.
    /// </summary>
    public interface IJwtHelper
    {
        /// <summary>
        /// Generates a JWT token for a specified user.
        /// </summary>
        /// <param name="user">The user for whom the token will be generated.</param>
        /// <returns>A JWT token as a string.</returns>
        string GenerateToken(User user);
    }
}
