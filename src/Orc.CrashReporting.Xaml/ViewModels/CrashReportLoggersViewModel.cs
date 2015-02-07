// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportLoggersViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Catel.MVVM;
    using Models;
    using Orc.SupportPackage;
    using Reporters;
    using Services;

    internal class CrashReportLoggersViewModel : ViewModelBase
    {
        private readonly CrashReport _crashReport;
        private readonly ICrashLoggerService _crashLoggerService;
        private readonly ISupportPackageService _supportPackageService;
        private readonly ICrashReportingContext _crashReportingContext;

        public CrashReportLoggersViewModel(CrashReport crashReport, ICrashLoggerService crashLoggerService, ISupportPackageService supportPackageService, ICrashReportingContext crashReportingContext)
        {
            _crashReport = crashReport;
            _crashLoggerService = crashLoggerService;
            _supportPackageService = supportPackageService;
            _crashReportingContext = crashReportingContext;

            Loggers = new List<ICrashLogger>(_crashLoggerService.GetAllCrashLoggers());
        }

        
        public IList<ICrashLogger> Loggers { get; private set; }

        public ICrashLogger SelectedLogger { get; set; }

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
                    SelectedLogger.Report(_crashReport, file);
                }
            }            
        }
    }
}