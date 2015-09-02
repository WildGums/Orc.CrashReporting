// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Catel;
    using Catel.IoC;
    using Services;

    internal class CrashReporterInitializer
    {
        #region Fields
        private readonly ICrashInfoService _crashInfoService;
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        public CrashReporterInitializer(ICrashInfoService crashInfoService, IServiceLocator serviceLocator)
        {
            Argument.IsNotNull("crashInfoService", crashInfoService);
            Argument.IsNotNull("serviceLocator", serviceLocator);

            _crashInfoService = crashInfoService;
            _serviceLocator = serviceLocator;

            InitializeUnhandledCatcher();
            InitializeCrashInfoProvider();
        }
        #endregion

        #region Methods
        private void InitializeUnhandledCatcher()
        {
            _serviceLocator.RegisterTypeAndInstantiate<UnhandledExceptionWatcher>();
        }

        private void InitializeCrashInfoProvider()
        {
            _crashInfoService.AddCrashInfo<AdditionalInfo>();
            _crashInfoService.AddCrashInfo<ExceptionInfo>();
            _crashInfoService.AddCrashInfo<SystemInfo>();
            _crashInfoService.AddCrashInfo<LoadedModulesInfo>();
        }
        #endregion
    }
}