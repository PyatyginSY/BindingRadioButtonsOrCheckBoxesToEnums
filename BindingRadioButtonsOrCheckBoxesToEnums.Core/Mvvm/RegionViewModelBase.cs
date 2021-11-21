// <copyright file="RegionViewModelBase.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using Prism.Regions;
using System;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Core.Mvvm
{
    /// <summary>
    /// RegionViewModelBase.
    /// </summary>
    public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionViewModelBase"/> class.
        /// </summary>
        /// <param name="regionManager">regionManager.</param>
        public RegionViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        protected IRegionManager RegionManager { get; private set; }

        /// <summary>
        /// ConfirmNavigationRequest.
        /// </summary>
        /// <param name="navigationContext">navigationContext.</param>
        /// <param name="continuationCallback">continuationCallback.</param>
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        /// <inheritdoc/>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <inheritdoc/>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <inheritdoc/>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
