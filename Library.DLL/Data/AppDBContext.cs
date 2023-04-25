using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DLL.Data
{
     public class AppDBContext : DbContext
     {
         public AppDBContext(DbContextOptions<AppDBContext> options)
             : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookOrder> BookOrder { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public object Address { get; internal set; }
    }
}
