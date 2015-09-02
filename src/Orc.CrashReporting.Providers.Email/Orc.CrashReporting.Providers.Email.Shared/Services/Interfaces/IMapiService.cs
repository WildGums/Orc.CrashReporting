// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapiService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using Models;

    public interface IMapiService
    {
        #region Methods
        bool SendMailPopup(Email email);
        #endregion
    }
}