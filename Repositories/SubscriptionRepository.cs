using BookSubscriptionApi.Data;
using BookSubscriptionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSubscriptionApi.Repositories
{
    /// <summary>
    /// Provides methods for interacting with the subscriptions in the database.
    /// </summary>
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new subscription to the database.
        /// </summary>
        /// <param name="subscription">The subscription to add.</param>
        /// <returns>The added subscription.</returns>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while adding the subscription.</exception>
        public async Task<Subscription> AddAsync(Subscription subscription)
        {
            try
            {
                await _context.Subscriptions.AddAsync(subscription);
                await _context.SaveChangesAsync();
                return subscription;
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("An error occurred while adding the subscription to the database.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while adding the subscription.", ex);
            }
        }

        /// <summary>
        /// Retrieves the active subscription for a user and a specific book.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="bookId">The book ID.</param>
        /// <returns>The active subscription for the user and book.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no active subscription is found.</exception>
        public async Task<Subscription> GetActiveSubscriptionForUserAsync(string userId, string bookId)
        {
            try
            {
                var subscription = await _context.Subscriptions
                    .FirstOrDefaultAsync(s => s.UserId == userId && s.BookId == bookId && s.IsActive);

                if (subscription == null)
                {
                    throw new KeyNotFoundException("Subscription not found.");
                }

                return subscription;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the active subscription.", ex);
            }
        }

        /// <summary>
        /// Retrieves a subscription by its ID.
        /// </summary>
        /// <param name="id">The subscription ID.</param>
        /// <returns>The subscription with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the subscription is not found.</exception>
        public async Task<Subscription> GetById(string id)
        {
            try
            {
                var subscription = await _context.Subscriptions.FindAsync(id);

                if (subscription == null)
                {
                    throw new KeyNotFoundException($"Subscription with ID {id} not found.");
                }

                return subscription;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the subscription with ID: {id}.", ex);
            }
        }

        /// <summary>
        /// Marks a subscription as inactive to unsubscribe the user.
        /// </summary>
        /// <param name="subscription">The subscription to unsubscribe.</param>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while unsubscribing.</exception>
        public async Task UnsubscribeAsync(Subscription subscription)
        {
            try
            {
                subscription.IsActive = false;
                _context.Subscriptions.Update(subscription);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("An error occurred while unsubscribing the user from the subscription.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while unsubscribing the user.", ex);
            }
        }
    }
}
