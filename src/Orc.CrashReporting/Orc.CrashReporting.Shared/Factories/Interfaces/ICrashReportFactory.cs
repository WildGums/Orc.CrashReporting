// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportFactory.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;

    public interface ICrashReportFactory
    {
        #region Methods
        CrashReport CreateCrashReport(Exception exception);
        #endregion
    }
}