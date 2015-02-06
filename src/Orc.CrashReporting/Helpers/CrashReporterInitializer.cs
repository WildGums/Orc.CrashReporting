// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Catel;
    using Models;
    using Services;

    internal class CrashReporterInitializer
    {
        #region Fields
        private readonly ICrashInfoProvider _crashInfoProvider;
        #endregion

        #region Constructors
        public CrashReporterInitializer(ICrashInfoProvider crashInfoProvider)
        {
            Argument.IsNotNull(() => crashInfoProvider);

            _crashInfoProvider = crashInfoProvider;
            InitializeCrashInfoProvider();
        }
        #endregion

        #region Methods
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