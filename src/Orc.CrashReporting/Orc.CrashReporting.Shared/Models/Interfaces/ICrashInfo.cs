// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Orc.SupportPackage;

    public interface ICrashInfo
    {
        #region Properties
        string Title { get; }
        #endregion

        #region Methods
        void ProvideSupportPackageData(ISupportPackageContext supportPackageContext);
        #endregion
    }
}