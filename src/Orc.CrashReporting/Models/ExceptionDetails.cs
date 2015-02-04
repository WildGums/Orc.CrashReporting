// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionDetails.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Catel.Data;
    using Services;

    public class ExceptionDetails : CrashDetailsBase
    {
        public ExceptionDetails(ICrashReporterManager crashReporterManager)
            : base(CrashDetails.ExceptionDetails, crashReporterManager)
        {
        }
    }
}