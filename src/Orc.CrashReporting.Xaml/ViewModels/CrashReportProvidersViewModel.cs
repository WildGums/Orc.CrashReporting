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
        private readonly CrashReport _crashReport;
        private readonly ICrashReportingContext _crashReportingContext;
        private readonly ICrashReportProvidersService _crashReportProvidersService;
        private readonly ISupportPackageService _supportPackageService;
        #endregion

        #region Constructors
        public CrashReportProvidersViewModel(ICrashReportProvidersService crashReportProvidersService, 
            ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull(() => crashReportProvidersService);
            Argument.IsNotNull(() => crashReportingContext);

            _crashReportProvidersService = crashReportProvidersService;
            _crashReportingContext = crashReportingContext;
            _crashReport = _crashReportingContext.CrashReport;

            CrashReportProviders = new List<ICrashReportProvider>(_crashReportProvidersService.GetAllCrashReportProviders());
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

            var supportFackageFile = _crashReportingContext.SupportFackageFile;

            SelectedReportProvider.SendCrashReport(_crashReport, supportFackageFile);

            await CloseViewModel(null);
        }
        #endregion
    }
}