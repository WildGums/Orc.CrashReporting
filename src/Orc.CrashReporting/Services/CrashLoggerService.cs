// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashLoggerService.cs" company="Wild Gums">
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
    using Loggers;

    public class CrashLoggerService : ICrashLoggerService
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        #endregion

        #region Constructors
        public CrashLoggerService(ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => typeFactory);

            _typeFactory = typeFactory;
        }
        #endregion

        #region Methods
        public IEnumerable<ICrashLogger> GetAllCrashLoggers()
        {
            var crashLoggerTypes = (from type in TypeCache.GetTypes()
                where !type.IsAbstractEx() && type.IsClassEx() &&
                      type.ImplementsInterfaceEx<ICrashLogger>()
                select type).ToList();

            foreach (var crashLoggerType in crashLoggerTypes)
            {
                yield return (ICrashLogger) _typeFactory.CreateInstance(crashLoggerType);
            }
        }
        #endregion
    }
}