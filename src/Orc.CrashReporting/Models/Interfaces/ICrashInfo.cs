﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using Orc.SupportPackage;

    public interface ICrashInfo
    {
        void ProvideSupportPackageData(ISupportPackageContext supportPackageContext);
        #region Properties
        string Title { get; }
        #endregion
    }
}