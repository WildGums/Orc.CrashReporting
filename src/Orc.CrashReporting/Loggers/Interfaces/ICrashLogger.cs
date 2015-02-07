// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashLogger.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Reporters
{
    using System;
    using Models;

    public interface ICrashLogger
    {
        #region Properties
        string Title { get; }
        #endregion

        #region Methods
        void Report(CrashReport exception, string fileToAttach);
        #endregion
    }
}