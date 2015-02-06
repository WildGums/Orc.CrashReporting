// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using Catel;
    using Models;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        #region Fields
        private readonly ICrashReporterService _crashReporterService;
        private readonly ICrashReportFactory _crashReportFactory;
        #endregion

        #region Constructors
        public ExceptionHandlerService(ICrashReporterService crashReporterService, ICrashReportFactory crashReportFactory)
        {
            Argument.IsNotNull(() => crashReportFactory);

            _crashReporterService = crashReporterService;
            _crashReportFactory = crashReportFactory;
        }
        #endregion

        #region Methods
        public void HandleException(Exception exception, ExceptionHandlingPolicy policy)
        {
            var crashReport = _crashReportFactory.CreateCrashReport(exception);
            _crashReporterService.ShowCrashReport(crashReport);
        }
        #endregion
    }
}