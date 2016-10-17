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
                SetCurrentValue(ResizeModeProperty, ResizeMode.CanResize);

                SetCurrentValue(MinWidthProperty, (double)550);
                SetCurrentValue(MinHeightProperty, (double)350);
            }
            else
            {
                SetCurrentValue(ResizeModeProperty, ResizeMode.NoResize);

                SetCurrentValue(MinWidthProperty, (double)550);
                SetCurrentValue(MinHeightProperty, (double)230);

                SetCurrentValue(WidthProperty, (double)550);
                SetCurrentValue(HeightProperty, (double)230);
            }
        }
    }
}