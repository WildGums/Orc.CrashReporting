// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Example.ViewModels
{
    using System;
    using System.Threading;
    using Catel.MVVM;
    using Catel.Threading;

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

        private void OnThrowExceptionExecute()
        {
            // Note: Use a separate thread to test exceptions from a non-ui thread
            TaskHelper.Run(() =>
            {
                try
                {
                    throw new NotImplementedException("Inner exception message");
                }
                catch (Exception exception)
                {
                    throw new InvalidOperationException("Exception message", exception);
                }
            }, false, CancellationToken.None);
        }
        #endregion
    }
}