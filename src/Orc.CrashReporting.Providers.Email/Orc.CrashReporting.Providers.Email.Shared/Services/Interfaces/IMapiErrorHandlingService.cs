// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapiErrorHandlingService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
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