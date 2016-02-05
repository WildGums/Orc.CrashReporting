// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfo.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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