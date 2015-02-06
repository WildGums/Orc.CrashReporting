// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedModulesInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.Collections.Generic;
    using Catel;
    using Extensions;
    using Orc.SystemInfo;

    public class LoadedModulesInfo : CrashInfoBase
    {
        #region Fields
        private readonly ISystemInfoService _systemInfoService;
        #endregion

        #region Constructors
        public LoadedModulesInfo(CrashReport crashReport, ISystemInfoService systemInfoService) : base(CrashDetails.LoadedModulesInfo, crashReport)
        {
            Argument.IsNotNull(() => systemInfoService);

            _systemInfoService = systemInfoService;

            Initialize();
        }
        #endregion

        #region Properties
        public IList<string> LoadedModules { get; private set; }
        #endregion

        #region Methods
        private async void Initialize()
        {
            LoadedModules = new List<string>(await _systemInfoService.GetLoadedModules());
        }
        #endregion
    }
}