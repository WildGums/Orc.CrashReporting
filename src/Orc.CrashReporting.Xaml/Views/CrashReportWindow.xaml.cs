// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportWindow.xaml.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Xaml.Views
{
    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for CrashReportWindow.xaml
    /// </summary>
    internal partial class CrashReportWindow
    {
        #region Constructors
        public CrashReportWindow()
            : this(null)
        {
            InitializeComponent();
        }

        public CrashReportWindow(CrashReportViewModel viewModel)
            : base(viewModel, DataWindowMode.Custom)
        {
            InitializeComponent();
        }
        #endregion
    }
}