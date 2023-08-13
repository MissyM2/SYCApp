using System;
using Moq;
using FluentAssertions;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Tests.ViewModels
{
    public class AdminUsersPageVM_Should
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<IMessageService> _mockMessageService;
        private readonly Mock<IUserPreferences> _mockUserPreferences;

        private readonly Mock<IRepository<LoginModel>> _mockLoginModelRepository;
        private readonly Mock<IRepository<UserModel>> _mockUserModelRepository;

        public AdminUsersPageVM_Should()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockMessageService = new Mock<IMessageService>();
            _mockUserPreferences = new Mock<IUserPreferences>();
            _mockLoginModelRepository = new Mock<IRepository<LoginModel>>();
            _mockUserModelRepository = new Mock<IRepository<UserModel>>();
        }

        [Fact]
        public void DeleteUserCommand()
        {
            AdminUsersPageVM _sut = CreateAdminUsersPageVM();

            var selectedListItem = new UserModel();
            _sut.UserId = 1;

            _mockUserModelRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(selectedListItem);

            _mockUserModelRepository.Setup(repo => repo.DeleteAsync(selectedListItem))
                .ReturnsAsync(It.IsAny<int>())
                .Verifiable();

        }

        [Fact]
        public void FindUserByIdCommand()
        {
            AdminUsersPageVM _sut = CreateAdminUsersPageVM();

            var selectedListItem = new UserModel();

            _mockUserModelRepository
              .Setup(x => x.GetById(It.IsAny<int>()))
              .ReturnsAsync(selectedListItem);
        }


        private AdminUsersPageVM CreateAdminUsersPageVM()
        {
            return new AdminUsersPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockLoginModelRepository.Object,
                _mockUserModelRepository.Object);
        }
    }
}
