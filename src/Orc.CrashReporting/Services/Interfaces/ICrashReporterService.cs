// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReporterService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ICrashReporterService
    {
        #region Methods
        Task ShowCrashReport(Exception exception);
        #endregion
    }
}