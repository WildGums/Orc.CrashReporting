// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    public static class EmailSettings
    {
        #region Fields
        public const string Recipient = "CrashReporting.Providers.Email.Recipient";
        public const string RecipientDefaultValue = "support@company.com";

        public const string Subject = "CrashReporting.Providers.Email.Subject";
        public const string SubjectDefaultValue = "Crash report";
        #endregion
    }
}