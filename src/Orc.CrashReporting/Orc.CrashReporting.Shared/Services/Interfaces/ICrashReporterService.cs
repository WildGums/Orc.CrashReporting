// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReporterService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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