using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {}
}