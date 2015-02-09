// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class CrashReportViewModel : ViewModelBase
    {
        #region Constructors
        public CrashReportViewModel(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            CrashReport = crashReport;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("Message")]
        public CrashReport CrashReport { get; set; }
        #endregion
    }
}