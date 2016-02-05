// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfo.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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