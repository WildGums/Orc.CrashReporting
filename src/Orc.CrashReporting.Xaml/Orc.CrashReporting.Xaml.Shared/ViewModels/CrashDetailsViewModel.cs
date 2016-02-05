// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.ComponentModel;
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;

    internal class CrashDetailsViewModel : ViewModelBase
    {
        #region Constructors
        public CrashDetailsViewModel(ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull(() => crashReportingContext);

            CrashReport = crashReportingContext.CrashReport;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("CrashDetailsToDisplay")]
        public CrashReport CrashReport { get; private set; }

        [DefaultValue(0)]
        public int SelectedIndex { get; set; }
        #endregion
    }
}