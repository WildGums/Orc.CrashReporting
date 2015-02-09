// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using Catel;
    using Catel.IoC;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        #region Fields
        private ICrashReporterService _crashReporterService;
        private readonly ICrashReportFactory _crashReportFactory;
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        public ExceptionHandlerService(IServiceLocator serviceLocator, ICrashReportFactory crashReportFactory)
        {
            Argument.IsNotNull(() => serviceLocator);
            Argument.IsNotNull(() => crashReportFactory);

            _serviceLocator = serviceLocator;
            _crashReportFactory = crashReportFactory;
        }
        #endregion

        #region Properties
        private ICrashReporterService CrashReporterService
        {
            get
            {
                if (_crashReporterService == null)
                {
                    // can't be injected, because the inplementation could be registered later
                    _crashReporterService = _serviceLocator.ResolveType<ICrashReporterService>();
                }

                return _crashReporterService;
            }
        }
        #endregion

        #region Methods
        public void HandleException(Exception exception)
        {
            var crashReport = _crashReportFactory.CreateCrashReport(exception);
            CrashReporterService.ShowCrashReport(crashReport);
        }
        #endregion
    }
}