// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedModulesInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using System.Collections.Generic;
    using Extensions;
    using Orc.SystemInfo;

    public class LoadedModulesInfo : CrashInfoBase
    {
        private readonly ISystemInfoService _systemInfoService;

        public LoadedModulesInfo(CrashReport crashReport, ISystemInfoService systemInfoService) : base(CrashDetails.LoadedModulesInfo, crashReport)
        {
            _systemInfoService = systemInfoService;

            Initialize();
        }

        private async void Initialize()
        {
            LoadedModules = new List<string>(await _systemInfoService.GetLoadedModules());
        }

        public IList<string> LoadedModules { get; private set; }
    }
}