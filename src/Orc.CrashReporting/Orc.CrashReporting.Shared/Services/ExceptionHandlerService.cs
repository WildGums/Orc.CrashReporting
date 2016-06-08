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
    using Catel.Services;
    using Orc.SupportPackage;

    public class ExceptionHandlerService : IExceptionHandlerService
    {
        #region Fields
        private readonly IServiceLocator _serviceLocator;
        private readonly ISupportPackageService _supportPackageService;
        private ICrashReporterService _crashReporterService;
        #endregion

        #region Constructors
        public ExceptionHandlerService(IServiceLocator serviceLocator, ISupportPackageService supportPackageService)
        {
            Argument.IsNotNull("serviceLocator", serviceLocator);
            Argument.IsNotNull("supportPackageService", supportPackageService);

            _serviceLocator = serviceLocator;
            _supportPackageService = supportPackageService;
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
            var typeFactory = this.GetTypeFactory();

            using (var context = typeFactory.CreateInstance<CrashReportingContext>())
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
                finally
                {
                    _serviceLocator.RemoveType<ICrashReportingContext>();
                }
            }
        }
        #endregion
    }
}