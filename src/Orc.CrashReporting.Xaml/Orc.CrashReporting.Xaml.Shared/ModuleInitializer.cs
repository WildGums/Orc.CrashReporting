using Catel.IoC;
using Catel.MVVM;
using Orc.CrashReporting;
using Orc.CrashReporting.Views;
using Orc.CrashReporting.Services;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;
        
        serviceLocator.RegisterType<ICrashReporterService, CrashReporterService>();
        serviceLocator.RegisterType<ICrashReportProviderMenuService, CrashReportProviderMenuService>();
        serviceLocator.RegisterType<IDefaultCrashReportProviderService, DefaultCrashReportProviderService>();
    }
}