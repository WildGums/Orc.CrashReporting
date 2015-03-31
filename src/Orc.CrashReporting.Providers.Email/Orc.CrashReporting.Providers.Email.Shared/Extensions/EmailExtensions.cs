// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailExtensions.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Native;

    internal static class EmailExtensions
    {
        #region Methods
        public static IEnumerable<Mapi32.MapiRecipDesc> GetRecepients(this Email email)
        {
            return email.RecipientsTo.Select(recepient => new Mapi32.MapiRecipDesc {recipClass = (int) Mapi32.HowTo.MAPI_TO, name = recepient});
        }
        #endregion
    }
}