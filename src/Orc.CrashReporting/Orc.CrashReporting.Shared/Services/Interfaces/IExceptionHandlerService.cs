// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandlerService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IExceptionHandlerService
    {
        #region Methods
        Task HandleException(Exception exception);
        #endregion
    }
}