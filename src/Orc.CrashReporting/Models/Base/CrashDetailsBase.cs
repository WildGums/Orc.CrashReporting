// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsBase.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.Models
{
    using Catel;
    using Catel.Data;
    using Services;

    public abstract class CrashDetailsBase : ModelBase, ICrashDetails
    {
        public CrashDetailsBase(string title, ICrashReporterManager crashReporterManager)
        {            
            Argument.IsNotNullOrWhitespace(() => title);
            Argument.IsNotNull(() => crashReporterManager);

            Title = title;
            crashReporterManager.CrashReporter.CrashDetailsList.Add(this);
        }

        public string Title { get; private set; }
    }
}