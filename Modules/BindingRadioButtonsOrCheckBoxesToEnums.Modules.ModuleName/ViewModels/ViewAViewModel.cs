// <copyright file="ViewAViewModel.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using BindingRadioButtonsOrCheckBoxesToEnums.Core.Mvvm;
using BindingRadioButtonsOrCheckBoxesToEnums.Services.Interfaces;
using Prism.Regions;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName.ViewModels
{
    /// <summary>
    /// ViewAViewModel.
    /// </summary>
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">regionManager.</param>
        /// <param name="messageService">messageService.</param>
        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService)
            : base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        /// <inheritdoc/>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // do something
        }
    }
}
