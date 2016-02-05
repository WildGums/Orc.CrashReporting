// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PleaseWaitService.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Services
{
    using System.Windows.Input;
    using Catel;
    using Catel.Logging;
    using Catel.Services;

    public class PleaseWaitService : IPleaseWaitService
    {
        #region Fields

        #region Constants
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        #endregion

        protected readonly IDispatcherService _dispatcherService;
        private Cursor _previousCursor;
        #endregion

        #region Constructors
        public PleaseWaitService(IDispatcherService dispatcherService)
        {
            Argument.IsNotNull(() => dispatcherService);

            _dispatcherService = dispatcherService;
        }
        #endregion

        #region Properties
        public int ShowCounter { get; private set; }
        #endregion

        #region IPleaseWaitService Members
        public virtual void Show(string status = "")
        {
            if (ShowCounter <= 0)
            {
                ShowCounter = 1;
            }

            UpdateStatus(status);

            _dispatcherService.BeginInvokeIfRequired(() =>
            {
                if (_previousCursor == null)
                {
                    _previousCursor = Mouse.OverrideCursor;
                }

                Mouse.OverrideCursor = Cursors.Wait;
            });
        }

        public virtual void Show(PleaseWaitWorkDelegate workDelegate, string status = "")
        {
            Show(status);

            try
            {
                workDelegate();
            }
            finally
            {
                Hide();
            }
        }

        public virtual void UpdateStatus(string status)
        {
            if (!string.IsNullOrWhiteSpace(status))
            {
                Log.Info(status);
            }
        }

        public virtual void UpdateStatus(int currentItem, int totalItems, string statusFormat = "")
        {
            // not required
        }

        public virtual void Hide()
        {
            ShowCounter = 0;

            _dispatcherService.BeginInvokeIfRequired(() =>
            {
                Mouse.OverrideCursor = _previousCursor;

                _previousCursor = null;
            });
        }

        public virtual void Push(string status = "")
        {
            if (ShowCounter == 0)
            {
                Show(status);
            }
            else
            {
                ShowCounter++;
            }
        }

        public virtual void Pop()
        {
            ShowCounter--;

            if (ShowCounter <= 0)
            {
                Hide();
            }
        }
        #endregion
    }
}