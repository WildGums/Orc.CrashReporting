// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporterInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Services
{
    using Catel;
    using Models;

    internal class CrashReporterInitializer
    {
        private readonly ICrashInfoProvider _crashInfoProvider;

        public CrashReporterInitializer(ICrashInfoProvider crashInfoProvider)
        {
            Argument.IsNotNull(() => crashInfoProvider);

            _crashInfoProvider = crashInfoProvider;
            InitializeCrashInfoProvider();
        }

        private void InitializeCrashInfoProvider()
        {
            _crashInfoProvider.RegisterCrashInfo<ExceptionInfo>();
            _crashInfoProvider.RegisterCrashInfo<SystemInfo>();
            _crashInfoProvider.RegisterCrashInfo<AdditionalInfoInfo>();
        }
    }
}