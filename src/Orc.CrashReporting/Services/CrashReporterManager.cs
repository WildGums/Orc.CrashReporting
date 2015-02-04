// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterManager.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using Models;

    public class CrashReporterManager : ICrashReporterManager
    {
        public CrashReporterManager()
        {
            CrashReporter = new CrashReporter();
        }

        #region Properties
        public CrashReporter CrashReporter { get; private set; }
        #endregion
    }
}