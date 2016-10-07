// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Catel;
    using Orc.SystemInfo;

    public static class SystemInfoExtensions
    {
        #region Methods
        public static IEnumerable<string> GetLoadedModules(this ISystemInfoService systemInfoService)
        {
            Argument.IsNotNull(() => systemInfoService);

            var currentProcess = Process.GetCurrentProcess();

            return from ProcessModule module in currentProcess.Modules
                   select $"{module.FileName} {module.GetFileVersion()}";
        }
        #endregion        
    }
}