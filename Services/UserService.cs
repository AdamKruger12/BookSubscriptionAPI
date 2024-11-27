using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;
using BookSubscriptionApi.Models;
using BookSubscriptionApi.Repositories;

namespace BookSubscriptionApi.Services
{
    /// <summary>
    /// Provides user-related services such as authentication and registration.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHelper _jwtHelper; // Might end up being redundant

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository for accessing user data.</param>
        /// <param name="jwtHelper">The JWT helper for generating and validating tokens.</param>
        public UserService(IUserRepository userRepository, IJwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        /// <summary>
        /// Authenticates a user based on their email and password.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>A <see cref="UserDto"/> containing user information and a JWT token.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown if the credentials are invalid.</exception>
        public async Task<UserDto> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !VerifyPasswordHash(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var token = _jwtHelper.GenerateToken(user);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = token
            };
        }

        /// <summary>
        /// Registers a new user and returns their details.
        /// </summary>
        /// <param name="userDto">The data transfer object containing the user's registration details.</param>
        /// <returns>A <see cref="UserDto"/> containing the registered user's details.</returns>
        public async Task<UserDto> RegisterUserAsync(UserRegistrationDto userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Password = HashPassword(userDto.Password)
            };

            await _userRepository.AddAsync(user);
            return new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            };
        }

        /// <summary>
        /// Hashes a password using BCrypt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifies if the provided password matches the hashed password.
        /// </summary>
        /// <param name="password">The password to verify.</param>
        /// <param name="passwordHash">The stored hashed password.</param>
        /// <returns>True if the password matches the hash, otherwise false.</returns>
        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
