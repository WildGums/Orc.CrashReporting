// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionInfo.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.IO;
    using Catel;
    using Orc.SupportPackage;

    public class ExceptionInfo : CrashInfoBase
    {
        #region Fields
        private readonly Exception _exception;
        #endregion

        #region Constructors
        public ExceptionInfo(ICrashReportingContext crashReportingContext)
            : base(CrashDetails.ExceptionDetailsTitle)
        {
            Argument.IsNotNull("crashReportingContext", crashReportingContext);

            _exception = crashReportingContext.Exception;
            FullExceptionText = _exception.GetExceptionInfo();
        }
        #endregion

        #region Properties
        public string FullExceptionText { get; private set; }
        #endregion

        #region Methods
        public override void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull("supportPackageContext", supportPackageContext);

            var txtFile = supportPackageContext.GetFile("Exception.txt");

            var exception = _exception;
            File.WriteAllText(txtFile, exception.ToString());
        }
        #endregion
    }
}