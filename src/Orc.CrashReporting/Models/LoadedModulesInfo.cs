// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedModulesInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Catel;
    using Orc.SupportPackage;
    using Orc.SystemInfo;

    public class LoadedModulesInfo : CrashInfoBase
    {
        #region Fields
        private readonly ISystemInfoService _systemInfoService;
        #endregion

        #region Constructors
        public LoadedModulesInfo(ISystemInfoService systemInfoService)
            : base(CrashDetails.LoadedModulesInfo)
        {
            Argument.IsNotNull("systemInfoService", systemInfoService);

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

        public override void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
            Argument.IsNotNull("supportPackageContext", supportPackageContext);

            var loadedModules = LoadedModules.Aggregate(string.Empty, (s, assembly) => s += string.Format("{0}\n", assembly));

            if (string.IsNullOrWhiteSpace(loadedModules))
            {
                return;
            }

            var file = supportPackageContext.GetFile("LoadedModules.txt");

            File.WriteAllText(file, loadedModules);
        }
        #endregion
    }
}