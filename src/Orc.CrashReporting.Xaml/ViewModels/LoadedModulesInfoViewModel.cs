// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedModulesInfoViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    public class LoadedModulesInfoViewModel : ViewModelBase
    {
        #region Fields
        private readonly LoadedModulesInfo _loadedModulesInfo;
        #endregion

        #region Constructors
        public LoadedModulesInfoViewModel(LoadedModulesInfo loadedModulesInfo)
        {
            LoadedModulesInfo = loadedModulesInfo;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("LoadedModules")]
        public LoadedModulesInfo LoadedModulesInfo { get; private set; }
        #endregion
    }
}