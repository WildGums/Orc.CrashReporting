// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccentColorHelper.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Windows;
    using System.Windows.Media;

    internal class AccentColorHelper
    {
        #region Fields
        private static bool _isAccentColorResourceDictionaryCreated;
        #endregion

        public static void CreateAccentColorResourceDictionary()
        {
            if (_isAccentColorResourceDictionaryCreated)
            {
                return;
            }

            var accentColor = GetAccentColorBrush().Color;
            accentColor.CreateAccentColorResourceDictionary();

            _isAccentColorResourceDictionaryCreated = true;
        }

        private static SolidColorBrush GetAccentColorBrush()
        {
            var accentColorBrush = Application.Current.TryFindResource("AccentColorBrush") as SolidColorBrush;
            if (accentColorBrush != null)
            {
                return accentColorBrush;
            }
            return new SolidColorBrush(Color.FromArgb(255, 0, 122, 204));
        }
    }
}