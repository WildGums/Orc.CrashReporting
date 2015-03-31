// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportingContext.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
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
        string RegisterSupportFackageFile(string relativeFilePath);
        void RegisterException(Exception exception);
        #endregion
    }
}