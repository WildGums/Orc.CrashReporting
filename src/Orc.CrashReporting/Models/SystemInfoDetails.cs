// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoDetails.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Services;

    public class SystemInfoDetails : CrashDetailsBase
    {
        public SystemInfoDetails(ICrashReporterManager crashReporterManager)
            : base(CrashDetails.SystenInfoDetails, crashReporterManager)
        {
        }
    }
}