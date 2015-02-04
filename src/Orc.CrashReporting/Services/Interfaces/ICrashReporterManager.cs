// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReporterManager.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using Models;

    public interface ICrashReporterManager
    {
        #region Properties
        CrashReporter CrashReporter { get; }
        #endregion
    }
}