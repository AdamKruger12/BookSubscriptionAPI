using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Defines the operations for interacting with subscriptions in the repository.
    /// </summary>
    public interface ISubscriptionRepository
    {
        /// <summary>
        /// Adds a new subscription to the repository.
        /// </summary>
        /// <param name="subscription">The subscription to add.</param>
        /// <returns>The added subscription.</returns>
        Task<Subscription> AddAsync(Subscription subscription);

        /// <summary>
        /// Unsubscribes a user from a subscription.
        /// </summary>
        /// <param name="subscription">The subscription to unsubscribe from.</param>
        Task UnsubscribeAsync(Subscription subscription);

        /// <summary>
        /// Retrieves a subscription from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the subscription to retrieve.</param>
        /// <returns>The subscription with the specified ID.</returns>
        Task<Subscription> GetById(string id);

        /// <summary>
        /// Retrieves an active subscription for a user for a specific book.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="bookId">The ID of the book.</param>
        /// <returns>The active subscription for the user and book, if it exists.</returns>
        Task<Subscription> GetActiveSubscriptionForUserAsync(string userId, string bookId);
    }
}
