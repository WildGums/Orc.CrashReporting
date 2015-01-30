// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Example.ViewModels
{
    using Catel;
    using Catel.MVVM;
    using Catel.Services;
    using CrashReporting.ViewModels;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            Argument.IsNotNull(() => uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;
            ShowCrashReport = new Command(OnShowCrashReportExecute);
        }
        #endregion

        #region Commands
        public Command ShowCrashReport { get; private set; }

        private async void OnShowCrashReportExecute()
        {
            await _uiVisualizerService.ShowDialog<CrashReportViewModel>();
        }
        #endregion
    }
}