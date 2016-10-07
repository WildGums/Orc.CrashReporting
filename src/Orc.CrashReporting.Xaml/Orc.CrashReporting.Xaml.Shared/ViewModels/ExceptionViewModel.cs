// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionViewModel.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;

    internal class ExceptionViewModel : ViewModelBase
    {
        #region Constructors
        public ExceptionViewModel(ExceptionInfo exceptionInfo)
        {
            Argument.IsNotNull(() => exceptionInfo);

            ExceptionInfo = exceptionInfo;
        }
        #endregion

        #region Properties
        [Model(SupportIEditableObject = false)]
        [Expose("FullExceptionText")]
        public ExceptionInfo ExceptionInfo { get; private set; }
        #endregion
    }
}