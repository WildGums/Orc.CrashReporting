// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadedModulesInfoViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;

    internal class LoadedModulesInfoViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Constructors
        public LoadedModulesInfoViewModel(LoadedModulesInfo loadedModulesInfo)
        {
            Argument.IsNotNull(() => loadedModulesInfo);

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