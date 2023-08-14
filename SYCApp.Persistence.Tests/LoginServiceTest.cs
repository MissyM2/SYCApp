using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Domain;
using SYCApp.Persistence.Services;

namespace SYCApp.Persistence.Tests
{
	public class LoginServiceTest
    {

        [Fact]
        public void Should_Return_Existing_Users()
        {

            // ***** Arrange *****

            //  looking at the tests, it needs a date
            var date = new DateTime(2023, 06, 09);

            // need to arrange in memory db for testing use, just while test runs
            var dbOptions = new DbContextOptionsBuilder<SYCAppDbContext>()
                .UseInMemoryDatabase("ExistingUsersTest")
                .Options;

            // need to arrange some dummy data for testing
            using var context = new SYCAppDbContext(dbOptions);
            {
                context.Add(new UserModel { Id = 2, FirstName = "FirstName2", LastName = "LastName2", UserEmail = "u2@email.com", HashedPassword = "UserPass2" });
                context.Add(new UserModel { Id = 3, FirstName = "FirstName3", LastName = "LastName3", UserEmail = "u3@email.com", HashedPassword = "UserPass3" });

                context.Add(new LoginModel { UserId = 4, LoginDateTime = date });
                context.Add(new LoginModel { UserId = 5, LoginDateTime = date.AddDays(-1) });

                context.SaveChanges();
            }

            //  need to arrange LoginService
            var loginService = new LoginService(context);

            // ****** Act ******
            var existingUsers = loginService.GetExistingUserModels();

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

            using var context = new SYCAppDbContext(dbOptions);
            var loginService = new LoginService(context);
            loginService.Save(login);

            var users = context.Logins.ToList();

            var login1 = Assert.Single(users);

            Assert.Equal(login.LoginDateTime, login.LoginDateTime);
            Assert.Equal(login.UserId, login.UserId);
        }

    }
}
