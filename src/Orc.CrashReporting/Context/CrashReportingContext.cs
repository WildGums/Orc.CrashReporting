﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportingContext.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting
{
    using System;
    using System.IO;
    using Catel.Logging;
    using Catel.Reflection;

    public class CrashReportingContext : IDisposable, ICrashReportingContext
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly string _rootDirectory;

        public CrashReportingContext()
        {
            var assembly = AssemblyHelper.GetEntryAssembly();

            _rootDirectory = Path.Combine(Path.GetTempPath(), assembly.Company(), assembly.Title(),
                "support", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            Directory.CreateDirectory(_rootDirectory);
        }

        public string GetFile(string relativeFilePath)
        {
            var fullPath = Path.Combine(_rootDirectory, relativeFilePath);

            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return fullPath;
        }

        public void Dispose()
        {
            Log.Info("Deleting temporary files from '{0}'", _rootDirectory);

            try
            {
                if (Directory.Exists(_rootDirectory))
                {
                    Directory.Delete(_rootDirectory, true);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete temporary files");
            }
        }
    }
}