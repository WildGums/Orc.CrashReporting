// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDefaultCrashReportProviderService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    public interface IDefaultCrashReportProviderService
    {
        ICrashReportProvider GetDefaultCrashReportProvider();
    }
}