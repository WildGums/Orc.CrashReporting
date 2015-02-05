// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReport.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System;
    using System.Collections.Generic;
    using Catel;
    using Catel.Data;
    using Services;

    public class CrashReport : ModelBase
    {
        #region Constructors
        public CrashReport(Exception exception, ICrashInfoProvider crashInfoProvider)
        {
            Argument.IsNotNull(() => exception);
            Argument.IsNotNull(() => crashInfoProvider);

            Exception = exception;

            var infos = crashInfoProvider.ResolveAllCrashInfos(this);
            CrashDetails = new List<ICrashInfo>(infos);
        }
        #endregion

        #region Properties
        public IList<ICrashInfo> CrashDetails { get; private set; }
        public Exception Exception { get; private set; }

        public string Message
        {
            get { return Exception.Message; }
        }
        #endregion
    }
}