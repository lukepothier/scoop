using MvvmCross.Platform.Plugins;
using System.Collections.Generic;

namespace Scoop
{
    [Preserve(AllMembers = true)]
    public class ScoopConfiguration : IMvxPluginConfiguration
    {
        public bool IncludeDateTime { get; set; }
        public string DateTimeFormat { get; set; }
        public bool IncludePlatform { get; set; }
        public bool IncludeVersionNumber { get; set; }
        public bool IncludeDeviceName { get; set; }
        public bool IncludeNetworkState { get; set; }
        public int FontSize { get; set; }
        public ICollection<string> CustomData { get; set; }
    }
}
