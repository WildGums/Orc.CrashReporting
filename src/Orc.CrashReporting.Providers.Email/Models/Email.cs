// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Email.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Models
{
    using System.Collections.Generic;

    public class Email
    {
        #region Constructors
        public Email()
        {
            RecipientsTo = new List<string>();
            Attachments = new List<string>();
        }
        #endregion

        #region Properties
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<string> RecipientsTo { get; private set; }
        public IList<string> Attachments { get; private set; }
        #endregion
    }
}