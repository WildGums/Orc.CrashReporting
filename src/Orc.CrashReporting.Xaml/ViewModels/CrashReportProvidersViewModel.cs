// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProvidersViewModel.cs" company="Wild Gums">
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
    using Orc.SupportPackage;
    using Services;

    internal class CrashReportProvidersViewModel : ViewModelBase
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ICrashLoggerService _crashLoggerService;
        private readonly CrashReport _crashReport;
        private readonly IServiceLocator _serviceLocator;
        private readonly ISupportPackageService _supportPackageService;
        #endregion

        #region Constructors
        public CrashReportProvidersViewModel(CrashReport crashReport, ICrashLoggerService crashLoggerService, ISupportPackageService supportPackageService, IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => crashReport);
            Argument.IsNotNull(() => crashLoggerService);
            Argument.IsNotNull(() => supportPackageService);
            Argument.IsNotNull(() => serviceLocator);

            _crashReport = crashReport;
            _crashLoggerService = crashLoggerService;
            _supportPackageService = supportPackageService;
            _serviceLocator = serviceLocator;

            CrashReportProviders = new List<ICrashReportProvider>(_crashLoggerService.GetAllCrashLoggers());
        }
        #endregion

        #region Properties
        public IList<ICrashReportProvider> CrashReportProviders { get; private set; }
        public ICrashReportProvider SelectedReportProvider { get; set; }
        #endregion

        #region Methods
        private async void OnSelectedReportProviderChanged()
        {
            if (SelectedReportProvider == null)
            {
                return;
            }

            using (var crashRportingContext = _serviceLocator.ResolveType<ICrashReportingContext>())
            {
                var file = crashRportingContext.GetFile("SupportPackage.zip");
                if (await _supportPackageService.CreateSupportPackage(file))
                {
                    SelectedReportProvider.LogCrashReport(_crashReport, file);
                }
            }

            await CloseViewModel(null);
        }
        #endregion
    }
}