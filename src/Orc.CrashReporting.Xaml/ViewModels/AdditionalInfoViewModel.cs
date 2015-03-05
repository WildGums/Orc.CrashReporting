// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalInfoViewModel.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting.ViewModels
{
    using Catel;
    using Catel.Fody;
    using Catel.MVVM;

    internal class AdditionalInfoViewModel : ViewModelBase
    {
        #region Constructors
        public AdditionalInfoViewModel(AdditionalInfo additionalInfo)
        {
            Argument.IsNotNull(() => additionalInfo);

            AdditionalInfo = additionalInfo;
        }
        #endregion

        #region Properties
        [Model]
        [Expose("Text")]
        public AdditionalInfo AdditionalInfo { get; set; }
        #endregion
    }
}