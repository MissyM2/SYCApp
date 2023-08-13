using System;
using Moq;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class MessageServiceExtensions
    {
        public static void DisplayAlertReturns(this Mock<IMessageService> mock, bool alertResult)
        {
            mock.Setup(x => x.DisplayAlert(It.IsAny<string>(),
                                      It.IsAny<string>(),
                                      It.IsAny<string>(),
                                      It.IsAny<string>()))
                .Returns(Task.FromResult(alertResult));
        }

        public static void VerifyThatDisplayAlertWasCalledWithMessage(this Mock<IMessageService> mock, string message)
        {
            mock.Verify(x => x.DisplayAlert(It.IsAny<string>(), message, It.IsAny<string>()), Times.Once);
        }
    }
}
