// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsNavigatorViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;
    using Services;

    internal class CrashDetailsNavigatorViewModel : ViewModelBase
    {
        #region Fields
        private readonly ICrashReporterManager _crashReporterManager;
        #endregion

        #region Constructors
        public CrashDetailsNavigatorViewModel(ICrashReporterManager crashReporterManager)
        {
            Argument.IsNotNull(() => crashReporterManager);

            _crashReporterManager = crashReporterManager;
            CrashReporter = _crashReporterManager.CrashReporter;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("CrashDetailsList")]
        [Expose("SelectedCrashDetails")]
        public CrashReporter CrashReporter { get; private set; }
        #endregion
    }
}