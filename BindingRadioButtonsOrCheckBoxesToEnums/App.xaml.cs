﻿// <copyright file="App.xaml.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName;
using BindingRadioButtonsOrCheckBoxesToEnums.Services;
using BindingRadioButtonsOrCheckBoxesToEnums.Services.Interfaces;
using BindingRadioButtonsOrCheckBoxesToEnums.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace BindingRadioButtonsOrCheckBoxesToEnums
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App
    {
        /// <inheritdoc/>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <inheritdoc/>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        /// <inheritdoc/>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
