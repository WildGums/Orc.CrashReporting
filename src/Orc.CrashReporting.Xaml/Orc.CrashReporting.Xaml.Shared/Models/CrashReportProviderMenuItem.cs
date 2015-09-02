// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProviderMenuItem.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
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