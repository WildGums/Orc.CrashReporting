// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;
    using Services;

    internal class CrashDetailsViewModel : ViewModelBase
    {
        private readonly ICrashReporterManager _crashReporterManager;

        public CrashDetailsViewModel(ICrashReporterManager crashReporterManager)
        {
            Argument.IsNotNull(() => crashReporterManager);
            _crashReporterManager = crashReporterManager;
            
            CrashReporter = _crashReporterManager.CrashReporter;
        }

        #region Properties
        [Model]
        [Expose("CrashDetailsList")]
        [Expose("SelectedCrashDetails")]
        public CrashReporter CrashReporter { get; private set; }
        #endregion
    }
}