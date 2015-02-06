using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Orc.CrashReporting.Example
{
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Threading;
    using Catel.IoC;
    using Models;
    using Services;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Current.DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;

            var serviceLocator = this.GetServiceLocator();
            var exceptionHandlerService = serviceLocator.ResolveType<IExceptionHandlerService>();

            exceptionHandlerService.HandleException(exception, new ExceptionHandlingPolicy());
            e.Handled = true;
        }

        void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {            

            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                return;
            }

            var serviceLocator = this.GetServiceLocator();
            var exceptionHandlerService = serviceLocator.ResolveType<IExceptionHandlerService>();

            exceptionHandlerService.HandleException(exception, new ExceptionHandlingPolicy());
        }
    }
}
