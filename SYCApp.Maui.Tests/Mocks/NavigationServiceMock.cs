using System;
using Moq;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class NavigationServiceExtensions
    {
        public static void VerifyThatGoBackWasCalledOnce(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoBackAsync(), Times.Once);
        }

        public static void VerifyThatGoBackWasNotCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoBackAsync(), Times.Never);
        }

        public static void VerifyThatGoToDashboardPageAsyncWasCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoToDashboardPageAsync(), Times.Once);
        }

        public static void VerifyThatGoToLoginPageAsyncWasCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoToLoginPageAsync(), Times.Once);
        }

        public static void VerifyThatGoToRegistrationPageAsyncWasCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoToRegistrationPageAsync(), Times.Once);
        }

        public static void VerifyThatGoToMainFlowAsyncWasCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoToMainFlowAsync(), Times.Once);
        }

        public static void VerifyThatGoToAddClosetItemPageAsyncWasCalled(this Mock<INavigationService> mock)
        {
            mock.Verify(x => x.GoToAddClosetItemPageAsync(), Times.Once);
        }


    }
}
