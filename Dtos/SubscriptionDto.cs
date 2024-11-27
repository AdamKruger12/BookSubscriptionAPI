namespace BookSubscriptionApi.Dtos
{
    /// <summary>
    /// Data transfer object for a subscription
    /// </summary>
    public class SubscriptionDto
    {
        /// <summary>
        /// Id to track the subscription
        /// </summary>
        public required string Id { get; set; }
        /// <summary>
        /// User email to track the user
        /// </summary>
        public required string UserEmail { get; set; }
        /// <summary>
        /// Book id to track the book or books
        /// </summary>
        public required string BookId { get; set; }
    }
}
