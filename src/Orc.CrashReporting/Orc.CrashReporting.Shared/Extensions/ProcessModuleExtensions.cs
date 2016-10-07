// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessModuleExtensions.cs" company="WildGums">
//   Copyright (c) 2008 - 2016 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Diagnostics;

    public static class ProcessModuleExtensions
    {
        #region Methods
        public static string GetFileVersion(this ProcessModule module)
        {
            try
            {
                return module.FileVersionInfo.FileVersion;
            }
            catch (Exception)
            {
                // ignored
            }

            return string.Empty;
        }
        #endregion
    }
}