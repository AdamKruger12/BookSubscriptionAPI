using BookSubscriptionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSubscriptionApi.Data
{
    /// <summary>
    /// DbContext for the application
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// DbSet for users
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// DbSet for books
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// DbSet for subscriptions
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }
        /// <summary>
        /// DbContext constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// This is a seeder. meant for mocking data for testing purposes
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var linkToDummyUser = Guid.NewGuid().ToString();
            var linkToDummyBook = Guid.NewGuid().ToString();

            //Dummy users for testing
            modelBuilder.Entity<User>().HasData(
                         new User { Id = linkToDummyUser, Username = "QuackMeister", Email = "TotallyGenericEmail1@gmail.com", FirstName = "John", LastName = "Doe", Password = HashPassword("admin") },
                         new User { Id = Guid.NewGuid().ToString(), Username = "ChickenMan", Email = "TotallyGenericEmail2@gmail.com", FirstName = "Barry", LastName = "Allen", Password = HashPassword("admin") },
                         new User { Id = Guid.NewGuid().ToString(), Username = "BigBoy", Email = "TotallyGenericEmail3@gmail.com", FirstName = "Tom", LastName = "Holland", Password = HashPassword("admin") },
                         new User { Id = Guid.NewGuid().ToString(), Username = "TheRealJack", Email = "TotallyGenericEmail4@gmail.com", FirstName = "Jack", LastName = "Black", Password = HashPassword("admin") },
                         new User { Id = Guid.NewGuid().ToString(), Username = "TheyDontKnowMeSon", Email = "TotallyGenericEmail5@gmail.com", FirstName = "David", LastName = "Goggins", Password = HashPassword("admin") });


            modelBuilder.Entity<Book>().HasData(
           // Fiction Books
           new Book { Id = linkToDummyBook, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A novel by F. Scott Fitzgerald exploring the American Dream in the 1920s.", Price = 15.99M, Category = BookCategory.Fiction, DatePublished = DateTime.Parse("1925-04-10"), Genre = "LiteraryFiction", ImageUrl = "https://i.imgur.com/xil4B5F.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "1984", Author = "George Orwell", Description = "A dystopian novel about a totalitarian regime that controls everything, including thought.", Price = 12.99M, Category = BookCategory.Fiction, DatePublished = DateTime.Parse("1949-06-08"), Genre = "Dystopian", ImageUrl = "https://i.imgur.com/xil4B5F.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "A Pulitzer Prize-winning novel about racial injustice in the Deep South.", Price = 10.99M, Category = BookCategory.Fiction, DatePublished = DateTime.Parse("1960-07-11"), Genre = "LiteraryFiction", ImageUrl = "https://i.imgur.com/IVHoso3.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "The Hobbit", Author = "J.R.R. Tolkien", Description = "A fantasy novel that introduces readers to Middle-earth and the journey of Bilbo Baggins.", Price = 13.50M, Category = BookCategory.Fiction, DatePublished = DateTime.Parse("1937-09-21"), Genre = "Fantasy", ImageUrl = "https://i.imgur.com/0MlcxEa.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "Pride and Prejudice", Author = "Jane Austen", Description = "A classic romance novel that critiques the British landed gentry at the end of the 18th century.", Price = 9.99M, Category = BookCategory.Fiction, DatePublished = DateTime.Parse("1813-01-28"), Genre = "Romance", ImageUrl = "https://i.imgur.com/fQZELCQ.jpeg" },

           // Non-Fiction Books
           new Book { Id = Guid.NewGuid().ToString(), Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", Description = "A sweeping history of human evolution and the impact of our species on the world.", Price = 18.99M, Category = BookCategory.NonFiction, DatePublished = DateTime.Parse("2011-01-01"), Genre = "History", ImageUrl = "https://imgur.com/JbeU4X7" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "Educated", Author = "Tara Westover", Description = "A memoir of a woman who escapes her strict and abusive upbringing in rural Idaho to earn a PhD.", Price = 16.99M, Category = BookCategory.NonFiction, DatePublished = DateTime.Parse("2018-02-20"), Genre = "Memoir", ImageUrl = "https://imgur.com/xil4B5F" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "The Power of Habit", Author = "Charles Duhigg", Description = "A book exploring how habits are formed and how they can be changed.", Price = 14.99M, Category = BookCategory.NonFiction, DatePublished = DateTime.Parse("2012-02-28"), Genre = "SelfHelp", ImageUrl = "https://i.imgur.com/ejpU8zR.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "The Immortal Life of Henrietta Lacks", Author = "Rebecca Skloot", Description = "The story of Henrietta Lacks, whose cells were taken without her knowledge and became one of the most important tools in medicine.", Price = 15.50M, Category = BookCategory.NonFiction, DatePublished = DateTime.Parse("2010-02-02"), Genre = "Biography", ImageUrl = "https://i.imgur.com/N8YfwC0.jpeg" },
           new Book { Id = Guid.NewGuid().ToString(), Title = "Outliers: The Story of Success", Author = "Malcolm Gladwell", Description = "An exploration of the factors that contribute to high levels of success.", Price = 13.99M, Category = BookCategory.NonFiction, DatePublished = DateTime.Parse("2008-11-18"), Genre = "Psychology", ImageUrl = "https://imgur.com/z6V6kyj" }
       );

            modelBuilder.Entity<Subscription>().HasData(
    new Subscription
    {
        Id = Guid.NewGuid().ToString(),
        UserId = linkToDummyUser,
        BookId = linkToDummyBook,
        DateSubscribed = DateTime.Now,
        IsActive = true
    }
);


        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
