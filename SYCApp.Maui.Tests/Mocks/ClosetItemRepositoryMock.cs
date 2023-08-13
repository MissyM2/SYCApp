using System;
using Moq;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class ClosetItemRepositoryExtensions
    {
        public static void GetAllAsyncReturns(this Mock<IRepository<ClosetItemModel>> mock, List<ClosetItemModel> closetItems)
        {
            mock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(closetItems));
        }

        public static void VerifyThatSaveAsyncWasCalled(this Mock<IRepository<ClosetItemModel>> mock)
        {
            mock.Verify(x => x.SaveAsync(It.IsAny<ClosetItemModel>()), Times.Once);
        }

        //public static void GetByIdReturns(this Mock<IRepository<ClosetItemModel>> mock, ClosetItemModel closetItem)
        //{
        //    mock.Setup(x => x.GetById(closetItem.Id))
        //        .Returns(Task.FromResult(closetItem));
        //}


    }
}

