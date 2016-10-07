// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandlerService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IExceptionHandlerService
    {
        #region Methods
        Task HandleExceptionAsync(Exception exception);
        #endregion
    }
}