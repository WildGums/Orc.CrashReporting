// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportingContext.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;

    public interface ICrashReportingContext : IDisposable
    {
        #region Properties
        CrashReport CrashReport { get; }
        Exception Exception { get; }
        string SupportFackageFile { get; }
        #endregion

        #region Methods
        string RegisterSupportPackageFile(string relativeFilePath);
        void RegisterException(Exception exception);
        #endregion
    }
}