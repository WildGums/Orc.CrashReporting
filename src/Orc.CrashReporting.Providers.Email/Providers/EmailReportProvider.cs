// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailReportProvider.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Catel;
    using Catel.Configuration;
    using Models;
    using Native;

    public class EmailReportProvider : ICrashReportProvider
    {
        #region Fields
        private readonly IConfigurationService _configurationService;
        private readonly ICrashReportingContext _crashReportingContext;
        private readonly IMapiService _mapiService;
        #endregion

        #region Constructors
        public EmailReportProvider(IConfigurationService configurationService, ICrashReportingContext crashReportingContext, IMapiService mapiService)
        {
            Argument.IsNotNull(() => configurationService);
            Argument.IsNotNull(() => crashReportingContext);
            Argument.IsNotNull(() => mapiService);

            _configurationService = configurationService;
            _crashReportingContext = crashReportingContext;
            _mapiService = mapiService;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return "Email crash report"; }
        }
        #endregion

        #region Methods
        public void SendCrashReport(CrashReport crashReport, string fileToAttach)
        {
            Argument.IsNotNull(() => crashReport);
            
            var email = new Email();
            
            var emailTo = _configurationService.GetValue(EmailLoggerSettings.EmailTo, EmailLoggerSettings.EmailToDefaultValue);
            var exceptionInfo = crashReport.CrashDetails.OfType<ExceptionInfo>().FirstOrDefault();
            var emailBody = exceptionInfo == null ? string.Empty : exceptionInfo.FullExceptionText;

            email.RecipientsTo.Add(emailTo);
            email.Body = emailBody;
            email.Subject = _configurationService.GetValue(EmailLoggerSettings.EmailSubject, EmailLoggerSettings.EmailSubjectDefaultValue);

            email.Attachments.Add(fileToAttach);

            _mapiService.SendMailPopup(email);
        }
        #endregion
    }
}