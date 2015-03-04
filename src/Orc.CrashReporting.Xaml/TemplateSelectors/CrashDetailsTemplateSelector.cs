// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsTemplateSelector.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.TemplateSelectors
{
    using System.Windows;
    using System.Windows.Controls;
    using Catel;
    using Models;

    internal class CrashDetailsTemplateSelector : DataTemplateSelector
    {
        #region Properties
        public DataTemplate ExceptionTemplate { get; set; }
        public DataTemplate SystemInfoTemplate { get; set; }
        public DataTemplate AdditionatInfoTemplate { get; set; }
        public DataTemplate LoadedModulesTemplate { get; set; }
        #endregion

        #region Methods
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Argument.IsNotNull(() => item);
            Argument.IsNotNull(() => container);

            var crashDetails = item as ICrashInfo;
            if (crashDetails == null)
            {
                return base.SelectTemplate(item, container);
            }

            switch (crashDetails.Title)
            {
                case CrashDetails.ExceptionDetailsTitle:
                    return ExceptionTemplate;

                case CrashDetails.SystemInfoTitle:
                    return SystemInfoTemplate;
                    
                case CrashDetails.AdditionalInfo:
                    return AdditionatInfoTemplate;
                    
                case CrashDetails.LoadedModulesInfo:
                    return LoadedModulesTemplate;
            }

            return base.SelectTemplate(item, container);
        }
        #endregion
    }
}