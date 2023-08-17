using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Domain;
using SYCApp.Persistence.Repositories;

namespace SYCApp.Persistence.Tests
{
	public class LoginRepositoryTests
    {

        [Fact]
        public async Task Should_Return_Existing_Users()
        {

            // ***** Arrange *****

            //  looking at the tests, it needs a date
            var date = new DateTime(2023, 06, 09);

            // need to arrange in memory db for testing use, just while test runs
            var dbOptions = new DbContextOptionsBuilder<SYCAppDbContext>()
                .UseInMemoryDatabase("ExistingUsersTest")
                .Options;

            // need to arrange some dummy data for testing
            using var dbContext = new SYCAppDbContext(dbOptions);
            {
                dbContext.Add(new UserModel { Id = 2, FirstName = "FirstName2", LastName = "LastName2", UserEmail = "u2@email.com", HashedPassword = "UserPass2" });
                dbContext.Add(new UserModel { Id = 3, FirstName = "FirstName3", LastName = "LastName3", UserEmail = "u3@email.com", HashedPassword = "UserPass3" });

                dbContext.Add(new LoginModel { UserId = 4, LoginDateTime = date });
                dbContext.Add(new LoginModel { UserId = 5, LoginDateTime = date.AddDays(-1) });

                dbContext.SaveChangesAsync();
            }

            //  need to arrange LoginRepository
            var loginRepository = new LoginRepository(dbContext);

            // ****** Act ******
            var existingUsers = await loginRepository.GetAll();

            // ****** Assert *****
            // using default assert
            Assert.Equal(2, existingUsers.Count());

            Assert.Contains(existingUsers, q => q.Id == 2);
            Assert.Contains(existingUsers, q => q.Id == 3);
            Assert.DoesNotContain(existingUsers, q => q.Id == 1);

            // could assert other things, such as name

        }


        [Fact]
        public void Should_Save_User_Login()
        {
            var dbOptions = new DbContextOptionsBuilder<SYCAppDbContext>()
                .UseInMemoryDatabase("UserLoginTest")
                .Options;

            var login = new LoginModel
            {
                UserId = 1,
                LoginDateTime = new DateTime()
            };

            using var dbContext = new SYCAppDbContext(dbOptions);
            var loginRepository = new LoginRepository(dbContext);
            var result = loginRepository.Create(login);

            var users = dbContext.Logins.ToList();

            // what is this for?
            var login1 = Assert.Single(users);

            Assert.Equal(login.LoginDateTime, login.LoginDateTime);
            Assert.Equal(login.UserId, login.UserId);
        }

    }
}
