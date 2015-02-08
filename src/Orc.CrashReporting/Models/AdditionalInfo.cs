// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using Orc.SupportPackage;

    public class AdditionalInfo : CrashInfoBase
    {
        #region Constructors
        public AdditionalInfo(CrashReport crashReport)
            : base(CrashDetails.AdditionalInfo, crashReport)
        {
        }
        #endregion

        public string Text { get; set; }

        public override void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
            base.ProvideSupportPackageData(supportPackageContext);
        }
    }
}