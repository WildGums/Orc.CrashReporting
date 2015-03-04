// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.IO;
    using Catel;
    using Orc.SupportPackage;

    public class ExceptionInfo : CrashInfoBase
    {
        #region Fields
        private readonly CrashReport _crashReport;
        #endregion

        #region Constructors
        public ExceptionInfo(CrashReport crashReport)
            : base(CrashDetails.ExceptionDetailsTitle, crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            _crashReport = crashReport;
            
            FullExceptionText = crashReport.Exception.GetExceptionInfo();
        }
        #endregion

        #region Properties
        public string FullExceptionText { get; private set; }
        #endregion

        #region Methods
        public override void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull(() => supportPackageContext);

            var txtFile = supportPackageContext.GetFile("Exception.txt");

            var exception = _crashReport.Exception;
            File.WriteAllText(txtFile, exception.ToString());
        }
        #endregion
    }
}