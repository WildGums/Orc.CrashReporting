// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportProviderMenuService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using Models;

    public interface ICrashReportProviderMenuService
    {
        IEnumerable<CrashReportProviderMenuItem> GetCrashReporterProviders();
    }
}