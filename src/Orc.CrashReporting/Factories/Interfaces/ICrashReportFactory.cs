// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportFactory.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using Models;

    public interface ICrashReportFactory
    {
        #region Methods
        CrashReport CreateCrashReport(Exception exception);
        #endregion
    }
}