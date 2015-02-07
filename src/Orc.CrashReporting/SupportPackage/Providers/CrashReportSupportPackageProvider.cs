// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportSupportPackageProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.SupportPackage.Providers
{
    using System.Threading.Tasks;
    using Catel;
    using Models;
    using Orc.SupportPackage;

    public class CrashReportSupportPackageProvider : SupportPackageProviderBase
    {
        private readonly CrashReport _crashReport;

        public CrashReportSupportPackageProvider(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            _crashReport = crashReport;
        }

        public async override Task Provide(ISupportPackageContext supportPackageContext)
        {
            foreach (var crashInfo in _crashReport.CrashDetails)
            {
                crashInfo.ProvideSupportPackageData(supportPackageContext);
            }
        }
    }
}