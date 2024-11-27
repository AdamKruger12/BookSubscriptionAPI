using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSubscriptionApi.Models
{
    /// <summary>
    /// Represents a subscription to a book by a user.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Gets or sets the unique identifier for the subscription.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user who subscribed to the book.
        /// </summary>
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who made the subscription.
        /// </summary>
        [Required]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the book that was subscribed to.
        /// </summary>
        [Required]
        [ForeignKey("Book")]
        public string BookId { get; set; }

        /// <summary>
        /// Gets or sets the book that is part of the subscription.
        /// </summary>
        [Required]
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets the date when the subscription was created.
        /// </summary>
        [Required]
        public DateTime DateSubscribed { get; set; }

        /// <summary>
        /// Gets or sets whether the subscription is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
    }
}
