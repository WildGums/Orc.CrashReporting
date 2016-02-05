// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInitializer.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using Catel.IoC;
using Catel.Services;
using Catel.Services.Models;
using Orc.CrashReporting;
using Orc.CrashReporting.Services;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    #region Methods
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;

        serviceLocator.RegisterType<ICrashReportFactory, CrashReportFactory>();
        serviceLocator.RegisterType<ICrashInfoService, CrashInfoService>();
        serviceLocator.RegisterType<IExceptionHandlerService, ExceptionHandlerService>();
        serviceLocator.RegisterType<ICrashReportProvidersService, CrashReportProvidersService>();
        serviceLocator.RegisterType<IPleaseWaitService, Orc.CrashReporting.Services.PleaseWaitService>();

        var languageService = serviceLocator.ResolveType<ILanguageService>();
        languageService.RegisterLanguageSource(new LanguageResourceSource("Orc.CrashReporting", "Orc.CrashReporting.Properties", "Resources"));

        serviceLocator.RegisterTypeAndInstantiate<CrashReporterInitializer>();
    }
    #endregion
}