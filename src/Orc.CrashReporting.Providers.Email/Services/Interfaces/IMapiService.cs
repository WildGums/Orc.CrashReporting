// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapiService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using Models;

    public interface IMapiService
    {
        bool SendMailPopup(Email email);
    }
}