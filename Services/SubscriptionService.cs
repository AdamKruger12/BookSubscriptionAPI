using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;
using BookSubscriptionApi.Models;
using BookSubscriptionApi.Repositories;

namespace BookSubscriptionApi.Services
{
    /// <summary>
    /// Provides services related to subscription operations, including adding, retrieving, and unsubscribing users.
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionService"/> class.
        /// </summary>
        /// <param name="subscriptionRepository">The subscription repository for accessing subscription data.</param>
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        /// <summary>
        /// Adds a new subscription.
        /// </summary>
        /// <param name="subscription">The subscription to add.</param>
        /// <returns>The added subscription.</returns>
        public async Task<Subscription> AddAsync(Subscription subscription)
        {
            return await _subscriptionRepository.AddAsync(subscription);
        }

        /// <summary>
        /// Retrieves the active subscription for a given user and book.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="bookId">The ID of the book.</param>
        /// <returns>The active subscription, if found.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no active subscription is found for the user and book.</exception>
        public async Task<Subscription> GetActiveSubscriptionForUserAsync(string userId, string bookId)
        {
            return await _subscriptionRepository.GetActiveSubscriptionForUserAsync(userId, bookId);
        }

        /// <summary>
        /// Retrieves a subscription by its ID.
        /// </summary>
        /// <param name="id">The ID of the subscription.</param>
        /// <returns>The subscription with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no subscription is found with the given ID.</exception>
        public async Task<Subscription> GetByIdAsync(string id)
        {
            return await _subscriptionRepository.GetById(id);
        }

        /// <summary>
        /// Marks a subscription as inactive, effectively unsubscribing the user.
        /// </summary>
        /// <param name="subscriptionDto">The data transfer object containing the subscription ID to unsubscribe.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the subscription is not found or is already inactive.</exception>
        public async Task UnsubscribeAsync(SubscriptionDto subscriptionDto)
        {
            var subscription = await _subscriptionRepository.GetById(subscriptionDto.Id);

            if (subscription == null || !subscription.IsActive)
            {
                throw new InvalidOperationException("Subscription not found or already inactive.");
            }

            subscription.IsActive = false;
            await _subscriptionRepository.UnsubscribeAsync(subscription);
        }
    }
}
