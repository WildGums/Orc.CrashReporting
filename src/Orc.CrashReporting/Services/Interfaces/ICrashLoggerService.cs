// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashLoggerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;

    public interface ICrashLoggerService
    {
        #region Methods
        IEnumerable<ICrashReportProvider> GetAllCrashLoggers();
        #endregion
    }
}