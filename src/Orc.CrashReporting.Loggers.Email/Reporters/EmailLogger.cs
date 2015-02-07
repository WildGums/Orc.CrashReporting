// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailLogger.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Reporters
{
    using System;
    using Models;

    public class EmailLogger : ICrashLogger
    {
        public string Title
        {
            get { return "Email"; }
        }

        public void Report(CrashReport exception, string fileToAttach)
        {
            
        }
    }
}