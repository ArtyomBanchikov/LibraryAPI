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
    }
}
