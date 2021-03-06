﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportProvidersService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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
        private List<ICrashReportProvider> _crashReportProviders;
        #endregion

        #region Constructors
        public CrashReportProvidersService(ITypeFactory typeFactory)
        {
            Argument.IsNotNull("typeFactory", typeFactory);

            _typeFactory = typeFactory;
        }
        #endregion

        #region Methods
        public IEnumerable<ICrashReportProvider> GetAllCrashReportProviders()
        {
            if (_crashReportProviders == null)
            {
                _crashReportProviders = new List<ICrashReportProvider>();
                var crashReportProviders = (from type in TypeCache.GetTypes()
                                            where !type.IsAbstractEx() && type.IsClassEx() && type.ImplementsInterfaceEx<ICrashReportProvider>()
                                            select type).ToList();

                foreach (var crashReportProvider in crashReportProviders)
                {
                    _crashReportProviders.Add((ICrashReportProvider)_typeFactory.CreateInstance(crashReportProvider));
                }
            }

            return _crashReportProviders;
        }
        #endregion
    }
}