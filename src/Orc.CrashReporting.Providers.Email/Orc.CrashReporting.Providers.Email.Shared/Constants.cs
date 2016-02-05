// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    public static class EmailLoggerSettings
    {
        #region Fields
        public const string EmailTo = "CrashReporting.Providers.Email.EmailTo";
        public const string EmailToDefaultValue = "support@company.com";
        public const string EmailSubject = "CrashReporting.Providers.Email.EmailSubject";
        public const string EmailSubjectDefaultValue = "CrashReport";
        #endregion
    }
}