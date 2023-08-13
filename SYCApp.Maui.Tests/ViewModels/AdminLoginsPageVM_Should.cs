using System;
using Moq;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Tests.ViewModels
{
    public class AdminLoginsPageVM_Should : BaseVM
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<IMessageService> _mockMessageService;
        private readonly Mock<IUserPreferences> _mockUserPreferences;

        private readonly Mock<IRepository<LoginModel>> _mockLoginModelRepository;

        public AdminLoginsPageVM_Should()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockMessageService = new Mock<IMessageService>();
            _mockUserPreferences = new Mock<IUserPreferences>();
            _mockLoginModelRepository = new Mock<IRepository<LoginModel>>();
        }

        [Fact]
        public void DeleteLoginCommand()
        {
            AdminLoginsPageVM _sut = CreateAdminLoginsPageVM();

            var selectedListItem = new LoginModel();
            _sut.LoginId = 1;

            _mockLoginModelRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(selectedListItem);

            _mockLoginModelRepository.Setup(repo => repo.DeleteAsync(selectedListItem))
                .ReturnsAsync(It.IsAny<int>())
                .Verifiable();

        }

        [Fact]
        public void FindUserByIdCommand()
        {
            AdminLoginsPageVM _sut = CreateAdminLoginsPageVM();

            var selectedListItem = new LoginModel();

            _mockLoginModelRepository
              .Setup(x => x.GetById(It.IsAny<int>()))
              .ReturnsAsync(selectedListItem);
        }


        private AdminLoginsPageVM CreateAdminLoginsPageVM()
        {
            return new AdminLoginsPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockLoginModelRepository.Object);
        }
    }
}
