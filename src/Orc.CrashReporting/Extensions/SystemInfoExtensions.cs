// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using SystemInfo;
    using Catel;

    public static class SystemInfoExtensions
    {
        #region Methods
        public static async Task<IEnumerable<string>> GetLoadedModules(this ISystemInfoService systemInfoService)
        {
            Argument.IsNotNull(() => systemInfoService);

            return await Task.Factory.StartNew(() => GetLoadedModules());
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