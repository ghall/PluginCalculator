using Android.App;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using PluginCalculator.Core.NativePlugins;

namespace PluginCalculator.Droid.NativePlugins
{
    public class DroidDialogPlugin : IDialogPlugin
    {
        public void ShowMessage(string title, string message, string button)
        {
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            activity.RunOnUiThread(() => new AlertDialog.Builder(activity)
                .SetMessage(message)
                .SetCancelable(true)
                .SetNegativeButton(button, CloseDialog)
                .SetTitle(title)
                .Show());
        }

        private void CloseDialog(object sender, DialogClickEventArgs e)
        {
            var dialog = sender as IDialogInterface;
            if (null != dialog)
            {
                dialog.Dismiss();
            }
        }
    }
}