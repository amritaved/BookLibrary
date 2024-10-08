using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Ikigai", Author = "Héctor García and Francesc Miralles.", Genre = "Non-fiction", Year = 2016 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Year = 1960 },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", Year = 1925 },
            new Book { Id = 4, Title = "Atomic Habits", Author = "James Clear", Genre = "Non-fiction", Year = 2018 }

        );
    }
}
