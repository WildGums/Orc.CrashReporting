// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;
    using Models;
    using Services;

    internal class CrashReportViewModel : ViewModelBase
    {
        #region Fields
        private readonly IDefaultCrashReportProviderService _defaultCrashReportProviderService;
        #endregion

        #region Constructors
        public CrashReportViewModel(ICrashReportingContext crashReportingContext, ICrashReportProviderMenuService crashReportProviderMenuService,
            IDefaultCrashReportProviderService defaultCrashReportProviderService)
        {
            _defaultCrashReportProviderService = defaultCrashReportProviderService;
            Argument.IsNotNull(() => crashReportingContext);
            Argument.IsNotNull(() => crashReportProviderMenuService);
            Argument.IsNotNull(() => defaultCrashReportProviderService);

            CrashReport = crashReportingContext.CrashReport;
            CrashReportProviders = crashReportProviderMenuService.CrashReportProviders;
            var defaultCrashReportProvider = defaultCrashReportProviderService.GetDefaultCrashReportProvider();
            DefaultCrashReportProvider = CrashReportProviders.FirstOrDefault(x => Equals(x.Provider, defaultCrashReportProvider));

            DefaultProviderAction = new TaskCommand(OnDefaultProviderActionExecute, OnDefaultProviderActionCanExecute);
        }

        
        #endregion

        #region Properties
        public IEnumerable<CrashReportProviderMenuItem> CrashReportProviders { get; set; }

        [Model]
        [Expose("DefaultProviderHeader", "Title")]
        public CrashReportProviderMenuItem DefaultCrashReportProvider { get; set; }

        public TaskCommand DefaultProviderAction { get; private set; }

        private async Task OnDefaultProviderActionExecute()
        {
            if (DefaultCrashReportProvider == null || DefaultCrashReportProvider.Command == null)
            {
                return;
            }

            await Task.Factory.StartNew(() => DefaultCrashReportProvider.Command.Execute(null));
        }

        private bool OnDefaultProviderActionCanExecute()
        {
            if (DefaultCrashReportProvider == null || DefaultCrashReportProvider.Command == null)
            {
                return false;
            }

            return DefaultCrashReportProvider.Command.CanExecute(null);
        }

        [Model]
        [Expose("Message")]
        public CrashReport CrashReport { get; set; }
        #endregion


    }
}