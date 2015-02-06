// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Catel;
    using Catel.IoC;
    using Models;
    using Services;

    internal class CrashReporterInitializer
    {
        #region Fields
        private readonly ICrashInfoProvider _crashInfoProvider;
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        public CrashReporterInitializer(ICrashInfoProvider crashInfoProvider, IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => crashInfoProvider);
            Argument.IsNotNull(() => serviceLocator);

            _crashInfoProvider = crashInfoProvider;
            _serviceLocator = serviceLocator;

            InitializeUnhandledCatcher();
            InitializeCrashInfoProvider();
        }
        #endregion

        #region Methods
        private void InitializeUnhandledCatcher()
        {
            _serviceLocator.RegisterTypeAndInstantiate<UnhandledCatcher>();
        }

        private void InitializeCrashInfoProvider()
        {
            _crashInfoProvider.RegisterCrashInfo<AdditionalInfo>();
            _crashInfoProvider.RegisterCrashInfo<ExceptionInfo>();
            _crashInfoProvider.RegisterCrashInfo<SystemInfo>();
            _crashInfoProvider.RegisterCrashInfo<LoadedModulesInfo>();
        }
        #endregion
    }
}