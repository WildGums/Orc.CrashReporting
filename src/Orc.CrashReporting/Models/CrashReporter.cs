// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReporter.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.Collections.Generic;
    using Catel.Data;

    public class CrashReporter : ModelBase
    {
        #region Constructors
        public CrashReporter()
        {
            CrashDetailsList = new List<ICrashDetails>();
        }
        #endregion

        #region Properties
        public IList<ICrashDetails> CrashDetailsList { get; private set; }
        public ICrashDetails SelectedCrashDetails { get; set; }
        #endregion
    }
}