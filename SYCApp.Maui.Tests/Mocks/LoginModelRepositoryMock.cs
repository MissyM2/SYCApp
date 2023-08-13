using System;
using Moq;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class LoginModelRepositoryExtensions
    {
        public static void GetAllAsyncReturns(this Mock<IRepository<LoginModel>> mock, List<LoginModel> logins)
        {
            mock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(logins));
        }

        public static void VerifyThatSaveAsyncWasCalled(this Mock<IRepository<LoginModel>> mock)
        {
            mock.Verify(x => x.SaveAsync(It.IsAny<LoginModel>()), Times.Once);
        }
    }
}

