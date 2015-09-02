// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapiErrorHandlingService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Collections.Generic;
    using Catel.Logging;

    public class MapiErrorHandlingService : IMapiErrorHandlingService
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly IDictionary<int, string> _errors = new Dictionary<int, string>
        {
            {0, "OK"},
            {1, "User abort"},
            {2, "General MAPI failure"},
            {3, "MAPI login failure"},
            {4, "Disk full"},
            {5, "Insufficient memory"},
            {6, "Access denied"},
            {7, "Unknown error"},
            {8, "Too many sessions"},
            {9, "Too many files were specified"},
            {10, "Too many recipients were specified"},
            {11, "A specified attachment was not found"},
            {12, "Attachment open failure"},
            {13, "Attachment write failure"},
            {14, "Unknown recipient"},
            {15, "Bad recipient type"},
            {16, "No messages"},
            {17, "Invalid message"},
            {18, "Text too large"},
            {19, "Invalid session"},
            {20, "Type not supported"},
            {21, "A recipient was specified ambiguously"},
            {22, "Message in use"},
            {23, "Network failure"},
            {24, "Invalid edit fields"},
            {25, "Invalid recipients"},
            {26, "Not supported"}
        };
        #endregion

        #region Methods
        public void HandleError(int errorCode)
        {
            string message;
            _errors.TryGetValue(errorCode, out message);

            message = string.Format("MAPI error: [{0}]", string.IsNullOrEmpty(message) ? errorCode.ToString() : message);

            Log.Error(message);
        }
        #endregion
    }
}