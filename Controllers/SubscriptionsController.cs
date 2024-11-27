using BookSubscriptionApi.Dtos;
using BookSubscriptionApi.Interfaces;
using BookSubscriptionApi.Models;
using BookSubscriptionApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookSubscriptionApi.Controllers
{
    /// <summary>
    /// Handles operations related to book subscriptions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Creates a new instance of the <see cref="SubscriptionsController"/> class.
        /// </summary>
        /// <param name="subscriptionService"></param>
        /// <param name="userRepository"></param>
        /// <param name="bookRepository"></param>
        public SubscriptionsController(ISubscriptionService subscriptionService, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _subscriptionService = subscriptionService;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Unsubscribes a user from a book subscription.
        /// </summary>
        /// <param name="subscriptionDto">The subscription details.</param>
        /// <returns>Status of the unsubscription process.</returns>
        [HttpPost("unsubscribe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Unsubscribe([FromBody] SubscriptionDto subscriptionDto)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(subscriptionDto.UserEmail);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                var subscription = await _subscriptionService.GetActiveSubscriptionForUserAsync(user.Id, subscriptionDto.BookId);
                if (subscription == null || !subscription.IsActive)
                {
                    return NotFound("No active subscription found for this book.");
                }

                await _subscriptionService.UnsubscribeAsync(subscriptionDto);
                return Ok("Successfully unsubscribed.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Purchases a subscription for a book.
        /// </summary>
        /// <param name="subscriptionDto">The subscription details.</param>
        /// <returns>The newly created subscription.</returns>
        [HttpPost("purchase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PurchaseSubscription([FromBody] SubscriptionDto subscriptionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid input.");
                }

                var user = await _userRepository.GetByEmailAsync(subscriptionDto.UserEmail);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                var book = await _bookRepository.GetBookByIdAsync(subscriptionDto.BookId);
                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                var existingSubscription = await _subscriptionService.GetActiveSubscriptionForUserAsync(user.Id, subscriptionDto.BookId);
                if (existingSubscription != null && existingSubscription.IsActive)
                {
                    return Conflict("User already subscribed to this book.");
                }

                var subscription = new Subscription
                {
                    UserId = user.Id,
                    User = user,
                    BookId = book.Id,
                    Book = book,
                    DateSubscribed = DateTime.UtcNow,
                    IsActive = true,
                };

                await _subscriptionService.AddAsync(subscription);

                return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscription.Id }, subscription);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a subscription by ID.
        /// </summary>
        /// <param name="id">The subscription ID.</param>
        /// <returns>The subscription details.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubscriptionById(string id)
        {
            var subscription = await _subscriptionService.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound("Subscription not found.");
            }

            return Ok(subscription);
        }
    }
}
