using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Models;

namespace BookSubscriptionApi.Interfaces
{
    /// <summary>
    /// Defines methods for managing user subscriptions.
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// Adds a new subscription for a user.
        /// </summary>
        /// <param name="subscription">The subscription to be added.</param>
        /// <returns>The added subscription.</returns>
        public Task<Subscription> AddAsync(Subscription subscription);

        /// <summary>
        /// Unsubscribes a user from a book subscription.
        /// </summary>
        /// <param name="subscriptionDto">The details of the subscription to unsubscribe from.</param>
        /// <returns>A task representing the operation.</returns>
        public Task UnsubscribeAsync(SubscriptionDto subscriptionDto);

        /// <summary>
        /// Retrieves the active subscription for a user and book.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="bookId">The book ID.</param>
        /// <returns>The active subscription, or null if no active subscription exists.</returns>
        public Task<Subscription> GetActiveSubscriptionForUserAsync(string userId, string bookId);

        /// <summary>
        /// Retrieves a subscription by its ID.
        /// </summary>
        /// <param name="id">The subscription ID.</param>
        /// <returns>The subscription matching the ID, or null if not found.</returns>
        public Task<Subscription> GetByIdAsync(string id);
    }
}
