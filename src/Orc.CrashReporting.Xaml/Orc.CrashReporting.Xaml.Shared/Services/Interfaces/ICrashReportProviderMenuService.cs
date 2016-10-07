// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportProviderMenuService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using Models;

    public interface ICrashReportProviderMenuService
    {
        IEnumerable<CrashReportProviderMenuItem> CrashReportProviders { get; }
    }
}