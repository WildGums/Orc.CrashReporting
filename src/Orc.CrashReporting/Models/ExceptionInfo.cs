// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionDetailsTitle.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Catel.Data;
    using Catel.IoC;
    using Services;

    public class ExceptionInfo : CrashInfoBase
    {
        public ExceptionInfo(CrashReport crashReport)
            : base(CrashDetails.ExceptionDetailsTitle, crashReport)
        {
            FullExceptionText = crashReport.Exception.ToString();
        }

        public string FullExceptionText { get; private set; }
    }
}