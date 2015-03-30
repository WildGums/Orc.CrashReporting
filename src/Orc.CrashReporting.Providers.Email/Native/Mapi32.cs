// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapi32.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Native
{
    using System;
    using System.Runtime.InteropServices;

    public class Mapi32
    {
        #region Delegates
        public enum HowTo
        {
            MAPI_ORIG = 0,
            MAPI_TO,
            MAPI_CC,
            MAPI_BCC
        };
        #endregion

        #region Fields
        public const int MAPI_LOGON_UI = 0x00000001;
        public const int MAPI_DIALOG = 0x00000008;
        public const int MaxAttachments = 20;
        #endregion

        #region Methods
        [DllImport("MAPI32.DLL")]
        public static extern int MAPISendMail(IntPtr sess, IntPtr hwnd, MapiMessage message, int flg, int rsv);
        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MapiMessage
        {
            public int reserved;
            public string subject;
            public string noteText;
            public string messageType;
            public string dateReceived;
            public string conversationID;
            public int flags;
            public IntPtr originator;
            public int recipCount;
            public IntPtr recips;
            public int fileCount;
            public IntPtr files;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MapiFileDesc
        {
            public int reserved;
            public int flags;
            public int position;
            public string path;
            public string name;
            public IntPtr type;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MapiRecipDesc
        {
            public int reserved;
            public int recipClass;
            public string name;
            public string address;
            public int eIDSize;
            public IntPtr entryID;
        }
    }
}