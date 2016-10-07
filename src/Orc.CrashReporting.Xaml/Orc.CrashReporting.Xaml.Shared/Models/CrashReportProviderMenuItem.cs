// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProviderMenuItem.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.Windows.Input;

    public class CrashReportProviderMenuItem
    {
        public ICommand Command { get; set; }
        public string Title { get; set; }
        public ICrashReportProvider Provider { get; set; }
    }
}