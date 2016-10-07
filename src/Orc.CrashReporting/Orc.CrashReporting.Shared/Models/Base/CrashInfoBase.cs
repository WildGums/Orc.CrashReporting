// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashInfoBase.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Catel;
    using Catel.Data;
    using Orc.SupportPackage;

    public abstract class CrashInfoBase : ModelBase, ICrashInfo
    {
        #region Constructors
        public CrashInfoBase(string title)
        {
            Argument.IsNotNullOrWhitespace("title", title);

            Title = title;
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        #endregion

        #region Methods
        public virtual void ProvideSupportPackageData(ISupportPackageContext supportPackageContext)
        {
        }
        #endregion
    }
}