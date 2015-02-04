// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel.MVVM;
    using Models;

    internal class ExceptionViewModel : ViewModelBase, ICrashDetails
    {
        public ExceptionViewModel()
        {
            Title = "Exc";
        }
    }
}