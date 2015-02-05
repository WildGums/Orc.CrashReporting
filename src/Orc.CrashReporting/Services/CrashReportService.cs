// --------------------------------------------------------------------------------------------------------------------
// <copyright file="crashReportService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using Catel;
    using Catel.IoC;
    using Models;

    public class CrashReportService : ICrashReportService
    {
        private readonly ITypeFactory _typeFactory;

        public CrashReportService(ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => typeFactory);

            _typeFactory = typeFactory;
        }

        public CrashReport CreateCrashReport(Exception exception)
        {
            Argument.IsNotNull(() => exception);

            return _typeFactory.CreateInstanceWithParametersAndAutoCompletion<CrashReport>(exception);
        }
    }
}