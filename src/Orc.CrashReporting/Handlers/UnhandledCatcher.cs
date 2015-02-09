// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnhandledCatcher.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Windows.Threading;
    using Catel;
    using Services;

    public class UnhandledCatcher
    {
        #region Fields
        private readonly IExceptionHandlerService _exceptionHandlerService;
        #endregion

        #region Constructors
        public UnhandledCatcher(IExceptionHandlerService exceptionHandlerService)
        {
            Argument.IsNotNull(() => exceptionHandlerService);

            _exceptionHandlerService = exceptionHandlerService;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Dispatcher.CurrentDispatcher.UnhandledException += OnDispatcherUnhandledException;
        }
        #endregion

        #region Methods
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;

            _exceptionHandlerService.HandleException(exception);
            e.Handled = true;
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                return;
            }

            _exceptionHandlerService.HandleException(exception);
        }
        #endregion
    }
}