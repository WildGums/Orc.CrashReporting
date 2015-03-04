// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfoService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ICrashInfoService
    {
        #region Methods
        void AddCrashInfo<T>() 
            where T : ICrashInfo;

        IEnumerable<ICrashInfo> GetAllCrashInfos(CrashReport crashReport);
        #endregion
    }
}