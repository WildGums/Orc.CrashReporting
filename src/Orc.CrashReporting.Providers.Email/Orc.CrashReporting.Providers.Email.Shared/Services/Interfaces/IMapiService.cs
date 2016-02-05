// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapiService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
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