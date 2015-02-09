// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportLoggersViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using Catel;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.MVVM;
    using Loggers;
    using Models;
    using Orc.SupportPackage;
    using Services;

    internal class CrashReportLoggersViewModel : ViewModelBase
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ICrashLoggerService _crashLoggerService;
        private readonly CrashReport _crashReport;
        private readonly IServiceLocator _serviceLocator;
        private readonly ISupportPackageService _supportPackageService;
        #endregion

        #region Constructors
        public CrashReportLoggersViewModel(CrashReport crashReport, ICrashLoggerService crashLoggerService, ISupportPackageService supportPackageService, IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => crashReport);
            Argument.IsNotNull(() => crashLoggerService);
            Argument.IsNotNull(() => supportPackageService);
            Argument.IsNotNull(() => serviceLocator);

            _crashReport = crashReport;
            _crashLoggerService = crashLoggerService;
            _supportPackageService = supportPackageService;
            _serviceLocator = serviceLocator;

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

            using (var crashRportingContext = _serviceLocator.ResolveType<ICrashReportingContext>())
            {
                var file = crashRportingContext.GetFile("SupportPackage.zip");
                if (await _supportPackageService.CreateSupportPackage(file))
                {
                    SelectedLogger.LogCrashReport(_crashReport, file);
                }
            }

            await CloseViewModel(null);
        }
        #endregion
    }
}