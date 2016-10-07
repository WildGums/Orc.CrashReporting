// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapiErrorHandlingService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    public interface IMapiErrorHandlingService
    {
        #region Methods
        void HandleError(int errorCode);
        #endregion
    }
}