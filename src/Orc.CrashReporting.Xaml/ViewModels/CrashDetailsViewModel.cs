// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.ComponentModel;
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class CrashDetailsViewModel : ViewModelBase
    {
        #region Constructors
        public CrashDetailsViewModel(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            CrashReport = crashReport;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("CrashDetails")]
        public CrashReport CrashReport { get; private set; }

        [DefaultValue(0)]
        public int SelectedIndex { get; set; }
        #endregion
    }
}