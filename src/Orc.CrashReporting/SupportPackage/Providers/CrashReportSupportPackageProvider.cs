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
        #region Fields
        private readonly CrashReport _crashReport;
        #endregion

        #region Constructors
        public CrashReportSupportPackageProvider(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            _crashReport = crashReport;
        }
        #endregion

        #region Methods
        public override async Task Provide(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull(() => supportPackageContext);

            foreach (var crashInfo in _crashReport.CrashDetails)
            {
                crashInfo.ProvideSupportPackageData(supportPackageContext);
            }
        }
        #endregion
    }
}