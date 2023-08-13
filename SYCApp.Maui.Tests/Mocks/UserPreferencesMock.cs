using System;
using Moq;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Tests.Mocks
{
    public static class UserPreferencesExtensions
    {
        public static void ContainsKeyReturns(this Mock<IUserPreferences> mock, string key, bool value)
        {
            mock.Setup(x => x.ContainsKey(key))
                .Returns(value);
        }

        public static void GetReturns(this Mock<IUserPreferences> mock, string key, bool value)
        {
            mock.Setup(x => x.Get(key, false))
                .Returns(value);
        }
    }
}
