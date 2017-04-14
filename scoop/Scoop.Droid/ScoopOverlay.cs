using Android.Graphics;
using Android.Runtime;
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

            var flags = WindowManagerFlags.NotTouchable | WindowManagerFlags.NotFocusable;

            // TODO :: When Android O is out, switch from WindowManagerTypes.SystemOverlay to the Xamarin equivalent of TYPE_APPLICATION_OVERLAY: https://developer.android.com/reference/android/view/WindowManager.LayoutParams.html#TYPE_APPLICATION_OVERLAY
            var layoutParams = new WindowManagerLayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent, WindowManagerTypes.SystemOverlay, flags, Format.Translucent)
            {
                Gravity = GravityFlags.Top | GravityFlags.Right
            };

            var windowManager = context.ApplicationContext.GetSystemService(Android.Content.Context.WindowService).JavaCast<IWindowManager>();

            windowManager.AddView(overlayView, layoutParams);
        }
    }
}
