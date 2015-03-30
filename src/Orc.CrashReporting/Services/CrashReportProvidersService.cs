// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProvidersService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Catel;
    using Catel.IoC;
    using Catel.Reflection;

    public class CrashReportProvidersService : ICrashReportProvidersService
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        #endregion

        #region Constructors
        public CrashReportProvidersService(ITypeFactory typeFactory)
        {
            Argument.IsNotNull("typeFactory", typeFactory);

            _typeFactory = typeFactory;
        }
        #endregion

        private IList<ICrashReportProvider> _crashReportProviders;
        #region Methods
        public IEnumerable<ICrashReportProvider> GetAllCrashReportProviders()
        {
            if (_crashReportProviders == null)
            {
                _crashReportProviders = new List<ICrashReportProvider>();
                var crashLoggerTypes = (from type in TypeCache.GetTypes()
                    where !type.IsAbstractEx() && type.IsClassEx() &&
                          type.ImplementsInterfaceEx<ICrashReportProvider>()
                    select type).ToList();

                foreach (var crashLoggerType in crashLoggerTypes)
                {
                    _crashReportProviders.Add((ICrashReportProvider) _typeFactory.CreateInstance(crashLoggerType));
                }
            }

            return _crashReportProviders;

        }
        #endregion
    }
}