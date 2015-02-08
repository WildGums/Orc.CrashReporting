// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailLogger.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Loggers
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using Catel;
    using Catel.Configuration;
    using Catel.Services;
    using Models;

    public class EmailLogger : ICrashLogger
    {
        #region Fields
        private readonly IConfigurationService _configurationService;
        private readonly IPleaseWaitService _pleaseWaitService;
        #endregion

        #region Constructors
        public EmailLogger(IConfigurationService configurationService, IPleaseWaitService pleaseWaitService)
        {
            Argument.IsNotNull(() => configurationService);
            Argument.IsNotNull(() => pleaseWaitService);

            _configurationService = configurationService;
            _pleaseWaitService = pleaseWaitService;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return "Email"; }
        }
        #endregion

        #region Methods
        public void LogCrashReport(CrashReport crashReport, string fileToAttach)
        {
            Argument.IsNotNull(() => crashReport);

            var emailTo = _configurationService.GetValue(EmailLoggerSettings.EmailTo, EmailLoggerSettings.EmailToDefaultValue);
            var emailSubject = _configurationService.GetValue(EmailLoggerSettings.EmailSubject, EmailLoggerSettings.EmailSubjectDefaultValue);
            var emailBody = crashReport.Exception.ToString();

            var mailTo = string.Format("mailto:{0}?subject={1}&body={2}", emailTo, emailSubject, emailBody);

            Process.Start(mailTo);
        }
        #endregion
    }
}