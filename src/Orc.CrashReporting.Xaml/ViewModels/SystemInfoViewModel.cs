// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfoViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.ViewModels
{
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class SystemInfoViewModel : ViewModelBase
    {
        public SystemInfoViewModel(SystemInfo systemInfo)
        {
            SystemInfo = systemInfo;
        }

        [Model]
        [Expose("Details")]
        public SystemInfo SystemInfo { get; private set; }
    }
}