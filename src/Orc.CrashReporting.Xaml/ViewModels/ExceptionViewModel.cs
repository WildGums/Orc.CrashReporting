// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel.Fody;
    using Catel.MVVM;
    using Models;

    internal class ExceptionViewModel : ViewModelBase, ICrashInfo
    {
        public ExceptionViewModel(ExceptionInfo exceptionInfo)
        {
            
        }

        [Model]
        [Expose("FullExceptionText")]
        public ExceptionInfo ExceptionInfo { get; private set; }
    }
}