// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfoInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Services;

    public class AdditionalInfoInfo : CrashInfoBase
    {
        public AdditionalInfoInfo(CrashReport crashReport)
            : base(CrashDetails.AdditionalInfo, crashReport)
        {
        }
    }
}