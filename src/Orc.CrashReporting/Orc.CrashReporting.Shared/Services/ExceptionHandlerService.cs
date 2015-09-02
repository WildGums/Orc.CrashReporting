// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Threading.Tasks;
    using Catel;
    using Catel.IoC;
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
            using (var disposableToken = exception.UseInReportingContext())
            {
                var context = disposableToken.Instance;

                var supportFackageFile = context.RegisterSupportPackageFile("SupportPackage.zip");

                await _supportPackageService.CreateSupportPackageAsync(supportFackageFile);

                CrashReporterService.ShowCrashReport(exception);
            }
        }
        #endregion
    }
}