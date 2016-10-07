// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Threading.Tasks;
    using Catel;
    using Catel.Services;
    using ViewModels;

    internal class CrashReporterService : ICrashReporterService
    {
        #region Fields
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IDispatcherService _dispatcherService;
        #endregion

        #region Constructors
        public CrashReporterService(IUIVisualizerService uiVisualizerService, IDispatcherService dispatcherService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => dispatcherService);

            _uiVisualizerService = uiVisualizerService;
            _dispatcherService = dispatcherService;
        }
        #endregion

        #region Methods
        public Task ShowCrashReportAsync(ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull(() => crashReportingContext);

            return _dispatcherService.InvokeAsync(() => _uiVisualizerService.ShowDialogAsync<CrashReportViewModel>(crashReportingContext));
        }
        #endregion
    }
}