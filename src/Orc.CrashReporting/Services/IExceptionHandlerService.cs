namespace Orc.CrashReporting.Services
{
    using System;
    using Models;

    public interface IExceptionHandlerService
    {
        void HandleException(Exception exception, ExceptionHandlingPolicy policy);
    }
}