// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashReportWindow.xaml.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.Xaml.Views
{
    using System.Windows;
    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for CrashReportWindow.xaml
    /// </summary>
    public partial class CrashReportWindow
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

            expander.Collapsed += OnExpanderCollapsed;
            expander.Expanded += OnExpanderExpanded;

            UpdateSize();
        }
        #endregion

        private void OnExpanderCollapsed(object sender, RoutedEventArgs e)
        {
            UpdateSize();
        }

        private void OnExpanderExpanded(object sender, RoutedEventArgs e)
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            if (expander.IsExpanded)
            {
                ResizeMode = ResizeMode.CanResize;

                MinWidth = 550;
                MinHeight = 350;
            }
            else
            {
                ResizeMode = ResizeMode.NoResize;

                MinWidth = 550;
                MinHeight = 230;

                Width = 550;
                Height = 230;
            }
        }
    }
}