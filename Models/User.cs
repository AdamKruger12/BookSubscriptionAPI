using System.ComponentModel.DataAnnotations;

namespace BookSubscriptionApi.Models
{
    /// <summary>
    /// Represents a user in the book subscription system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
