// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportFactory.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using Catel;
    using Catel.IoC;
    using Models;

    public class CrashReportFactory : ICrashReportFactory
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        private readonly IServiceLocator _serviceLocator;
        #endregion

        #region Constructors
        public CrashReportFactory(ITypeFactory typeFactory, IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => typeFactory);
            Argument.IsNotNull(() => serviceLocator);

            _typeFactory = typeFactory;
            _serviceLocator = serviceLocator;
        }
        #endregion

        #region Methods
        public CrashReport CreateCrashReport(Exception exception)
        {
            Argument.IsNotNull(() => exception);

            var crashReport = _typeFactory.CreateInstanceWithParametersAndAutoCompletion<CrashReport>(exception);
            _serviceLocator.RegisterInstance(typeof(CrashReport), crashReport);

            return crashReport;
        }
        #endregion
    }
}