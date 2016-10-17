// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProvidersViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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
#pragma warning disable AvoidAsyncVoid
        private async void OnSelectedReportProviderChanged()
#pragma warning restore AvoidAsyncVoid
        {
            if (SelectedReportProvider == null)
            {
                return;
            }

            var supportFackageFile = _crashReportingContext.SupportFackageFile;

            await SelectedReportProvider.SendCrashReportAsync(_crashReport, supportFackageFile);

            await CloseViewModelAsync(null);
        }
        #endregion
    }
}