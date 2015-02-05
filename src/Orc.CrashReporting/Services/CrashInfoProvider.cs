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
        private readonly IServiceLocator _serviceLocator;
        private readonly ITypeFactory _typeFactory;
        private readonly IList<object> _tags;
        private IList<Type> _types;
        #endregion

        #region Constructors
        public CrashInfoProvider(IServiceLocator serviceLocator, ITypeFactory typeFactory)
        {
            Argument.IsNotNull(() => serviceLocator);

            _serviceLocator = serviceLocator;
            _typeFactory = typeFactory;
            _tags = new List<object>();

            _types = new List<Type>();
        }
        #endregion

        #region Methods
        public void RegisterCrashInfo<T>() where T : ICrashInfo
        {
            /*var tag = typeof (T).ToString();
            if (_tags.Contains(_tags))
            {
                return;
            }

            _tags.Add(tag);

            _serviceLocator.RegisterTypeWithTag<ICrashInfo, T>(tag, RegistrationType.Transient);*/

            _types.Add(typeof(T));
        }

        public IEnumerable<ICrashInfo> ResolveAllCrashInfos(CrashReport crashReport)
        {
            Argument.IsNotNull(() => crashReport);

            /*foreach (var tag in _tags)
            {
                yield return _serviceLocator.ResolveTypeUsingParametersAndAutoCompletion<ICrashInfo>(new object[] {crashReport}, tag);
            }*/

            foreach (var type in _types)
            {
                yield return (ICrashInfo)_typeFactory.CreateInstanceWithParametersAndAutoCompletion(type, crashReport);
            }
        }
        #endregion
    }
}