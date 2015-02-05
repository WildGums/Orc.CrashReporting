// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    public class CrashReportViewModel : ViewModelBase
    {
        #region Constructors
        public CrashReportViewModel(CrashReport crashReport)
        {
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