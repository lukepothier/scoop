using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using System.Collections.Generic;

namespace Scoop.iOS
{
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxConfigurablePlugin
    {
        bool _includeDateTime = true;
        bool _includePlatform = true;
        bool _includeVersionNumber = true;
        bool _includeDeviceName = true;
        bool _includeNetworkState;
        string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss zzz";
        int _fontSize = 8;
        ICollection<string> _customData;

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (configuration == null)
                return;

            var scoopConfiguration = (ScoopConfiguration)configuration;

            _includeDateTime = scoopConfiguration.IncludeDateTime;
            _includePlatform = scoopConfiguration.IncludePlatform;
            _includeVersionNumber = scoopConfiguration.IncludeVersionNumber;
            _includeDeviceName = scoopConfiguration.IncludeDeviceName;
            _includeNetworkState = scoopConfiguration.IncludeNetworkState;
            _dateTimeFormat = scoopConfiguration.DateTimeFormat;
            _fontSize = scoopConfiguration.FontSize;
            _customData = scoopConfiguration.CustomData;
        }

        public void Load()
        {
            var configuration = new ScoopConfiguration
            {
                IncludeDateTime = _includeDateTime,
                IncludePlatform = _includePlatform,
                IncludeVersionNumber = _includeVersionNumber,
                IncludeDeviceName = _includeDeviceName,
                IncludeNetworkState = _includeNetworkState,
                DateTimeFormat = _dateTimeFormat,
                FontSize = _fontSize,
                CustomData = _customData
            };

            var instance = new ScoopOverlay
            {
                Configuration = configuration
            };

            Mvx.RegisterSingleton<IScoopOverlay>(instance);
        }
    }
}
