﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportSupportPackageProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.SupportPackage.Providers
{
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
        public override void Provide(ISupportPackageContext supportPackageContext)
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