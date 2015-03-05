// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemInfo.cs" company="Wild Gums">
//   Copyright (c) 2008 - 2015 Wild Gums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.CrashReporting
{
    using System.Text;
    using Catel;
    using Orc.SystemInfo;

    public class SystemInfo : CrashInfoBase
    {
        #region Fields
        private readonly ISystemInfoService _systemInfoService;
        #endregion

        #region Constructors
        public SystemInfo(ISystemInfoService systemInfoService)
            : base(CrashDetails.SystemInfoTitle)
        {
            Argument.IsNotNull("systemInfoService", systemInfoService);

            _systemInfoService = systemInfoService;

            Initialize();
        }
        #endregion

        #region Properties
        public string Details { get; set; }
        #endregion

        #region Methods
        private async void Initialize()
        {
            var systemInfo = await _systemInfoService.GetSystemInfo();
            var stringBuilder = new StringBuilder();
            foreach (var infoElement in systemInfo)
            {
                if (string.IsNullOrEmpty(infoElement.Name))
                {
                    stringBuilder.AppendLine(infoElement.Value);
                }
                else
                {
                    stringBuilder.AppendFormat("{0}: {1}", infoElement.Name, infoElement.Value).AppendLine();
                }
            }

            Details = stringBuilder.ToString();
        }
        #endregion
    }
}