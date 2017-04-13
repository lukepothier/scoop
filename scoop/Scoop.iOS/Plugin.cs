using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Scoop.iOS
{
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IScoopOverlay>(new ScoopOverlay());
        }
    }
}
