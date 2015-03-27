// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class CrashReportViewModel : ViewModelBase
    {
        public IEnumerable<CrashReportProviderMenuItem> CrashReportProviders { get; set; }

        #region Constructors
        public CrashReportViewModel(ICrashReportingContext crashReportingContext, ICrashReportProviderMenuService crashReportProviderMenuService)
        {            
            Argument.IsNotNull(() => crashReportingContext);
            Argument.IsNotNull(() => crashReportProviderMenuService);

            CrashReport = crashReportingContext.CrashReport;
            CrashReportProviders = crashReportProviderMenuService.GetCrashReporterProviders();
        }
        #endregion

        #region Properties
        [Model]
        [Expose("Message")]
        public CrashReport CrashReport { get; set; }
        #endregion
    }
}