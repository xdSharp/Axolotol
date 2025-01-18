using System.Data.Entity;

public class LibraryContext : DbContext
{
    public LibraryContext() : base("name=LibraryDB") { }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
}