using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class AddressUserContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AddressUser> AddressUsers { get; set; }

        public AddressUserContext(DbContextOptions<AddressUserContext> options)
            : base(options)
        {
        }
    }
}