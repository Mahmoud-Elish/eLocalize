using Microsoft.EntityFrameworkCore;

namespace Library.DAL;

public class LibraryContext:DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<BookMember> BookMembers => Set<BookMember>();

    public LibraryContext(DbContextOptions options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
