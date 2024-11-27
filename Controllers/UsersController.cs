using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookSubscriptionApi.Controllers
{
    /// <summary>
    /// Handles operations related to users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Creates a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userDto">The user registration details.</param>
        /// <returns>The registered user and their token.</returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User registration data is required.");
            }

            var user = await _userService.RegisterUserAsync(userDto);
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="loginDto">The login credentials.</param>
        /// <returns>The authenticated user and their JWT token.</returns>
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return Unauthorized("Invalid credentials.");
            }

            var user = await _userService.AuthenticateUserAsync(loginDto.Email, loginDto.Password);
            if (string.IsNullOrEmpty(user.Token))
            {
                return Unauthorized("Authentication failed. Invalid username or password.");
            }

            return Ok(new { User = user });//Note could make this just return the token
        }
    }
}
