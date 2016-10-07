// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailReportProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Linq;
    using System.Threading.Tasks;
    using Catel;
    using Catel.Configuration;
    using Models;

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
        public async Task SendCrashReportAsync(CrashReport crashReport, string fileToAttach)
        {
            Argument.IsNotNull(() => crashReport);

            var email = new Email();

            var emailTo = _configurationService.GetRoamingValue(EmailSettings.Recipient, EmailSettings.RecipientDefaultValue);
            var exceptionInfo = crashReport.CrashDetails.OfType<ExceptionInfo>().FirstOrDefault();
            var emailBody = exceptionInfo == null ? string.Empty : exceptionInfo.FullExceptionText;

            email.RecipientsTo.Add(emailTo);
            email.Body = emailBody;
            email.Subject = _configurationService.GetRoamingValue(EmailSettings.Subject, EmailSettings.SubjectDefaultValue);

            email.Attachments.Add(fileToAttach);

            _mapiService.SendMailPopup(email);
        }
        #endregion
    }
}