// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashReportProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Threading.Tasks;

    public interface ICrashReportProvider
    {
        #region Properties
        string Title { get; }
        #endregion

        #region Methods
        Task SendCrashReportAsync(CrashReport crashReport, string fileToAttach);
        #endregion
    }
}