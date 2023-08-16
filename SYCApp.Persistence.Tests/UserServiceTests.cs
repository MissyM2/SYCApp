using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Domain;
using SYCApp.Persistence.Repositories;

namespace SYCApp.Persistence.Tests
{
    public class UserRepositoryTests
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

                dbContext.SaveChangesAsync();
            }

            //  need to arrange LoginRepository
            var loginRepository = new LoginRepository(dbContext);

            // ****** Act ******
            var existingUsers = await loginRepository.GetAllAsync();

            // ****** Assert *****
            // using default assert
            Assert.Equal(2, existingUsers.Count());

            Assert.Contains(existingUsers, q => q.Id == 2);
            Assert.Contains(existingUsers, q => q.Id == 3);
            Assert.DoesNotContain(existingUsers, q => q.Id == 1);

            // could assert other things, such as name

        }


        [Fact]
        public void Should_Save_User_Model()
        {
            var dbOptions = new DbContextOptionsBuilder<SYCAppDbContext>()
                .UseInMemoryDatabase("AddUserTest")
                .Options;

            var userModel = new UserModel
            {
                FirstName = "FirstName5",
                LastName = "LastName5",
                UserEmail = "u5@email.com",
                HashedPassword = "UserPass5"
            };

            using var dbContext = new SYCAppDbContext(dbOptions);
            var userRepository = new UserRepository(dbContext);

            //var result = userRepository.Save(userModel);

            var users = dbContext.Users.ToList();


            Assert.Equal(userModel.FirstName, userModel.FirstName);
            Assert.Equal(userModel.LastName, userModel.LastName);
            Assert.Equal(userModel.UserEmail, userModel.UserEmail);
            Assert.Equal(userModel.HashedPassword, userModel.HashedPassword);
        }

    }
}
