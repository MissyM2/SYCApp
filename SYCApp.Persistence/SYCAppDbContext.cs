

using Microsoft.EntityFrameworkCore;
using SYCApp.Domain;

namespace SYCApp.Persistence
{
	public class SYCAppDbContext : DbContext
	{
        public SYCAppDbContext(DbContextOptions<SYCAppDbContext> options) : base(options)
        {
        }


        public DbSet<UserModel> Users { get; set; }
        public DbSet<LoginModel> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().HasData(
               new UserModel { Id = 1, FirstName = "FirstName1", LastName="LastName1", UserEmail="u1@email.com", HashedPassword="UserPass1" },
               new UserModel { Id = 2, FirstName = "FirstName2", LastName = "LastName2", UserEmail = "u2@email.com", HashedPassword = "UserPass2" },
               new UserModel { Id = 3, FirstName = "FirstName3", LastName = "LastName3", UserEmail = "u3@email.com", HashedPassword = "UserPass3" }
           );
        }
    }
}

