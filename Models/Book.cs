using System.ComponentModel.DataAnnotations;

namespace BookSubscriptionApi.Models
{
    /// <summary>
    /// Enum representing the category of a book.
    /// </summary>
    public enum BookCategory
    {
        /// <summary>
        /// Represents fiction books.
        /// </summary>
        Fiction,

        /// <summary>
        /// Represents non-fiction books.
        /// </summary>
        NonFiction
    }

    /// <summary>
    /// Represents a book in the system.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description of the book.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the date the book was published.
        /// </summary>
        [Required]
        public DateTime DatePublished { get; set; }

        /// <summary>
        /// Gets or sets the category of the book (Fiction/NonFiction).
        /// </summary>
        [Required]
        public BookCategory Category { get; set; } // 0 = Fiction, 1 = NonFiction

        /// <summary>
        /// Gets or sets the genre of the book.
        /// </summary>
        [Required]
        public string Genre { get; set; } // Ideally this will map to a table but assuming it will always be set.

        /// <summary>
        /// Gets or sets the image URL for the book.
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }
    }
}
