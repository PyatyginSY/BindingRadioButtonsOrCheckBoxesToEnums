// <copyright file="ModuleNameModule.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using BindingRadioButtonsOrCheckBoxesToEnums.Core;
using BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName
{
    /// <summary>
    /// ModuleNameModule.
    /// </summary>
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleNameModule"/> class.
        /// </summary>
        /// <param name="regionManager">regionManager.</param>
        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <inheritdoc/>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        /// <inheritdoc/>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}