// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProviderMenuService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using Catel.MVVM;
    using Models;

    public class CrashReportProviderMenuService : ICrashReportProviderMenuService
    {
        private readonly ICrashReportProvidersService _crashReportProvidersService;
        private readonly ICrashReportingContext _crashReportingContext;

        public CrashReportProviderMenuService(ICrashReportProvidersService crashReportProvidersService, ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull(() => crashReportProvidersService);
            Argument.IsNotNull(() => crashReportingContext);

            _crashReportProvidersService = crashReportProvidersService;
            _crashReportingContext = crashReportingContext;

            CrashReportProviders = GetCrashReporterProviders().ToArray();
        }

        private IEnumerable<CrashReportProviderMenuItem> GetCrashReporterProviders()
        {
            return _crashReportProvidersService.GetAllCrashReportProviders().Select(provider =>
            {
                var menuItem = new CrashReportProviderMenuItem();
                menuItem.Title = provider.Title;
                menuItem.Command = new TaskCommand(() =>
                {
                    return provider.SendCrashReportAsync(_crashReportingContext.CrashReport, _crashReportingContext.SupportFackageFile);
                });
                menuItem.Provider = provider;
                return menuItem;
            });
        }

        public IEnumerable<CrashReportProviderMenuItem> CrashReportProviders { get; private set; }
    }
}