// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using Catel;
    using Extensions;

    public class ExceptionInfo : CrashInfoBase
    {
        #region Constructors
        public ExceptionInfo(CrashReport crashReport)
            : base(CrashDetails.ExceptionDetailsTitle, crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            FullExceptionText = crashReport.Exception.GetExceptionInfo();
        }
        #endregion

        #region Properties
        public string FullExceptionText { get; private set; }
        #endregion
    }
}