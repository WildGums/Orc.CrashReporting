// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Threading.Tasks;
    using Catel;
    using Catel.IoC;
    using Catel.Logging;
    using Orc.SupportPackage;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IServiceLocator _serviceLocator;
        private readonly ISupportPackageService _supportPackageService;
        private readonly ITypeFactory _typeFactory;
        private ICrashReporterService _crashReporterService;
        #endregion

        #region Constructors
        public ExceptionHandlerService(IServiceLocator serviceLocator, ISupportPackageService supportPackageService,
            ITypeFactory typeFactory)
        {
            Argument.IsNotNull(nameof(serviceLocator), serviceLocator);
            Argument.IsNotNull(nameof(supportPackageService), supportPackageService);
            Argument.IsNotNull(nameof(typeFactory), typeFactory);

            _serviceLocator = serviceLocator;
            _supportPackageService = supportPackageService;
            _typeFactory = typeFactory;
        }
        #endregion

        #region Properties
        private ICrashReporterService CrashReporterService
        {
            get
            {
                if (_crashReporterService == null)
                {
                    // can't be injected, because the inplementation could be registered later
                    _crashReporterService = _serviceLocator.ResolveType<ICrashReporterService>();
                }

                return _crashReporterService;
            }
        }
        #endregion

        #region Methods
        public async Task HandleExceptionAsync(Exception exception)
        {

            using (var context = _typeFactory.CreateInstance<CrashReportingContext>())
            {
                try
                {
                    _serviceLocator.RegisterInstance<ICrashReportingContext>(context);

                    if (exception != null)
                    {
                        context.RegisterException(exception);
                    }

                    var supportPackageFile = context.RegisterSupportPackageFile("SupportPackage.zip");

                    await _supportPackageService.CreateSupportPackageAsync(supportPackageFile);

                    await CrashReporterService.ShowCrashReportAsync(context);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Failed to handle exception:{Environment.NewLine}{exception?.GetExceptionInfo() ?? "no exception"}");
                }
                finally
                {
                    _serviceLocator.RemoveType<ICrashReportingContext>();
                }
            }
        }
        #endregion
    }
}