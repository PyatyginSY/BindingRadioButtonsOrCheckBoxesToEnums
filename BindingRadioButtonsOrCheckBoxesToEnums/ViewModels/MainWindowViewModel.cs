using BindingRadioButtonsOrCheckBoxesToEnums.Modules.ModuleName.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using SADT.Core.Enums;
using SADT.Core.Extension;

namespace BindingRadioButtonsOrCheckBoxesToEnums.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Field

        private string _title;
        private DelegateCommand _changeCommand;

        #endregion

        #region Property

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public EnumSelection<CalculationType> CalculationTypeProperty
        {
            get;
            private set;
        }

        #endregion

        #region Command

        public DelegateCommand ChangeCommand => _changeCommand ??= new DelegateCommand(ChangeExecute);

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            CalculationTypeProperty = new EnumSelection<CalculationType>(CalculationType.CalculationTransformer);
            Title = CalculationTypeProperty.Value.ToString();
        }

        #endregion

        #region Method

        private void ChangeExecute()
        {
            Title = CalculationTypeProperty.Value.ToString();
        }

        #endregion

        //public enum StartTask
        //{
        //    Manual,
        //    Automatic
        //}

        //[Flags()]
        //public enum DayOfWeek
        //{
        //    Sunday = 1 << 0,
        //    Monday = 1 << 1,
        //    Tuesday = 1 << 2,
        //    Wednesday = 1 << 3,
        //    Thursday = 1 << 4,
        //    Friday = 1 << 5,
        //    Saturday = 1 << 6
        //}

        //public enum AdditionalOptions
        //{
        //    None = 0,
        //    OptionA,
        //    OptionB
        //}

        //public class MyViewModel : ViewModelBase
        //{
        //    public MyViewModel()
        //    {
        //        StartUp = new EnumSelection<StartTask>(StartTask.Manual);
        //        Days = new EnumSelection<DayOfWeek>(default(DayOfWeek));
        //        Options = new EnumSelection<AdditionalOptions>(AdditionalOptions.None, true, AdditionalOptions.None);
        //    }

        //    public EnumSelection<StartTask> StartUp { get; private set; }
        //    public EnumSelection<DayOfWeek> Days { get; private set; }
        //    public EnumSelection<AdditionalOptions> Options { get; private set; }
        //}

        //        <StackPanel Orientation = "Vertical" >
        //  < StackPanel Orientation="Horizontal">
        //    <!-- Using RadioButtons for exactly 1 selection behavior -->
        //    <RadioButton IsChecked = "{Binding StartUp[Manual]}" > Manual </ RadioButton >
        //    < RadioButton IsChecked="{Binding StartUp[Automatic]}">Automatic</RadioButton>
        //  </StackPanel>
        //  <StackPanel Orientation = "Horizontal" >
        //    < !--Using CheckBoxes for 0 or Many selection behavior -->
        //    <CheckBox IsChecked = "{Binding Days[Sunday]}" > Sunday </ CheckBox >
        //    < CheckBox IsChecked="{Binding Days[Monday]}">Monday</CheckBox>
        //    <CheckBox IsChecked = "{Binding Days[Tuesday]}" > Tuesday </ CheckBox >
        //    < CheckBox IsChecked="{Binding Days[Wednesday]}">Wednesday</CheckBox>
        //    <CheckBox IsChecked = "{Binding Days[Thursday]}" > Thursday </ CheckBox >
        //    < CheckBox IsChecked="{Binding Days[Friday]}">Friday</CheckBox>
        //    <CheckBox IsChecked = "{Binding Days[Saturday]}" > Saturday </ CheckBox >
        //  </ StackPanel >
        //  < StackPanel Orientation="Horizontal">
        //    <!-- Using CheckBoxes for 0 or 1 selection behavior -->
        //    <CheckBox IsChecked = "{Binding Options[OptionA]}" > Option A</CheckBox>
        //    <CheckBox IsChecked = "{Binding Options[OptionB]}" > Option B</CheckBox>
        //  </StackPanel>
        //</StackPanel>
    }
}
