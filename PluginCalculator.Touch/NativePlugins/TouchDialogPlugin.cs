using System;
using PluginCalculator.Core.NativePlugins;
using MonoTouch.UIKit;

namespace PluginCalculator.Touch.NativePlugins
{
	public class TouchDialogPlugin : IDialogPlugin
	{

		public void ShowMessage (string title, string message, string button)
		{
			var view = new UIAlertView (title, message, null, button);
			view.InvokeOnMainThread (() => view.Show());
		}

	}
}