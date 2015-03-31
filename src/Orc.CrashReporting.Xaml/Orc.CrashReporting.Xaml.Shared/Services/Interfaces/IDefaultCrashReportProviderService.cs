// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDefaultCrashReportProviderService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    public interface IDefaultCrashReportProviderService
    {
        ICrashReportProvider GetDefaultCrashReportProvider();
    }
}