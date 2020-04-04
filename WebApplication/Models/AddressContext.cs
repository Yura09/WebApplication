using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class AddressContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<AddressUser> AddressUsers { get; set; }
       // public AddressContext() : base(NameValueCollection: "TestConnection") { } 
        public AddressContext(DbContextOptions<AddressContext> options)
            : base(options)
        {
          //  Database.EnsureCreated();
        }
    }
}