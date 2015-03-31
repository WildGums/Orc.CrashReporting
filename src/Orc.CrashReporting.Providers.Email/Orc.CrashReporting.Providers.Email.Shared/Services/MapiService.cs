// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapiService.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Catel;
    using Catel.IO;
    using Catel.Logging;
    using Extensions;
    using Models;
    using Native;

    public class MapiService : IMapiService
    {
        #region Fields
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IMapiErrorHandlingService _mapiErrorHandlingService;
        #endregion

        #region Constructors
        public MapiService(IMapiErrorHandlingService mapiErrorHandlingService)
        {
            Argument.IsNotNull(() => mapiErrorHandlingService);

            _mapiErrorHandlingService = mapiErrorHandlingService;
        }
        #endregion

        #region Methods
        public bool SendMailPopup(Email email)
        {
            Argument.IsNotNull(() => email);

            var result = Mapi32.MAPIInitialize(IntPtr.Zero);
            try
            {
                if (result == 0)
                {
                    var error = SendMail(email, Mapi32.MAPI_LOGON_UI | Mapi32.MAPI_DIALOG);
                    return error <= 1;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Fail to send email.");
            }
            finally
            {
                Mapi32.MAPIUninitialize();
            }

            return false;
        }

        private IntPtr GetAttachmentsPtr(IEnumerable<string> attachments, out int fileCount)
        {
            Argument.IsNotNull(() => attachments);

            fileCount = 0;
            if (attachments == null)
            {
                return IntPtr.Zero;
            }

            var count = attachments.Count();

            if ((count <= 0) || (count > Mapi32.MaxAttachments))
            {
                return IntPtr.Zero;
            }

            var size = Marshal.SizeOf(typeof (Mapi32.MapiFileDesc));
            var intPtr = Marshal.AllocHGlobal(count*size);

            var mapiFileDesc = new Mapi32.MapiFileDesc {position = -1};
            var ptr = intPtr;

            foreach (var strAttachment in attachments)
            {
                mapiFileDesc.name = Path.GetFileName(strAttachment);
                mapiFileDesc.path = strAttachment;
                Marshal.StructureToPtr(mapiFileDesc, ptr, false);
                ptr += size;
            }

            fileCount = count;
            return intPtr;
        }

        private int SendMail(Email email, int how)
        {
            Argument.IsNotNull(() => email);

            var msg = new Mapi32.MapiMessage {subject = email.Subject, noteText = email.Body};

            var mapiRecipDescs = email.GetRecepients().ToArray();

            msg.recips = GetRecipientsPtr(mapiRecipDescs, out msg.recipCount);
            msg.files = GetAttachmentsPtr(email.Attachments, out msg.fileCount);

            var errorCode = Mapi32.MAPISendMail(IntPtr.Zero, IntPtr.Zero, msg, how, 0);
            if (errorCode > 1)
            {
                _mapiErrorHandlingService.HandleError(errorCode);
            }

            Cleanup(ref msg);
            return errorCode;
        }

        private static void Cleanup(ref Mapi32.MapiMessage msg)
        {
            Argument.IsNotNull("masg", msg);

            var size = Marshal.SizeOf(typeof (Mapi32.MapiFileDesc));
            IntPtr ptr;

            if (msg.recips != IntPtr.Zero)
            {
                ptr = msg.recips;
                for (var i = 0; i < msg.recipCount; i++)
                {
                    Marshal.DestroyStructure(ptr, typeof (Mapi32.MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.recips);
            }

            if (msg.files != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof (Mapi32.MapiFileDesc));

                ptr = msg.files;
                for (var i = 0; i < msg.fileCount; i++)
                {
                    Marshal.DestroyStructure(ptr, typeof (Mapi32.MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.files);
            }
        }

        private IntPtr GetRecipientsPtr(IEnumerable<Mapi32.MapiRecipDesc> recipients, out int recipCount)
        {
            Argument.IsNotNull(() => recipients);

            recipCount = 0;
            var mapiRecipDescs = recipients as Mapi32.MapiRecipDesc[] ?? recipients.ToArray();
            var count = mapiRecipDescs.Count();

            if (count == 0)
            {
                return IntPtr.Zero;
            }

            var size = Marshal.SizeOf(typeof (Mapi32.MapiRecipDesc));
            var intPtr = Marshal.AllocHGlobal(count*size);

            var ptr = intPtr;
            foreach (var mapiDesc in mapiRecipDescs)
            {
                Marshal.StructureToPtr(mapiDesc, ptr, false);
                ptr += size;
            }

            recipCount = count;
            return intPtr;
        }
        #endregion
    }
}