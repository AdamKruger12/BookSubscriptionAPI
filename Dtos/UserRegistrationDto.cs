namespace BookSubscriptionApi.Dtos
{
    /// <summary>
    /// Data transfer object for user registration
    /// </summary>
    public class UserRegistrationDto
    {
        /// <summary>
        /// New user email
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// New user first name
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// New user last name
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// New user username
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// New user password (Will be hashed)
        /// </summary>
        public required string Password { get; set; } // Password only for registration
    }
}
