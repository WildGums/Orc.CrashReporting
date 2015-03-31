// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultCrashReportProviderService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Services
{
    using System.Linq;
    using Catel;

    internal class DefaultCrashReportProviderService : IDefaultCrashReportProviderService
    {
        private readonly ICrashReportProvidersService _crashReportProvidersService;

        public DefaultCrashReportProviderService(ICrashReportProvidersService crashReportProvidersService)
        {
            Argument.IsNotNull(() => crashReportProvidersService);

            _crashReportProvidersService = crashReportProvidersService;
        }

        public ICrashReportProvider GetDefaultCrashReportProvider()
        {
            return _crashReportProvidersService.GetAllCrashReportProviders().FirstOrDefault();
        }
    }
}