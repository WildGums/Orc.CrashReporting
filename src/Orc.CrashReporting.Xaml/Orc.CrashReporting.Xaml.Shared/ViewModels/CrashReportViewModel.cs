// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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
        public CrashReportViewModel(ICrashReportingContext crashReportingContext, ICrashReportProviderMenuService crashReportProviderMenuService, IDefaultCrashReportProviderService defaultCrashReportProviderService)
        {
            Argument.IsNotNull(() => crashReportingContext);
            Argument.IsNotNull(() => crashReportProviderMenuService);
            Argument.IsNotNull(() => defaultCrashReportProviderService);

            _defaultCrashReportProviderService = defaultCrashReportProviderService;

            CrashReport = crashReportingContext.CrashReport;
            CrashReportProviders = crashReportProviderMenuService.CrashReportProviders;
            var defaultCrashReportProvider = defaultCrashReportProviderService.GetDefaultCrashReportProvider();
            DefaultCrashReportProvider = CrashReportProviders.FirstOrDefault(x => Equals(x.Provider, defaultCrashReportProvider));

            DefaultProviderAction = new Command(OnDefaultProviderActionExecute, OnDefaultProviderActionCanExecute);
            AppName = Assembly.GetExecutingAssembly().GetName().Name;
            AccentColorHelper.CreateAccentColorResourceDictionary();

            Title = string.Format("{0} has encountered a problem", AppName);
        }
        #endregion

        #region Properties
        public string AppName { get; set; }

        public IEnumerable<CrashReportProviderMenuItem> CrashReportProviders { get; set; }

        [Model]
        [Expose("DefaultProviderHeader", "Title")]
        public CrashReportProviderMenuItem DefaultCrashReportProvider { get; set; }

        [Model]
        [Expose("Message")]
        public CrashReport CrashReport { get; set; }
        #endregion

        #region Commands
        public Command DefaultProviderAction { get; private set; }

        private void OnDefaultProviderActionExecute()
        {
            if (DefaultCrashReportProvider == null || DefaultCrashReportProvider.Command == null)
            {
                return;
            }

            DefaultCrashReportProvider.Command.Execute(null);
        }

        private bool OnDefaultProviderActionCanExecute()
        {
            if (DefaultCrashReportProvider == null || DefaultCrashReportProvider.Command == null)
            {
                return false;
            }

            return DefaultCrashReportProvider.Command.CanExecute(null);
        }
        #endregion
    }
}