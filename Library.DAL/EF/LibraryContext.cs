using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var testBook1 = new BookEntity { Title = "TestBook1", Author = "TestAuthor1", Description = "TestDescription1", Genre = "TestGenre1", ISBN = 1000000000001 };

            var testBook2 = new BookEntity { Title = "TestBook2", Author = "TestAuthor2", Description = "TestDescription2", Genre = "TestGenre2", ISBN = 1000000000002 };

            var testBook3 = new BookEntity
            {
                Title = "TestBook3",
                Author = "TestAuthor3",
                Description = "TestDescription3",
                Genre = "TestGenre3",
                ISBN = 1000000000003,
                TakenDate = new DateTime(2023, 11, 24),
                ReturnDate = new DateTime(2024, 1, 24)
            };

            var testBook4 = new BookEntity
            {
                Title = "TestBook4",
                Author = "TestAuthor4",
                Description = "TestDescription4",
                Genre = "TestGenre4",
                ISBN = 1000000000004,
                TakenDate = new DateTime(2023, 12, 13),
                ReturnDate = new DateTime(2024, 1, 13)
            };

            modelBuilder.Entity<BookEntity>().HasData(testBook1, testBook2, testBook3, testBook4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
