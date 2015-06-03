// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Catel;
    using Catel.Threading;
    using Orc.SystemInfo;

    public static class SystemInfoExtensions
    {
        #region Methods
        public static Task<IEnumerable<string>> GetLoadedModules(this ISystemInfoService systemInfoService)
        {
            Argument.IsNotNull("systemInfoService", systemInfoService);

            return TaskHelper.Run(() => GetLoadedModules());
        }

        private static IEnumerable<string> GetLoadedModules()
        {
            var currentProcess = Process.GetCurrentProcess();

            return from ProcessModule module in currentProcess.Modules
                   select string.Format("{0} {1}", module.FileName, module.FileVersionInfo.FileVersion);
        }
        #endregion
    }
}