// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using Models;

    public interface ICrashReportService
    {
        CrashReport CreateCrashReport(Exception exception);
    }
}