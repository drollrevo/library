using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DLL.Data
{
     public class AppDBContext : DbContext
     {
         public AppDBContext(DbContextOptions<AppDBContext> options)
             : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
     }
}
