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
        #region Methods
        string GetFile(string relativeFilePath);
        #endregion
    }
}