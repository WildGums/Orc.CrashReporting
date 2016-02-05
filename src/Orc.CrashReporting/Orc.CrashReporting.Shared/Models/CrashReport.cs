// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReport.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using Catel.Data;
    using Services;

    public class CrashReport : ModelBase
    {
        #region Constructors
        public CrashReport(Exception exception, ICrashInfoService crashInfoService)
        {
            Argument.IsNotNull("exception", exception);
            Argument.IsNotNull("crashInfoService", crashInfoService);

            Message = exception.Message;

            var infos = crashInfoService.GetAllCrashInfos();
            CrashDetails = new List<ICrashInfo>(infos);
        }
        #endregion

        #region Properties
        public IList<ICrashInfo> CrashDetails { get; private set; }
        public IEnumerable<ICrashInfo> CrashDetailsToDisplay
        {
            get { return CrashDetails.Where(x => x.GetType() != typeof(AdditionalInfo)); }
        }
        public string Message { get; private set; }
        #endregion
    }
}