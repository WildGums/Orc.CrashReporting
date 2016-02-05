// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportSupportPackageProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.SupportPackage.Providers
{
    using System.Threading.Tasks;
    using Catel;
    using Orc.SupportPackage;

    public class CrashReportSupportPackageProvider : SupportPackageProviderBase
    {
        #region Fields
        private readonly CrashReport _crashReport;
        #endregion

        #region Constructors
        public CrashReportSupportPackageProvider(ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull("crashReportingContext", crashReportingContext);

            _crashReport = crashReportingContext.CrashReport;
        }
        #endregion

        #region Methods
        public override async Task ProvideAsync(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull("supportPackageContext", supportPackageContext);

            foreach (var crashInfo in _crashReport.CrashDetails)
            {
                crashInfo.ProvideSupportPackageData(supportPackageContext);
            }
        }
        #endregion
    }
}