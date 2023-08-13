using System;
using Moq;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class UserRepositoryExtensions
    {
        public static void GetAllAsyncReturns(this Mock<IRepository<UserModel>> mock, List<UserModel> users)
        {
            mock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(users));
        }

        public static void VerifyThatSaveAsyncWasCalled(this Mock<IRepository<UserModel>> mock)
        {
            mock.Verify(x => x.SaveAsync(It.IsAny<UserModel>()), Times.Once);
        }

        public static void VerifyThatDeleteAsyncWasCalled(this Mock<IRepository<UserModel>> mock)
        {
            mock.Verify(x => x.DeleteAsync(It.IsAny<UserModel>()), Times.Once);
        }

        public static void GetByIdReturns(this Mock<IRepository<UserModel>> mock, UserModel user)
        {
            mock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(user));
        }



        //public static void DeleteAsyncReturns(this Mock<IRepository<UserModel>> mock, int )
        //{
        //    mock.Setup(x => x.GetById(It.IsAny<int>()))
        //        .Returns(Task.FromResult(user));
        //}
    }
}
