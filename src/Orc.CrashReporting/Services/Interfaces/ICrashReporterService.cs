// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReporterService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using Models;

    public interface ICrashReporterService
    {
        #region Methods
        void ShowCrashReport(CrashReport crashReport);
        #endregion
    }
}