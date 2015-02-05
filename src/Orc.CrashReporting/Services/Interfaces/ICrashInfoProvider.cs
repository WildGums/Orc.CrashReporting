// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrashInfoProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ICrashInfoProvider
    {
        #region Methods
        void RegisterCrashInfo<T>() where T : ICrashInfo;
        IEnumerable<ICrashInfo> ResolveAllCrashInfos(CrashReport crashReport);
        #endregion
    }
}