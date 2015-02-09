// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class SystemInfoViewModel : ViewModelBase
    {
        #region Constructors
        public SystemInfoViewModel(SystemInfo systemInfo)
        {
            Argument.IsNotNull(() => systemInfo);

            SystemInfo = systemInfo;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("Details")]
        public SystemInfo SystemInfo { get; private set; }
        #endregion
    }
}