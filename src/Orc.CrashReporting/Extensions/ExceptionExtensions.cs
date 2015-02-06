// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Extensions
{
    using System;
    using System.Text;

    public static class ExceptionExtensions
    {
        #region Methods
        public static string GetExceptionInfo(this Exception exception)
        {
            var exceptionInfo = new StringBuilder();
            exceptionInfo
                .AppendLine("Exception classes:")
                .AppendLine(exception.GetExceptionTypeStack())
                .AppendLine("Exception messages:")
                .AppendLine(exception.GetExceptionMessageStack())
                .AppendLine("Stack Traces:")
                .AppendLine(exception.GetExceptionCallStack());

            return exceptionInfo.ToString();
        }

        public static string GetExceptionCallStack(this Exception exception)
        {
            return exception.GetExceptionStackedMessage(ex => ex.StackTrace, "--- Next Call Stack:");
        }

        public static string GetExceptionTypeStack(this Exception exception)
        {
            return exception.GetExceptionStackedMessage(ex => " " + ex.GetType());
        }

        public static string GetExceptionMessageStack(this Exception exception)
        {
            return exception.GetExceptionStackedMessage(ex => " " + ex.Message);
        }

        private static string GetExceptionStackedMessage(this Exception exception, Func<Exception, string> stackLevelToString, string subStackHeader = null)
        {
            if (exception.InnerException == null)
            {
                return stackLevelToString(exception);
            }

            var message = new StringBuilder();
            message.AppendLine(GetExceptionStackedMessage(exception.InnerException, stackLevelToString, subStackHeader));

            if (!string.IsNullOrWhiteSpace(subStackHeader))
            {
                message.AppendLine(subStackHeader);
            }

            message.AppendLine(stackLevelToString(exception));
            return (message.ToString());
        }
        #endregion
    }
}