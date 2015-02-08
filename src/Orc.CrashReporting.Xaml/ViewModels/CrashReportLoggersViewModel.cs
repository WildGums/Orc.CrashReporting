// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportLoggersViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using Catel.MVVM;
    using Loggers;
    using Models;
    using Orc.SupportPackage;
    using Services;

    internal class CrashReportLoggersViewModel : ViewModelBase
    {
        #region Fields
        private readonly ICrashLoggerService _crashLoggerService;
        private readonly CrashReport _crashReport;
        private readonly ISupportPackageService _supportPackageService;
        #endregion

        #region Constructors
        public CrashReportLoggersViewModel(CrashReport crashReport, ICrashLoggerService crashLoggerService, ISupportPackageService supportPackageService)
        {
            _crashReport = crashReport;
            _crashLoggerService = crashLoggerService;
            _supportPackageService = supportPackageService;

            Loggers = new List<ICrashLogger>(_crashLoggerService.GetAllCrashLoggers());
        }
        #endregion

        #region Properties
        public IList<ICrashLogger> Loggers { get; private set; }
        public ICrashLogger SelectedLogger { get; set; }
        #endregion

        #region Methods
        private async void OnSelectedLoggerChanged()
        {
            if (SelectedLogger == null)
            {
                return;
            }

            using (var crashRportingContext = new CrashReportingContext())
            {
                var file = crashRportingContext.GetFile("SupportPackage.zip");
                if (await _supportPackageService.CreateSupportPackage(file))
                {
                    SelectedLogger.LogCrashReport(_crashReport, file);
                }
            }
        }
        #endregion
    }
}