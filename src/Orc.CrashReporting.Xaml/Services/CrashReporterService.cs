// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using Catel;
    using Catel.IoC;
    using Catel.Services;
    using Models;
    using ViewModels;

    internal class CrashReporterService : ICrashReporterService
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public CrashReporterService(IUIVisualizerService uiVisualizerService, ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => typeFactory);

            _uiVisualizerService = uiVisualizerService;
            _typeFactory = typeFactory;
        }
        #endregion

        #region Methods
        public void ShowCrashReport(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            var crashReporterVm = _typeFactory.CreateInstanceWithParametersAndAutoCompletion<CrashReportViewModel>(crashReport);
            _uiVisualizerService.ShowDialog(crashReporterVm);
        }
        #endregion
    }
}