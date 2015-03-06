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

    public class EmailReportProvider : ICrashReportProvider
    {
        #region Fields
        private readonly IConfigurationService _configurationService;
        private readonly ICrashReportingContext _crashReportingContext;
        #endregion

        #region Constructors
        public EmailReportProvider(IConfigurationService configurationService, ICrashReportingContext crashReportingContext)
        {
            Argument.IsNotNull(() => configurationService);
            Argument.IsNotNull(() => crashReportingContext);

            _configurationService = configurationService;
            _crashReportingContext = crashReportingContext;
        }
        #endregion

        #region Properties
        public string Title
        {
            get { return "Email"; }
        }
        #endregion

        #region Methods
        public void SendCrashReport(CrashReport crashReport, string fileToAttach)
        {
            Argument.IsNotNull(() => crashReport);

            var emailTo = _configurationService.GetValue(EmailLoggerSettings.EmailTo, EmailLoggerSettings.EmailToDefaultValue);
            var emailSubject = _configurationService.GetValue(EmailLoggerSettings.EmailSubject, EmailLoggerSettings.EmailSubjectDefaultValue);
            var exceptionInfo = crashReport.CrashDetails.OfType<ExceptionInfo>().FirstOrDefault();
            var emailBody = exceptionInfo == null ? string.Empty : exceptionInfo.FullExceptionText;

            var mailTo = string.Format("mailto:{0}&subject={1}&body={2}", emailTo, emailSubject, emailBody);

            if (!string.IsNullOrWhiteSpace(fileToAttach) && File.Exists(fileToAttach))
            {
                var uri = new System.Uri(fileToAttach);
                var converted = /*uri.AbsoluteUri;*/ fileToAttach.Replace('\\', '/');
                mailTo += string.Format("&attachment={0}", converted);
            }

            var process = Process.Start(mailTo);
            if (process != null)
            {
                process.WaitForInputIdle();
            }
        }
        #endregion
    }
}