// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.IO;
    using Catel;
    using Orc.SupportPackage;

    public class AdditionalInfo : CrashInfoBase
    {
        #region Constructors
        public AdditionalInfo()
            : base(CrashDetails.AdditionalInfo)
        {
        }
        #endregion

        #region Properties
        public string Text { get; set; }
        #endregion

        #region Methods
        public override void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull("supportPackageContext", supportPackageContext);

            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }

            var file = supportPackageContext.GetFile("AdditionalInfo.txt");

            File.WriteAllText(file, Text);
        }
        #endregion
    }
}