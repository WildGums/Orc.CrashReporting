// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Example.ViewModels
{
    using System;
    using Catel;
    using Catel.MVVM;
    using Services;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IExceptionHandlerService _exceptionHandlerService;
        #endregion

        #region Constructors
        public MainWindowViewModel(IExceptionHandlerService exceptionHandlerService)
        {
            Argument.IsNotNull(() => exceptionHandlerService);
            _exceptionHandlerService = exceptionHandlerService;

            ShowCrashReport = new Command(OnShowCrashReportExecute);
        }
        #endregion

        #region Commands
        public Command ShowCrashReport { get; private set; }

        private async void OnShowCrashReportExecute()
        {
            _exceptionHandlerService.HandleException(new NotImplementedException("message"), new ExceptionHandlingPolicy());
        }
        #endregion
    }
}