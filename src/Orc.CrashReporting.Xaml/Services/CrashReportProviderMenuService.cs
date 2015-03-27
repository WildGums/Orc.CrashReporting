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
        }

        public IEnumerable<CrashReportProviderMenuItem> GetCrashReporterProviders()
        {
            return _crashReportProvidersService.GetAllCrashReportProviders().Select(x =>
            {
                var menuItem = new CrashReportProviderMenuItem();
                menuItem.Title = x.Title;
                menuItem.Command = new Command(() =>
                {
                    x.SendCrashReport(_crashReportingContext.CrashReport, _crashReportingContext.SupportFackageFile);
                });
                return menuItem;
            });
        }
    }
}