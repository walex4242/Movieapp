using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountViewModel> Account { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important: Call base method

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    IsSubscribedToNewsletter = false,
                    MembershipTypeId = 1
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane Smith",
                    IsSubscribedToNewsletter = true,
                    MembershipTypeId = 2
                },
                new Customer
                {
                    Id = 3,
                    Name = "David Lee",
                    IsSubscribedToNewsletter = true,
                    MembershipTypeId = 3
                }
            );
        }
    }

    public class ApplicationUser : IdentityUser
    {
        // You can add custom properties if needed
    }
}