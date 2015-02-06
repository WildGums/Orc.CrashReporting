// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrashDetailsTemplateSelector.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Orc.CrashReporting.TemplateSelectors
{
    using System.Windows;
    using System.Windows.Controls;
    using Models;

    public class CrashDetailsTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var crashDetails = item as ICrashInfo;
            if (crashDetails == null)
            {
                return base.SelectTemplate(item, container);
            }           

            switch (crashDetails.Title)
            {
                case CrashDetails.ExceptionDetailsTitle:
                    return ExceptionTemplate;
                    break;
                case CrashDetails.SystemInfoTitle:
                    return SystemInfoTemplate;
                    break;
                case CrashDetails.AdditionalInfo:
                    return AdditionatInfoTemplate;
                    break;
                case CrashDetails.LoadedModulesInfo:
                    return LoadedModulesTemplate;
                    break;
            }

            return base.SelectTemplate(item, container);
        }

        public DataTemplate ExceptionTemplate { get; set; }
        public DataTemplate SystemInfoTemplate { get; set; }
        public DataTemplate AdditionatInfoTemplate { get; set; }
        public DataTemplate LoadedModulesTemplate { get; set; }
    }
}