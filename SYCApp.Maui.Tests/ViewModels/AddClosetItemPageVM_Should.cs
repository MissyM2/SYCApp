using System;
using Moq;
using FluentAssertions;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Interfaces;
using SYCApp.Maui.Tests.Mocks;

namespace SYCApp.Maui.Tests.ViewModels
{
    public class AddClosetItemPageVM_Should
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<IMessageService> _mockMessageService;
        private readonly Mock<IUserPreferences> _mockUserPreferences;

        private readonly Mock<IRepository<ClosetItemModel>> _mockClosetItemModelRepository;
        private readonly Mock<IRepository<LoginModel>> _mockLoginModelRepository;

        public AddClosetItemPageVM_Should()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockMessageService = new Mock<IMessageService>();
            _mockUserPreferences = new Mock<IUserPreferences>();

            _mockClosetItemModelRepository = new Mock<IRepository<ClosetItemModel>>();
            _mockLoginModelRepository = new Mock<IRepository<LoginModel>>();
        }


        [Fact]
        public void GoBack_doesnt_navigate_back_when_the_user_cancels_navigation()
        {
            _mockMessageService.DisplayAlertReturns(false);
            AddClosetItemPageVM _sut = CreateAddClosetItemPageVM();

            _sut.GoBackCommand.Execute(null);

            _mockNavigationService.VerifyThatGoBackWasNotCalled();
        }

        [Fact]
        public void GoBack_navigates_back_when_the_user_confirms_navigation()
        {
            _mockMessageService.DisplayAlertReturns(true);

            AddClosetItemPageVM _sut = CreateAddClosetItemPageVM();


            _sut.GoBackCommand.Execute(null);

            _mockNavigationService.VerifyThatGoBackWasCalledOnce();
        }


        [Fact]
        public void AddClosetItemCommand_saves_new_closetitem()
        {
            // Arrange
            AddClosetItemPageVM _sut = CreateAddClosetItemPageVM();

            _sut.Name.Value = "Test Closet";
            _sut.Season.Value = "Test Season";
            _sut.ItemType.Value = "Test ItemType";
            _sut.Size.Value = "Test Size";
            _sut.Desc.Value = "Test Desc";

            // cct

            _sut.AddClosetItemCommand.Execute(null);

            // Assert

            _sut.Name.Errors.Should().BeEmpty();
            _sut.Season.Errors.Should().BeEmpty();
            _sut.ItemType.Errors.Should().BeEmpty();
            _sut.Size.Errors.Should().BeEmpty();
            _sut.Desc.Errors.Should().BeEmpty();


            _mockClosetItemModelRepository.VerifyThatSaveAsyncWasCalled();
        }

        private AddClosetItemPageVM CreateAddClosetItemPageVM()
        {
            return new AddClosetItemPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockClosetItemModelRepository.Object,
                _mockLoginModelRepository.Object);
        }
    }
}

