// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfoDetails.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Services;

    public class AdditionalInfoDetails : CrashDetailsBase
    {
        public AdditionalInfoDetails(ICrashReporterManager crashReporterManager)
            : base(CrashDetails.AdditionalInfoDetails, crashReporterManager)
        {
        }
    }
}