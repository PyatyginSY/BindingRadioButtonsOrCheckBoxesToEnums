// <copyright file="ViewAViewModelFixture.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName.ViewModels;
using BindingRadioButtonsOrCheckBoxesToEnums.Services.Interfaces;
using Moq;
using Prism.Regions;
using Xunit;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName.Tests.ViewModels
{
    /// <summary>
    /// ViewAViewModelFixture.
    /// </summary>
    public class ViewAViewModelFixture
    {
        private const string MessageServiceDefaultMessage = "Some Value";
        private readonly Mock<IMessageService> _messageServiceMock;
        private readonly Mock<IRegionManager> _regionManagerMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAViewModelFixture"/> class.
        /// </summary>
        public ViewAViewModelFixture()
        {
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
            _messageServiceMock = messageService;

            _regionManagerMock = new Mock<IRegionManager>();
        }

        /// <summary>
        /// MessagePropertyValueUpdated.
        /// </summary>
        [Fact]
        public void MessagePropertyValueUpdated()
        {
            var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            _messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

            Assert.Equal(MessageServiceDefaultMessage, vm.Message);
        }

        /// <summary>
        /// MessageINotifyPropertyChangedCalled.
        /// </summary>
        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            var vm = new ViewAViewModel(_regionManagerMock.Object, _messageServiceMock.Object);
            Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
        }
    }
}
