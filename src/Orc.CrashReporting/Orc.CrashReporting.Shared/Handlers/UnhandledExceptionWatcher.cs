// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnhandledExceptionWatcher.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using Catel;
    using Catel.Logging;
    using Services;

    public class UnhandledExceptionWatcher
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IExceptionHandlerService _exceptionHandlerService;
        #endregion

        #region Constructors
        public UnhandledExceptionWatcher(IExceptionHandlerService exceptionHandlerService)
        {
            Argument.IsNotNull("exceptionHandlerService", exceptionHandlerService);

            _exceptionHandlerService = exceptionHandlerService;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Dispatcher.CurrentDispatcher.UnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }
        #endregion

        #region Methods
        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                var exception = e.Exception;

                HandleException(exception);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.Exception;

                HandleException(exception);

                e.Handled = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = (Exception) e.ExceptionObject;

                HandleException(exception);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void HandleException(Exception exception)
        {
            Log.Error(exception);
            _exceptionHandlerService.HandleException(exception);
        }
        #endregion
    }
}