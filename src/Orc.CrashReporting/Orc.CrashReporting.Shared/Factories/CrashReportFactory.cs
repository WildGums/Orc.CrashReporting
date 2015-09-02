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

    public class CrashReportFactory : ICrashReportFactory
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        #endregion

        #region Constructors
        public CrashReportFactory(ITypeFactory typeFactory)
        {
            Argument.IsNotNull("typeFactory", typeFactory);

            _typeFactory = typeFactory;
        }
        #endregion

        #region Methods
        public CrashReport CreateCrashReport(Exception exception)
        {
            Argument.IsNotNull("exception", exception);

            var crashReport = _typeFactory.CreateInstanceWithParametersAndAutoCompletion<CrashReport>(exception);
            return crashReport;
        }
        #endregion
    }
}