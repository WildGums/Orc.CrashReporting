// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfoService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;

    public interface ICrashInfoService
    {
        #region Methods
        void AddCrashInfo<T>()
            where T : ICrashInfo;

        IEnumerable<ICrashInfo> GetAllCrashInfos();
        #endregion
    }
}