// --------------------------------------------------------------------------------------------------------------------
// <copyright file="crashInfoService.cs" company="Wild Gums">
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

    public class CrashInfoService : ICrashInfoService
    {
        #region Fields
        private readonly ITypeFactory _typeFactory;
        private readonly IList<Type> _types;
        #endregion

        #region Constructors
        public CrashInfoService(ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => typeFactory);

            _typeFactory = typeFactory;

            _types = new List<Type>();
        }
        #endregion

        #region Methods
        public void AddCrashInfo<T>() where T : ICrashInfo
        {
            // don't used Catel.Reflection.TypeCahe because need to keep order
            _types.Add(typeof (T));
        }

        public IEnumerable<ICrashInfo> GetAllCrashInfos(CrashReport crashReport)
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