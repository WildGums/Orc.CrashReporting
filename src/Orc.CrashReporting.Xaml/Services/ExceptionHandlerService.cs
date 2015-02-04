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
    using ViewModels;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly ITypeFactory _typeFactory;

        public ExceptionHandlerService(IUIVisualizerService uiVisualizerService, ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => typeFactory);

            _uiVisualizerService = uiVisualizerService;
            _typeFactory = typeFactory;
        }

        public void HandleException(Exception exception, ExceptionHandlingPolicy policy)
        {
            var crashReporterVm = (CrashReportViewModel)_typeFactory.CreateInstanceWithParametersAndAutoCompletion(typeof (CrashReportViewModel), exception);
            _uiVisualizerService.ShowDialog(crashReporterVm);
        }
    }
}