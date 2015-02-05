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
    using Catel.Services;
    using Models;
    using ViewModels;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly ITypeFactory _typeFactory;
        private readonly ICrashReportService _crashReportService;

        public ExceptionHandlerService(IUIVisualizerService uiVisualizerService, ITypeFactory typeFactory, ICrashReportService crashReportService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => typeFactory);
            Argument.IsNotNull(() => crashReportService);

            _uiVisualizerService = uiVisualizerService;
            _typeFactory = typeFactory;
            _crashReportService = crashReportService;
        }

        public void HandleException(Exception exception, ExceptionHandlingPolicy policy)
        {
            var crashReport = _crashReportService.CreateCrashReport(exception);
            var crashReporterVm = _typeFactory.CreateInstanceWithParametersAndAutoCompletion<CrashReportViewModel>(crashReport);
            _uiVisualizerService.ShowDialog(crashReporterVm);
        }
    }
}