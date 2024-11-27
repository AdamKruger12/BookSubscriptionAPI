namespace BookSubscriptionApi.Dtos
{
    /// <summary>
    /// Data transfer object for a user
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// First name of the user
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// Last name of the user
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Username of the user
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// JWT token for the user
        /// </summary>
        public string? Token { get; set; }
    }
}
