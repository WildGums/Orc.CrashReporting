namespace Orc.CrashReporting.Services
{
    using System;

    class ExceptionPolicy
    {
         
    }

    public class ExceptionHandlingPolicy
    {
         
    }

    public interface IExceptionHandlerService
    {
        void HandleException(Exception exception, ExceptionHandlingPolicy policy);
    }
}