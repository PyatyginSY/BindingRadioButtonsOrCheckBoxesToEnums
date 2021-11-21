// <copyright file="MainWindowViewModel.cs" company="Pyatygin S.Y.">
// Copyright (c) Pyatygin S.Y.. All rights reserved.
// </copyright>

using Prism.Commands;
using Prism.Mvvm;
using SADT.Core.Enums;
using SADT.Core.Extension;

namespace BindingRadioButtonsOrCheckBoxesToEnums.ViewModels
{
    /// <summary>
    /// MainWindowViewModel.
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string _title;
        private DelegateCommand _changeCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            CalculationTypeProperty = new EnumSelection<CalculationType>(CalculationType.CalculationTransformer);
            Title = CalculationTypeProperty.Value.ToString();
        }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public EnumSelection<CalculationType> CalculationTypeProperty
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public DelegateCommand ChangeCommand => _changeCommand ??= new DelegateCommand(ChangeExecute);

        private void ChangeExecute()
        {
            Title = CalculationTypeProperty.Value.ToString();
        }
    }
}
