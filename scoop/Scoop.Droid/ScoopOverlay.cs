using Android.Graphics;
using Android.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using System;
using static Android.Views.ViewGroup;

namespace Scoop.Droid
{
    [Preserve(AllMembers = true)]
    public class ScoopOverlay : IScoopOverlay
    {
        public ScoopConfiguration Configuration { get; set; }

        public void ShowOverlay()
        {
            Mvx.Trace($"{nameof(ShowOverlay)} called");

            var context = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            var overlayView = new Android.Widget.TextView(context)
            {
                Text = $"Testing: {DateTime.Now.ToString(Configuration.DateTimeFormat)}"
            };

            var flags = WindowManagerFlags.Fullscreen | WindowManagerFlags.WatchOutsideTouch | WindowManagerFlags.AllowLockWhileScreenOn | WindowManagerFlags.NotTouchable | WindowManagerFlags.NotFocusable;

            var layoutParams = new WindowManagerLayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, WindowManagerTypes.ApplicationPanel, flags, Format.Translucent)
            {
                Gravity = GravityFlags.Top | GravityFlags.Right
            };

            var windowManager = context.WindowManager;

            // TODO :: deal with WindowManagerBadTokenExceptions
            windowManager.AddView(overlayView, layoutParams);
        }
    }
}
