// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Example.ViewModels
{
    using System;
    using Catel.MVVM;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors
        public MainWindowViewModel()
        {
            ThrowException = new Command(OnThrowExceptionExecute);
        }
        #endregion

        #region Commands
        public Command ThrowException { get; private set; }

        private async void OnThrowExceptionExecute()
        {
            try
            {
                throw new NotImplementedException("Inner exception message");
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Exception message", exception);
            }
        }
        #endregion
    }
}