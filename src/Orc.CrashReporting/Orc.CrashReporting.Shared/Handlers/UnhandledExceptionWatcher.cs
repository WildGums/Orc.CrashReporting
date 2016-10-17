// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnhandledExceptionWatcher.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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
#pragma warning disable AvoidAsyncVoid
        private async void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
#pragma warning restore AvoidAsyncVoid
        {
            if (e.Observed)
            {
                return;
            }

            try
            {
                var exception = e.Exception;

                await HandleExceptionAsync(exception);

                e.SetObserved();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

#pragma warning disable AvoidAsyncVoid
        private async void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
#pragma warning restore AvoidAsyncVoid
        {
            if (e.Handled)
            {
                return;
            }

            // Don't exit yet
            e.Handled = true;

            try
            {
                var exception = e.Exception;

                // Note: force wait (don't allow app to exit)
                await HandleExceptionAsync(exception);
                
                // TODO: Now we can exit...
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

                // TODO: how to ensure that we will not exit?
                var task = HandleExceptionAsync(exception);
                task.Wait();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private Task HandleExceptionAsync(Exception exception)
        {
            Log.Error(exception);

            return _exceptionHandlerService.HandleExceptionAsync(exception);
        }
        #endregion
    }
}