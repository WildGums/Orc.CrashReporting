// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandlerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;

    public interface IExceptionHandlerService
    {
        #region Methods
        void HandleException(Exception exception);
        #endregion
    }
}