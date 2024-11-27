namespace BookSubscriptionApi.Dtos
{
    /// <summary>
    /// Data transfer object for login
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// User email
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public required string Password { get; set; }
    }
}
