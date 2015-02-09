// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInitializer.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using Catel.IoC;
using Orc.CrashReporting;
using Orc.CrashReporting.Models;
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
        serviceLocator.RegisterType<ICrashLoggerService, CrashLoggerService>();
        serviceLocator.RegisterType<ICrashReportingContext, CrashReportingContext>(RegistrationType.Transient);

        serviceLocator.RegisterTypeAndInstantiate<CrashReporterInitializer>();
    }
    #endregion
}