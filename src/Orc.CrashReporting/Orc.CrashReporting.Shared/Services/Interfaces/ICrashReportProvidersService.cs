// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportProvidersService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;

    public interface ICrashReportProvidersService
    {
        #region Methods
        IEnumerable<ICrashReportProvider> GetAllCrashReportProviders();
        #endregion
    }
}