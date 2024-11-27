using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Dtos
{
    /// <summary>
    /// Data transfer object for a book
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Id of the book
        /// </summary>
        public required string Id { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Description of the book
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Price of the book
        /// </summary>
        public required decimal Price { get; set; }
        /// <summary>
        /// Author of the book
        /// </summary>
        public required string? Author { get; set; }
        /// <summary>
        /// Date the book was published
        /// </summary>
        public required DateTime DatePublished { get; set; }
        /// <summary>
        /// Category of the book
        /// </summary>
        public required BookCategory Category { get; set; }
        /// <summary>
        /// Genre of the book
        /// </summary>
        public required string Genre { get; set; }
    }
}
