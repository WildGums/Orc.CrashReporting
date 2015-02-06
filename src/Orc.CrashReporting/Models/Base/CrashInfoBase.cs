// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashInfoBase.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using Catel;
    using Catel.Data;

    public abstract class CrashInfoBase : ModelBase, ICrashInfo
    {
        #region Constructors
        public CrashInfoBase(string title, CrashReport crashReport)
        {
            Argument.IsNotNullOrWhitespace(() => title);
            Argument.IsNotNull(() => crashReport);

            Title = title;
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        #endregion
    }
}