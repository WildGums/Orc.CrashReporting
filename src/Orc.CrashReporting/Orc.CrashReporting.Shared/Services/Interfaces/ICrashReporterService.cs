// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReporterService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;

    public interface ICrashReporterService
    {
        #region Methods
        void ShowCrashReport(Exception exception);
        #endregion
    }
}