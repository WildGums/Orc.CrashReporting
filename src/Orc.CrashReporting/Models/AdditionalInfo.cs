// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.IO;
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
            var file = supportPackageContext.GetFile("AdditionalInfo.txt");

            File.WriteAllText(file, Text);
        }
    }
}