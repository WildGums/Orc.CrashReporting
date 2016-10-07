// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Example.ViewModels
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Catel.MVVM;
    using Catel.Threading;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors
        public MainWindowViewModel()
        {
            ThrowException = new Command(OnThrowExceptionExecute);
            ThrowExceptionInTask = new Command(OnThrowExceptionInTaskExecute);
        }
        #endregion

        #region Commands
        public Command ThrowException { get; private set; }

        private void OnThrowExceptionExecute()
        {
            BrokenMethod();
        }

        public Command ThrowExceptionInTask { get; private set; }

        private async void OnThrowExceptionInTaskExecute()
        {
            // Note: Use a separate thread to test exceptions from a non-ui thread. This is *not*
            // a TaskCommand because that catches exceptions for us

            //await TaskHelper.Run(() =>
            //{
            //    BrokenMethod();
            //}, true, CancellationToken.None);

            await Task.Factory.StartNew(() => BrokenMethod());
        }
        #endregion

        #region Methods
        private void BrokenMethod()
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