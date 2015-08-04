// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using Catel;
    using Catel.Services;
    using ViewModels;

    internal class CrashReporterService : ICrashReporterService
    {
        #region Fields
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public CrashReporterService(IUIVisualizerService uiVisualizerService)
        {
            Argument.IsNotNull(() => uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;
        }
        #endregion

        #region Methods
        public void ShowCrashReport(Exception exception)
        {
            _uiVisualizerService.ShowDialog<CrashReportViewModel>();
        }
        #endregion
    }
}