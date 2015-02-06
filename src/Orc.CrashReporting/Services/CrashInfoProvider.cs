// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashInfoProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Collections.Generic;
    using Catel;
    using Catel.IoC;
    using Models;

    public class CrashInfoProvider : ICrashInfoProvider
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        private readonly IList<Type> _types;
        #endregion

        #region Constructors
        public CrashInfoProvider(ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => typeFactory);

            _typeFactory = typeFactory;

            _types = new List<Type>();
        }
        #endregion

        #region Methods
        public void RegisterCrashInfo<T>() where T : ICrashInfo
        {
            _types.Add(typeof (T));
        }

        public IEnumerable<ICrashInfo> ResolveAllCrashInfos(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            foreach (var type in _types)
            {
                yield return (ICrashInfo) _typeFactory.CreateInstanceWithParametersAndAutoCompletion(type, crashReport);
            }
        }
        #endregion
    }
}