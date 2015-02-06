// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnhandledCatcher.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using Catel;
    using Catel.IoC;
    using Models;
    using Services;

    public class UnhandledCatcher
    {
        #region Fields
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        public UnhandledCatcher(IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => serviceLocator);

            _serviceLocator = serviceLocator;

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Dispatcher.CurrentDispatcher.UnhandledException += OnDispatcherUnhandledException;
        }
        #endregion

        #region Methods
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;

            var exceptionHandlerService = _serviceLocator.ResolveType<IExceptionHandlerService>();

            exceptionHandlerService.HandleException(exception, new ExceptionHandlingPolicy());
            e.Handled = true;
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                return;
            }

            var exceptionHandlerService = _serviceLocator.ResolveType<IExceptionHandlerService>();

            exceptionHandlerService.HandleException(exception, new ExceptionHandlingPolicy());
        }
        #endregion
    }
}