// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportingContext.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.IO;
    using Catel;
    using Catel.Logging;
    using Catel.Reflection;

    public class CrashReportingContext : ICrashReportingContext
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ICrashReportFactory _crashReportFactory;
        private readonly string _rootDirectory;
        #endregion

        #region Constructors
        public CrashReportingContext(ICrashReportFactory crashReportFactory)
        {
            Argument.IsNotNull("crashReportFactory", crashReportFactory);

            _crashReportFactory = crashReportFactory;

            var assembly = AssemblyHelper.GetEntryAssembly();

            _rootDirectory = Path.Combine(Path.GetTempPath(), assembly.Company(), assembly.Title(),
                "supportPackage", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            Directory.CreateDirectory(_rootDirectory);
        }
        #endregion

        #region Properties
        public CrashReport CrashReport { get; private set; }
        public Exception Exception { get; private set; }
        public string SupportFackageFile { get; private set; }
        #endregion

        #region Methods
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

        public string RegisterSupportPackageFile(string relativeFilePath)
        {
            Argument.IsNotNullOrWhitespace("relativeFilePath", relativeFilePath);

            var fullPath = Path.Combine(_rootDirectory, relativeFilePath);

            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            SupportFackageFile = fullPath;

            return fullPath;
        }

        public void RegisterException(Exception exception)
        {
            Exception = exception;
            CrashReport = _crashReportFactory.CreateCrashReport(exception);
        }
        #endregion
    }
}