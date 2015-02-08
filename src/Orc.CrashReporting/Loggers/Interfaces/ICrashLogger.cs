// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashLogger.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Loggers
{
    using Models;

    public interface ICrashLogger
    {
        #region Properties
        string Title { get; }
        #endregion

        #region Methods
        void LogCrashReport(CrashReport crashReport, string fileToAttach);
        #endregion
    }
}