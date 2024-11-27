using BookSubscriptionApi.Dtos;

namespace BookSubscriptionApi.Interfaces
{
    /// <summary>
    /// Defines methods for managing user registration and authentication.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userDto">The user registration details.</param>
        /// <returns>A <see cref="UserDto"/> representing the registered user.</returns>
        Task<UserDto> RegisterUserAsync(UserRegistrationDto userDto);

        /// <summary>
        /// Authenticates a user based on email and password.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>A <see cref="UserDto"/> representing the authenticated user, or null if authentication fails.</returns>
        Task<UserDto> AuthenticateUserAsync(string email, string password);
    }
}
